Imports System
Imports System.IO
Imports digiozsearch

Public Class Form1

    Dim aList As ArrayList
    Dim sFile As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
        sFile = OpenFileDialog1.FileName
        txtPath.Text = sFile
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim srch1 As New clsSearch
        Dim aListResult As New ArrayList
        Dim i As Integer = 0

        srch1.SearchFile(sFile, txtSearchTerm.Text, False)

        For i = 0 To srch1.resultcount - 1
            MessageBox.Show(srch1.aListResults.Item(i).File)
        Next

        txtOut.Text = ""

        While Not srch1.EOF
            txtOut.Text &= srch1.aListResults.Item(srch1.rowindex).LineText.ToString() & vbNewLine
            srch1.MoveNext()
        End While

    End Sub
End Class
