'Imports System.Net
'Imports System.Net.Sockets
'Imports System.Threading
'Imports System.IO
'Imports MySql.Data.MySqlClient

Public Class LoginAdmin

#Region "Deklarasi Variabel"
    '    '======== untuk koneksi ==============
    '    Dim con As MySqlConnection
    '    Dim cmd As MySqlCommand
    '    Dim ad As MySqlDataAdapter
    '    Dim dr As DataRow
    '    Public ds As DataSet
    '    Dim cb As MySqlCommandBuilder
    '    Dim dc(0) As DataColumn
    '    Dim koneksi As New MySqlConnection("Server=192.168.3.1; Port=3306; User Id=admin; Password=admin; Database=Laboratorium")
    '    '=====================================
#End Region

#Region "Form Load"
    Private Sub LoginAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
        'Try
        '    koneksi.Open()
        'Catch ex As Exception
        '    MessageBox.Show("Koneksi Gagal")
        'End Try

    End Sub

    Private Sub setcontrols()

        'Panel 3 Label Administrator
        Panel3.Top = Panel3.Height * 1.8
        Panel3.Left = (Me.Width - Panel3.Width - 50) / 1.75

        'Panel  Label ID, Nama, Pass
        Panel1.Width = LblID.Width * 2
        Panel1.Left = (Me.Width / 4 + (Panel1.Width / 3))
        Panel1.Height = (LblID.Height + LblNama.Height + LblPass.Height + 100)
        Panel1.Top = Me.Height / 3
        LblID.Left = LblID.Width / 2
        LblNama.Left = LblNama.Width / 2
        LblPass.Left = LblPass.Width / 2

        'Panel Textbox'
        Panel2.Left = (Me.Width / 3) + Panel1.Left / 3
        Panel2.Top = Me.Height / 3
        Panel2.Height = Panel1.Height

        'Panel Login, Cancel'
        pnlappbar.Width = Me.Width
        pnlappbar.Left = Me.Left
        pnlappbar.Height = 100
        pnlappbar.Top = Me.Height - pnlappbar.Height
        btnCancel.Left = (pnlappbar.Width / 2 + 10)
        btnLogin.Left = (btnCancel.Left - btnCancel.Width) - 30

        Me.TopMost = True

        BtnRegistrasi.Visible = False
        TxtID.Text = ""
        TxtNama.Text = ""
        TxtPassword.Text = ""
        TxtID.Focus()
    End Sub

#End Region 'Set Form'

#Region "Login"
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'Dim Sql As String
        'Dim rdr As MySqlDataReader
        'Sql = "SELECT NO_ID, Password FROM Admin WHERE NO_ID='" + TxtID.Text + "' AND Password='" + TxtPassword.Text + "'"
        'cmd = New MySqlCommand(Sql, koneksi)
        'rdr = cmd.ExecuteReader()
        'If rdr.HasRows = True Then
        '    HOME.Show()
        '    Me.Hide()
        'Else
        '    MessageBox.Show("ID dan Password yang anda masukkan salah")
        '    TxtID.Clear()
        '    TxtPassword.Clear()
        '    TxtID.Focus()
        'End If


        If TxtID.Text = "admin" And TxtPassword.Text = "admin" Then
            HOME.Show()
            Me.Hide()
        Else
            MessageBox.Show("ID dan Password yang anda masukkan salah")
            TxtID.Clear()
            TxtPassword.Clear()
            TxtID.Focus()
        End If

    End Sub
#End Region

#Region "Cancel"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        TxtID.Clear()
        TxtNama.Clear()
        TxtPassword.Clear()
        TxtID.Focus()
    End Sub
#End Region

    'Private Sub BtnRegistrasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrasi.Click
    '    register.Show()
    '    Me.Hide()
    'End Sub
End Class
