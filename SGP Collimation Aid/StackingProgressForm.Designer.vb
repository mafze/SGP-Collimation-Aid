<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StackingProgressForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StackingProgressForm))
        Me.Label_Stacking = New System.Windows.Forms.Label()
        Me.ProgressBar_Stacking = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label_Stacking
        '
        Me.Label_Stacking.AutoSize = True
        Me.Label_Stacking.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Stacking.Location = New System.Drawing.Point(20, 33)
        Me.Label_Stacking.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Stacking.Name = "Label_Stacking"
        Me.Label_Stacking.Size = New System.Drawing.Size(174, 46)
        Me.Label_Stacking.TabIndex = 0
        Me.Label_Stacking.Text = "Stacking"
        '
        'ProgressBar_Stacking
        '
        Me.ProgressBar_Stacking.Location = New System.Drawing.Point(20, 107)
        Me.ProgressBar_Stacking.Margin = New System.Windows.Forms.Padding(6)
        Me.ProgressBar_Stacking.Name = "ProgressBar_Stacking"
        Me.ProgressBar_Stacking.Size = New System.Drawing.Size(1220, 63)
        Me.ProgressBar_Stacking.TabIndex = 1
        '
        'StackingProgressForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1467, 220)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar_Stacking)
        Me.Controls.Add(Me.Label_Stacking)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "StackingProgressForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Stacking frames ..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_Stacking As Label
    Friend WithEvents ProgressBar_Stacking As ProgressBar
End Class
