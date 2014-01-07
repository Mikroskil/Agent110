Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO

Public Class Shutdown
    Inherits System.Windows.Forms.Form
    Dim trSendMessage As Thread

    Sub SendMessage()
        Dim host As String = txtClientIP.Text
        Dim port As Integer = 8000
        Try
            'Melakukan validasi request 
            Dim tcpCli As New TcpClient(host, port)
            Dim ns As NetworkStream = tcpCli.GetStream

            Dim sw As New StreamWriter(ns)
            If rbShutdown.Checked = True Then
                sw.WriteLine("###SHUTDOWN###")
            End If
            If rbReboot.Checked = True Then
                sw.WriteLine("###REBOOT###")
            End If
            If rbLogOff.Checked = True Then
                sw.WriteLine("###LOGOFF###")
            End If
            sw.Flush()


            Dim sr As New StreamReader(ns)
            Dim result As String = sr.ReadLine()
            If result = "###OK###" Then
                MsgBox("Operasi Sukses", MsgBoxStyle.Information)
            End If

            sr.Close()
            sw.Close()
            ns.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Hide()
        HOME.Show()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Trim(txtClientIP.Text) = "" Then
            MsgBox("IP Address Client Kosong", MsgBoxStyle.Information)
            txtClientIP.Focus()
            Exit Sub
        Else
            trSendMessage = New Thread(AddressOf SendMessage)
            trSendMessage.Start()
        End If
    End Sub
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMYIP.Text = ipAddress.ToString
    End Sub
End Class
