'*********************************************************************************************'
'*        DigiOz Google DLL                                                                  *'
'*********************************************************************************************'
'*      Author:  Pedram Soheil                                                               *'
'*      Company: DigiOz Multimedia                                                           *'
'*      Website: http://www.digioz.com                                                       *'
'*      Version: 1.0.0.0                                                                     *'
'*      Date:    05/10/2007                                                                  *'
'*      Purpose: The purpose of this class is to use the Google Web API to Perform a search  *'
'*               on either a Windows or Web Application. The search results are stored in a  *'
'*               list of items which contain the title, URL, description and cache size of   *'
'*               each search result item. A Google Key will have to be obtained by each user *'
'*               of this DLL for use. Also, Google limits the daily query for each account   *'
'*               to 1000 queries, where you can retrieve a maximum of 10 results per query   *'
'*               and you cannot access information beyond the 1000th result for any query.   *'
'*********************************************************************************************'

Public Class clsGoogle
    Public LicenseKey As String = ""
    Public ResultList As New List(Of ResultItem)
    Public SearchResult As String = ""
    Public Err As String = ""
    Private MyService As com.google.api.GoogleSearchService = New com.google.api.GoogleSearchService
    Private MyResult As com.google.api.GoogleSearchResult

    Public Structure ResultItem
        Public description As String
        Public title As String
        Public URL As String
        Public cacheSize As String
    End Structure

    Public Sub SearchGoogle(ByVal SearchTerm As String, ByVal Pages As Integer)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim pg As Integer = 0
        Dim rsItem As ResultItem

        Try
            For j = 0 To Pages - 1
                pg = j * 10
                ' Execute Google search on the text enter and license key
                MyResult = MyService.doGoogleSearch(LicenseKey, SearchTerm, pg, 10, False, "", False, "", "", "")

                For i = 0 To 9
                    rsItem.cacheSize = MyResult.resultElements(i).cachedSize.ToString()
                    rsItem.description = stripHTMLTags(MyResult.resultElements(i).snippet.ToString())
                    rsItem.title = stripHTMLTags(MyResult.resultElements(i).title.ToString())
                    rsItem.URL = MyResult.resultElements(i).URL.ToString()
                    ResultList.Add(rsItem)
                Next
            Next
        Catch ex As Exception
            Err = ex.Message.ToString()
        End Try
    End Sub

    Private Function stripHTMLTags(ByVal sText As String) As String
        Dim sTextClean As String = ""

        sTextClean = Replace(sText, "<b>", "")
        sTextClean = Replace(sTextClean, "</b>", "")
        sTextClean = Replace(sTextClean, "<br>", "")
        Return sTextClean
    End Function

    Public Function TotalResultCount() As Integer
        Return CInt(MyResult.estimatedTotalResultsCount)
    End Function

    Public Function PageItemCount() As Integer
        Return ResultList.Count
    End Function

End Class
