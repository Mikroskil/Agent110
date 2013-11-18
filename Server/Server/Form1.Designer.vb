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
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.PanelHome = New System.Windows.Forms.Panel()
        Me.LblHome = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ItemPanelRestart = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemPanelMonitoring = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroTileItem4 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemPanelLogout = New DevComponents.DotNetBar.ItemPanel()
        Me.MetroTileItem3 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.PanelHome.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ItemPanelShutdown.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem1})
        Me.ItemPanelShutdown.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelShutdown.Location = New System.Drawing.Point(12, 112)
        Me.ItemPanelShutdown.Name = "ItemPanelShutdown"
        Me.ItemPanelShutdown.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelShutdown.TabIndex = 0
        Me.ItemPanelShutdown.Text = "ItemPanel1"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroTileItem1.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem1.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTileItem1.TitleText = "SHUTDOWN"
        Me.MetroTileItem1.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelHome
        '
        Me.PanelHome.Controls.Add(Me.LblHome)
        Me.PanelHome.Controls.Add(Me.PictureBox1)
        Me.PanelHome.Location = New System.Drawing.Point(159, 12)
        Me.PanelHome.Name = "PanelHome"
        Me.PanelHome.Size = New System.Drawing.Size(289, 80)
        Me.PanelHome.TabIndex = 14
        '
        'LblHome
        '
        Me.LblHome.BackColor = System.Drawing.Color.White
        Me.LblHome.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblHome.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.LblHome.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblHome.Location = New System.Drawing.Point(82, 3)
        Me.LblHome.Name = "LblHome"
        Me.LblHome.Size = New System.Drawing.Size(202, 73)
        Me.LblHome.TabIndex = 0
        Me.LblHome.Text = "HOME"
        Me.LblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'ItemPanelRestart
        '
        Me.ItemPanelRestart.BackColor = System.Drawing.Color.Red
        '
        '
        '
        Me.ItemPanelRestart.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanelRestart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanelRestart.ContainerControlProcessDialogKey = True
        Me.ItemPanelRestart.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem2})
        Me.ItemPanelRestart.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelRestart.Location = New System.Drawing.Point(351, 112)
        Me.ItemPanelRestart.Name = "ItemPanelRestart"
        Me.ItemPanelRestart.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelRestart.TabIndex = 15
        Me.ItemPanelRestart.Text = "ItemPanel2"
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroTileItem2.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem2.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTileItem2.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroTileItem2.TitleText = "RESTART"
        Me.MetroTileItem2.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.ItemPanelMonitoring.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem4})
        Me.ItemPanelMonitoring.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelMonitoring.Location = New System.Drawing.Point(12, 251)
        Me.ItemPanelMonitoring.Name = "ItemPanelMonitoring"
        Me.ItemPanelMonitoring.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelMonitoring.TabIndex = 16
        Me.ItemPanelMonitoring.Text = "ItemPanel4"
        '
        'MetroTileItem4
        '
        Me.MetroTileItem4.Name = "MetroTileItem4"
        Me.MetroTileItem4.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroTileItem4.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem4.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTileItem4.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroTileItem4.TitleText = "MONITORING"
        Me.MetroTileItem4.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.ItemPanelLogout.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem3})
        Me.ItemPanelLogout.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanelLogout.Location = New System.Drawing.Point(351, 251)
        Me.ItemPanelLogout.Name = "ItemPanelLogout"
        Me.ItemPanelLogout.Size = New System.Drawing.Size(219, 104)
        Me.ItemPanelLogout.TabIndex = 17
        Me.ItemPanelLogout.Text = "ItemPanel3"
        '
        'MetroTileItem3
        '
        Me.MetroTileItem3.Name = "MetroTileItem3"
        Me.MetroTileItem3.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.MetroTileItem3.TileSize = New System.Drawing.Size(220, 100)
        '
        '
        '
        Me.MetroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem3.TileStyle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTileItem3.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroTileItem3.TitleText = "LOGOUT"
        Me.MetroTileItem3.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HOME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(604, 568)
        Me.Controls.Add(Me.ItemPanelLogout)
        Me.Controls.Add(Me.ItemPanelMonitoring)
        Me.Controls.Add(Me.ItemPanelRestart)
        Me.Controls.Add(Me.PanelHome)
        Me.Controls.Add(Me.ItemPanelShutdown)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "HOME"
        Me.Text = "Form1"
        Me.PanelHome.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItemPanelShutdown As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents PanelHome As System.Windows.Forms.Panel
    Friend WithEvents LblHome As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ItemPanelRestart As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemPanelMonitoring As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroTileItem4 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemPanelLogout As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents MetroTileItem3 As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
