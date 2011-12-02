Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

'*********************************************************************************************'
'*        DigiOz MySQL Database Class                                                         *'
'*********************************************************************************************'
'*      Author:  Pedram Soheil                                                               *'
'*      Company: DigiOz Multimedia                                                           *'
'*      Website: http://www.digioz.com                                                       *'
'*      Version: 1.0.0                                                                       *'
'*      Date:    02/14/2007                                                                  *'
'*      Purpose: The purpose of this class is to provide a MySQL database access wrapper     *'
'*               for MySQL .NET Connector which allows you to insert update and delete       *'
'*               as well as populate a gridview for both a Windows or an ASP.NET Application *'
'*********************************************************************************************'

Public Class dbClass
    Private pr_dbhost As String
    Private pr_dbuser As String
    Private pr_dbpass As String
    Private pr_dbname As String

    Private connStr As String
    Public conn As MySqlConnection

    Public reader As MySqlDataReader
    Public ds As New DataSet

    Public da As New MySqlDataAdapter
    Public cb As MySqlCommandBuilder
    Public dt As New DataTable

    Public err As String
    Public errNumber As Integer
    Public dllversion As String = "1.0.0"

    Public Sub openConnection()
        connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; Allow Zero DateTime=False;", dbhost, dbuser, dbpass, dbname)
        If Not conn Is Nothing Then conn.Close()

        Try
            conn = New MySqlConnection(connStr)
            conn.Open()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
    End Sub

    Public Sub closeConnection()
        Try
            conn.Close()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
    End Sub

    Public Function QueryDBReader(ByVal sql As String)
        reader = Nothing

        Dim cmd As New MySqlCommand(sql, conn)
        Try
            reader = cmd.ExecuteReader()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

        Return reader
    End Function

    Public Sub QueryDBDataset(ByVal sql As String)
        Try
            Dim cmd As New MySqlCommand(sql, conn)
            da.SelectCommand = cmd
            cb = New MySqlCommandBuilder(da)
            da.Fill(ds)
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
    End Sub

    Public Sub UpdateDBDataset()
        Try
            dt = ds.Tables(0)
            Dim changes As DataTable = dt.GetChanges()

            da.Update(changes)
            dt.AcceptChanges()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
    End Sub

    Public Sub DeleteDBDataset(ByVal primarykey As String)
        Try
            ds.Tables(0).Rows(primarykey).Delete()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
    End Sub

    Public Sub ExecDB(ByVal sql As String)
        Try
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
    End Sub

    Public Function ExecDBScalar(ByVal sql As String)
        Dim cmd As New MySqlCommand(sql, conn)
        Dim strReturn As String = ""

        Try
            strReturn = cmd.ExecuteScalar().ToString()
        Catch ex As MySqlException
            err &= "Error: " & ex.Message.ToString()
            errNumber = ex.Number
        End Try
        Return strReturn
    End Function

    Public Function GetDLLVersion()
        Return "DigiOz MySql DLL Version " & dllversion
    End Function

    Public Property dbhost() As String
        Get
            dbhost = pr_dbhost
        End Get
        Set(ByVal value As String)
            pr_dbhost = value
        End Set
    End Property

    Public Property dbuser() As String
        Get
            dbuser = pr_dbuser
        End Get
        Set(ByVal value As String)
            pr_dbuser = value
        End Set
    End Property

    Public Property dbpass() As String
        Get
            dbpass = pr_dbpass
        End Get
        Set(ByVal value As String)
            pr_dbpass = value
        End Set
    End Property

    Public Property dbname() As String
        Get
            dbname = pr_dbname
        End Get
        Set(ByVal value As String)
            pr_dbname = value
        End Set
    End Property

End Class

