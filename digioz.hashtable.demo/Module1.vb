Module Module1

    Sub Main()
        Dim ht As New digioz.hashtable.clsHashtable
        Dim b1, b2, b3 As Boolean

        ht.AddToTable("key1", "item1")
        ht.AddToTable("Key2", "item2")
        ht.AddToTable(1, 100)
        b1 = ht.KeyExists("Key2")
        b2 = ht.ItemExists("item1")
        b3 = ht.ItemExists("item3")

        Console.WriteLine("Starting Count: " & ht.Count)

        If b1 = True Then
            Console.WriteLine("B2 Key Exists!")
        End If

        If b2 = True Then
            Console.WriteLine("B1 Item Exists!")
        End If

        If b3 = False Then
            Console.WriteLine("B3 Item Does NOT Exist!")
        End If

        Console.WriteLine("Key1 Value: " & ht.GetValue("key1").ToString())

        ht.RemoveFromTable("key1")

        Console.WriteLine("Count after removing key1: " & ht.Count)

        Console.ReadLine()

    End Sub

End Module
