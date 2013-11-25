Public Class register
#Region "submit"
    Private Sub BtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click

        MsgBox("Data Telah Disimpan, Silahkan Login ", vbOKOnly, "Pemberitahuan")
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

#Region "cancel"
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

    End Sub

    Private Sub BtnCancel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.MouseEnter
        BtnCancel.BackColor = Color.SlateGray
    End Sub

    Private Sub BtnCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.MouseLeave
        BtnCancel.BackColor = Color.DarkTurquoise
    End Sub
#End Region


    Private Sub register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
End Class