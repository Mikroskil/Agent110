<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shutdown
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shutdown))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtClientIP = New System.Windows.Forms.TextBox()
        Me.lblMYIP = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.rbLogOff = New System.Windows.Forms.RadioButton()
        Me.rbReboot = New System.Windows.Forms.RadioButton()
        Me.rbShutdown = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        '
        'txtClientIP
        '
        resources.ApplyResources(Me.txtClientIP, "txtClientIP")
        Me.txtClientIP.Name = "txtClientIP"
        '
        'lblMYIP
        '
        resources.ApplyResources(Me.lblMYIP, "lblMYIP")
        Me.lblMYIP.Name = "lblMYIP"
        '
        'btnExit
        '
        resources.ApplyResources(Me.btnExit, "btnExit")
        Me.btnExit.Name = "btnExit"
        '
        'rbLogOff
        '
        resources.ApplyResources(Me.rbLogOff, "rbLogOff")
        Me.rbLogOff.Name = "rbLogOff"
        '
        'rbReboot
        '
        resources.ApplyResources(Me.rbReboot, "rbReboot")
        Me.rbReboot.Name = "rbReboot"
        '
        'rbShutdown
        '
        resources.ApplyResources(Me.rbShutdown, "rbShutdown")
        Me.rbShutdown.Name = "rbShutdown"
        '
        'Shutdown
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtClientIP)
        Me.Controls.Add(Me.lblMYIP)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.rbLogOff)
        Me.Controls.Add(Me.rbReboot)
        Me.Controls.Add(Me.rbShutdown)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Shutdown"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtClientIP As System.Windows.Forms.TextBox
    Friend WithEvents lblMYIP As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents rbLogOff As System.Windows.Forms.RadioButton
    Friend WithEvents rbReboot As System.Windows.Forms.RadioButton
    Friend WithEvents rbShutdown As System.Windows.Forms.RadioButton
End Class
