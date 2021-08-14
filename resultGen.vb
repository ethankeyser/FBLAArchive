Imports MySql.Data.MySqlClient
Imports System.Data


Public Class resultGen
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim Q As New questions
    Dim reader As MySqlDataReader
    Public Function calcResult(ByRef isCorrect As Boolean, ByRef quNum As Int16)
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13; database=example1"
        'When the window loads, the window displays if each question was answered correctly and if not it will show the correct answer
        Dim dsQuestions As New DataSet
        Dim strErrMsg As String = ""
        Dim oQuestions As New questions
        'calls the questions from the class set previously that obtains all of the data needed from the database
        Call oQuestions.getAllQuestion(dsQuestions, strErrMsg)
        'Checks if the question was answered correctly through the use of a boolean variable that was set to either true or false based on if the user selected or 
        'typed the correct answer 
        'if the user answered incorrectly the text of the label will display the correct answer
        'each if statement, the program adds the results to a new database so that they can be used in the future if somebody would like to return to the program and see their results
        Dim LabelName As String
        If quNum = 1 Then
            If isCorrect = True Then
                LabelName = "Question 1 was correct!"
            Else
                LabelName = "Question 1 was incorrect" + "; Correct answer: " + dsQuestions.Tables(0).Rows(Q1).ItemArray(rightans1)
            End If
            Try
                mysqlconn.Open()
                Dim query As String
                query = "insert into example1.pastresults (ID,Q1,Q2,Q3,Q4,Q5) values ('" & identify & "','" & LabelName & "','','','','')"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try


        ElseIf quNum = 2 Then
            If isCorrect Then
                LabelName = "Question 2 was correct!"
            Else
                LabelName = "Question 2 was incorrect" + "; Correct answer: " + dsQuestions.Tables(0).Rows(Q2).ItemArray(rightans2)
            End If
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q2 = '" & LabelName & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try

        ElseIf quNum = 3 Then
            If isCorrect Then
                LabelName = "Question 3 was correct!"
            Else
                LabelName = "Question 3 was incorrect" + "; Correct answer: " + dsQuestions.Tables(0).Rows(Q3).ItemArray(rightans3)
            End If
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q3 = '" & LabelName & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try

        ElseIf quNum = 4 Then
            If isCorrect Then
                LabelName = "Question 4 was correct!"
            Else
                LabelName = "Question 4 was incorrect" + "; Correct answer: " + dsQuestions.Tables(0).Rows(Q4).ItemArray(rightans4)
            End If
            Try
                mysqlconn.Open()
                Dim query As String
                query = "UPDATE example1.pastresults SET Q4 = '" & LabelName & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try


        ElseIf quNum = 5 Then
            mysqlconn.Open()
            Dim qu5ans = dsQuestions.Tables(0).Rows(Q5).ItemArray(6).ToString
            If isCorrect Then
                LabelName = "Question 5 was correct!"
            Else
                LabelName = "Question 5 was incorrect" + "; Correct answer: " + qu5ans.ToLower
            End If
            Try
                Dim query As String
                query = "UPDATE example1.pastresults SET Q5 = '" & LabelName & "' WHERE ID = '" & identify & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                mysqlconn.Close()
            Catch ex As Exception

            End Try

        End If

        Return LabelName
    End Function
End Class
