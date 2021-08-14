'imports the data from the database as well as the data needed for printing
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Documents.Serialization
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging


Public Class Window6
    'calls the conncetion and questions from the database and assigns them to variables
    Dim mysqlconn As New MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim result As New resultGen
    Dim WindowContent As String
    Dim QUnum As String
    Dim counter1 As String
    Dim SelectValues As New SelectData
    Dim TryData As New AccessData
    Dim insertData As New InsertData
    Private Sub Window6_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        'if the quiz has not been completed than the correct results must be pulled from the database
        If IsResume Then
            'selects the question number that the user ended on when the quiz was saved to determine how many questions should be pulled from the database
            QUnum = SelectValues.AccessDatabase(identify, "QN")
            'depending on each number, the quiz then pulls the correct information from the database and then calculates the results of the questions answered on the same session
            If QUnum = 2 Then
                qu1.Text = SelectValues.AccessDatabase(identify, 1)
                insertData.UpdateData(1, qu1.Text)
                If correct2 <> True Then
                    qu2.Text = result.calcResult(False, 2)
                Else
                    qu2.Text = result.calcResult(True, 2)
                End If
                If correct3 <> True Then
                    qu3.Text = result.calcResult(False, 3)
                Else
                    qu3.Text = result.calcResult(True, 3)
                End If
                If correct4 <> True Then
                    qu4.Text = result.calcResult(False, 4)
                Else
                    qu4.Text = result.calcResult(True, 4)
                End If
                If correct5 <> True Then
                    qu5.Text = result.calcResult(False, 5)
                Else
                    qu5.Text = result.calcResult(True, 5)
                End If
            End If
            If QUnum = 3 Then
                qu1.Text = SelectValues.AccessDatabase(identify, 1)
                insertData.UpdateData(1, qu1.Text)
                qu2.Text = SelectValues.AccessDatabase(identify, 2)
                insertData.UpdateData(2, qu2.Text)
                If correct3 <> True Then
                    qu3.Text = result.calcResult(False, 3)
                Else
                    qu3.Text = result.calcResult(True, 3)
                End If
                If correct4 <> True Then
                    qu4.Text = result.calcResult(False, 4)
                Else
                    qu4.Text = result.calcResult(True, 4)
                End If
                If correct5 <> True Then
                    qu5.Text = result.calcResult(False, 5)
                Else
                    qu5.Text = result.calcResult(True, 5)
                End If
            End If
            If QUnum = 4 Then
                qu1.Text = SelectValues.AccessDatabase(identify, 1)
                insertData.UpdateData(1, qu1.Text)
                qu2.Text = SelectValues.AccessDatabase(identify, 2)
                insertData.UpdateData(2, qu2.Text)
                qu3.Text = SelectValues.AccessDatabase(identify, 3)
                insertData.UpdateData(3, qu3.Text)
                If correct4 <> True Then
                    qu4.Text = result.calcResult(False, 4)
                Else
                    qu4.Text = result.calcResult(True, 4)
                End If
                If correct5 <> True Then
                    qu5.Text = result.calcResult(False, 5)
                Else
                    qu5.Text = result.calcResult(True, 5)
                End If
            End If
            If QUnum = 5 Then
                qu1.Text = SelectValues.AccessDatabase(identify, 1)
                insertData.UpdateData(1, qu1.Text)
                qu2.Text = SelectValues.AccessDatabase(identify, 2)
                insertData.UpdateData(2, qu2.Text)
                qu3.Text = SelectValues.AccessDatabase(identify, 3)
                insertData.UpdateData(3, qu3.Text)
                qu4.Text = SelectValues.AccessDatabase(identify, 4)
                insertData.UpdateData(4, qu4.Text)
                If correct5 <> True Then
                    qu5.Text = result.calcResult(False, 5)
                Else
                    qu5.Text = result.calcResult(True, 5)
                End If
            End If
            'the counter and time is updated on the results screen to match the results from the saved quiz 
            counter1 = SelectValues.AccessDatabase(identify, "Count")
            Time.Text = "Time: " + diff.ToString("mm\:ss")
            counter = counter + counter1
            percent.Text = counter.ToString + "/5"
        Else
            'if the quiz was not taken from a saved version than the results are calculated through the calcresult function 
            If correct1 <> True Then
                qu1.Text = result.calcResult(False, 1)
            Else
                qu1.Text = result.calcResult(True, 1)
            End If
            If correct2 <> True Then
                qu2.Text = result.calcResult(False, 2)
            Else
                qu2.Text = result.calcResult(True, 2)
            End If
            If correct3 <> True Then
                qu3.Text = result.calcResult(False, 3)
            Else
                qu3.Text = result.calcResult(True, 3)
            End If
            If correct4 <> True Then
                qu4.Text = result.calcResult(False, 4)
            Else
                qu4.Text = result.calcResult(True, 4)
            End If
            If correct5 <> True Then
                qu5.Text = result.calcResult(False, 5)
            Else
                qu5.Text = result.calcResult(True, 5)
            End If
            Time.Text = "Time: " + diff.ToString("mm\:ss")
            'the last label displays how many answers were correct out of 5 using the counter variable used in each question window
            percent.Text = counter.ToString + "/5"
        End If

        'shows the user their ID
        ID_Label.Content = "ID: " + identify.ToString
        'This try statement updates the database to provide a score for the ID that was given in the beginning 
        TryData.AccessDatabase(identify.ToString(), "score", counter)
        TryData.AccessDatabase(identify.ToString(), "Time", diff.ToString("mm\:ss"))
    End Sub

    Private Sub Print_Click(sender As Object, e As RoutedEventArgs)

        'Sizes and formats the window correctly so that the window can be printed in the correct format

        Dim printDlg As New PrintDialog
        printDlg.PageRangeSelection = PageRangeSelection.AllPages
        printDlg.UserPageRangeEnabled = True
        Dim capabilities As System.Printing.PrintCapabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket)
        Dim Scale As Double = Math.Min(capabilities.PageImageableArea.ExtentWidth / Me.ActualWidth, capabilities.PageImageableArea.ExtentHeight / Me.ActualHeight)
        Me.LayoutTransform = New ScaleTransform(Scale, Scale)
        Dim sz As Size = New Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight)
        Me.Measure(sz)
        Me.Arrange(New Rect(New Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz))
        Dim print As Nullable(Of Boolean) = printDlg.ShowDialog()
        If print = True Then
            TTSBTN.Visibility = Visibility.Hidden
            PrintBtn.Visibility = Visibility.Hidden
            printDlg.PrintVisual(Me, "print job")
        End If
        TTSBTN.Visibility = Visibility.Visible
        PrintBtn.Visibility = Visibility.Visible

    End Sub

    Private Function GenerateTTS()
        'creates a text to speech object that is used to read the content of the screen 
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.speak(WindowContent)
        Return True
    End Function
    Private Async Sub ResultsText_Click(sender As Object, e As RoutedEventArgs)
        'creates a text to speech object to read the answers on the page
        WindowContent = results.Text + ":" + qu1.Text + ":" + qu2.Text + ":" + qu3.Text + ":" + qu4.Text + ":" + qu5.Text + ":" + counter.ToString + "out of 5"
        Await Task.Run(Function() GenerateTTS())
    End Sub

End Class
