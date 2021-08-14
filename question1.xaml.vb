'Imports the data needed to obtain the values from the database
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Timers
Public Class Window1
    'calls the conncetion and questions from the database and assigns them to variables
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim Q As New questions
    Dim answerContent As String
    Dim questionContent As String
    Dim reader As MySqlDataReader
    Dim IsAnswered As String


    Private Sub Window1_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        'When the window loads the screen will display a random question from the database and the answers will coorespond to the question asked.
        Dim StopWatch As New Timer(1000)
        StopWatch.Enabled = True
        StopWatch.Start()
        now = DateTime.Now
        AddHandler StopWatch.Elapsed, New ElapsedEventHandler(AddressOf TimePassed)
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        Dim r As Random = New Random

        progBar1.Value = 20
        'calls the questions from the class set previously that obtains all of the data needed from the database
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'creates a variable that stores a random number between 0 and 29, this only goes to 29 because there are only 30 questions that are multiple choice/dropdown
        Randomize()
        Q1 = r.Next(0, 10)

        'assigns the question box and the radio buttons to the data from the database

        qText.Text = "Question 1: " + dsQuestions.Tables(0).Rows(Q1).ItemArray(0).ToString()

        ans1.Content = dsQuestions.Tables(0).Rows(Q1).ItemArray(1).ToString()
        ans2.Content = dsQuestions.Tables(0).Rows(Q1).ItemArray(2).ToString()
        ans3.Content = dsQuestions.Tables(0).Rows(Q1).ItemArray(3).ToString()
        ans4.Content = dsQuestions.Tables(0).Rows(Q1).ItemArray(4).ToString()
        'shows the user their ID
        ID_Label.Content = "ID: " + identify.ToString

        Time.Text = diff.ToString("mm\:ss")
    End Sub

    Private Sub NextQuestion_Click(sender As Object, e As RoutedEventArgs)
        'checks to see if a warning message is already being displayed before opening a new one
        Dim warn As New Window7
        For Each f As Window In System.Windows.Application.Current.Windows
            If f.Title = warn.Title Then
                f.Close()
            End If
        Next
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions

        'calls the questions once again from the class
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'assigns the global variable of rightans1 to the correct answer from the database so that this variable can be used here and in the results
        rightans1 = dsQuestions.Tables(0).Rows(Q1).ItemArray(5)
        'checks if the answer selected by the user is correct and if it is, the counter for total questions correct goes 
        'up and the correct1 value is true so that the program will later know that the user answered this question right
        If rightans1 = 1 Then
            If ans1.IsChecked Then
                correct1 = True
            End If
        ElseIf rightans1 = 2 Then
            If ans2.IsChecked Then
                correct1 = True
            End If
        ElseIf rightans1 = 3 Then
            If ans3.IsChecked Then
                correct1 = True
            End If
        ElseIf rightans1 = 4 Then
            If ans4.IsChecked Then
                correct1 = True
            End If
        End If
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        'checks if the user selected an answer and if they did, the warning message will then show and if not, the program will display a message that says to select an answer
        If ans1.IsChecked Or ans2.IsChecked Or ans3.IsChecked Or ans4.IsChecked Then

            Dim formInstance As Window7 = New Window7()
            formInstance.Show()
        Else
            MessageBox.Show("Please select an answer", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
        End If
    End Sub

    Private Function GenerateTTS()
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.speak(questionContent)
        Return True
    End Function
    Private Async Sub QuestionText_Click(sender As Object, e As RoutedEventArgs)
        'creates a text to speech object to read the question on the page
        questionContent = qText.Text
        Await Task.Run(Function() GenerateTTS())
    End Sub

    Private Function GenerateTTS2()
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.speak(answerContent)
        Return True
    End Function
    Private Async Sub AnswerText_Click(sender As Object, e As RoutedEventArgs)
        'creates a text to speech object to read the answers on the page
        answerContent = ans1.Content + ";" + ans2.Content + ";" + ans3.Content + ";" + ans4.Content
        Await Task.Run(Function() GenerateTTS2())
    End Sub

    Private Function GetTime()
        'gets the correct time by starting a timer and subtracting the current time from the time the timer was started
        diff = New TimeSpan
        diff = DateTime.Now - now
        Time.Text = diff.ToString()
        Return True
    End Function
    Private Async Sub TimePassed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        'if the quiz is not paused, time is continually added to the timer
        If IsPaused = False Then
            diff = New TimeSpan()
            diff = DateTime.Now - now - AccumulatedPauseTime + TimeSpan.Parse(PulledTime)
            Dim format As String = "mm:ss"
            Await Task.Run(Async Function()
                               Time.Dispatcher.Invoke(Sub() Time.Text = diff.ToString("mm\:ss"))
                           End Function)

        End If
    End Sub

    Private Sub Pause_Click(sender As Object, e As RoutedEventArgs)
        StopWatch.Stop()
        IsPaused = True
        PauseCount += 1
        Me.Hide()
        Dim formInstance As PauseMenu = New PauseMenu()
        formInstance.Show()

    End Sub


End Class
