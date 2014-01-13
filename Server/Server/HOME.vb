Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports Netlib
Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class HOME

#Region "Deklarasi Variabel"
    Inherits System.Windows.Forms.Form
    Dim koneksi As MySqlConnection
    Dim trlisten As Thread
    Dim trKirimPerintah As Thread
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
    Dim PerintahShutdown As Thread
#End Region

#Region "Kumpulan Sub Function"
    Private Sub ShutdownPingComplete(ByVal s As Object, ByVal ev As NetScanCompletedEventArgs)
        If ev.Reply.Status = IPStatus.Success Then
            Dim port As Integer = 8000
            Dim tcpCli As TcpClient
            Dim ns As NetworkStream
            Dim sw As StreamWriter
            tcpCli = New TcpClient(ev.Reply.Address.ToString(), port)
            ns = tcpCli.GetStream
            sw = New StreamWriter(ns)
            sw.WriteLine("###SHUTDOWN###")
            sw.Flush()
            sw.Close()
            ns.Close()
            Dim c As CheckBox
            For Each c In GroupBox1.Controls
                c.BackColor = Color.DimGray
            Next
        End If
    End Sub

    Private Sub RebootPingComplete(ByVal s As Object, ByVal ev As NetScanCompletedEventArgs)
        If ev.Reply.Status = IPStatus.Success Then
            Dim port As Integer = 8000
            Dim tcpCli As TcpClient
            Dim ns As NetworkStream
            Dim sw As StreamWriter
            tcpCli = New TcpClient(ev.Reply.Address.ToString(), port)
            ns = tcpCli.GetStream
            sw = New StreamWriter(ns)
            sw.WriteLine("###REBOOT###")
            sw.Flush()
            sw.Close()
            ns.Close()
            Dim c As CheckBox
            For Each c In GroupBox1.Controls
                c.BackColor = Color.DimGray
            Next
        End If
    End Sub

    Private Sub LogOffPingComplete(ByVal s As Object, ByVal ev As NetScanCompletedEventArgs)
        If ev.Reply.Status = IPStatus.Success Then
            Dim port As Integer = 8000
            Dim tcpCli As TcpClient
            Dim ns As NetworkStream
            Dim sw As StreamWriter
            tcpCli = New TcpClient(ev.Reply.Address.ToString(), port)
            ns = tcpCli.GetStream
            sw = New StreamWriter(ns)
            sw.WriteLine("###LOGOFF###")
            sw.Flush()
            sw.Close()
            ns.Close()
            Dim c As CheckBox
            For Each c In GroupBox1.Controls
                c.BackColor = Color.DimGray
            Next
        End If
    End Sub

    Private Sub NetScanComplete(ByVal s As Object, ByVal ev As EventArgs)
        If BtnShutdown.Enabled = False Or BtnLogOff.Enabled = False Or BtnRestart.Enabled = False Then
            BtnShutdown.Enabled = True
            BtnLogOff.Enabled = True
            BtnRestart.Enabled = True
        End If
    End Sub

    Sub ListenToClient()
        Dim LISTENING As Boolean
        Dim LocalHostAddress As IPAddress = ipAddress.Parse(ipAddress.ToString)
        Dim port As Integer = 8000
        Dim tcpList As New TcpListener(LocalHostAddress, port)

        Try
            tcpList.Start()
            LISTENING = True

            Do While LISTENING

                Do While tcpList.Pending = False And LISTENING = True
                    Thread.Sleep(10)
                Loop

                If Not LISTENING Then Exit Do
                Dim strKoneksi, nama, Sql As String
                Dim cmd As MySqlCommand

                'Eksekusi alamat IP yang dikirim dari Client ke database
                strKoneksi = "Server=192.168.3.254; Port=3306; User Id=admin; Password=admin; Database=Laboratorium"
                koneksi = New MySqlConnection(strKoneksi)

                Try
                    Dim tcpCli As TcpClient = tcpList.AcceptTcpClient()
                    Dim ns As NetworkStream = tcpCli.GetStream
                    Dim sr As New StreamReader(ns)
                    Dim receivedData As String = sr.ReadLine()
                    koneksi.Open()
                    Sql = "SELECT NoKomputer FROM Client WHERE IP_Address='" + receivedData + "'"
                    cmd = New MySqlCommand(Sql, koneksi)

                    'Ini Bagian untuk mengupdate warna CECKBOX client yang sudah login
                    Dim Nomor = cmd.ExecuteScalar
                    Dim i As Integer = 1
                    Dim ck, ck2 As CheckBox
                    For Each ck In GroupBox1.Controls
                        If Nomor = i Then
                            nama = "CheckBox" + CStr(i)
                            For Each ck2 In GroupBox1.Controls
                                If ck2.Name = nama Then
                                    ck2.BackColor = Color.Green
                                End If
                            Next
                        End If
                        i = CInt(i)
                        i += 1
                    Next
                    sr.Close()
                    ns.Close()
                    tcpCli.Close()
                Catch ex As Exception
                    MessageBox.Show("Nomor IP yang di terima salah atau tidak ada")
                End Try
            Loop
            tcpList.Stop()
        Catch ex As Exception
            LISTENING = False
        End Try
    End Sub
#End Region

#Region "Load"
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
        BtnRestart.Left = PanelPerintah.Width / 4 + (BtnRestart.Width * 2.7)
        BtnLogOff.Left = PanelPerintah.Width / 3 + (BtnLogOff.Width * 3.8)
        SignOut.Left = PanelPerintah.Width / 2 + (SignOut.Width * 3.4)
        trlisten = New Thread(AddressOf ListenToClient)
        trlisten.Start()
        Label1.Left = Me.Width / 2.25
        Label1.Visible = False

        Label2.Visible = False
        Label2.Left = Me.Width / 2.25

        Label3.Visible = False
        Label3.Left = Me.Width / 2.25

        Label4.Visible = False
        Label4.Left = Me.Width / 2.25

    End Sub
#End Region

#Region "BtnShutdown"
    Private Sub BtnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShutdown.Click
        Dim port As Integer = 8000
        Dim tcpCli As TcpClient
        Dim ns As NetworkStream
        Dim sw As StreamWriter
        If CheckBox1.Checked = True Then
            If CheckBox1.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.1", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox1.CheckState = CheckState.Unchecked
                CheckBox1.BackColor = Color.DimGray
            End If
        End If
        If CheckBox2.Checked = True Then
            If CheckBox2.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.2", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox2.CheckState = CheckState.Unchecked
                CheckBox2.BackColor = Color.DimGray
            End If
        End If
        If CheckBox3.Checked = True Then
            If CheckBox3.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.3", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox3.CheckState = CheckState.Unchecked
                CheckBox3.BackColor = Color.DimGray
            End If
        End If
        If CheckBox4.Checked = True Then
            If CheckBox4.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.4", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox4.CheckState = CheckState.Unchecked
                CheckBox4.BackColor = Color.DimGray
            End If
        End If
        If CheckBox5.Checked = True Then
            If CheckBox5.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.5", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox5.CheckState = CheckState.Unchecked
                CheckBox5.BackColor = Color.DimGray
            End If
        End If
        If CheckBox6.Checked = True Then
            If CheckBox6.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.6", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox6.CheckState = CheckState.Unchecked
                CheckBox6.BackColor = Color.DimGray
            End If
        End If
        If CheckBox7.Checked = True Then
            If CheckBox7.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.7", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox7.CheckState = CheckState.Unchecked
                CheckBox7.BackColor = Color.DimGray
            End If
        End If
        If CheckBox8.Checked = True Then
            If CheckBox8.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.8", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox8.CheckState = CheckState.Unchecked
                CheckBox8.BackColor = Color.DimGray
            End If
        End If
        If CheckBox9.Checked = True Then
            If CheckBox9.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.9", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox9.CheckState = CheckState.Unchecked
                CheckBox9.BackColor = Color.DimGray
            End If
        End If
        If CheckBox10.Checked = True Then
            If CheckBox10.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.10", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox10.CheckState = CheckState.Unchecked
                CheckBox10.BackColor = Color.DimGray
            End If
        End If
        If CheckBox11.Checked = True Then
            If CheckBox11.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.11", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox11.CheckState = CheckState.Unchecked
                CheckBox11.BackColor = Color.DimGray
            End If
        End If
        If CheckBox12.Checked = True Then
            If CheckBox12.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.12", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox12.CheckState = CheckState.Unchecked
                CheckBox12.BackColor = Color.DimGray
            End If
        End If
        If CheckBox13.Checked = True Then
            If CheckBox13.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.13", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox13.CheckState = CheckState.Unchecked
                CheckBox13.BackColor = Color.DimGray
            End If
        End If
        If CheckBox14.Checked = True Then
            If CheckBox14.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.14", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox14.CheckState = CheckState.Unchecked
                CheckBox14.BackColor = Color.DimGray
            End If
        End If
        If CheckBox15.Checked = True Then
            If CheckBox15.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.15", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox15.CheckState = CheckState.Unchecked
                CheckBox15.BackColor = Color.DimGray
            End If
        End If

        If CheckBox16.Checked = True Then
            If CheckBox16.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.16", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox16.CheckState = CheckState.Unchecked
                CheckBox16.BackColor = Color.DimGray
            End If
        End If

        If CheckBox17.Checked = True Then
            If CheckBox17.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.17", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox17.CheckState = CheckState.Unchecked
                CheckBox17.BackColor = Color.DimGray
            End If
        End If
        If CheckBox18.Checked = True Then
            If CheckBox18.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.18", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox18.CheckState = CheckState.Unchecked
                CheckBox18.BackColor = Color.DimGray
            End If
        End If
        If CheckBox19.Checked = True Then
            If CheckBox19.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.19", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox19.CheckState = CheckState.Unchecked
                CheckBox19.BackColor = Color.DimGray
            End If
        End If
        If CheckBox20.Checked = True Then
            If CheckBox20.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.20", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox20.CheckState = CheckState.Unchecked
                CheckBox20.BackColor = Color.DimGray
            End If
        End If
        If CheckBox21.Checked = True Then
            If CheckBox21.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.21", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox21.CheckState = CheckState.Unchecked
                CheckBox21.BackColor = Color.DimGray
            End If
        End If
        If CheckBox22.Checked = True Then
            If CheckBox22.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.22", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox22.CheckState = CheckState.Unchecked
                CheckBox22.BackColor = Color.DimGray
            End If
        End If
        If CheckBox23.Checked = True Then
            If CheckBox23.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.23", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox23.CheckState = CheckState.Unchecked
                CheckBox23.BackColor = Color.DimGray
            End If
        End If
        If CheckBox24.Checked = True Then
            If CheckBox24.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.24", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox24.CheckState = CheckState.Unchecked
                CheckBox24.BackColor = Color.DimGray
            End If
        End If
        If CheckBox25.Checked = True Then
            If CheckBox25.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.25", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox25.CheckState = CheckState.Unchecked
                CheckBox25.BackColor = Color.DimGray
            End If
        End If
        If CheckBox26.Checked = True Then
            If CheckBox26.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.26", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox26.CheckState = CheckState.Unchecked
                CheckBox26.BackColor = Color.DimGray
            End If
        End If
        If CheckBox27.Checked = True Then
            If CheckBox27.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.27", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox27.CheckState = CheckState.Unchecked
                CheckBox27.BackColor = Color.DimGray
            End If
        End If
        If CheckBox28.Checked = True Then
            If CheckBox28.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.28", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox28.CheckState = CheckState.Unchecked
                CheckBox28.BackColor = Color.DimGray
            End If
        End If
        If CheckBox29.Checked = True Then
            If CheckBox29.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.29", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox29.CheckState = CheckState.Unchecked
                CheckBox29.BackColor = Color.DimGray
            End If
        End If
        If CheckBox30.Checked = True Then
            If CheckBox30.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.30", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox30.CheckState = CheckState.Unchecked
                CheckBox30.BackColor = Color.DimGray
            End If
        End If
        If CheckBox31.Checked = True Then
            If CheckBox31.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.31", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox31.CheckState = CheckState.Unchecked
                CheckBox31.BackColor = Color.DimGray
            End If
        End If
        If CheckBox32.Checked = True Then
            If CheckBox32.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.32", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox32.CheckState = CheckState.Unchecked
                CheckBox32.BackColor = Color.DimGray
            End If
        End If
        If CheckBox33.Checked = True Then
            If CheckBox33.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.33", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox33.CheckState = CheckState.Unchecked
                CheckBox33.BackColor = Color.DimGray
            End If
        End If
        If CheckBox34.Checked = True Then
            If CheckBox34.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.34", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox34.CheckState = CheckState.Unchecked
                CheckBox34.BackColor = Color.DimGray
            End If
        End If
        If CheckBox35.Checked = True Then
            If CheckBox35.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.35", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox35.CheckState = CheckState.Unchecked
                CheckBox35.BackColor = Color.DimGray
            End If
        End If
        If CheckBox36.Checked = True Then
            If CheckBox36.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.36", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox36.CheckState = CheckState.Unchecked
                CheckBox36.BackColor = Color.DimGray
            End If
        End If
        If CheckBox37.Checked = True Then
            If CheckBox37.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.37", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox37.CheckState = CheckState.Unchecked
                CheckBox37.BackColor = Color.DimGray
            End If
        End If
        If CheckBox38.Checked = True Then
            If CheckBox38.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.38", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox38.CheckState = CheckState.Unchecked
                CheckBox38.BackColor = Color.DimGray
            End If
        End If
        If CheckBox39.Checked = True Then
            If CheckBox39.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.39", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox39.CheckState = CheckState.Unchecked
                CheckBox39.BackColor = Color.DimGray
            End If
        End If
        If CheckBox40.Checked = True Then
            If CheckBox40.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.40", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox40.CheckState = CheckState.Unchecked
                CheckBox40.BackColor = Color.DimGray
            End If
        End If
        If CheckBox41.Checked = True Then
            If CheckBox41.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.41", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox41.CheckState = CheckState.Unchecked
                CheckBox41.BackColor = Color.DimGray
            End If
        End If
        If CheckBox42.Checked = True Then
            If CheckBox42.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.42", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox42.CheckState = CheckState.Unchecked
                CheckBox42.BackColor = Color.DimGray
            End If
        End If
        If CheckBox43.Checked = True Then
            If CheckBox43.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.43", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox43.CheckState = CheckState.Unchecked
                CheckBox43.BackColor = Color.DimGray
            End If
        End If
        If CheckBox44.Checked = True Then
            If CheckBox44.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.44", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox44.CheckState = CheckState.Unchecked
                CheckBox44.BackColor = Color.DimGray
            End If
        End If
        If CheckBox45.Checked = True Then
            If CheckBox45.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.45", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox45.CheckState = CheckState.Unchecked
                CheckBox45.BackColor = Color.DimGray
            End If
        End If
        If CheckBox46.Checked = True Then
            If CheckBox46.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.46", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox46.CheckState = CheckState.Unchecked
                CheckBox46.BackColor = Color.DimGray
            End If
        End If
        If CheckBox47.Checked = True Then
            If CheckBox47.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.47", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox47.CheckState = CheckState.Unchecked
                CheckBox47.BackColor = Color.DimGray
            End If
        End If
        If CheckBox48.Checked = True Then
            If CheckBox48.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.48", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox48.CheckState = CheckState.Unchecked
                CheckBox48.BackColor = Color.DimGray
            End If
        End If
        If CheckBox49.Checked = True Then
            If CheckBox49.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.49", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox49.CheckState = CheckState.Unchecked
                CheckBox49.BackColor = Color.DimGray
            End If
        End If
        If CheckBox50.Checked = True Then
            If CheckBox50.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.50", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox50.CheckState = CheckState.Unchecked
                CheckBox50.BackColor = Color.DimGray
            End If
        End If
        If CheckBox51.Checked = True Then
            If CheckBox51.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.51", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox51.CheckState = CheckState.Unchecked
                CheckBox51.BackColor = Color.DimGray
            End If
        End If
        If CheckBox52.Checked = True Then
            If CheckBox52.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.52", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox52.CheckState = CheckState.Unchecked
                CheckBox52.BackColor = Color.DimGray
            End If
        End If
        If CheckBox53.Checked = True Then
            If CheckBox53.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.53", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox53.CheckState = CheckState.Unchecked
                CheckBox53.BackColor = Color.DimGray
            End If
        End If
        If CheckBox54.Checked = True Then
            If CheckBox54.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.54", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox54.CheckState = CheckState.Unchecked
                CheckBox54.BackColor = Color.DimGray
            End If
        End If
        If CheckBox55.Checked = True Then
            If CheckBox55.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.55", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox55.CheckState = CheckState.Unchecked
                CheckBox55.BackColor = Color.DimGray
            End If
        End If
        If CheckBox56.Checked = True Then
            If CheckBox56.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.56", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox56.CheckState = CheckState.Unchecked
                CheckBox56.BackColor = Color.DimGray
            End If
        End If
        If CheckBox57.Checked = True Then
            If CheckBox57.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.57", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox57.CheckState = CheckState.Unchecked
                CheckBox57.BackColor = Color.DimGray
            End If
        End If
        If CheckBox58.Checked = True Then
            If CheckBox58.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.58", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox58.CheckState = CheckState.Unchecked
                CheckBox58.BackColor = Color.DimGray
            End If
        End If
        If CheckBox59.Checked = True Then
            If CheckBox59.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.59", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox59.CheckState = CheckState.Unchecked
                CheckBox59.BackColor = Color.DimGray
            End If
        End If
        If CheckBox60.Checked = True Then
            If CheckBox60.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.60", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###SHUTDOWN###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox60.CheckState = CheckState.Unchecked
                CheckBox60.BackColor = Color.DimGray
            End If

        Else
            '======== Matikan semua komputer client yang terkoneksi ======
            'Mengambil nilai awal dan akhir ip address

            Dim startIP As IPAddress = ipAddress.Parse("192.168.3.1")

            Dim endIP As IPAddress = ipAddress.Parse("192.168.3.253")

            '
            ' NetScan melakukan pengecekan terhadap komputer mana yang aktif
            '
            Dim ns1 As NetScan = New NetScan()

            '
            ' Event handler untuk setiap ping yang berhasil maka akan langsung dieksekusi menuju shutdown.
            '
            AddHandler ns1.PingComplete, AddressOf ShutdownPingComplete

            '
            ' Event handler untuk setiap ip yang di ping.
            '
            AddHandler ns1.NetScanComplete, AddressOf NetScanComplete
            '
            ' Disable the "Scan" button while the pings are running, and start the pings.
            '
            BtnShutdown.Enabled = False
            BtnLogOff.Enabled = False
            BtnRestart.Enabled = False
            ns1.Start(New PingRange(startIP, endIP))
        End If
    End Sub

    Private Sub BtnShutdown_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShutdown.MouseEnter
        Label1.Visible = True
        PanelPerintah.BackColor = Color.DarkRed
    End Sub

    Private Sub BtnShutdown_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShutdown.MouseLeave
        Label1.Visible = False
        PanelPerintah.BackColor = Color.DimGray
    End Sub
#End Region

#Region "BtnRestart"
    Private Sub BtnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRestart.Click
        Dim port As Integer = 8000
        Dim tcpCli As TcpClient
        Dim ns As NetworkStream
        Dim sw As StreamWriter
        If CheckBox1.Checked = True Then
            If CheckBox1.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.1", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox1.CheckState = CheckState.Unchecked
                CheckBox1.BackColor = Color.DimGray
            End If
        End If
        If CheckBox2.Checked = True Then
            If CheckBox2.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.2", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox2.CheckState = CheckState.Unchecked
                CheckBox2.BackColor = Color.DimGray
            End If
        End If
        If CheckBox3.Checked = True Then
            If CheckBox3.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.3", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox3.CheckState = CheckState.Unchecked
                CheckBox3.BackColor = Color.DimGray
            End If
        End If
        If CheckBox4.Checked = True Then
            If CheckBox4.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.4", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox4.CheckState = CheckState.Unchecked
                CheckBox4.BackColor = Color.DimGray
            End If
        End If
        If CheckBox5.Checked = True Then
            If CheckBox5.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.5", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox5.CheckState = CheckState.Unchecked
                CheckBox5.BackColor = Color.DimGray
            End If
        End If
        If CheckBox6.Checked = True Then
            If CheckBox6.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.6", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox6.CheckState = CheckState.Unchecked
                CheckBox6.BackColor = Color.DimGray
            End If
        End If
        If CheckBox7.Checked = True Then
            If CheckBox7.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.7", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox7.CheckState = CheckState.Unchecked
                CheckBox7.BackColor = Color.DimGray
            End If
        End If
        If CheckBox8.Checked = True Then
            If CheckBox8.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.8", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox8.CheckState = CheckState.Unchecked
                CheckBox8.BackColor = Color.DimGray
            End If
        End If
        If CheckBox9.Checked = True Then
            If CheckBox9.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.9", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox9.CheckState = CheckState.Unchecked
                CheckBox9.BackColor = Color.DimGray
            End If
        End If
        If CheckBox10.Checked = True Then
            If CheckBox10.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.10", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox10.CheckState = CheckState.Unchecked
                CheckBox10.BackColor = Color.DimGray
            End If
        End If
        If CheckBox11.Checked = True Then
            If CheckBox11.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.11", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox11.CheckState = CheckState.Unchecked
                CheckBox11.BackColor = Color.DimGray
            End If
        End If
        If CheckBox12.Checked = True Then
            If CheckBox12.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.12", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox12.CheckState = CheckState.Unchecked
                CheckBox12.BackColor = Color.DimGray
            End If
        End If
        If CheckBox13.Checked = True Then
            If CheckBox13.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.13", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox13.CheckState = CheckState.Unchecked
                CheckBox13.BackColor = Color.DimGray
            End If
        End If
        If CheckBox14.Checked = True Then
            If CheckBox14.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.14", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox14.CheckState = CheckState.Unchecked
                CheckBox14.BackColor = Color.DimGray
            End If
        End If
        If CheckBox15.Checked = True Then
            If CheckBox15.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.15", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox15.CheckState = CheckState.Unchecked
                CheckBox15.BackColor = Color.DimGray
            End If
        End If

        If CheckBox16.Checked = True Then
            If CheckBox16.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.16", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox16.CheckState = CheckState.Unchecked
                CheckBox16.BackColor = Color.DimGray
            End If
        End If

        If CheckBox17.Checked = True Then
            If CheckBox17.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.17", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox17.CheckState = CheckState.Unchecked
                CheckBox17.BackColor = Color.DimGray
            End If
        End If
        If CheckBox18.Checked = True Then
            If CheckBox18.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.18", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox18.CheckState = CheckState.Unchecked
                CheckBox18.BackColor = Color.DimGray
            End If
        End If
        If CheckBox19.Checked = True Then
            If CheckBox19.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.19", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox19.CheckState = CheckState.Unchecked
                CheckBox19.BackColor = Color.DimGray
            End If
        End If
        If CheckBox20.Checked = True Then
            If CheckBox20.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.20", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox20.CheckState = CheckState.Unchecked
                CheckBox20.BackColor = Color.DimGray
            End If
        End If
        If CheckBox21.Checked = True Then
            If CheckBox21.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.21", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox21.CheckState = CheckState.Unchecked
                CheckBox21.BackColor = Color.DimGray
            End If
        End If
        If CheckBox22.Checked = True Then
            If CheckBox22.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.22", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox22.CheckState = CheckState.Unchecked
                CheckBox22.BackColor = Color.DimGray
            End If
        End If
        If CheckBox23.Checked = True Then
            If CheckBox23.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.23", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox23.CheckState = CheckState.Unchecked
                CheckBox23.BackColor = Color.DimGray
            End If
        End If
        If CheckBox24.Checked = True Then
            If CheckBox24.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.24", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox24.CheckState = CheckState.Unchecked
                CheckBox24.BackColor = Color.DimGray
            End If
        End If
        If CheckBox25.Checked = True Then
            If CheckBox25.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.25", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox25.CheckState = CheckState.Unchecked
                CheckBox25.BackColor = Color.DimGray
            End If
        End If
        If CheckBox26.Checked = True Then
            If CheckBox26.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.26", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox26.CheckState = CheckState.Unchecked
                CheckBox26.BackColor = Color.DimGray
            End If
        End If
        If CheckBox27.Checked = True Then
            If CheckBox27.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.27", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox27.CheckState = CheckState.Unchecked
                CheckBox27.BackColor = Color.DimGray
            End If
        End If
        If CheckBox28.Checked = True Then
            If CheckBox28.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.28", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox28.CheckState = CheckState.Unchecked
                CheckBox28.BackColor = Color.DimGray
            End If
        End If
        If CheckBox29.Checked = True Then
            If CheckBox29.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.29", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox29.CheckState = CheckState.Unchecked
                CheckBox29.BackColor = Color.DimGray
            End If
        End If
        If CheckBox30.Checked = True Then
            If CheckBox30.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.30", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox30.CheckState = CheckState.Unchecked
                CheckBox30.BackColor = Color.DimGray
            End If
        End If
        If CheckBox31.Checked = True Then
            If CheckBox31.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.31", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox31.CheckState = CheckState.Unchecked
                CheckBox31.BackColor = Color.DimGray
            End If
        End If
        If CheckBox32.Checked = True Then
            If CheckBox32.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.32", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox32.CheckState = CheckState.Unchecked
                CheckBox32.BackColor = Color.DimGray
            End If
        End If
        If CheckBox33.Checked = True Then
            If CheckBox33.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.33", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox33.CheckState = CheckState.Unchecked
                CheckBox33.BackColor = Color.DimGray
            End If
        End If
        If CheckBox34.Checked = True Then
            If CheckBox34.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.34", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox34.CheckState = CheckState.Unchecked
                CheckBox34.BackColor = Color.DimGray
            End If
        End If
        If CheckBox35.Checked = True Then
            If CheckBox35.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.35", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox35.CheckState = CheckState.Unchecked
                CheckBox35.BackColor = Color.DimGray
            End If
        End If
        If CheckBox36.Checked = True Then
            If CheckBox36.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.36", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox36.CheckState = CheckState.Unchecked
                CheckBox36.BackColor = Color.DimGray
            End If
        End If
        If CheckBox37.Checked = True Then
            If CheckBox37.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.37", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox37.CheckState = CheckState.Unchecked
                CheckBox37.BackColor = Color.DimGray
            End If
        End If
        If CheckBox38.Checked = True Then
            If CheckBox38.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.38", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox38.CheckState = CheckState.Unchecked
                CheckBox38.BackColor = Color.DimGray
            End If
        End If
        If CheckBox39.Checked = True Then
            If CheckBox39.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.39", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox39.CheckState = CheckState.Unchecked
                CheckBox39.BackColor = Color.DimGray
            End If
        End If
        If CheckBox40.Checked = True Then
            If CheckBox40.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.40", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox40.CheckState = CheckState.Unchecked
                CheckBox40.BackColor = Color.DimGray
            End If
        End If
        If CheckBox41.Checked = True Then
            If CheckBox41.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.41", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox41.CheckState = CheckState.Unchecked
                CheckBox41.BackColor = Color.DimGray
            End If
        End If
        If CheckBox42.Checked = True Then
            If CheckBox42.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.42", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox42.CheckState = CheckState.Unchecked
                CheckBox42.BackColor = Color.DimGray
            End If
        End If
        If CheckBox43.Checked = True Then
            If CheckBox43.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.43", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox43.CheckState = CheckState.Unchecked
                CheckBox43.BackColor = Color.DimGray
            End If
        End If
        If CheckBox44.Checked = True Then
            If CheckBox44.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.44", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox44.CheckState = CheckState.Unchecked
                CheckBox44.BackColor = Color.DimGray
            End If
        End If
        If CheckBox45.Checked = True Then
            If CheckBox45.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.45", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox45.CheckState = CheckState.Unchecked
                CheckBox45.BackColor = Color.DimGray
            End If
        End If
        If CheckBox46.Checked = True Then
            If CheckBox46.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.46", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox46.CheckState = CheckState.Unchecked
                CheckBox46.BackColor = Color.DimGray
            End If
        End If
        If CheckBox47.Checked = True Then
            If CheckBox47.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.47", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox47.CheckState = CheckState.Unchecked
                CheckBox47.BackColor = Color.DimGray
            End If
        End If
        If CheckBox48.Checked = True Then
            If CheckBox48.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.48", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox48.CheckState = CheckState.Unchecked
                CheckBox48.BackColor = Color.DimGray
            End If
        End If
        If CheckBox49.Checked = True Then
            If CheckBox49.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.49", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox49.CheckState = CheckState.Unchecked
                CheckBox49.BackColor = Color.DimGray
            End If
        End If
        If CheckBox50.Checked = True Then
            If CheckBox50.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.50", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox50.CheckState = CheckState.Unchecked
                CheckBox50.BackColor = Color.DimGray
            End If
        End If
        If CheckBox51.Checked = True Then
            If CheckBox51.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.51", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox51.CheckState = CheckState.Unchecked
                CheckBox51.BackColor = Color.DimGray
            End If
        End If
        If CheckBox52.Checked = True Then
            If CheckBox52.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.52", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox52.CheckState = CheckState.Unchecked
                CheckBox52.BackColor = Color.DimGray
            End If
        End If
        If CheckBox53.Checked = True Then
            If CheckBox53.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.53", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox53.CheckState = CheckState.Unchecked
                CheckBox53.BackColor = Color.DimGray
            End If
        End If
        If CheckBox54.Checked = True Then
            If CheckBox54.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.54", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox54.CheckState = CheckState.Unchecked
                CheckBox54.BackColor = Color.DimGray
            End If
        End If
        If CheckBox55.Checked = True Then
            If CheckBox55.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.55", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox55.CheckState = CheckState.Unchecked
                CheckBox55.BackColor = Color.DimGray
            End If
        End If
        If CheckBox56.Checked = True Then
            If CheckBox56.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.56", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox56.CheckState = CheckState.Unchecked
                CheckBox56.BackColor = Color.DimGray
            End If
        End If
        If CheckBox57.Checked = True Then
            If CheckBox57.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.57", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox57.CheckState = CheckState.Unchecked
                CheckBox57.BackColor = Color.DimGray
            End If
        End If
        If CheckBox58.Checked = True Then
            If CheckBox58.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.58", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox58.CheckState = CheckState.Unchecked
                CheckBox58.BackColor = Color.DimGray
            End If
        End If
        If CheckBox59.Checked = True Then
            If CheckBox59.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.59", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox59.CheckState = CheckState.Unchecked
                CheckBox59.BackColor = Color.DimGray
            End If
        End If
        If CheckBox60.Checked = True Then
            If CheckBox60.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.60", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###REBOOT###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox60.CheckState = CheckState.Unchecked
                CheckBox60.BackColor = Color.DimGray
            End If

        Else
            '======== Restart semua komputer client yang terkoneksi ======
            'Mengambil nilai awal dan akhir ip address

            Dim startIP As IPAddress = ipAddress.Parse("192.168.3.1")

            Dim endIP As IPAddress = ipAddress.Parse("192.168.3.253")

            '
            ' NetScan melakukan pengecekan terhadap komputer mana yang aktif
            '
            Dim ns1 As NetScan = New NetScan()

            '
            ' Event handler untuk setiap ping yang berhasil maka akan langsung dieksekusi menuju Restart.
            '
            AddHandler ns1.PingComplete, AddressOf RebootPingComplete

            '
            ' Event handler untuk setiap ip yang di ping.
            '
            AddHandler ns1.NetScanComplete, AddressOf NetScanComplete
            '
            ' Disable the "Scan" button while the pings are running, and start the pings.
            '
            BtnShutdown.Enabled = False
            BtnLogOff.Enabled = False
            BtnRestart.Enabled = False
            ns1.Start(New PingRange(startIP, endIP))
        End If
    End Sub

    Private Sub BtnRestart_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRestart.MouseEnter
        Label2.Visible = True
        PanelPerintah.BackColor = Color.Green
    End Sub

    Private Sub BtnRestart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRestart.MouseLeave
        Label2.Visible = False
        PanelPerintah.BackColor = Color.DimGray
    End Sub
#End Region

#Region "BtnLogOff  "
    Private Sub BtnLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogOff.Click
        Dim port As Integer = 8000
        Dim tcpCli As TcpClient
        Dim ns As NetworkStream
        Dim sw As StreamWriter
        If CheckBox1.Checked = True Then
            If CheckBox1.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.1", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox1.CheckState = CheckState.Unchecked
                CheckBox1.BackColor = Color.DimGray
            End If
        End If
        If CheckBox2.Checked = True Then
            If CheckBox2.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.2", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox2.CheckState = CheckState.Unchecked
                CheckBox2.BackColor = Color.DimGray
            End If
        End If
        If CheckBox3.Checked = True Then
            If CheckBox3.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.3", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox3.CheckState = CheckState.Unchecked
                CheckBox3.BackColor = Color.DimGray
            End If
        End If
        If CheckBox4.Checked = True Then
            If CheckBox4.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.4", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox4.CheckState = CheckState.Unchecked
                CheckBox4.BackColor = Color.DimGray
            End If
        End If
        If CheckBox5.Checked = True Then
            If CheckBox5.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.5", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox5.CheckState = CheckState.Unchecked
                CheckBox5.BackColor = Color.DimGray
            End If
        End If
        If CheckBox6.Checked = True Then
            If CheckBox6.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.6", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox6.CheckState = CheckState.Unchecked
                CheckBox6.BackColor = Color.DimGray
            End If
        End If
        If CheckBox7.Checked = True Then
            If CheckBox7.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.7", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox7.CheckState = CheckState.Unchecked
                CheckBox7.BackColor = Color.DimGray
            End If
        End If
        If CheckBox8.Checked = True Then
            If CheckBox8.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.8", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox8.CheckState = CheckState.Unchecked
                CheckBox8.BackColor = Color.DimGray
            End If
        End If
        If CheckBox9.Checked = True Then
            If CheckBox9.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.9", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox9.CheckState = CheckState.Unchecked
                CheckBox9.BackColor = Color.DimGray
            End If
        End If
        If CheckBox10.Checked = True Then
            If CheckBox10.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.10", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox10.CheckState = CheckState.Unchecked
                CheckBox10.BackColor = Color.DimGray
            End If
        End If
        If CheckBox11.Checked = True Then
            If CheckBox11.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.11", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox11.CheckState = CheckState.Unchecked
                CheckBox11.BackColor = Color.DimGray
            End If
        End If
        If CheckBox12.Checked = True Then
            If CheckBox12.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.12", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox12.CheckState = CheckState.Unchecked
                CheckBox12.BackColor = Color.DimGray
            End If
        End If
        If CheckBox13.Checked = True Then
            If CheckBox13.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.13", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox13.CheckState = CheckState.Unchecked
                CheckBox13.BackColor = Color.DimGray
            End If
        End If
        If CheckBox14.Checked = True Then
            If CheckBox14.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.14", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox14.CheckState = CheckState.Unchecked
                CheckBox14.BackColor = Color.DimGray
            End If
        End If
        If CheckBox15.Checked = True Then
            If CheckBox15.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.15", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox15.CheckState = CheckState.Unchecked
                CheckBox15.BackColor = Color.DimGray
            End If
        End If

        If CheckBox16.Checked = True Then
            If CheckBox16.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.16", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox16.CheckState = CheckState.Unchecked
                CheckBox16.BackColor = Color.DimGray
            End If
        End If

        If CheckBox17.Checked = True Then
            If CheckBox17.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.17", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox17.CheckState = CheckState.Unchecked
                CheckBox17.BackColor = Color.DimGray
            End If
        End If
        If CheckBox18.Checked = True Then
            If CheckBox18.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.18", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox18.CheckState = CheckState.Unchecked
                CheckBox18.BackColor = Color.DimGray
            End If
        End If
        If CheckBox19.Checked = True Then
            If CheckBox19.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.19", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox19.CheckState = CheckState.Unchecked
                CheckBox19.BackColor = Color.DimGray
            End If
        End If
        If CheckBox20.Checked = True Then
            If CheckBox20.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.20", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox20.CheckState = CheckState.Unchecked
                CheckBox20.BackColor = Color.DimGray
            End If
        End If
        If CheckBox21.Checked = True Then
            If CheckBox21.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.21", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox21.CheckState = CheckState.Unchecked
                CheckBox21.BackColor = Color.DimGray
            End If
        End If
        If CheckBox22.Checked = True Then
            If CheckBox22.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.22", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox22.CheckState = CheckState.Unchecked
                CheckBox22.BackColor = Color.DimGray
            End If
        End If
        If CheckBox23.Checked = True Then
            If CheckBox23.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.23", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox23.CheckState = CheckState.Unchecked
                CheckBox23.BackColor = Color.DimGray
            End If
        End If
        If CheckBox24.Checked = True Then
            If CheckBox24.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.24", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox24.CheckState = CheckState.Unchecked
                CheckBox24.BackColor = Color.DimGray
            End If
        End If
        If CheckBox25.Checked = True Then
            If CheckBox25.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.25", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox25.CheckState = CheckState.Unchecked
                CheckBox25.BackColor = Color.DimGray
            End If
        End If
        If CheckBox26.Checked = True Then
            If CheckBox26.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.26", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox26.CheckState = CheckState.Unchecked
                CheckBox26.BackColor = Color.DimGray
            End If
        End If
        If CheckBox27.Checked = True Then
            If CheckBox27.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.27", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox27.CheckState = CheckState.Unchecked
                CheckBox27.BackColor = Color.DimGray
            End If
        End If
        If CheckBox28.Checked = True Then
            If CheckBox28.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.28", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox28.CheckState = CheckState.Unchecked
                CheckBox28.BackColor = Color.DimGray
            End If
        End If
        If CheckBox29.Checked = True Then
            If CheckBox29.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.29", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox29.CheckState = CheckState.Unchecked
                CheckBox29.BackColor = Color.DimGray
            End If
        End If
        If CheckBox30.Checked = True Then
            If CheckBox30.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.30", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox30.CheckState = CheckState.Unchecked
                CheckBox30.BackColor = Color.DimGray
            End If
        End If
        If CheckBox31.Checked = True Then
            If CheckBox31.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.31", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox31.CheckState = CheckState.Unchecked
                CheckBox31.BackColor = Color.DimGray
            End If
        End If
        If CheckBox32.Checked = True Then
            If CheckBox32.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.32", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox32.CheckState = CheckState.Unchecked
                CheckBox32.BackColor = Color.DimGray
            End If
        End If
        If CheckBox33.Checked = True Then
            If CheckBox33.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.33", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox33.CheckState = CheckState.Unchecked
                CheckBox33.BackColor = Color.DimGray
            End If
        End If
        If CheckBox34.Checked = True Then
            If CheckBox34.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.34", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox34.CheckState = CheckState.Unchecked
                CheckBox34.BackColor = Color.DimGray
            End If
        End If
        If CheckBox35.Checked = True Then
            If CheckBox35.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.35", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox35.CheckState = CheckState.Unchecked
                CheckBox35.BackColor = Color.DimGray
            End If
        End If
        If CheckBox36.Checked = True Then
            If CheckBox36.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.36", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox36.CheckState = CheckState.Unchecked
                CheckBox36.BackColor = Color.DimGray
            End If
        End If
        If CheckBox37.Checked = True Then
            If CheckBox37.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.37", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox37.CheckState = CheckState.Unchecked
                CheckBox37.BackColor = Color.DimGray
            End If
        End If
        If CheckBox38.Checked = True Then
            If CheckBox38.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.38", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox38.CheckState = CheckState.Unchecked
                CheckBox38.BackColor = Color.DimGray
            End If
        End If
        If CheckBox39.Checked = True Then
            If CheckBox39.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.39", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox39.CheckState = CheckState.Unchecked
                CheckBox39.BackColor = Color.DimGray
            End If
        End If
        If CheckBox40.Checked = True Then
            If CheckBox40.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.40", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox40.CheckState = CheckState.Unchecked
                CheckBox40.BackColor = Color.DimGray
            End If
        End If
        If CheckBox41.Checked = True Then
            If CheckBox41.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.41", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox41.CheckState = CheckState.Unchecked
                CheckBox41.BackColor = Color.DimGray
            End If
        End If
        If CheckBox42.Checked = True Then
            If CheckBox42.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.42", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox42.CheckState = CheckState.Unchecked
                CheckBox42.BackColor = Color.DimGray
            End If
        End If
        If CheckBox43.Checked = True Then
            If CheckBox43.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.43", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox43.CheckState = CheckState.Unchecked
                CheckBox43.BackColor = Color.DimGray
            End If
        End If
        If CheckBox44.Checked = True Then
            If CheckBox44.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.44", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox44.CheckState = CheckState.Unchecked
                CheckBox44.BackColor = Color.DimGray
            End If
        End If
        If CheckBox45.Checked = True Then
            If CheckBox45.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.45", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox45.CheckState = CheckState.Unchecked
                CheckBox45.BackColor = Color.DimGray
            End If
        End If
        If CheckBox46.Checked = True Then
            If CheckBox46.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.46", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox46.CheckState = CheckState.Unchecked
                CheckBox46.BackColor = Color.DimGray
            End If
        End If
        If CheckBox47.Checked = True Then
            If CheckBox47.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.47", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox47.CheckState = CheckState.Unchecked
                CheckBox47.BackColor = Color.DimGray
            End If
        End If
        If CheckBox48.Checked = True Then
            If CheckBox48.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.48", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox48.CheckState = CheckState.Unchecked
                CheckBox48.BackColor = Color.DimGray
            End If
        End If
        If CheckBox49.Checked = True Then
            If CheckBox49.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.49", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox49.CheckState = CheckState.Unchecked
                CheckBox49.BackColor = Color.DimGray
            End If
        End If
        If CheckBox50.Checked = True Then
            If CheckBox50.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.50", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox50.CheckState = CheckState.Unchecked
                CheckBox50.BackColor = Color.DimGray
            End If
        End If
        If CheckBox51.Checked = True Then
            If CheckBox51.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.51", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox51.CheckState = CheckState.Unchecked
                CheckBox51.BackColor = Color.DimGray
            End If
        End If
        If CheckBox52.Checked = True Then
            If CheckBox52.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.52", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox52.CheckState = CheckState.Unchecked
                CheckBox52.BackColor = Color.DimGray
            End If
        End If
        If CheckBox53.Checked = True Then
            If CheckBox53.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.53", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox53.CheckState = CheckState.Unchecked
                CheckBox53.BackColor = Color.DimGray
            End If
        End If
        If CheckBox54.Checked = True Then
            If CheckBox54.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.54", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox54.CheckState = CheckState.Unchecked
                CheckBox54.BackColor = Color.DimGray
            End If
        End If
        If CheckBox55.Checked = True Then
            If CheckBox55.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.55", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox55.CheckState = CheckState.Unchecked
                CheckBox55.BackColor = Color.DimGray
            End If
        End If
        If CheckBox56.Checked = True Then
            If CheckBox56.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.56", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox56.CheckState = CheckState.Unchecked
                CheckBox56.BackColor = Color.DimGray
            End If
        End If
        If CheckBox57.Checked = True Then
            If CheckBox57.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.57", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox57.CheckState = CheckState.Unchecked
                CheckBox57.BackColor = Color.DimGray
            End If
        End If
        If CheckBox58.Checked = True Then
            If CheckBox58.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.58", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox58.CheckState = CheckState.Unchecked
                CheckBox58.BackColor = Color.DimGray
            End If
        End If
        If CheckBox59.Checked = True Then
            If CheckBox59.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.59", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox59.CheckState = CheckState.Unchecked
                CheckBox59.BackColor = Color.DimGray
            End If
        End If
        If CheckBox60.Checked = True Then
            If CheckBox60.BackColor = Color.Green Then
                tcpCli = New TcpClient("192.168.3.60", port)
                ns = tcpCli.GetStream
                sw = New StreamWriter(ns)
                sw.WriteLine("###LOGOFF###")
                sw.Flush()
                sw.Close()
                ns.Close()
                CheckBox60.CheckState = CheckState.Unchecked
                CheckBox60.BackColor = Color.DimGray
            End If

        Else
            '======== Logoff semua komputer client yang terkoneksi ======
            'Mengambil nilai awal dan akhir ip address

            Dim startIP As IPAddress = ipAddress.Parse("192.168.3.1")

            Dim endIP As IPAddress = ipAddress.Parse("192.168.3.253")

            '
            ' NetScan melakukan pengecekan terhadap komputer mana yang aktif
            '
            Dim ns1 As NetScan = New NetScan()

            '
            ' Event handler untuk setiap ping yang berhasil maka akan langsung dieksekusi menuju logoff.
            '
            AddHandler ns1.PingComplete, AddressOf LogOffPingComplete

            '
            ' Event handler untuk setiap ip yang di ping.
            '
            AddHandler ns1.NetScanComplete, AddressOf NetScanComplete
            '
            ' Disable the "Scan" button while the pings are running, and start the pings.
            '
            BtnShutdown.Enabled = False
            BtnLogOff.Enabled = False
            BtnRestart.Enabled = False
            ns1.Start(New PingRange(startIP, endIP))
        End If
    End Sub

    Private Sub BtnLogOff_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLogOff.MouseEnter
        Label3.Visible = True
        PanelPerintah.BackColor = Color.DodgerBlue
    End Sub

    Private Sub BtnLogOff_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLogOff.MouseLeave
        Label3.Visible = False
        PanelPerintah.BackColor = Color.DimGray
    End Sub
#End Region

#Region "SignOut"
    Private Sub SignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignOut.Click
        LoginAdmin.TxtID.Clear()
        LoginAdmin.TxtNama.Clear()
        LoginAdmin.TxtPassword.Clear()
        LoginAdmin.Show()
        LoginAdmin.TxtID.Focus()
        Me.Hide()
    End Sub

    Private Sub SignOut_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles SignOut.MouseEnter
        Label4.Visible = True
        PanelPerintah.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub SignOut_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SignOut.MouseLeave
        Label4.Visible = False
        PanelPerintah.BackColor = Color.DimGray
    End Sub
#End Region

End Class