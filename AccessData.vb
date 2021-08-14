Imports MySql.Data.MySqlClient

Public Class AccessData
    Dim mysqlconn As New MySqlConnection
    Public Function AccessDatabase(ByRef ID As String, ByRef Row As String, ByRef data As String)
        Dim Command As MySqlCommand
        Dim reader As MySqlDataReader
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        'depending on what data needs to be changed, the function requires a row number to change certain rows of data in the database, along with an ID to know which data to change
        If Row = "1" Then
            Try
                mysqlconn.Open()
                Dim query As String
                'uses a query to update specific data in the database
                query = "UPDATE example1.userdata SET Q1Data = '" & data & "' WHERE ID = '" & ID & "'"
                'a command is used along with the query and connection to execute the query
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
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
                query = "UPDATE example1.userdata SET Q2Data = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
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
                query = "UPDATE example1.userdata SET Q3Data = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "4" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET Q4Data = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "5" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET Q5Data = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "Count" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET Counter = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "Time" Then

            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET Time = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "IC" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET IsComplete = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "QN" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET QuestionNumber = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf Row = "score" Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.userdata SET Score = '" & data & "' WHERE ID = '" & ID & "'"
                Command = New MySqlCommand(query, mysqlconn)
                reader = Command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            Finally
                mysqlconn.Dispose()
            End Try
        End If

        Return True
    End Function
End Class
