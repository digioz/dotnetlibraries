Imports digioz.file.utilities

Public Class Form1

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim lsPath As String = Nothing
        OpenFileDialog1.ShowDialog()
        lsPath = OpenFileDialog1.FileName
        txtPath.Text = lsPath

        Dim loFile As New utilities.Utilities
        Dim lsFileContent As String = Nothing

        lsFileContent = loFile.GetFileContents(lsPath)

        txtData.Text = lsFileContent

    End Sub

End Class
