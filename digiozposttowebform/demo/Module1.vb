Module Module1

    Sub Main()
        Dim wf1 As New digioz.PostToWebForm
        Dim sResult As String

        wf1.postURL = "http://www.digioz.com/scripts/posttest.php"

        ' --------------- field name , value ---------------------
        wf1.addNewFields("username", "username")
        wf1.addNewFields("password", "password")
        ' --------------------------------------------------------

        sResult = wf1.postForm()

        Console.WriteLine(sResult)
        Console.ReadLine()
    End Sub

End Module
