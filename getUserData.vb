﻿Imports System.Data
Imports MySql.Data.MySqlClient

Public Class getUserData
    Public Function getAllDataDB(ByRef poData As DataSet, ByRef psErrorMsg As String) As Boolean
        'the program tries to connect to the database, open the table desired, and create a dataset from the stored procedure created in the database
        Try
            'creates a connection to the database and uses the id and password to gain access
            Dim dbSQL As New MySqlConnection
            dbSQL.ConnectionString = "server=localhost;user id=root;password=dolphins13;database=example1"
            dbSQL.Open()
            Dim dsDataSet As New DataSet
            'creates a variable to access the stored procedure
            Dim cmd As New MySqlCommand("getUserData", dbSQL)
            cmd.CommandType = CommandType.StoredProcedure
            'uses the cmd variable to assign the stored procedure to a new variable
            Dim sa As New MySqlDataAdapter(cmd)
            sa.Fill(dsDataSet)
            'assigns poQuestions to the dataset
            poData = dsDataSet
            'closes the connection
            dbSQL.Close()
            Return True
        Catch ex As Exception
            'shows error message if the process fails and returns a false value
            psErrorMsg = ex.Message
            Return False
        End Try
    End Function
End Class
