'///////////// AccessDB Class ////////////////
'/// The purpose of this class is to query ///
'/// insert, update and delete records     ///
'/// from any given access database, given ///
'/// the name of the database, and the SQL ///
'/// Command the user wants to execute.    ///
'/////////////////////////////////////////////

Public Class AccessDB
    Private cn As ADODB.Connection
    Private rs As ADODB.Recordset
    Private cnSTR As String
    Public dbName As String
    Public query As String
    Public dbErr As String
    Public dbErrDetail As String

    Private Function makeCNStr()
        Try
            cnSTR = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbName & ";"
            Return True
        Catch ex As Exception
            dbErrDetail &= ex.ToString() & vbCrLf
            dbErr &= "Could not create database connection string!" & vbCrLf
        End Try
    End Function

    Public Function openDB()
        Try
            makeCNStr()
            cn = New ADODB.Connection
            cn.Open(cnSTR)
            Return True
        Catch ex As Exception
            dbErrDetail &= ex.ToString() & vbCrLf
            dbErr &= "Could not find or open MS Access Database!" & vbCrLf
        End Try
    End Function

    Public Function execDB()
        Try
            openDB()
            cn.Execute(query)
            closeDB()
            Return True
        Catch ex As Exception
            dbErrDetail &= ex.ToString() & vbCrLf
            dbErr &= "Could not execute SQL Command!" & vbCrLf
        End Try
    End Function

    Public Function queryDB()
        Try
            rs = cn.Execute(query)
            Return rs
        Catch ex As Exception
            dbErrDetail &= ex.ToString() & vbCrLf
            dbErr &= "Could not query database and retrieve records!" & vbCrLf
        End Try
    End Function

    Public Function closeDB()
        Try
            cn.Close()
            cn = Nothing
            Return True
        Catch ex As Exception
            dbErrDetail &= ex.ToString() & vbCrLf
            dbErr &= "Could not close MS Access Database!" & vbCrLf
        End Try
    End Function
End Class
