Public Class Form1

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim loYouTube As New digioz.youtube.youtube()
        Dim loVideo As digioz.youtube.video = Nothing
        Dim loVideos As Collection = Nothing
        Dim lsResponse As String = ""

        loYouTube.DevID = txtDevID.Text
        loYouTube.Page = 1
        loYouTube.PerPage = 10
        loYouTube.Tag = txtSearch.Text

        If txtDevID.Text = "XXXXXXXXXXX" Or txtDevID.Text = "" Then
            WebBrowser1.DocumentText = "Please register for a new developer ID by <a href=""http://youtube.com/signup?next=/my_profile_dev"" target=""_blank"">Clicking Here</a>"
            Exit Sub
        End If

        loVideos = loYouTube.SearchYouTube()
        lsResponse &= "<table border=1 bordercolor=black>"

        For Each loVideo In loVideos
            lsResponse &= "<tr>"
            lsResponse &= "<td valign=""top""><a href=""" & loVideo.URL & """ target=""_blank""><img src=""" & loVideo.ThumbnailURL & """></a></td>"
            lsResponse &= "<td valign=""top"">Title: " & loVideo.Title & "<br>"
            lsResponse &= "Author: " & loVideo.Author & "<br>"
            lsResponse &= "Description: " & loVideo.Description & "<br></td>"
            lsResponse &= "</tr>"
        Next

        lsResponse &= "</table>"

        WebBrowser1.DocumentText = "<HTML><BODY>" & lsResponse & "</BODY></HTML>"
    End Sub
End Class
