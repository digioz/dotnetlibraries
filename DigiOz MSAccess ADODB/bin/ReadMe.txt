DigiOz MS Access ADODB DLL
==========================

DLL Name: MSAccess.dll
Purpose:  To Query, INSERT, UPDATE and DELETE (or execute) SQL Statements to Microsoft Access Database. 

How to Use it
=============

1- Start a new VB.NET Windows Application Solution.

2- Open the "Solution Explorer" window.

3- Right-Click on References Folder inside of Solution Explorer for your project.

4- Select "Add Reference" from the menu given. 

5- Click on the "Projects" Tab, and click on "Browse" button.

6- Find the MSAccess.dll file from the location you downloaded and saved it to, select it and hit Open.

Example Query:
==============

Dim db1 As New MSAccess.AccessDB
Dim rs1 As New ADODB.Recordset

db1.dbName = "C:\Path\To\Your\Project\data.mdb"
db1.query = "SELECT * FROM [TableName]"
db1.openDB()
rs1 = db1.queryDB()

If Not db1.dbErr = "" Then
        MessageBox.Show(db1.dbErr.ToString())
        ' MessageBox.Show(db1.dbErrDetail.ToString())
        End
End If

While Not rs1.EOF
        MessageBox.Show(rs1.Fields("ColumnName").Value.ToString())
        rs1.MoveNext()
End While

db1.closeDB()

Sample Insert, UPDATE OR DELETE:
================================

Dim db1 As New MSAccess.AccessDB

db1.dbName = "C:\Path\To\Your\Project\data.mdb"
db1.query = "INSERT INTO [TableName] ([field1],[field2]) VALUES ('Value 1','Value 2')"
db1.openDB()
db1.execDB()

If Not db1.dbErr = "" Then
     MessageBox.Show(db1.dbErr.ToString())
     ' MessageBox.Show(db1.dbErrDetail.ToString())
     End
End If

MessageBox.Show("Record Inserted Successfully!")



















