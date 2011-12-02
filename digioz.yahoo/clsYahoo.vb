Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Xml.Serialization

'*********************************************************************************************'
'*        DigiOz Yahoo DLL                                                                   *'
'*********************************************************************************************'
'*      Author:  Pedram Soheil                                                               *'
'*      Company: DigiOz Multimedia                                                           *'
'*      Website: http://www.digioz.com                                                       *'
'*      Version: 1.0.0.0                                                                     *'
'*      Date:    05/10/2007                                                                  *'
'*      Purpose: The purpose of this class is to use the Yahoo Web API to Perform a search   *'
'*               on either a Windows or Web Application. The search results are stored in a  *'
'*               list of items which contain the title, URL, description and cache size of   *'
'*               each search result item. A Yahoo Key will have to be obtained by each user  *'
'*               of this DLL for use. Also, Yahoo limits the daily query for each account    *'
'*               to 5000 queries, where you can retrieve a maximum of 10 results per query.  *'
'*********************************************************************************************'

Public Class clsYahoo
    Public LicenseKey As String = ""
    Public ResultList As New List(Of ResultItem)
    Public SearchResult As String = ""
    Public Err As String = ""
    Private rCount As Integer
    Private MyService As New Yahoo.API.YahooSearchService
    Private MyResult As Yahoo.API.WebSearchResponse.ResultSet

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
                If pg = 0 Then
                    pg = 1
                End If
                ' Execute Google search on the text enter and license key
                MyResult = MyService.WebSearch(LicenseKey, SearchTerm, "all", 10, pg, "any", True, True, "en")

                For Each result As Yahoo.API.WebSearchResponse.ResultType In MyResult.Result
                    rsItem.cacheSize = result.Cache.Size.ToString()
                    rsItem.description = result.Summary.ToString()
                    rsItem.title = result.Title.ToString()
                    rsItem.URL = result.Url.ToString()
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
        Return ResultList.Count
    End Function

    Public Function PageItemCount() As Integer
        Return ResultList.Count
    End Function

End Class
