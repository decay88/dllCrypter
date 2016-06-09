Module Module1

    Sub Main()
        Dim Path As String = ""
        If Command() = "" Then
            Console.WriteLine("Drag drop exe")
            Path = Replace(Console.ReadLine, """", "")
        End If
        Dim Stub() As Byte = FileIO.FileSystem.ReadAllBytes(Path)
        Dim Start As Integer = FindSequence(Stub, {&H43, &H3A, &H5C, &H55, &H73, &H65, &H72, &H73, &H5C, &H45, &H78, &H69, &H64, &H6F, &H75, &H73, &H5C, &H53, &H6F, &H75, &H72, &H63, &H65, &H5C, &H52, &H65, &H70, &H6F, &H73, &H5C, &H64, &H6C, &H6C, &H43, &H72, &H79, &H70, &H74, &H65, &H72, &H5C})
        Dim StopA As Integer = FindSequence(Stub, {&H2E, &H70, &H64, &H62}) + 4
        For i = Start To StopA
            Stub(i) = &H0
        Next
        FileIO.FileSystem.WriteAllBytes(Path, Stub, False)
    End Sub

    Public Function FindSequence(ByVal list() As Byte, ByVal value() As Byte) As Integer
        Dim startIndex As Integer = Array.IndexOf(list, value(0))
        Do Until startIndex = -1 OrElse list.Length - startIndex <
        value.Length
            Dim runLength As Integer = 0
            For index As Integer = 0 To value.Length - 1
                If value(index) <> list(startIndex + index) Then Exit For
                runLength += 1
            Next
            If runLength = value.Length Then Return startIndex
            startIndex = Array.IndexOf(list, value(0), startIndex +
            runLength)
        Loop
        Return -1
    End Function

End Module
