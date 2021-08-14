Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Imports System.Windows.Documents.Serialization
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging

Public Class Window13
    Dim mysqlconn As New MySqlConnection


    Private Sub Window13_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=dolphins13;database=example1"

        Dim command As MySqlCommand
        Dim reader As MySqlDataReader
        Dim getData As New SelectData

        ID.Content = IDfield

        Dim msg = getData.AccessDatabase(IDfield, "FN")
        Message.Text = "Welcome Back " + msg + "!"
        Try
            'Sets the question labels by pulling the data from the Q1, Q2, Q3, Q4, and Q5 fields from the pastresults database
            mysqlconn.Open()
            Dim query As String
            query = "select * from example1.pastresults where ID='" & IDfield & "' "
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            reader.Read()
            qu1.Text = reader.GetString(1)
            qu2.Text = reader.GetString(2)
            qu3.Text = reader.GetString(3)
            qu4.Text = reader.GetString(4)
            qu5.Text = reader.GetString(5)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
        Finally
            mysqlconn.Dispose()

        End Try
        Score.Text = getData.AccessDatabase(IDfield, "Score")
        TimeLabel.Text = getData.AccessDatabase(IDfield, 7)

    End Sub


    Private Sub Print_Click(sender As Object, e As RoutedEventArgs)
        'creates an xps document to be printed 
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
            PrintBtn.Visibility = Visibility.Hidden
            printDlg.PrintVisual(Me, "print job")
        End If
        PrintBtn.Visibility = Visibility.Visible

    End Sub
End Class
