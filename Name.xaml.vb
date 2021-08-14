Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Window12

    Private Sub Submit_Click(sender As Object, e As RoutedEventArgs)
        Dim mysqlconn As New MySqlConnection
        Dim command As MySqlCommand
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        Dim reader As MySqlDataReader
        Dim notDupe As Boolean = True
        Dim dsID As New DataSet
        Dim reader2 As MySqlDataReader
        Dim moveOn As Boolean = False
        Dim tryCount As Integer = 0
        'the user must fill out each field, if not, an error message is shown
        If fName.Text = "" Or lName.Text = "" Then
            MessageBox.Show("Please enter a first and last name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
        Else
            'the loop continues to run until an original id is given
            While moveOn = False
                Try
                    mysqlconn.Open()
                    'the random number generator is initialized and it generates a random number for the identify variable
                    Randomize()
                    identify = CInt(Int((100000 * Rnd()) + 1))
                    'the program then inserts the users first name, last name, and picks a random ID while leaving the score as a non-existant value
                    Dim query As String
                    query = "insert into example1.userdata (ID, firstname,lastname,score) values ('" & identify & "','" & fName.Text & "','" & lName.Text & "','') "
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    mysqlconn.Close()
                Catch ex As Exception
                    'this measure is introduced to make sure that an error message does not show the first time because of the nature of the code
                    If tryCount >= 1 Then
                        notDupe = False
                    End If
                Finally
                    mysqlconn.Dispose()
                End Try
                Try
                    'this try statement tests to see if the ID given is duplicate 
                    mysqlconn.Open()
                    Dim query As String
                    query = "select * from example1.userdata where ID='" & identify & "' "
                    command = New MySqlCommand(query, mysqlconn)
                    reader2 = command.ExecuteReader
                    Dim counter As Integer
                    While reader2.Read
                        counter += 1
                    End While
                    mysqlconn.Close()
                    'if the ID is a duplicate, the program creates a new unique ID between 1 and 10000
                    If counter > 1 Then
                        mysqlconn.Open()
                        Dim reader3 As MySqlDataReader
                        Randomize()
                        identify = CInt(Int((100000 * Rnd()) + 1))
                        Dim query2 As String
                        query2 = "insert into example1.userdata (ID, firstname,lastname,score) values ('" & identify & "','" & fName.Text & "','" & lName.Text & "','') "
                        command = New MySqlCommand(query, mysqlconn)
                        reader3 = command.ExecuteReader
                        notDupe = True
                        mysqlconn.Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    'if the ID is not a duplicate then the program checks once more and shows the user their ID and proceeds to the next window
                    If notDupe = True Then
                        mysqlconn.Open()
                        Dim query As String
                        query = "select * from example1.userdata where ID='" & identify & "' "
                        command = New MySqlCommand(query, mysqlconn)
                        reader2 = command.ExecuteReader
                        Dim counter As Integer
                        While reader2.Read
                            counter += 1
                        End While
                        If counter <= 1 Then
                            moveOn = True
                        End If
                        mysqlconn.Close()

                        MessageBox.Show("Your ID is: " + identify.ToString, "ID", MessageBoxButton.OK, MessageBoxImage.Information)
                        Dim ques1 As New Window1
                        ques1.Show()
                        Me.Close()
                        mysqlconn.Close()
                    End If
                    mysqlconn.Dispose()
                End Try
                'after every loop, the trycount moves up 1 
                tryCount += 1
            End While
        End If

    End Sub
End Class
