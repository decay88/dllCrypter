'___________________________________________________________________________________________
' Module Name: CalculatorForm.vb
' Description: Provides an UI and funtionality that are found in Windows Calculator
' Author     : Raju.K
' Mail       : raju.kandasamy@gmail.com
'____________________________________________________________________________________________

' Enumerator to represent the active calculator operation
Public Enum OperatorType
    Addition = 0
    Subtraction = 1
    Multiplication = 2
    Division = 3
    Modulas = 4
    None = 5
End Enum
Public Class CalculatorForm
    'Intermediate Result buffer
    Private flastResult As String
    'To hold the active operation
    Private fActiveOperator As OperatorType
    'Control that is associated with the calculator drop-down
    Private fControl As Control
    'Boolean flag to check whether to add the key-ins or to restart the key-ins
    Private RestartText As Boolean
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Set default flags
        flastResult = "0"
        fActiveOperator = OperatorType.None
        RestartText = True
    End Sub
    ' Property that can be utilized to associate any control to Drop-Down calculator
    Public Property OwnerControl() As Control
        Get
            Return fControl
        End Get
        Set(ByVal value As Control)
            Me.fControl = value
        End Set
    End Property
    ' Procedure to reposition the drop-down calculator with respect to the associated control
    Private Sub RepositionCalc()
        Dim pt As Point
        Dim scrPt As Point
        pt = New Point(fControl.Left + fControl.Width, fControl.Top + fControl.Height)
        scrPt = New Point(fControl.FindForm().Left + pt.X, fControl.FindForm().Top + pt.Y + 30)
        CenterToScreen()
        Me.Location = scrPt
    End Sub
    ' Handle the key-ins
    Private Sub ProcessKey(ByVal KeyValue As Integer)
        Select Case KeyValue
            ' BackSpace
            Case 8
                If fControl.Text.Length > 0 Then
                    fControl.Text = fControl.Text.Substring(0, fControl.Text.Length - 1)
                    If fControl.Text.Length = 0 Then
                        fControl.Text = "0"
                    End If
                End If
                '0-9 in both numberic keypad and the main keyboard
            Case 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105
                If KeyValue > 57 Then
                    KeyValue = KeyValue - 48
                End If
                If Not RestartText Then
                    fControl.Text = fControl.Text & Chr(KeyValue)
                Else
                    flastResult = Val(fControl.Text)
                    fControl.Text = Chr(KeyValue)
                    RestartText = False
                End If
                ' +
            Case 43, 107
                If fActiveOperator <> OperatorType.None Then
                    ProcessResult()
                End If
                Me.fActiveOperator = OperatorType.Addition
                RestartText = True
                ' -
            Case 45, 109
                If fActiveOperator <> OperatorType.None Then
                    ProcessResult()
                End If
                Me.fActiveOperator = OperatorType.Subtraction
                RestartText = True
                ' *
            Case 42, 106
                If fActiveOperator <> OperatorType.None Then
                    ProcessResult()
                End If
                Me.fActiveOperator = OperatorType.Multiplication
                RestartText = True
                ' %
            Case 37
                If fActiveOperator <> OperatorType.None Then
                    ProcessResult()
                End If
                Me.fActiveOperator = OperatorType.Modulas
                RestartText = True
                ' /
            Case 47, 111
                If fActiveOperator <> OperatorType.None Then
                    ProcessResult()
                End If
                Me.fActiveOperator = OperatorType.Division
                RestartText = True
                ' Decimal Point
            Case 46, 110
                If fControl.Text.IndexOf(".") < 0 Then
                    fControl.Text = fControl.Text & "."
                End If
                ' Special code for SQRT (not associated with key-ins. Supplied programatically
            Case 251
                fControl.Text = Math.Sqrt(Val(fControl.Text))
                RestartText = True
                ' Special code for 1/x (not associated with key-ins. Supplied programatically
            Case 255
                If Val(fControl.Text) > 0 Then
                    fControl.Text = 1 / Val(fControl.Text)
                Else
                    MsgBox("Divide By Zero", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error")
                End If
                RestartText = True
                ' Special code for +/- (not associated with key-ins. Supplied programatically
            Case 241
                If Double.Parse(fControl.Text) > 0 Then
                    fControl.Text = "-" & fControl.Text
                Else
                    fControl.Text = Math.Abs(Val(fControl.Text))
                End If
                ' =
            Case 61, 187
                ProcessResult()
                ' ESC
            Case 27, 9
                ProcessResult()
                Me.Close()
                ' Unknown Keycode
            Case Else
                MsgBox(KeyValue & " is not recognized", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error")
        End Select
    End Sub

    ' Procedure to compute the result based on the active operator
    Private Sub ProcessResult()
        Select Case Me.fActiveOperator
            Case OperatorType.Addition
                fControl.Text = Val(flastResult) + Val(fControl.Text)
            Case OperatorType.Division
                If Val(fControl.Text) > 0 Then
                    fControl.Text = Val(flastResult) / Val(fControl.Text)
                Else
                    MsgBox("Divide By Zero", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error")
                End If
            Case OperatorType.Modulas
                fControl.Text = Val(flastResult) Mod Val(fControl.Text)
            Case OperatorType.Multiplication
                fControl.Text = Val(flastResult) * Val(fControl.Text)
            Case OperatorType.Subtraction
                fControl.Text = Val(flastResult) - Val(fControl.Text)
        End Select
        flastResult = Val(fControl.Text)
        fActiveOperator = OperatorType.None
        RestartText = True
    End Sub

    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        ProcessKey(55)

    End Sub

    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        ProcessKey(56)

    End Sub

    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        ProcessKey(57)

    End Sub

    Private Sub cmdDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDiv.Click
        ProcessKey(47)

    End Sub

    Private Sub cmdSqrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSqrt.Click
        ProcessKey(251)

    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        ProcessKey(52)

    End Sub

    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        ProcessKey(53)

    End Sub

    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        ProcessKey(54)

    End Sub

    Private Sub cmdMultiply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiply.Click
        ProcessKey(42)

    End Sub

    Private Sub cmdMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMod.Click
        ProcessKey(37)

    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        ProcessKey(49)

    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        ProcessKey(50)

    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        ProcessKey(51)

    End Sub

    Private Sub cmdMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMinus.Click
        ProcessKey(45)

    End Sub

    Private Sub cmdInverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInverse.Click
        ProcessKey(255)

    End Sub

    Private Sub cmd0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd0.Click
        ProcessKey(48)

    End Sub

    Private Sub cmdChangeSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeSign.Click
        ProcessKey(241)

    End Sub

    Private Sub cmdDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDot.Click
        ProcessKey(46)

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ProcessKey(43)

    End Sub

    Private Sub cmdEquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEquals.Click
        ProcessKey(61)

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        fControl.Text = "0"
        flastResult = 0
        fActiveOperator = OperatorType.None
        RestartText = True

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        fControl.Text = "0"
        RestartText = True

    End Sub

    Private Sub cmdBackSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackSpace.Click
        ProcessKey(8)
    End Sub

    Private Sub CalculatorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RepositionCalc()
    End Sub

    Private Sub CalculatorForm_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics
        g = e.Graphics
        Dim Bounds As Rectangle
        Bounds = Me.ClientRectangle
        Bounds.Width = Bounds.Width - 2
        Bounds.Height = Bounds.Height - 2
        g.DrawRectangle(Pens.Blue, Bounds)
    End Sub
    ' Capture and process the key since KeyPreview is true
    Private Sub CalculatorForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ProcessKey(e.KeyValue)
    End Sub
End Class