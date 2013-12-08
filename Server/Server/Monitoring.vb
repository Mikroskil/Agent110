Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Globalization


Public Class Monitoring

#Region "FORM LOAD"
    Private Sub Monitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Pengaturan Desain
        Label1.Left = (Me.Width - GroupBox1.Width - 5) / 1.2

        BtnKembali.Top = BtnKembali.Height / 3
        BtnKembali.Left = (Me.Width - GroupBox1.Width) / 4

        PictureBox1.Top = BtnKembali.Height / 3
        PictureBox1.Left = (Me.Width - GroupBox1.Width - 2) / 0.5

        GroupBox1.Top = GroupBox1.Height / 2
        GroupBox1.Left = (Me.Width - GroupBox1.Width - 5) / 2

        BtnShutdown.Top = GroupBox1.Height * 1.8
        BtnShutdown.Left = (Me.Width - GroupBox1.Width - 5)

        BtnRestart.Left = (Me.Width - GroupBox1.Width - 5) / 0.8
        BtnRestart.Top = GroupBox1.Height * 1.8

        BtnPing.Left = (Me.Width - GroupBox1.Width - 5) / 0.7
        BtnPing.Top = GroupBox1.Height * 1.8

        BtnPing.Visible = False
        LblAkhir.Visible = False
        LblAwal.Visible = False

        'Validasi Deteksi Client Yang Terkoneksi Ke Mesin Server'
        '
        'Mendapatkan IP server
        Dim ip As IPAddress = Dns.GetHostAddresses(Dns.GetHostName())(0)

        'Mengambil Rentang ip dari 192.168.1.2 - 192.168.1.254
        If ip IsNot Nothing Then
            Dim range As Byte() = ip.GetAddressBytes()
            range(3) = 1
            LblAwal.Text = (New IPAddress(range)).ToString()
            range(3) = 254
            LblAkhir.Text = (New IPAddress(range)).ToString()
        End If

    End Sub
#End Region

#Region "BUTTON KLIK"
    Private Sub BtnKembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKembali.Click
        Me.Hide()
        HOME.Show()
    End Sub

    'Private Sub BtnPing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPing.Click
    '    Dim IPawal As IPAddress = Nothing
    '    Try
    '        IPawal = IPAddress.Parse(LblAwal.Text)
    '    Catch ex As FormatException
    '        MessageBox.Show("Tidak ada koneksi", "Error", MessageBoxButtons.OK)
    '        Exit Sub
    '    End Try

    '    Dim IPAkhir As IPAddress = Nothing
    '    Try
    '        IPAkhir = IPAddress.Parse(LblAkhir.Text)
    '    Catch ex As Exception
    '        MessageBox.Show("Tidak ada koneksi", "Error", MessageBoxButtons.OK)
    '        Exit Sub
    '    End Try

    '    '
    '    'Proses Deteksi Dilakukan Dengan Melakukan Ping'
    '    '
    '    Dim Deteksi As NetScan = New NetScan()
    '    AddHandler Deteksi.PingComplete, AddressOf PingComplete
    '    AddHandler Deteksi.NetScanComplete, AddressOf NetScanComplete

    '    BtnPing.Enabled = False
    '    Deteksi.Start(New PingRange(IPawal, IPAkhir))
    'End Sub

    'Private Sub PingComplete(ByVal s As Object, ByVal ev As NetScanCompletedEventArgs)
    '    If ev.Reply.Status = IPStatus.Success Then
    '        Dim kom As CheckBox = New
    '    End If
    'End Sub

#End Region

End Class