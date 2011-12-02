Imports System
Imports Microsoft.Win32
Imports digioz.machine.software

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim loInstalledSoftware As New InstalledSoftware
        Dim laApps As ArrayList = loInstalledSoftware.Apps

        laApps = loInstalledSoftware.SortArrayList(laApps, 0, laApps.Count - 1, "DisplayName")
        Dim lsSoftwareInfo As SoftwareInfo = Nothing

        For Each lsSoftwareInfo In laApps
            lstInstalledApplications.Items.Add(lsSoftwareInfo.ToString())
        Next

        '' Find a specific application
        'If loInstalledSoftware.IsInstalled(".NET Framework 2.0", "2.0.50727") Or loInstalledSoftware.IsInstalled(".NET Framework 2.0", "2.1.20706") Then
        '    MessageBox.Show(True)
        'Else
        '    MessageBox.Show(False)
        'End If
    End Sub

End Class
