Imports System.Runtime.InteropServices
Imports System.Security

Public Class FrmClone
    Public Function GetByteArrayFromIcon(ByVal icoSource As Icon) As Byte()

        Dim byteArray As Byte()
        Using msIcon As New System.IO.MemoryStream
            icoSource.Save(msIcon)
            byteArray = msIcon.ToArray
        End Using
        Return byteArray
    End Function

    Public Sub SaveFileInfoTo(ByVal FileName As String, ByVal data As Byte())
        ' Dim hUpdate As IntPtr = BeginUpdateResource(FileName, False)
        Dim hUpdate As IntPtr = DynamicInvokeDll.Invoke("kernel32", "BeginUpdateResource", New Object() {FileName, False}, GetType(IntPtr))
        ' If (hUpdate = IntPtr.Zero) Then MsgBox("error") ' Throw New Win32Exception(Marshal.GetLastWin32Error)

        'If Not UpdateResource(hUpdate, 16, 1, 0, data, data.Length) Then MsgBox("Error") 'Throw New Win32Exception(Marshal.GetLastWin32Error)
        Dim f = DynamicInvokeDll.Invoke("kernel32", "UpdateResource", New Object() {hUpdate, 16, 1, 0, data, data.Length}, GetType(Integer))
        ' If Not EndUpdateResource(hUpdate, False) Then MsgBox("Error") 'Throw New Win32Exception(Marshal.GetLastWin32Error)
        Dim ff = DynamicInvokeDll.Invoke("kernel32", "EndUpdateResource", New Object() {hUpdate, False}, GetType(Integer))
        If f = 0 Or ff = 0 Then
            MsgBox("Assembly Cloning Failed :(")
        Else

        End If
    End Sub

    Function LoadFileInfoFrom(ByVal FileName As String) As Byte()
        ' Dim ret As IntPtr = LoadLibraryEx(FileName, 0, 3)
        'Private Shared Function LoadLibraryEx(lpFileName As String, hReservedNull As IntPtr, dwFlags As LoadLibraryFlags) As IntPtr
        Dim ret As IntPtr = DynamicInvokeDll.Invoke("kernel32", "LoadLibraryEx", New Object() {FileName, 0, 3}, GetType(IntPtr))
        ' If ret = 0 Then MsgBox("Error")
        Dim hglob As IntPtr = Marshal.StringToHGlobalUni("#1")
        ' Dim hres As IntPtr = FindResource(ret, hglob, New IntPtr(16))
        Dim hres As IntPtr = DynamicInvokeDll.Invoke("kernel32", "FindResource", New Object() {ret, hglob, New IntPtr(16)}, GetType(IntPtr))
        'If hres = 0 Then MsgBox("Error") 'Throw New Win32Exception(Marshal.GetLastWin32Error) Else Marshal.FreeHGlobal(hglob)
        ' Dim fRes As IntPtr = LoadResource(ret, hres)
        Dim fRes As IntPtr = DynamicInvokeDll.Invoke("kernel32", "LoadResource", New Object() {ret, hres}, GetType(IntPtr))
        'If fRes = 0 Then MsgBox("error") 'Throw New Win32Exception(Marshal.GetLastWin32Error)
        'Dim lRes As IntPtr = LockResource(fRes)
        Dim lRes As IntPtr = DynamicInvokeDll.Invoke("kernel32", "LockResource", New Object() {fRes}, GetType(IntPtr))
        'If lRes = 0 Then MsgBox("error") ' Throw New Win32Exception(Marshal.GetLastWin32Error)
        ' Dim szSize As Integer = SizeofResource(ret, hres)
        Dim szSize As Integer = DynamicInvokeDll.Invoke("kernel32", "SizeofResource", New Object() {ret, hres}, GetType(Integer))
        'If szSize = 0 Then MsgBox("error") ' Throw New Win32Exception(Marshal.GetLastWin32Error)
        Dim info(szSize - 1) As Byte
        If szSize = 0 Then Return {&H0}
        Marshal.Copy(lRes, info, 0, szSize)
        DynamicInvokeDll.Invoke("kernel32", "FreeLibrary", New Object() {ret}, GetType(IntPtr))
        '  FreeLibrary(ret)
        Return info
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .Title = "Select File To Clone"
            .FileName = ""
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            TextBox1.Text = OFD.FileName
            Dim smallIcon As Icon = IconExtract.ExtractIconFromExe(TextBox1.Text, True)
            '   Dim largeIcon As Icon = IconTools.GetIconForExtension(".html", ShellIconSize.LargeIcon)

            FileIO.FileSystem.WriteAllBytes("tmp.ico", GetByteArrayFromIcon(smallIcon), True)
            Icon.Text = Application.StartupPath & "\tmp.ico"
            Dim b As New Bitmap(smallIcon.ToBitmap)
            IconPicBox.Image = b
            '

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .Title = "Select File To Inject"
            .FileName = ""
            .ShowDialog()
        End With
        If OFD.FileName <> "" Then
            TextBox2.Text = OFD.FileName
            '

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim BinInfo() As Byte = LoadFileInfoFrom(TextBox1.Text)
        If BinInfo.Length = 1 Then MsgBox("file Clone Failed") : Exit Sub

        '  FileIO.FileSystem.CopyFile(TextBox2.Text, TextBox2.Text & "_Clone.exe")
        SaveFileInfoTo(TextBox2.Text, BinInfo)
        Me.Close()
        'Icon
        Dim smallIcon As Icon = IconExtract.ExtractIconFromExe(TextBox1.Text, True)
        '   Dim largeIcon As Icon = IconTools.GetIconForExtension(".html", ShellIconSize.LargeIcon)

        FileIO.FileSystem.WriteAllBytes("tmp.ico", GetByteArrayFromIcon(smallIcon), True)
        'IconInjector.InjectIcon(TextBox2.Text, "tmp.ico")
        'IconInjector.InjectIcon(TextBox2.Text, Icon.Text)
        IconChanger.InjectIcon(TextBox2.Text, Icon.Text)
        FileIO.FileSystem.DeleteFile("tmp.ico")
        Me.Close()
        ' MsgBox("Saved as: " & TextBox2.Text & "_Clone.exe")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ooo As New OpenFileDialog
        ooo.DefaultExt = "ico"
        ooo.Filter = "Icon Files (*.ico*)|*.ico*"
        ooo.FilterIndex = 1
        ooo.FileName = ""
        If ooo.ShowDialog(Me) = 1 Then
            Icon.Text = ooo.FileName
        End If
        Icon.Text = ooo.FileName
        Dim i As New Icon(ooo.FileName)
        Dim b As New Bitmap(i.ToBitmap)
        IconPicBox.Image = b
    End Sub
End Class

Public Class IconInjector

    ' Basically, you can change icons with the UpdateResource api call.
    ' When you make the call you say "I'm updating an icon", and you send the icon data.
    ' The main problem is that ICO files store the icons in one set of structures, and exe/dll files store them in
    ' another set of structures. So you have to translate between the two -- you can't just load the ICO file as
    ' bytes and send them with the UpdateResource api call.

    <SuppressUnmanagedCodeSecurity()>
    Private Class NativeMethods
        <DllImport("kernel32")>
        Public Shared Function BeginUpdateResource(
    ByVal fileName As String,
    <MarshalAs(UnmanagedType.Bool)> ByVal deleteExistingResources As Boolean) As IntPtr
        End Function

        <DllImport("kernel32")>
        Public Shared Function UpdateResource(
    ByVal hUpdate As IntPtr,
    ByVal type As IntPtr,
    ByVal name As IntPtr,
    ByVal language As Short,
    <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=5)>
    ByVal data() As Byte,
    ByVal dataSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("kernel32")>
        Public Shared Function EndUpdateResource(
    ByVal hUpdate As IntPtr,
    <MarshalAs(UnmanagedType.Bool)> ByVal discard As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
    End Class

    ' The first structure in an ICO file lets us know how many images are in the file.
    <StructLayout(LayoutKind.Sequential)>
    Private Structure ICONDIR
        Public Reserved As UShort  ' Reserved, must be 0
        Public Type As UShort  ' Resource type, 1 for icons.
        Public Count As UShort  ' How many images.
        ' The native structure has an array of ICONDIRENTRYs as a final field.
    End Structure

    ' Each ICONDIRENTRY describes one icon stored in the ico file. The offset says where the icon image data
    ' starts in the file. The other fields give the information required to turn that image data into a valid
    ' bitmap.
    <StructLayout(LayoutKind.Sequential)>
    Private Structure ICONDIRENTRY
        Public Width As Byte    ' Width, in pixels, of the image
        Public Height As Byte  ' Height, in pixels, of the image
        Public ColorCount As Byte  ' Number of colors in image (0 if >=8bpp)
        Public Reserved As Byte  ' Reserved ( must be 0)
        Public Planes As UShort  ' Color Planes
        Public BitCount As UShort  ' Bits per pixel
        Public BytesInRes As Integer   ' Length in bytes of the pixel data
        Public ImageOffset As Integer  ' Offset in the file where the pixel data starts.
    End Structure

    ' Each image is stored in the file as an ICONIMAGE structure:
    'typdef struct
    '{
    '   BITMAPINFOHEADER   icHeader;  // DIB header
    '   RGBQUAD  icColors[1];   // Color table
    '   BYTE    icXOR[1];  // DIB bits for XOR mask
    '   BYTE    icAND[1];  // DIB bits for AND mask
    '} ICONIMAGE, *LPICONIMAGE;

    <StructLayout(LayoutKind.Sequential)>
    Private Structure BITMAPINFOHEADER
        Public Size As UInteger
        Public Width As Integer
        Public Height As Integer
        Public Planes As UShort
        Public BitCount As UShort
        Public Compression As UInteger
        Public SizeImage As UInteger
        Public XPelsPerMeter As Integer
        Public YPelsPerMeter As Integer
        Public ClrUsed As UInteger
        Public ClrImportant As UInteger
    End Structure

    ' The icon in an exe/dll file is stored in a very similar structure:
    <StructLayout(LayoutKind.Sequential, Pack:=2)>
    Private Structure GRPICONDIRENTRY
        Public Width As Byte
        Public Height As Byte
        Public ColorCount As Byte
        Public Reserved As Byte
        Public Planes As UShort
        Public BitCount As UShort
        Public BytesInRes As Integer
        Public ID As UShort
    End Structure

    Public Shared Sub InjectIcon(ByVal exeFileName As String, ByVal iconFileName As String)
        InjectIcon(exeFileName, iconFileName, 1, 1)
    End Sub

    Public Shared Sub InjectIcon(ByVal exeFileName As String, ByVal iconFileName As String, ByVal iconGroupID As UInteger, ByVal iconBaseID As UInteger)
        Const RT_ICON = 3UI
        Const RT_GROUP_ICON = 14UI
        Dim iconFile As IconFile = IconFile.FromFile(iconFileName)
        Dim hUpdate = NativeMethods.BeginUpdateResource(exeFileName, False)
        Dim data = iconFile.CreateIconGroupData(iconBaseID)
        NativeMethods.UpdateResource(hUpdate, New IntPtr(RT_GROUP_ICON), New IntPtr(iconGroupID), 0, data, data.Length)
        For i = 0 To iconFile.ImageCount - 1
            Dim image = iconFile.ImageData(i)
            NativeMethods.UpdateResource(hUpdate, New IntPtr(RT_ICON), New IntPtr(iconBaseID + i), 0, image, image.Length)
        Next
        NativeMethods.EndUpdateResource(hUpdate, False)
    End Sub

    Private Class IconFile

        Private iconDir As New ICONDIR
        Private iconEntry() As ICONDIRENTRY
        Private iconImage()() As Byte

        Public ReadOnly Property ImageCount() As Integer
            Get
                Return iconDir.Count
            End Get
        End Property

        Public ReadOnly Property ImageData(ByVal index As Integer) As Byte()
            Get
                Return iconImage(index)
            End Get
        End Property

        Private Sub New()
        End Sub

        Public Shared Function FromFile(ByVal filename As String) As IconFile
            Dim instance As New IconFile
            ' Read all the bytes from the file.
            Dim fileBytes() As Byte = IO.File.ReadAllBytes(filename)
            ' First struct is an ICONDIR
            ' Pin the bytes from the file in memory so that we can read them.
            ' If we didn't pin them then they could move around (e.g. when the
            ' garbage collector compacts the heap)
            Dim pinnedBytes = GCHandle.Alloc(fileBytes, GCHandleType.Pinned)
            ' Read the ICONDIR
            instance.iconDir = DirectCast(Marshal.PtrToStructure(pinnedBytes.AddrOfPinnedObject, GetType(ICONDIR)), ICONDIR)
            ' which tells us how many images are in the ico file. For each image, there's a ICONDIRENTRY, and associated pixel data.
            instance.iconEntry = New ICONDIRENTRY(instance.iconDir.Count - 1) {}
            instance.iconImage = New Byte(instance.iconDir.Count - 1)() {}
            ' The first ICONDIRENTRY will be immediately after the ICONDIR, so the offset to it is the size of ICONDIR
            Dim offset = Marshal.SizeOf(instance.iconDir)
            ' After reading an ICONDIRENTRY we step forward by the size of an ICONDIRENTRY    
            Dim iconDirEntryType = GetType(ICONDIRENTRY)
            Dim size = Marshal.SizeOf(iconDirEntryType)
            For i = 0 To instance.iconDir.Count - 1
                ' Grab the structure.
                Dim entry = DirectCast(Marshal.PtrToStructure(New IntPtr(pinnedBytes.AddrOfPinnedObject.ToInt64 + offset), iconDirEntryType), ICONDIRENTRY)
                instance.iconEntry(i) = entry
                ' Grab the associated pixel data.
                instance.iconImage(i) = New Byte(entry.BytesInRes - 1) {}
                Buffer.BlockCopy(fileBytes, entry.ImageOffset, instance.iconImage(i), 0, entry.BytesInRes)
                offset += size
            Next
            pinnedBytes.Free()
            Return instance
        End Function

        Public Function CreateIconGroupData(ByVal iconBaseID As UInteger) As Byte()
            ' This will store the memory version of the icon.
            Dim sizeOfIconGroupData As Integer = Marshal.SizeOf(GetType(ICONDIR)) + Marshal.SizeOf(GetType(GRPICONDIRENTRY)) * ImageCount
            Dim data(sizeOfIconGroupData - 1) As Byte
            Dim pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned)
            Marshal.StructureToPtr(iconDir, pinnedData.AddrOfPinnedObject, False)
            Dim offset = Marshal.SizeOf(iconDir)
            For i = 0 To ImageCount - 1
                Dim grpEntry As New GRPICONDIRENTRY
                Dim bitmapheader As New BITMAPINFOHEADER
                Dim pinnedBitmapInfoHeader = GCHandle.Alloc(bitmapheader, GCHandleType.Pinned)
                Marshal.Copy(ImageData(i), 0, pinnedBitmapInfoHeader.AddrOfPinnedObject, Marshal.SizeOf(GetType(BITMAPINFOHEADER)))
                pinnedBitmapInfoHeader.Free()
                grpEntry.Width = iconEntry(i).Width
                grpEntry.Height = iconEntry(i).Height
                grpEntry.ColorCount = iconEntry(i).ColorCount
                grpEntry.Reserved = iconEntry(i).Reserved
                grpEntry.Planes = bitmapheader.Planes
                grpEntry.BitCount = bitmapheader.BitCount
                grpEntry.BytesInRes = iconEntry(i).BytesInRes
                grpEntry.ID = CType(iconBaseID + i, UShort)
                Marshal.StructureToPtr(grpEntry, New IntPtr(pinnedData.AddrOfPinnedObject.ToInt64 + offset), False)
                offset += Marshal.SizeOf(GetType(GRPICONDIRENTRY))
            Next
            pinnedData.Free()
            Return data
        End Function


    End Class

End Class