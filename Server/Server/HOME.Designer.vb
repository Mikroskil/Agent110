<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HOME
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HOME))
        Me.ItemPanelShutdown = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroShutdown = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemPanelRestart = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroRestart = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemPanelMonitoring = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroMonitoring = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemPanelLogout = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroLogout = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblAdmin = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelHome = New System.Windows.Forms.Panel()
        Me.LblHome = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelHome.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItemPanelShutdown
        '
        Me.ItemPanelShutdown.BackColor = System.Drawing.Color.Red
        '
        '
        '
        Me.ItemPanelShutdown.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanelShutdown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanelShutdown.ContainerControlProcessDialogKey = True
        Me.ItemPanelShutdown.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroShutdown})
        Me.ItemPanelShutdown.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelShutdown.Location = New System.Drawing.Point(12, 112)
        Me.ItemPanelShutdown.Name = "ItemPanelShutdown"
        Me.ItemPanelShutdown.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelShutdown.TabIndex = 0
        Me.ItemPanelShutdown.Text = "ItemPanel1"
        '
        'MetroShutdown
        '
        Me.MetroShutdown.Name = "MetroShutdown"
        Me.MetroShutdown.SymbolColor = System.Drawing.Color.Empty
        Me.MetroShutdown.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroShutdown.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroShutdown.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroShutdown.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroShutdown.TitleText = "SHUTDOWN"
        Me.MetroShutdown.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ItemPanelRestart
        '
        Me.ItemPanelRestart.BackColor = System.Drawing.Color.Red
        '
        '
        '
        Me.ItemPanelRestart.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanelRestart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanelRestart.ContainerControlProcessDialogKey = True
        Me.ItemPanelRestart.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroRestart})
        Me.ItemPanelRestart.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelRestart.Location = New System.Drawing.Point(351, 112)
        Me.ItemPanelRestart.Name = "ItemPanelRestart"
        Me.ItemPanelRestart.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelRestart.TabIndex = 15
        Me.ItemPanelRestart.Text = "ItemPanel2"
        '
        'MetroRestart
        '
        Me.MetroRestart.Name = "MetroRestart"
        Me.MetroRestart.SymbolColor = System.Drawing.Color.Empty
        Me.MetroRestart.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroRestart.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroRestart.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroRestart.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroRestart.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroRestart.TitleText = "RESTART"
        Me.MetroRestart.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ItemPanelMonitoring
        '
        Me.ItemPanelMonitoring.BackColor = System.Drawing.Color.Red
        '
        '
        '
        Me.ItemPanelMonitoring.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanelMonitoring.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanelMonitoring.ContainerControlProcessDialogKey = True
        Me.ItemPanelMonitoring.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroMonitoring})
        Me.ItemPanelMonitoring.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelMonitoring.Location = New System.Drawing.Point(12, 251)
        Me.ItemPanelMonitoring.Name = "ItemPanelMonitoring"
        Me.ItemPanelMonitoring.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelMonitoring.TabIndex = 16
        Me.ItemPanelMonitoring.Text = "ItemPanel4"
        '
        'MetroMonitoring
        '
        Me.MetroMonitoring.Name = "MetroMonitoring"
        Me.MetroMonitoring.SymbolColor = System.Drawing.Color.Empty
        Me.MetroMonitoring.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroMonitoring.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroMonitoring.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroMonitoring.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroMonitoring.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroMonitoring.TitleText = "MONITORING"
        Me.MetroMonitoring.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ItemPanelLogout
        '
        Me.ItemPanelLogout.BackColor = System.Drawing.Color.Red
        '
        '
        '
        Me.ItemPanelLogout.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanelLogout.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanelLogout.ContainerControlProcessDialogKey = True
        Me.ItemPanelLogout.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroLogout})
        Me.ItemPanelLogout.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelLogout.Location = New System.Drawing.Point(351, 251)
        Me.ItemPanelLogout.Name = "ItemPanelLogout"
        Me.ItemPanelLogout.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelLogout.TabIndex = 17
        Me.ItemPanelLogout.Text = "ItemPanel3"
        '
        'MetroLogout
        '
        Me.MetroLogout.Name = "MetroLogout"
        Me.MetroLogout.SymbolColor = System.Drawing.Color.Empty
        Me.MetroLogout.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroLogout.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroLogout.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroLogout.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroLogout.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroLogout.TitleText = "LOGOUT"
        Me.MetroLogout.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.LblAdmin)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(393, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(203, 81)
        Me.Panel1.TabIndex = 21
        '
        'LblAdmin
        '
        Me.LblAdmin.AutoSize = True
        Me.LblAdmin.Font = New System.Drawing.Font("Rockwell Condensed", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmin.ForeColor = System.Drawing.Color.White
        Me.LblAdmin.Location = New System.Drawing.Point(16, 26)
        Me.LblAdmin.Name = "LblAdmin"
        Me.LblAdmin.Size = New System.Drawing.Size(76, 31)
        Me.LblAdmin.TabIndex = 18
        Me.LblAdmin.Text = "Nama"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(127, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'PanelHome
        '
        Me.PanelHome.Controls.Add(Me.LblHome)
        Me.PanelHome.Location = New System.Drawing.Point(9, 6)
        Me.PanelHome.Name = "PanelHome"
        Me.PanelHome.Size = New System.Drawing.Size(169, 80)
        Me.PanelHome.TabIndex = 20
        '
        'LblHome
        '
        Me.LblHome.BackColor = System.Drawing.Color.Transparent
        Me.LblHome.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblHome.Font = New System.Drawing.Font("Rockwell", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHome.ForeColor = System.Drawing.Color.White
        Me.LblHome.Location = New System.Drawing.Point(2, 3)
        Me.LblHome.Name = "LblHome"
        Me.LblHome.Size = New System.Drawing.Size(164, 73)
        Me.LblHome.TabIndex = 0
        Me.LblHome.Text = "HOME"
        Me.LblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HOME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(604, 568)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelHome)
        Me.Controls.Add(Me.ItemPanelLogout)
        Me.Controls.Add(Me.ItemPanelMonitoring)
        Me.Controls.Add(Me.ItemPanelRestart)
        Me.Controls.Add(Me.ItemPanelShutdown)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "HOME"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelHome.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ItemPanelShutdown As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroShutdown As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemPanelRestart As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroRestart As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemPanelMonitoring As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroMonitoring As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemPanelLogout As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroLogout As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblAdmin As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelHome As System.Windows.Forms.Panel
    Friend WithEvents LblHome As System.Windows.Forms.Label
End Class
