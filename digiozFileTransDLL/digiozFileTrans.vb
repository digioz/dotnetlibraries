Imports System.IO

Public Class digiozFileTrans

    ' ****************************** Read from Text File Function *****************************

    Public Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String

        Dim strContents As String
        Dim objReader As StreamReader
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try

    End Function

    ' ***************************** Write to Text File Function ********************************

    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As Boolean

        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter

        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try

        Return bAns

    End Function

    ' ****************** Append to Text File Function ***********************

    Public Function AppendTextToFile(ByVal strData As String, ByVal path As String, Optional ByRef ErrInfo As String = "")
        Dim sw As StreamWriter

        ' Create the file if it does not exist
        If File.Exists(path) = False Then
            sw = File.CreateText(path)
            sw.Flush()
            sw.Close()
        End If

        Try
            sw = File.AppendText(path)          ' Open the file for append
            sw.Write(strData)
            'sw.WriteLine("Write text line by line")
        Catch Ex As Exception
            ErrInfo = Ex.Message
        Finally
            sw.Flush()
            sw.Close()
        End Try

        ' Optional Stream Reader for returning contents of the file
        'Dim sr As StreamReader = File.OpenText(path)
        'Dim s As String
        'Do While sr.Peek() >= 0
        's = sr.ReadLine()
        'txtOut.Text &= (s)
        'Loop
        'sr.Close()
    End Function

End Class
