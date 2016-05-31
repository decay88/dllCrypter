Public Class GameEngine

#Region " Public Types "
    Public Enum eGameImages As Integer
        kBackSquare
        kBackSquare1
        kBackSquare2
        kBackSquare3
        kBackSquare4
        kBackSquare5
        kBackSquare6
        kBackSquare7
        kBackSquare8
        kBackSquareBomb
        kFaceLost
        kFaceMouseDown
        kFaceNormal
        kFaceWin
        kFrontSquare
        kFrontSquareFlagBlue
        kFrontSquareFlagRed
        kFrontSquareShowBomb
        kFrontSquareShowBang
        kNUM_IMAGES
    End Enum
#End Region

#Region " Private Types "
    Private Enum eGameSounds
        kWin
        kLose
        kNUM_SOUNDS
    End Enum
#End Region

#Region " Const "
    Public Shared ReadOnly kClearColor As Color = Color.FromKnownColor(KnownColor.White)
    Public Shared ReadOnly kImagesPath As String = Application.StartupPath & "\Bitmaps\"
#End Region

#Region " Variables "
    Private m_NumSquaresW As Integer
    Private m_NumSquaresH As Integer
    Private m_MinePrc As Single
    Private m_NumMines As Integer
    Private m_MinesMarkedFound As Integer
    Private m_RealMinesFound As Integer
    Private m_ScreenPtr As IntPtr = IntPtr.Zero
    Private m_Map(,) As Square.eSquareTypes
    Private m_Squares(,) As Square
    Private m_Rand As New Random
    Private Shared m_GameBitmaps(eGameImages.kNUM_IMAGES) As Bitmap
    Private m_GameOver As Boolean
    Private m_AcceptClicks As Boolean
    Private Shared m_ImagesFolder As String
    Private Shared m_GameSounds(eGameSounds.kNUM_SOUNDS) As Sound
    Private m_MiddleCords As New ArrayList
    Private m_Dirty As Boolean
#End Region

#Region " Events "
    Public Event RestartingMap()
    Public Event GameWon()
    Public Event FinishedReseting()
    Public Event Resizing(ByVal w As Integer, ByVal h As Integer)
#End Region

#Region " Propertys "
    Public Shared WriteOnly Property ImagesFolder() As String
        Set(ByVal Value As String)
            m_ImagesFolder = Value
        End Set
    End Property

    Public Property GameOver() As Boolean
        Get
            Return m_GameOver
        End Get
        Set(ByVal Value As Boolean)
            m_GameOver = Value
        End Set
    End Property

    Public ReadOnly Property AcceptClicks() As Boolean
        Get
            Return m_AcceptClicks
        End Get
    End Property

    Public Property NumSquaresW() As Integer
        Get
            Return m_NumSquaresW
        End Get
        Set(ByVal Value As Integer)
            m_NumSquaresW = Value
        End Set
    End Property

    Public Property NumSquaresH() As Integer
        Get
            Return m_NumSquaresH
        End Get
        Set(ByVal Value As Integer)
            m_NumSquaresH = Value
        End Set
    End Property

    Public Property MinePrc() As Single
        Get
            Return m_MinePrc
        End Get
        Set(ByVal Value As Single)
            m_MinePrc = Value
        End Set
    End Property
#End Region

#Region " Constructors "
    Public Sub InitEngine(ByVal theScreenPtr As IntPtr, ByVal SquaresW As Integer, ByVal SquaresH As Integer, ByVal MinesPrc As Single)
        m_NumSquaresW = MakeEvenlyDivisible(SquaresW, Square.kSquareW)
        m_NumSquaresH = MakeEvenlyDivisible(SquaresH, Square.kSquareH)
        m_MinePrc = MinesPrc
        m_NumMines = CalcNumMines()
        m_ScreenPtr = theScreenPtr
        m_GameOver = False
        m_Dirty = False
    End Sub
#End Region

#Region " Functions "

#Region " Private "
    Private Function CalcNumMines() As Integer
        Return CInt(((m_NumSquaresW * m_NumSquaresH) * m_MinePrc))
    End Function

    Private Function GetSearchPoints(ByVal x As Integer, ByVal y As Integer) As Point()
        Dim retArr As New ArrayList

        retArr.Add(New Point(x - 1, y - 1))
        retArr.Add(New Point(x - 1, y))
        retArr.Add(New Point(x - 1, y + 1))

        retArr.Add(New Point(x, y - 1))
        retArr.Add(New Point(x, y + 1))

        retArr.Add(New Point(x + 1, y - 1))
        retArr.Add(New Point(x + 1, y))
        retArr.Add(New Point(x + 1, y + 1))

        Return retArr.ToArray(GetType(Point))
    End Function

    Private Function MapObjIsBomb(ByVal x, ByVal y) As Boolean
        If IsInBounds(x, y) Then
            Dim mapObj As Square.eSquareTypes = m_Map(x, y)
            If mapObj = Square.eSquareTypes.kFrontSquareBomb Or _
               mapObj = Square.eSquareTypes.kFrontSquareBombFlagBlue Or _
               mapObj = Square.eSquareTypes.kFrontSquareBombFlagRed Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Function NumMinesAround(ByVal x As Integer, ByVal y As Integer) As Integer
        Dim count As Integer = 0

        For Each p As Point In GetSearchPoints(x, y)
            If IsInBounds(p.X, p.Y) Then
                If MapObjIsBomb(p.X, p.Y) Then count += 1
            End If
        Next p

        Return count
    End Function
#End Region

#Region " Shared "
    Public Shared Function MakeEvenlyDivisible(ByVal value As Integer, ByVal by As Integer) As Integer
        Dim overflow As Integer = value Mod by

        If overflow > 0.0! Then Return value + (by - overflow)

        Return value
    End Function

    Public Shared Function GetBitmap(ByVal type As eGameImages) As Bitmap
        Return m_GameBitmaps(CInt(type)).Clone
    End Function
#End Region

    Public Function GetScreenShot(Optional ByVal time As String = Nothing, Optional ByVal font As Font = Nothing) As Image
        Dim w As Integer = m_Map.GetUpperBound(0) * Square.kSquareW
        Dim h As Integer = m_Map.GetUpperBound(1) * Square.kSquareH
        Dim theBmp As Bitmap = New Bitmap(w, h)
        Dim theGraphics As Graphics = Graphics.FromImage(theBmp)

        g.Engine.Render(theGraphics, True)

        If Not time Is Nothing Then
            Dim theFont As Font = New Font(font.FontFamily, 32, FontStyle.Bold, GraphicsUnit.Pixel)
            Dim semiTransBrush As New SolidBrush(Color.FromArgb(99, 0, 0, 0))
            Dim theTxt As String
            Dim size As SizeF

            theTxt = m_NumMines
            size = theGraphics.MeasureString(theTxt, theFont)
            theGraphics.DrawString(m_NumMines, theFont, semiTransBrush, ((w - CInt(size.Width)) >> 1), (((h - CInt(size.Height << 1)) - 16) >> 1))

            theTxt = NumSquaresW & "x" & NumSquaresH
            size = theGraphics.MeasureString(theTxt, theFont)
            theGraphics.DrawString(theTxt, theFont, semiTransBrush, ((w - CInt(size.Width)) >> 1), ((h - CInt(size.Height)) >> 1))

            theTxt = time
            size = theGraphics.MeasureString(theTxt, theFont)
            theGraphics.DrawString(theTxt, theFont, semiTransBrush, ((w - CInt(size.Width)) >> 1), ((h + 16) >> 1))
        End If

        Return theBmp
    End Function

    Public Function IsInBounds(ByVal x As Integer, ByVal y As Integer) As Boolean
        Return ((x >= 0 And x < m_Map.GetUpperBound(0)) And (y >= 0 And y < m_Map.GetUpperBound(1)))
    End Function

    Public Function IsUnmarkedBomb(ByVal x, ByVal y) As Boolean
        If IsInBounds(x, y) Then
            Dim mapObj As Square.eSquareTypes = m_Map(x, y)
            If mapObj = Square.eSquareTypes.kFrontSquareBomb Or _
               mapObj = Square.eSquareTypes.kFrontSquareBombFlagBlue Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Function NumberOfMines() As Integer
        Return m_NumMines
    End Function

    Public Function NumMinesFound() As Integer
        Return m_MinesMarkedFound
    End Function
#End Region

#Region " Subs "

#Region " Private "
    Private Sub ClearAround(ByVal x As Integer, ByVal y As Integer)
        For Each p As Point In GetSearchPoints(x, y)
            If IsInBounds(p.X, p.Y) Then
                If m_Map(p.X, p.Y) = Square.eSquareTypes.kFrontSquare Then
                    Dim numMines As Integer = NumMinesAround(p.X, p.Y)
                    SetSquare(p.X, p.Y, CType(numMines, Square.eSquareTypes))
                    If numMines = 0 Then ClearAround(p.X, p.Y)
                End If
            End If
        Next p
    End Sub

    Private Sub SetSquare(ByVal x As Integer, ByVal y As Integer, ByVal type As Square.eSquareTypes)
        If IsInBounds(x, y) Then
            m_Map(x, y) = type
            If Not m_Squares(x, y) Is Nothing Then m_Squares(x, y).Dispose()
            m_Squares(x, y) = Nothing
            m_Squares(x, y) = New Square(type, (x * Square.kSquareW), (y * Square.kSquareH))
            m_Dirty = True
        End If
    End Sub

    Private Sub DoGameOver(ByVal won As Boolean, Optional ByVal theX As Integer = -1, Optional ByVal theY As Integer = -1)
        If won Then
            m_GameSounds(eGameSounds.kWin).Play()
            RaiseEvent GameWon()

            For x As Integer = 0 To m_Map.GetUpperBound(0) - 1
                For y As Integer = 0 To m_Map.GetUpperBound(1) - 1
                    If m_Map(x, y) = Square.eSquareTypes.kFrontSquare Then
                        SetSquare(x, y, CType(NumMinesAround(x, y), Square.eSquareTypes))
                    End If
                Next y
            Next x

            Me.Render(False)

            If MsgBox("Congratulations you have won! Would you like to play again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DoResize()
                InitMap(False)
            Else
                m_GameOver = True
            End If
        Else
            m_GameSounds(eGameSounds.kLose).Play()

            For x As Integer = 0 To m_Map.GetUpperBound(0) - 1
                For y As Integer = 0 To m_Map.GetUpperBound(1) - 1
                    If m_Map(x, y) = Square.eSquareTypes.kFrontSquare Then
                        SetSquare(x, y, CType(NumMinesAround(x, y), Square.eSquareTypes))
                    End If
                Next y
            Next x

            For x As Integer = 0 To m_Map.GetUpperBound(0) - 1
                For y As Integer = 0 To m_Map.GetUpperBound(1) - 1
                    Select Case m_Map(x, y)
                        Case Square.eSquareTypes.kFrontSquareBomb, Square.eSquareTypes.kFrontSquareBombFlagBlue, Square.eSquareTypes.kFrontSquareFlagBlue
                            SetSquare(x, y, Square.eSquareTypes.kBackSquareBomb)

                        Case Square.eSquareTypes.kFrontSquareFlagRed
                            SetSquare(x, y, Square.eSquareTypes.kFrontSquareShowBomb)
                    End Select
                Next y
            Next x

            If IsInBounds(theX, theY) Then
                SetSquare(theX, theY, Square.eSquareTypes.kFrontSquareShowBang)
                m_Squares(theX, theY).Render(m_ScreenPtr)
            End If

            If MsgBox("You Looser! How about trying that again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DoResize()
                InitMap(False)
            Else
                m_GameOver = True
            End If
        End If
    End Sub

    Private Sub DoResize()
        Dim saveVal As Boolean = m_AcceptClicks

        m_AcceptClicks = False
        Dim theSizer As New dlgAskSize(m_NumSquaresW, m_NumSquaresH, m_MinePrc, m_ImagesFolder)
        theSizer.ShowDialog()
        m_AcceptClicks = saveVal

        Dim tmpFolder As String = theSizer.ImagesFolder

        m_NumSquaresW = theSizer.FieldW
        m_NumSquaresH = theSizer.FieldH
        RaiseEvent Resizing(m_NumSquaresW, m_NumSquaresH)

        If Not m_ImagesFolder = tmpFolder Then
            m_ImagesFolder = tmpFolder
            DisposeImages()
            LoadBitmaps()
            DisposeSounds()
            LoadSounds()
        End If

        m_MinePrc = theSizer.MinesPrc
        m_NumMines = CalcNumMines()

        theSizer = Nothing
    End Sub
#End Region

#Region " Shared "
    Public Shared Sub LoadBitmaps()
        For i As Integer = 0 To eGameImages.kNUM_IMAGES - 1
            Select Case CType(i, eGameImages)
                Case eGameImages.kBackSquare
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare.bmp"), Bitmap)
                Case eGameImages.kBackSquare1
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare1.bmp"), Bitmap)
                Case eGameImages.kBackSquare2
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare2.bmp"), Bitmap)
                Case eGameImages.kBackSquare3
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare3.bmp"), Bitmap)
                Case eGameImages.kBackSquare4
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare4.bmp"), Bitmap)
                Case eGameImages.kBackSquare5
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare5.bmp"), Bitmap)
                Case eGameImages.kBackSquare6
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare6.bmp"), Bitmap)
                Case eGameImages.kBackSquare7
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare7.bmp"), Bitmap)
                Case eGameImages.kBackSquare8
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquare8.bmp"), Bitmap)
                Case eGameImages.kBackSquareBomb
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\BackSquareBomb.bmp"), Bitmap)
                Case eGameImages.kFaceLost
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FaceLost.bmp"), Bitmap)
                Case eGameImages.kFaceMouseDown
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FaceMouseDown.bmp"), Bitmap)
                Case eGameImages.kFaceNormal
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FaceNormal.bmp"), Bitmap)
                Case eGameImages.kFaceWin
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FaceWin.bmp"), Bitmap)
                Case eGameImages.kFrontSquare
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FrontSquare.bmp"), Bitmap)
                Case eGameImages.kFrontSquareFlagBlue
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FrontSquareFlagBlue.bmp"), Bitmap)
                Case eGameImages.kFrontSquareFlagRed
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FrontSquareFlagRed.bmp"), Bitmap)
                Case eGameImages.kFrontSquareShowBomb
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FrontSquareShowBomb.bmp"), Bitmap)
                Case eGameImages.kFrontSquareShowBang
                    m_GameBitmaps(i) = CType(Bitmap.FromFile(kImagesPath & m_ImagesFolder & "\FrontSquareShowBang.bmp"), Bitmap)
            End Select
            m_GameBitmaps(i).MakeTransparent(kClearColor)
        Next i
    End Sub

    Public Sub LoadSounds()
        For i As Integer = 0 To m_GameSounds.Length - 1
            Select Case CType(i, eGameSounds)
                Case eGameSounds.kWin
                    m_GameSounds(i) = New Sound(kImagesPath & m_ImagesFolder & "\Win.wav")
                Case eGameSounds.kLose
                    m_GameSounds(i) = New Sound(kImagesPath & m_ImagesFolder & "\Lose.wav")
            End Select
        Next i
    End Sub
#End Region

    Public Sub InitMap(ByVal acceptClicksAfter As Boolean)
        m_AcceptClicks = False

        RaiseEvent RestartingMap()

        If Not m_Map Is Nothing Then
            Array.Clear(m_Map, 0, m_Map.Length)
            m_Map = Nothing
        End If

        m_MinesMarkedFound = 0
        m_RealMinesFound = 0

        m_Map = New Square.eSquareTypes(m_NumSquaresW, m_NumSquaresH) {}

        For x As Integer = 0 To m_Map.GetUpperBound(0) - 1
            For y As Integer = 0 To m_Map.GetUpperBound(1) - 1
                m_Map(x, y) = Square.eSquareTypes.kFrontSquare
            Next y
        Next x

        Dim numMinesPlaced As Integer = 0
        While True
            Dim randX As Integer = m_Rand.Next(0, m_NumSquaresW)
            Dim randY As Integer = m_Rand.Next(0, m_NumSquaresH)

            If IsInBounds(randX, randY) Then
                If Not m_Map(randX, randY) = Square.eSquareTypes.kFrontSquareBomb Then
                    m_Map(randX, randY) = Square.eSquareTypes.kFrontSquareBomb

                    numMinesPlaced += 1
                    If numMinesPlaced = m_NumMines Then Exit While
                End If
            End If
        End While

        If Not m_Squares Is Nothing Then
            For x As Integer = 0 To m_Squares.GetUpperBound(0) - 1
                For y As Integer = 0 To m_Squares.GetUpperBound(1) - 1
                    If Not m_Squares(x, y) Is Nothing Then m_Squares(x, y).Dispose()
                    m_Squares(x, y) = Nothing
                    m_Dirty = True
                Next y
            Next x
            m_Squares = Nothing
        End If

        m_Squares = New Square(m_NumSquaresW, m_NumSquaresH) {}

        For x As Integer = 0 To m_Squares.GetUpperBound(0) - 1
            For y As Integer = 0 To m_Squares.GetUpperBound(1) - 1
                m_Squares(x, y) = New Square(m_Map(x, y), (x * Square.kSquareW), (y * Square.kSquareH))
                m_Dirty = True
            Next y
        Next x

        RaiseEvent FinishedReseting()
        m_AcceptClicks = acceptClicksAfter
    End Sub

    Public Sub MiddleClickSquare(ByVal x As Integer, ByVal y As Integer)
        If Not m_AcceptClicks Then Exit Sub
        If m_MiddleCords.Count > 0 Then UndoMiddleClick(New Point(-1, -1))

        For Each p As Point In GetSearchPoints(x, y)
            If IsInBounds(p.X, p.Y) Then
                If CInt(m_Map(p.X, p.Y)) > Square.eSquareTypes.kBackSquareBomb Then
                    m_Squares(p.X, p.Y).DrawMode = Square.eDrawMode.kMiddleClick
                    m_Dirty = True
                    m_MiddleCords.Add(p)
                End If
            End If
        Next p
    End Sub

    Public Function UndoMiddleClick(ByVal searchPoint As Point) As Boolean
        For Each p As Point In m_MiddleCords
            If IsInBounds(p.X, p.Y) Then
                m_Squares(p.X, p.Y).DrawMode = Square.eDrawMode.kNormal
                m_Dirty = True
            End If
        Next p

        m_MiddleCords.Clear()

        If Not searchPoint.Equals(New Point(-1, -1)) Then
            If Not IsInBounds(searchPoint.X, searchPoint.Y) Then Exit Function

            Dim ST As Square.eSquareTypes = m_Map(searchPoint.X, searchPoint.Y)

            If ST >= Square.eSquareTypes.kBackSquare1 And ST <= Square.eSquareTypes.kBackSquare8 Then
                If MinesMarkedAround(searchPoint.X, searchPoint.Y) = CInt(ST) Then

                    For Each p As Point In GetSearchPoints(searchPoint.X, searchPoint.Y)
                        If IsInBounds(p.X, p.Y) Then
                            Dim ST2 As Square.eSquareTypes = m_Map(p.X, p.Y)

                            If ST2 = Square.eSquareTypes.kFrontSquare Or _
                               ST2 = Square.eSquareTypes.kFrontSquareFlagBlue Or _
                               ST2 = Square.eSquareTypes.kFrontSquareBomb Or _
                               ST2 = Square.eSquareTypes.kFrontSquareBombFlagBlue Then
                                If LeftClickSquare(p.X, p.Y, True) Then Return True
                            End If
                        End If
                    Next p

                End If
            End If
        End If

        Return False
    End Function

    Public Function MinesMarkedAround(ByVal x As Integer, ByVal y As Integer) As Integer
        Dim count As Integer = 0

        For Each p As Point In GetSearchPoints(x, y)
            If IsInBounds(p.X, p.Y) Then
                Dim ST As Square.eSquareTypes = m_Map(p.X, p.Y)
                If ST = Square.eSquareTypes.kFrontSquareFlagRed Or ST = Square.eSquareTypes.kFrontSquareBombFlagRed Then
                    count += 1
                End If
            End If
        Next p

        Return count
    End Function

    Public Function LeftClickSquare(ByVal x As Integer, ByVal y As Integer, Optional ByVal ignoreFlags As Boolean = False) As Boolean
        If Not m_AcceptClicks Then Exit Function
        If Not IsInBounds(x, y) Then Exit Function

        Dim ST As Square.eSquareTypes = m_Map(x, y)

        If Not ignoreFlags Then
            If (ST = Square.eSquareTypes.kFrontSquareBombFlagRed) Or (ST = Square.eSquareTypes.kFrontSquareFlagRed) Then Exit Function
        End If

        If m_Squares(x, y).IsBomb Then
            m_AcceptClicks = False
            DoGameOver(False, x, y)
            m_AcceptClicks = True
            Return True
        Else
            Dim numMines As Integer = NumMinesAround(x, y)
            SetSquare(x, y, CType(numMines, Square.eSquareTypes))
            If numMines = 0 Then ClearAround(x, y)
        End If

        Return False
    End Function

    Public Sub RightClickSquare(ByVal x As Integer, ByVal y As Integer)
        If Not m_AcceptClicks Then Exit Sub
        If Not IsInBounds(x, y) Then Exit Sub

        Dim ST As Square.eSquareTypes = m_Map(x, y)

        If ST = Square.eSquareTypes.kFrontSquare Then
            SetSquare(x, y, Square.eSquareTypes.kFrontSquareFlagRed)
            m_MinesMarkedFound += 1
        ElseIf ST = Square.eSquareTypes.kFrontSquareFlagRed Then
            SetSquare(x, y, Square.eSquareTypes.kFrontSquareFlagBlue)
            m_MinesMarkedFound -= 1
        ElseIf ST = Square.eSquareTypes.kFrontSquareFlagBlue Then
            SetSquare(x, y, Square.eSquareTypes.kFrontSquare)
        ElseIf ST = Square.eSquareTypes.kFrontSquareBomb Then
            SetSquare(x, y, Square.eSquareTypes.kFrontSquareBombFlagRed)
            m_MinesMarkedFound += 1
            m_RealMinesFound += 1
        ElseIf ST = Square.eSquareTypes.kFrontSquareBombFlagRed Then
            SetSquare(x, y, Square.eSquareTypes.kFrontSquareBombFlagBlue)
            m_MinesMarkedFound -= 1
            m_RealMinesFound -= 1
        ElseIf ST = Square.eSquareTypes.kFrontSquareBombFlagBlue Then
            SetSquare(x, y, Square.eSquareTypes.kFrontSquareBomb)
        End If

        If m_RealMinesFound = m_NumMines Then
            If m_MinesMarkedFound = m_RealMinesFound Then
                m_Squares(x, y).Render(m_ScreenPtr)
                m_AcceptClicks = False
                DoGameOver(True)
                m_AcceptClicks = True
            End If
        End If
    End Sub

    Public Sub Render(ByVal overrideDirty As Boolean)
        If m_ScreenPtr.Equals(IntPtr.Zero) Then Exit Sub
        If Not m_Dirty And Not overrideDirty Then Exit Sub

        For x As Integer = 0 To m_Squares.GetUpperBound(0) - 1
            For y As Integer = 0 To m_Squares.GetUpperBound(1) - 1
                m_Squares(x, y).Render(m_ScreenPtr)
            Next y
        Next x

        m_Dirty = False
    End Sub

    Public Sub Render(ByVal tmpPtr As Graphics, ByVal overrideDirty As Boolean)
        If m_Squares Is Nothing Then Exit Sub
        If Not m_Dirty And Not overrideDirty Then Exit Sub

        For x As Integer = 0 To m_Squares.GetUpperBound(0) - 1
            For y As Integer = 0 To m_Squares.GetUpperBound(1) - 1
                m_Squares(x, y).Render(tmpPtr)
            Next y
        Next x

        m_Dirty = False
    End Sub

    Private Sub DisposeImages()
        For i As Integer = 0 To m_GameBitmaps.Length - 1
            If Not m_GameBitmaps(i) Is Nothing Then m_GameBitmaps(i).Dispose()
        Next i
    End Sub

    Private Sub DisposeSounds()
        For i As Integer = 0 To m_GameSounds.Length - 1
            If Not m_GameSounds(i) Is Nothing Then m_GameSounds(i) = Nothing
        Next i
    End Sub

    Public Sub Dispose()
        For x As Integer = 0 To m_Squares.GetUpperBound(0) - 1
            For y As Integer = 0 To m_Squares.GetUpperBound(1) - 1
                If Not m_Squares(x, y) Is Nothing Then m_Squares(x, y).Dispose()
            Next y
        Next x

        DisposeImages()

        m_Squares = Nothing
        m_GameBitmaps = Nothing
    End Sub
#End Region

End Class