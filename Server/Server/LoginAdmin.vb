﻿Public Class LoginAdmin

    Dim db As ADODB.Connection
    Dim rs As ADODB.Recordset

#Region "Set Form"
    Private Sub LoginAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcontrols()
    End Sub

    Private Sub setcontrols()
        'Panel 3 Label Administrator
        Panel3.Top = Panel3.Height / 5
        Panel3.Left = (Me.Width - Panel3.Width - 50) / 2
        'LblAdmin.Left = (Me.Width - LblAdmin.Width - 50) / 2
        'LblAdmin.Top = LblAdmin.Height / 5

        'Panel  Label ID, Nama, Pass
        Panel1.Width = LblID.Width * 2
        Panel1.Left = (Me.Width / 4 + (Panel1.Width / 3))
        Panel1.Height = (LblID.Height + LblNama.Height + LblPass.Height + 100)
        Panel1.Top = Me.Height / 3
        LblID.Left = LblID.Width / 2
        LblNama.Left = LblNama.Width / 2
        LblPass.Left = LblPass.Width / 2

        'Panel Textbox'

        Panel2.Left = (Me.Width / 3) + Panel1.Left / 3
        Panel2.Top = Me.Height / 3
        Panel2.Height = Panel1.Height

        'Panel Login, Cancel'
        pnlappbar.Width = Me.Width
        pnlappbar.Left = Me.Left
        pnlappbar.Height = 100
        pnlappbar.Top = Me.Height - pnlappbar.Height
        btnCancel.Left = (pnlappbar.Width / 2 + 10)
        btnLogin.Left = (btnCancel.Left - btnCancel.Width) - 30

        Me.TopMost = True
    End Sub
#End Region 'Set Form'


End Class