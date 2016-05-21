Public Class Form1
    Public Shared byts() As Byte
    Public Shared ResponseResult As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AllowDrop = True
        PictureBox1.Image = My.Resources.AVG
    End Sub
    Private Sub Form1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        Reset()
        Application.DoEvents()
        For Each path In files
            TextBox1.Text = path
        Next
        Application.DoEvents()
        ScanFile(TextBox1.Text)
    End Sub

    Private Sub Form1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Sub Upload()
        Using client As New WebClient 'Net.WebClient
            Dim fname() As String = Split(StrReverse(TextBox1.Text), "\")
            Dim reqparm As New Specialized.NameValueCollection
            reqparm.Add("api_key", "09afd7dc3ce77af1fd411515df093e57c6a406bb")
            reqparm.Add("check_type", "file")
            reqparm.Add("data", Convert.ToBase64String(byts))
            reqparm.Add("file_name", StrReverse(fname(0)))
            Application.DoEvents()
            '  reqparm.Add("file_name", "test.exe")
            Try
                Dim responsebytes = client.UploadValues("http://avdetect.com/api/", "POST", reqparm)
                Application.DoEvents()
                ResponseResult = (New System.Text.UTF8Encoding).GetString(responsebytes)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End Using
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Reset()
        With OpenFileDialog1
            .Title = "Select Program To Scan"
            .FileName = ""
            .ShowDialog()
            If OpenFileDialog1.FileName <> "" Then
                ScanFile(OpenFileDialog1.FileName)
            End If
        End With
    End Sub

    Sub ScanFile(ByRef FileName As String)
        TextBox1.Text = FileName
        Application.DoEvents()
        byts = FileIO.FileSystem.ReadAllBytes(FileName)
        Me.Text = "Exidous AV Checker Uploading (Please Wait)"
        Application.DoEvents()

        Dim t1 As New Threading.Thread(AddressOf Upload)
        t1.Start()
        Do Until t1.IsAlive = False
            Application.DoEvents()
        Loop
        Me.Text = "Exidous AV Checker"
        ParseResult(ResponseResult)
    End Sub

    Sub ParseResult(ByRef TheResult As String)
        On Error GoTo ExitFunction
        Dim x() As String = Split(TheResult, """" & "result" & """" & ":")
        x = Split(x(1), "}")
        x = Split(x(0), ",")
        Dim i As Integer = 0
        For Each y In x
            y = Replace(y, "{", "")
            y = Replace(y, """", "")
            y = Trim(y)
            If SetDetection(y) = True Then
                i += 1
            End If
            y = y
            If i = 0 Then
                GroupBox1.Text = "Antivirus Results: Detections:" & "Clean!!!"
                Application.DoEvents()
                ' GroupBox1.ForeColor = Color.Green
            Else
                GroupBox1.Text = "Antivirus Results: Detections:" & i
                Application.DoEvents()
                ' GroupBox1.ForeColor = Color.Red
            End If

            Application.DoEvents()
        Next

        If i = 0 Then
            GroupBox1.Text = "Antivirus Results: Detections:" & "0/39"
            Application.DoEvents()
            ' GroupBox1.ForeColor = Color.Green
        Else
            GroupBox1.Text = "Antivirus Results: Detections:" & i & "/39"
            Application.DoEvents()
            ' GroupBox1.ForeColor = Color.Red
        End If
        x = Split(ResponseResult, "link" & """" & ":")
        x = Split(x(2), ",")
        x(0) = Trim(Replace(x(0), """", ""))
        TextBox2.Text = x(0)
        Application.DoEvents()
ExitFunction:
    End Sub

    Sub Reset()
        'Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        ' Label5.Text = ""
        Label6.Text = ""
        'Label7.Text = ""
        Label8.Text = ""
        ' Label9.Text = ""
        Label10.Text = ""
        '  Label11.Text = ""
        Label12.Text = ""
        ' Label13.Text = ""
        Label14.Text = ""
        'Label15.Text = ""
        Label16.Text = ""
        'Label17.Text = ""
        Label18.Text = ""
        'Label19.Text = ""
        Label20.Text = ""
        'Label21.Text = ""
        Label22.Text = ""
        'Label23.Text = ""
        Label24.Text = ""
        'Label25.Text = ""
        Label26.Text = ""
        'Label27.Text = ""

        Label28.Text = ""
        'Label29.Text = ""
        Label30.Text = ""
        'Label31.Text = ""
        Label32.Text = ""
        'Label33.Text = ""
        Label34.Text = ""
        'Label35.Text = ""
        Label36.Text = ""
        'Label37.Text = ""
        Label38.Text = ""
        'Label39.Text = ""
        Label40.Text = ""
        'Label41.Text = ""
        Label42.Text = ""
        'Label43.Text = ""
        Label44.Text = ""
        'Label45.Text = ""
        Label46.Text = ""
        'Label47.Text = ""
        Label48.Text = ""
        'Label49.Text = ""
        Label50.Text = ""
        'Label51.Text = ""
        Label52.Text = ""
        'Label53.Text = ""
        Label54.Text = ""
        'Label55.Text = ""
        Label56.Text = ""
        'Label57.Text = ""

        Label58.Text = ""
        'Label59.Text = ""
        Label60.Text = ""
        'Label61.Text = ""
        Label62.Text = ""
        'Label63.Text = ""
        Label64.Text = ""
        'Label65.Text = ""
        Label66.Text = ""
        'Label67.Text = ""
        Label68.Text = ""
        'Label69.Text = ""
        Label70.Text = ""
        'Label71.Text = ""
        Label72.Text = ""
        'Label73.Text = ""
        Label74.Text = ""
        'Label75.Text = ""
        Label76.Text = ""
        'Label77.Text = ""
        Label78.Text = ""
        TextBox2.Text = ""
        'Label79.Text = ""
        GroupBox1.Text = "Antivirus Results"
    End Sub
    Function SetDetection(ByRef AVNAME As String)
        On Error GoTo exitFunction
        Dim x() As String = Split(AVNAME, ":", 2)

        If x(0) = ("virit") Then
            Label62.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label62, x(1))
            If Label62.Text = "OK" Then
                Label62.ForeColor = Color.Green
                Return False
            Else
                Label62.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("vipre") Then
            Label64.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label64, x(1))
            If Label64.Text = "OK" Then
                Label64.ForeColor = Color.Green
                Return False
            Else
                Label64.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("twister") Then
            Label66.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label66, x(1))
            If Label66.Text = "OK" Then
                Label66.ForeColor = Color.Green
                Return False
            Else
                Label66.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("trendmicro") Then
            Label68.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label68, x(1))
            If Label68.Text = "OK" Then
                Label68.ForeColor = Color.Green
                Return False
            Else
                Label68.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("sophos") Then
            Label70.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label70, x(1))
            If Label70.Text = "OK" Then
                Label70.ForeColor = Color.Green
                Return False
            Else
                Label70.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("se") Then
            Label72.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label72, x(1))
            If Label72.Text = "OK" Then
                Label72.ForeColor = Color.Green
                Return False
            Else
                Label72.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("sas") Then
            Label74.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label74, x(1))
            If Label74.Text = "OK" Then
                Label74.ForeColor = Color.Green
                Return False
            Else
                Label74.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("quickheal") Then
            Label42.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label42, x(1))
            If Label42.Text = "OK" Then
                Label42.ForeColor = Color.Green
                Return False
            Else
                Label42.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("panda") Then
            Label46.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label46, x(1))
            If Label46.Text = "OK" Then
                Label46.ForeColor = Color.Green
                Return False
            Else
                Label46.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("pandacl") Then
            Label44.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label44, x(1))
            If Label44.Text = "OK" Then
                Label44.ForeColor = Color.Green
                Return False
            Else
                Label44.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("outpost") Then
            Label48.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label48, x(1))
            If Label48.Text = "OK" Then
                Label48.ForeColor = Color.Green
                Return False
            Else
                Label48.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("norman") Then
            Label50.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label50, x(1))
            If Label50.Text = "OK" Then
                Label50.ForeColor = Color.Green
                Return False
            Else
                Label50.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("nod") Then
            Label52.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label52, x(1))
            If Label52.Text = "OK" Then
                Label52.ForeColor = Color.Green
                Return False
            Else
                Label52.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0) = ("nis") Then
            Label54.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label54, x(1))
            If Label54.Text = "OK" Then
                Label54.ForeColor = Color.Green
                Return False
            Else
                Label54.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("nano") Then
            Label56.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label56, x(1))
            If Label56.Text = "OK" Then
                Label56.ForeColor = Color.Green
                Return False
            Else
                Label56.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("mcafee") Then
            Label58.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label58, x(1))
            If Label58.Text = "OK" Then
                Label58.ForeColor = Color.Green
                Return False
            Else
                Label58.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("kis2013") Then
            Label60.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label60, x(1))
            If Label60.Text = "OK" Then
                Label60.ForeColor = Color.Green
                Return False
            Else
                Label60.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("k7") Then
            Label32.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label32, x(1))
            If Label32.Text = "OK" Then
                Label32.ForeColor = Color.Green
                Return False
            Else
                Label32.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("immunet") Then
            Label34.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label34, x(1))
            If Label34.Text = "OK" Then
                Label34.ForeColor = Color.Green
                Return False
            Else
                Label34.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("ikarus") Then
            Label36.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label36, x(1))
            If Label36.Text = "OK" Then
                Label36.ForeColor = Color.Green
                Return False
            Else
                Label36.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("gdata") Then
            Label38.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label38, x(1))
            If Label38.Text = "OK" Then
                Label38.ForeColor = Color.Green
                Return False
            Else
                Label38.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("fsecure") Then
            Label40.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label40, x(1))
            If Label40.Text = "OK" Then
                Label40.ForeColor = Color.Green
                Return False
            Else
                Label40.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("fprot") Then
            Label12.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label12, x(1))
            If Label12.Text = "OK" Then
                Label12.ForeColor = Color.Green
                Return False
            Else
                Label12.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("fortinet") Then
            Label14.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label14, x(1))
            If Label14.Text = "OK" Then
                Label14.ForeColor = Color.Green
                Return False
            Else
                Label14.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("escan") Then
            Label16.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label16, x(1))
            If Label16.Text = "OK" Then
                Label16.ForeColor = Color.Green
                Return False
            Else
                Label16.ForeColor = Color.Red
                Return True
            End If
        End If



        If x(0).Contains("drwebfile") Then
            Label18.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label18, x(1))
            If Label18.Text = "OK" Then
                Label18.ForeColor = Color.Green
                Return False
            Else
                Label18.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("deftot") Then
            Label20.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label20, x(1))
            If Label20.Text = "OK" Then
                Label20.ForeColor = Color.Green
                Return False
            Else
                Label20.ForeColor = Color.Red
                Return True
            End If
        End If



        If x(0).Contains("comodo") Then
            Label22.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label22, x(1))
            If Label22.Text = "OK" Then
                Label22.ForeColor = Color.Green
                Return False
            Else
                Label22.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("clamav") Then
            Label24.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label24, x(1))
            If Label24.Text = "OK" Then
                Label24.ForeColor = Color.Green
                Return False
            Else
                Label24.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("bullguard") Then
            Label26.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label26, x(1))
            If Label26.Text = "OK" Then
                Label26.ForeColor = Color.Green
                Return False
            Else
                Label26.ForeColor = Color.Red
                Return True
            End If
        End If



        If x(0).Contains("bitdef") Then
            Label28.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label28, x(1))
            If Label28.Text = "OK" Then
                Label28.ForeColor = Color.Green
                Return False
            Else
                Label28.ForeColor = Color.Red
                Return True
            End If
        End If



        If x(0).Contains("aware") Then
            Label30.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label30, x(1))
            If Label30.Text = "OK" Then
                Label30.ForeColor = Color.Green
                Return False
            Else
                Label30.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("avira") Then
            Label10.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label10, x(1))
            If Label10.Text = "OK" Then
                Label10.ForeColor = Color.Green
                Return False
            Else
                Label10.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("avast") Then
            Label8.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label8, x(1))
            If Label8.Text = "OK" Then
                Label8.ForeColor = Color.Green
                Return False
            Else
                Label8.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("avg") Then
            Label3.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label3, x(1))
            If Label3.Text = "OK" Then
                Label3.ForeColor = Color.Green
                Return False
            Else
                Label3.ForeColor = Color.Red
                Return True
            End If

        End If


        If x(0).Contains("ahnlab") Then
            Label4.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label4, x(1))
            If Label4.Text = "OK" Then
                Label4.ForeColor = Color.Green
                Return False
            Else
                Label4.ForeColor = Color.Red
                Return True
            End If
        End If


        If x(0).Contains("arcavir") Then
            Label6.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label6, x(1))
            If Label6.Text = "OK" Then
                Label6.ForeColor = Color.Green
                Return False
            Else
                Label6.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("nano") Then
            Label56.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label56, x(1))
            If Label56.Text = "OK" Then
                Label56.ForeColor = Color.Green
                Return False
            Else
                Label56.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("a2") Then 'asquared
            Label78.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label78, x(1))
            If Label78.Text = "OK" Then
                Label78.ForeColor = Color.Green
                Return False
            Else
                Label78.ForeColor = Color.Red
                Return True
            End If
        End If

        If x(0).Contains("vba") Then
            Label76.Text = Trim(x(1))
            Dim tt As New ToolTip
            tt.SetToolTip(Label76, x(1))
            If Label76.Text = "OK" Then
                Label76.ForeColor = Color.Green
                Return False
            Else
                Label76.ForeColor = Color.Red
                Return True
            End If
        End If

        '   MsgBox(x(0))
        '   MsgBox(x(1))
        '   Return "fuck"
exitFunction:
    End Function


End Class

Public Class WebClient
    Inherits System.Net.WebClient

    Private _TimeoutMS As Integer = 99999999

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal TimeoutMS As Integer)
        MyBase.New()
        _TimeoutMS = TimeoutMS
    End Sub
    ''' <summary>
    ''' Set the web call timeout in Milliseconds
    ''' </summary>
    ''' <value></value>
    Public WriteOnly Property setTimeout() As Integer
        Set(ByVal value As Integer)
            _TimeoutMS = value
        End Set
    End Property


    Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
        Dim w As System.Net.WebRequest = MyBase.GetWebRequest(address)
        If _TimeoutMS <> 0 Then
            w.Timeout = _TimeoutMS
        End If
        Return w  '<<< NOTICE: MyBase.GetWebRequest(address) DOES NOT WORK >>>
    End Function

End Class

