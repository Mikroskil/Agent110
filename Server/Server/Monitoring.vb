Public Class Monitoring

    Private Sub Kembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kembali.Click
        Me.Close()
        HOME.Show()
    End Sub

    Private Sub Monitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Left = (Me.Width - GroupBox1.Width - 5) / 1.2
        PictureBox1.Left = (Me.Width - GroupBox1.Width - 2) / 0.5
        GroupBox1.Top = GroupBox1.Height / 2
        GroupBox1.Left = (Me.Width - GroupBox1.Width - 5) / 2
        PictureBox2.Top = GroupBox1.Height * 1.8
        PictureBox2.Left = (Me.Width - GroupBox1.Width - 5)
        PictureBox3.Left = (Me.Width - GroupBox1.Width - 5) / 0.8
        PictureBox3.Top = GroupBox1.Height * 1.8
    End Sub

    
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class