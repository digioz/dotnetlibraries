Imports System.IO

Public Class clsSearch

    Public rowindex As Integer
    Public resultcount As Integer
    Public aListResults As List(Of result)

    Public Sub New()
        rowindex = 0
    End Sub

    Protected Overrides Sub Finalize()
        GC.Collect()
    End Sub

    Public Structure result
        Public File As String
        Public SearchTerm As String
        Public Line As Integer
        Public Position As Integer
        Public LineText As String
    End Structure

    Public Function SearchFile(ByVal filename As String, ByVal searchterm As String, ByVal searchcase As Boolean) As Boolean
        Dim objReader As StreamReader
        Dim LineIn As String = ""
        Dim LineInOriginal As String = ""
        Dim filenameShort As String = ""
        Dim pos As Integer = -1
        Dim linenumber As Integer = 1

        aListResults = New List(Of result)

        filename = Replace(filename, "/", "\")

        objReader = New StreamReader(filename)
        filenameShort = GetFileName(filename)

        While objReader.Peek <> -1
            LineIn = objReader.ReadLine()
            LineInOriginal = LineIn

            If searchcase = False Then
                LineIn = UCase(LineIn)
                searchterm = UCase(searchterm)
            End If

            pos = LineIn.IndexOf(searchterm)

            If pos >= 0 Then
                Dim rs As New result
                rs.File = filenameShort
                rs.SearchTerm = searchterm
                rs.Line = linenumber
                rs.Position = pos
                rs.LineText = LineInOriginal

                aListResults.Add(rs)
            End If

            linenumber = linenumber + 1

        End While

        objReader.Close()

        resultcount = aListResults.Count

        If aListResults.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function EOF() As Boolean
        If rowindex = resultcount Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GetFileName(ByVal filename)
        Dim arr1() As String
        Dim fname As String = ""

        filename = Replace(filename, "/", "\")
        arr1 = Split(filename, "\")
        fname = arr1(arr1.Length - 1)
        Return fname
    End Function

    Private Function GetFilePath(ByVal filename)
        Dim arr1() As String
        Dim fpath As String = ""
        Dim i As Integer = 0

        filename = Replace(filename, "/", "\")
        arr1 = Split(filename, "\")

        For i = 0 To arr1.Length - 2
            fpath &= arr1(i) & "\"
        Next

        Return fpath
    End Function

    Public Sub MoveNext()
        If rowindex < resultcount Then
            rowindex = rowindex + 1
        End If
    End Sub

    Public Sub MovePrev()
        If rowindex >= 1 Then
            rowindex = rowindex - 1
        End If
    End Sub

End Class
