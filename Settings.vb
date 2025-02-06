
Imports System.Configuration

Namespace My

    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings
        Private Sub MySettings_SettingsLoaded(sender As Object, e As SettingsLoadedEventArgs) Handles Me.SettingsLoaded
            If MachineMonitoringSystem.My.Settings.IsDebug = True Then
                If Environment.MachineName.ToString = "NBCP-DT-032" Then
                    Me.Item("ConnectionString") = "Data Source=NBCP-DT-032\SQLEXPRESS;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                Else
                    Me.Item("ConnectionString") = "Data Source=NBCP-LT-144\SQLEXPRESS;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                End If
            Else
                Me.Item("ConnectionString") = "Data Source=LENOVO-AX3RONG2;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            End If
        End Sub

    End Class

End Namespace
