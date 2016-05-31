Public Class Square
    Inherits Sprite

#Region " Public Types "
    Public Enum eSquareTypes As Integer
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
        kFrontSquare
        kFrontSquareFlagBlue
        kFrontSquareFlagRed
        kFrontSquareBomb
        kFrontSquareBombFlagBlue
        kFrontSquareBombFlagRed
        kFrontSquareShowBomb
        kFrontSquareShowBang
    End Enum

    Public Enum eDrawMode
        kNormal
        kMiddleClick
    End Enum
#End Region

#Region " Const "
    Public Const kSquareW As Integer = 16
    Public Const kSquareH As Integer = 16
#End Region

#Region " Variables "
    Private m_Type As eSquareTypes
    Private m_DrawMode As eDrawMode
#End Region

#Region " Propertys "
    Public Property DrawMode() As eDrawMode
        Get
            Return m_DrawMode
        End Get
        Set(ByVal Value As eDrawMode)
            m_DrawMode = Value
        End Set
    End Property
#End Region

#Region " Constructor "
    Public Sub New(ByVal type As eSquareTypes, ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, GameEngine.GetBitmap(ImageTypeFromSquareType(type)))
        m_Type = type
        m_DrawMode = eDrawMode.kNormal
    End Sub
#End Region

#Region " Functions "
    Public Function IsBomb() As Boolean
        Return m_Type = eSquareTypes.kFrontSquareBomb Or m_Type = eSquareTypes.kFrontSquareBombFlagBlue Or m_Type = eSquareTypes.kFrontSquareBombFlagRed
    End Function

    Private Shared Function ImageTypeFromSquareType(ByVal theSquareType As eSquareTypes) As GameEngine.eGameImages
        If CInt(theSquareType) >= CInt(eSquareTypes.kBackSquare) And CInt(theSquareType) <= CInt(eSquareTypes.kBackSquareBomb) Then
            Return CType(theSquareType, GameEngine.eGameImages)
        End If

        Select Case theSquareType
            Case eSquareTypes.kFrontSquare
                Return GameEngine.eGameImages.kFrontSquare
            Case eSquareTypes.kFrontSquareFlagBlue
                Return GameEngine.eGameImages.kFrontSquareFlagBlue
            Case eSquareTypes.kFrontSquareFlagRed
                Return GameEngine.eGameImages.kFrontSquareFlagRed
            Case eSquareTypes.kFrontSquareBomb
                Return GameEngine.eGameImages.kFrontSquare
            Case eSquareTypes.kFrontSquareBombFlagBlue
                Return GameEngine.eGameImages.kFrontSquareFlagBlue
            Case eSquareTypes.kFrontSquareBombFlagRed
                Return GameEngine.eGameImages.kFrontSquareFlagRed
            Case eSquareTypes.kFrontSquareShowBomb
                Return GameEngine.eGameImages.kFrontSquareShowBomb
            Case eSquareTypes.kFrontSquareShowBang
                Return GameEngine.eGameImages.kFrontSquareShowBang
        End Select
    End Function
#End Region

#Region " Events "
    Private Sub Square_FinishedRendering(ByVal useGrap As System.Drawing.Graphics) Handles MyBase.FinishedRendering
        If m_DrawMode = eDrawMode.kMiddleClick Then
            useGrap.DrawLine(New Drawing.Pen(Color.Yellow, 1), New Point(m_x, m_y), New Point(m_x + kSquareW, m_y))
            useGrap.DrawLine(New Drawing.Pen(Color.Yellow, 1), New Point(m_x, m_y), New Point(m_x, m_y + kSquareH))
            useGrap.DrawLine(New Drawing.Pen(Color.Yellow, 2), New Point(m_x, m_y + kSquareH), New Point(m_x + kSquareW, m_y + kSquareH))
            useGrap.DrawLine(New Drawing.Pen(Color.Yellow, 2), New Point(m_x + kSquareW, m_y), New Point(m_x + kSquareW, m_y + kSquareH))
        End If
    End Sub
#End Region

End Class