'Imports the data needed to obtain the values from the database
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Timers

Public Class Window2
    'calls the conncetion and questions from the database and assigns them to variables
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim Q As New questions
    Dim answerContent As String
    Dim questionContent As String
    Dim reader As MySqlDataReader
    Dim IsAnswered As String
    Dim result As New resultGen
    Dim QuestionData As String
    Dim IsComplete As String
    Dim TryData As New AccessData
    Private Sub Window2_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        'When the window loads the screen will display a random question from the database and the answers will coorespond to the question asked.
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        Dim Q1 As New Integer
        Dim r As Random = New Random
        Time.Text = diff.ToString("mm\:ss")
        Dim StopWatch As New Timer(1000)
        StopWatch.Enabled = True
        StopWatch.Start()
        AddHandler StopWatch.Elapsed, New ElapsedEventHandler(AddressOf TimePassed)
        progBar1.Value = 40
        'calls the questions from the class set previously that obtains all of the data needed from the database
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'creates a variable that stores a random number between 0 and 29, this only goes to 29 because there are only 30 questions that are multiple choice/dropdown
        'the program continues to create a random number until the new question number is not equal to the first questions number

        Randomize()
        Q2 = r.Next(10, 20)

        'assigns the question box and the radio buttons to the data from the database
        qText.Text = "Question 2: " + dsQuestions.Tables(0).Rows(Q2).ItemArray(0).ToString()
        ans1.Content = dsQuestions.Tables(0).Rows(Q2).ItemArray(1).ToString()
        ans2.Content = dsQuestions.Tables(0).Rows(Q2).ItemArray(2).ToString()
        ans3.Content = dsQuestions.Tables(0).Rows(Q2).ItemArray(3).ToString()
        ans4.Content = dsQuestions.Tables(0).Rows(Q2).ItemArray(4).ToString()
        'shows the user their ID
        ID_Label.Content = "ID: " + identify.ToString
    End Sub

    Private Sub NextQuestion_Click(sender As Object, e As RoutedEventArgs)
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        'calls the questions once again from the class
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'assigns the global variable of rightans1 to the correct answer from the database so that this variable can be used here and in the results
        rightans2 = dsQuestions.Tables(0).Rows(Q2).ItemArray(5)
        'checks if the answer selected by the user is correct and if it is, the counter for total questions correct goes 
        'up and the correct1 value is true so that the program will later know that the user answered this question right
        If rightans2 = 1 Then
            If ans1.IsChecked Then
                correct2 = True
            End If
        ElseIf rightans2 = 2 Then
            If ans2.IsChecked Then
                correct2 = True
            End If
        ElseIf rightans2 = 3 Then
            If ans3.IsChecked Then
                correct2 = True
            End If
        ElseIf rightans2 = 4 Then
            If ans4.IsChecked Then
                correct2 = True
            End If
        End If
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        'checks if the user selected an answer and if they did, the warning message will then show and if not, the program will display a message that says to select an answer
        If ans1.IsChecked Or ans2.IsChecked Or ans3.IsChecked Or ans4.IsChecked Then

            'if the user did not check the box on the previous warning window, another warning message will show, if the box was check, then the next window will be opened
            If warningMessage = True Then

                Dim ques2warn As New Window8
                ques2warn.Show()
            Else

                If correct2 = True Then
                    counter += 1
                End If
                Dim ques3 As Window3 = New Window3()
                ques3.Show()
                Me.Close()
            End If
        Else
            MessageBox.Show("Please select an answer.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
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

    Private Async Sub TimePassed(ByVal sender As Object, ByVal e As ElapsedEventArgs)

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

    Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
        'if the quiz is attempting to be saved the IsComplete value is set to 0 and the first question is scored to be stored in the database
        IsComplete = "0"
        Dim QUNum As String = "2"
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        If correct1 = True Then
            QuestionData = result.calcResult(True, 1)
        Else
            QuestionData = result.calcResult(False, 1)
        End If
        'uses the AccessDatabase function to put the question data into the database along with the counter, time, question number, and IsComplete value
        TryData.AccessDatabase(identify.ToString(), "1", QuestionData)
        TryData.AccessDatabase(identify.ToString(), "Count", counter)
        TryData.AccessDatabase(identify.ToString(), "QN", QUNum)
        TryData.AccessDatabase(identify.ToString(), "Time", diff.ToString())
        TryData.AccessDatabase(identify.ToString(), "IC", IsComplete)
        Me.Close()
    End Sub
End Class
