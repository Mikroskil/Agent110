Imports MySql.Data.MySqlClient
Imports System.Net

Public Class register

#Region "Deklarasi Variabel"
    Dim con As MySqlConnection
    Dim cmd As MySqlCommand
    Dim ad As MySqlDataAdapter
    Dim dr As DataRow
    Public ds As DataSet
    Dim cb As MySqlCommandBuilder
    Dim dc(0) As DataColumn
#End Region

    Sub updateDB()
        cb = New MySqlCommandBuilder(ad)
        ad = cb.DataAdapter
        ad.Update(ds, "Admin")
    End Sub

    Sub kosong()
        TxtNo.Clear()
        TxtPass.Clear()
        TxtRePass.Clear()
        TxtNip.Clear()
    End Sub

#Region "Form Load"
    Private Sub register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New MySqlConnection("Server=192.168.3.1; Port=3306 Database= Laboratorium; User Id=admin; Password=admin")
        cmd = New MySqlCommand("select * from Admin", con)
        ad = New MySqlDataAdapter(cmd)
        ds = New DataSet
        ad.Fill(ds, "Admin")
        dc(0) = ds.Tables("Admin").Columns("NO_ID")
        ds.Tables("Admin").PrimaryKey = dc

        Label1.Top = Label1.Height * 5
        Label1.Left = (Me.Width - Label1.Width - 50) / 1.9

        'Panel  ID, password, Nip
        Panel1.Width = Label2.Width * 5
        Panel1.Left = (Me.Width / 5 + (Panel1.Width / 3.5))
        Panel1.Height = (Label2.Height + Label3.Height + Label4.Height + Label5.Height + 100)
        Panel1.Top = Me.Height / 3
        Label2.Left = Label3.Width / 2
        Label3.Left = Label3.Width / 2
        Label4.Left = Label4.Width / 2
        Label5.Left = Label5.Width / 2

        'Panel submit, Cancel'
        Panel2.Width = Me.Width
        Panel2.Left = Me.Left
        Panel2.Height = 100
        Panel2.Top = Me.Height - Panel2.Height()
        BtnCancel.Left = (Panel2.Width / 2 + 10)
        BtnSubmit.Left = (BtnCancel.Left - BtnCancel.Width) - 30
    End Sub
#End Region

#Region "submit"
    Private Sub BtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        dr = ds.Tables("Admin").NewRow
        dr("NO_ID") = TxtNo.Text
        dr("NIP") = TxtNip.Text
        dr("Password") = TxtPass.Text
        ds.Tables("Admin").Rows.Add(dr)
        Call updateDB()
        BtnSubmit.Enabled = False
        MsgBox("Data Telah Disimpan, Silahkan Login ", vbOKOnly, "Pemberitahuan")
        kosong()
        Me.Hide()
        LoginAdmin.Show()
    End Sub

    Private Sub BtnSubmit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.MouseEnter
        BtnSubmit.BackColor = Color.SlateGray
    End Sub

    Private Sub BtnSubmit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.MouseLeave
        BtnSubmit.BackColor = Color.DarkTurquoise

    End Sub
#End Region

#Region "Validasi Input Data"
    Private Sub TxtNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNo.Validating
        If TxtNo.Text = "" Then
            ErrorProvider1.SetError(TxtNo, "No ID Wajib Diisi ")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TxtNo, "")
        End If
    End Sub

    Private Sub TxtPass_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPass.Validating
        If TxtPass.Text = "" Then
            ErrorProvider1.SetError(TxtPass, "Password Wajib Diisi ")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TxtPass, "")
        End If
    End Sub

    Private Sub TxtRePass_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRePass.Validating
        If TxtRePass.Text <> TxtPass.Text Then
            ErrorProvider1.SetError(TxtRePass, "Harus Sama dengan Password ")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TxtRePass, "")
        End If
    End Sub

    Private Sub TxtNip_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNip.Validating
        If TxtNip.Text = "" Then
            ErrorProvider1.SetError(TxtNip, "No ID Wajib Diisi ")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TxtNip, "")
        End If
    End Sub
#End Region

#Region "cancel"
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        End
    End Sub

    Private Sub BtnCancel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.MouseEnter
        BtnCancel.BackColor = Color.SlateGray
    End Sub

    Private Sub BtnCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.MouseLeave
        BtnCancel.BackColor = Color.DarkTurquoise
    End Sub
#End Region

End Class