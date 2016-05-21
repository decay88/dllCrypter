Imports System.IO
Imports System.CodeDom.Compiler
Imports System.ComponentModel

Public Class FormASM

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = ofd.FileName
        Else
            MessageBox.Show("Please select a valid file!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        If File.Exists(Application.StartupPath & "\res.exe") Then
            File.Delete(Application.StartupPath & "\res.exe")
        End If
        If File.Exists(Application.StartupPath & "\assemblychange.res") Then
            File.Delete(Application.StartupPath & "\assemblychange.res")
        End If
        System.IO.File.WriteAllBytes(Application.StartupPath & "\res.exe", My.Resources.Res)
        Dim source As String = My.Resources.String1
        If File.Exists(Application.StartupPath & "\assemblychange.exe") Then
            File.Delete(Application.StartupPath & "\assemblychange.exe")
        End If
        Dim Version = New Collections.Generic.Dictionary(Of String, String) : Version.Add("CompilerVersion", "v2.0")
        Dim Compiler As VBCodeProvider = New VBCodeProvider(Version)
        Dim cResults As CompilerResults
        Dim Settings As New CompilerParameters()
        With Settings
            .GenerateExecutable = True
            .OutputAssembly = Application.StartupPath & "\assemblychange.exe"
            .CompilerOptions = "/target:winexe"
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            .MainClass = "X"
        End With
        source = source.Replace("*Title*", TextBox2.Text)
        source = source.Replace("*Description*", TextBox3.Text)
        source = source.Replace("*Company*", TextBox4.Text)
        source = source.Replace("*Product*", TextBox5.Text)
        source = source.Replace("*Copyright*", TextBox6.Text)
        source = source.Replace("*Trademark*", TextBox7.Text)
        source = source.Replace("*version*", NumericUpDown1.Value.ToString & "." & NumericUpDown2.Value.ToString & "." & NumericUpDown3.Value.ToString & "." & NumericUpDown4.Value.ToString)
        source = source.Replace("*fversion*", NumericUpDown5.Value.ToString & "." & NumericUpDown6.Value.ToString & "." & NumericUpDown7.Value.ToString & "." & NumericUpDown8.Value.ToString)
        cResults = Compiler.CompileAssemblyFromSource(Settings, source)
        If cResults.Errors.Count > 0 Then
            For Each CompilerError In cResults.Errors
                MessageBox.Show("Error: " & CompilerError.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Next
            If File.Exists(Application.StartupPath & "\res.exe") = True Then
                File.Delete(Application.StartupPath & "\res.exe")
            End If
            If File.Exists(Application.StartupPath & "\res.log") = True Then
                File.Delete(Application.StartupPath & "\res.log")
            End If
            If File.Exists(Application.StartupPath & "\res.ini") = True Then
                File.Delete(Application.StartupPath & "\res.ini")
            End If
            If File.Exists(Application.StartupPath & "\assemblychange.exe") Then
                File.Delete(Application.StartupPath & "\assemblychange.exe")
            End If
            If File.Exists(Application.StartupPath & "\assemblychange.res") Then
                File.Delete(Application.StartupPath & "\assemblychange.res")
            End If
            MessageBox.Show("An error occurred. The assembly was not changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim otherfile As String = Application.StartupPath & "\assemblychange.exe"
        Dim resfile As String = Application.StartupPath & "\assemblychange.res"
        Dim mainfile As String = TextBox1.Text
        '  Shell(System.AppDomain.CurrentDomain.BaseDirectory() & "res.exe -extract " & otherfile & "," & resfile & ",VERSIONINFO,,")
        Process.Start(System.AppDomain.CurrentDomain.BaseDirectory() & "res.exe", "-extract " & otherfile & "," & resfile & ",VERSIONINFO,,").WaitForExit()
        ' Shell(System.AppDomain.CurrentDomain.BaseDirectory() & "res.exe -delete " & mainfile & "," & System.AppDomain.CurrentDomain.BaseDirectory() + "res.exe" & ",VERSIONINFO,,")
        Process.Start(System.AppDomain.CurrentDomain.BaseDirectory() & "res.exe", "-delete " & mainfile & "," & System.AppDomain.CurrentDomain.BaseDirectory() + "res.exe" & ",VERSIONINFO,,").WaitForExit()
        ' Shell(System.AppDomain.CurrentDomain.BaseDirectory() & "res.exe -addoverwrite " & mainfile & "," & mainfile & "," & resfile & ",VERSIONINFO,1,")
        Process.Start(System.AppDomain.CurrentDomain.BaseDirectory() & "res.exe", "-addoverwrite " & mainfile & "," & mainfile & "," & resfile & ",VERSIONINFO,1,").WaitForExit()

        If File.Exists(Application.StartupPath & "\assemblychange.exe") Then
            File.Delete(Application.StartupPath & "\assemblychange.exe")
        End If
        If File.Exists(Application.StartupPath & "\assemblychange.res") Then
            File.Delete(Application.StartupPath & "\assemblychange.res")
        End If
        If File.Exists(Application.StartupPath & "\res.exe") = True Then
            File.Delete(Application.StartupPath & "\res.exe")
        End If
        If File.Exists(Application.StartupPath & "\res.log") = True Then
            File.Delete(Application.StartupPath & "\res.log")
        End If
        If File.Exists(Application.StartupPath & "\res.ini") = True Then
            File.Delete(Application.StartupPath & "\res.ini")
        End If

        If Icon.Text = vbNullString Then
            MsgBox("Icon Is Required <3")
        Else
            IconChanger.InjectIcon(mainfile, Icon.Text)
        End If
        '  MessageBox.Show("The assembly has been changed successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        NumericUpDown1.Text = keyc1.Key1()
        NumericUpDown2.Text = keyc1.Key1()
        NumericUpDown3.Text = keyc1.Key1()
        NumericUpDown4.Text = keyc1.Key1()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        NumericUpDown5.Text = keyc1.Key1()
        NumericUpDown6.Text = keyc1.Key1()
        NumericUpDown7.Text = keyc1.Key1()
        NumericUpDown8.Text = keyc1.Key1()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox2.Text = keyc.Key()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TextBox3.Text = keyc.Key()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox4.Text = keyc.Key()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TextBox5.Text = keyc.Key()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        TextBox6.Text = keyc.Key()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        TextBox7.Text = keyc.Key()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ooo As New OpenFileDialog
        ooo.DefaultExt = "ico"
        ooo.Filter = "Icon Files (*.ico*)|*.ico*"
        ooo.FilterIndex = 1
        ooo.FileName = ""
        If ooo.ShowDialog(Me) = 1 Then
            Icon.Text = ooo.FileName
        End If
        Icon.Text = ooo.FileName
        Dim i As New Icon(ooo.FileName)
        Dim b As New Bitmap(i.ToBitmap)
        IconPicBox.Image = b
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox2.Text = keyc.Key()
        TextBox3.Text = keyc.Key()
        TextBox4.Text = keyc.Key()
        TextBox5.Text = keyc.Key()
        TextBox6.Text = keyc.Key()
        TextBox7.Text = keyc.Key()

        NumericUpDown1.Text = keyc1.Key1()
        NumericUpDown2.Text = keyc1.Key1()
        NumericUpDown3.Text = keyc1.Key1()
        NumericUpDown4.Text = keyc1.Key1()

        NumericUpDown5.Text = keyc1.Key1()
        NumericUpDown6.Text = keyc1.Key1()
        NumericUpDown7.Text = keyc1.Key1()
        NumericUpDown8.Text = keyc1.Key1()
    End Sub


End Class