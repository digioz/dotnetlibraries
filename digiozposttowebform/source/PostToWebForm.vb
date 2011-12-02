Imports System
Imports System.IO
Imports System.Net

'*********************************************************************************************'
'*      DigiOz Post To Web DLL                                                               *'
'*********************************************************************************************'
'*      Author:  Pedram Soheil                                                               *'
'*      Company: DigiOz Multimedia                                                           *'
'*      Website: http://www.digioz.com                                                       *'
'*      Version: 1.0.0                                                                       *'
'*      Date:    03/30/2007                                                                  *'
'*      Purpose: The purpose of this class is to allow a Windows GUI application to post     *'
'*               information to any web form on any website given the remote website URL     *'
'*               and all the form fields and their respective values.                        *'
'*********************************************************************************************'

Public Class PostToWebForm
    Private m_URL As String
    Protected m_List As New List(Of formFields)

    Public Structure formFields
        Public FieldName As String
        Public FieldValue As String
    End Structure

    Sub New()
        ' Constructor
    End Sub

    Public Sub addNewFields(ByVal fldName, ByVal fldValue)
        Dim fld As New formFields
        fld.FieldName = fldName
        fld.FieldValue = fldValue
        m_List.Add(fld)
    End Sub

    Public Function postForm() As String
        Dim strPost As String
        Dim sResult As String = ""
        strPost = concatFieldsToString()

        Dim myWriter As StreamWriter = Nothing

        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(m_URL), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = strPost.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"

        Try
            myWriter = New StreamWriter(objRequest.GetRequestStream())
            myWriter.Write(strPost)
        Catch e As Exception
            Return e.Message
        Finally
            myWriter.Close()
        End Try

        Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)
        Dim sr As New StreamReader(objResponse.GetResponseStream())
        sResult = sr.ReadToEnd()

        sr.Close()

        Return sResult
    End Function

    Private Function concatFieldsToString() As String
        Dim sFields As String = ""
        Dim i As Integer = 0

        For i = 0 To m_List.Count - 1
            sFields &= m_List.Item(i).FieldName & "=" & m_List(i).FieldValue
            If i < m_List.Count - 1 Then
                sFields &= "&"
            End If
        Next

        Return sFields
    End Function

    Public Property postURL() As String
        Get
            postURL = m_URL
        End Get
        Set(ByVal value As String)
            m_URL = value
        End Set
    End Property

End Class
