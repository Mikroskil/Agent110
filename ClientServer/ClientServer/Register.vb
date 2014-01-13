Imports MySql.Data.MySqlClient
Imports System.Net

Public Class Register
    Dim con As MySqlConnection
    Dim cmd As MySqlCommand
    Dim ad As MySqlDataAdapter
    Dim dr As DataRow
    Public ds As DataSet
    Dim cb As MySqlCommandBuilder
    Dim dc(0) As DataColumn
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)

    Sub updateDB()
        cb = New MySqlCommandBuilder(ad)
        ad = cb.DataAdapter
        ad.Update(ds, "Client")
    End Sub

    Sub kosong()
        txtID.Clear()
        txtPass.Clear()
        txtRePass.Clear()
    End Sub

#Region "Form Load"
    Private Sub Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()

        con = New MySqlConnection("Server=192.168.3.254; Port=3306; User Id=admin; Password=admin; Database=Laboratorium")
        cmd = New MySqlCommand("select * from Client", con)
        ad = New MySqlDataAdapter(cmd)
        ds = New DataSet
        ad.Fill(ds, "Client")
        dc(0) = ds.Tables("Client").Columns("NoKomputer")
        ds.Tables("Client").PrimaryKey = dc
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
#End Region

#Region "Cancel Button"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        kosong()
        splash.Show()
        Me.Close()
    End Sub

    Private Sub btnclose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.DarkTurquoise
    End Sub
#End Region

#Region "Submit Button"
    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        If txtID.Text = " " Or txtPass.Text = " " Or txtRePass.Text = " " Then
            MsgBox("Tidak boleh ada data yang kosong", vbOKOnly, "Peringatan")
            kosong()
            txtID.Focus()
        Else
            dr = ds.Tables("Client").NewRow
            dr("NoKomputer") = txtID.Text
            dr("Password") = txtPass.Text
            dr("RuangLab") = cboRuangLab.SelectedItem
            dr("IP_Address") = ipAddress.ToString
            ds.Tables("Client").Rows.Add(dr)
            Call updateDB()
            Submit.Enabled = False

            MsgBox("Data Telah Disimpan, Silahkan Login", vbOKOnly, "Pemberitahuan")
            kosong()
            main.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Submit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.MouseEnter
        Submit.BackColor = Color.SlateGray
    End Sub

    Private Sub Submit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.MouseLeave
        Submit.BackColor = Color.DarkTurquoise

    End Sub

#End Region

End Class