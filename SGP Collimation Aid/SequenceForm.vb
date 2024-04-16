Imports System.ComponentModel

Public Class SequenceForm


    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        MainForm.abortSeq = True
        lblAbort.Text = "ABORTING AFTER THIS FRAME!"
        Application.DoEvents()
    End Sub

    Private Sub SequenceForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainForm.Enabled = False
    End Sub

    Private Sub SequenceForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MainForm.Enabled = True
    End Sub
End Class