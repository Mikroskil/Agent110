Public Class HOME


    Private Sub HOME_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanelHome.Top = PanelHome.Height / 5
        PanelHome.Left = (Me.Width - PanelHome.Width - 5) / 20
        PictureBox1.Left = (Me.Width - PanelHome.Width - 5)
        ItemPanelShutdown.Top = ItemPanelShutdown.Height * 2
        ItemPanelMonitoring.Top = ItemPanelMonitoring.Height * 3.5
        ItemPanelRestart.Top = ItemPanelRestart.Height * 2
        ItemPanelLogout.Top = ItemPanelLogout.Height * 3.5
        ItemPanelShutdown.Left = (Me.Width - ItemPanelShutdown.Width - 5) / 3
        ItemPanelMonitoring.Left = (Me.Width - ItemPanelMonitoring.Width - 5) / 3
        ItemPanelRestart.Left = (Me.Width - PanelHome.Width) / 1.5
        ItemPanelLogout.Left = (Me.Width - PanelHome.Width) / 1.5
    End Sub

    Private Sub MetroShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroShutdown.Click
      
    End Sub

    Private Sub MetroMonitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroMonitoring.Click

    End Sub

    Private Sub ItemPanelMonitoring_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemPanelMonitoring.Click
        Me.Hide()
        Monitoring.Show()
    End Sub
End Class