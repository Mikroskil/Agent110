Public Class main

#Region "Set Form"
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
    End Sub

    Public Sub setcontrols()
        'Sets the location for all of the controls on the form.
        pnlappbar.Width = Me.Width
        pnlappbar.Left = Me.Left
        pnlappbar.Height = 100
        pnlappbar.Top = Me.Height - pnlappbar.Height
        btnCancel.Left = (pnlappbar.Width / 2) - 10
        btnLogin.Left = (btnCancel.Left - btnCancel.Width) - 30
        Me.TopMost = True
    End Sub
#End Region 'Set Form


#Region "Cancel Button"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
        splash.Visible = True

    End Sub

    Private Sub btnclose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.Gray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.Black
    End Sub
#End Region 'Close Button



#Region "Login"
    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'This code will Restart Windows
        'System.Diagnostics.Process.Start("shutdown", "-r -t 05")
        Application.Exit()
    End Sub

    Private Sub Login_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.Gray
    End Sub

    Private Sub Login_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.Black
    End Sub
#End Region 'Login Button'





End Class