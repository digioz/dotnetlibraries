Public Class SoftwareInfo

    Private csDisplayName As String
    Private csDisplayVersion As String
    Private csInstallDate As String
    Private csInstallLocation As String
    Private csInstallSource As String
    Private csPublisher As String
    Private ciVersionMajor As Integer
    Private ciVersionMinor As Integer

    Sub New()
        ' Constructor
    End Sub

    Public Overrides Function ToString() As String
        Return csDisplayName
    End Function

    Public Property DisplayName() As String
        Get
            Return csDisplayName
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                csDisplayName = value
            End If
        End Set
    End Property

    Public Property DisplayVersion() As String
        Get
            Return csDisplayVersion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                csDisplayVersion = value
            End If
        End Set
    End Property

    Public Property InstallDate() As String
        Get
            Return csInstallDate
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                csInstallDate = value
            End If
        End Set
    End Property

    Public Property InstallLocation() As String
        Get
            Return csInstallLocation
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                csInstallLocation = value
            End If
        End Set
    End Property

    Public Property InstallSource() As String
        Get
            Return csInstallSource
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                csInstallSource = value
            End If
        End Set
    End Property

    Public Property Publisher() As String
        Get
            Return csPublisher
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                csPublisher = value
            End If
        End Set
    End Property

    Public Property VersionMajor() As Integer
        Get
            Return ciVersionMajor
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciVersionMajor = value
            End If
        End Set
    End Property

    Public Property VersionMinor() As Integer
        Get
            Return ciVersionMinor
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                ciVersionMinor = value
            End If
        End Set
    End Property

End Class
