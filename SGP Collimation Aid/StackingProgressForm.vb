Imports System.ComponentModel

Public Class StackingProgressForm
    Private Sub StackingProgressForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainForm.Enabled = False
    End Sub

    Private Sub StackingProgressForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MainForm.Enabled = True
    End Sub
End Class