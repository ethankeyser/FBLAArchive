Imports MySql.Data.MySqlClient
Imports System.Data
Class MainWindow
    'creates the connection to the database as a variable
    Dim mysqlconn As MySqlConnection
    Public TitleContent As String
    Public DirectionsContent As String
    Dim IsComplete As String
    Dim QUNum As String
    Dim getData As New SelectData
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13;database=example1"
        Dim query As String
        query = "SELECT ID, firstname, lastname FROM example1.userdata"


        'Creates a new query and command that fills a data table to show the ID, First Name, and Last Name in a list box
        Dim cmd As New MySqlCommand(query, mysqlconn)
        Dim dr As MySqlDataReader
        Try
            mysqlconn.Open()
            dr = cmd.ExecuteReader
            'If there is data then this loop will run
            If dr.HasRows Then
                Do While dr.Read
                    'adds all the user data to a table that will be displayed for the user to see and use
                    IDBox.Items.Add("ID: " & dr.Item(0).ToString & "; First Name: " & dr.Item(1).ToString & "; Last Name: " & dr.Item(2).ToString)
                Loop
            End If
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())

        Finally
            mysqlconn.Dispose()
        End Try


    End Sub
    Private Sub Begin_Click(sender As Object, e As RoutedEventArgs)
        'when the user clicks the begin test button, the name window will open and the home window will close
        PulledTime = 0
        Dim name As Window12 = New Window12()
        name.Show()
        Me.Close()
    End Sub

    Private Sub test_conn_btn_Click(sender As Object, e As RoutedEventArgs) Handles test_conn_btn.Click
        'when the user clicks the test connection button, it will check if the connection to the database is successful
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13;database=example1"

        Try
            mysqlconn.Open()
            MessageBox.Show("Connection Success", "Connection Message", MessageBoxButton.OK, MessageBoxImage.Information)
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Message", MessageBoxButton.OK, MessageBoxImage.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Submit_Click(sender As Object, e As RoutedEventArgs)
        'this button, when pressed, allows the user to enter their ID given from any attempt to then see their score. 
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13;database=example1"
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader
        Dim idExists As Boolean = False
        If textBox1.Text <> "" Then
            IDfield = Int32.Parse(textBox1.Text)


            'this try command checks to see if the user has entered a valid ID and if not, sets the idExists variable to false and prompts the user to enter a valid ID
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select * from example1.pastresults where ID='" & IDfield & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                Dim count As Integer
                While reader.Read
                    count += 1
                End While
                If count = 1 Then
                    idExists = True
                Else
                    idExists = False
                End If
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                mysqlconn.Dispose()
            End Try
            'the user must fill out each field, if not, an error message is shown
            If textBox1.Text <> "" And idExists = True Then
                Dim dsData As New DataSet
                Dim strErrMsg As String = ""
                Dim oData As New userData
                Call oData.getAllUserData(dsData, strErrMsg)
                'checks to see if the test is complete and if it is then the IsComplete value is set to 1 and if not, it is set to 0
                IsComplete = getData.AccessDatabase(IDfield, "IC")

                'if the test is complete than a report is shown displaying quiz results and correct answers
                If IsComplete = "1" Then
                    Dim report As New Window13
                    report.Show()
                Else
                    'if the quiz is not complete the IsResume value is set to true and the time is pulled from the database to display the correct time while resuming the quiz
                    IsResume = True
                    identify = IDfield.ToString()
                    now = DateTime.Now

                    PulledTime = getData.AccessDatabase(identify, "7")
                    'pulls the question number from the database to open the correct question for the user to work on 
                    QUNum = getData.AccessDatabase(identify, "QN")
                    diff = TimeSpan.Parse(PulledTime)
                End If
                'opens the correct question based on the QUNum value 
                If QUNum = 2 Then
                    Dim formInstance As Window2 = New Window2()
                    formInstance.Show()
                    IsResume = True
                    Me.Close()

                ElseIf QUNum = 3 Then
                    Dim formInstance As Window3 = New Window3()
                    formInstance.Show()
                    IsResume = True
                    Me.Close()
                ElseIf QUNum = 4 Then
                    Dim formInstance As Window4 = New Window4()
                    formInstance.Show()
                    IsResume = True
                    Me.Close()
                ElseIf QUNum = 5 Then
                    Dim formInstance As Window5 = New Window5()
                    formInstance.Show()
                    IsResume = True
                    Me.Close()

                End If

            Else
                MessageBox.Show("Please enter a valid ID.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
            End If
        Else
            MessageBox.Show("Please Enter An ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
        End If
    End Sub

    Private Function GenerateTTS()
        'creates a text to speech object that reads what is on the page
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.speak(TitleContent + ";" + DirectionsContent)
    End Function

    Private Async Sub TTS_Click(sender As Object, e As RoutedEventArgs)
        'runs the text to speech funciton in a seperate thread to prevent the screen from freezing
        TitleContent = QuizTitle.Content
        DirectionsContent = directions.Text
        Await Task.Run(Function() GenerateTTS())
    End Sub

End Class
