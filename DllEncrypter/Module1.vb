Module Module1
    Sub Main()
        Console.WriteLine("Drag/Drop dll")
        Dim Dll As String = Console.ReadLine
        Dll = Replace(Dll, """", "")
        Dim Path As String = Strings.Left(Dll, Dll.LastIndexOf("\") + 1)
        Dim Name As String = Replace(Dll, Path, "")
        Path = Path & "Enc\" & Name
        FileIO.FileSystem.WriteAllBytes(Path, Compress(AES_Encrypt(FileIO.FileSystem.ReadAllBytes(Dll))), False)
    End Sub

    Public Function Compress(bytes As Byte()) As Byte()
        Dim stream = New IO.MemoryStream()
        Dim zipStream = New IO.Compression.DeflateStream(stream, IO.Compression.CompressionMode.Compress, True)
        zipStream.Write(bytes, 0, bytes.Length)
        zipStream.Close()
        Return stream.ToArray()
    End Function

    Function AES_Encrypt(ByVal input() As Byte) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim encrypted() As Byte = DESEncrypter.TransformFinalBlock(input, 0, input.Length)
            Return encrypted
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Module
