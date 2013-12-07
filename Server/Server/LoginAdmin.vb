'Imports System.Data
'Imports System.Data.SqlClient

Public Class LoginAdmin

    '======== untuk koneksi ==============
    'Dim con As SqlConnection
    'Dim cmd As SqlCommand
    'Dim ad As SqlDataAdapter
    'Dim dr As DataRow
    'Public ds As DataSet
    'Dim cb As SqlCommandBuilder
    'Dim dc(0) As DataColumn
    'Dim koneksi As SqlConnection
    '=====================================

#Region "Set Form"
    Private Sub LoginAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
        
        'Dim strKoneksi As String
        'strKoneksi = "Data Source=ASUS-1025C\SQLEXPRESS; Initial Catalog = Laboratorium; Integrated Security=True"
        'koneksi = (New SqlConnection(strKoneksi))
        'Try
        '    koneksi.Open()
        'Catch ex As Exception
        '    MessageBox.Show("Koneksi Gagal")
        'End Try

        TxtID.Text = ""
        TxtNama.Text = ""
        TxtPassword.Text = ""
        TxtID.Focus()
    End Sub

    Private Sub setcontrols()

        'Panel 3 Label Administrator
        'BtnSignUp.Left = (Me.Width - BtnSignUp.Width - 10)
        'BtnSignUp.Left = Me.Width / 1.1
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
    End Sub
#End Region 'Set Form'

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If TxtID.Text = "Admin" And TxtPassword.Text = "admin" Then
            HOME.Show()
            Me.Hide()
        Else
            MessageBox.Show("ID dan Password yang anda masukkan salah")
            TxtID.Clear()
            TxtPassword.Clear()
            TxtID.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        TxtID.Clear()
        TxtNama.Clear()
        TxtPassword.Clear()
        TxtID.Focus()
    End Sub

End Class
