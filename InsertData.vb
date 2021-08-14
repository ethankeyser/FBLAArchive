Imports MySql.Data.MySqlClient

Public Class InsertData
    Dim mysqlconn As New MySqlConnection
    Public Function UpdateData(ByRef QNum As Int16, ByRef Data As String)
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        'This function inserts all of the data from the saved data into the collective database for the results so that the report shows the correct information
        If QNum = 1 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q1 = '" & Data & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
        ElseIf QNum = 2 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q2 = '" & Data & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
        ElseIf QNum = 3 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q3 = '" & Data & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
        ElseIf QNum = 4 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q4 = '" & Data & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
        ElseIf QNum = 5 Then
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q5 = '" & Data & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try
        End If
        Return True
    End Function
End Class
