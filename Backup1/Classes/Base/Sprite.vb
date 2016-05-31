Imports System.Windows.Forms
Imports System.Drawing
Imports System
Imports System.Collections

Public Class Sprite

#Region " Events "
    Protected Event FinishedRendering(ByVal useGrap As Graphics)
#End Region

#Region " Variables "
    Protected m_X As Integer
    Protected m_Y As Integer
    Protected m_Image As Bitmap = Nothing
#End Region

#Region " Propertys "
    Public Property X() As Integer
        Get
            Return m_X
        End Get
        Set(ByVal Value As Integer)
            m_X = Value
        End Set
    End Property

    Public Property Y() As Integer
        Get
            Return m_Y
        End Get
        Set(ByVal Value As Integer)
            m_Y = Value
        End Set
    End Property

    Public Property Image() As Bitmap
        Get
            Return m_Image
        End Get
        Set(ByVal Value As Bitmap)
            m_Image = Value
        End Set
    End Property
#End Region

#Region " Constructor "
    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        m_X = x
        m_Y = y
    End Sub

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Bitmap)
        m_X = x
        m_Y = y
        m_Image = image
    End Sub
#End Region

#Region " Subs "
    Public Sub Render(ByVal inWinPtr As IntPtr)
        Dim theGraphics As Graphics = Graphics.FromHwnd(inWinPtr)
        Render(theGraphics)
        theGraphics.Dispose()
    End Sub

    Public Sub Render(ByVal theGraphics As Graphics)
        theGraphics.DrawImageUnscaled(m_Image, m_X, m_Y)
        RaiseEvent FinishedRendering(theGraphics)
    End Sub

    Public Sub Dispose()
        If Not m_Image Is Nothing Then m_Image.Dispose()
        m_Image = Nothing
    End Sub
#End Region

End Class