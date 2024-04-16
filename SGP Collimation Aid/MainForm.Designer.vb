<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label_StatusFocuser = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label_StatusCamera = New System.Windows.Forms.Label()
        Me.Label_StatusTelescope = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label_Offset_DEC = New System.Windows.Forms.Label()
        Me.Label_Offset_RA = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button_SetToCenter = New System.Windows.Forms.Button()
        Me.Label_Scope_DEC = New System.Windows.Forms.Label()
        Me.Label_Scope_RA = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button_StackFrames = New System.Windows.Forms.Button()
        Me.CheckBox_StackFrames = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_FOV_Angle = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button_Capture_All_Frames = New System.Windows.Forms.Button()
        Me.Button_CaptureFrame = New System.Windows.Forms.Button()
        Me.ComboBox_Binning = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox_ExpTime = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label_SaveDir = New System.Windows.Forms.Label()
        Me.Button_BrowseSaveDir = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button_SlewToPos = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox_Distance = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox_Pattern = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox_Pattern = New System.Windows.Forms.GroupBox()
        Me.TextBox_FOV_Y = New System.Windows.Forms.TextBox()
        Me.TextBox_FOV_X = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button_IntraFocusGoto = New System.Windows.Forms.Button()
        Me.TextBox_FocusShift = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Button_ExtraFocusGoto = New System.Windows.Forms.Button()
        Me.Button_InFocusGoto = New System.Windows.Forms.Button()
        Me.Button_InFocusSet = New System.Windows.Forms.Button()
        Me.Label_InFocusPos = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label_FocusPos = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label_StatusFocuser)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label_StatusCamera)
        Me.GroupBox1.Controls.Add(Me.Label_StatusTelescope)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(1666, 218)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Equipment Status"
        '
        'Label_StatusFocuser
        '
        Me.Label_StatusFocuser.AutoSize = True
        Me.Label_StatusFocuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StatusFocuser.Location = New System.Drawing.Point(868, 68)
        Me.Label_StatusFocuser.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_StatusFocuser.Name = "Label_StatusFocuser"
        Me.Label_StatusFocuser.Size = New System.Drawing.Size(53, 46)
        Me.Label_StatusFocuser.TabIndex = 5
        Me.Label_StatusFocuser.Text = "..."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(648, 68)
        Me.Label21.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(176, 46)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Focuser:"
        '
        'Label_StatusCamera
        '
        Me.Label_StatusCamera.AutoSize = True
        Me.Label_StatusCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StatusCamera.Location = New System.Drawing.Point(277, 68)
        Me.Label_StatusCamera.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_StatusCamera.Name = "Label_StatusCamera"
        Me.Label_StatusCamera.Size = New System.Drawing.Size(53, 46)
        Me.Label_StatusCamera.TabIndex = 3
        Me.Label_StatusCamera.Text = "..."
        '
        'Label_StatusTelescope
        '
        Me.Label_StatusTelescope.AutoSize = True
        Me.Label_StatusTelescope.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StatusTelescope.Location = New System.Drawing.Point(277, 135)
        Me.Label_StatusTelescope.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_StatusTelescope.Name = "Label_StatusTelescope"
        Me.Label_StatusTelescope.Size = New System.Drawing.Size(53, 46)
        Me.Label_StatusTelescope.TabIndex = 2
        Me.Label_StatusTelescope.Text = "..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 135)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 46)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Telescope:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 68)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Camera:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label_Offset_DEC)
        Me.GroupBox2.Controls.Add(Me.Label_Offset_RA)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Button_SetToCenter)
        Me.GroupBox2.Controls.Add(Me.Label_Scope_DEC)
        Me.GroupBox2.Controls.Add(Me.Label_Scope_RA)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 218)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox2.Size = New System.Drawing.Size(1666, 215)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Telescope"
        '
        'Label_Offset_DEC
        '
        Me.Label_Offset_DEC.AutoSize = True
        Me.Label_Offset_DEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Offset_DEC.Location = New System.Drawing.Point(857, 141)
        Me.Label_Offset_DEC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Offset_DEC.Name = "Label_Offset_DEC"
        Me.Label_Offset_DEC.Size = New System.Drawing.Size(53, 46)
        Me.Label_Offset_DEC.TabIndex = 17
        Me.Label_Offset_DEC.Text = "..."
        '
        'Label_Offset_RA
        '
        Me.Label_Offset_RA.AutoSize = True
        Me.Label_Offset_RA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Offset_RA.Location = New System.Drawing.Point(857, 70)
        Me.Label_Offset_RA.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Offset_RA.Name = "Label_Offset_RA"
        Me.Label_Offset_RA.Size = New System.Drawing.Size(53, 46)
        Me.Label_Offset_RA.TabIndex = 16
        Me.Label_Offset_RA.Text = "..."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(587, 141)
        Me.Label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(244, 46)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Offset DEC: "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(619, 70)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(215, 46)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Offset RA: "
        '
        'Button_SetToCenter
        '
        Me.Button_SetToCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SetToCenter.Location = New System.Drawing.Point(1260, 100)
        Me.Button_SetToCenter.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_SetToCenter.Name = "Button_SetToCenter"
        Me.Button_SetToCenter.Size = New System.Drawing.Size(348, 57)
        Me.Button_SetToCenter.TabIndex = 13
        Me.Button_SetToCenter.Text = "Set to Center"
        Me.Button_SetToCenter.UseVisualStyleBackColor = True
        '
        'Label_Scope_DEC
        '
        Me.Label_Scope_DEC.AutoSize = True
        Me.Label_Scope_DEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scope_DEC.Location = New System.Drawing.Point(331, 141)
        Me.Label_Scope_DEC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Scope_DEC.Name = "Label_Scope_DEC"
        Me.Label_Scope_DEC.Size = New System.Drawing.Size(53, 46)
        Me.Label_Scope_DEC.TabIndex = 3
        Me.Label_Scope_DEC.Text = "..."
        '
        'Label_Scope_RA
        '
        Me.Label_Scope_RA.AutoSize = True
        Me.Label_Scope_RA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scope_RA.Location = New System.Drawing.Point(331, 70)
        Me.Label_Scope_RA.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Scope_RA.Name = "Label_Scope_RA"
        Me.Label_Scope_RA.Size = New System.Drawing.Size(53, 46)
        Me.Label_Scope_RA.TabIndex = 2
        Me.Label_Scope_RA.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 141)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 46)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Current DEC: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 70)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 46)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Current RA: "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button_StackFrames)
        Me.GroupBox3.Controls.Add(Me.CheckBox_StackFrames)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.TextBox_FOV_Angle)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Button_Capture_All_Frames)
        Me.GroupBox3.Controls.Add(Me.Button_CaptureFrame)
        Me.GroupBox3.Controls.Add(Me.ComboBox_Binning)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.TextBox_ExpTime)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label_SaveDir)
        Me.GroupBox3.Controls.Add(Me.Button_BrowseSaveDir)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Button_SlewToPos)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TextBox_Distance)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ComboBox_Pattern)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.GroupBox_Pattern)
        Me.GroupBox3.Controls.Add(Me.TextBox_FOV_Y)
        Me.GroupBox3.Controls.Add(Me.TextBox_FOV_X)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 757)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox3.Size = New System.Drawing.Size(1666, 1038)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Collimation Imaging"
        '
        'Button_StackFrames
        '
        Me.Button_StackFrames.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_StackFrames.Location = New System.Drawing.Point(76, 738)
        Me.Button_StackFrames.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_StackFrames.Name = "Button_StackFrames"
        Me.Button_StackFrames.Size = New System.Drawing.Size(524, 111)
        Me.Button_StackFrames.TabIndex = 30
        Me.Button_StackFrames.Text = "Stack frames"
        Me.Button_StackFrames.UseVisualStyleBackColor = True
        '
        'CheckBox_StackFrames
        '
        Me.CheckBox_StackFrames.AutoSize = True
        Me.CheckBox_StackFrames.Location = New System.Drawing.Point(91, 673)
        Me.CheckBox_StackFrames.Margin = New System.Windows.Forms.Padding(6)
        Me.CheckBox_StackFrames.Name = "CheckBox_StackFrames"
        Me.CheckBox_StackFrames.Size = New System.Drawing.Size(437, 50)
        Me.CheckBox_StackFrames.TabIndex = 29
        Me.CheckBox_StackFrames.Text = "Auto stack all frames"
        Me.CheckBox_StackFrames.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1231, 78)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(163, 46)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "degrees"
        '
        'TextBox_FOV_Angle
        '
        Me.TextBox_FOV_Angle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_FOV_Angle.Location = New System.Drawing.Point(999, 72)
        Me.TextBox_FOV_Angle.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox_FOV_Angle.Name = "TextBox_FOV_Angle"
        Me.TextBox_FOV_Angle.Size = New System.Drawing.Size(207, 53)
        Me.TextBox_FOV_Angle.TabIndex = 27
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(781, 78)
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(178, 46)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "ANGLE: "
        '
        'Button_Capture_All_Frames
        '
        Me.Button_Capture_All_Frames.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Capture_All_Frames.Location = New System.Drawing.Point(76, 540)
        Me.Button_Capture_All_Frames.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Capture_All_Frames.Name = "Button_Capture_All_Frames"
        Me.Button_Capture_All_Frames.Size = New System.Drawing.Size(524, 122)
        Me.Button_Capture_All_Frames.TabIndex = 25
        Me.Button_Capture_All_Frames.Text = "Capture All Pattern Frames"
        Me.Button_Capture_All_Frames.UseVisualStyleBackColor = True
        '
        'Button_CaptureFrame
        '
        Me.Button_CaptureFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_CaptureFrame.Location = New System.Drawing.Point(76, 418)
        Me.Button_CaptureFrame.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_CaptureFrame.Name = "Button_CaptureFrame"
        Me.Button_CaptureFrame.Size = New System.Drawing.Size(524, 111)
        Me.Button_CaptureFrame.TabIndex = 24
        Me.Button_CaptureFrame.Text = "Capture Single Frame"
        Me.Button_CaptureFrame.UseVisualStyleBackColor = True
        '
        'ComboBox_Binning
        '
        Me.ComboBox_Binning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Binning.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Binning.FormattingEnabled = True
        Me.ComboBox_Binning.Items.AddRange(New Object() {"1x1", "2x2", "3x3", "4x4"})
        Me.ComboBox_Binning.Location = New System.Drawing.Point(469, 320)
        Me.ComboBox_Binning.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Binning.Name = "ComboBox_Binning"
        Me.ComboBox_Binning.Size = New System.Drawing.Size(247, 54)
        Me.ComboBox_Binning.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(281, 326)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(164, 46)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Binning:"
        '
        'TextBox_ExpTime
        '
        Me.TextBox_ExpTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_ExpTime.Location = New System.Drawing.Point(469, 242)
        Me.TextBox_ExpTime.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox_ExpTime.Name = "TextBox_ExpTime"
        Me.TextBox_ExpTime.Size = New System.Drawing.Size(247, 53)
        Me.TextBox_ExpTime.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(80, 248)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(344, 46)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "Exposure time (s):"
        '
        'Label_SaveDir
        '
        Me.Label_SaveDir.AutoSize = True
        Me.Label_SaveDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SaveDir.Location = New System.Drawing.Point(49, 955)
        Me.Label_SaveDir.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_SaveDir.Name = "Label_SaveDir"
        Me.Label_SaveDir.Size = New System.Drawing.Size(53, 46)
        Me.Label_SaveDir.TabIndex = 19
        Me.Label_SaveDir.Text = "..."
        '
        'Button_BrowseSaveDir
        '
        Me.Button_BrowseSaveDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_BrowseSaveDir.Location = New System.Drawing.Point(363, 877)
        Me.Button_BrowseSaveDir.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_BrowseSaveDir.Name = "Button_BrowseSaveDir"
        Me.Button_BrowseSaveDir.Size = New System.Drawing.Size(236, 70)
        Me.Button_BrowseSaveDir.TabIndex = 18
        Me.Button_BrowseSaveDir.Text = "Browse"
        Me.Button_BrowseSaveDir.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(49, 886)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(286, 46)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Save directory:"
        '
        'Button_SlewToPos
        '
        Me.Button_SlewToPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SlewToPos.Location = New System.Drawing.Point(996, 849)
        Me.Button_SlewToPos.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_SlewToPos.Name = "Button_SlewToPos"
        Me.Button_SlewToPos.Size = New System.Drawing.Size(524, 98)
        Me.Button_SlewToPos.TabIndex = 12
        Me.Button_SlewToPos.Text = "Slew To Position"
        Me.Button_SlewToPos.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1347, 320)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 46)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "fraction"
        '
        'TextBox_Distance
        '
        Me.TextBox_Distance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Distance.Location = New System.Drawing.Point(1167, 316)
        Me.TextBox_Distance.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox_Distance.Name = "TextBox_Distance"
        Me.TextBox_Distance.Size = New System.Drawing.Size(158, 53)
        Me.TextBox_Distance.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(923, 322)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(187, 46)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Distance:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(519, 152)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 46)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "arcmins"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(519, 78)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 46)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "arcmins"
        '
        'ComboBox_Pattern
        '
        Me.ComboBox_Pattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Pattern.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Pattern.FormattingEnabled = True
        Me.ComboBox_Pattern.Items.AddRange(New Object() {"Radial", "Rectangular 9", "Rectangular 5"})
        Me.ComboBox_Pattern.Location = New System.Drawing.Point(1167, 242)
        Me.ComboBox_Pattern.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Pattern.Name = "ComboBox_Pattern"
        Me.ComboBox_Pattern.Size = New System.Drawing.Size(439, 54)
        Me.ComboBox_Pattern.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(958, 248)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 46)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Pattern:"
        '
        'GroupBox_Pattern
        '
        Me.GroupBox_Pattern.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Pattern.Location = New System.Drawing.Point(969, 394)
        Me.GroupBox_Pattern.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox_Pattern.Name = "GroupBox_Pattern"
        Me.GroupBox_Pattern.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox_Pattern.Size = New System.Drawing.Size(591, 444)
        Me.GroupBox_Pattern.TabIndex = 4
        Me.GroupBox_Pattern.TabStop = False
        Me.GroupBox_Pattern.Text = "Imaging Pattern"
        '
        'TextBox_FOV_Y
        '
        Me.TextBox_FOV_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_FOV_Y.Location = New System.Drawing.Point(287, 146)
        Me.TextBox_FOV_Y.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox_FOV_Y.Name = "TextBox_FOV_Y"
        Me.TextBox_FOV_Y.Size = New System.Drawing.Size(207, 53)
        Me.TextBox_FOV_Y.TabIndex = 3
        '
        'TextBox_FOV_X
        '
        Me.TextBox_FOV_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_FOV_X.Location = New System.Drawing.Point(287, 72)
        Me.TextBox_FOV_X.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox_FOV_X.Name = "TextBox_FOV_X"
        Me.TextBox_FOV_X.Size = New System.Drawing.Size(207, 53)
        Me.TextBox_FOV_X.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(68, 152)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 46)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "FOV Y: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(68, 78)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 46)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "FOV X: "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button_IntraFocusGoto)
        Me.GroupBox4.Controls.Add(Me.TextBox_FocusShift)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Button_ExtraFocusGoto)
        Me.GroupBox4.Controls.Add(Me.Button_InFocusGoto)
        Me.GroupBox4.Controls.Add(Me.Button_InFocusSet)
        Me.GroupBox4.Controls.Add(Me.Label_InFocusPos)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label_FocusPos)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(0, 433)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox4.Size = New System.Drawing.Size(1666, 313)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Focuser"
        '
        'Button_IntraFocusGoto
        '
        Me.Button_IntraFocusGoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_IntraFocusGoto.Location = New System.Drawing.Point(1260, 216)
        Me.Button_IntraFocusGoto.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_IntraFocusGoto.Name = "Button_IntraFocusGoto"
        Me.Button_IntraFocusGoto.Size = New System.Drawing.Size(348, 65)
        Me.Button_IntraFocusGoto.TabIndex = 32
        Me.Button_IntraFocusGoto.Text = "Goto Intra Focus"
        Me.Button_IntraFocusGoto.UseVisualStyleBackColor = True
        '
        'TextBox_FocusShift
        '
        Me.TextBox_FocusShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_FocusShift.Location = New System.Drawing.Point(338, 220)
        Me.TextBox_FocusShift.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox_FocusShift.Name = "TextBox_FocusShift"
        Me.TextBox_FocusShift.Size = New System.Drawing.Size(285, 53)
        Me.TextBox_FocusShift.TabIndex = 29
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(59, 226)
        Me.Label23.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(236, 46)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "Focus shift: "
        '
        'Button_ExtraFocusGoto
        '
        Me.Button_ExtraFocusGoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ExtraFocusGoto.Location = New System.Drawing.Point(1260, 131)
        Me.Button_ExtraFocusGoto.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_ExtraFocusGoto.Name = "Button_ExtraFocusGoto"
        Me.Button_ExtraFocusGoto.Size = New System.Drawing.Size(348, 65)
        Me.Button_ExtraFocusGoto.TabIndex = 27
        Me.Button_ExtraFocusGoto.Text = "Goto Extra Focus"
        Me.Button_ExtraFocusGoto.UseVisualStyleBackColor = True
        '
        'Button_InFocusGoto
        '
        Me.Button_InFocusGoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_InFocusGoto.Location = New System.Drawing.Point(1260, 46)
        Me.Button_InFocusGoto.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_InFocusGoto.Name = "Button_InFocusGoto"
        Me.Button_InFocusGoto.Size = New System.Drawing.Size(348, 65)
        Me.Button_InFocusGoto.TabIndex = 23
        Me.Button_InFocusGoto.Text = "Goto In Focus"
        Me.Button_InFocusGoto.UseVisualStyleBackColor = True
        '
        'Button_InFocusSet
        '
        Me.Button_InFocusSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_InFocusSet.Location = New System.Drawing.Point(517, 124)
        Me.Button_InFocusSet.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_InFocusSet.Name = "Button_InFocusSet"
        Me.Button_InFocusSet.Size = New System.Drawing.Size(211, 65)
        Me.Button_InFocusSet.TabIndex = 22
        Me.Button_InFocusSet.Text = "Set"
        Me.Button_InFocusSet.UseVisualStyleBackColor = True
        '
        'Label_InFocusPos
        '
        Me.Label_InFocusPos.AutoSize = True
        Me.Label_InFocusPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_InFocusPos.Location = New System.Drawing.Point(331, 130)
        Me.Label_InFocusPos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_InFocusPos.Name = "Label_InFocusPos"
        Me.Label_InFocusPos.Size = New System.Drawing.Size(53, 46)
        Me.Label_InFocusPos.TabIndex = 21
        Me.Label_InFocusPos.Text = "..."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(103, 131)
        Me.Label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(195, 46)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "In Focus: "
        '
        'Label_FocusPos
        '
        Me.Label_FocusPos.AutoSize = True
        Me.Label_FocusPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FocusPos.Location = New System.Drawing.Point(331, 65)
        Me.Label_FocusPos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_FocusPos.Name = "Label_FocusPos"
        Me.Label_FocusPos.Size = New System.Drawing.Size(53, 46)
        Me.Label_FocusPos.TabIndex = 19
        Me.Label_FocusPos.Text = "..."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(116, 67)
        Me.Label20.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(186, 46)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Position: "
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1666, 1795)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "MainForm"
        Me.Text = "SGP Collimation Aid"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label_StatusCamera As Label
    Friend WithEvents Label_StatusTelescope As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label_Scope_DEC As Label
    Friend WithEvents Label_Scope_RA As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox_FOV_Y As TextBox
    Friend WithEvents TextBox_FOV_X As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBox_Pattern As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox_Pattern As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox_Distance As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button_SlewToPos As Button
    Friend WithEvents Button_SetToCenter As Button
    Friend WithEvents Label_Offset_DEC As Label
    Friend WithEvents Label_Offset_RA As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents ComboBox_Binning As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox_ExpTime As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label_SaveDir As Label
    Friend WithEvents Button_BrowseSaveDir As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Button_CaptureFrame As Button
    Friend WithEvents Button_Capture_All_Frames As Button
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox_FOV_Angle As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label_FocusPos As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Button_ExtraFocusGoto As Button
    Friend WithEvents Button_InFocusGoto As Button
    Friend WithEvents Button_InFocusSet As Button
    Friend WithEvents Label_InFocusPos As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox_FocusShift As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Button_IntraFocusGoto As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label_StatusFocuser As Label
    Friend WithEvents CheckBox_StackFrames As CheckBox
    Friend WithEvents Button_StackFrames As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
