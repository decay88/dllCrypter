Imports System.IO

Public Class dlgAskSize
    Inherits System.Windows.Forms.Form

#Region " Variables "
    Private m_W As Integer
    Private m_H As Integer
    Private m_Prc As Single
    Private m_ImagesFolder As String
#End Region

#Region " Propertys "
    Public ReadOnly Property FieldW() As Integer
        Get
            Return GameEngine.MakeEvenlyDivisible(m_W, Square.kSquareW)
        End Get
    End Property

    Public ReadOnly Property FieldH() As Integer
        Get
            Return GameEngine.MakeEvenlyDivisible(m_H, Square.kSquareH)
        End Get
    End Property

    Public ReadOnly Property MinesPrc() As Single
        Get
            Return m_Prc
        End Get
    End Property

    Public ReadOnly Property ImagesFolder() As String
        Get
            Return m_ImagesFolder
        End Get
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal w As Integer = -1, Optional ByVal h As Integer = -1, Optional ByVal prc As Single = -1.0, Optional ByVal folder As String = "")
        MyBase.New()
        Application.EnableVisualStyles()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_W = w
        m_H = h
        m_Prc = prc
        m_ImagesFolder = folder
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents tbW As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbH As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbPrc As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmboTilesets As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.tbW = New System.Windows.Forms.NumericUpDown
        Me.tbH = New System.Windows.Forms.NumericUpDown
        Me.tbPrc = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmboTilesets = New System.Windows.Forms.ComboBox
        CType(Me.tbW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPrc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Width:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Height:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "%Mines:"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(72, 104)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "OK"
        '
        'tbW
        '
        Me.tbW.Location = New System.Drawing.Point(56, 0)
        Me.tbW.Name = "tbW"
        Me.tbW.ReadOnly = True
        Me.tbW.Size = New System.Drawing.Size(160, 20)
        Me.tbW.TabIndex = 7
        '
        'tbH
        '
        Me.tbH.Location = New System.Drawing.Point(56, 24)
        Me.tbH.Name = "tbH"
        Me.tbH.ReadOnly = True
        Me.tbH.Size = New System.Drawing.Size(160, 20)
        Me.tbH.TabIndex = 7
        '
        'tbPrc
        '
        Me.tbPrc.DecimalPlaces = 2
        Me.tbPrc.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.tbPrc.Location = New System.Drawing.Point(56, 48)
        Me.tbPrc.Maximum = New Decimal(New Integer() {99, 0, 0, 131072})
        Me.tbPrc.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tbPrc.Name = "tbPrc"
        Me.tbPrc.ReadOnly = True
        Me.tbPrc.Size = New System.Drawing.Size(160, 20)
        Me.tbPrc.TabIndex = 7
        Me.tbPrc.Value = New Decimal(New Integer() {2, 0, 0, 65536})
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tileset:"
        '
        'cmboTilesets
        '
        Me.cmboTilesets.Location = New System.Drawing.Point(56, 72)
        Me.cmboTilesets.Name = "cmboTilesets"
        Me.cmboTilesets.Size = New System.Drawing.Size(160, 21)
        Me.cmboTilesets.TabIndex = 9
        '
        'dlgAskSize
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(218, 136)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmboTilesets)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbW)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbH)
        Me.Controls.Add(Me.tbPrc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgAskSize"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Map Size"
        CType(Me.tbW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPrc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Events "
    Private Sub dlgAskSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbW.Increment = Square.kSquareW
        tbW.Maximum = Square.kSquareW * 2
        tbW.Minimum = Square.kSquareW

        tbH.Increment = tbW.Increment
        tbH.Maximum = tbW.Maximum
        tbH.Minimum = tbW.Minimum

        Dim folders() As String = Directory.GetDirectories(GameEngine.kImagesPath)
        Dim count As Integer = folders.Length

        For i As Integer = 0 To count - 1
            Dim thePath As String = folders(i)
            folders(i) = thePath.Remove(0, thePath.LastIndexOf("\") + 1)
        Next i

        cmboTilesets.Items.AddRange(folders)

        If m_W > 0 Then tbW.Text = m_W
        If m_H > 0 Then tbH.Text = m_H
        If m_Prc > 0 Then tbPrc.Text = m_Prc

        If Not m_ImagesFolder = "" Then
            cmboTilesets.Text = m_ImagesFolder
        Else
            cmboTilesets.Text = cmboTilesets.Items(0)
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        m_W = CInt(tbW.Text)
        m_H = CInt(tbH.Text)
        m_Prc = CType(tbPrc.Text, Single)

        If cmboTilesets.Text = "" Then
            MsgBox("Please select a tileset!")
            cmboTilesets.Focus()
            Exit Sub
        End If

        m_ImagesFolder = cmboTilesets.Text
        Me.Close()
    End Sub
#End Region

End Class