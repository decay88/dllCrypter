Imports System.Runtime.InteropServices
Imports System.Drawing

Module IconExtract
    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Function ExtractIconEx(ByVal szFileName As String,
        ByVal nIconIndex As Integer,
        ByVal phiconLarge() As IntPtr,
        ByVal phiconSmall() As IntPtr,
        ByVal nIcons As Integer) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="DestroyIcon", SetLastError:=True)>
    Function DestroyIcon(ByVal hIcon As IntPtr) As Integer
    End Function

    Public Function WriteIconOut(ByVal iconsrcpath As String, ByVal icondestpath As String)
        Dim iconsrc As Icon = ExtractIconFromExe(iconsrcpath, True)
        iconsrc.Save(System.IO.File.OpenWrite(icondestpath))
    End Function

    Public Function ExtractIconFromExe(ByVal f As String, ByVal large As Boolean) As Icon
        Dim readIconCount As Integer = 0
        Dim hDummy As IntPtr() = New IntPtr(0) {IntPtr.Zero}
        Dim hIconEx As IntPtr() = New IntPtr(0) {IntPtr.Zero}

        Try
            If (large) Then
                readIconCount = ExtractIconEx(f, 0, hIconEx, hDummy, 1)
            Else
                readIconCount = ExtractIconEx(f, 0, hDummy, hIconEx, 1)
            End If

            If (readIconCount > 0 AndAlso Not hIconEx(0).Equals(IntPtr.Zero)) Then
                ' GET FIRST EXTRACTED ICON
                Dim extractedIcon As Icon = Icon.FromHandle(hIconEx(0)).Clone()
                Return extractedIcon
            Else ' NO ICONS READ
                Return Nothing
            End If
        Catch ex As Exception
            ' EXTRACT ICON ERROR
            ' BUBBLE UP
            Throw New ApplicationException("Could not extract icon", ex)
        Finally
            'RELEASE RESOURCES
            For Each ptr As IntPtr In hIconEx
                If (Not ptr.Equals(IntPtr.Zero)) Then
                    DestroyIcon(ptr)
                End If
            Next ptr

            For Each ptr As IntPtr In hDummy
                If Not (ptr.Equals(IntPtr.Zero)) Then
                    DestroyIcon(ptr)
                End If
            Next ptr
        End Try
    End Function
End Module