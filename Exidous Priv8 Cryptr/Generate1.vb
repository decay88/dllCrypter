Module Randomnumber
    Class keyc1
        Public Shared Function Key1() As Object
            Const ranshit3 As String = "1234567890"
            Dim totalequivalent As String
            Dim i As Short
            totalequivalent = ranshit3
                Key1 = Key1 & Mid(totalequivalent, Int((Rnd() * Len(totalequivalent)) + 1), 1)
        End Function
    End Class
End Module
