'Imports the data needed to obtain the values from the database
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Timers

Public Class Window5
    'calls the conncetion and questions from the database and assigns them to variables
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim Q As New questions
    Dim questionContent As String
    Dim reader As MySqlDataReader
    Dim IsAnswered As String
    Dim result As New resultGen
    Dim QuestionData As String
    Dim QuestionData1 As String
    Dim QuestionData2 As String
    Dim QuestionData3 As String
    Dim IsComplete As String
    Dim TryData As New AccessData
    Private Sub Window5_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        'When the window loads the screen will display a random question from the database and the answers will coorespond to the question asked.
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        Dim r As Random = New Random
        Time.Text = diff.ToString("mm\:ss")
        Dim StopWatch As New Timer(1000)
        StopWatch.Enabled = True
        StopWatch.Start()
        AddHandler StopWatch.Elapsed, New ElapsedEventHandler(AddressOf TimePassed)
        progBar1.Value = 100
        'calls the questions from the class set previously that obtains all of the data needed from the database
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'creates a variable that stores a random number between 40 and 49, this only goes to 49 because there are only 10 questions that are fill in the blank
        Randomize()
        Q5 = r.Next(40, 50)
        'assigns the question box to the data from the database
        qText.Text = "Question 5: Fill in the blank(please use the correct spelling and spacing and use words not numbers for the respective questions): " + dsQuestions.Tables(0).Rows(Q5).ItemArray(0).ToString()
        'shows the user their ID
        ID_Label.Content = "ID: " + identify.ToString

    End Sub

    Private Sub NextQuestion_Click(sender As Object, e As RoutedEventArgs)
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        Dim rightans As String
        'calls the questions once again from the class
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'assigns the global variable of rightans1 to the correct answer from the database so that this variable can be used here and in the results
        rightans = dsQuestions.Tables(0).Rows(Q5).ItemArray(6)
        'checks if the answer entered by the user is correct and if it is, the counter for total questions correct goes 
        'up and the correct5 value is true so that the program will later know that the user answered this question right
        'the text entered by the user must be converted into uppercase because the answer in the database is uppercase
        aText.Text = aText.Text.Trim()
        If aText.Text.ToUpper = rightans Then
            correct5 = True
        End If
        'checks if the user entered text and if they did then the warning message will show or the next window will show, if not, the prgram will prompt the user to type an answer
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        If aText.Text <> "" Then
            'if the user did not check the box on the previous warning window, another warning message will show, if the box was check, then the next window will be opened
            If warningMessage = True Then

                IsComplete = "1"
                TryData.AccessDatabase(identify.ToString(), "IC", IsComplete)
                Dim ques5warn As New Window11
                ques5warn.Show()
            Else

                If correct5 = True Then
                    counter += 1
                End If
                IsComplete = "1"
                TryData.AccessDatabase(identify.ToString(), "IC", IsComplete)
                Dim results As Window6 = New Window6()
                results.Show()
                Me.Close()
            End If
        Else
            MessageBox.Show("Please type an answer", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
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
        'if the quiz is attempting to be saved the IsComplete value is set to 0 and the first, second, third, and fourth question is scored to be stored in the database
        IsComplete = "0"
        Dim QUNum As String = "5"
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        If correct4 = True Then
            QuestionData = result.calcResult(True, 4)
        Else
            QuestionData = result.calcResult(False, 4)
        End If
        If correct3 = True Then
            QuestionData1 = result.calcResult(True, 3)
        Else
            QuestionData1 = result.calcResult(False, 3)
        End If
        If correct2 = True Then
            QuestionData2 = result.calcResult(True, 2)
        Else
            QuestionData2 = result.calcResult(False, 2)
        End If
        If correct1 = True Then
            QuestionData3 = result.calcResult(True, 1)
        Else
            QuestionData3 = result.calcResult(False, 1)
        End If
        'uses the AccessDatabase function to put the question 1, 2, 3, and 4 data into the database along with the counter, time, question number, and IsComplete value
        TryData.AccessDatabase(identify.ToString(), "1", QuestionData3)
        TryData.AccessDatabase(identify.ToString(), "2", QuestionData2)
        TryData.AccessDatabase(identify.ToString(), "3", QuestionData1)
        TryData.AccessDatabase(identify.ToString(), "4", QuestionData)
        TryData.AccessDatabase(identify.ToString(), "Count", counter)
        TryData.AccessDatabase(identify.ToString(), "QN", QUNum)
        TryData.AccessDatabase(identify.ToString(), "Time", diff.ToString())
        TryData.AccessDatabase(identify.ToString(), "IC", IsComplete)
        Me.Close()
    End Sub
End Class
