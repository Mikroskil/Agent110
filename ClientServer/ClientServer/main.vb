Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class main
    Inherits System.Windows.Forms.Form
    Dim koneksi As SqlConnection
    Dim trlisten As Thread
    Dim trShutdown As Thread
    Dim trReboot As Thread
    Dim trLogOff As Thread
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)

    '============================================================
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
    End Sub 'Bagian System Shutdown

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
    End Sub 'Bagian Reboot Windows

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
    End Sub 'Bagian LogOff System

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
                'ListBox1.Items.Add("Data from " & "128.10.20.63")

                Dim ns As NetworkStream = tcpCli.GetStream
                Dim sr As New StreamReader(ns)

                ' Mengambil data dari client 
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

                Dim returnedData As String = "###OK###" '& " From Server"
                Dim sw As New StreamWriter(ns)
                sw.WriteLine(returnedData)
                sw.Flush()
                sr.Close()
                sw.Close()
                ns.Close()
                tcpCli.Close()
            Loop
            tcpList.Stop()
        Catch ex As Exception
            'error
            LISTENING = False
        End Try
    End Sub 'Bagian Koneksi terhadap server
    '============================================================

#Region "Set Posisi Desain Dinamis Form"
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
        Dim strKoneksi As String
        strKoneksi = "Data Source=asus-2015c; Initial Catalog = Laboratorium; Integrated Security=True"
        koneksi = New SqlConnection(strKoneksi)

        Try
            koneksi.Open()
        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal !!")
        End Try

        txtUser.Text = ""
        txtPass.Text = ""
        txtUser.Focus()

    End Sub

    Public Sub setcontrols()
        PictureBox1.Top = (Me.Height - PictureBox1.Width - 50) / 2
        PictureBox1.Left = (Me.Width - PictureBox1.Width - 50) / 3

        Label4.Top = Label4.Height / 2
        Label4.Left = (Me.Width - Label4.Width - 50) / 2

        Panel1.Width = Label1.Width * 3
        Panel1.Left = (Me.Width / 3 + (Panel1.Width / 3))
        Panel1.Top = (Me.Height - PictureBox1.Width - 50) / 2

        Me.LblIP.Text = splash.LblIP.Text.ToString

        'Sets the location for all of the controls on the form.
        pnlappbar.Width = Me.Width
        pnlappbar.Left = Me.Left
        pnlappbar.Height = 100
        pnlappbar.Top = Me.Height - pnlappbar.Height
        btnCancel.Left = (pnlappbar.Width / 2) - 10
        btnLogin.Left = (btnCancel.Left - btnCancel.Width) - 30
        BtnSignUp.Left = (btnCancel.Left - btnCancel.Width) - 100 * 1.8
        Me.TopMost = True
    End Sub
#End Region 'Set Form

#Region "Cancel Button"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
        splash.Visible = True

    End Sub

    Private Sub btnclose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.DarkTurquoise
    End Sub
#End Region 'Kembali Ke Tampilan Awal'

#Region "Login"
    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim Sql, user, pass As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        user = txtUser.Text
        pass = txtPass.Text

        Sql = "SELECT Nim,Pass FROM Client WHERE Nim='" + user + "' AND Pass='" + pass + "'"
        cmd = New SqlCommand(Sql, koneksi)

        rdr = cmd.ExecuteReader()

        If rdr.HasRows = True Then
            splash.Show()
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = LblIP.Text
        Else
            MessageBox.Show("Kombinasi Username ,Password dan Hak Akses Salah", "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUser.Focus()

        End If

        rdr.Close()
        cmd.Dispose()

    End Sub

    Private Sub Login_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.SlateGray
    End Sub

    Private Sub Login_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.DarkTurquoise
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.Show()
    End Sub

#End Region 'Login Button'

#Region "Registrasi"
    Private Sub BtnSignUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSignUp.Click
        Me.Hide()
        Register.Show()
    End Sub

    Private Sub BtnSignUp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSignUp.MouseEnter
        BtnSignUp.BackColor = Color.SlateGray
    End Sub

    Private Sub BtnSignUp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSignUp.MouseLeave
        BtnSignUp.BackColor = Color.DarkTurquoise
    End Sub

#End Region 'Button SignUp'

End Class