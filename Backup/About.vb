Imports Snake.Form1
Public Class About
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(About))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(30, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 102)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Made By :"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Chocolate
        Me.Label7.Location = New System.Drawing.Point(12, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "INDIA"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Chocolate
        Me.Label6.Location = New System.Drawing.Point(12, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 18)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "GU,Ahmedabad-380015"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Chocolate
        Me.Label5.Location = New System.Drawing.Point(12, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "8th Sem,L.D. Engg"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Chocolate
        Me.Label4.Location = New System.Drawing.Point(12, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Atul M. Ojha"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Snake"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(30, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(114, 102)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(162, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Version 2"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(162, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 36)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Software Used :  .NET v 1.1 (VB.NET)"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'About
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.ClientSize = New System.Drawing.Size(342, 276)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "About"
        Me.Opacity = 0.01
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Me.Opacity = 100) Then
            Timer1.Stop()
        Else
            Me.Opacity = Me.Opacity + 0.04
        End If
    End Sub
    Private Sub About_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub GroupBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub Label7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.TopMost = False : Me.Dispose(True)
    End Sub
End Class
