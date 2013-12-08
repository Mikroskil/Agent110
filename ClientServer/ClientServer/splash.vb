Public Class splash
    Inherits System.Windows.Forms.Form

    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        pnllogo.Left = (Me.Width - pnllogo.Width) / 2
        pnllogo.Top = (Me.Height - pnllogo.Height) / 2
    End Sub

#Region "Event Jika Klik"
    Private Sub main_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        main.Show()
        Me.Hide()
    End Sub

    Private Sub piclogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles piclogo.Click
        main.Show()
        Me.Hide()
    End Sub

    Private Sub lbllogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbllogo.Click
        main.Show()
        Me.Hide()
    End Sub

    Private Sub lblcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcompany.Click
        main.Show()
        Me.Hide()
    End Sub
#End Region

End Class
