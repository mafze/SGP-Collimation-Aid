<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SequenceForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SequenceForm))
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.lblAbort = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbort.Location = New System.Drawing.Point(12, 147)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(187, 71)
        Me.btnAbort.TabIndex = 0
        Me.btnAbort.Text = "Abort"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(51, 44)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(27, 37)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "-"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(51, 94)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(27, 37)
        Me.lblPath.TabIndex = 2
        Me.lblPath.Text = "-"
        '
        'lblAbort
        '
        Me.lblAbort.AutoSize = True
        Me.lblAbort.Location = New System.Drawing.Point(250, 164)
        Me.lblAbort.Name = "lblAbort"
        Me.lblAbort.Size = New System.Drawing.Size(27, 37)
        Me.lblAbort.TabIndex = 3
        Me.lblAbort.Text = "-"
        '
        'SequenceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1431, 230)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblAbort)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnAbort)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SequenceForm"
        Me.Text = "Capture Sequence"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAbort As Button
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblPath As Label
    Friend WithEvents lblAbort As Label
End Class
