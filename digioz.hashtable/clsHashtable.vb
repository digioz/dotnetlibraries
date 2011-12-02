Imports System
Imports System.Object
Imports System.Collections

'*********************************************************************************************'
'*        DigiOz HashTable DLL                                                               *'
'*********************************************************************************************'
'*      Author:  Pedram Soheil                                                               *'
'*      Company: DigiOz Multimedia                                                           *'
'*      Website: http://www.digioz.com                                                       *'
'*      Version: 1.0.0.0                                                                     *'
'*      Date:    05/16/2007                                                                  *'
'*      Purpose: The purpose of this class is to summarize all the capabilities of HashTable *'
'*               in the dot net framework into one easy to use class, which allows you to    *'
'*               create hashtable objects to perform the adding, removing and searching of   *'
'*               items with ease.                                                            *'
'*********************************************************************************************'

Public Class clsHashtable
    Private Tablet As System.Collections.Hashtable

    Public Sub New()
        Tablet = New System.Collections.Hashtable()
    End Sub

    Public Sub AddToTable(ByVal HashKey As Object, ByVal HashValue As Object)
        Tablet.Add(HashKey, HashValue)
    End Sub

    Public Sub RemoveFromTable(ByVal HashKey As Object)
        Tablet.Remove(HashKey)
    End Sub

    Public Function ItemExists(ByVal HashValue As Object) As Boolean
        If Tablet.ContainsValue(HashValue) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function KeyExists(ByVal HashKey As Object) As Boolean
        If Tablet.ContainsKey(HashKey) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetValue(ByVal HashKey As Object) As Object
        Return Tablet.Item(HashKey)
    End Function

    Public Function Count() As Integer
        Return Tablet.Count
    End Function

    Public Sub Clear()
        Tablet.Clear()
    End Sub

End Class

' ***********************************************************************************************'
' *         Other Hashtable Properties and Methods                                              *'
' ***********************************************************************************************'
'   Count               Retrieves the number of key and value pairs contained in the Hashtable   '
'   IsFixedSize         Retrieves a value indicating wheather the Hashtable has a fixed size     '
'   IsReadOnly          Retrieves a value indicating wheather the Hashtable is Read Only         '
'   IsSynchronized      Retrieves a value indicating wheather acc4ess to Hashtable is            '
'                       synchronized (thread safe)                                               '
'   Item                Retrieves or sets the value associated with the specified key            '
'   Keys                Retrieves an ICollection containing the keys in the Hashtable            '
'   SyncRoot            Retrieves an object that can be used to synchronize access to the table  '
'   Values              Retrieves an ICollection containing the values in the Hashtable          '
'   Add                 Adds an element with the specified key and value into the Hashtable      '
'   Clear               Removes all elements from the Hashtable                                  '
'   Contains            Determines if the Hashtable contains a specific key                      '
'   ContainsKey         Determines if the Hashtable contains a specific key                      '
'   ContainsValue       Determines if the Hashtable contains a specific value                    '
'   CopyTo              Copies the Hashtable elements to a one-dimensitional array instance at   '
'                       the specified index                                                      '
'   GetEnumerator       Returns an IDictionary Enumerator that can iterate through the Hashtable '
'   GetHashCode         Inherited from Object, it serves as a hash function for a particular     ' 
'                       type, suitable for use in hashing algorithms and data structures like    '
'                       a hash table                                                             '
'   GetObjectData       Implements the ISerializable interface and returns the data needed to    '
'                       serialize the Hashtable                                                  '
'   OnDeserialization   Implements the ISerializable interface and raises the                    '
'                       deserialization event when the deserialization is complete               '
'   Remove              Removes the element with the specified key from the Hashtable            '
'   Synchronized        Returns a synchronized (thread-safe) wrapper for the Hashtable           '
'   Comparer            Retrieves or sets the comparer to use for Hashtable                      '
'   hcp                 Retrieves or sets the object that can dispense hash codes                '
'   GetHash             Returns the hash code for the specified key                              '
'   KeyEquals           Compares a specific object with the specific key in the Hashtable        '
'  **********************************************************************************************' 

