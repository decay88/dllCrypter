Imports System.Drawing.Graphics
Imports System.Diagnostics.Process
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 15
        '
        'Timer2
        '
        Me.Timer2.Interval = 15
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(112, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(342, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Press  Any  Direction  Key  to  ""Start""  Game"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem5, Me.MenuItem9})
        Me.MenuItem1.Text = "Options"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "New Game"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Pause"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuItem7, Me.MenuItem8})
        Me.MenuItem5.Text = "Level"
        '
        'MenuItem6
        '
        Me.MenuItem6.Checked = True
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Level 1"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.Text = "Level 2"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 2
        Me.MenuItem8.Text = "Level 3"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(600, 315)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Snake"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public snake As Pen = New Pen(Color.Red, 2)             'For Drawing Snake
    Public snake_erase As Pen = New Pen(Color.Black, 2)     'For Erasing Snake
    Public food As Pen = New Pen(Color.Yellow, 2)           'For Drawing Food
    Public food_erase As Pen = New Pen(Color.Black, 2)      'For Erasing Food
    Public about_form As About = New About
    Public x1 = 0, y1 = 20, x2 = 1, y2 = 20, counter = 1, value = 0, points = 0, prev = "", int_timer1 = 15, int_timer2 = 15, keypressed, foodx, foody, i, length, j, about_counter
    Public X(500000) As Int64  ' For Saving X co-ordinates during Snake Motion
    Public Y(500000) As Int64  ' For Saving Y co-ordinates during Snake Motion

    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = int_timer1 : Timer2.Interval = int_timer2
        'When Snake length is 70 Then Show Food and start Erasing from Behind
        If (counter = 70) Then Timer2.Enabled = True : Show_Food()
        If (keypressed = "down") Then prev = "up" : Valid_Range() : y2 = y2 + 1
        If (keypressed = "left") Then prev = "right" : Valid_Range() : x2 = x2 - 1
        If (keypressed = "right") Then prev = "left" : Valid_Range() : x2 = x2 + 1
        If (keypressed = "up") Then prev = "down" : Valid_Range() : y2 = y2 - 1
    End Sub
    Public Sub Valid_Range()

        'For Adjusting Range during Snake and Food Collision
        Timer1.Interval = int_timer1 : Timer2.Interval = int_timer2
        If ((x2 = foodx) And (y2 = foody)) Then Erase_Food() : points = points + 1 : value = value - 16 : Show_Food()

        'If Snake cuts  the food from Left or Top of food by a margin of 1 pixel 
        If ((x2 = foodx - 1) And (y2 = foody - 1)) Then Increase_Length()
        If ((x2 = foodx - 1) And (y2 = foody)) Then Increase_Length()
        If ((x2 = foodx) And (y2 = foody - 1)) Then Increase_Length()

        'If Snake cuts  the food from Left or Top of food by a margin of 2 pixel
        If ((x2 = foodx - 2) And (y2 = foody - 2)) Then Increase_Length()
        If ((x2 = foodx - 2) And (y2 = foody)) Then Increase_Length()
        If ((x2 = foodx) And (y2 = foody - 2)) Then Increase_Length()

        'If Snake cuts  the food from Right or Bottom of food by a margin of 2 pixel
        If ((x2 = foodx + 2) And (y2 = foody + 2)) Then Increase_Length()
        If ((x2 = foodx + 2) And (y2 = foody)) Then Increase_Length()
        If ((x2 = foodx) And (y2 = foody + 2)) Then Increase_Length()

        'If Snake cuts  the food from Right or Bottom of food by a margin of 3 pixel
        If ((x2 = foodx + 3) And (y2 = foody + 3)) Then Increase_Length()
        If ((x2 = foodx + 3) And (y2 = foody)) Then Increase_Length()
        If ((x2 = foodx) And (y2 = foody + 3)) Then Increase_Length()

        'If Snake cuts  the food from Right or Bottom of food by a margin of 1 pixel
        If ((x2 = foodx + 1) And (y2 = foody + 1)) Then Increase_Length()
        If ((x2 = foodx + 1) And (y2 = foody)) Then Increase_Length()
        If ((x2 = foodx) And (y2 = foody + 1)) Then Increase_Length()
        'For Showing points in Form Caption
        Me.Text = Convert.ToString("Snake - " + Convert.ToString(points))
        'For Chekcing Whether Snake bites itself,If Yes Then "Game Over"
        For i = value To counter - 10
            If (x2 = X(i) And y2 = Y(i)) Then
                Timer1.Stop() : Timer2.Stop() : MessageBox.Show("Game Over", "Game Over")
                Me.CreateGraphics.Clear(Color.Black) : x1 = 0 : y1 = 20 : x2 = 1 : y2 = 20 : counter = 1 : value = 0 : points = 0 : prev = "" : Timer1.Stop() : Timer2.Stop() : Label7.Visible = True
            End If
            i = i + 1
        Next
        'Draw Snake
        Me.CreateGraphics.DrawLine(snake, x1, y1, x2, y2)
        'Check Whether Snake is moving outside the Form
        If ((x2 > Me.Width - 5) Or y2 > (Me.Height - 50) Or (x2 < 0) Or (y2 < 0)) Then
            Timer1.Stop() : Timer2.Stop() : MessageBox.Show("Game Over", "Game Over")
            Me.CreateGraphics.Clear(Color.Black) : x1 = 0 : y1 = 20 : x2 = 1 : y2 = 20 : counter = 1 : value = 0 : points = 0 : prev = "" : Timer1.Stop() : Timer2.Stop() : Label7.Visible = True
        End If
        'Making the (x2,y2) as New (x1,y1) and new  x2,y2 "ll be as per the Direction keys
        'i.e If keypressed = "down" Then New  (x1,y1)=(x2,y2) and (x2,y2)=(x2+1,y2)
        x1 = x2 : y1 = y2 : X(counter) = x2 : Y(counter) = y2 : counter = counter + 1
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        'Adjusting the Direction Keys for Motion
        If (about_form.TopMost = False) Then
            'Hide the "Press Any Direction Key Label" When any Key is pressed
            Label7.Visible = False
            If Not (MenuItem3.Text = "Resume") Then
                Timer1.Interval = int_timer1 : Timer2.Interval = int_timer2 : Timer1.Start()
                If (e.KeyCode = Keys.Down) And ((prev = "up") Or (prev = "right") Or (prev = "left") Or (prev = "")) Then keypressed = "down"
                If (e.KeyCode = Keys.Up) And ((prev = "down") Or (prev = "") Or (prev = "right") Or (prev = "left")) Then keypressed = "up"
                If (e.KeyCode = Keys.Right) And ((prev = "left") Or (prev = "") Or (prev = "up") Or (prev = "down")) Then keypressed = "right"
                If (e.KeyCode = Keys.Left) And ((prev = "right") Or (prev = "") Or (prev = "up") Or (prev = "down")) Then keypressed = "left"
            End If
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' To check Whether Another Instance of Snake.exe is running or Not
        Dim process_name(100) As Diagnostics.Process
        Dim j, list_process As Int32
        Dim hit = 1
        process_name = Process.GetProcesses()
        list_process = process_name.Length()
        For j = 0 To list_process - 1
            If (process_name(j).ProcessName = "Snake") Then hit = hit + 1
            If (hit > 2) Then MessageBox.Show("Another Instance of Snake is Running", "Alert") : End
        Next
        X(0) = 0 : Y(0) = 20
        'Start Snake from (0,20) almost Top-Left Corner
        'For Showing The Startup Screen
        about_form.Show() : about_form.TopMost = True
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer1.Interval = int_timer1 : Timer2.Interval = int_timer2
        'Erase the Snake Taking the Old Path Travelled whose Co-ordinates are continously being saved
        'in X() and Y()
        Me.CreateGraphics.DrawLine(snake_erase, X(value), Y(value), X(value + 1), Y(value + 1))
        value = value + 1
    End Sub
    Public Sub Show_Food()
        Dim RandomNumber As New Random
        'For Generating Random Food Co-Ordinates(X,Y)
        foodx = RandomNumber.Next(20, Me.Width - 60)
        foody = RandomNumber.Next(20, Me.Height - 60)
        'Draw Food
        Me.CreateGraphics.DrawRectangle(food, foodx, foody, 2, 2)
    End Sub
    Public Sub Erase_Food()
        'Redraw a Black Rectangle that Erases the Yellow Rectangle (Food)
        Me.CreateGraphics.DrawRectangle(food_erase, foodx, foody, 2, 2)
    End Sub
    Public Sub Increase_Length()
        'Increase Length by decreasing the Erasing Snake by 16 (16 is my fav number :-))
        'Increase Points by 1
        Erase_Food() : points = points + 1 : value = value - 16 : Show_Food()
    End Sub
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        'If text="Pause" Then chaange text="Resume" else vice-versa :-) 
        If ((MenuItem3.Text = "Pause") And (Label7.Visible = False)) Then
            MenuItem3.Text = "Resume" : Timer1.Stop() : Timer2.Stop()
        Else
            MenuItem3.Text = "Pause" : Timer1.Start() : Timer2.Start()
        End If
    End Sub
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        int_timer1 = 7 : int_timer2 = 7 : MenuItem6.Checked = False : MenuItem7.Checked = True : MenuItem8.Checked = False
    End Sub
    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        Me.Dispose(True)
    End Sub
    Public Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.CreateGraphics.Clear(Color.Black) : x1 = 0 : y1 = 20 : x2 = 1 : y2 = 20 : counter = 1 : value = 0 : points = 0 : prev = "" : Timer1.Stop() : Timer2.Stop() : Label7.Visible = True : MenuItem3.Text = "Pause"
    End Sub
    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        int_timer1 = 1 : int_timer2 = 1 : MenuItem6.Checked = False : MenuItem7.Checked = False : MenuItem8.Checked = True
    End Sub
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        int_timer1 = 15 : int_timer2 = 15 : MenuItem6.Checked = True : MenuItem7.Checked = False : MenuItem8.Checked = False
    End Sub
End Class
