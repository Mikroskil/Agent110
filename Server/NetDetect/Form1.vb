Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading
Imports NetLib
Imports System.Globalization

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        ' Get the IP address of this machine.
        '
        Dim ip As IPAddress = Dns.GetHostAddresses(Dns.GetHostName())(0)
        '
        ' Figure out the IP range for a class C network, around the machine IP.
        '
        If ip IsNot Nothing Then
            Dim range As Byte() = ip.GetAddressBytes()
            range(3) = 2
            startIPTextBox.Text = (New IPAddress(range)).ToString()
            range(3) = 254
            endIPTextBox.Text = (New IPAddress(range)).ToString()
        End If
    End Sub

    Private Sub scanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanButton.Click
        resultsListView.Items.Clear()
        '
        ' Get the start and end IP addresses from the text boxes.
        '
        Dim startIP As IPAddress = Nothing
        Try

            startIP = IPAddress.Parse(startIPTextBox.Text)

        Catch ex As FormatException

            MessageBox.Show("Start address is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            Exit Sub
        End Try

        Dim endIP As IPAddress = Nothing
        Try

            endIP = IPAddress.Parse(endIPTextBox.Text)

        Catch ex As FormatException

            MessageBox.Show("End address is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            Exit Sub
        End Try

        '
        ' The NetScan will perform the pings on separate threads
        '
        Dim ns As NetScan = New NetScan()

        '
        ' Event handler for when each ping completes.
        '
        AddHandler ns.PingComplete, AddressOf PingComplete

        '
        ' Event handler for when all pings have completed.
        '
        AddHandler ns.NetScanComplete, AddressOf NetScanComplete

        '
        ' Disable the "Scan" button while the pings are running, and start the pings.
        '
        scanButton.Enabled = False
        ns.Start(New PingRange(startIP, endIP))
    End Sub

    Private Sub PingComplete(ByVal s As Object, ByVal ev As NetScanCompletedEventArgs)
        If ev.Reply.Status = IPStatus.Success Then

            Dim li As ListViewItem = New ListViewItem(New String() {ev.Reply.Address.ToString(), ev.Reply.RoundtripTime.ToString(CultureInfo.InvariantCulture) + " ms"})
            resultsListView.Items.Add(li)
        End If
    End Sub

    Private Sub NetScanComplete(ByVal s As Object, ByVal ev As EventArgs)
        scanButton.Enabled = True
    End Sub
End Class