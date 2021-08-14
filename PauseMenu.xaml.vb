Imports System.Timers

Public Class PauseMenu
    Private Sub PauseMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        Test_Time.Text = "00:00"
        Dim PauseTime As New Timer(1000)
        'starts a new timer to keep track of how much time is spent in the pause menu
        PauseTime.Enabled = True
        PauseTime.Start()
        now2 = DateTime.Now
        AddHandler PauseTime.Elapsed, New ElapsedEventHandler(AddressOf TimePassed)
    End Sub

    Private Sub Resume_Button_Click(sender As Object, e As RoutedEventArgs)
        'when the resume button is clicked the IsPaused value is set to false
        IsPaused = False
        'Time is added to the accumulated pause time to display the correct time when the quiz is opened back up
        AccumulatedPauseTime += diff2
        'creates new instances of the warning windows and closes them if opened when the resume button is clicked
        Dim Warning1 As Window7 = New Window7()
        Dim Warning2 As Window8 = New Window8()
        Dim Warning3 As Window9 = New Window9()
        Dim Warning4 As Window10 = New Window10()
        Dim Warning5 As Window11 = New Window11()
        For Each f As Window In System.Windows.Application.Current.Windows
            If Title <> f.Title And Warning1.Title <> f.Title And Warning2.Title <> f.Title And Warning3.Title <> f.Title And Warning4.Title <> f.Title And Warning5.Title <> f.Title Then
                f.Show()
            End If
        Next
        PauseTime.Stop()
        PauseTime.Dispose()
        Me.Close()
    End Sub

    Private Async Sub TimePassed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        'accumaltes the time when the quiz is paused so that the correct time is displayed after the resume button is clicked
        If IsPaused = True Then
            diff2 = New TimeSpan()
            diff2 = DateTime.Now - now2
            Dim format As String = "mm:ss"
            Await Task.Run(Async Function()
                               Test_Time.Dispatcher.Invoke(Sub() Test_Time.Text = diff2.ToString("mm\:ss"))
                           End Function)

        End If

    End Sub
End Class
