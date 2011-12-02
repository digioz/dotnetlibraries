Imports System
Imports System.IO

Public Class Utilities

    Sub New()
        ' Constructor
    End Sub

    Public Function GetFileContents(ByVal lsPath As String, Optional ByRef lsErrInfo As String = "") As String
        Dim lsContents As String
        Dim loStreamReader As StreamReader

        Try
            loStreamReader = New StreamReader(lsPath)
            lsContents = loStreamReader.ReadToEnd()
            loStreamReader.Close()
        Catch ex As Exception
            lsContents = String.Empty
            lsErrInfo = ex.Message
        End Try

        Return lsContents
    End Function

    Public Function SaveTextToFile(ByVal lsString As String, ByVal lsPath As String, Optional ByVal lsErrInfo As String = "") As Boolean
        Dim lbSuccess As Boolean = False
        Dim loStreamWriter As StreamWriter

        Try
            loStreamWriter = New StreamWriter(lsPath)
            loStreamWriter.Write(lsString)
            loStreamWriter.Close()
            lbSuccess = True
        Catch Ex As Exception
            lsErrInfo = Ex.Message
        End Try

        Return lbSuccess
    End Function

    Public Function AppendTextToFile(ByVal lsString As String, ByVal lsPath As String, Optional ByVal lsErrInfo As String = "") As Boolean
        Dim loStreamWriter As StreamWriter = Nothing
        Dim lbSuccess As Boolean = False

        ' Create the file if it does not exist
        If IO.File.Exists(lsPath) = False Then
            loStreamWriter = IO.File.CreateText(lsPath)
            loStreamWriter.Flush()
            loStreamWriter.Close()
        End If

        Try
            loStreamWriter = IO.File.AppendText(lsPath)
            loStreamWriter.Write(lsString)
            lbSuccess = True
        Catch Ex As Exception
            lsErrInfo = Ex.Message
        Finally
            loStreamWriter.Flush()
            loStreamWriter.Close()
        End Try

        Return lbSuccess
    End Function

End Class
