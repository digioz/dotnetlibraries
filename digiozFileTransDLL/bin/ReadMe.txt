DigiOz File Trans DLL
=====================

DLL Name: digiozFileTrans.dll
Purpose:  To read, write and append text to a text file chosen by programmer.

How to Use it
=============

1- Start a new VB.NET Windows Application Solution.

2- Open the "Solution Explorer" window.

3- Right-Click on References Folder inside of Solution Explorer for your project.

4- Select "Add Reference" from the menu given. 

5- Click on the "Projects" Tab, and click on "Browse" button.

6- Find the digiozFileTrans.dll file from the location you downloaded and saved it to, select it and hit Open.

7- The following 3 Functions are accessable in the dll:

a) AppendTextToFile()
=====================
Appends a text string to the END of a chosen text file if the text file already exists. If the text file does NOT exist, the dll will attempt to create the file for you.

b) GetFileContents()
====================
Reads the contents of a text file from a file specified by you and returns the contents of the file for you. 

c) SaveTextToFile() 
===================
Writes text to a file specified by you, deleting any existing file along with its content, effectively replacing the existing file with the new content you specify in your string you pass to the function.

Sample Usage:
=============
' Appending text to an existing file
------------------------------------
Dim myFL As New digiozFileTrans.digiozFileTrans
myFL.AppendTextToFile("Test", "fileName.txt")

' Writing text to a file replacing the old one
----------------------------------------------
Dim myFL2 As New digiozFileTrans.digiozFileTrans
myFL2.SaveTextToFile("Test Write", "fileName2.txt")

' Reading text from a file 
--------------------------
Dim myFL3 As New digiozFileTrans.digiozFileTrans
Dim myString As String
myString = myFL3.GetFileContents("fileName2.txt")
MessageBox.Show(myString)



















