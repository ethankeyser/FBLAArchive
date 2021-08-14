'Imports the data needed to obtain the values from the database
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Timers

Public Class Window3
    'calls the conncetion and questions from the database and assigns them to variables
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim Q As New questions
    Dim questionContent As String
    Dim answerContent As String
    Dim reader As MySqlDataReader
    Dim IsAnswered As String
    Dim result As New resultGen
    Dim QuestionData As String
    Dim QuestionData1 As String
    Dim IsComplete As String
    Dim TryData As New AccessData

    Private Sub Window3_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        'When the window loads the screen will display a random question from the database and the answers will coorespond to the question asked.
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        Dim Q2 As New Integer
        Dim r As Random = New Random
        Time.Text = diff.ToString("mm\:ss")
        Dim StopWatch As New Timer(1000)
        StopWatch.Enabled = True
        StopWatch.Start()
        AddHandler StopWatch.Elapsed, New ElapsedEventHandler(AddressOf TimePassed)
        progBar1.Value = 60
        'calls the questions from the class set previously that obtains all of the data needed from the database
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'creates a variable that stores a random number between 0 and 29, this only goes to 29 because there are only 30 questions that are multiple choice/dropdown
        'the program continues to create a random number until the new question number is not equal to the second questions number     
        Q3 = r.Next(20, 30)

        'assigns the question box and the radio buttons to the data from the database
        qText.Text = "Question 3: " + dsQuestions.Tables(0).Rows(Q3).ItemArray(0).ToString()
        cb1.Items.Add(dsQuestions.Tables(0).Rows(Q3).ItemArray(1).ToString())
        cb1.Items.Add(dsQuestions.Tables(0).Rows(Q3).ItemArray(2).ToString())
        cb1.Items.Add(dsQuestions.Tables(0).Rows(Q3).ItemArray(3).ToString())
        cb1.Items.Add(dsQuestions.Tables(0).Rows(Q3).ItemArray(4).ToString())
        answerContent = dsQuestions.Tables(0).Rows(Q3).ItemArray(1).ToString() + ";" + dsQuestions.Tables(0).Rows(Q3).ItemArray(2).ToString() + ";" + dsQuestions.Tables(0).Rows(Q3).ItemArray(3).ToString() + ";" + dsQuestions.Tables(0).Rows(Q3).ItemArray(4).ToString()
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
        rightans3 = dsQuestions.Tables(0).Rows(Q3).ItemArray(5)
        'checks if the answer selected by the user is correct and if it is, the counter for total questions correct goes 
        'up and the correct1 value is true so that the program will later know that the user answered this question right
        'this code also checks if the user selected an answer and if not displays a message to tell the user to select an answer
        If cb1.SelectedItem <> "" Then

            If rightans3 = 1 Then
                If cb1.SelectedItem.Equals(dsQuestions.Tables(0).Rows(Q3).ItemArray(1).ToString()) Then
                    correct3 = True
                End If
            ElseIf rightans3 = 2 Then
                If cb1.SelectedItem.Equals(dsQuestions.Tables(0).Rows(Q3).ItemArray(2).ToString()) Then
                    correct3 = True
                End If
            ElseIf rightans3 = 3 Then
                If cb1.SelectedItem.Equals(dsQuestions.Tables(0).Rows(Q3).ItemArray(3).ToString()) Then
                    correct3 = True
                End If
            ElseIf rightans3 = 4 Then
                If cb1.SelectedItem.Equals(dsQuestions.Tables(0).Rows(Q3).ItemArray(4).ToString()) Then
                    correct3 = True
                End If
            End If
            mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
            'if the user did not check the box on the previous warning window, another warning message will show, if the box was check, then the next window will be opened
            If warningMessage = True Then

                Dim ques3warn As New Window9
                ques3warn.Show()
            Else

                If correct3 = True Then
                    counter += 1
                End If
                Dim ques4 As Window4 = New Window4()
                ques4.Show()
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
        'if the quiz is attempting to be saved the IsComplete value is set to 0 and the first and second question is scored to be stored in the database
        IsComplete = "0"
        Dim QUNum As String = "3"
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        If correct2 = True Then
            QuestionData = result.calcResult(True, 2)
        Else
            QuestionData = result.calcResult(False, 2)
        End If
        If correct1 = True Then
            QuestionData1 = result.calcResult(True, 1)
        Else
            QuestionData1 = result.calcResult(False, 1)
        End If
        'uses the AccessDatabase function to put the question 1 and 2 data into the database along with the counter, time, question number, and IsComplete value
        TryData.AccessDatabase(identify.ToString(), "1", QuestionData1)
        TryData.AccessDatabase(identify.ToString(), "2", QuestionData)
        TryData.AccessDatabase(identify.ToString(), "Count", counter)
        TryData.AccessDatabase(identify.ToString(), "QN", QUNum)
        TryData.AccessDatabase(identify.ToString(), "Time", diff.ToString())
        TryData.AccessDatabase(identify.ToString(), "IC", IsComplete)
        Me.Close()
    End Sub
End Class
