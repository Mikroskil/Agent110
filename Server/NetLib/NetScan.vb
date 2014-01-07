Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading

Public Class NetScan
    Inherits Control

    '
    ' Fired when each ping completes
    ' 
    Public Event PingComplete As EventHandler(Of NetScanCompletedEventArgs)

    '
    ' Fired when all pings complete
    '
    Public Event NetScanComplete As EventHandler(Of EventArgs)

    '
    ' Limits the number of pings happening simultaniously
    '
    Const THREAD_COUNT As Integer = 200
    Private pingBlock As Semaphore = New Semaphore(0, THREAD_COUNT)

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        '
        ' Needed before Control.Invoke will work.
        '
        Dim i As IntPtr = Me.Handle

        '
        ' All items in the semaphore start out locked.  This releases them all.
        '
        pingBlock.Release(THREAD_COUNT)
    End Sub

    ''' <summary>
    ''' Starts ping operations on a background thread.
    ''' </summary>
    ''' <param name="pr">Contains the starting and ending IP address for the pings.</param>
    Public Sub Start(ByVal pr As PingRange)
        Dim t As Thread = New Thread(New ParameterizedThreadStart(AddressOf pingWorker_DoWork))
        t.Start(New PingRange(pr.StartRange, pr.EndRange))

    End Sub

    ''' <summary>
    ''' Loops through the IP address and does the pings.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <param name="o">Start and end IP addresses to ping.</param>
    Private Sub pingWorker_DoWork(ByVal o As Object)
        Dim pingRange As PingRange = CType(o, PingRange)

        '
        ' Get the starting and ending address as a byte array to make it easier to
        ' loop through.
        '
        Dim startRange As Byte() = pingRange.StartRange.GetAddressBytes()
        Dim endRange As Byte() = pingRange.EndRange.GetAddressBytes()

        '
        ' Each thread that's spawned will be put in this list so that it's easy to
        ' know when they've all completed.
        '
        Dim threads As LinkedList(Of Thread) = New LinkedList(Of Thread)()

        '
        ' Loop through each octet in the IP address, and ping on a background thread.
        '
        For o0 As Byte = startRange(0) To endRange(0)
            For o1 As Byte = startRange(1) To endRange(1)
                For o2 As Byte = startRange(2) To endRange(2)
                    For o3 As Byte = startRange(3) To endRange(3)

                        pingBlock.WaitOne()
                        Dim t As Thread = New Thread(New ParameterizedThreadStart(AddressOf DoPing))
                        t.Start(New IPAddress(New Byte() {o0, o1, o2, o3}))
                        threads.AddLast(t)

                    Next o3
                Next o2
            Next o1
        Next o0

        '
        ' Wait until all the pings are done.
        '
        For Each ln As Thread In threads
            ln.Join()
        Next

        '
        ' Raise an event saying the pings are done on the main UI thread.
        '
        Try

            Me.Invoke(New RaiseNetScanCompleteHandler(AddressOf RaiseNetScanComplete))

        Catch ex As InvalidOperationException

            ' Can happen if the application is closed while pings are going on in 
            ' the background.  Safe to ignore.
        End Try
    End Sub

    Private Delegate Sub RaiseNetScanCompleteHandler()

    ''' <summary>
    ''' Fire an event to the client on the same thread that they invoked this  
    ''' object on so that the UI can be safely updated.
    ''' </summary>
    Private Sub RaiseNetScanComplete()
        RaiseEvent NetScanComplete(Me, New EventArgs())
    End Sub

    ''' <summary>
    ''' Perform the actual ping, and release the semaphore so that another thread
    ''' can go.
    ''' </summary>
    ''' <param name="o">IP address to ping</param>
    Private Sub DoPing(ByVal o As Object)
        Dim ip As IPAddress = CType(o, IPAddress)
        Dim newPing As Ping = New Ping()
        Dim pr As PingReply = newPing.Send(ip)
        pingBlock.Release()

        Try

            Me.Invoke(New PingResults(AddressOf Results), New Object() {pr})

        Catch ex As InvalidOperationException

            ' Can happen if the application is closed while pings are going on in 
            ' the background.  Safe to ignore.
        End Try
    End Sub

    Protected Delegate Sub PingResults(ByVal pr As PingReply)

    ''' <summary>
    ''' Fire an event when each ping completes so that the client can show
    ''' progress
    ''' </summary>
    ''' <param name="pr">Ping Results</param>
    Sub Results(ByVal pr As PingReply)

        Dim e As NetScanCompletedEventArgs = New NetScanCompletedEventArgs()
        e.Reply = pr
        RaiseEvent PingComplete(Me, e)
    End Sub
End Class
