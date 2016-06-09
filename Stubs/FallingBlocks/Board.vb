'Program: FallingBlocks
'ProgramCopyright: 2007 Thomas Stockwell
'Programmer: Thomas Stockwell
'Date: February 7, 2008
'License: The Code Project Open Source License (CPOL).  Any directvariations of this code
'    needs to reference the author Thomas Stockwell
Imports System.Collections.ObjectModel
Imports System.Drawing.Drawing2D
Public Class Board

    Friend boardPieces As New Collection(Of Shape)
    Dim currentPieceIndex As Integer = -1
    Dim randPieceGen As New Random
    Dim paused As Boolean = False
    Dim score, level As Integer
    Dim _nextPiece As ShapeType = ShapeType.null
    Public Event ScoreChange As EventHandler
    Public Event LevelChange As EventHandler
    Public Event GameOver As EventHandler

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub Me_GameOver(ByVal sender As Object, ByVal e As EventArgs) Handles Me.GameOver
        Me.tmrMove.Enabled = False
        Me.tmrIncreaseTmr.Enabled = False
    End Sub

#Region "Public Methods"
    Public Sub NewGame()
        boardPieces = New Collection(Of Shape)
        Me.tmrMove.Enabled = True
        Me.tmrMove.Interval = 500
        Me.tmrIncreaseTmr.Enabled = True
        level = 1
        score = 0
        _nextPiece = ShapeType.null
        RaiseEvent LevelChange(Me, New EventArgs())
        RaiseEvent ScoreChange(Me, New EventArgs())
        currentPieceIndex = -1
        Me.Invalidate()
    End Sub
    Public Sub Reset()
        Me.tmrMove.Enabled = False
        Me.tmrMove.Interval = 500
        Me.tmrIncreaseTmr.Enabled = False
        level = 1
        score = 0
        _nextPiece = ShapeType.null
        RaiseEvent LevelChange(Me, New EventArgs())
        RaiseEvent ScoreChange(Me, New EventArgs())
        boardPieces = New Collection(Of Shape)
        currentPieceIndex = -1
        Me.Invalidate()
    End Sub

#End Region

#Region "Private Event Routines"
    Private Sub Board_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        For x As Integer = 0 To 9
            For y As Integer = 0 To 19
                e.Graphics.DrawRectangle(Pens.Black, x * 20, y * 20, 20, 20)
            Next
        Next
        For Each shp As Shape In boardPieces
            For Each pnt As Point In shp.Points
                e.Graphics.FillRectangle(New LinearGradientBrush(New Rectangle(0, 0, 19, 19), shp.Color, ControlPaint.Light(shp.Color), LinearGradientMode.BackwardDiagonal), (9 - (9 - pnt.X)) * 20 + 1, (19 - pnt.Y) * 20 + 1, 19, 19)
                'e.Graphics.DrawRectangle(New Pen(New SolidBrush(shp.Color), 1), (9 - (9 - pnt.X)) * 20 + 1, (19 - pnt.Y) * 20 + 1, 19, 19)
            Next
        Next
    End Sub

    Private Sub tmrIncreaseTmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrIncreaseTmr.Tick
        If (Me.tmrMove.Interval >= 21) Then
            Me.tmrMove.Interval = Me.tmrMove.Interval - 20
            level += 1
            RaiseEvent LevelChange(Me, New EventArgs())
        End If
    End Sub

#Region "Timer"
    Private Sub tmrMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMove.Tick
        If (paused) Then
            Return
        End If
        If (currentPieceIndex = -1) Then
            'initially create a piece
            Dim randVal As Integer = randPieceGen.Next(0, 7)
            Dim shp As Shape
            Select Case randVal
                Case 0
                    shp = New Shape(ShapeType.line)
                Case 1
                    shp = New Shape(ShapeType.lshapeLeft)
                Case 2
                    shp = New Shape(ShapeType.lshapeRight)
                Case 3
                    shp = New Shape(ShapeType.pyramid)
                Case 4
                    shp = New Shape(ShapeType.square)
                Case 5
                    shp = New Shape(ShapeType.staircaseLeft)
                Case Else
                    shp = New Shape(ShapeType.staircaseRight)
            End Select
            'set the nextPiece property
            randVal = randPieceGen.Next(0, 7)
            Select Case randVal
                Case 0
                    _nextPiece = ShapeType.line
                Case 1
                    _nextPiece = ShapeType.lshapeLeft
                Case 2
                    _nextPiece = ShapeType.lshapeRight
                Case 3
                    _nextPiece = ShapeType.pyramid
                Case 4
                    _nextPiece = ShapeType.square
                Case 5
                    _nextPiece = ShapeType.staircaseLeft
                Case Else
                    _nextPiece = ShapeType.staircaseRight
            End Select

            boardPieces.Add(shp)
            currentPieceIndex = boardPieces.IndexOf(shp)
        ElseIf (boardPieces(currentPieceIndex).IsFrozen) Then
            'if frozen then create a new piece
            Dim randVal As Integer = randPieceGen.Next(0, 7)
            Dim shp As Shape = New Shape(_nextPiece)

            randVal = randPieceGen.Next(0, 7)
            Select Case randVal
                Case 0
                    _nextPiece = ShapeType.line
                Case 1
                    _nextPiece = ShapeType.lshapeLeft
                Case 2
                    _nextPiece = ShapeType.lshapeRight
                Case 3
                    _nextPiece = ShapeType.pyramid
                Case 4
                    _nextPiece = ShapeType.square
                Case 5
                    _nextPiece = ShapeType.staircaseLeft
                Case Else
                    _nextPiece = ShapeType.staircaseRight
            End Select

            For Each shap As Shape In boardPieces
                If (shp.WillCollide(shap, NewDirection.down)) Then
                    Me.tmrMove.Enabled = False
                    RaiseEvent GameOver(Me, New EventArgs())
                    Return
                End If
            Next
            boardPieces.Add(shp)
            currentPieceIndex = boardPieces.IndexOf(shp)
        Else
            'this is the overall movement and scoring along with the arrow key methods
            Dim boolCollision As Boolean = False
            boolCollision = boardPieces(currentPieceIndex).WillCollide(NewDirection.down)
            For Each shp As Shape In boardPieces
                If (Not shp Is boardPieces(currentPieceIndex)) Then
                    If (Not boolCollision) Then
                        boolCollision = boardPieces(currentPieceIndex).WillCollide(shp, NewDirection.down)
                    End If
                End If
            Next
            If (Not boolCollision) Then
                boardPieces(currentPieceIndex).MoveDown()
                score = score + 5 * level
                RaiseEvent ScoreChange(Me, New EventArgs())
            Else
                boardPieces(currentPieceIndex).IsFrozen = True
                ManageCompleteLines()
            End If
        End If
        Me.Invalidate()
    End Sub
#End Region

#End Region

#Region "Properties"
    Public ReadOnly Property NextPiece() As ShapeType
        Get
            Return _nextPiece
        End Get
    End Property
    Public ReadOnly Property CurrentScore() As Integer
        Get
            Return score
        End Get
    End Property
    Public ReadOnly Property CurrentLevel() As Integer
        Get
            Return level
        End Get
    End Property
    Public Property IsPaused() As Boolean
        Get
            Return paused
        End Get
        Set(ByVal value As Boolean)
            If (value) Then
                Me.tmrMove.Enabled = False
                Me.tmrIncreaseTmr.Enabled = False
                Me.Label1.Visible = True
                paused = value
            Else
                If Not (currentPieceIndex = -1) Then
                    Me.tmrMove.Enabled = True
                    Me.tmrIncreaseTmr.Enabled = True
                End If
                Me.Label1.Visible = False
                paused = value
            End If
        End Set
    End Property

#End Region

#Region "Private Methods"
    Private Sub ManageCompleteLines()
        Dim counter(20) As Integer
        'instantiate everything
        For i As Integer = 0 To 19
            counter(i) = 0
        Next
        'get lines completed
        For Each shp As Shape In boardPieces
            For Each pnt As Point In shp.Points
                counter(pnt.Y) = counter(pnt.Y) + 1
            Next
        Next
        'score for every completed line
        Dim lineCount As Integer = 0
        For Each i As Integer In counter
            If (counter(i) = 10) Then
                lineCount += 1
            End If
        Next
        score = score + (20 * level * lineCount)
        RaiseEvent ScoreChange(Me, New EventArgs())

        'for all completed lines remove points
        For i As Integer = 0 To 19
            If (counter(i) = 10) Then
                Dim shapes As New Collection(Of Shape)
                For Each shp As Shape In boardPieces
                    If (shp.IsFrozen) Then
                        'collect all points then remove them
                        Dim pntsToRemove As New Collection(Of Point)
                        For Ipnt As Integer = 0 To shp.Points.Count - 1
                            If (shp.Points(Ipnt).Y = i) Then
                                pntsToRemove.Add(shp.Points(Ipnt))
                            End If
                        Next
                        For Each pnt As Point In pntsToRemove
                            shp.RemovePoint(pnt)
                        Next
                    End If
                Next
            End If
        Next
        'move lines down by moving only the points of the objects
        For i As Integer = 19 To 0 Step -1
            If (counter(i) = 10) Then
                For Each shp As Shape In boardPieces
                    Dim moveDown As Boolean = False
                    Dim pointsToMove As New Collection(Of Point)
                    For Each pnt As Point In shp.Points
                        If (pnt.Y > i) Then
                            pointsToMove.Add(pnt)
                        End If
                    Next
                    For Each pnt As Point In pointsToMove
                        shp.MovePointDown(pnt)
                    Next
                    'If (moveDown And shp.WillCollide(NewDirection.down) = False) Then
                    '    shp.MoveDown()
                    'End If
                    shp.IsFrozen = True
                Next
            End If
        Next
        'if the board is completely cleared add bonus points
        If (boardPieces.Count = 0) Then
            score = score + 1000 * level
        End If
    End Sub

#End Region

#Region "Move Events"
    Public Sub MoveLeft()
        If (paused Or currentPieceIndex = -1 Or boardPieces(currentPieceIndex).IsFrozen) Then
            Return
        End If
        Dim boolCollision As Boolean = False
        boolCollision = boardPieces(currentPieceIndex).WillCollide(NewDirection.left)
        For Each shp As Shape In boardPieces
            If (Not shp Is boardPieces(currentPieceIndex)) Then
                If (Not boolCollision) Then
                    boolCollision = boardPieces(currentPieceIndex).WillCollide(shp, NewDirection.left)
                End If
            End If
        Next
        If (Not boolCollision) Then
            boardPieces(currentPieceIndex).MoveLeft()
            'Else - frozen is not determined by left right movement
            '    boardPieces(currentPieceIndex).IsFrozen = True
            If (Not boardPieces(currentPieceIndex).WillCollide(NewDirection.down)) Then
                'this fixes a bug where it freezes in mid air if move during timer event
                boardPieces(currentPieceIndex).IsFrozen = False
            End If
        End If
        Me.Invalidate()
    End Sub
    Public Sub MoveRight()
        If (paused Or currentPieceIndex = -1 Or boardPieces(currentPieceIndex).IsFrozen) Then
            Return
        End If
        Dim boolCollision As Boolean = False
        boolCollision = boardPieces(currentPieceIndex).WillCollide(NewDirection.right)
        For Each shp As Shape In boardPieces
            If (Not shp Is boardPieces(currentPieceIndex)) Then
                If (Not boolCollision) Then
                    boolCollision = boardPieces(currentPieceIndex).WillCollide(shp, NewDirection.right)
                End If
            End If
        Next
        If (Not boolCollision) Then
            boardPieces(currentPieceIndex).MoveRight()
            'Else - frozen is not determined by left right movement
            '    boardPieces(currentPieceIndex).IsFrozen = True
            If (Not boardPieces(currentPieceIndex).WillCollide(NewDirection.down)) Then
                'this fixes a bug where it freezes in mid air if move during timer event
                boardPieces(currentPieceIndex).IsFrozen = False
            End If
        End If
        Me.Invalidate()
    End Sub
    Public Sub MoveDown()
        If (paused Or currentPieceIndex = -1 Or boardPieces(currentPieceIndex).IsFrozen) Then
            Return
        End If
        Me.tmrMove_Tick(Me, New EventArgs())
        Me.Invalidate()
    End Sub
    Public Sub ToggleOrientation()
        If (paused Or currentPieceIndex = -1 Or boardPieces(currentPieceIndex).IsFrozen) Then
            Return
        End If
        Dim boolCollision As Boolean = False
        boolCollision = boardPieces(currentPieceIndex).WillCollide(NewDirection.toggleOrientation)
        For Each shp As Shape In boardPieces
            If (Not shp Is boardPieces(currentPieceIndex)) Then
                If (Not boolCollision) Then
                    boolCollision = boardPieces(currentPieceIndex).WillCollide(shp, NewDirection.toggleOrientation)
                End If
            End If
        Next
        If (Not boolCollision) Then
            boardPieces(currentPieceIndex).ToggleOrientation()
            'Else - frozen is not determined by left right movement
            '    boardPieces(currentPieceIndex).IsFrozen = True
            If (Not boardPieces(currentPieceIndex).WillCollide(NewDirection.down)) Then
                'this fixes a bug where it freezes in mid air if move during timer event
                boardPieces(currentPieceIndex).IsFrozen = False
            End If
        End If
        Me.Invalidate()
    End Sub

#End Region

#Region "Shape Class"
    Public Class Shape
        Private gridLocations As New Collection(Of Point)
        Private shapeType As ShapeType
        Private boolIsFrozen As Boolean

#Region "New"
        Public Sub New(ByVal shape As ShapeType)
            shapeType = shape
            Select Case shape
                'toggle must be in the third position
                Case FallingBlocks.ShapeType.line
                    gridLocations.Add(New Point(5, 19))
                    gridLocations.Add(New Point(5, 18))
                    gridLocations.Add(New Point(5, 17)) 'toggle
                    gridLocations.Add(New Point(5, 16))
                Case FallingBlocks.ShapeType.lshapeLeft
                    gridLocations.Add(New Point(5, 19))
                    gridLocations.Add(New Point(5, 18))
                    gridLocations.Add(New Point(5, 17)) 'toggle
                    gridLocations.Add(New Point(4, 17))
                Case FallingBlocks.ShapeType.lshapeRight
                    gridLocations.Add(New Point(5, 19))
                    gridLocations.Add(New Point(5, 18))
                    gridLocations.Add(New Point(5, 17)) 'toggle
                    gridLocations.Add(New Point(6, 17))
                Case FallingBlocks.ShapeType.pyramid
                    gridLocations.Add(New Point(5, 19)) 'fist will be the primary side
                    gridLocations.Add(New Point(4, 18))
                    gridLocations.Add(New Point(5, 18)) 'toggle
                    gridLocations.Add(New Point(6, 18))
                Case FallingBlocks.ShapeType.square
                    gridLocations.Add(New Point(5, 19))
                    gridLocations.Add(New Point(5, 18))
                    gridLocations.Add(New Point(4, 19)) 'toggle
                    gridLocations.Add(New Point(4, 18))
                Case FallingBlocks.ShapeType.staircaseLeft
                    gridLocations.Add(New Point(5, 19))
                    gridLocations.Add(New Point(4, 19))
                    gridLocations.Add(New Point(5, 18)) 'toggle
                    gridLocations.Add(New Point(6, 18))
                Case FallingBlocks.ShapeType.staircaseRight
                    gridLocations.Add(New Point(5, 19))
                    gridLocations.Add(New Point(6, 19))
                    gridLocations.Add(New Point(5, 18)) 'toggle
                    gridLocations.Add(New Point(4, 18))
            End Select
        End Sub

#End Region

#Region "WillCollide"
        Public Function WillCollide(ByVal shape As Shape, ByVal direction As NewDirection) As Boolean
            Dim pntsToCheck As Collection(Of Point) = GetNewPoints(direction)
            For Each pnt As Point In shape.Points
                For Each pnts As Point In pntsToCheck
                    If (pnt.Equals(pnts)) Then
                        Return True
                    End If
                Next
            Next
        End Function
        Public Function WillCollide(ByVal direction As NewDirection) As Boolean
            Dim pntsToCheck As Collection(Of Point) = GetNewPoints(direction)
            For Each pnt As Point In pntsToCheck
                If (pnt.X < 0 Or pnt.X > 9 Or pnt.Y > 19 Or pnt.Y < 0) Then
                    Return True
                End If
            Next
        End Function

#End Region

        'all of the following functions will return a boolean as to whether the function was successful
        'willcollide must be called before these methods can be called
        Public Function MoveLeft() As Boolean
            Me.gridLocations = GetNewPoints(NewDirection.left)
        End Function
        Public Function MoveRight() As Boolean
            Me.gridLocations = GetNewPoints(NewDirection.right)
        End Function
        Public Function MoveDown() As Boolean
            Me.gridLocations = GetNewPoints(NewDirection.down)
        End Function
        Public Function ToggleOrientation() As Boolean
            Me.gridLocations = GetNewPoints(NewDirection.toggleOrientation)
        End Function

#Region "GetNewPoints"
        Private Function GetNewPoints(ByVal direction As NewDirection) As Collection(Of Point)
            Dim rval As New Collection(Of Point)
            Select Case direction
                Case NewDirection.current
                    Return Me.Points
                Case NewDirection.down
                    For Each pnt As Point In Me.Points
                        rval.Add(New Point(pnt.X, pnt.Y - 1))
                    Next
                Case NewDirection.left
                    For Each pnt As Point In Me.Points
                        rval.Add(New Point(pnt.X - 1, pnt.Y))
                    Next
                Case NewDirection.right
                    For Each pnt As Point In Me.Points
                        rval.Add(New Point(pnt.X + 1, pnt.Y))
                    Next
                Case NewDirection.toggleOrientation
                    Select Case shapeType
                        Case FallingBlocks.ShapeType.line
                            'toggle point is 3rd cube
                            Dim x, y As Integer
                            x = Points(2).X
                            y = Points(2).Y
                            If (Points(0).X = x) Then
                                'the line is vertical and needs to switch to horizontal
                                rval.Add(New Point(x - 2, y))
                                rval.Add(New Point(x - 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x + 1, y))
                            Else
                                'the line is horizontal and needs to switch to vertical
                                rval.Add(New Point(x, y - 2))
                                rval.Add(New Point(x, y - 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y + 1))
                            End If
                        Case FallingBlocks.ShapeType.lshapeLeft
                            'toggle point is 3rd cube
                            Dim x, y As Integer
                            x = Points(2).X
                            y = Points(2).Y
                            'find the farrest point from center
                            If (Points(0).X = Points(3).X - 2) Then 'pointing left switch to up
                                rval.Add(New Point(x, y + 2))
                                rval.Add(New Point(x, y + 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x - 1, y))
                            ElseIf (Points(0).Y = Points(3).Y + 2) Then 'pointing up switch to right
                                rval.Add(New Point(x + 2, y))
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y + 1))
                            ElseIf (Points(0).X = Points(3).X + 2) Then 'pointing right switch to down
                                rval.Add(New Point(x, y - 2))
                                rval.Add(New Point(x, y - 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x + 1, y))
                            ElseIf (Points(0).Y = Points(3).Y - 2) Then 'pointing down switch to left
                                rval.Add(New Point(x - 2, y))
                                rval.Add(New Point(x - 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y - 1))
                            End If
                        Case FallingBlocks.ShapeType.lshapeRight
                            'toggle point is 3rd cube
                            Dim x, y As Integer
                            x = Points(2).X
                            y = Points(2).Y
                            'find the farrest point from center
                            If (Points(0).X = Points(3).X - 2) Then 'pointing left switch to up
                                rval.Add(New Point(x, y + 2))
                                rval.Add(New Point(x, y + 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x + 1, y))
                            ElseIf (Points(0).Y = Points(3).Y + 2) Then 'pointing up switch to right
                                rval.Add(New Point(x + 2, y))
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y - 1))
                            ElseIf (Points(0).X = Points(3).X + 2) Then 'pointing right switch to down
                                rval.Add(New Point(x, y - 2))
                                rval.Add(New Point(x, y - 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x - 1, y))
                            ElseIf (Points(0).Y = Points(3).Y - 2) Then 'pointing down switch to left
                                rval.Add(New Point(x - 2, y))
                                rval.Add(New Point(x - 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y + 1))
                            End If
                        Case FallingBlocks.ShapeType.pyramid
                            'toggle point is 3rd cube
                            Dim x, y As Integer
                            x = Points(2).X
                            y = Points(2).Y
                            If (Points(0).X = x - 1) Then 'pointing left switch to up
                                rval.Add(New Point(x, y + 1))
                                rval.Add(New Point(x - 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x + 1, y))
                            ElseIf (Points(0).Y = y + 1) Then 'pointing up switch to right
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x, y + 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y - 1))
                            ElseIf (Points(0).X = x + 1) Then 'pointing right switch to down
                                rval.Add(New Point(x, y - 1))
                                rval.Add(New Point(x - 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x + 1, y))
                            ElseIf (Points(0).Y = y - 1) Then 'pointing down switch to left
                                rval.Add(New Point(x - 1, y))
                                rval.Add(New Point(x, y - 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y + 1))
                            End If
                        Case FallingBlocks.ShapeType.square
                            rval = Points 'square cannot be toggled
                        Case FallingBlocks.ShapeType.staircaseLeft
                            'toggle point is 3rd cube
                            Dim x, y As Integer
                            x = Points(2).X
                            y = Points(2).Y
                            If (Points(0).Y = y + 1) Then 'pointing left switch down
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x + 1, y + 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y - 1))
                            ElseIf (Points(0).X = x + 1) Then 'pointing down switch left
                                rval.Add(New Point(x, y + 1))
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x - 1, y + 1))
                            End If
                        Case FallingBlocks.ShapeType.staircaseRight
                            'toggle point is 3rd cube
                            Dim x, y As Integer
                            x = Points(2).X
                            y = Points(2).Y
                            If (Points(0).Y = y + 1) Then 'pointing right switch down
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x + 1, y - 1))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y + 1))
                            ElseIf (Points(0).X = x + 1) Then 'pointing down switch right
                                rval.Add(New Point(x + 1, y))
                                rval.Add(New Point(x, y))
                                rval.Add(New Point(x, y - 1))
                                rval.Add(New Point(x - 1, y - 1))
                            End If
                    End Select
            End Select
            Return rval
        End Function

#End Region

        Public Property Points() As Collection(Of Point)
            Get
                Return gridLocations
            End Get
            Set(ByVal value As Collection(Of Point))
                gridLocations = value
            End Set
        End Property
        Public Property IsFrozen() As Boolean
            Get
                Return boolIsFrozen
            End Get
            Set(ByVal value As Boolean)
                boolIsFrozen = value
            End Set
        End Property
        Public ReadOnly Property Color() As Color
            Get
                Select Case Me.shapeType
                    Case FallingBlocks.ShapeType.line
                        Return Drawing.Color.Red
                    Case FallingBlocks.ShapeType.lshapeLeft
                        Return Drawing.Color.Purple
                    Case FallingBlocks.ShapeType.lshapeRight
                        Return Drawing.Color.Yellow
                    Case FallingBlocks.ShapeType.pyramid
                        Return Drawing.Color.Gray
                    Case FallingBlocks.ShapeType.square
                        Return Drawing.Color.Cyan
                    Case FallingBlocks.ShapeType.staircaseLeft
                        Return Drawing.Color.Green
                    Case FallingBlocks.ShapeType.staircaseRight
                        Return Drawing.Color.Blue
                End Select
            End Get
        End Property
        Public Sub RemovePoint(ByVal pnt As Point)
            Me.gridLocations.Remove(pnt)
        End Sub
        Public Sub MovePointDown(ByVal pnt As Point)
            Me.gridLocations(Me.gridLocations.IndexOf(pnt)) = New Point(pnt.X, pnt.Y - 1)
        End Sub
    End Class
#End Region
End Class
