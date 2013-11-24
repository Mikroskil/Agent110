Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Public Class splash
    Inherits System.Windows.Forms.Form

#Region "Di sini Code untuk Validasi Shutdown, Restart, LogOff"
    Dim trlisten As Thread

    Sub LISTENING()
        'Bagian Try
        Dim LISTENING As Boolean
        Dim LocalhostAddress As IPAddress = ipAddress.Parse(ipAddress.ToString)
    End Sub
#End Region

    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        pnllogo.Left = (Me.Width - pnllogo.Width) / 2
        pnllogo.Top = (Me.Height - pnllogo.Height) / 2
        LblIP.Text = ipAddress.ToString
        LblIP.Visible = False

    End Sub

#Region "Event Jika Klik"
    Private Sub main_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub piclogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles piclogo.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub lbllogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbllogo.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub lblcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcompany.Click
        Me.Visible = False
        main.Visible = True
    End Sub
#End Region

End Class
