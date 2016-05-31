Imports System.IO

Public Class Sound

#Region " Const "
    Private Const kFileAsc As Integer = &H20001
#End Region

#Region " Declare Auto Function "
    Declare Auto Function PlaySound Lib "winmm.dll" (ByVal name As String, ByVal hmod As Integer, ByVal flags As Integer) As Integer
#End Region

#Region " Variables "
    Private m_Path As String
#End Region

#Region " Constructor "
    Public Sub New(ByVal path As String)
        m_Path = path
    End Sub
#End Region

#Region " Subs "
    Public Sub Play()
        On Error Resume Next
        PlaySound(m_Path, 0, kFileAsc)
    End Sub
#End Region

End Class