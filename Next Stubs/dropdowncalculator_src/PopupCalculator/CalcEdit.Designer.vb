<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalcEdit
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.PopupPanel = New System.Windows.Forms.Panel
        Me.cmdPopupCalc = New System.Windows.Forms.Button
        Me.EditPanel = New System.Windows.Forms.Panel
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.PopupPanel.SuspendLayout()
        Me.EditPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'PopupPanel
        '
        Me.PopupPanel.Controls.Add(Me.cmdPopupCalc)
        Me.PopupPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.PopupPanel.Location = New System.Drawing.Point(211, 0)
        Me.PopupPanel.Name = "PopupPanel"
        Me.PopupPanel.Size = New System.Drawing.Size(27, 22)
        Me.PopupPanel.TabIndex = 0
        '
        'cmdPopupCalc
        '
        Me.cmdPopupCalc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdPopupCalc.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.cmdPopupCalc.Location = New System.Drawing.Point(0, 0)
        Me.cmdPopupCalc.Name = "cmdPopupCalc"
        Me.cmdPopupCalc.Size = New System.Drawing.Size(27, 22)
        Me.cmdPopupCalc.TabIndex = 0
        Me.cmdPopupCalc.Text = "Button1"
        Me.cmdPopupCalc.UseVisualStyleBackColor = True
        '
        'EditPanel
        '
        Me.EditPanel.Controls.Add(Me.txtValue)
        Me.EditPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditPanel.Location = New System.Drawing.Point(0, 0)
        Me.EditPanel.Name = "EditPanel"
        Me.EditPanel.Size = New System.Drawing.Size(211, 22)
        Me.EditPanel.TabIndex = 1
        '
        'txtValue
        '
        Me.txtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValue.Location = New System.Drawing.Point(0, 0)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(211, 20)
        Me.txtValue.TabIndex = 0
        '
        'CalcEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EditPanel)
        Me.Controls.Add(Me.PopupPanel)
        Me.Name = "CalcEdit"
        Me.Size = New System.Drawing.Size(238, 22)
        Me.PopupPanel.ResumeLayout(False)
        Me.EditPanel.ResumeLayout(False)
        Me.EditPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PopupPanel As System.Windows.Forms.Panel
    Friend WithEvents EditPanel As System.Windows.Forms.Panel
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cmdPopupCalc As System.Windows.Forms.Button

End Class
