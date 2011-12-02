DigiOz Search DLL Version 1.0.1 (for .NET 2.0)
==============================================

DLL Name: digiozsearch.dll
Purpose:  To search through any specified text file, find specific instances of the given search term (either case sensitive or not depending on option selected) and return the line number and position number of the first matching instance in a plain string format. 

How to Use it
=============

1- Start a new VB.NET Windows Application Solution.

2- Open the "Solution Explorer" window.

3- Right-Click on References Folder inside of Solution Explorer for your project.

4- Select "Add Reference" from the menu given. 

5- Click on the "Projects" Tab, and click on "Browse" button.

6- Find the digiozsearch.dll file from the location you downloaded and saved it to, select it and hit Open.

Sample usage of this DLL:
=========================

Dim srch1 As New clsSearch
Dim aListResult As New ArrayList
Dim i As Integer = 0

srch1.SearchFile(sFile, txtSearchTerm.Text, False)

For i = 0 To srch1.resultcount - 1
	MessageBox.Show(srch1.aListResults.Item(i).File)
Next

txtOut.Text = ""

While Not srch1.EOF
	txtOut.Text &= srch1.aListResults.Item(srch1.rowindex).LineText.ToString() & vbNewLine
	srch1.MoveNext()
End While


Note: 
=====

The last option in the "SearchFile()" function call is for case sensitivity. If set to True, the DLL will consider Case for search, else, it will ignore case and return all results back. 













