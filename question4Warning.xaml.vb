Public Class Window10
    Dim WarnContent As String
    Private Sub NextWindow_Click(sender As Object, e As RoutedEventArgs)
        If correct4 = True Then
            counter += 1
        End If
        'when the user clicks the next question button, the next window will be displayed 
        Dim ques5 As New Window5
        ques5.Show()
        'the warning message will be closed
        Me.Close()
        'the program loops through all of the open windows and if the title of a window is open that is not the next question, it will be closed
        For Each f As Window In System.Windows.Application.Current.Windows
            If ques5.Title <> f.Title Then
                f.Close()
            End If
        Next
        'if the user clicks the check box, the program will no longer display the warning messages by setting a variable to false and making sure that this variable is true
        'if a warning message is to be displayed
        If dbstmaMsg.IsChecked Then
            warningMessage = False
        End If
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
