Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class main
    Inherits System.Windows.Forms.Form
    Dim trlisten As Thread
    Dim trShutdown As Thread
    Dim trReboot As Thread
    Dim trLogOff As Thread
    Dim trKirimStatus As Thread
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
    Dim mysqlconn As New MySqlConnection("Server=192.168.3.254; Port=3306; User Id=admin; Password=admin; Database=Laboratorium")

#Region "Menerima Perintah dari Server"
    Sub shutdown()
        Dim t As Single
        Dim objWMIService, objComputer As Object
        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(8 + 4, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'Shutdown system
            End If
        Next
    End Sub

    Sub reboot()
        Dim t As Single
        Dim objWMIService, objComputer As Object

        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(2 + 4, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'Reboot  system
            End If
        Next
    End Sub

    Sub logoff()
        Dim t As Single
        Dim objWMIService, objComputer As Object

        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(0, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'LogOff  system
            End If
        Next
    End Sub

    Sub ListenToServer()
        'Try

        Dim LISTENING As Boolean
        Dim localhostAddress As IPAddress = ipAddress.Parse(ipAddress.ToString)

        ' PORT 
        Dim port As Integer = 8000

        ' Membuat socket tcp
        Dim tcpList As New TcpListener(localhostAddress, port)
        Try
            tcpList.Start()
            LISTENING = True

            Do While LISTENING

                Do While tcpList.Pending = False And LISTENING = True
                    Thread.Sleep(10)
                Loop

                If Not LISTENING Then Exit Do

                Dim tcpCli As TcpClient = tcpList.AcceptTcpClient()
                Dim ns As NetworkStream = tcpCli.GetStream
                Dim sr As New StreamReader(ns)

                ' Menerima data dari server untuk di kerjakan client
                Dim receivedData As String = sr.ReadLine()
                If receivedData = "###SHUTDOWN###" Then
                    trShutdown = New Thread(AddressOf shutdown)
                    trShutdown.Start()
                End If
                If receivedData = "###REBOOT###" Then
                    trReboot = New Thread(AddressOf reboot)
                    trReboot.Start()
                End If
                If receivedData = "###LOGOFF###" Then
                    trLogOff = New Thread(AddressOf logoff)
                    trLogOff.Start()
                End If

                sr.Close()
                ns.Close()
                tcpCli.Close()
            Loop
            tcpList.Stop()
        Catch ex As Exception
            LISTENING = False
        End Try
    End Sub
#End Region

#Region "Kirim Status Client ke Server"
    Sub KirimStatus()
        'host yang dipakai adalah host server'
        Dim host As String = "192.168.3.254"
        Dim port As Integer = 8000
        Dim tcpCli As New TcpClient(host, port)
        Dim ns As NetworkStream = tcpCli.GetStream
        Dim sw As New StreamWriter(ns)
        sw.WriteLine(ipAddress.ToString)
        sw.Flush()
        sw.Close()
        ns.Close()
        '        MessageBox.Show("Komputer Telah Terkoneksi ke Server")
    End Sub
#End Region

#Region "Load"
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
        Try
            mysqlconn.Open()
            trlisten = New Thread(AddressOf ListenToServer)
            trlisten.Start()

            txtNoKomputer.Text = ""
            txtPass.Text = ""
            txtNoKomputer.Focus()

        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal...")
            splash.Show()
            Me.Hide()
        End Try

    End Sub

    Public Sub setcontrols()

        NotifyIcon1.Visible = False
        PictureBox1.Top = (Me.Height - PictureBox1.Width - 50) / 2
        PictureBox1.Left = (Me.Width - PictureBox1.Width - 50) / 3

        Label4.Top = Label4.Height / 2
        Label4.Left = (Me.Width - Label4.Width - 50) / 2

        Panel1.Width = Label1.Width * 3
        Panel1.Left = (Me.Width / 3 + (Panel1.Width / 3))
        Panel1.Top = (Me.Height - PictureBox1.Width - 50) / 2

        'Sets the location for all of the controls on the form.
        pnlappbar.Width = Me.Width
        pnlappbar.Left = Me.Left
        pnlappbar.Height = 100
        pnlappbar.Top = Me.Height - pnlappbar.Height
        btnCancel.Left = (pnlappbar.Width / 2)
        btnLogin.Left = (btnCancel.Left - btnCancel.Width) - 30
        BtnSignUp.Left = (btnCancel.Left - btnCancel.Width) - 100 * 1.8
        Me.TopMost = True
    End Sub
#End Region

#Region "Cancel Button & Kembali Ke Splash"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtNoKomputer.Clear()
        txtPass.Clear()
        txtNoKomputer.Focus()
        splash.Show()
        Me.Close()
    End Sub

    Private Sub btnclose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.DarkTurquoise
    End Sub
#End Region

#Region "Login"
    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim Sql, NoKomputer, Password As String
        Dim cmd As MySqlCommand
        Dim rdr As MySqlDataReader

        NoKomputer = txtNoKomputer.Text
        Password = txtPass.Text

        Sql = "SELECT NoKomputer, Password, IP_Address FROM client WHERE NoKomputer='" + NoKomputer + "' AND Password='" + Password + " 'AND IP_Address='" + ipAddress.ToString + "'"
        cmd = New MySqlCommand(Sql, mysqlconn)

        rdr = cmd.ExecuteReader()

        If rdr.HasRows = True Then
            trlisten = New Thread(AddressOf ListenToServer)
            trlisten.Start()
            trKirimStatus = New Thread(AddressOf KirimStatus)
            trKirimStatus.Start()
        Else
            MessageBox.Show("Kombinasi Username dan Password atau Cek Alamat IP ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNoKomputer.Clear()
            txtPass.Clear()
            txtNoKomputer.Focus()
        End If

        rdr.Close()
        cmd.Dispose()

        NotifyIcon1.Visible = True
        NotifyIcon1.Text = ipAddress.ToString
        Me.Hide()
    End Sub

    Private Sub Login_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.SlateGray
    End Sub

    Private Sub Login_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.DarkTurquoise
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        txtNoKomputer.Clear()
        txtPass.Clear()
        txtNoKomputer.Focus()
        Me.Show()
    End Sub

#End Region

#Region "Sign UP"
    Private Sub BtnSignUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSignUp.Click
        txtNoKomputer.Clear()
        txtPass.Clear()
        txtNoKomputer.Focus()
        Register.Show()
        Me.Close()
    End Sub

    Private Sub BtnSignUp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSignUp.MouseEnter
        BtnSignUp.BackColor = Color.SlateGray
    End Sub

    Private Sub BtnSignUp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSignUp.MouseLeave
        BtnSignUp.BackColor = Color.DarkTurquoise
    End Sub

#End Region

End Class