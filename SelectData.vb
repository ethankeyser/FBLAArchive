Imports MySql.Data.MySqlClient

Public Class SelectData
    Dim mysqlconn As New MySqlConnection
    Public Function AccessDatabase(ByRef ID As String, ByRef Row As String)
        Dim Command As MySqlCommand
        Dim reader As MySqlDataReader
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        Dim dataPulled As String
        'Uses a row variable to determine which data needs to be retrived and then returns a string that contains the data desired
        If Row = "1" Then
            Try
                mysqlconn.Open()
                Dim query As String
                'query used to retrieve the data from the database
                query = "select Q1Data from example1.userdata where ID='" & identify & "' "
                'a mysqlcommand that uses a query and a connection to access the data in the database
                Command = New MySqlCommand(query, mysqlconn)
                'the reader is used to read the data pulled from the command
                reader = Command.ExecuteReader
                'the while loop allows the reader to get the data and put it in string format
                While reader.Read
                    dataPulled = reader.GetString(0)
                    Return dataPulled
                End While
                'closes the connection once everything is retrieved
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try

        ElseIf Row = "2" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q2Data from example1.userdata where ID='" & identify & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                    Return dataPulled
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try

        ElseIf Row = "3" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q3Data from example1.userdata where ID='" & identify & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "4" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q4Data from example1.userdata where ID='" & identify & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "5" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Q5Data from example1.userdata where ID='" & identify & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "Count" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Counter from example1.userdata where ID='" & identify & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "7" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select Time from example1.userdata where ID='" & ID & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "IC" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select IsComplete from example1.userdata where ID='" & ID & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "QN" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select QuestionNumber from example1.userdata where ID='" & identify & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "FN" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select firstname from example1.userdata where ID='" & ID & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0)
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        ElseIf Row = "Score" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "select score from example1.userdata where ID='" & ID & "' "
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                While reader.Read
                    dataPulled = reader.GetString(0) + "/5"
                End While
                mysqlconn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
            Return dataPulled
        End If

        Return True
    End Function
End Class
