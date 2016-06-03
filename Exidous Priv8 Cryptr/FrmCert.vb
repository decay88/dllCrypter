Imports System.IO
Imports System.Security.Cryptography.X509Certificates

Public Class FrmCert
    Dim TheSig() As Byte
    Public TheFileToSign As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button3.Enabled = False
        Dim OFD As New OpenFileDialog
        With OFD
            .Title = "Select digitally signed application or digital cert"
            .FileName = ""
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            TextBox1.Text = OFD.FileName
            If OFD.FileName.EndsWith(".cert") Then GoTo Process
            Dim Result As String = CheckSig()

            If Result = "INVALID" Then
                MsgBox("This file does not appear to be digitally signed!")
                Exit Sub
            End If
Process:
            ProcessFile()
            TextBox2.Text = TextBox2.Text & Result & Environment.NewLine
            Button3.Enabled = True
        End If
    End Sub

    Function CheckSig()
        Try
            Dim basicSigner As X509Certificate = X509Certificate.CreateFromSignedFile(TextBox1.Text)
            Dim cert As X509Certificate2 = New X509Certificate2(basicSigner)

            Dim S As String
            With cert
                S = "Issuer: " & .IssuerName.Name & vbNewLine & vbNewLine
                S = S & "Product: " & .SubjectName.Name & vbNewLine & vbNewLine
                S = S & "Thumbprint: " & .Thumbprint & vbNewLine & vbNewLine
                S = S & "Serial: " & .SerialNumber & vbNewLine & vbNewLine
                S = S & "Signed Date: " & .NotBefore & vbNewLine & vbNewLine
                S = S & "Expire Date: " & .NotAfter & vbNewLine & vbNewLine
                S = S & "Version: " & .Version & vbNewLine & vbNewLine
            End With
            Return (S)
        Catch ex As Exception
            Return ("INVALID")
        End Try
    End Function

    Function GetSignedName()
        Try
            Dim basicSigner As X509Certificate = X509Certificate.CreateFromSignedFile(TextBox1.Text)
            Dim cert As X509Certificate2 = New X509Certificate2(basicSigner)
            Return cert.SubjectName.Name
        Catch ex As Exception
            Return ("INVALID")
        End Try
    End Function

    Sub ProcessFile()
        Dim TheFile() As Byte = FileIO.FileSystem.ReadAllBytes(TextBox1.Text)
        If TextBox1.Text.EndsWith(".cert") Then TheSig = TheFile : GoTo Skip
        Dim AddressToPE As Integer
        Dim Found1 As Boolean = False
        Dim i As Integer = 0
        For Each Byt In TheFile
            If Found1 = True And Byt = &H45 Then
                AddressToPE = i - 1
                Exit For
            Else
                Found1 = False
            End If
            If Byt = &H50 Then Found1 = True
            i += 1
        Next
        Dim OutPutAddressToPE As String = Hex(AddressToPE)
        Do Until OutPutAddressToPE.Length = 8
            OutPutAddressToPE = "0" & OutPutAddressToPE
        Loop
        TextBox2.Text = "Address To PE: " & OutPutAddressToPE & Environment.NewLine
        'got the address to PE start, now lets count the bytes.
        Dim Prt1 As Byte = TheFile(AddressToPE + 4)
        Dim AddressToSection As Integer
        If Prt1 = &H4C Then
            'x32
            AddressToSection = AddressToPE + 152
        Else
            'x64
            AddressToSection = AddressToPE + 168
        End If

        Dim OutPutAddressToSection As String = Hex(AddressToSection)
        Do Until OutPutAddressToSection.Length = 8
            OutPutAddressToSection = "0" & OutPutAddressToSection
        Loop
        TextBox2.Text = TextBox2.Text & "Address To Securty Section: " & OutPutAddressToSection & Environment.NewLine
        Dim Part1 As Integer = TheFile(AddressToSection + 3)
        Dim Part2 As Integer = TheFile(AddressToSection + 2)
        Dim Part3 As Integer = TheFile(AddressToSection + 1)
        Dim Part4 As Integer = TheFile(AddressToSection)

        Dim HexStr As String = FixHex(Hex(Part1)) & FixHex(Hex(Part2)) & FixHex(Hex(Part3)) & FixHex(Hex(Part4))
        Dim OffsetToSignature As Integer = CInt("&H" & HexStr)

        TextBox2.Text &= "Address To Digital Cert: " & HexStr & Environment.NewLine

        Part1 = TheFile(AddressToSection + 7)
        Part2 = TheFile(AddressToSection + 6)
        Part3 = TheFile(AddressToSection + 5)
        Part4 = TheFile(AddressToSection + 4)
        HexStr = FixHex(Hex(Part1)) & FixHex(Hex(Part2)) & FixHex(Hex(Part3)) & FixHex(Hex(Part4))

        TextBox2.Text &= "Size of Digital Cert: " & HexStr & Environment.NewLine
        Dim SignatureSize As Integer = CInt("&H" & HexStr)
        Dim Signature(0 To SignatureSize - 1) As Byte
        For i = 0 To SignatureSize - 1
            Signature(i) = TheFile(OffsetToSignature + i)
        Next
        TextBox2.Text = TextBox2.Text & "Grabbed Cert Successfully!" & Environment.NewLine
        TheSig = Signature
Skip:
        'FileIO.FileSystem.WriteAllBytes("C:\Users\Exidous\Desktop\Signatures\" & GetSignedName() & ".sig", Signature, False)
    End Sub

    Function FixHex(ByVal Input As String) As String
        If Input.Length = 1 Then
            Return "0" & Input
        Else
            Return Input
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim SFD As New SaveFileDialog
        With SFD
            .Title = "Save Digital Cert"
            .FileName = "DigitalCert.cert"
            .ShowDialog()
        End With

        If SFD.FileName.EndsWith(".cert") Then
            FileIO.FileSystem.WriteAllBytes(SFD.FileName, TheSig, False)
        Else
            FileIO.FileSystem.WriteAllBytes(SFD.FileName & ".cert", TheSig, False)
        End If
        MsgBox("Saved digital Cert!")
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TheBinToSign() As Byte = FileIO.FileSystem.ReadAllBytes(TheFileToSign)
        Dim TheCert() As Byte = TheSig

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
        '  TextBox2.Text = TextBox2.Text & "Address To Securty Section: " & Hex(AddressToSection) & Environment.NewLine
        FileIO.FileSystem.WriteAllBytes(TheFileToSign, NewBin, False)
        Me.Close()
    End Sub
End Class
