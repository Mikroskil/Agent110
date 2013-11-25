﻿Public Class main

#Region "Set Posisi Desain Dinamis Form"
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
    End Sub

    Public Sub setcontrols()
        PictureBox1.Top = (Me.Height - PictureBox1.Width - 50) / 2
        PictureBox1.Left = (Me.Width - PictureBox1.Width - 50) / 3

        Label4.Top = Label4.Height / 2
        Label4.Left = (Me.Width - Label4.Width - 50) / 2

        Panel1.Width = Label1.Width * 3
        Panel1.Left = (Me.Width / 3 + (Panel1.Width / 3))
        Panel1.Top = (Me.Height - PictureBox1.Width - 50) / 2

        Me.LblIP.Text = splash.LblIP.Text.ToString

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
        btnCancel.BackColor = Color.SlateGray
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.DarkTurquoise
    End Sub
#End Region 'Kembali Ke Tampilan Awal'

#Region "Login"
    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'This code will Restart Windows
        'System.Diagnostics.Process.Start("shutdown", "-r -t 05")
        Application.Exit()
    End Sub

    Private Sub Login_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.SlateGray
    End Sub

    Private Sub Login_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.DarkTurquoise

    End Sub
#End Region 'Login Button'

End Class