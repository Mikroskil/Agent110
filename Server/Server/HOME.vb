Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class HOME
    Inherits System.Windows.Forms.Form
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
    Dim trKirimPerintah As Thread
    Dim koneksi As SqlConnection

#Region "Terima status komputer Client jika hidup"

    Sub ListenToClient()
        Dim LISTENING As Boolean
        Dim LocalHostAddress As IPAddress = ipAddress.Parse(ipAddress.ToString)
        Dim port As Integer = 8000
        Dim tcpList As New TcpListener(LocalHostAddress, port)

        Try
            tcpList.Start()
            LISTENING = True

            Do While LISTENING
                If Not LISTENING Then Exit Do
                Dim tcpCli As TcpClient = tcpList.AcceptTcpClient()
                Dim ns As NetworkStream = tcpCli.GetStream
                Dim sr As New StreamReader(ns)
                Dim receivedData As String = sr.ReadLine()

                'Eksekusi database dengan alamat IP yang dikirim dari Client
                Dim strKoneksi, Sql As String
                Dim cmd As SqlCommand
                Dim rdr As SqlDataReader
                strKoneksi = "Data Source=ASUS-1025C\SQLEXPRESS; Initial Catalog = Laboratorium; Integrated Security=True"
                koneksi = New SqlConnection(strKoneksi)
                Try
                    koneksi.Open()
                    Sql = "SELECT IP_Address FROM Client WHERE IP_Address='" + receivedData + "'"
                    cmd = New SqlCommand(Sql, koneksi)
                    rdr = cmd.ExecuteReader()

                    'IF nya perlu perbaikan ini !!!
                    If rdr.HasRows = True Then
                        Kom1.BackColor = Color.Green
                    End If
                    sr.Close()
                    ns.Close()
                    tcpCli.Close()
                Catch ex As Exception

                End Try
            Loop
            tcpList.Stop()
        Catch ex As Exception
            LISTENING = False
        End Try
    End Sub
#End Region

    Sub KirimPerintah()
        'Dim host As String = (ipAddress.ToString)
        'Dim port As Integer = 8000
        'Try
        '    'Lakukan validasi terhadap perintah yang dikirim
        '    Dim tcpCli As New TcpClient(host, port)
        '    Dim ns As NetworkStream = tcpCli.GetStream
        '    Dim sw As New StreamWriter(ns)
        '    If BtnShutdown.PerformClick = True Then

        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub HOME_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanelHome.Top = PanelHome.Height / 5
        PanelHome.Left = (Me.Width - PanelHome.Width - 5) / 20

        Panel1.Top = PanelHome.Height / 5
        Panel1.Left = (Me.Width - PanelHome.Width) / 1.1
        LblAdmin.Text = LoginAdmin.TxtNama.Text
        GroupBox1.Top = GroupBox1.Height / 2
        GroupBox1.Left = (Me.Width - GroupBox1.Width - 5) / 2

        PanelPerintah.Width = Me.Width
        PanelPerintah.Left = Me.Left
        PanelPerintah.Top = Me.Height - PanelPerintah.Height
        BtnShutdown.Left = PanelPerintah.Width / 4
        BtnRestart.Left = PanelPerintah.Width / 4 + (BtnRestart.Width * 2)
        BtnLogOff.Left = PanelPerintah.Width / 3 + (BtnLogOff.Width * 2)
        BtnPing.Left = PanelPerintah.Width / 2 + (BtnPing.Width * 2)


    End Sub

    Private Sub BtnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShutdown.Click
        
    End Sub

    Private Sub BtnLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogOff.Click
        LoginAdmin.TxtID.Clear()
        LoginAdmin.TxtNama.Clear()
        LoginAdmin.TxtPassword.Clear()
        LoginAdmin.Show()
        Me.Hide()
    End Sub
End Class