Public Class register
#Region "submit"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'This code will Restart Windows
        'System.Diagnostics.Process.Start("shutdown", "-r -t 05")
        Application.Exit()
    End Sub

    Private Sub Submit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.SlateGray
    End Sub

    Private Sub Submit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.DarkTurquoise

    End Sub
#End Region

#Region "cancel"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Cancel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.DarkTurquoise
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
        Button2.Left = (Panel2.Width / 2 + 10)
        Button1.Left = (Button2.Left - Button2.Width) - 30



    End Sub
End Class