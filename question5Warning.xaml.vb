Public Class Window11
    Dim WarnContent As String
    Private Sub NextWindow_Click(sender As Object, e As RoutedEventArgs)
        'when the user clicks the next question button, the next window will be displayed 
        If correct5 = True Then
            counter += 1
        End If
        Dim results As New Window6
        results.Show()
        'the warning message will be closed
        Me.Close()
        'the program loops through all of the open windows and if the title of a window is open that is not the next question, it will be closed
        For Each f As Window In System.Windows.Application.Current.Windows
            If results.Title <> f.Title Then
                f.Close()
            End If
        Next
    End Sub

    Private Sub Close_Click(sender As Object, e As RoutedEventArgs)
        'if the user does not wish to proceed, the warning message will be closed and the user will return to the original question
        Me.Close()
    End Sub
    Private Function GenerateTTS()
        'creates a text to speech object that reads what is on the page
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.speak(WarnContent)
        Return True
    End Function

    Private Async Sub TTS_Click(sender As Object, e As RoutedEventArgs)
        'runs the text to speech funciton in a seperate thread to prevent the screen from freezing
        WarnContent = warn.Text
        Await Task.Run(Function() GenerateTTS())
    End Sub

End Class
