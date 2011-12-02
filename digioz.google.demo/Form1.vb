Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbPages.SelectedItem = "1"
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim LicenseKey As String = "<Enter GOOGLE Key Here>"
        Dim srch1 As New digioz.google.clsGoogle
        Dim i As Integer = 0
        txtResults.Text = ""

        srch1.LicenseKey = LicenseKey
        srch1.SearchGoogle(txtSearch.Text, CInt(cmbPages.SelectedItem))

        For i = 0 To srch1.PageItemCount - 1
            txtResults.Text &= "Title:       " & srch1.ResultList.Item(i).title & vbNewLine
            txtResults.Text &= "URL:         " & srch1.ResultList.Item(i).URL & vbNewLine
            txtResults.Text &= "Cache Size:  " & srch1.ResultList.Item(i).cacheSize & vbNewLine
            txtResults.Text &= "Description: " & srch1.ResultList.Item(i).description & vbNewLine
            txtResults.Text &= "------------------------------------------------------------" & vbNewLine
        Next

        lblResultCount.Text = srch1.TotalResultCount.ToString()
        lblResultItemCount.Text = srch1.PageItemCount.ToString()
    End Sub


End Class
