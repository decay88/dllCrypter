Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox5.Text = TextBox1.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Stub() As Byte = FileIO.FileSystem.ReadAllBytes(TextBox2.Text)
        Dim StubStr As String = Convert.ToBase64String(Stub)
        'insert user into database
        Dim WC As New System.Net.WebClient
        Dim Result As String = WRequest(TextBox5.Text, "POST", "add=true&license_key=" & TextBox3.Text & "&stub=" & StubStr & "&expire=" & TextBox4.Text)
        If Result.Contains("Error:") Then
            MsgBox("Failed!")
        End If
        If Result.Contains("success") Then
            MsgBox("Success!")
        End If
    End Sub

    Function WRequest(URL As String, method As String, POSTdata As String) As String
        Dim responseData As String = ""
        Try
            Dim cookieJar As New Net.CookieContainer()
            Dim hwrequest As Net.HttpWebRequest = Net.WebRequest.Create(URL)
            hwrequest.CookieContainer = cookieJar
            hwrequest.Accept = "*/*"
            hwrequest.AllowAutoRedirect = True
            hwrequest.UserAgent = "http_requester/0.1"
            hwrequest.Timeout = 60000
            hwrequest.Method = method
            If hwrequest.Method = "POST" Then
                hwrequest.ContentType = "application/x-www-form-urlencoded"
                Dim encoding As New Text.ASCIIEncoding() 'Use UTF8Encoding for XML requests
                Dim postByteArray() As Byte = encoding.GetBytes(POSTdata)
                hwrequest.ContentLength = postByteArray.Length
                Dim postStream As IO.Stream = hwrequest.GetRequestStream()
                postStream.Write(postByteArray, 0, postByteArray.Length)
                postStream.Close()
            End If
            Dim hwresponse As Net.HttpWebResponse = hwrequest.GetResponse()
            If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader =
        New IO.StreamReader(hwresponse.GetResponseStream())
                responseData = responseStream.ReadToEnd()
            End If
            hwresponse.Close()
        Catch e As Exception
            responseData = "An error occurred: " & e.Message
        End Try
        Return responseData
    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Stub() As Byte = FileIO.FileSystem.ReadAllBytes(TextBox7.Text)

        Dim StubStr As String = Hex2Str(Stub) ' Convert.ToBase64String(Stub)
        Dim Result As String = WRequest(TextBox1.Text, "POST", "update=true&license_key=" & TextBox6.Text & "&stub=" & StubStr)
        If Result.Contains("USER IS EXPIRED NEEDS MORE STUBS") Then
            MsgBox("User does not have any stubs left for updating, they need to pay! CHA CHING$")
        Else
            MsgBox("Success!")
        End If
    End Sub

    Function Hex2Str(ByVal Bytes() As Byte) As String
        Dim RetStr As String = ""
        For Each byt In Bytes
            Dim S As String = Hex(byt)
            If S.Length = 1 Then
                S = "0" & S
            End If
            RetStr &= S
        Next
        Return RetStr
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .Title = "Select Stub"
            .FileName = ""
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            TextBox7.Text = OFD.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .Title = "Select Stub"
            .FileName = ""
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            TextBox2.Text = OFD.FileName
        End If
    End Sub
End Class
