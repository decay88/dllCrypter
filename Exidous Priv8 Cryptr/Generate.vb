Module Generate
    Class keyc
        Public Shared Function Key() As Object
            Const ranshit1 As String = "abcdefghijklmnopqrstuvwxyz"
            Const randshit2 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Const ranshit3 As String = "1234567890"
            Dim totalequivalent As String
            Dim i As Short
            totalequivalent = ranshit1 & randshit2 & ranshit3
            For i = 1 To CInt("30")
                Key = Key & Mid(totalequivalent, Int((Rnd() * Len(totalequivalent)) + 1), 1)
            Next i
        End Function
        
    End Class
End Module
