Imports System.Data
Public Class questions
    'creates a function to see if the program was able to obtain all of the data
    Public Function getAllQuestion(ByRef poQuestions As DataSet, ByRef psErrorMsg As String) As Boolean
        'the program tries to obtain the questions from the database and if this fails, then an error message is created
        Try
            Dim loQuestions As New QuestionsDb

            If loQuestions.getAllQuestionDB(poQuestions, psErrorMsg) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            psErrorMsg = "There was an error retrieving the questions."
            Return False
        End Try
    End Function

End Class

