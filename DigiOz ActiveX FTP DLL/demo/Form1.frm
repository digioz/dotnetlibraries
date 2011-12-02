VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6915
   ClientLeft      =   2355
   ClientTop       =   2130
   ClientWidth     =   9135
   LinkTopic       =   "Form1"
   ScaleHeight     =   6915
   ScaleWidth      =   9135
   Begin VB.TextBox txtDirectory 
      Height          =   375
      Left            =   1200
      TabIndex        =   11
      Text            =   "/"
      Top             =   1560
      Width           =   4695
   End
   Begin VB.TextBox txtPassword 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   1200
      PasswordChar    =   "*"
      TabIndex        =   10
      Text            =   "mypassword"
      Top             =   1080
      Width           =   4695
   End
   Begin VB.CommandButton btnDownload 
      Caption         =   "Download"
      Enabled         =   0   'False
      Height          =   375
      Left            =   1920
      TabIndex        =   9
      Top             =   6120
      Width           =   1335
   End
   Begin VB.CommandButton btnGetDirList 
      Caption         =   "Get Dir List"
      Height          =   375
      Left            =   6000
      TabIndex        =   8
      Top             =   6120
      Width           =   1215
   End
   Begin VB.CommandButton btnDisconnect 
      Caption         =   "Disconnect"
      Height          =   375
      Left            =   4680
      TabIndex        =   7
      Top             =   6120
      Width           =   1215
   End
   Begin VB.CommandButton btnConnect 
      Caption         =   "Connect"
      Height          =   375
      Left            =   3360
      TabIndex        =   6
      Top             =   6120
      Width           =   1215
   End
   Begin VB.TextBox txtResponse 
      Height          =   3975
      Left            =   1200
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   2
      Top             =   2040
      Width           =   7695
   End
   Begin VB.TextBox txtUser 
      Height          =   375
      Left            =   1200
      TabIndex        =   1
      Text            =   "me@mydomain.com"
      Top             =   600
      Width           =   4695
   End
   Begin VB.TextBox txtServer 
      Height          =   375
      Left            =   1200
      TabIndex        =   0
      Text            =   "www.mydomain.com"
      Top             =   120
      Width           =   4695
   End
   Begin VB.Label Label4 
      Caption         =   "Directory"
      Height          =   255
      Left            =   240
      TabIndex        =   12
      Top             =   1680
      Width           =   855
   End
   Begin VB.Label Label3 
      Caption         =   "Password"
      Height          =   255
      Left            =   240
      TabIndex        =   5
      Top             =   1200
      Width           =   855
   End
   Begin VB.Label Label2 
      Caption         =   "Username"
      Height          =   255
      Left            =   240
      TabIndex        =   4
      Top             =   720
      Width           =   855
   End
   Begin VB.Label Label1 
      Caption         =   "Server"
      Height          =   255
      Left            =   240
      TabIndex        =   3
      Top             =   240
      Width           =   855
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim ftp1 As New cFTP

Private Sub btnConnect_Click()
    Dim bOK As Boolean
    bOK = ftp1.OpenConnection(txtServer.Text, txtUser.Text, txtPassword.Text)
End Sub

Private Sub btnDisconnect_Click()
    ftp1.CloseConnection
End Sub

Private Sub btnGetDirList_Click()
    Dim i As Integer
    Dim cDir As Integer

    ftp1.SetFTPDirectory (txtDirectory.Text)
    ftp1.DirectoryList
        
    cDir = ftp1.dirList.Count
    
    For i = 1 To cDir
        txtResponse.Text = ftp1.dirList.Item(i) & vbNewLine & txtResponse
    Next
    
    ftp1.ClearCollection
    
    txtResponse.Text = "<-- E N D -->" & vbNewLine & txtResponse.Text
    
    ftp1.SetFTPDirectory ("/")
    ftp1.DirectoryList
    
    cDir = ftp1.dirList.Count
    
    For i = 1 To cDir
        txtResponse.Text = ftp1.dirList.Item(i) & vbNewLine & txtResponse
    Next
    
    ' MsgBox CStr(ftp1.dirList.Item(2))
    
End Sub
