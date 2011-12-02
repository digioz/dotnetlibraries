Imports System
Imports Microsoft.Win32

Public Class InstalledSoftware

    Private caApps As ArrayList

    Sub New()
        caApps = New ArrayList
        GetInstalledSoftware()
    End Sub

    Private Sub GetInstalledSoftware()
        Dim lsDisplayName As String = ""
        Dim lsUninstallKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        Dim loSoftwareInfo As SoftwareInfo = Nothing
        Dim loRegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey(lsUninstallKey)

        With loRegistryKey
            For Each lsSubKeyName As String In loRegistryKey.GetSubKeyNames()
                Dim loSubKey As RegistryKey = loRegistryKey.OpenSubKey(lsSubKeyName)

                With loSubKey
                    loSoftwareInfo = New SoftwareInfo
                    lsDisplayName = loSubKey.GetValue("DisplayName")

                    If Not lsDisplayName Is Nothing Then
                        With loSoftwareInfo
                            .DisplayName = lsDisplayName
                            .DisplayVersion = loSubKey.GetValue("DisplayVersion")
                            .InstallDate = loSubKey.GetValue("InstallDate")
                            .InstallLocation = loSubKey.GetValue("InstallLocation")
                            .InstallSource = loSubKey.GetValue("InstallSource")
                            .Publisher = loSubKey.GetValue("Publisher")
                            .VersionMajor = loSubKey.GetValue("VersionMajor")
                            .VersionMinor = loSubKey.GetValue("VersionMinor")
                            caApps.Add(loSoftwareInfo)
                        End With
                    End If

                End With
            Next
        End With
    End Sub

    Public Function SortArrayList(ByVal laList As ArrayList, ByVal liMin As Integer, ByVal liMax As Integer, ByVal lsPropName As String) As ArrayList
        Dim liLastSwap As Integer
        Dim loTmp As Object
        Dim i, j As Integer

        Do While liMin < liMax
            liLastSwap = liMin - 1
            i = liMin + 1
            Do While i <= liMax
                If CallByName(laList(i - 1), lsPropName, CallType.Get) > CallByName(laList(i), lsPropName, CallType.Get) Then
                    loTmp = laList(i - 1)
                    j = i
                    Do
                        laList(j - 1) = laList(j)
                        j = j + 1
                        If j > liMax Then Exit Do
                    Loop While CallByName(laList(j), lsPropName, CallType.Get) < CallByName(loTmp, lsPropName, CallType.Get)
                    laList(j - 1) = loTmp
                    liLastSwap = j - 1
                    i = j + 1
                Else
                    i = i + 1
                End If
            Loop

            liMax = liLastSwap - 1
            liLastSwap = liMax + 1
            i = liMax - 1

            Do While i >= liMin
                If CallByName(laList(i + 1), lsPropName, CallType.Get) < CallByName(laList(i), lsPropName, CallType.Get) Then
                    loTmp = laList(i + 1)
                    j = i
                    Do
                        laList(j + 1) = laList(j)
                        j = j - 1
                        If j < liMin Then Exit Do
                    Loop While CallByName(laList(j), lsPropName, CallType.Get) > CallByName(loTmp, lsPropName, CallType.Get)
                    laList(j + 1) = loTmp
                    liLastSwap = j + 1
                    i = j - 1
                Else
                    i = i - 1
                End If
            Loop

            liMin = liLastSwap + 1
        Loop

        Return laList
    End Function

    Public Function IsInstalled(ByVal lsApplicationName As String, ByVal lsDisplayVersion As String) As Boolean
        Dim lbResult As Boolean = False
        Dim lsSoftwareInfo As SoftwareInfo = Nothing

        For Each lsSoftwareInfo In caApps
            With lsSoftwareInfo
                If .DisplayName.IndexOf(lsApplicationName) > 0 AndAlso lsDisplayVersion = .DisplayVersion Then
                    lbResult = True
                    Exit For
                Else
                    lbResult = False
                End If
            End With
        Next

        Return lbResult
    End Function

    Public ReadOnly Property Apps() As ArrayList
        Get
            Return caApps
        End Get
    End Property

End Class
