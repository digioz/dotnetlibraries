Imports System.IO
Imports System.Xml
Imports System.Net
Imports Microsoft.VisualBasic

Public Class video
    Private csAuthor As String
    Private csID As String
    Private csTitle As String
    Private clLengthSeconds As Long
    Private cdRatingAVG As Double
    Private ciRatingCount As Integer
    Private csDescription As String
    Private ciViewCount As Integer
    Private clUploadTime As Long
    Private ciCommentCount As Integer
    Private csTags As String
    Private csURL As String
    Private csThumbnailURL As String
    Private csEmbededStatus As String
    Private csAllowRatings As String
    Private Shared clTotalResults As Long

    Sub New()
        csAuthor = ""
        csID = ""
        csTitle = ""
        clLengthSeconds = 0
        cdRatingAVG = 0.0
        ciRatingCount = 0
        csDescription = ""
        ciViewCount = 0
        clUploadTime = 0
        ciCommentCount = 0
        csTags = ""
        csURL = ""
        csThumbnailURL = ""
        csEmbededStatus = ""
        csAllowRatings = ""
    End Sub

    Public Property Author() As String
        Get
            Return csAuthor
        End Get
        Set(ByVal value As String)
            csAuthor = value
        End Set
    End Property
    Public Property ID() As String
        Get
            Return csID
        End Get
        Set(ByVal value As String)
            csID = value
        End Set
    End Property
    Public Property Title() As String
        Get
            Return csTitle
        End Get
        Set(ByVal value As String)
            csTitle = value
        End Set
    End Property
    Public Property LengthSeconds() As Long
        Get
            Return clLengthSeconds
        End Get
        Set(ByVal value As Long)
            If IsNumeric(value) Then
                clLengthSeconds = value
            End If
        End Set
    End Property
    Public Property RatingAVG() As Double
        Get
            Return cdRatingAVG
        End Get
        Set(ByVal value As Double)
            If IsNumeric(value) Then
                cdRatingAVG = value
            End If
        End Set
    End Property
    Public Property RatingCount() As Integer
        Get
            Return ciRatingCount
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciRatingCount = value
            End If
        End Set
    End Property
    Public Property Description() As String
        Get
            Return csDescription
        End Get
        Set(ByVal value As String)
            csDescription = value
        End Set
    End Property
    Public Property ViewCount() As Integer
        Get
            Return ciViewCount
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciViewCount = value
            End If
        End Set
    End Property
    Public Property UploadTime() As Long
        Get
            Return clUploadTime
        End Get
        Set(ByVal value As Long)
            If IsNumeric(value) Then
                clUploadTime = value
            End If
        End Set
    End Property
    Public Property CommentCount() As Integer
        Get
            Return ciCommentCount
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciCommentCount = value
            End If
        End Set
    End Property
    Public Property Tags() As String
        Get
            Return csTags
        End Get
        Set(ByVal value As String)
            csTags = value
        End Set
    End Property
    Public Property URL() As String
        Get
            Return csURL
        End Get
        Set(ByVal value As String)
            csURL = value
        End Set
    End Property
    Public Property ThumbnailURL() As String
        Get
            Return csThumbnailURL
        End Get
        Set(ByVal value As String)
            csThumbnailURL = value
        End Set
    End Property
    Public Property EmbededStatus() As String
        Get
            Return csEmbededStatus
        End Get
        Set(ByVal value As String)
            csEmbededStatus = value
        End Set
    End Property
    Public Property AllowRatings() As String
        Get
            Return csAllowRatings
        End Get
        Set(ByVal value As String)
            csAllowRatings = value
        End Set
    End Property
    Public Shared Property TotalResults() As Long
        Get
            Return clTotalResults
        End Get
        Set(ByVal value As Long)
            clTotalResults = value
        End Set
    End Property

End Class

Public Class youtube
    Private csDevID As String
    Private csBaseURL As String
    Private csMethod As String
    Private csTag As String
    Private ciPage As Integer
    Private ciPerPage As Integer

    Sub New()
        ciPage = 1
        ciPerPage = 10
        csBaseURL = "http://www.youtube.com/api2_rest?"
        csMethod = "youtube.videos.list_by_tag"
    End Sub

    Public Function GetWebPageResult(ByVal loURL As String) As String
        Dim loHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(loURL), HttpWebRequest)
        Dim myHttpWebResponse As HttpWebResponse = CType(loHttpWebRequest.GetResponse(), HttpWebResponse)
        Dim loStream As Stream = myHttpWebResponse.GetResponseStream()
        Dim loEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")
        Dim loReadStream As New StreamReader(loStream, loEncode)
        GetWebPageResult = loReadStream.ReadToEnd()
        loStream.Close()
        loReadStream.Close()
    End Function

    Public Function SearchYouTube() As Collection
        Dim lsRequestURL As String
        Dim lsResults As String = Nothing
        Dim loXMLDoc As XmlDocument = New XmlDocument
        Dim lsTemp As String = Nothing
        Dim loVideo As video = Nothing
        Dim loVideos As New Collection

        lsRequestURL = csBaseURL & "method=" & csMethod & "&dev_id=" & csDevID & "&tag=" & csTag & "&page=" & ciPage & "&per_page=" & ciPerPage
        lsResults = GetWebPageResult(lsRequestURL)

        loXMLDoc.LoadXml(lsResults)

        Dim loParentNode As XmlNode = loXMLDoc.SelectSingleNode("//ut_response/video_list")
        Dim loChildList As XmlNodeList = loParentNode.ChildNodes
        loVideos.Clear()

        For Each loNode As XmlNode In loChildList
            If loNode.Name = "video" Then
                loVideo = New video()
                loVideo.Author = loNode.SelectSingleNode("author").InnerText
                loVideo.ID = loNode.SelectSingleNode("id").InnerText
                loVideo.Title = loNode.SelectSingleNode("title").InnerText
                loVideo.LengthSeconds = loNode.SelectSingleNode("length_seconds").InnerText
                loVideo.RatingAVG = loNode.SelectSingleNode("rating_avg").InnerText
                loVideo.RatingCount = loNode.SelectSingleNode("rating_count").InnerText
                loVideo.Description = loNode.SelectSingleNode("description").InnerText
                loVideo.ViewCount = loNode.SelectSingleNode("view_count").InnerText
                loVideo.UploadTime = loNode.SelectSingleNode("upload_time").InnerText
                loVideo.CommentCount = loNode.SelectSingleNode("comment_count").InnerText
                loVideo.Tags = loNode.SelectSingleNode("tags").InnerText
                loVideo.URL = loNode.SelectSingleNode("url").InnerText
                loVideo.ThumbnailURL = loNode.SelectSingleNode("thumbnail_url").InnerText
                loVideo.EmbededStatus = loNode.SelectSingleNode("embed_status").InnerText
                loVideo.AllowRatings = loNode.SelectSingleNode("allow_ratings").InnerText
                loVideos.Add(loVideo)
            ElseIf loNode.Name = "total" Then
                video.TotalResults = loNode.InnerText
            End If
        Next

        Return loVideos
    End Function

    ''' <summary>
    ''' Property to sets the YouTube Developer ID 
    ''' for the class instance. If you do not have
    ''' one you can register for a new ID at: 
    ''' http://youtube.com/signup?next=/my_profile_dev
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DevID() As String
        Get
            Return csDevID
        End Get
        Set(ByVal value As String)
            csDevID = value
        End Set
    End Property

    ''' <summary>
    ''' Property that sets the search Term for
    ''' our YouTube Search
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tag() As String
        Get
            Return csTag
        End Get
        Set(ByVal value As String)
            csTag = value
        End Set
    End Property

    ''' <summary>
    ''' Property that specifies the page number for our 
    ''' search results that are returned
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Page() As Integer
        Get
            Return ciPage
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciPage = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Property that specifies how many search 
    ''' results per page are shown 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PerPage() As Integer
        Get
            Return ciPerPage
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciPerPage = value
            End If
        End Set
    End Property

    Public Property BaseURL() As String
        Get
            Return csBaseURL
        End Get
        Set(ByVal value As String)
            csBaseURL = value
        End Set
    End Property

    Public Property Method() As String
        Get
            Return csMethod
        End Get
        Set(ByVal value As String)
            csMethod = value
        End Set
    End Property

End Class

