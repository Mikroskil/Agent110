<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginAdmin))
        Me.LblAdmin = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlappbar = New System.Windows.Forms.Panel()
        Me.BtnRegistrasi = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblPass = New System.Windows.Forms.Label()
        Me.LblNama = New System.Windows.Forms.Label()
        Me.LblID = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtNama = New System.Windows.Forms.TextBox()
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlappbar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblAdmin
        '
        Me.LblAdmin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LblAdmin.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblAdmin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblAdmin.Location = New System.Drawing.Point(82, 3)
        Me.LblAdmin.Name = "LblAdmin"
        Me.LblAdmin.Size = New System.Drawing.Size(202, 73)
        Me.LblAdmin.TabIndex = 0
        Me.LblAdmin.Text = "LOGIN ADMINISTRATOR"
        Me.LblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(415, 31)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 45)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Reset"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlappbar
        '
        Me.pnlappbar.BackColor = System.Drawing.Color.Teal
        Me.pnlappbar.Controls.Add(Me.BtnRegistrasi)
        Me.pnlappbar.Controls.Add(Me.btnLogin)
        Me.pnlappbar.Controls.Add(Me.btnCancel)
        Me.pnlappbar.Location = New System.Drawing.Point(86, 457)
        Me.pnlappbar.Name = "pnlappbar"
        Me.pnlappbar.Size = New System.Drawing.Size(766, 100)
        Me.pnlappbar.TabIndex = 5
        '
        'BtnRegistrasi
        '
        Me.BtnRegistrasi.BackColor = System.Drawing.Color.LightSeaGreen
        Me.BtnRegistrasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegistrasi.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrasi.ForeColor = System.Drawing.Color.White
        Me.BtnRegistrasi.Location = New System.Drawing.Point(575, 31)
        Me.BtnRegistrasi.Name = "BtnRegistrasi"
        Me.BtnRegistrasi.Size = New System.Drawing.Size(120, 45)
        Me.BtnRegistrasi.TabIndex = 6
        Me.BtnRegistrasi.Text = "Registrasi"
        Me.BtnRegistrasi.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(254, 31)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(120, 45)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LblPass)
        Me.Panel1.Controls.Add(Me.LblNama)
        Me.Panel1.Controls.Add(Me.LblID)
        Me.Panel1.Location = New System.Drawing.Point(86, 181)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 247)
        Me.Panel1.TabIndex = 10
        '
        'LblPass
        '
        Me.LblPass.BackColor = System.Drawing.Color.White
        Me.LblPass.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblPass.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblPass.Location = New System.Drawing.Point(48, 174)
        Me.LblPass.Name = "LblPass"
        Me.LblPass.Size = New System.Drawing.Size(95, 47)
        Me.LblPass.TabIndex = 15
        Me.LblPass.Text = "Password"
        Me.LblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNama
        '
        Me.LblNama.BackColor = System.Drawing.Color.White
        Me.LblNama.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblNama.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblNama.Location = New System.Drawing.Point(48, 96)
        Me.LblNama.Name = "LblNama"
        Me.LblNama.Size = New System.Drawing.Size(95, 47)
        Me.LblNama.TabIndex = 14
        Me.LblNama.Text = "Name"
        Me.LblNama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblID
        '
        Me.LblID.BackColor = System.Drawing.Color.White
        Me.LblID.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblID.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblID.Location = New System.Drawing.Point(48, 12)
        Me.LblID.Name = "LblID"
        Me.LblID.Size = New System.Drawing.Size(95, 47)
        Me.LblID.TabIndex = 13
        Me.LblID.Text = "ID"
        Me.LblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.TxtPassword)
        Me.Panel2.Controls.Add(Me.TxtNama)
        Me.Panel2.Controls.Add(Me.TxtID)
        Me.Panel2.Location = New System.Drawing.Point(367, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(440, 247)
        Me.Panel2.TabIndex = 11
        '
        'TxtPassword
        '
        Me.TxtPassword.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.Location = New System.Drawing.Point(61, 187)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(342, 27)
        Me.TxtPassword.TabIndex = 2
        '
        'TxtNama
        '
        Me.TxtNama.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNama.Location = New System.Drawing.Point(61, 109)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(342, 27)
        Me.TxtNama.TabIndex = 1
        '
        'TxtID
        '
        Me.TxtID.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtID.Location = New System.Drawing.Point(61, 25)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(342, 27)
        Me.TxtID.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblAdmin)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(158, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(290, 82)
        Me.Panel3.TabIndex = 13
        '
        'LoginAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumTurquoise
        Me.ClientSize = New System.Drawing.Size(880, 567)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlappbar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoginAdmin"
        Me.Text = "Login Admin"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlappbar.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblAdmin As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlappbar As System.Windows.Forms.Panel
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents TxtNama As System.Windows.Forms.TextBox
    Friend WithEvents LblPass As System.Windows.Forms.Label
    Friend WithEvents LblNama As System.Windows.Forms.Label
    Friend WithEvents LblID As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnRegistrasi As System.Windows.Forms.Button

End Class
