Public Class Game
    Public Sub Init()
        Dim theSizer As New dlgAskSize
        theSizer.ShowDialog()

        g.Engine = New GameEngine

        Dim theGameFrm As New GameFrm
        theGameFrm.SetSize(theSizer.FieldW, theSizer.FieldH)
        theGameFrm.Show()

        g.Engine.InitEngine(theGameFrm.ScreenPtr, theSizer.FieldW, theSizer.FieldH, theSizer.MinesPrc)
        g.Engine.ImagesFolder = theSizer.ImagesFolder
        g.Engine.LoadBitmaps()
        g.Engine.LoadSounds()
        g.Engine.InitMap(True)

        theGameFrm.SetMineCount()
    End Sub

    Public Sub MainLoop()
        While Not g.Engine.GameOver
            g.GameFrm.AdjustTimer()
            Application.DoEvents()
        End While
    End Sub

    Public Sub Kill()
        g.Engine.Dispose()
        g.Engine = Nothing
    End Sub
End Class