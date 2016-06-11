Public Class Form1
    Dim UsedStrings() As String = {}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Template As String = My.Resources.String1
        Dim Usage As String = " %SHIT0%.%SHIT1%()"
        For i = 0 To 25
            If i = 0 Or i = 1 Then
                Dim Name As String = GenerateString()
                Template = Replace(Template, "%SHIT" & i & "%", Name)
                Usage = Replace(Usage, "%SHIT" & i & "%", Name)
            Else
                Template = Replace(Template, "%SHIT" & i & "%", GenerateString)
                Usage = Replace(Usage, "%SHIT" & i & "%", GenerateString)
            End If

        Next
        Dim X() As String = Split(Replace(Replace(Template, vbLf, Environment.NewLine), Environment.NewLine & Environment.NewLine, Environment.NewLine), Environment.NewLine)
        Dim IsInSubOrFunc As Boolean = False
        Dim LineSkip As Integer = 0
        Dim LinesSkipped As Integer = 0
        Dim RandomFunctions As String = ""
        Dim RebuiltStr As String = ""
        Dim IsShared As Boolean = False

        For Each line In X
            If IsInSubOrFunc = False Then
                If line.Contains("Shared Sub") Or line.Contains("Shared Function") Or line.Contains("Public Shared Funciton") Or line.Contains("Public Shared Sub") Or line.Contains("Private Shared Function") Or line.Contains("Private Shared Sub") Then
                    IsInSubOrFunc = True
                    LinesSkipped = 0
                    LineSkip = 0
                    If line.Contains("Shared") Then IsShared = True Else IsShared = False
                End If
            Else
                'we are now inside a sub or function
                If line.Contains("End Sub") Or line.Contains("End Function") Then IsInSubOrFunc = False : RebuiltStr &= line & Environment.NewLine & RandomFunctions & Environment.NewLine : RandomFunctions = "" : Continue For
                'check if we have skipped enough lines
                If LinesSkipped = LineSkip Then
                    Dim FuncName As String = GenerateString()
                    Dim rn As New Random

                    Dim c As Integer = rn.Next(0, 3)
                    Select Case c
                        Case 0
                            line &= Environment.NewLine & FuncName & "()" & Environment.NewLine
                            RandomFunctions &= RandomSub(FuncName, IsShared) & Environment.NewLine & Environment.NewLine

                        Case 1
                            line &= Environment.NewLine & "Dim " & GenerateString() & " = " & FuncName & "()" & Environment.NewLine
                            RandomFunctions &= RandomFunction(FuncName, IsShared) & Environment.NewLine & Environment.NewLine

                        Case 2
                            line &= RandomDeclaration(FuncName)
                    End Select

                    LinesSkipped = 0
                    System.Threading.Thread.Sleep(50)
                    LineSkip = rn.Next(0, 1)
                Else
                    LinesSkipped += 1
                End If
            End If
            RebuiltStr &= line & Environment.NewLine
        Next
        TextBox3.Text = Replace(RebuiltStr & Environment.NewLine & My.Resources.String2, Environment.NewLine & Environment.NewLine, Environment.NewLine)
        TextBox2.Text = Usage
    End Sub

    Private Function GenerateString()
        Dim Rn As New Random
Retry:
        Dim RndStr As String = RandomString(Rn.Next(6, 12))
        For Each rndstrs In UsedStrings
            If RndStr.ToLower = rndstrs.ToLower Then
                GoTo Retry
            End If
        Next
        Dim Tmp() As String = UsedStrings
        ReDim UsedStrings(0 To Tmp.Count)
        For i = 0 To Tmp.Count - 1
            UsedStrings(i) = Tmp(i)
        Next
        UsedStrings(UsedStrings.Count - 1) = RndStr
        Return RndStr
    End Function
    Function RandomDeclaration(ByVal FuncName As String)
        Dim Rn As New Random
        Dim Z As Integer = Rn.Next(0, 5)

        Dim FuncLines As String = ""
        For i As Integer = 0 To Z
            Dim CurrentLineText As String = ""
            Dim XY As Integer = Rn.Next(0, 8)
            Select Case XY
                Case 0
                    CurrentLineText = "Dim " & GenerateString() & " As String = " & """" & GenerateString() & """"
                Case 1
                    CurrentLineText = "Dim " & GenerateString() & " As Long = " & Long.Parse(Rn.Next(0, 1000))
                Case 2
                    CurrentLineText = "Dim " & GenerateString() & " As Integer = " & Integer.Parse(Rn.Next(0, 1000))
                Case 3
                    CurrentLineText = "Dim " & GenerateString() & " As Object = {}"
                Case 4
                    CurrentLineText = "Dim " & GenerateString() & " As Byte() = {}"
                Case 5
                    Dim TheName As String = GenerateString()

                    CurrentLineText = "Dim " & TheName & " As Boolean = False" & Environment.NewLine _
                    & "If " & TheName & " = True Then" & Environment.NewLine & "Debug.Print(" & """" & GenerateString() & """" & ")" & Environment.NewLine & "End If"
                Case 6
                    Dim TheName As String = GenerateString()
                    CurrentLineText = "Dim " & TheName & " As Boolean = True" & Environment.NewLine _
                    & "If " & TheName & " = False Then" & Environment.NewLine & "Debug.Print(" & """" & GenerateString() & """" & ")" & Environment.NewLine & "End If"
                Case 7
                    Dim Name As String = GenerateString()
                    CurrentLineText = "Dim " & Name & " As integer = 0" & Environment.NewLine & "For " & GenerateString() & " = 0 to 100" & Environment.NewLine _
                        & Name & " += 1" & Environment.NewLine & "Next"
            End Select
            FuncLines &= CurrentLineText & Environment.NewLine
        Next
        Return FuncLines
    End Function

    Function RandomFunction(ByVal FuncName As String, ByVal IsShared As Boolean)
        Dim Rn As New Random
        Dim Z As Integer = Rn.Next(3, 20)
        Dim Function_Type As String = ""
        If IsShared = True Then
            Function_Type = "Public Shared Function "
        Else
            Function_Type = "Public Function "
        End If
        Dim FuncLines As String = Function_Type & FuncName & "()" & Environment.NewLine
        For i As Integer = 0 To Z
            Dim CurrentLineText As String = ""
            Dim XY As Integer = Rn.Next(0, 8)
            Select Case XY
                Case 0
                    CurrentLineText = "Dim " & GenerateString() & " As String = " & """" & GenerateString() & """"
                Case 1
                    CurrentLineText = "Dim " & GenerateString() & " As Long = " & Long.Parse(Rn.Next(0, 1000))
                Case 2
                    CurrentLineText = "Dim " & GenerateString() & " As Integer = " & Integer.Parse(Rn.Next(0, 1000))
                Case 3
                    CurrentLineText = "Dim " & GenerateString() & " As Object = {}"
                Case 4
                    CurrentLineText = "Dim " & GenerateString() & " As Byte() = {}"
                Case 5
                    Dim TheName As String = GenerateString()
                    CurrentLineText = "Dim " & TheName & " As Boolean = False" & Environment.NewLine _
                    & "If " & TheName & " = True Then" & Environment.NewLine & "Msgbox(" & """" & GenerateString() & """" & ")" & Environment.NewLine & "End If"
                Case 6
                    Dim TheName As String = GenerateString()
                    CurrentLineText = "Dim " & TheName & " As Boolean = True" & Environment.NewLine _
                    & "If " & TheName & " = False Then" & Environment.NewLine & "Msgbox(" & """" & GenerateString() & """" & ")" & Environment.NewLine & "End If"
                Case 7
                    Dim Name As String = GenerateString()
                    CurrentLineText = "Dim " & Name & " As integer = 0" & Environment.NewLine & "For " & GenerateString() & " = 0 to 100" & Environment.NewLine _
                        & Name & " += 1" & Environment.NewLine & "Next"
            End Select
            FuncLines &= CurrentLineText & Environment.NewLine
        Next
        Return FuncLines & "Return " & """" & GenerateString() & """" & Environment.NewLine & "End Function"
    End Function

    Function RandomSub(ByVal FuncName As String, ByVal IsShared As Boolean)
        Dim Rn As New Random
        Dim Z As Integer = Rn.Next(3, 20)
        Dim Function_Type As String = ""
        If IsShared = True Then
            Function_Type = "Public Shared Sub "
        Else
            Function_Type = "Public Sub "
        End If
        Dim FuncLines As String = Function_Type & FuncName & "()" & Environment.NewLine
        For i As Integer = 0 To Z
            Dim CurrentLineText As String = ""
            Dim XY As Integer = Rn.Next(0, 10)
            Select Case XY
                Case 0
                    CurrentLineText = "Dim " & GenerateString() & " As String = " & """" & GenerateString() & """"
                Case 1
                    CurrentLineText = "Dim " & GenerateString() & " As Long = " & Long.Parse(Rn.Next(0, 1000))
                Case 2
                    CurrentLineText = "Dim " & GenerateString() & " As Integer = " & Integer.Parse(Rn.Next(0, 1000))
                Case 3
                    CurrentLineText = "Dim " & GenerateString() & " As Object = {}"
            End Select
            FuncLines &= CurrentLineText & Environment.NewLine
        Next
        Return FuncLines & Environment.NewLine & "End Sub"
    End Function
    Public Function RandomString(size As Integer, Optional validchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz") As String
        If size < 1 Or validchars.Length = 0 Then Return ""
        RandomString = ""
        Randomize()
        For i = 1 To size
            RandomString &= Mid(validchars, Int(Rnd() * validchars.Length) + 1, 1)
        Next
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clipboard.Clear()
        Clipboard.SetText(TextBox3.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'C:\windows\Microsoft.NET\Framework\v2.0.50727\vbc.exe yourfile.vb
    End Sub
End Class
