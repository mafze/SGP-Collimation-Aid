Imports System.Math

Public Class MountClass
    Public Device As ASCOM.DriverAccess.Telescope
    Public Connected As Boolean

    Public Function Connect(ByVal selectedTelescope As String) As Boolean
        Try
            Device = New ASCOM.DriverAccess.Telescope(selectedTelescope)
            Device.Connected = True

        Catch ex As Exception
            'MainForm.Logging("Failed to connect to mount " + selectedTelescope + ".")
            Device.Connected = False
            Return False
        End Try
        Connected = True
        'MainForm.Logging("Connected to mount " + selectedTelescope + ".")
        Return True
    End Function

    Public Sub Disconnect()
        Device.Connected = False
        Device = Nothing
        Connected = False

        'MainForm.Logging("DisConnected from mount.")
    End Sub

End Class
