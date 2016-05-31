Module modLoad

#Region " Main "
    Public Sub Main()
        Dim theGame As New Game
        theGame.Init()
        theGame.MainLoop()
        theGame.Kill()
    End Sub
#End Region

End Module

