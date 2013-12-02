Public Class HOME


    Private Sub HOME_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanelHome.Top = PanelHome.Height / 5
        PanelHome.Left = (Me.Width - PanelHome.Width - 5) / 20
        'PictureBox1.Left = (Me.Width - PanelHome.Width - 5)
        ItemPanelShutdown.Top = ItemPanelShutdown.Height * 2
        ItemPanelMonitoring.Top = ItemPanelMonitoring.Height * 3.5
        ItemPanelRestart.Top = ItemPanelRestart.Height * 2
        ItemPanelLogout.Top = ItemPanelLogout.Height * 3.5
        ItemPanelShutdown.Left = (Me.Width - ItemPanelShutdown.Width - 5) / 3
        ItemPanelMonitoring.Left = (Me.Width - ItemPanelMonitoring.Width - 5) / 3
        ItemPanelRestart.Left = (Me.Width - PanelHome.Width) / 1.5
        ItemPanelLogout.Left = (Me.Width - PanelHome.Width) / 1.5
        Panel1.Top = PanelHome.Height / 5
        Panel1.Left = (Me.Width - PanelHome.Width) / 1.1
        LblAdmin.Text = LoginAdmin.TxtNama.Text

    End Sub

    Private Sub MetroShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroShutdown.Click
        MsgBox("Apakah kamu yakin ingin meshutdown semua komputer Client", vbYesNoCancel, "Peringatan")

    End Sub

    Private Sub MetroMonitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroMonitoring.Click

    End Sub

    Private Sub ItemPanelMonitoring_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemPanelMonitoring.Click
        Me.Hide()
        Monitoring.Show()
    End Sub

    Private Sub MetroLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLogout.Click
        Me.Hide()
        LoginAdmin.Show()
        LoginAdmin.TxtID.Text = ""
        LoginAdmin.TxtNama.Text = ""
        LoginAdmin.TxtPassword.Text = ""
        LoginAdmin.TxtID.Focus()
    End Sub

    Private Sub MetroRestart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroRestart.Click
        MsgBox("Apakah kamu yakin meRestart semua Komputer Client", vbYesNo, "Peringatan")
    End Sub
End Class