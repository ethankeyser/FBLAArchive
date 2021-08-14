Imports System.Data

Public Class userData
    Public Function getAllUserData(ByRef poData As DataSet, ByRef psErrorMsg As String) As Boolean
        'the program tries to obtain the questions from the database and if this fails, then an error message is created
        Try
            Dim loData As New getUserData

            If loData.getAllDataDB(poData, psErrorMsg) Then
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
