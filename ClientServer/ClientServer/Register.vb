Imports System.Data
Imports System.Data.SqlClient

Public Class Register
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim dr As DataRow
    Public ds As DataSet
    Dim cb As SqlCommandBuilder
    Dim dc(0) As DataColumn


    Sub updateDB()
        cb = New SqlCommandBuilder(ad)
        ad = cb.DataAdapter
        ad.Update(ds, "Client")
    End Sub

    Sub kosong()
        txtID.Clear()
        txtPass.Clear()
        txtRePass.Clear()


    End Sub
#Region "Set Form"
    Private Sub Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()

        con = New SqlConnection("Data Source = WULAN-4750; Initial Catalog = Laboratorium; Integrated Security = true")
        cmd = New SqlCommand("select * from Client", con)
        ad = New SqlDataAdapter(cmd)
        ds = New DataSet
        ad.Fill(ds, "Client")
        dc(0) = ds.Tables("Client").Columns("Nim")
        ds.Tables("Client").PrimaryKey = dc

        kosong()
        txtID.Focus()


    End Sub

    Public Sub setcontrols()
        Label5.Left = (Me.Width - Label5.Width - 50) / 2
        Label5.Top = Label5.Height * 5

        Panel1.Width = Label1.Width * 2
        Panel1.Left = Me.Width / 3
        Panel1.Height = (Label1.Height + Label2.Height + Label3.Height + Label4.Height + 100)
        Panel1.Top = Me.Height / 3

        Panel2.Left = (Me.Width / 4) + Panel1.Left / 2 + 30
        Panel2.Top = Me.Height / 3
        Panel2.Height = Panel1.Height

        Panel3.Width = Me.Width
        Panel3.Left = Me.Left
        Panel3.Height = 100
        Panel3.Top = Me.Height - Panel3.Height
        Button2.Left = (Panel3.Width / 2) + 55
        Submit.Left = (Panel3.Width / 3) + 20
        Me.TopMost = True
    End Sub
#End Region 'Set Form

#Region "Cancel Button"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Me.Visible = False
        'splash.Visible = True
        End
    End Sub

    Private Sub btnclose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.DarkTurquoise
    End Sub
#End Region 'Close Button




    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        'This code will Restart Windows
        'System.Diagnostics.Process.Start("shutdown", "-r -t 05")
        'Application.Exit()

        dr = ds.Tables("Client").NewRow
        dr("Nim") = txtID.Text
        dr("Pass") = txtPass.Text
        dr("Jurusan") = cboJurusan.SelectedItem
        ds.Tables("Client").Rows.Add(dr)
        Call updateDB()
        Submit.Enabled = False

        MsgBox("Data Telah Disimpan, Silahkan Login", vbOKOnly, "Pemberitahuan")
        kosong()
        Me.Hide()
        splash.Show()


    End Sub

    Private Sub Submit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.MouseEnter
        Submit.BackColor = Color.SlateGray
    End Sub

    Private Sub Submit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.MouseLeave
        Submit.BackColor = Color.DarkTurquoise

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class