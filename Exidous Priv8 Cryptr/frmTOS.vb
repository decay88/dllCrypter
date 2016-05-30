Public Class frmTOS
    Public CrypterAgreement As Boolean = False
    Public BinderAgreement As Boolean = False
    Public DownloaderAgreement As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True Then
            If CrypterAgreement = True Then Form1.TOS = True
            If BinderAgreement = True Then Form1.BinderTOS = True
            If DownloaderAgreement = True Then Form1.DownloaderTOS = True
            Me.Close()
        Else
            MsgBox("You did not agree to the terms of service!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.TOS = False
        Me.Close()
    End Sub

    Private Sub frmTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class