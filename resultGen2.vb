
Imports MySql.Data.MySqlClient

Public Class resultGen2
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim result As resultGen
    Public Function CalcResult2(ByRef QNum As Int16)
        Dim Q1Content As String
        Dim Q2Content As String
        Dim Q3Content As String
        Dim Q4Content As String
        'Checks the question number and returns a string using a mysqlcommand that contains the question data from past quizzes
        If QNum = 2 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q1Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q1Content = reader.GetString(0)
                    Return Q1Content
                End While
                mysqlconn.Close()

            Catch ex As Exception
            End Try

        End If
        If QNum = 3 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q1Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q1Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q2Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q2Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q1 = '" & Q1Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q2 = '" & Q2Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Return Q1Content And Q2Content
        End If
        If QNum = 4 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q1Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q1Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q2Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q2Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q3Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q3Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q1 = '" & Q1Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q2 = '" & Q2Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q3 = '" & Q3Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Return Q1Content And Q2Content And Q3Content
        End If
        If QNum = 5 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q1Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q1Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q2Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q2Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q3Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q3Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q4Data from example1.userdata where ID='" & identify & "' "
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                While reader.Read
                    Q4Content = reader.GetString(0)
                End While
                mysqlconn.Close()
            Catch ex As Exception
            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q1 = '" & Q1Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q2 = '" & Q2Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q3 = '" & Q3Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q4 = '" & Q4Content & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
            Return Q1Content And Q2Content And Q3Content And Q4Content
        End If

    End Function
End Class
