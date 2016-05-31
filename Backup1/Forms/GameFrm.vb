Public Class GameFrm
    Inherits System.Windows.Forms.Form

#Region " Constants "
    Const kOffsetX As Integer = 6
    Const kOffsetY As Integer = 72
#End Region

#Region " Variables "
    Private m_StartTime As DateTime
    Private m_MiddleIsDown As Boolean
#End Region

#Region " Propertys "
    Public ReadOnly Property ScreenPtr() As IntPtr
        Get
            Return pbGameBoard.Handle
        End Get
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        g.GameFrm = Me
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
    Friend WithEvents pbGameBoard As System.Windows.Forms.PictureBox
    Friend WithEvents btnFace As System.Windows.Forms.Button
    Friend WithEvents lblMines As System.Windows.Forms.Label
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents pnlScores As System.Windows.Forms.Panel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GameFrm))
        Me.pbGameBoard = New System.Windows.Forms.PictureBox
        Me.pnlScores = New System.Windows.Forms.Panel
        Me.lblMines = New System.Windows.Forms.Label
        Me.btnFace = New System.Windows.Forms.Button
        Me.lblTimer = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.pnlScores.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbGameBoard
        '
        Me.pbGameBoard.BackColor = System.Drawing.Color.Black
        Me.pbGameBoard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbGameBoard.Location = New System.Drawing.Point(0, 48)
        Me.pbGameBoard.Name = "pbGameBoard"
        Me.pbGameBoard.Size = New System.Drawing.Size(320, 320)
        Me.pbGameBoard.TabIndex = 0
        Me.pbGameBoard.TabStop = False
        '
        'pnlScores
        '
        Me.pnlScores.Controls.Add(Me.lblMines)
        Me.pnlScores.Controls.Add(Me.btnFace)
        Me.pnlScores.Controls.Add(Me.lblTimer)
        Me.pnlScores.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlScores.Location = New System.Drawing.Point(0, 0)
        Me.pnlScores.Name = "pnlScores"
        Me.pnlScores.Size = New System.Drawing.Size(320, 48)
        Me.pnlScores.TabIndex = 1
        '
        'lblMines
        '
        Me.lblMines.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMines.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMines.Location = New System.Drawing.Point(4, 12)
        Me.lblMines.Name = "lblMines"
        Me.lblMines.Size = New System.Drawing.Size(118, 23)
        Me.lblMines.TabIndex = 1
        Me.lblMines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnFace
        '
        Me.btnFace.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFace.BackColor = System.Drawing.Color.White
        Me.btnFace.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFace.Location = New System.Drawing.Point(140, 4)
        Me.btnFace.Name = "btnFace"
        Me.btnFace.Size = New System.Drawing.Size(40, 40)
        Me.btnFace.TabIndex = 0
        '
        'lblTimer
        '
        Me.lblTimer.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.Location = New System.Drawing.Point(198, 12)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(118, 23)
        Me.lblTimer.TabIndex = 1
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GameFrm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 368)
        Me.Controls.Add(Me.pbGameBoard)
        Me.Controls.Add(Me.pnlScores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GameFrm"
        Me.Text = "My Sweeper"
        Me.pnlScores.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Events "
    Private Sub GameFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_MiddleIsDown = False
        AddHandler g.Engine.RestartingMap, AddressOf HandleReset
        AddHandler g.Engine.GameWon, AddressOf HandleWin
        AddHandler g.Engine.FinishedReseting, AddressOf AnimateReset
        AddHandler g.Engine.Resizing, AddressOf SetSize
    End Sub

    Private Sub GameFrm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not pbGameBoard.Image Is Nothing Then
            pbGameBoard.Image.Dispose()
            pbGameBoard.Image = Nothing
            Application.DoEvents()
        End If

        g.Engine.Render(True)
    End Sub

    Private Sub GameFrm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Dim theBmp As Bitmap = New Bitmap(pbGameBoard.Width, pbGameBoard.Height)
        g.Engine.Render(Graphics.FromImage(theBmp), True)
        pbGameBoard.Image = theBmp
    End Sub

    Private Sub GameFrm_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LocationChanged
        g.Engine.Render(True)
    End Sub

    Private Sub btnFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFace.Click
        g.Engine.InitMap(True)
    End Sub

    Private Sub pbGameBoard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbGameBoard.MouseDown
        If Not g.Engine.AcceptClicks Then Exit Sub

        If e.Button = MouseButtons.Left Then
            btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceMouseDown)
        ElseIf e.Button = MouseButtons.Middle Then
            m_MiddleIsDown = True
            btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceMouseDown)
            g.Engine.MiddleClickSquare((CInt(GameEngine.MakeEvenlyDivisible(e.X, Square.kSquareW) / Square.kSquareW) - 1), (CInt(GameEngine.MakeEvenlyDivisible(e.Y, Square.kSquareH) / Square.kSquareH) - 1))
            g.Engine.Render(False)
        End If
    End Sub

    Private Sub pbGameBoard_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbGameBoard.MouseUp
        If Not g.Engine.AcceptClicks Then Exit Sub

        Dim x As Integer = (CInt(GameEngine.MakeEvenlyDivisible(e.X, Square.kSquareW) / Square.kSquareW) - 1)
        Dim y As Integer = (CInt(GameEngine.MakeEvenlyDivisible(e.Y, Square.kSquareH) / Square.kSquareH) - 1)

        m_MiddleIsDown = False
        If g.Engine.UndoMiddleClick(New Point(x, y)) Then Exit Sub

        If g.Engine.IsInBounds(x, y) Then
            If e.Button = MouseButtons.Left Then
                If g.Engine.IsUnmarkedBomb(x, y) Then
                    btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceLost)
                Else
                    btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceNormal)
                End If
                g.Engine.LeftClickSquare(x, y)
            ElseIf e.Button = MouseButtons.Right Then
                btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceNormal)
                g.Engine.RightClickSquare(x, y)
            End If
        Else
            btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceNormal)
        End If

        g.Engine.Render(False)

        SetMineCount()
    End Sub

    Private Sub pbGameBoard_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbGameBoard.MouseMove
        If m_MiddleIsDown Then
            g.Engine.MiddleClickSquare((CInt(GameEngine.MakeEvenlyDivisible(e.X, Square.kSquareW) / Square.kSquareW) - 1), (CInt(GameEngine.MakeEvenlyDivisible(e.Y, Square.kSquareH) / Square.kSquareH) - 1))
            g.Engine.Render(False)
        End If
    End Sub
#End Region

#Region " Handlers "
    Private Sub AnimateReset()
        Dim theBmp As Bitmap = New Bitmap(pbGameBoard.Width, pbGameBoard.Height)

        g.Engine.Render(Graphics.FromImage(theBmp), True)

        Dim theGraphics As Graphics = Graphics.FromHwnd(pbGameBoard.Handle)
        Dim x As Integer = pbGameBoard.Width
        Dim y As Integer = pbGameBoard.Height
        Dim h As Integer = 0
        Dim w As Integer = 0

        Dim incX As Integer
        Dim incY As Integer

        If Not x = y Then
            incX = IIf(x > y, 4, 2)
            incY = IIf(x > y, 2, 4)
        Else
            incX = IIf(g.Engine.NumSquaresW > Square.kSquareW, 4, 1)
            incY = incX
        End If

        theGraphics.Clear(pbGameBoard.BackColor)
        While w <= pbGameBoard.Width
            theGraphics.DrawImage(theBmp, x, y, w, h)
            x -= incX
            y -= incY
            w += incX
            h += incY
            Application.DoEvents()
        End While

        theBmp.Dispose()
        theGraphics.Dispose()
    End Sub

    Private Sub HandleReset()
        btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceNormal)
        m_StartTime = DateTime.Now
        m_MiddleIsDown = False
    End Sub

    Private Sub HandleWin()
        btnFace.Image = g.Engine.GetBitmap(GameEngine.eGameImages.kFaceWin)

        If MsgBox("Would you like to save an image of this map?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveFileDialog1.Title = "Save current map image"
            SaveFileDialog1.DefaultExt = ".bmp"
            SaveFileDialog1.Filter = "*.bmp|.bmp"
            SaveFileDialog1.FileName = g.Engine.NumSquaresW & "x" & g.Engine.NumSquaresH & "(" & lblTimer.Text.Replace(":", "-") & ")"

            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                g.Engine.GetScreenShot(lblTimer.Text, lblTimer.Font).Save(SaveFileDialog1.FileName)
            End If
        End If
    End Sub
#End Region

#Region " Overrides "
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        If Not g.Engine Is Nothing Then g.Engine.GameOver = True
        RemoveHandler g.Engine.RestartingMap, AddressOf HandleReset
        RemoveHandler g.Engine.GameWon, AddressOf HandleWin
        RemoveHandler g.Engine.FinishedReseting, AddressOf AnimateReset
        RemoveHandler g.Engine.Resizing, AddressOf SetSize
    End Sub
#End Region

#Region " Subs "
    Public Sub AdjustTimer()
        Dim timeDif As TimeSpan = DateTime.Now.Subtract(m_StartTime)
        lblTimer.Text = timeDif.Hours & ":" & timeDif.Minutes & ":" & timeDif.Seconds
    End Sub

    Public Sub SetMineCount()
        Dim numMines As Integer = g.Engine.NumberOfMines
        Dim found As Integer = g.Engine.NumMinesFound
        Dim theColor As Color = Color.Green

        If found > numMines Then
            theColor = Color.Red
        ElseIf found = numMines Then
            theColor = Color.Blue
        End If

        lblMines.ForeColor = theColor
        lblMines.Text = found & "/" & numMines
    End Sub

    Public Sub SetSize(ByVal w As Integer, ByVal h As Integer)
        Me.Width = (w * Square.kSquareW) + kOffsetX
        Me.Height = (h * Square.kSquareH) + kOffsetY
        Me.CenterToScreen()
    End Sub
#End Region

End Class