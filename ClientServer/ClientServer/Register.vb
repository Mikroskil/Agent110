Public Class Register
#Region "Set Form"

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
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
        Button1.Left = (Panel3.Width / 3) + 20
        Me.TopMost = True
    End Sub
#End Region 'Set Form

#Region "Cancel Button"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        splash.Visible = True

    End Sub

    Private Sub btnclose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.DarkTurquoise
    End Sub
#End Region 'Close Button



#Region "Sign Up"
    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'This code will Restart Windows
        'System.Diagnostics.Process.Start("shutdown", "-r -t 05")
        Application.Exit()
    End Sub

    Private Sub Login_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.SlateGray
    End Sub

    Private Sub Login_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.DarkTurquoise

    End Sub
#End Region 'Login Button'



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class