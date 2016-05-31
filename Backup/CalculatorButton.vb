'___________________________________________________________________________________________
' Module Name: CalculatorButton.vb
' Description: Custom button that behaves like a Drop-Down
' Author     : Raju.K
' Mail       : raju.kandasamy@gmail.com
'____________________________________________________________________________________________

Imports System.Drawing.Drawing2D
Public Class CalculatorButton
    Inherits Button
    ' To hold the control that is to be associated with the Drop-Down Calculator
    Private ownerControl As Control
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler MouseEnter, AddressOf OnMouseEnters
        AddHandler MouseLeave, AddressOf OnMouseLeaves
        AddHandler MouseUp, AddressOf OnMouseUps
    End Sub

    ' The property that can be used at design-time to set the control associated with the calculator
    Public Property AssociatedControl() As Control
        Get
            Return Me.ownerControl
        End Get
        Set(ByVal value As Control)
            Me.ownerControl = value
        End Set
    End Property
    Sub OnMouseEnters(ByVal sender As Object, ByVal e As EventArgs)
        Invalidate()
    End Sub
    Sub OnMouseLeaves(ByVal sender As Object, ByVal e As EventArgs)
        Invalidate()
    End Sub
    Sub OnMouseUps(ByVal sender As Object, ByVal e As MouseEventArgs)
        Invalidate()
    End Sub
    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)
        Dim g As Graphics = pe.Graphics
        Dim r As Rectangle = ClientRectangle
        Dim pen As New Pen(Color.Black)
        'draw the arrow
        Dim p1 As New Point(5, r.Height / 4 - 1)
        Dim p2 As New Point(r.Width - 5, r.Height / 4 - 1)
        Dim p3 As New Point((p1.X + p2.X) / 2, r.Height - 6)
        Dim xpoints(2) As Point
        xpoints(0) = p1
        xpoints(1) = p2
        xpoints(2) = p3
        g.FillPolygon(Brushes.Black, xpoints)

    End Sub

    ' Create and visualize the drop-down calculator
    Private Sub CalculatorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If Not Me.ownerControl Is Nothing Then
            Dim CalcForm As CalculatorForm
            CalcForm = New CalculatorForm
            CalcForm.OwnerControl = Me.ownerControl
            CalcForm.Show()
        End If
    End Sub
End Class
