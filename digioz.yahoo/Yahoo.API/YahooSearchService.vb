Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Xml.Serialization

Namespace Yahoo.API
    Public Class YahooSearchService

        Private Const _searchYahooApiAddress As String = "http://search.yahooapis.com/"
        Private Const _localYahooApiAddress As String = "http://local.yahooapis.com/"


        Public Function TermExtraction(ByVal appId As String, ByVal query As String, ByVal context As String) As Yahoo.API.TermExtractionResponse.ResultSet

            ' Set the uri to send the request to
            Dim requestUri As String = _searchYahooApiAddress + "ContentAnalysisService/V1/termExtraction"

            ' Create the request object
            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)

            ' Set up resource variables
            Dim sw As StreamWriter = Nothing
            Dim resultSet As Yahoo.API.TermExtractionResponse.ResultSet = Nothing
            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing

            Try
                ' As the context parameter may be quite long
                ' we will use a POST request
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                sw = New StreamWriter(request.GetRequestStream())
                sw.Write("appid={0}&context={1}&query={2}", appId, context, query)
                sw.Close()

                ' Get the response from Yahoo
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                ' Convert the result string into an object model
                Dim serializer As New XmlSerializer(GetType(Yahoo.API.TermExtractionResponse.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.TermExtractionResponse.ResultSet)
            Finally
                ' Clean up
                If (Not sw Is Nothing) Then sw.Close()
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function ImageSearch(ByVal appId As String, ByVal query As String, ByVal type As String, ByVal results As Short, ByVal start As Integer, ByVal format As String, ByVal adultOk As Boolean) As Yahoo.API.ImageSearchResponse.ResultSet

            Dim requestUri As String = String.Format(_searchYahooApiAddress + "ImageSearchService/V1/imageSearch?appid={0}&query={1}&type={2}&results={3}&start={4}&format={5}&adult_ok={6}", appId, query, type, results, start, format, IIf(adultOk, "1", "0"))

            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)

            Dim resultSet As Yahoo.API.ImageSearchResponse.ResultSet = Nothing
            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing

            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.ImageSearchResponse.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.ImageSearchResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function LocalSearch(ByVal appId As String, ByVal query As String, ByVal results As Short, ByVal start As Integer, ByVal radius As Single, ByVal street As String, ByVal city As String, ByVal state As String, ByVal zip As String, ByVal location As String) As Yahoo.API.LocalSearchResponse.ResultSet

            Dim requestUri As String = String.Format(_localYahooApiAddress + "LocalSearchService/V1/localSearch?appid={0}&query={1}&results={2}&start={3}&radious={4}&street={5}&city={6}&state={7}&zip={8}&location={9}", appId, query, results, start, radius, street, city, state, zip, location)

            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            Dim resultSet As Yahoo.API.LocalSearchResponse.ResultSet = Nothing

            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.LocalSearchResponse.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.LocalSearchResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function LocalSearch2(ByVal appId As String, ByVal query As String, ByVal results As Short, ByVal start As Integer, ByVal sort As Integer, ByVal radius As Single, ByVal street As String, ByVal city As String, ByVal state As String, ByVal zip As String, ByVal location As String, ByVal latitude As Double, ByVal longitude As Double) As Yahoo.API.LocalSearchResponse2.ResultSet

            Dim requestUri As String = String.Format(_localYahooApiAddress + "LocalSearchService/V2/localSearch?appid={0}&query={1}&results={2}&start={3}&sort={4}&radious={6}&street={6}&city={7}&state={8}&zip={9}&location={10}&latitude={11}&longitude={12}&output=xml", appId, query, results, start, sort, radius, street, city, state, zip, location, latitude, longitude)

            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            Dim resultSet As Yahoo.API.LocalSearchResponse2.ResultSet = Nothing

            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.LocalSearchResponse2.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.LocalSearchResponse2.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function NewsSearch(ByVal appId As String, ByVal query As String, ByVal type As String, ByVal results As Short, ByVal start As Integer, ByVal sort As String, ByVal language As String) As Yahoo.API.NewsSearchResponse.ResultSet

            Dim requestUri As String = String.Format(_searchYahooApiAddress + "NewsSearchService/V1/newsSearch?appid={0}&query={1}&type={2}&results={3}&start={4}&sort={5}&language={6}", appId, HttpUtility.UrlEncode(query, Encoding.UTF8), type, results, start, sort, language)

            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            Dim resultSet As Yahoo.API.NewsSearchResponse.ResultSet = Nothing

            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.NewsSearchResponse.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.NewsSearchResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function VideoSearch(ByVal appId As String, ByVal query As String, ByVal type As String, ByVal results As Short, ByVal start As Integer, ByVal format As String, ByVal adultOk As Boolean) As Yahoo.API.VideoSearchResponse.ResultSet

            Dim requestUri As String = String.Format(_searchYahooApiAddress + "VideoSearchService/V1/videoSearch?appid={0}&query={1}&type={2}&results={3}&start={4}&format={5}&adult_ok={6}", appId, HttpUtility.UrlEncode(query, Encoding.UTF8), type, results, start, format, IIf(adultOk, "1", "0"))

            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            Dim resultSet As Yahoo.API.VideoSearchResponse.ResultSet = Nothing

            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.VideoSearchResponse.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.VideoSearchResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function WebSearchRelated(ByVal appId As String, ByVal query As String, ByVal results As Short) As Yahoo.API.WebSearchRelatedResponse.ResultSet

            Dim requestUri As String = String.Format(_searchYahooApiAddress + "WebSearchService/V1/relatedSuggestion?appid={0}&query={1}&results={2}", appId, HttpUtility.UrlEncode(query, Encoding.UTF8), results)

            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            Dim resultSet As Yahoo.API.WebSearchRelatedResponse.ResultSet = Nothing

            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.WebSearchRelatedResponse.ResultSet))
                resultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.WebSearchRelatedResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return resultSet
        End Function

        Public Function WebSearch(ByVal appId As String, ByVal query As String, ByVal type As String, ByVal results As Short, ByVal start As Integer, ByVal format As String, ByVal adultOk As Boolean, ByVal similarOk As Boolean, ByVal language As String) As Yahoo.API.WebSearchResponse.ResultSet

            Dim requestUri As String = String.Format(_searchYahooApiAddress + "WebSearchService/V1/webSearch?appid={0}&query={1}&type={2}&results={3}&start={4}&format={5}&adult_ok={6}&similar_ok={7}&language={8}", appId, HttpUtility.UrlEncode(query, Encoding.UTF8), type, results, start, format, IIf(adultOk, "1", "0"), IIf(similarOk, "1", "0"), language)
            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)

            Dim ResultSet As Yahoo.API.WebSearchResponse.ResultSet = Nothing
            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.WebSearchResponse.ResultSet))
                ResultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.WebSearchResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return ResultSet
        End Function

        Public Function WebSearchSpelling(ByVal appId As String, ByVal query As String) As Yahoo.API.WebSearchSpellingResponse.ResultSet

            Dim requestUri As String = String.Format(_searchYahooApiAddress + "WebSearchService/V1/spellingSuggestion?appid={0}&query={1}", appId, HttpUtility.UrlEncode(query, Encoding.UTF8))
            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)

            Dim ResultSet As Yahoo.API.WebSearchSpellingResponse.ResultSet = Nothing
            Dim response As HttpWebResponse = Nothing
            Dim responseStream As Stream = Nothing
            Try
                response = CType(request.GetResponse(), HttpWebResponse)
                responseStream = response.GetResponseStream()

                Dim serializer As New XmlSerializer(GetType(Yahoo.API.WebSearchSpellingResponse.ResultSet))
                ResultSet = CType(serializer.Deserialize(responseStream), Yahoo.API.WebSearchSpellingResponse.ResultSet)
            Finally
                If Not (responseStream Is Nothing) Then responseStream.Close()
                If Not (response Is Nothing) Then response.Close()
            End Try

            Return ResultSet

        End Function
    End Class
End Namespace
