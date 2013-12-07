Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO

Public Class HOME
    Inherits System.Windows.Forms.Form
    Dim trSendMessage As Thread

    Private Sub HOME_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanelHome.Top = PanelHome.Height / 5
        PanelHome.Left = (Me.Width - PanelHome.Width - 5) / 20
      
        Panel1.Top = PanelHome.Height / 5
        Panel1.Left = (Me.Width - PanelHome.Width) / 1.1
        LblAdmin.Text = LoginAdmin.TxtNama.Text
        GroupBox1.Top = GroupBox1.Height / 2
        GroupBox1.Left = (Me.Width - GroupBox1.Width - 5) / 2

        PanelPerintah.Width = Me.Width
        PanelPerintah.Left = Me.Left
        PanelPerintah.Top = Me.Height - PanelPerintah.Height
        BtnShutdown.Left = PanelPerintah.Width / 4
        BtnRestart.Left = PanelPerintah.Width / 4 + (BtnRestart.Width * 2)
        BtnLogOff.Left = PanelPerintah.Width / 3 + (BtnLogOff.Width * 2)
        BtnPing.Left = PanelPerintah.Width / 2 + (BtnPing.Width * 2)


    End Sub

    Private Sub BtnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShutdown.Click
        Shutdown.Show()
        Me.Hide()
    End Sub

    Private Sub BtnLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogOff.Click
        LoginAdmin.TxtID.Clear()
        LoginAdmin.TxtNama.Clear()
        LoginAdmin.TxtPassword.Clear()
        LoginAdmin.Show()
        Me.Hide()
    End Sub
End Class