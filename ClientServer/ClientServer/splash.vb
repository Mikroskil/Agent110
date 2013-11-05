Public Class splash

    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set Splash Screen size and begin the Timer
        Me.WindowState = FormWindowState.Maximized
        pnllogo.Left = (Me.Width - pnllogo.Width) / 2
        pnllogo.Top = (Me.Height - pnllogo.Height) / 2
    End Sub

    Private Sub main_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub piclogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles piclogo.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub lbllogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbllogo.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub lblcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcompany.Click
        Me.Visible = False
        main.Visible = True
    End Sub
End Class
