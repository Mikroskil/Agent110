<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(splash))
        Me.lblcompany = New System.Windows.Forms.Label()
        Me.piclogo = New System.Windows.Forms.PictureBox()
        Me.pnllogo = New System.Windows.Forms.Panel()
        Me.lbllogo = New System.Windows.Forms.Label()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnllogo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblcompany
        '
        Me.lblcompany.AutoSize = True
        Me.lblcompany.Font = New System.Drawing.Font("Segoe UI Light", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcompany.ForeColor = System.Drawing.Color.Maroon
        Me.lblcompany.Location = New System.Drawing.Point(236, 3)
        Me.lblcompany.Name = "lblcompany"
        Me.lblcompany.Size = New System.Drawing.Size(501, 62)
        Me.lblcompany.TabIndex = 2
        Me.lblcompany.Text = "Laboratorium Komputer"
        '
        'piclogo
        '
        Me.piclogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.piclogo.Image = CType(resources.GetObject("piclogo.Image"), System.Drawing.Image)
        Me.piclogo.Location = New System.Drawing.Point(3, 3)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(227, 200)
        Me.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.piclogo.TabIndex = 0
        Me.piclogo.TabStop = False
        '
        'pnllogo
        '
        Me.pnllogo.Controls.Add(Me.lblcompany)
        Me.pnllogo.Controls.Add(Me.lbllogo)
        Me.pnllogo.Controls.Add(Me.piclogo)
        Me.pnllogo.Location = New System.Drawing.Point(12, 12)
        Me.pnllogo.Name = "pnllogo"
        Me.pnllogo.Size = New System.Drawing.Size(868, 213)
        Me.pnllogo.TabIndex = 1
        '
        'lbllogo
        '
        Me.lbllogo.AutoSize = True
        Me.lbllogo.Font = New System.Drawing.Font("Segoe UI Light", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllogo.ForeColor = System.Drawing.Color.Maroon
        Me.lbllogo.Location = New System.Drawing.Point(232, 91)
        Me.lbllogo.Name = "lbllogo"
        Me.lbllogo.Size = New System.Drawing.Size(652, 89)
        Me.lbllogo.TabIndex = 1
        Me.lbllogo.Text = "STMIK - STIE Mikroskil"
        '
        'splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(904, 293)
        Me.Controls.Add(Me.pnllogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "splash"
        Me.Text = "Form1"
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnllogo.ResumeLayout(False)
        Me.pnllogo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblcompany As System.Windows.Forms.Label
    Friend WithEvents piclogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnllogo As System.Windows.Forms.Panel
    Friend WithEvents lbllogo As System.Windows.Forms.Label
End Class
