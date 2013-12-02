Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class LoginAdmin
    Dim koneksi As SqlConnection
#Region "Set Form"
    Private Sub LoginAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
        Dim strKoneksi As String
        strKoneksi = "Data Source=WULAN-4750; Initial Catalog = Laboratorium; Integrated Security=True"
        koneksi = New SqlConnection(strKoneksi)

        Try
            koneksi.Open()

        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal !!")
        End Try
        TxtID.Text = ""
        TxtNama.Text = ""
        TxtPassword.Text = ""
        TxtID.Focus()
    End Sub

    Private Sub setcontrols()
        'Panel 3 Label Administrator
        Panel3.Top = Panel3.Height / 0.7
        Panel3.Left = (Me.Width - Panel3.Width - 50) / 2
        BtnSignUp.Left = Me.Width / 1.1

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
    End Sub
#End Region 'Set Form'


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim Sql, user, pass, id As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        user = TxtNama.Text
        pass = TxtPassword.Text
        id = TxtID.Text

        Sql = "SELECT Id,Pass FROM Admin WHERE Id='" + id + "' AND Pass='" + pass + "'"
        cmd = New SqlCommand(Sql, koneksi)

        rdr = cmd.ExecuteReader()

        If rdr.HasRows = True Then
            HOME.Show()
            Me.Hide()
        Else
            MessageBox.Show("Kombinasi Username ,Password dan Hak Akses Salah", "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtID.Focus()

        End If

        rdr.Close()
        cmd.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub BtnSignUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSignUp.Click
        Me.Hide()
        register.Show()

    End Sub
End Class
