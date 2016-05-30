Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel


''' <summary>
''' Angel Theme Coded by
''' Earn from HackForums.net
''' </summary>
''' <remarks></remarks>


#Region " Enums "
Enum MouseState
    None = 0
    Over = 1
    Down = 2
End Enum

Enum Alignment
    Left = 0
    Centre = 1
    Right = 2
End Enum

Enum State
    Enabled = 0
    Disabled = 1
End Enum
#End Region

Class AngelTheme
    Inherits ContainerControl

#Region " Back End "

#Region " Declarations "
    Private H As Integer = 52
    Private D As Boolean = False
    Private P As Point
    Private A As Alignment = Alignment.Left
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        D = False
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If New Rectangle(0, 0, Width, H).Contains(e.Location) AndAlso e.Button = System.Windows.Forms.MouseButtons.Left Then
            P = e.Location
            D = True
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If D = True Then
            ParentForm.Location = MousePosition - P
        End If
    End Sub

#End Region

#Region " Properties "

#Region " Appearance "
    <Category("Appearance")>
    Public Property TextAlignment() As Alignment
        Get
            Return A
        End Get
        Set(ByVal value As Alignment)
            A = value
            Invalidate()
        End Set
    End Property

#End Region

#End Region

#Region " Misc "

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        FindForm.AllowTransparency = True
        FindForm.TransparencyKey = Color.Fuchsia
        FindForm.FormBorderStyle = FormBorderStyle.None
        BackColor = Color.FromArgb(17, 33, 47)
        Dock = DockStyle.Fill
        Font = New Font("Segoe UI", 12)
        Invalidate()
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.Black)
        G.DrawRectangle(New Pen(Color.FromArgb(10, 33, 55)), New Rectangle(0, 0, Width - 1, H))
        G.FillRectangle(New LinearGradientBrush(New Point(1, 1), New Point(1, H), Color.FromArgb(75, 168, 218), Color.FromArgb(33, 112, 177)), New Rectangle(1, 1, Width - 2, H - 1))
        G.FillRectangle(New LinearGradientBrush(New Point(2, 2), New Point(2, H - 1), Color.FromArgb(54, 131, 203), Color.FromArgb(26, 86, 145)), New Rectangle(2, 2, Width - 4, H - 3))
        G.DrawRectangle(New Pen(Color.FromArgb(27, 48, 66)), New Rectangle(1, H + 1, Width - 3, Height - H - 3))
        G.FillRectangle(New SolidBrush(Color.FromArgb(17, 33, 47)), New Rectangle(2, H + 1, Width - 4, Height - H - 3))

        Dim F As New StringFormat With {.LineAlignment = StringAlignment.Center}
        Select Case A
            Case Alignment.Left
                G.DrawString(Text, Font, Brushes.White, New Rectangle(8, 0, Width, H), F)
            Case Alignment.Centre
                F.Alignment = StringAlignment.Center
                G.DrawString(Text, Font, Brushes.White, New Rectangle(0, 0, Width - 1, H), F)
            Case Alignment.Right
                G.DrawString(Text, Font, Brushes.White, New Rectangle(Width - TextRenderer.MeasureText(Text, Font).Width - 8, 0, TextRenderer.MeasureText(Text, Font).Width + 8, H), F)
        End Select

    End Sub

End Class

Class AngelControlBox
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private S As MouseState = MouseState.None
    Private C As State = State.Enabled
    Private M As State = State.Enabled
    Private X As Integer
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        S = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        S = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        If X <= 24 Then
            FindForm.WindowState = FormWindowState.Minimized
        Else
            Application.Exit()
        End If
    End Sub

#End Region

#Region " Misc "

    Sub New()
        Size = New Size(52, 23)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(52, 23)
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.Black)
        G.FillRectangle(New LinearGradientBrush(New Point(1, 1), New Point(1, Height - 1), Color.FromArgb(53, 79, 109), Color.FromArgb(24, 46, 69)), New Rectangle(1, 1, Width - 2, Height - 2))
        G.DrawRectangle(New Pen(Color.FromArgb(30, Color.White)), New Rectangle(1, 1, Width - 3, Height - 3))
        G.DrawLine(Pens.Black, New Point(25, 0), New Point(25, Height))
        G.DrawLine(New Pen(Color.FromArgb(30, Color.White)), New Point(26, 2), New Point(26, Height - 3))
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(Width - 1, Height - 1, 1, 1))
        Select Case S
            Case MouseState.Over
                If X <= 24 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), New Rectangle(1, 1, 24, Height - 2))
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), New Rectangle(26, 1, 25, Height - 2))
                End If
            Case MouseState.Down
                If X <= 24 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(75, Color.Black)), New Rectangle(1, 1, 24, Height - 2))
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(75, Color.Black)), New Rectangle(26, 1, 25, Height - 2))
                End If
        End Select
        Dim F As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        G.DrawString("r", New Font("Marlett", 9), Brushes.White, New Rectangle(27, 1, 25, Height - 2), F)
        G.DrawString("0", New Font("Marlett", 9), Brushes.White, New Rectangle(3, 1, 24, Height - 3), F)
    End Sub
End Class

Class AngelButton
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private S As MouseState = MouseState.None
    Private A As Alignment = Alignment.Centre
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        S = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        S = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        S = MouseState.Over
        Invalidate()
    End Sub

#End Region

#Region " Properties "

#Region " Appearance "

    <Category("Appearance")>
    Public Property TextAlignment() As Alignment
        Get
            Return A
        End Get
        Set(ByVal value As Alignment)
            A = value
            Invalidate()
        End Set
    End Property
#End Region

#Region " Behaviour "

#End Region

#End Region

#Region " Misc "
    Sub New()
        Size = New Size(90, 30)
        Font = New Font("Segoe UI", 10)
    End Sub
#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.Black)
        G.FillRectangle(New LinearGradientBrush(New Point(1, 1), New Point(1, Height - 2), Color.FromArgb(52, 78, 108), Color.FromArgb(22, 45, 67)), New Rectangle(1, 1, Width - 3, Height - 3))
        G.DrawRectangle(New Pen(Color.FromArgb(70, 103, 143)), New Rectangle(1, 1, Width - 3, Height - 3))
        Select Case S
            Case MouseState.Over
                G.FillRectangle(New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(2, 2, Width - 4, Height - 4))
            Case MouseState.Down
                G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.Black)), New Rectangle(2, 2, Width - 4, Height - 4))
        End Select
        Dim F As New StringFormat With {.LineAlignment = StringAlignment.Center}
        Select Case A
            Case Alignment.Left
                G.DrawString(Text, Font, Brushes.White, New Rectangle(8, 0, Width - 1, Height - 1), F)
            Case Alignment.Centre
                F.Alignment = StringAlignment.Center
                G.DrawString(Text, Font, Brushes.White, New Rectangle(0, 0, Width - 1, Height - 1), F)
            Case Alignment.Right
                G.DrawString(Text, Font, Brushes.White, New Rectangle(Width - TextRenderer.MeasureText(Text, Font).Width, 0, TextRenderer.MeasureText(Text, Font).Width, Height - 1), F)
        End Select
    End Sub
End Class

Class AngelGroupBox
    Inherits ContainerControl

#Region " Back End "

#Region " Misc "

    Sub New()
        BackColor = Color.FromArgb(10, 25, 38)
        Font = New Font("Segoe UI", 12)
        Size = New Size(200, 100)
    End Sub
#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(10, 25, 38))
        G.FillRectangle(New SolidBrush(Color.FromArgb(17, 33, 47)), New Rectangle(0, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(17, 33, 47)), New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(17, 33, 47)), New Rectangle(0, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(17, 33, 47)), New Rectangle(Width - 1, Height - 1, 1, 1))
        G.DrawString(Text, Font, Brushes.White, New Point(8, 6))
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class AngelCheckBox
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Event CheckedChanged(ByVal sender As Object)
    Private S As MouseState = MouseState.None
    Private C As Boolean = False
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        S = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        S = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        If C = True Then
            C = False
        Else
            C = True
        End If
        RaiseEvent CheckedChanged(Me)
    End Sub

#End Region

#Region " Properties "

#Region " Behaviour "

    <Category("Behavior")>
    Public Property Checked() As Boolean
        Get
            Return C
        End Get
        Set(ByVal value As Boolean)
            C = value
            Invalidate()
        End Set
    End Property
#End Region

#End Region

#Region " Misc "

    Sub New()
        Font = New Font("Segoe UI", 10)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 18
        Invalidate()
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Width = TextRenderer.MeasureText(Text, Font).Width + 16
        Invalidate()
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Parent.BackColor)
        G.FillRectangle(New LinearGradientBrush(New Point(1, 1), New Point(1, 16), Color.FromArgb(52, 78, 108), Color.FromArgb(22, 45, 67)), New Rectangle(1, 1, 15, 15))
        G.DrawRectangle(New Pen(Color.FromArgb(70, 103, 143)), New Rectangle(1, 1, 15, 15))
        If C = True Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(75, Color.White)), New Rectangle(4, 4, 10, 10))
        End If
        G.DrawString(Text, Font, Brushes.White, New Point(22, 0))
        Select Case S
            Case MouseState.Over
                G.FillRectangle(New SolidBrush(Color.FromArgb(15, Color.White)), New Rectangle(2, 2, 13, 13))
            Case MouseState.Down
                G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), New Rectangle(2, 2, 13, 13))
        End Select
    End Sub
End Class

<DefaultEvent("CheckedChanged")>
Class AngelRadioButton
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private S As MouseState = MouseState.None
    Private C As Boolean = False
    Event CheckedChanged(ByVal sender As Object)
#End Region

#Region " Mouse States"

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        S = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        S = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        S = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        If Not C Then Checked = True
        MyBase.OnClick(e)
    End Sub

#End Region

#Region " Properties "

#Region " Behaviour "

    <Category("Behavior")>
    Public Property Checked() As Boolean
        Get
            Return C
        End Get
        Set(ByVal value As Boolean)
            C = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

#End Region

#End Region

#Region " Misc "

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not C Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is AngelRadioButton Then
                DirectCast(C, AngelRadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub

    Sub New()
        Font = New Font("Segoe UI", 10)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 18
        Invalidate()
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Width = TextRenderer.MeasureText(Text, Font).Width + 16
        Invalidate()
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.SmoothingMode = SmoothingMode.AntiAlias
        G.Clear(Parent.BackColor)
        G.FillEllipse(New LinearGradientBrush(New Point(1, 1), New Point(1, 16), Color.FromArgb(52, 78, 108), Color.FromArgb(22, 45, 67)), New Rectangle(1, 1, 15, 15))
        G.DrawEllipse(New Pen(Color.FromArgb(70, 103, 143)), New Rectangle(1, 1, 15, 15))
        If C = True Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(75, Color.White)), New Rectangle(4, 4, 9, 9))
        End If
        G.DrawString(Text, Font, Brushes.White, New Point(22, 0))
        Select Case S
            Case MouseState.Over
                G.FillEllipse(New SolidBrush(Color.FromArgb(15, Color.White)), New Rectangle(2, 2, 13, 13))
            Case MouseState.Down
                G.FillEllipse(New SolidBrush(Color.FromArgb(30, Color.Black)), New Rectangle(2, 2, 13, 13))
        End Select
    End Sub

End Class

Class AngelProgressBar
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private V As Integer
    Private Min As Integer = 0
    Private Max As Integer = 100
#End Region

#Region " Properties "

#Region " Appearance "

#End Region

#Region " Behaviour "

    <Category("Behavior")>
    Public Property Value() As Integer
        Get
            Return V
        End Get
        Set(ByVal value As Integer)
            If Not value > Max Then
                If Not value < Min Then
                    V = value
                    Invalidate()
                End If
            End If
        End Set
    End Property

    <Category("Behavior")>
    Public Property Minimum() As Integer
        Get
            Return Min
        End Get
        Set(ByVal value As Integer)
            Min = value
            Invalidate()
        End Set
    End Property

    <Category("Behavior")>
    Public Property Maximum() As Integer
        Get
            Return Max
        End Get
        Set(ByVal value As Integer)
            Max = value
            Invalidate()
        End Set
    End Property
#End Region

#End Region

#Region " Misc "

    Sub New()
        Size = New Size(150, 40)
    End Sub

    Sub Increment(ByVal Int As Integer)
        Value += Int
        Invalidate()
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(10, 25, 38))
        G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
        G.FillRectangle(New LinearGradientBrush(New Point(1, 1), New Point(1, Height - 2), Color.FromArgb(52, 78, 108), Color.FromArgb(22, 45, 67)), New Rectangle(1, 1, (V / Max * Width) - 3, Height - 3))
        G.DrawRectangle(New Pen(Color.FromArgb(70, 103, 143)), New Rectangle(1, 1, Width - 3, Height - 3))
    End Sub

End Class

<DefaultEvent("TextChanged")>
Class AngelTextBox
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private S As MouseState = MouseState.None
    Private WithEvents T As System.Windows.Forms.TextBox
    Private A As HorizontalAlignment = HorizontalAlignment.Left
    Private L As Integer = 32767
    Private R As Boolean
    Private Pw As Boolean
    Private ML As Boolean
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        S = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        S = MouseState.Over
        T.Focus()
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        S = MouseState.Over
        T.Focus()
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        S = MouseState.None
        Invalidate()
    End Sub

#End Region

#Region " Properties "

#Region " Appearance "

    <Category("Appearance")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return A
        End Get
        Set(ByVal value As HorizontalAlignment)
            A = value
            If T IsNot Nothing Then
                T.TextAlign = value
            End If
        End Set
    End Property

    <Category("Appearance")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If T IsNot Nothing Then
                T.Text = value
            End If
        End Set
    End Property
    <Category("Appearance")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If T IsNot Nothing Then
                T.Font = value
                T.Location = New Point(3, 5)
                T.Width = Width - 6

                If Not ML Then
                    Height = T.Height + 11
                End If
            End If
        End Set
    End Property

#End Region

#Region " Behaviour "

    <Category("Behavior")>
    Property MaxLength() As Integer
        Get
            Return L
        End Get
        Set(ByVal value As Integer)
            L = value
            If T IsNot Nothing Then
                T.MaxLength = value
            End If
        End Set
    End Property

    <Category("Behavior")>
    Property [ReadOnly]() As Boolean
        Get
            Return R
        End Get
        Set(ByVal value As Boolean)
            R = value
            If T IsNot Nothing Then
                T.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Behavior")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return Pw
        End Get
        Set(ByVal value As Boolean)
            Pw = value
            If T IsNot Nothing Then
                T.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Behavior")>
    Property Multiline() As Boolean
        Get
            Return ML
        End Get
        Set(ByVal value As Boolean)
            ML = value
            If T IsNot Nothing Then
                T.Multiline = value

                If value Then
                    T.Height = Height - 11
                Else
                    Height = T.Height + 11
                End If

            End If
        End Set
    End Property


#End Region

#End Region

#Region " Misc "

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(T) Then
            Controls.Add(T)
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = T.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            T.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            T.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        T.Location = New Point(5, 5)
        T.Width = Width - 10

        If ML Then
            T.Height = Height - 11
        Else
            Height = T.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        T = New System.Windows.Forms.TextBox
        T.Font = New Font("Segoe UI", 10)
        T.Text = Text
        T.BackColor = Color.FromArgb(10, 25, 38)
        T.ForeColor = Color.White
        T.MaxLength = L
        T.Multiline = ML
        T.ReadOnly = R
        T.UseSystemPasswordChar = Pw
        T.BorderStyle = BorderStyle.None
        T.Location = New Point(5, 5)
        T.Width = Width - 10
        T.Cursor = Cursors.IBeam
        If ML Then
            T.Height = Height - 11
        Else
            Height = T.Height + 11
        End If
        AddHandler T.TextChanged, AddressOf OnBaseTextChanged
        AddHandler T.KeyDown, AddressOf OnBaseKeyDown
        Font = New Font("Segoe UI", 10)
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(10, 25, 38))
        G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawRectangle(New Pen(Color.FromArgb(70, 103, 143)), New Rectangle(1, 1, Width - 3, Height - 3))
    End Sub

End Class