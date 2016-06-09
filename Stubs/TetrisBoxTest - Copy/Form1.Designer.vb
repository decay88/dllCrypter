<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbxBackground = New System.Windows.Forms.GroupBox()
        Me.lnkBackgroundPicture = New System.Windows.Forms.LinkLabel()
        Me.radBackgroundPicture = New System.Windows.Forms.RadioButton()
        Me.cboGradientDirection = New System.Windows.Forms.ComboBox()
        Me.pnlBackgroundGradient2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlBackgroundGradient1 = New System.Windows.Forms.Panel()
        Me.radBackgroundGradient = New System.Windows.Forms.RadioButton()
        Me.pnlBackgroundSolid = New System.Windows.Forms.Panel()
        Me.radBackgroundSolid = New System.Windows.Forms.RadioButton()
        Me.dlgBackgroundPicture = New System.Windows.Forms.OpenFileDialog()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.gbxBoardSize = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numCellSize = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numColumns = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numRows = New System.Windows.Forms.NumericUpDown()
        Me.gbxBlockColors = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlBlock7Color = New System.Windows.Forms.Panel()
        Me.pnlBlock6Color = New System.Windows.Forms.Panel()
        Me.pnlBlock5Color = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlBlock4Color = New System.Windows.Forms.Panel()
        Me.pnlBlock3Color = New System.Windows.Forms.Panel()
        Me.pnlBlock2Color = New System.Windows.Forms.Panel()
        Me.pnlBlock1Color = New System.Windows.Forms.Panel()
        Me.gbxKeys = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboKeysDrop = New System.Windows.Forms.ComboBox()
        Me.cboKeysRotate = New System.Windows.Forms.ComboBox()
        Me.cboKeysRight = New System.Windows.Forms.ComboBox()
        Me.cboKeysLeft = New System.Windows.Forms.ComboBox()
        Me.gbxDifficulties = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pnlUncompleteLine = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.numUncompleteLine = New System.Windows.Forms.NumericUpDown()
        Me.chkUncompleteLine = New System.Windows.Forms.CheckBox()
        Me.pnlRandomBlock = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.numRandomBlock = New System.Windows.Forms.NumericUpDown()
        Me.chkRandomBlock = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbrSpeed = New System.Windows.Forms.TrackBar()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lstEvents = New System.Windows.Forms.ListBox()
        Me.TetrisBox1 = New TetrisBoxTest.TetrisBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lnkArticle = New System.Windows.Forms.LinkLabel()
        Me.gbxBackground.SuspendLayout()
        Me.gbxBoardSize.SuspendLayout()
        CType(Me.numCellSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxBlockColors.SuspendLayout()
        Me.gbxKeys.SuspendLayout()
        Me.gbxDifficulties.SuspendLayout()
        CType(Me.numUncompleteLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRandomBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.tbrSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.TetrisBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxBackground
        '
        Me.gbxBackground.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxBackground.Controls.Add(Me.lnkBackgroundPicture)
        Me.gbxBackground.Controls.Add(Me.radBackgroundPicture)
        Me.gbxBackground.Controls.Add(Me.cboGradientDirection)
        Me.gbxBackground.Controls.Add(Me.pnlBackgroundGradient2)
        Me.gbxBackground.Controls.Add(Me.Label1)
        Me.gbxBackground.Controls.Add(Me.pnlBackgroundGradient1)
        Me.gbxBackground.Controls.Add(Me.radBackgroundGradient)
        Me.gbxBackground.Controls.Add(Me.pnlBackgroundSolid)
        Me.gbxBackground.Controls.Add(Me.radBackgroundSolid)
        Me.gbxBackground.Location = New System.Drawing.Point(806, 12)
        Me.gbxBackground.Name = "gbxBackground"
        Me.gbxBackground.Size = New System.Drawing.Size(356, 99)
        Me.gbxBackground.TabIndex = 1
        Me.gbxBackground.TabStop = False
        Me.gbxBackground.Text = "Background"
        '
        'lnkBackgroundPicture
        '
        Me.lnkBackgroundPicture.AutoSize = True
        Me.lnkBackgroundPicture.Location = New System.Drawing.Point(90, 74)
        Me.lnkBackgroundPicture.Name = "lnkBackgroundPicture"
        Me.lnkBackgroundPicture.Size = New System.Drawing.Size(87, 15)
        Me.lnkBackgroundPicture.TabIndex = 8
        Me.lnkBackgroundPicture.TabStop = True
        Me.lnkBackgroundPicture.Text = "Select picture..."
        '
        'radBackgroundPicture
        '
        Me.radBackgroundPicture.AutoSize = True
        Me.radBackgroundPicture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.radBackgroundPicture.Location = New System.Drawing.Point(6, 72)
        Me.radBackgroundPicture.Name = "radBackgroundPicture"
        Me.radBackgroundPicture.Size = New System.Drawing.Size(62, 19)
        Me.radBackgroundPicture.TabIndex = 7
        Me.radBackgroundPicture.Text = "Picture"
        Me.radBackgroundPicture.UseVisualStyleBackColor = True
        '
        'cboGradientDirection
        '
        Me.cboGradientDirection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGradientDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGradientDirection.FormattingEnabled = True
        Me.cboGradientDirection.Items.AddRange(New Object() {"Horizontal", "Vertical", "ForwardDiagonal", "BackwardDiagonal"})
        Me.cboGradientDirection.Location = New System.Drawing.Point(195, 46)
        Me.cboGradientDirection.Name = "cboGradientDirection"
        Me.cboGradientDirection.Size = New System.Drawing.Size(155, 23)
        Me.cboGradientDirection.TabIndex = 6
        '
        'pnlBackgroundGradient2
        '
        Me.pnlBackgroundGradient2.BackColor = System.Drawing.Color.Black
        Me.pnlBackgroundGradient2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBackgroundGradient2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBackgroundGradient2.Location = New System.Drawing.Point(156, 47)
        Me.pnlBackgroundGradient2.Name = "pnlBackgroundGradient2"
        Me.pnlBackgroundGradient2.Size = New System.Drawing.Size(33, 19)
        Me.pnlBackgroundGradient2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "to"
        '
        'pnlBackgroundGradient1
        '
        Me.pnlBackgroundGradient1.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBackgroundGradient1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBackgroundGradient1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBackgroundGradient1.Location = New System.Drawing.Point(93, 47)
        Me.pnlBackgroundGradient1.Name = "pnlBackgroundGradient1"
        Me.pnlBackgroundGradient1.Size = New System.Drawing.Size(33, 19)
        Me.pnlBackgroundGradient1.TabIndex = 3
        '
        'radBackgroundGradient
        '
        Me.radBackgroundGradient.AutoSize = True
        Me.radBackgroundGradient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.radBackgroundGradient.Location = New System.Drawing.Point(6, 47)
        Me.radBackgroundGradient.Name = "radBackgroundGradient"
        Me.radBackgroundGradient.Size = New System.Drawing.Size(70, 19)
        Me.radBackgroundGradient.TabIndex = 2
        Me.radBackgroundGradient.Text = "Gradient"
        Me.radBackgroundGradient.UseVisualStyleBackColor = True
        '
        'pnlBackgroundSolid
        '
        Me.pnlBackgroundSolid.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBackgroundSolid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBackgroundSolid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBackgroundSolid.Location = New System.Drawing.Point(93, 22)
        Me.pnlBackgroundSolid.Name = "pnlBackgroundSolid"
        Me.pnlBackgroundSolid.Size = New System.Drawing.Size(33, 19)
        Me.pnlBackgroundSolid.TabIndex = 1
        '
        'radBackgroundSolid
        '
        Me.radBackgroundSolid.AutoSize = True
        Me.radBackgroundSolid.Checked = True
        Me.radBackgroundSolid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.radBackgroundSolid.Location = New System.Drawing.Point(6, 22)
        Me.radBackgroundSolid.Name = "radBackgroundSolid"
        Me.radBackgroundSolid.Size = New System.Drawing.Size(81, 19)
        Me.radBackgroundSolid.TabIndex = 0
        Me.radBackgroundSolid.TabStop = True
        Me.radBackgroundSolid.Text = "Solid color"
        Me.radBackgroundSolid.UseVisualStyleBackColor = True
        '
        'dlgBackgroundPicture
        '
        Me.dlgBackgroundPicture.Filter = "Picture files|*.jpg;*.png;*.gif;*.bmp"
        Me.dlgBackgroundPicture.Title = "Select background picture"
        '
        'gbxBoardSize
        '
        Me.gbxBoardSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxBoardSize.Controls.Add(Me.Label4)
        Me.gbxBoardSize.Controls.Add(Me.numCellSize)
        Me.gbxBoardSize.Controls.Add(Me.Label3)
        Me.gbxBoardSize.Controls.Add(Me.numColumns)
        Me.gbxBoardSize.Controls.Add(Me.Label2)
        Me.gbxBoardSize.Controls.Add(Me.numRows)
        Me.gbxBoardSize.Location = New System.Drawing.Point(806, 117)
        Me.gbxBoardSize.Name = "gbxBoardSize"
        Me.gbxBoardSize.Size = New System.Drawing.Size(356, 113)
        Me.gbxBoardSize.TabIndex = 2
        Me.gbxBoardSize.TabStop = False
        Me.gbxBoardSize.Text = "Board size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Cell size:"
        '
        'numCellSize
        '
        Me.numCellSize.Location = New System.Drawing.Point(93, 80)
        Me.numCellSize.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.numCellSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numCellSize.Name = "numCellSize"
        Me.numCellSize.Size = New System.Drawing.Size(96, 23)
        Me.numCellSize.TabIndex = 8
        Me.numCellSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCellSize.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Columns:"
        '
        'numColumns
        '
        Me.numColumns.Location = New System.Drawing.Point(93, 51)
        Me.numColumns.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numColumns.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.numColumns.Name = "numColumns"
        Me.numColumns.Size = New System.Drawing.Size(96, 23)
        Me.numColumns.TabIndex = 6
        Me.numColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numColumns.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Rows:"
        '
        'numRows
        '
        Me.numRows.Location = New System.Drawing.Point(93, 22)
        Me.numRows.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numRows.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numRows.Name = "numRows"
        Me.numRows.Size = New System.Drawing.Size(96, 23)
        Me.numRows.TabIndex = 0
        Me.numRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numRows.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'gbxBlockColors
        '
        Me.gbxBlockColors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxBlockColors.Controls.Add(Me.Label11)
        Me.gbxBlockColors.Controls.Add(Me.Label10)
        Me.gbxBlockColors.Controls.Add(Me.Label9)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock7Color)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock6Color)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock5Color)
        Me.gbxBlockColors.Controls.Add(Me.Label8)
        Me.gbxBlockColors.Controls.Add(Me.Label7)
        Me.gbxBlockColors.Controls.Add(Me.Label6)
        Me.gbxBlockColors.Controls.Add(Me.Label5)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock4Color)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock3Color)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock2Color)
        Me.gbxBlockColors.Controls.Add(Me.pnlBlock1Color)
        Me.gbxBlockColors.Location = New System.Drawing.Point(806, 236)
        Me.gbxBlockColors.Name = "gbxBlockColors"
        Me.gbxBlockColors.Size = New System.Drawing.Size(356, 128)
        Me.gbxBlockColors.TabIndex = 3
        Me.gbxBlockColors.TabStop = False
        Me.gbxBlockColors.Text = "Block colors"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(178, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 15)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Type 7 Block:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(178, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 15)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Type 6 Block:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(178, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Type 5 Block:"
        '
        'pnlBlock7Color
        '
        Me.pnlBlock7Color.BackColor = System.Drawing.Color.Purple
        Me.pnlBlock7Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock7Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock7Color.Location = New System.Drawing.Point(265, 72)
        Me.pnlBlock7Color.Name = "pnlBlock7Color"
        Me.pnlBlock7Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock7Color.TabIndex = 14
        '
        'pnlBlock6Color
        '
        Me.pnlBlock6Color.BackColor = System.Drawing.Color.Yellow
        Me.pnlBlock6Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock6Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock6Color.Location = New System.Drawing.Point(265, 47)
        Me.pnlBlock6Color.Name = "pnlBlock6Color"
        Me.pnlBlock6Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock6Color.TabIndex = 13
        '
        'pnlBlock5Color
        '
        Me.pnlBlock5Color.BackColor = System.Drawing.Color.Brown
        Me.pnlBlock5Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock5Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock5Color.Location = New System.Drawing.Point(265, 22)
        Me.pnlBlock5Color.Name = "pnlBlock5Color"
        Me.pnlBlock5Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock5Color.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Type 4 Block:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Type 3 Block:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Type 2 Block:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Type 1 Block:"
        '
        'pnlBlock4Color
        '
        Me.pnlBlock4Color.BackColor = System.Drawing.Color.Aqua
        Me.pnlBlock4Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock4Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock4Color.Location = New System.Drawing.Point(93, 97)
        Me.pnlBlock4Color.Name = "pnlBlock4Color"
        Me.pnlBlock4Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock4Color.TabIndex = 5
        '
        'pnlBlock3Color
        '
        Me.pnlBlock3Color.BackColor = System.Drawing.Color.Green
        Me.pnlBlock3Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock3Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock3Color.Location = New System.Drawing.Point(93, 72)
        Me.pnlBlock3Color.Name = "pnlBlock3Color"
        Me.pnlBlock3Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock3Color.TabIndex = 4
        '
        'pnlBlock2Color
        '
        Me.pnlBlock2Color.BackColor = System.Drawing.Color.Blue
        Me.pnlBlock2Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock2Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock2Color.Location = New System.Drawing.Point(93, 47)
        Me.pnlBlock2Color.Name = "pnlBlock2Color"
        Me.pnlBlock2Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock2Color.TabIndex = 3
        '
        'pnlBlock1Color
        '
        Me.pnlBlock1Color.BackColor = System.Drawing.Color.Red
        Me.pnlBlock1Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlock1Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlock1Color.Location = New System.Drawing.Point(93, 22)
        Me.pnlBlock1Color.Name = "pnlBlock1Color"
        Me.pnlBlock1Color.Size = New System.Drawing.Size(33, 19)
        Me.pnlBlock1Color.TabIndex = 2
        '
        'gbxKeys
        '
        Me.gbxKeys.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxKeys.Controls.Add(Me.Label15)
        Me.gbxKeys.Controls.Add(Me.Label14)
        Me.gbxKeys.Controls.Add(Me.Label13)
        Me.gbxKeys.Controls.Add(Me.Label12)
        Me.gbxKeys.Controls.Add(Me.cboKeysDrop)
        Me.gbxKeys.Controls.Add(Me.cboKeysRotate)
        Me.gbxKeys.Controls.Add(Me.cboKeysRight)
        Me.gbxKeys.Controls.Add(Me.cboKeysLeft)
        Me.gbxKeys.Location = New System.Drawing.Point(806, 370)
        Me.gbxKeys.Name = "gbxKeys"
        Me.gbxKeys.Size = New System.Drawing.Size(356, 85)
        Me.gbxKeys.TabIndex = 4
        Me.gbxKeys.TabStop = False
        Me.gbxKeys.Text = "Keys"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(190, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 15)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Drop:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(190, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 15)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Rotate:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 15)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Right:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 15)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Left:"
        '
        'cboKeysDrop
        '
        Me.cboKeysDrop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboKeysDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKeysDrop.FormattingEnabled = True
        Me.cboKeysDrop.Location = New System.Drawing.Point(240, 51)
        Me.cboKeysDrop.Name = "cboKeysDrop"
        Me.cboKeysDrop.Size = New System.Drawing.Size(110, 23)
        Me.cboKeysDrop.Sorted = True
        Me.cboKeysDrop.TabIndex = 10
        '
        'cboKeysRotate
        '
        Me.cboKeysRotate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboKeysRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKeysRotate.FormattingEnabled = True
        Me.cboKeysRotate.Location = New System.Drawing.Point(240, 22)
        Me.cboKeysRotate.Name = "cboKeysRotate"
        Me.cboKeysRotate.Size = New System.Drawing.Size(110, 23)
        Me.cboKeysRotate.Sorted = True
        Me.cboKeysRotate.TabIndex = 9
        '
        'cboKeysRight
        '
        Me.cboKeysRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboKeysRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKeysRight.FormattingEnabled = True
        Me.cboKeysRight.Location = New System.Drawing.Point(50, 51)
        Me.cboKeysRight.Name = "cboKeysRight"
        Me.cboKeysRight.Size = New System.Drawing.Size(110, 23)
        Me.cboKeysRight.Sorted = True
        Me.cboKeysRight.TabIndex = 8
        '
        'cboKeysLeft
        '
        Me.cboKeysLeft.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboKeysLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKeysLeft.FormattingEnabled = True
        Me.cboKeysLeft.Location = New System.Drawing.Point(50, 22)
        Me.cboKeysLeft.Name = "cboKeysLeft"
        Me.cboKeysLeft.Size = New System.Drawing.Size(110, 23)
        Me.cboKeysLeft.Sorted = True
        Me.cboKeysLeft.TabIndex = 7
        '
        'gbxDifficulties
        '
        Me.gbxDifficulties.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxDifficulties.Controls.Add(Me.Label19)
        Me.gbxDifficulties.Controls.Add(Me.pnlUncompleteLine)
        Me.gbxDifficulties.Controls.Add(Me.Label18)
        Me.gbxDifficulties.Controls.Add(Me.numUncompleteLine)
        Me.gbxDifficulties.Controls.Add(Me.chkUncompleteLine)
        Me.gbxDifficulties.Controls.Add(Me.pnlRandomBlock)
        Me.gbxDifficulties.Controls.Add(Me.Label17)
        Me.gbxDifficulties.Controls.Add(Me.Label16)
        Me.gbxDifficulties.Controls.Add(Me.numRandomBlock)
        Me.gbxDifficulties.Controls.Add(Me.chkRandomBlock)
        Me.gbxDifficulties.Location = New System.Drawing.Point(806, 461)
        Me.gbxDifficulties.Name = "gbxDifficulties"
        Me.gbxDifficulties.Size = New System.Drawing.Size(356, 127)
        Me.gbxDifficulties.TabIndex = 5
        Me.gbxDifficulties.TabStop = False
        Me.gbxDifficulties.Text = "Difficulties"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(23, 100)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 15)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Uncomplete lines color:"
        '
        'pnlUncompleteLine
        '
        Me.pnlUncompleteLine.BackColor = System.Drawing.Color.Orange
        Me.pnlUncompleteLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUncompleteLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlUncompleteLine.Location = New System.Drawing.Point(156, 98)
        Me.pnlUncompleteLine.Name = "pnlUncompleteLine"
        Me.pnlUncompleteLine.Size = New System.Drawing.Size(33, 19)
        Me.pnlUncompleteLine.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(247, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 15)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "new blocks"
        '
        'numUncompleteLine
        '
        Me.numUncompleteLine.Location = New System.Drawing.Point(196, 72)
        Me.numUncompleteLine.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numUncompleteLine.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numUncompleteLine.Name = "numUncompleteLine"
        Me.numUncompleteLine.Size = New System.Drawing.Size(45, 23)
        Me.numUncompleteLine.TabIndex = 16
        Me.numUncompleteLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numUncompleteLine.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'chkUncompleteLine
        '
        Me.chkUncompleteLine.AutoSize = True
        Me.chkUncompleteLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkUncompleteLine.Location = New System.Drawing.Point(6, 73)
        Me.chkUncompleteLine.Name = "chkUncompleteLine"
        Me.chkUncompleteLine.Size = New System.Drawing.Size(184, 19)
        Me.chkUncompleteLine.TabIndex = 15
        Me.chkUncompleteLine.Text = "Add an uncomplete line every"
        Me.chkUncompleteLine.UseVisualStyleBackColor = True
        '
        'pnlRandomBlock
        '
        Me.pnlRandomBlock.BackColor = System.Drawing.Color.Orange
        Me.pnlRandomBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRandomBlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlRandomBlock.Location = New System.Drawing.Point(156, 48)
        Me.pnlRandomBlock.Name = "pnlRandomBlock"
        Me.pnlRandomBlock.Size = New System.Drawing.Size(33, 19)
        Me.pnlRandomBlock.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(23, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 15)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Random blocks color:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(285, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 15)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "new blocks"
        '
        'numRandomBlock
        '
        Me.numRandomBlock.Location = New System.Drawing.Point(234, 22)
        Me.numRandomBlock.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numRandomBlock.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numRandomBlock.Name = "numRandomBlock"
        Me.numRandomBlock.Size = New System.Drawing.Size(45, 23)
        Me.numRandomBlock.TabIndex = 1
        Me.numRandomBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numRandomBlock.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'chkRandomBlock
        '
        Me.chkRandomBlock.AutoSize = True
        Me.chkRandomBlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRandomBlock.Location = New System.Drawing.Point(6, 23)
        Me.chkRandomBlock.Name = "chkRandomBlock"
        Me.chkRandomBlock.Size = New System.Drawing.Size(222, 19)
        Me.chkRandomBlock.TabIndex = 0
        Me.chkRandomBlock.Text = "Add a random single-cell block every"
        Me.chkRandomBlock.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.tbrSpeed)
        Me.GroupBox6.Controls.Add(Me.btnResume)
        Me.GroupBox6.Controls.Add(Me.btnPause)
        Me.GroupBox6.Controls.Add(Me.btnStop)
        Me.GroupBox6.Controls.Add(Me.btnStart)
        Me.GroupBox6.Location = New System.Drawing.Point(540, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(260, 162)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Game control"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 141)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 15)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Faster"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(210, 141)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 15)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Slower"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 15)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Game speed"
        '
        'tbrSpeed
        '
        Me.tbrSpeed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbrSpeed.Location = New System.Drawing.Point(6, 111)
        Me.tbrSpeed.Maximum = 1000
        Me.tbrSpeed.Minimum = 100
        Me.tbrSpeed.Name = "tbrSpeed"
        Me.tbrSpeed.Size = New System.Drawing.Size(253, 45)
        Me.tbrSpeed.TabIndex = 4
        Me.tbrSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbrSpeed.Value = 1000
        '
        'btnResume
        '
        Me.btnResume.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResume.Enabled = False
        Me.btnResume.Location = New System.Drawing.Point(137, 55)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(115, 27)
        Me.btnResume.TabIndex = 3
        Me.btnResume.Text = "Resume"
        Me.btnResume.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPause.Enabled = False
        Me.btnPause.Location = New System.Drawing.Point(6, 55)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(117, 27)
        Me.btnPause.TabIndex = 2
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(137, 22)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(117, 27)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.Location = New System.Drawing.Point(6, 22)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(117, 27)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.lstEvents)
        Me.GroupBox7.Location = New System.Drawing.Point(540, 180)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(260, 408)
        Me.GroupBox7.TabIndex = 7
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Events"
        '
        'lstEvents
        '
        Me.lstEvents.FormattingEnabled = True
        Me.lstEvents.ItemHeight = 15
        Me.lstEvents.Location = New System.Drawing.Point(9, 22)
        Me.lstEvents.Name = "lstEvents"
        Me.lstEvents.Size = New System.Drawing.Size(245, 379)
        Me.lstEvents.TabIndex = 0
        '
        'TetrisBox1
        '
        Me.TetrisBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.TetrisBox1.BackgroundStyle = TetrisBoxTest.TetrisBox.BackgroundStyles.SolidColor
        Me.TetrisBox1.Block1Color = System.Drawing.Color.Red
        Me.TetrisBox1.Block2Color = System.Drawing.Color.Blue
        Me.TetrisBox1.Block3Color = System.Drawing.Color.Green
        Me.TetrisBox1.Block4Color = System.Drawing.Color.Aqua
        Me.TetrisBox1.Block5Color = System.Drawing.Color.Brown
        Me.TetrisBox1.Block6Color = System.Drawing.Color.Yellow
        Me.TetrisBox1.Block7Color = System.Drawing.Color.Purple
        Me.TetrisBox1.CellSize = 25
        Me.TetrisBox1.Columns = 10
        Me.TetrisBox1.DropKey = System.Windows.Forms.Keys.Down
        Me.TetrisBox1.GradientColor1 = System.Drawing.Color.SteelBlue
        Me.TetrisBox1.GradientColor2 = System.Drawing.Color.Black
        Me.TetrisBox1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.TetrisBox1.LeftKey = System.Windows.Forms.Keys.Left
        Me.TetrisBox1.Location = New System.Drawing.Point(12, 12)
        Me.TetrisBox1.Name = "TetrisBox1"
        Me.TetrisBox1.RandomBlockColor = System.Drawing.Color.Orange
        Me.TetrisBox1.RightKey = System.Windows.Forms.Keys.Right
        Me.TetrisBox1.RotateKey = System.Windows.Forms.Keys.Up
        Me.TetrisBox1.Rows = 20
        Me.TetrisBox1.Size = New System.Drawing.Size(241, 481)
        Me.TetrisBox1.TabIndex = 0
        Me.TetrisBox1.TabStop = False
        Me.TetrisBox1.TimerInterval = 1000
        Me.TetrisBox1.UncompleteRowColor = System.Drawing.Color.Orange
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(537, 603)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(126, 15)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "If you liked this, please"
        '
        'lnkArticle
        '
        Me.lnkArticle.AutoSize = True
        Me.lnkArticle.Location = New System.Drawing.Point(661, 603)
        Me.lnkArticle.Name = "lnkArticle"
        Me.lnkArticle.Size = New System.Drawing.Size(142, 15)
        Me.lnkArticle.TabIndex = 9
        Me.lnkArticle.TabStop = True
        Me.lnkArticle.Text = "vote my article as helpful."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 865)
        Me.Controls.Add(Me.lnkArticle)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.gbxDifficulties)
        Me.Controls.Add(Me.gbxKeys)
        Me.Controls.Add(Me.gbxBlockColors)
        Me.Controls.Add(Me.gbxBoardSize)
        Me.Controls.Add(Me.gbxBackground)
        Me.Controls.Add(Me.TetrisBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "TetrisBox Test"
        Me.gbxBackground.ResumeLayout(False)
        Me.gbxBackground.PerformLayout()
        Me.gbxBoardSize.ResumeLayout(False)
        Me.gbxBoardSize.PerformLayout()
        CType(Me.numCellSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxBlockColors.ResumeLayout(False)
        Me.gbxBlockColors.PerformLayout()
        Me.gbxKeys.ResumeLayout(False)
        Me.gbxKeys.PerformLayout()
        Me.gbxDifficulties.ResumeLayout(False)
        Me.gbxDifficulties.PerformLayout()
        CType(Me.numUncompleteLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRandomBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.tbrSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.TetrisBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TetrisBox1 As TetrisBoxTest.TetrisBox
    Friend WithEvents gbxBackground As System.Windows.Forms.GroupBox
    Friend WithEvents radBackgroundSolid As System.Windows.Forms.RadioButton
    Friend WithEvents lnkBackgroundPicture As System.Windows.Forms.LinkLabel
    Friend WithEvents radBackgroundPicture As System.Windows.Forms.RadioButton
    Friend WithEvents cboGradientDirection As System.Windows.Forms.ComboBox
    Friend WithEvents pnlBackgroundGradient2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlBackgroundGradient1 As System.Windows.Forms.Panel
    Friend WithEvents radBackgroundGradient As System.Windows.Forms.RadioButton
    Friend WithEvents pnlBackgroundSolid As System.Windows.Forms.Panel
    Friend WithEvents dlgBackgroundPicture As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents gbxBoardSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numCellSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numColumns As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numRows As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbxBlockColors As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlBlock7Color As System.Windows.Forms.Panel
    Friend WithEvents pnlBlock6Color As System.Windows.Forms.Panel
    Friend WithEvents pnlBlock5Color As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlBlock4Color As System.Windows.Forms.Panel
    Friend WithEvents pnlBlock3Color As System.Windows.Forms.Panel
    Friend WithEvents pnlBlock2Color As System.Windows.Forms.Panel
    Friend WithEvents pnlBlock1Color As System.Windows.Forms.Panel
    Friend WithEvents gbxKeys As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboKeysDrop As System.Windows.Forms.ComboBox
    Friend WithEvents cboKeysRotate As System.Windows.Forms.ComboBox
    Friend WithEvents cboKeysRight As System.Windows.Forms.ComboBox
    Friend WithEvents cboKeysLeft As System.Windows.Forms.ComboBox
    Friend WithEvents gbxDifficulties As System.Windows.Forms.GroupBox
    Friend WithEvents numRandomBlock As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkRandomBlock As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnlRandomBlock As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents numUncompleteLine As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkUncompleteLine As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents pnlUncompleteLine As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnResume As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbrSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lstEvents As System.Windows.Forms.ListBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lnkArticle As System.Windows.Forms.LinkLabel

End Class
