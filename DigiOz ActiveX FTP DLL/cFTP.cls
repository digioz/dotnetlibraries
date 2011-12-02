VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cFTP"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'****************************************************************************
' Module Name:      cFTP
' Module Type:      Class Module
' Filename:         cFTP.cls
' Author:
' Date:             11/5/2001
' Purpose:          FTP Class downloaded from PSC - beats the hell out of using
'                   an ocx!!
'*****************************************************************************

Option Explicit
Private Const BUFFERSIZE = 255

Private hOpen As Long
Private hConnection As Long
Private hFile As Long
Private dwType As Long
Private dwSeman As Long
Private szErrorMessage As String
Public dirList As New Collection


Public Event FileTransferProgress(lCurrentBytes As Long, lTotalBytes As Long)

Public Sub ClearCollection()
    Set dirList = New Collection
End Sub


Private Sub ErrorOut(ByVal dwError As Long, ByRef szFunc As String)
    Dim dwRet As Long
    Dim dwTemp As Long
    Dim szString As String * 2048
    dwRet = FormatMessage(FORMAT_MESSAGE_FROM_HMODULE, _
                      GetModuleHandle("wininet.dll"), dwError, 0, _
                      szString, 256, 0)
    szErrorMessage = szFunc & " error code: " & dwError & " Message: " & szString
    If (dwError = 12003) Then
        ' Extended error information was returned
        dwRet = InternetGetLastResponseInfo(dwTemp, szString, 2048)
        szErrorMessage = szString
    End If
End Sub


Property Get GetLastErrorMessage() As String
    GetLastErrorMessage = szErrorMessage
End Property

Public Sub CloseConnection()
    If hConnection <> 0 Then
        InternetCloseHandle hConnection
    End If
    hConnection = 0
End Sub

Public Function SimpleFTPPutFile(sLocal As String, sRemote As String) As Boolean
    If (FTPPutFile(hConnection, sLocal, sRemote, dwType, 0) = False) Then
        ErrorOut Err.LastDllError, "SimpleFtpPutFile"
        SimpleFTPPutFile = False
        Exit Function
    Else
        SimpleFTPPutFile = True
    End If
End Function
 
Public Function RenameFTPFile(sExisting As String, sNewName As String) As Boolean
    If (FtpRenameFile(hConnection, sExisting, sNewName) = False) Then
        ErrorOut Err.LastDllError, "RenameFTPFile"
        RenameFTPFile = False
        Exit Function
    Else
        RenameFTPFile = True
    End If
End Function

Public Function CreateFTPDirectory(sDirectory As String) As Boolean
    If (FtpCreateDirectory(hConnection, sDirectory) = False) Then
        ErrorOut Err.LastDllError, "CreateFTPDirectory"
        CreateFTPDirectory = False
        Exit Function
    Else
        CreateFTPDirectory = True
    End If
End Function

Public Function RemoveFTPDirectory(sDirectory As String) As Boolean
    If (FtpRemoveDirectory(hConnection, sDirectory) = False) Then
        ErrorOut Err.LastDllError, "RemoveFTPDirectory"
        RemoveFTPDirectory = False
        Exit Function
    Else
        RemoveFTPDirectory = True
    End If
End Function
 
Public Function DeleteFTPFile(sRemote As String) As Boolean
    If (FtpDeleteFile(hConnection, sRemote) = False) Then
        ErrorOut Err.LastDllError, "DeleteFTPFile"
        DeleteFTPFile = False
        Exit Function
    Else
        DeleteFTPFile = True
    End If
End Function

Public Function OpenConnection(sServer As String, sUser As String, sPassword As String) As Boolean
    If hConnection <> 0 Then
        InternetCloseHandle hConnection
    End If
    hConnection = InternetConnect(hOpen, sServer, INTERNET_INVALID_PORT_NUMBER, sUser, sPassword, INTERNET_SERVICE_FTP, dwSeman, 0)
    If hConnection = 0 Then
        ErrorOut Err.LastDllError, "InternetConnect"
        OpenConnection = False
        Exit Function
    Else
        OpenConnection = True
    End If
End Function

Public Function FTPUploadFile(sLocal As String, sRemote As String) As Boolean
    Dim Data(BUFFERSIZE - 1) As Byte
    Dim Written As Long
    Dim Size As Long
    Dim Sum As Long
    Dim lBlock As Long
    
    Sum = 0
    lBlock = 0
    sLocal = Trim(sLocal)
    sRemote = Trim(sRemote)
    
    If sLocal <> "" And sRemote <> "" Then
      hFile = FtpOpenFile(hConnection, sRemote, GENERIC_WRITE, dwType, 0)
      If hFile = 0 Then
          ErrorOut Err.LastDllError, "FtpOpenFile:PutFile"
          FTPUploadFile = False
          Exit Function
      End If
      
      Open sLocal For Binary Access Read As #1
      Size = LOF(1)
      For lBlock = 1 To Size \ BUFFERSIZE
          Get #1, , Data
          If (InternetWriteFile(hFile, Data(0), BUFFERSIZE, Written) = 0) Then
              FTPUploadFile = False
              ErrorOut Err.LastDllError, "InternetWriteFile"
              Exit Function
          End If
          DoEvents
          Sum = Sum + BUFFERSIZE
          RaiseEvent FileTransferProgress(Sum, Size)
      Next lBlock
      
      Get #1, , Data
      If (InternetWriteFile(hFile, Data(0), Size Mod BUFFERSIZE, Written) = 0) Then
          FTPUploadFile = False
          ErrorOut Err.LastDllError, "InternetWriteFile2"
          Exit Function
      End If
      
      Sum = Sum + (Size Mod BUFFERSIZE)
      Size = Sum
      RaiseEvent FileTransferProgress(Sum, Size)

      Close #1
      InternetCloseHandle (hFile)
      FTPUploadFile = True
   End If

End Function

Public Function FTPDownloadFile(sLocal As String, sRemote As String) As Boolean
    Dim Data(BUFFERSIZE - 1) As Byte ' array of 100 elements 0 to 99
    Dim Written As Long
    Dim Size As Long
    Dim Sum As Long
    Dim lBlock As Long
    FTPDownloadFile = False
            
    Sum = 0
    lBlock = 0
    
    sLocal = Trim(sLocal)
    sRemote = Trim(sRemote)
    
    If sLocal <> "" And sRemote <> "" Then
      Size = GetFTPFileSize(sRemote)
      DoEvents
      If Size > 0 Then
          hFile = FtpOpenFile(hConnection, sRemote, GENERIC_READ, dwType, 0)
          DoEvents
          If hFile = 0 Then
              ErrorOut Err.LastDllError, "FtpOpenFile:GetFile"
              Exit Function
          End If
          
          Open sLocal For Binary Access Write As #1
          DoEvents
          Seek #1, 1
          DoEvents
          Sum = 1
          DoEvents
          For lBlock = 1 To Size \ BUFFERSIZE
              If (InternetReadFile(hFile, Data(0), BUFFERSIZE, Written) = 0) Then
                  ErrorOut Err.LastDllError, "InternetReadFile"
                  Close #1
                  Exit Function
              End If
              Put #1, , Data
              DoEvents
              Sum = Sum + BUFFERSIZE
              DoEvents
              RaiseEvent FileTransferProgress(Sum, Size)
              DoEvents
              DoEvents
          Next lBlock
          
          DoEvents
          ReDim Data2((Size Mod BUFFERSIZE) - 1) As Byte
          If (InternetReadFile(hFile, Data2(0), Size Mod BUFFERSIZE, Written) = 0) Then
              ErrorOut Err.LastDllError, "InternetReadFile2"
              Close #1
              Exit Function
          End If
                      
          Put #1, , Data2
          
          Sum = Sum + (Size Mod BUFFERSIZE)
          DoEvents
          Size = Sum
          DoEvents
          RaiseEvent FileTransferProgress(Sum, Size)
                        DoEvents
              DoEvents
          Close #1
          
          InternetCloseHandle (hFile)
          DoEvents
          FTPDownloadFile = True
          DoEvents
      End If
   End If
End Function

Public Function SimpleFTPGetFile(sLocal As String, sRemote As String) As Boolean
   ' add INTERNET_FLAG_NO_CACHE_WRITE to avoid local caching 0x04000000 (hex)
    If (FTPGetFile(hConnection, sRemote, sLocal, False, FILE_ATTRIBUTE_NORMAL, dwType Or INTERNET_FLAG_RELOAD, 0) = False) Then
        ErrorOut Err.LastDllError, "SimpleFtpGetFile"
        SimpleFTPGetFile = False
        Exit Function
    Else
        SimpleFTPGetFile = True
    End If
End Function

Public Function GetFTPDirectory() As String
    Dim szDir As String
    szDir = String(1024, Chr$(0))
    If (FtpGetCurrentDirectory(hConnection, szDir, 1024) = False) Then
        ErrorOut Err.LastDllError, "FtpGetCurrentDirectory"
        Exit Function
    Else
        GetFTPDirectory = Left(szDir, InStr(1, szDir, String(1, 0), vbBinaryCompare) - 1)
    End If
End Function

Public Function SetFTPDirectory(sDir As String)
    If (FtpSetCurrentDirectory(hConnection, sDir) = False) Then
        ErrorOut Err.LastDllError, "FtpSetCurrentDirectory"
        SetFTPDirectory = False
        Exit Function
    Else
        SetFTPDirectory = True
    End If
End Function

Public Function GetFTPFileSize(sFile As String) As Long
    Dim szDir As String
    Dim hFind As Long
    Dim nLastError As Long
    Dim pdata As WIN32_FIND_DATA
    
    hFind = FtpFindFirstFile(hConnection, sFile, pdata, 0, 0)
    nLastError = Err.LastDllError
    If hFind = 0 Then
        If (nLastError = ERROR_NO_MORE_FILES) Then
            GetFTPFileSize = -1  ' File not found
        Else
            GetFTPFileSize = -2  ' Other error
            ErrorOut Err.LastDllError, "FtpFindFirstFile"
        End If
        Exit Function
    End If
           
    GetFTPFileSize = pdata.nFileSizeLow
    InternetCloseHandle (hFind)
End Function


Public Sub SetTransferASCII()
    dwType = FTP_TRANSFER_TYPE_ASCII
End Sub

Public Sub SetTransferBinary()
    dwType = FTP_TRANSFER_TYPE_BINARY
End Sub

Public Sub SetModeActive()
    dwSeman = 0
End Sub

Public Sub SetModePassive()
    dwSeman = INTERNET_FLAG_PASSIVE
End Sub

Private Sub Class_Initialize()
    hOpen = InternetOpen("eDIY FTP Client", INTERNET_OPEN_TYPE_PRECONFIG, vbNullString, vbNullString, 0)
    If hOpen = 0 Then
        ErrorOut Err.LastDllError, "InternetOpen"
    End If
    dwType = FTP_TRANSFER_TYPE_ASCII
    dwSeman = 0
    hConnection = 0
End Sub

Private Sub Class_Terminate()
    InternetCloseHandle hOpen
End Sub

Public Sub DirectoryList() ' As Collection
    Dim hFind As Long
    Dim pdata As WIN32_FIND_DATA
    Dim strItemData As String
    Dim bRet As Boolean
    
    pdata.cFileName = String(260, 0)
    hFind = FtpFindFirstFile(hConnection, "*.*", pdata, 0, 0)
    
    'Add items to the collection until, the API returns the
    'ERROR_NO_MORE_FILES error.
    If hFind <> False Then
        Do While Not Err.LastDllError = ERROR_NO_MORE_FILES
            InternetFindNextFile hFind, pdata
            If Err.LastDllError = ERROR_NO_MORE_FILES Then Exit Do
            strItemData = Left(pdata.cFileName, InStr(1, pdata.cFileName, String(1, 0), vbBinaryCompare) - 1)
            'colItems.Add strItemData
            dirList.Add strItemData
        Loop
    End If
    
    InternetCloseHandle (hFind)
    
End Sub











