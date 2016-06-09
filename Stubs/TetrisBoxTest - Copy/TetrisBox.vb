Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class TetrisBox
    '**********************************************************************************************
    '*** This is my TetrisBox class made for an Experts Exchange article                        ***
    '*** Feel free to modify and use at your convenience!                                       ***
    '*** Visit my profile on Experts Exchange for more articles and solutions:                  ***
    '*** http://www.experts-exchange.com/members/RolandDeschain.html                            ***
    '**********************************************************************************************
    '*** Version 1.0.0.0                                                                        ***
    '*** Released on 08/19/2014                                                                 ***
    '**********************************************************************************************

    'As this class is, basically, a Tetris drawing surface, I thought that it would be logical to inherit it from the PictureBox class
    Inherits System.Windows.Forms.PictureBox

#Region "Public Enumerations"
    'This enum is for the background style. You can choose between 3 background styles:
    Public Enum BackgroundStyles
        SolidColor  'Draw the background as a solid, unique color (use BackColor property)
        Gradient    'Draw the background as a gradient (use GradientColor1, GradientColor2 and GradientDirection properties)
        Picture     'Draw the background as a picture (use the BackgroundImage property, it will be stretched to the control size)
    End Enum
#End Region

#Region "Private Classes"
    Private Class Block
        'This class represents a falling block in Tetris game. There are 7 different blocks, as you Tetris gamers sure know.
        Private _type As Integer    'Stores the block type. In the Experts Exchange article you'll find a guide matching _type value with each associated block type.
        Public Property Color As Color     'Each block type has a distinctive color.
        Private _rotationsNumber As Integer     'Each block type has a concrete number of possible positions (rotations) in board.
        Private _rotations As Dictionary(Of Integer, List(Of String)) = New Dictionary(Of Integer, List(Of String)) 'Stores the block definition for each rotation inside a 4x4 matrix
        Private _currentRotation As Integer = 1 'The current position of the block
        Public Property X As Integer = 0    'The current column inside board
        Public Property Y As Integer = 0    'The current row inside board

        Public Sub OffsetRotation()
            'Sets the block to the next possible rotation, in response to the user pressing the rotate key
            _currentRotation += 1
            If (_currentRotation > _rotationsNumber) Then _currentRotation = 1
        End Sub

        Public Function FilledCell(ByVal x As Integer, ByVal y As Integer) As Boolean
            'Returns True if the specified x,y position is filled inside the 4x4 matrix
            Return Me.CurrentMatrix()(y).Substring(x, 1).Equals("1")
        End Function

        Public ReadOnly Property CurrentMatrix As List(Of String)
            Get
                'Returns the 4x4 matrix corresponding to the current rotation of the block
                Return _rotations(_currentRotation)
            End Get
        End Property

        Public ReadOnly Property NextRotationMatrix As List(Of String)
            Get
                'Returns the 4x4 matrix corresponding to the next rotation of the block
                Dim nextRotation As Integer = _currentRotation + 1
                If (nextRotation > _rotationsNumber) Then nextRotation = 1
                Return _rotations(nextRotation)
            End Get
        End Property

        Public ReadOnly Property Type As Integer
            Get
                'Returns the block's type
                Return _type
            End Get
        End Property

        Public Sub New(ByVal blockType As Integer)
            'Initializes the class. Depending on the block type it will initialize with its own values
            _type = blockType
            Select Case _type
                Case 1
                    Call InitializeBlock(New List(Of String) From {"0100", "0100", "0100", "0100"}, New List(Of String) From {"0000", "1111", "0000", "0000"})
                Case 2
                    Call InitializeBlock(New List(Of String) From {"0110", "0110", "0000", "0000"})
                Case 3
                    Call InitializeBlock(New List(Of String) From {"0100", "1110", "0000", "0000"}, New List(Of String) From {"0100", "0110", "0100", "0000"}, New List(Of String) From {"1110", "0100", "0000", "0000"}, New List(Of String) From {"0100", "1100", "0100", "0000"})
                Case 4
                    Call InitializeBlock(New List(Of String) From {"0010", "0110", "0100", "0000"}, New List(Of String) From {"0110", "0011", "0000", "0000"})
                Case 5
                    Call InitializeBlock(New List(Of String) From {"0100", "0110", "0010", "0000"}, New List(Of String) From {"0011", "0110", "0000", "0000"})
                Case 6
                    Call InitializeBlock(New List(Of String) From {"0100", "0100", "0110", "0000"}, New List(Of String) From {"0111", "0100", "0000", "0000"}, New List(Of String) From {"0110", "0010", "0010", "0000"}, New List(Of String) From {"0001", "0111", "0000", "0000"})
                Case 7
                    Call InitializeBlock(New List(Of String) From {"0010", "0010", "0110", "0000"}, New List(Of String) From {"0100", "0111", "0000", "0000"}, New List(Of String) From {"0110", "0100", "0100", "0000"}, New List(Of String) From {"0111", "0001", "0000", "0000"})
            End Select
        End Sub

        Private Sub InitializeBlock(ByVal ParamArray rotations() As List(Of String))
            'Initializes a new block

            'Set the number of possible rotations
            _rotationsNumber = rotations.Length
            'Set the 4x4 matrix of each possible rotation
            For k As Integer = 0 To rotations.Length - 1
                _rotations.Add(k + 1, rotations(k))
            Next
        End Sub
    End Class

    Private Class Cell
        'This class represents a single cell (defined by its row and column) inside the game board
        Public Property Row As Integer = 0          'Defines the cell row
        Public Property Column As Integer = 0       'Defines the cell column
        Public Property Fixed As Boolean = False    'When a block drops in the board to its ultimate position (and therefore it cannot be moved anymore), the board cells corresponding to the block filled cells become Fixed
        Public Property Color As Color              'The color in which this cell must be painted in the board

        Public Sub New(ByVal row As Integer, ByVal column As Integer)
            'Instantiates a new Cell object passing its row and column
            Me.Row = row
            Me.Column = column
        End Sub
    End Class

    Private Class CellPoint
        'Really this class is very close to the System.Drawing.Point class, but I've overwritten its ToString function to return the row and column into a string
        'that is helpful to me because it's the Key in the cells collection of the board.
        Public Property Row As Integer = 0          'Represents the row
        Public Property Column As Integer = 0       'Represents the column

        Public Sub New(ByVal row As Integer, ByVal column As Integer)
            'Instantiates a new CellPoint object passing its row and column
            Me.Row = row
            Me.Column = column
        End Sub

        Public Overrides Function ToString() As String
            'Returns a string that can be used as a Key in the cells collection of the board
            Return Me.Row.ToString + "," + Me.Column.ToString
        End Function
    End Class

    Private Class KeyboardHook
        'This class is to globally capture keystrokes.
        'Credits to sim0n for this: http://sim0n.wordpress.com/2009/03/28/vbnet-keyboard-hook-class/
        'although I've modified this slightly to implement the IDisposable interface
        Implements IDisposable

        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Overloads Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As HookProc, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
        End Function
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Overloads Shared Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        End Function
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Overloads Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
        End Function

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure KBDLLHOOKSTRUCT
            Public vkCode As UInt32
            Public scanCode As UInt32
            Public flags As KBDLLHOOKSTRUCTFlags
            Public time As UInt32
            Public dwExtraInfo As UIntPtr
        End Structure

        <Flags()> _
        Private Enum KBDLLHOOKSTRUCTFlags As UInt32
            LLKHF_EXTENDED = &H1
            LLKHF_INJECTED = &H10
            LLKHF_ALTDOWN = &H20
            LLKHF_UP = &H80
        End Enum

        Public Event KeyDown(ByVal Key As Keys)
        Public Event KeyUp(ByVal Key As Keys)

        Private Const WH_KEYBOARD_LL As Integer = 13
        Private Const HC_ACTION As Integer = 0
        Private Const WM_KEYDOWN = &H100
        Private Const WM_KEYUP = &H101
        Private Const WM_SYSKEYDOWN = &H104
        Private Const WM_SYSKEYUP = &H105

        Private Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer

        Private hookDelegate As HookProc = New HookProc(AddressOf KeyboardProc)
        Private hookID As IntPtr = IntPtr.Zero

        Private Function KeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
            If (nCode = HC_ACTION) Then
                Dim struct As KBDLLHOOKSTRUCT
                Select Case wParam
                    Case WM_KEYDOWN, WM_SYSKEYDOWN
                        RaiseEvent KeyDown(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                    Case WM_KEYUP, WM_SYSKEYUP
                        RaiseEvent KeyUp(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                End Select
            End If
            Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
        End Function

        Public Sub New()
            hookID = SetWindowsHookEx(WH_KEYBOARD_LL, hookDelegate, IntPtr.Zero, 0)
            If hookID = IntPtr.Zero Then
                Throw New Exception("Could not set keyboard hook")
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                End If

                If Not hookID = IntPtr.Zero Then
                    UnhookWindowsHookEx(hookID)
                End If

            End If
            Me.disposedValue = True
        End Sub

        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private Class Board
        'This class represents the game board. Many of the game logic is implemented here.
        Public Property Rows As Integer = 0                     'Defines the number of rows
        Public Property Columns As Integer = 0                  'Defines the number of columns
        Public Property Cells As Dictionary(Of String, Cell)    'Single-cell collection
        Public Property FallingBlock As Block = Nothing         'The current falling block, if there's any
        Public Property Block1Color As Color = Color.Red        'Allows to customize the color of the type 1 blocks
        Public Property Block2Color As Color = Color.Blue       'Allows to customize the color of the type 2 blocks
        Public Property Block3Color As Color = Color.Green      'Allows to customize the color of the type 3 blocks
        Public Property Block4Color As Color = Color.Aqua       'Allows to customize the color of the type 4 blocks
        Public Property Block5Color As Color = Color.Brown      'Allows to customize the color of the type 5 blocks
        Public Property Block6Color As Color = Color.Yellow     'Allows to customize the color of the type 6 blocks
        Public Property Block7Color As Color = Color.Purple     'Allows to customize the color of the type 7 blocks

        Private _nextBlock As Integer = 0                       'The next block that will fall after the current that is falling

        Public Event FullRows(sender As Object, e As FullRowsEventArgs)     'Fires when the user completes any number of full rows. The completed rows will disappear.
        Public Event GameOver(sender As Object, e As System.EventArgs)      'Fires when a block reaches the top of the game board.
        Public Event GotNewBlock(sender As Object, e As NewBlockEventArgs)  'Fires every time a new block is created. This is useful for adding difficulties every certain number of blocks.

        Public Sub New(ByVal rows As Integer, ByVal columns As Integer)
            'Instantiates a new Board class passing its rows and columns number

            'Set the number of rows
            Me.Rows = rows
            'Set the number of columns
            Me.Columns = columns
            'Initialize the Cell collection
            Me.Cells = New Dictionary(Of String, Cell)
            For row As Integer = 0 To Me.Rows - 1
                For column As Integer = 0 To Me.Columns - 1
                    Me.Cells.Add(row.ToString + "," + column.ToString, New Cell(row, column))
                Next
            Next
        End Sub

        Private Function GetRandomNumber(ByVal lowerbound As Integer, ByVal upperbound As Integer) As Integer
            'To get an integer random number inside a known interval, as seen on MSDN
            Return CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        End Function

        Public Function Rotate() As Boolean
            'Tries to rotate the current falling block, returning True if the rotation has been done
            If CanRotate() Then
                Me.FallingBlock.OffsetRotation()
                Return True
            Else
                Return False
            End If
        End Function

        Private Function CanRotate() As Boolean
            'Ensures that the current falling block can rotate. It can rotate if, once rotated, keeps inside board margins and doesn't overlap with existing fixed cells.
            If Me.FallingBlock IsNot Nothing Then
                'Get the 4x4 matrix corresponding to the next rotation of the block
                Dim nextRotation As List(Of String) = Me.FallingBlock.NextRotationMatrix
                'Check each filled cell of the block. It must be inside board margins and not overlap with fixed cells.
                For row As Integer = 0 To 3
                    For column As Integer = 0 To 3
                        If nextRotation(row).Substring(column, 1).Equals("1") Then
                            'This is a filled cell.
                            'Translate its coordinates to board-coordinates.
                            Dim pt As CellPoint = BlockToBoard(New CellPoint(row, column))
                            'Check if the cell is inside board margins and doesn't overlap with fixed cells.
                            If (pt.Column < 0) OrElse (pt.Column >= Me.Columns) OrElse (pt.Row < 0) OrElse (pt.Row >= Me.Rows) OrElse Me.Cells(New CellPoint(pt.Row, pt.Column).ToString).Fixed Then
                                Return False
                            End If
                        End If
                    Next
                Next
                Return True
            Else
                Return False
            End If
        End Function

        Public Function MoveLeft() As Boolean
            'Tries to move the current block 1 column to the left, returning True if it has been moved
            If CanMoveLeft() Then
                Me.FallingBlock.X -= 1
                Return True
            Else
                Return False
            End If
        End Function

        Private Function CanMoveLeft() As Boolean
            'Ensures that the current falling block can move to the left. It can move if, once moved, keeps inside board margins and doesn't overlap with existing fixed cells.
            If Me.FallingBlock IsNot Nothing Then
                'Check each filled cell of the block. It must be inside board margins and not overlap with fixed cells.
                For row As Integer = 0 To 3
                    For column As Integer = 0 To 3
                        If Me.FallingBlock.FilledCell(column, row) Then
                            'This is a filled cell.
                            'Translate its coordinates to board-coordinates.
                            Dim pt As CellPoint = BlockToBoard(New CellPoint(row, column))
                            'Check if the cell is inside board margins and doesn't overlap with fixed cells.
                            If pt.Column.Equals(0) OrElse Me.Cells(New CellPoint(pt.Row, pt.Column - 1).ToString).Fixed Then
                                Return False
                            End If
                        End If
                    Next
                Next
                Return True
            Else
                Return False
            End If
        End Function

        Private Function CanMoveRight() As Boolean
            'Ensures that the current falling block can move to the right. It can move if, once moved, keeps inside board margins and doesn't overlap with existing fixed cells.
            If Me.FallingBlock IsNot Nothing Then
                'Check each filled cell of the block. It must be inside board margins and not overlap with fixed cells.
                For row As Integer = 0 To 3
                    For column As Integer = 3 To 0 Step -1
                        If Me.FallingBlock.FilledCell(column, row) Then
                            'This is a filled cell.
                            'Translate its coordinates to board-coordinates.
                            Dim pt As CellPoint = BlockToBoard(New CellPoint(row, column))
                            'Check if the cell is inside board margins and doesn't overlap with fixed cells.
                            If pt.Column.Equals(Me.Columns - 1) OrElse Me.Cells(New CellPoint(pt.Row, pt.Column + 1).ToString).Fixed Then
                                Return False
                            End If
                        End If
                    Next
                Next
                Return True
            Else
                Return False
            End If
        End Function

        Public Function MoveRight() As Boolean
            'Tries to move the current block 1 column to the right, returning True if it has been moved
            If CanMoveRight() Then
                Me.FallingBlock.X += 1
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub NewBlock()
            'Creates a new block.

            If _nextBlock.Equals(0) Then
                'This is the first block requested, so get its block type randomly
                Me.FallingBlock = New Block(GetRandomNumber(1, 7))
            Else
                'This is not the first block, so use the _nextBlock variable
                Me.FallingBlock = New Block(_nextBlock)
            End If
            'Set the block color
            Select Case Me.FallingBlock.Type
                Case 1
                    Me.FallingBlock.Color = Me.Block1Color
                Case 2
                    Me.FallingBlock.Color = Me.Block2Color
                Case 3
                    Me.FallingBlock.Color = Me.Block3Color
                Case 4
                    Me.FallingBlock.Color = Me.Block4Color
                Case 5
                    Me.FallingBlock.Color = Me.Block5Color
                Case 6
                    Me.FallingBlock.Color = Me.Block6Color
                Case 7
                    Me.FallingBlock.Color = Me.Block7Color
            End Select
            'Select the next block to fall (after the one just chosen)
            _nextBlock = GetRandomNumber(1, 7)
            'Position the new block inside the board
            Me.FallingBlock.X = (Me.Columns - 4) / 2
            Me.FallingBlock.Y = 0
            'Notify user that a new block has been created
            RaiseEvent GotNewBlock(Me, New NewBlockEventArgs(Me.FallingBlock.Type, _nextBlock))
        End Sub

        Public Sub CheckBlock()
            'Checks game logic with the falling block. Concretely, checks that:
            '1) The falling block has reached the top of the board (it overlaps with existing fixed cells)
            '2) The falling block has reached its ultimate position and, therefore, it cannot be moved anymore (for example, it has been dropped to the bottom of the board)

            If Me.FallingBlock IsNot Nothing Then
                'Let's see if the falling block overlaps with existing fixed cells. If so, the game is over
                Dim overlapBlock As Boolean = False
                'Check each existing filled cell on the current falling block
                For row As Integer = 0 To 3
                    For column As Integer = 0 To 3
                        If Me.FallingBlock.FilledCell(column, row) Then
                            'This is a filled cell
                            'Translate its coordinates to board-coordinates
                            Dim pt As CellPoint = BlockToBoard(New CellPoint(row, column))
                            If Me.Cells(pt.ToString).Fixed Then
                                overlapBlock = True
                                Exit For
                            End If
                        End If
                    Next
                    If overlapBlock Then Exit For
                Next
                If overlapBlock Then
                    'An overlap exists. This is game over!
                    RaiseEvent GameOver(Me, New System.EventArgs)
                Else
                    'Now check if the current falling block has been dropped to its ultimate position. If so, transform each filled cell of the block into a fixed cell on the board.
                    Dim fixBlock As Boolean = False

                    For column As Integer = 0 To 3
                        For row As Integer = 3 To 0 Step -1
                            If Me.FallingBlock.FilledCell(column, row) Then
                                Dim pt As CellPoint = BlockToBoard(New CellPoint(row, column))
                                'If the falling block has a filled cell just over the board's bottom, or just over a fixed cell in the next line, it must be fixed
                                If pt.Row.Equals(Me.Rows - 1) OrElse Me.Cells(New CellPoint(pt.Row + 1, pt.Column).ToString).Fixed Then
                                    fixBlock = True
                                End If
                                Exit For
                            End If
                        Next
                        If fixBlock Then Exit For
                    Next

                    If fixBlock Then
                        'Transform each filled cell on the block into a fixed cell on the board
                        For row As Integer = 0 To 3
                            For column As Integer = 0 To 3
                                If Me.FallingBlock.FilledCell(column, row) Then
                                    Dim pt As CellPoint = BlockToBoard(New CellPoint(row, column))
                                    Me.Cells(pt.ToString).Fixed = True
                                    Me.Cells(pt.ToString).Color = Me.FallingBlock.Color
                                End If
                            Next
                        Next
                        Me.FallingBlock = Nothing
                        'As a block has been dropped and fixed, check if the player has completed full rows
                        Call CheckFullRows()
                    End If
                End If
            End If
        End Sub

        Private Sub CheckFullRows()
            'Checks if the player has completed full rows (this is the main Tetris objective!)

            Dim fullRows As List(Of Integer) = New List(Of Integer)

            'Check each row from bottom to top
            For row As Integer = Me.Rows - 1 To 0 Step -1
                Dim fullRow As Boolean = True
                'Check if all columns are fixed in the row
                For column As Integer = 0 To Me.Columns - 1
                    If (Not Me.Cells(row.ToString + "," + column.ToString).Fixed) Then
                        fullRow = False
                        Exit For
                    End If
                Next
                'The row is full filled
                If fullRow Then fullRows.Add(row)
            Next
            If fullRows.Count > 0 Then
                'Delete the full rows
                For Each row As Integer In fullRows
                    Call DeleteRow(row)
                Next
                'Notify the user (you should probably reward the player)
                RaiseEvent FullRows(Me, New FullRowsEventArgs(fullRows.Count))
            End If
        End Sub

        Private Sub DeleteRow(ByVal row As Integer)
            'Delete a row

            'To delete a row, drop-down the entire board over the deleted row and clear the first row
            For r As Integer = row To 1 Step -1
                For col As Integer = 0 To Me.Columns - 1
                    Me.Cells(r.ToString + "," + col.ToString).Fixed = Me.Cells((r - 1).ToString + "," + col.ToString).Fixed
                    Me.Cells(r.ToString + "," + col.ToString).Color = Me.Cells((r - 1).ToString + "," + col.ToString).Color
                Next
            Next
            'Clear the first row
            For col As Integer = 0 To Me.Columns - 1
                Me.Cells("0," + col.ToString).Fixed = False
            Next
        End Sub

        Private Function BlockToBoard(ByVal p As CellPoint) As CellPoint
            'Translate a block coordinate into a board coordinate
            Return New CellPoint(p.Row + Me.FallingBlock.Y, p.Column + Me.FallingBlock.X)
        End Function

        Private Function BoardToBlock(ByVal p As CellPoint) As CellPoint
            'Translate a board coordinate into a block coordinate
            Return New CellPoint(p.Row - Me.FallingBlock.Y, p.Column - Me.FallingBlock.X)
        End Function

        Public Function GetCellColor(ByVal p As CellPoint) As Color
            'Returns the color in which a cell must be painted. Defaults to Transparent, which means that the cell is empty.
            Dim output As Color = Color.Transparent

            If Me.Cells(p.Row.ToString + "," + p.Column.ToString).Fixed Then
                'If the cell if fixed in the board, return its fixed color
                output = Me.Cells(p.Row.ToString + "," + p.Column.ToString).Color
            Else
                'If the cell is inside the 4x4 matrix of the falling block...
                If (Me.FallingBlock IsNot Nothing) AndAlso CellIsInsideBlock(p.Row, p.Column) Then
                    'Translate to block coordinates
                    Dim pt As CellPoint = BoardToBlock(p)
                    'If 
                    If Me.FallingBlock.FilledCell(pt.Column, pt.Row) Then
                        output = Me.FallingBlock.Color
                    End If
                    'If Me.FallingBlock.CurrentMatrix(pt.Row).Substring(pt.Column, 1).Equals("1") Then
                    'End If
                End If
            End If

            Return output
        End Function

        Private Function CellIsInsideBlock(ByVal row As Integer, ByVal column As Integer) As Boolean
            'Returns true if the row,column coordinate (board system) is inside the current falling block 4x4 matrix
            Return (row >= Me.FallingBlock.Y) AndAlso (row <= (Me.FallingBlock.Y + 3)) AndAlso (column >= Me.FallingBlock.X) AndAlso (column <= (Me.FallingBlock.X + 3))
        End Function
    End Class
#End Region

#Region "Public Classes"
    Public Class FullRowsEventArgs
        'Argument for the FullRows event.
        Inherits System.EventArgs

        'Contains the number of rows filled at once, from 1 to 4. In the classic Tetris game, the more rows you filled at once, the more points are you rewarded with.
        Public Property NumberOfRows As Integer = 0

        Public Sub New(ByVal numberOfRows As Integer)
            Me.NumberOfRows = numberOfRows
        End Sub
    End Class

    Public Class NewBlockEventArgs
        'Argument for the NewBlock event.
        Inherits System.EventArgs

        'This property notifies about the falling block type
        Public Property BlockType As Integer = 0
        'This property notifies about the next falling block type
        Public Property NextBlockType As Integer = 0

        Public Sub New(ByVal blockType As Integer, ByVal nextBlockType As Integer)
            Me.BlockType = blockType
            Me.NextBlockType = nextBlockType
        End Sub
    End Class
#End Region

#Region "Public Events"
    'Fires when the player completes entire rows
    Public Event FullRows(sender As Object, e As FullRowsEventArgs)
    'Fires when a block reaches the top of the board and, therefore, overlaps with existing fixed cells
    Public Event GameOver(sender As Object, e As System.EventArgs)
    'Fires when the game is about to start
    Public Event Starting(sender As Object, e As System.EventArgs)
    'Fires every time a new block is created
    Public Event NewBlock(sender As Object, e As NewBlockEventArgs)
#End Region

#Region "Private Variables"
    Private _rows As Integer = 20       'Number of board rows. Internal storage for Rows property.
    Private _columns As Integer = 10    'Number of board columns. Internal storage for Columns property.
    Private _cellSize As Integer = 25   'Cell size (in pixels). Internal storage for CellSize property. [Board width = Columns x CellSize] [Board height = Rows x CellSize]
    Private _backgroundStyle As BackgroundStyles = BackgroundStyles.SolidColor  'Background style. Internal storage for BackgroundStyle property.
    Private _gradientColor1 As Color = Color.SteelBlue  'First gradient color. Internal storage for GradientColor1 property.
    Private _gradientColor2 As Color = Color.Black      'Second gradient color. Internal storage for GradientColor2 property.
    Private _gradientDirection As Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Vertical  'Gradient direction. Internal storage for GradientDirection property.
    Private _timer As System.Timers.Timer = Nothing     'Timer used to drop the falling block 1 row automatically.
    Private _board As Board                             'The board.
    Private _running As Boolean = False                 'Stores a value indicating whether the game is running or not
    Private _pause As Boolean = False                   'Stores a value indicating whether the game is paused or not
    Private WithEvents _hook As KeyboardHook = Nothing  'Hook to catch keystrokes
#End Region

#Region "Constructor"
    Public Sub New()
        'Set DoubleBuffered to true to avoid screen-flickering.
        Me.DoubleBuffered = True
        'Instantiate the Timer and set a default interval of 1000 ms.
        _timer = New Timers.Timer(1000)
        'Set the SynchronizingObject of the timer (if not, the Elapsed event fires into its own subprocess and it's impossible to update the UI)
        _timer.SynchronizingObject = Me
        'Add a handler to the Elapsed event
        AddHandler _timer.Elapsed, AddressOf TimerElapsed
    End Sub
#End Region

#Region "Public Auto-Implemented Properties"
    Public Property RandomBlockColor As Color = Color.LightYellow       'The color of random-generated blocks (difficulty)
    Public Property UncompleteRowColor As Color = Color.LightYellow     'The color of umcomplete rows (difficulty)
    Public Property LeftKey As Keys = Keys.Left     'Allows to customize the Left key for the game (defaults to the left direction key)
    Public Property RightKey As Keys = Keys.Right   'Allows to customize the Right key for the game (defaults to the right direction key)
    Public Property RotateKey As Keys = Keys.Up     'Allows to customize the Rotate key for the game (defaults to the up direction key)
    Public Property DropKey As Keys = Keys.Down     'Allows to customize the Drop key for the game (defaults to the down direction key)
    Public Property Block1Color As Color = Color.Red        'Allows to customize the color of the type 1 blocks
    Public Property Block2Color As Color = Color.Blue       'Allows to customize the color of the type 2 blocks
    Public Property Block3Color As Color = Color.Green      'Allows to customize the color of the type 3 blocks
    Public Property Block4Color As Color = Color.Aqua       'Allows to customize the color of the type 4 blocks
    Public Property Block5Color As Color = Color.Brown      'Allows to customize the color of the type 5 blocks
    Public Property Block6Color As Color = Color.Yellow     'Allows to customize the color of the type 6 blocks
    Public Property Block7Color As Color = Color.Purple     'Allows to customize the color of the type 7 blocks
#End Region

#Region "Public Properties"
    'Gets or sets the Timer interval (game speed). The shorter interval, the higher speed.
    Public Property TimerInterval As Integer
        Get
            Return _timer.Interval
        End Get
        Set(value As Integer)
            _timer.Interval = value
        End Set
    End Property

    'Gets or sets the first color of the gradient when BackgroundStyle = Gradient
    Public Property GradientColor1 As Color
        Get
            Return _gradientColor1
        End Get
        Set(value As Color)
            _gradientColor1 = value
            If Me.BackgroundStyle = BackgroundStyles.Gradient Then Me.Invalidate()
        End Set
    End Property

    'Gets or sets the second color of the gradient when BackgroundStyle = Gradient
    Public Property GradientColor2 As Color
        Get
            Return _gradientColor2
        End Get
        Set(value As Color)
            _gradientColor2 = value
            If Me.BackgroundStyle = BackgroundStyles.Gradient Then Me.Invalidate()
        End Set
    End Property

    'Gets or sets the direction of the gradient when BackgroundStyle = Gradient
    Public Property GradientDirection As Drawing2D.LinearGradientMode
        Get
            Return _gradientDirection
        End Get
        Set(value As Drawing2D.LinearGradientMode)
            _gradientDirection = value
            If Me.BackgroundStyle = BackgroundStyles.Gradient Then Me.Invalidate()
        End Set
    End Property

    'Gets or sets the background style
    Public Property BackgroundStyle As BackgroundStyles
        Get
            Return _backgroundStyle
        End Get
        Set(value As BackgroundStyles)
            _backgroundStyle = value
            Me.Invalidate()
        End Set
    End Property

    'Gets or sets the number of rows in the game board
    Public Property Rows As Integer
        Get
            Return _rows
        End Get
        Set(value As Integer)
            _rows = value
            Me.Invalidate()
        End Set
    End Property

    'Gets or sets the number of columns in the game board
    Public Property Columns As Integer
        Get
            Return _columns
        End Get
        Set(value As Integer)
            _columns = value
            Me.Invalidate()
        End Set
    End Property

    'Gets or sets the cell size (in pixels)
    Public Property CellSize As Integer
        Get
            Return _cellSize
        End Get
        Set(value As Integer)
            _cellSize = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "OnPaint"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        'First, set the control's size
        Me.Width = (Me.Columns * Me.CellSize) - (Me.Columns - 1)
        Me.Height = (Me.Rows * Me.CellSize) - (Me.Rows - 1)

        'Draw the background
        Select Case Me.BackgroundStyle
            Case BackgroundStyles.SolidColor
                'Draws a single color
                e.Graphics.Clear(Me.BackColor)

            Case BackgroundStyles.Gradient
                'Draws a gradient
                Using b As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush(Me.DisplayRectangle, Me.GradientColor1, Me.GradientColor2, Me.GradientDirection)
                    e.Graphics.FillRectangle(b, Me.DisplayRectangle)
                End Using

            Case BackgroundStyles.Picture
                'Draws a picture if BackgroundImage is set; if not, draws a single color
                If Me.BackgroundImage IsNot Nothing Then
                    e.Graphics.DrawImage(Me.BackgroundImage, 0, 0, Me.Width, Me.Height)
                Else
                    e.Graphics.Clear(Me.BackColor)
                End If
        End Select

        'Paint cells
        If _board IsNot Nothing Then
            For row As Integer = 0 To Me.Rows - 1
                For column As Integer = 0 To Me.Columns - 1
                    'Get the cell color
                    Dim c As Color = _board.GetCellColor(New CellPoint(row, column))
                    If c <> Color.Transparent Then
                        'Draw the cell background
                        Using b As SolidBrush = New SolidBrush(c)
                            e.Graphics.FillRectangle(b, New Rectangle(column * (Me.CellSize - 1), row * (Me.CellSize - 1), Me.CellSize - 1, Me.CellSize - 1))
                        End Using
                        'Draw the cell border
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(column * (Me.CellSize - 1), row * (Me.CellSize - 1), Me.CellSize - 1, Me.CellSize - 1))
                    End If
                Next
            Next
        End If
    End Sub
#End Region

#Region "Public Methods And Functions"
    Public Sub StartGame()
        'Starts a game
        If (Not Me.IsRunning) AndAlso (Not Me.IsPaused) Then
            'Initialize the ramdom number generator
            Randomize()
            'Initialize the game board
            _board = New Board(Me.Rows, Me.Columns)
            With _board
                .Block1Color = Me.Block1Color
                .Block2Color = Me.Block2Color
                .Block3Color = Me.Block3Color
                .Block4Color = Me.Block4Color
                .Block5Color = Me.Block5Color
                .Block6Color = Me.Block6Color
                .Block7Color = Me.Block7Color
            End With
            'Add handlers to catch board events
            AddHandler _board.FullRows, AddressOf CatchFullRows
            AddHandler _board.GameOver, AddressOf CatchGameOver
            AddHandler _board.GotNewBlock, AddressOf CatchNewBlock
            'Set that the game is running
            _running = True
            'Initialize the keyboard hook
            _hook = New KeyboardHook()
            'Notify user
            RaiseEvent Starting(Me, New System.EventArgs)
            'Start the timer
            _timer.Start()
        End If
    End Sub

    Public Sub StopGame()
        'Stops a running game
        If Me.IsRunning() Then
            'Stop the timer
            _timer.Stop()
            'Not running
            _running = False
            'Not paused
            _pause = False
            'Dispose the keyboard hook
            _hook.Dispose()
            _hook = Nothing
        End If
    End Sub

    Public Function FreeRowsFromTop() As Integer
        'In classic Tetris game, the game was not continuous, but the player should be playing among different screens, each one with its one goal. For example, the first
        'screen was an initial empty board and the player must play until he completes 5 full rows. In this game system, when a new screen was achieved, the game rewarded
        'the player not only for the full rows completed, but also for the completely free rows from the top of the board until the first not-completely free row. So you
        'can use this function to get the number of free rows from board's top.
        Dim freeRows As Integer = 0
        If _board IsNot Nothing Then
            For row As Integer = 0 To Me.Rows - 1
                Dim freeRow As Boolean = True
                For column As Integer = 0 To Me.Columns - 1
                    If _board.Cells(row.ToString + "," + column.ToString).Fixed Then
                        freeRow = False
                        Exit For
                    End If
                Next
                If freeRow Then
                    freeRows += 1
                Else
                    Exit For
                End If
            Next
        End If
        Return freeRows
    End Function

    Public Sub AddRandomBlock()
        'Adds a random block to the board. The block is always positioned over the board's bottom or a existing fixed cell.

        'Choose the column
        Dim whichColumn As Integer
        Do
            whichColumn = GetRandomNumber(0, Me.Columns - 1)
        Loop Until (Not _board.Cells("0," + whichColumn.ToString).Fixed)

        'Check for a fixed cell in the column to position the random block over it.
        For row As Integer = Me.Rows - 1 To 0 Step -1
            If (Not _board.Cells(row.ToString + "," + whichColumn.ToString).Fixed) Then
                _board.Cells(row.ToString + "," + whichColumn.ToString).Fixed = True
                _board.Cells(row.ToString + "," + whichColumn.ToString).Color = Me.RandomBlockColor
                Me.Invalidate()
                Exit For
            End If
        Next
    End Sub

    Public Sub AddUncompleteRow()
        'Adds an uncomplete row at the bottom of the board, moving up the rest of the cells. This can cause a game over.
        Dim forceGameOver As Boolean = False

        'If there's a fixed cell in first row, moving up the entire board will cause a game over
        If ThereIsSomethingInFirstRow() Then
            forceGameOver = True
        End If
        'Move all the board up 1 row
        For row As Integer = 0 To Me.Rows - 2
            For column As Integer = 0 To Me.Columns - 1
                _board.Cells(row.ToString + "," + column.ToString).Fixed = _board.Cells((row + 1).ToString + "," + column.ToString).Fixed
                _board.Cells(row.ToString + "," + column.ToString).Color = _board.Cells((row + 1).ToString + "," + column.ToString).Color
            Next
        Next
        'Choose the empty column
        Dim emptyColumn As Integer = GetRandomNumber(0, Me.Columns - 1)
        'Draw the uncomplete row
        For column As Integer = 0 To Me.Columns - 1
            If column.Equals(emptyColumn) Then
                _board.Cells((Me.Rows - 1).ToString + "," + column.ToString).Fixed = False
            Else
                _board.Cells((Me.Rows - 1).ToString + "," + column.ToString).Fixed = True
                _board.Cells((Me.Rows - 1).ToString + "," + column.ToString).Color = Me.UncompleteRowColor
            End If
        Next
        'Redraw
        Me.Invalidate()
    End Sub

    Public Function IsRunning() As Boolean
        'Returns True if a game is running
        Return _running
    End Function

    Public Function IsPaused() As Boolean
        'Returns True if a game is paused
        Return _pause
    End Function

    Public Sub Pause()
        'Pauses a running game
        If Me.IsRunning AndAlso (Not Me.IsPaused) Then
            _pause = True
        End If
    End Sub

    Public Sub [Resume]()
        If Me.IsPaused Then
            _pause = False
        End If
    End Sub
#End Region

#Region "Private Methods And Functions"
    'Timer elapsed event
    Private Sub TimerElapsed(sender As Object, e As System.EventArgs)
        If (Not Me.IsPaused) Then
            'Redraw the board and check the current falling block
            Call RedrawAndCheckBlock()

            If _board.FallingBlock Is Nothing Then
                'If there's not a falling block, create new one
                Call _board.NewBlock()
                Call RedrawAndCheckBlock()
            Else
                'Drop the falling block 1 line
                _board.FallingBlock.Y += 1
            End If
        End If
    End Sub

    'Redraws the board and checks the falling block
    Private Sub RedrawAndCheckBlock()
        Me.Invalidate()
        Call _board.CheckBlock()
    End Sub

    'Catches keystrokes
    Private Sub _hook_KeyDown(Key As Keys) Handles _hook.KeyDown
        If (Not Me.IsPaused) Then
            If Key = Me.LeftKey Then
                If _board.MoveLeft() Then Call RedrawAndCheckBlock()
            ElseIf Key = Me.RightKey Then
                If _board.MoveRight() Then Call RedrawAndCheckBlock()
            ElseIf Key = Me.DropKey Then
                'If the user presses the Drop key, force a 1-line drop
                Call TimerElapsed(Nothing, Nothing)
            ElseIf Key = Me.RotateKey Then
                If _board.Rotate() Then Call RedrawAndCheckBlock()
            End If
        End If
    End Sub

    'The board notifies that the player has completed full rows. Notify and redraw board.
    Private Sub CatchFullRows(sender As Object, e As FullRowsEventArgs)
        RaiseEvent FullRows(Me, e)
        Me.Invalidate()
    End Sub

    'The board notifies that the game is over.
    Private Sub CatchGameOver(sender As Object, e As System.EventArgs)
        'Stop the game
        Call StopGame()

        'Notify the user
        RaiseEvent GameOver(Me, e)
    End Sub

    'The board notifies that a new block has been created. Notify.
    Private Sub CatchNewBlock(sender As Object, e As NewBlockEventArgs)
        RaiseEvent NewBlock(sender, e)
    End Sub

    'Checks if there is a fixed cell in the first row
    Private Function ThereIsSomethingInFirstRow() As Boolean
        Dim output As Boolean = False
        For column = 0 To Me.Columns - 1
            If _board.Cells("0," + column.ToString).Fixed Then
                output = True
                Exit For
            End If
        Next
        Return output
    End Function

    Private Function GetRandomNumber(ByVal lowerbound As Integer, ByVal upperbound As Integer) As Integer
        'Get a random integer number as seen on MSDN
        Return CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
    End Function
#End Region
End Class
