Imports System
Imports System.Data
Imports digiozmysqldll

'*********************************************************************************************'
'*        DigiOz MySQL Database Class                                                        *'
'*********************************************************************************************'
'*      Author:  Pedram Soheil                                                               *'
'*      Company: DigiOz Multimedia                                                           *'
'*      Website: http://www.digioz.com                                                       *'
'*      Version: 1.0.0                                                                       *'
'*      Date:    02/14/2007                                                                  *'
'*      Purpose: Demo Application for digiozmysqldll                                         *'
'*********************************************************************************************'

Public Class Form1

    Dim db1 As New dbClass
    Dim tbl1 As String
    Dim changedDG As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dialog1 As New Dialog1
        dialog1.ShowDialog()
        db1.dbhost = dialog1.txthost.Text
        db1.dbname = dialog1.txtdbname.Text
        tbl1 = dialog1.txttable.Text
        db1.dbuser = dialog1.txtuser.Text
        db1.dbpass = dialog1.txtpass.Text

        db1.openConnection()
        db1.QueryDBDataset("SELECT * FROM " & tbl1)
        DataGridView1.DataSource = db1.ds.Tables(0)
        db1.closeConnection()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If changedDG = True Then
            db1.UpdateDBDataset()
            Me.Refresh()
        End If
        changedDG = False
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        db1.DeleteDBDataset(DataGridView1.SelectedRows.Item(0).Index.ToString())
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        changedDG = True
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim db1 As New dbClass
        MessageBox.Show(db1.GetDLLVersion())
    End Sub
End Class
