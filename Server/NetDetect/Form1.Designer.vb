<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.resultsListView = New System.Windows.Forms.ListView
        Me.ipAddressColumn = New System.Windows.Forms.ColumnHeader("")
        Me.responseTimeColumn = New System.Windows.Forms.ColumnHeader("")
        Me.label3 = New System.Windows.Forms.Label
        Me.scanButton = New System.Windows.Forms.Button
        Me.endIPTextBox = New System.Windows.Forms.TextBox
        Me.startIPTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'resultsListView
        '
        Me.resultsListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resultsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ipAddressColumn, Me.responseTimeColumn})
        Me.resultsListView.Location = New System.Drawing.Point(13, 112)
        Me.resultsListView.Name = "resultsListView"
        Me.resultsListView.Size = New System.Drawing.Size(267, 143)
        Me.resultsListView.TabIndex = 14
        Me.resultsListView.View = System.Windows.Forms.View.Details
        '
        'ipAddressColumn
        '
        Me.ipAddressColumn.Text = "IP Address"
        Me.ipAddressColumn.Width = 120
        '
        'responseTimeColumn
        '
        Me.responseTimeColumn.Text = "Response Time"
        Me.responseTimeColumn.Width = 120
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(13, 91)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(121, 13)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Found Network Devices:"
        '
        'scanButton
        '
        Me.scanButton.Location = New System.Drawing.Point(13, 56)
        Me.scanButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.scanButton.Name = "scanButton"
        Me.scanButton.Size = New System.Drawing.Size(75, 23)
        Me.scanButton.TabIndex = 12
        Me.scanButton.Text = "Scan"
        '
        'endIPTextBox
        '
        Me.endIPTextBox.Location = New System.Drawing.Point(55, 32)
        Me.endIPTextBox.Margin = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.endIPTextBox.Name = "endIPTextBox"
        Me.endIPTextBox.Size = New System.Drawing.Size(100, 20)
        Me.endIPTextBox.TabIndex = 11
        '
        'startIPTextBox
        '
        Me.startIPTextBox.Location = New System.Drawing.Point(55, 11)
        Me.startIPTextBox.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.startIPTextBox.Name = "startIPTextBox"
        Me.startIPTextBox.Size = New System.Drawing.Size(100, 20)
        Me.startIPTextBox.TabIndex = 10
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 35)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "End IP"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 14)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(38, 13)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Start IP"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.resultsListView)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.scanButton)
        Me.Controls.Add(Me.endIPTextBox)
        Me.Controls.Add(Me.startIPTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents resultsListView As System.Windows.Forms.ListView
    Friend WithEvents ipAddressColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents responseTimeColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents scanButton As System.Windows.Forms.Button
    Friend WithEvents endIPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents startIPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label

End Class
