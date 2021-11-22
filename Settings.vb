
Namespace My
    
    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings

        Private Sub MySettings_SettingsLoaded(sender As Object, e As System.Configuration.SettingsLoadedEventArgs) Handles Me.SettingsLoaded
            If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
                Me.Item("MachineMonitoringConnectionString") = "Data Source=NBCP-LT-058\SQLEXPRESS;Initial Catalog=MachineMonitoring;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            Else
                Me.Item("MachineMonitoringConnectionString") = "Data Source=LENOVO-AX3RONG2;Initial Catalog=MachineMonitoring;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            End If
        End Sub

    End Class

End Namespace
