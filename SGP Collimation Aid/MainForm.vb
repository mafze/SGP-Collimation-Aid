Imports Newtonsoft.Json
Imports RestSharp
Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Globalization
Imports System.Net.Sockets
Imports System.Threading
Imports nom.tam.fits
Imports nom.tam.util

Public Class MainForm

    'FITS class
    Dim FITSworker As New FITSImageClass

    'SGP comm
    Dim SGPurl As String = "http://localhost:59590/" 'default http://localhost:59590/  this is saved into the json settings file, but cannot be changed in the program altough it can be changed in the file
    Dim SGP As New SGPClass(SGPurl)

    'equipment 
    Dim CameraConnected As Boolean
    Dim TelescopeConnected As Boolean
    Dim FocuserConnected As Boolean

    'astro
    Dim Astro As New AstronomyClass

    'imaging pattern settings
    Dim CentreSet As Boolean = False
    Dim Centre_RA, Centre_DEC As Double     'centre position in DEG

    'focuser positions
    Dim FocuserInFocusPosition As Integer

    'capture sequence
    Public abortSeq As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim SizeX, SizeY As Integer

        'load saved settings
        TextBox_FOV_X.Text = My.Settings.FOV_X
        TextBox_FOV_Y.Text = My.Settings.FOV_Y
        TextBox_FOV_Angle.Text = My.Settings.FOV_Angle
        ComboBox_Pattern.SelectedIndex = My.Settings.PatternIdx
        TextBox_Distance.Text = My.Settings.Distance
        Label_SaveDir.Text = My.Settings.SaveDir
        TextBox_ExpTime.Text = My.Settings.ExpTime
        ComboBox_Binning.SelectedIndex = My.Settings.BinningIdx
        TextBox_FocusShift.Text = My.Settings.FocusShift

        'disable some buttons
        Button_InFocusSet.Enabled = False
        Button_InFocusGoto.Enabled = False
        Button_ExtraFocusGoto.Enabled = False
        Button_IntraFocusGoto.Enabled = False
        Button_SetToCenter.Enabled = False

        'init imaging pattern radio buttons
        PopulateImagePattern()

        'set main from size
        SizeY = 0
        SizeX = 0
        SizeY = SizeY + GroupBox1.Height + GroupBox1.Padding.Top + GroupBox1.Padding.Bottom
        SizeY = SizeY + GroupBox2.Height + GroupBox2.Padding.Top + GroupBox2.Padding.Bottom
        SizeY = SizeY + GroupBox3.Height + GroupBox3.Padding.Top + GroupBox3.Padding.Bottom
        SizeY = SizeY + GroupBox4.Height + GroupBox4.Padding.Top + GroupBox4.Padding.Bottom
        SizeX = GroupBox1.Width * 1.02
        Me.Height = SizeY
        Me.Width = SizeX

        Timer.Interval = 500
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick

        If SGPresponding() Then
            UpdateSGPStatus()
            UpdateTelescope()
        Else
            Label_StatusCamera.Text = "N.A."
            Label_StatusTelescope.Text = "N.A."
            Label_StatusFocuser.Text = "N.A."
        End If

        If CentreSet Then
            Button_SlewToPos.Enabled = True
            GroupBox_Pattern.Enabled = True
            If CameraConnected Then
                Button_CaptureFrame.Enabled = True
                Button_Capture_All_Frames.Enabled = True
                CheckBox_StackFrames.Enabled = True
            End If
        Else
            Button_SlewToPos.Enabled = False
            Button_CaptureFrame.Enabled = False
            Button_Capture_All_Frames.Enabled = False
            CheckBox_StackFrames.Enabled = False
            GroupBox_Pattern.Enabled = False
        End If

    End Sub

    Public Function SGPresponding() As Boolean
        Dim SGPport As Integer = 59590

        Dim result As IAsyncResult
        Dim success As Boolean
        Dim checkPort As New TcpClient

        result = checkPort.BeginConnect("localhost", SGPport, Nothing, Nothing)
        success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(100))

        If success Then
            checkPort.Close()
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub UpdateSGPStatus()
        Dim SGPreturn As New SGPClass.SGPresponse
        Dim FocusPos As New SGPClass.FocuserPos

        SGPreturn = SGP.TelescopeStatus()
        If SGPreturn.Success = True Then
            If String.Compare(SGPreturn.Response, "DISCONNECTED") = 0 Then
                TelescopeConnected = False
                Label_StatusTelescope.Text = "DISCONNECTED"
                CentreSet = False   'assume that a lost connection means we need to reset the centre position
                Label_Scope_RA.Text = "NA"
                Label_Scope_DEC.Text = "NA"
                Label_Offset_RA.Text = "NA"
                Label_Offset_DEC.Text = "NA"
                Button_SetToCenter.Enabled = False
                GroupBox_Pattern.Enabled = False
            Else
                TelescopeConnected = True
                Button_SetToCenter.Enabled = True
                GroupBox_Pattern.Enabled = True
                Label_StatusTelescope.Text = SGPreturn.Response
            End If
        Else
            Label_StatusTelescope.Text = "N.A."
            TelescopeConnected = False
        End If

        SGPreturn = SGP.CameraStatus()
        If SGPreturn.Success = True Then
            If String.Compare(SGPreturn.Response, "DISCONNECTED") = 0 Then
                CameraConnected = False
                Label_StatusCamera.Text = "DISCONNECTED"
                Button_CaptureFrame.Enabled = False
                Button_Capture_All_Frames.Enabled = False
            Else
                CameraConnected = True
                Label_StatusCamera.Text = SGPreturn.Response
            End If
        Else
            Label_StatusCamera.Text = "N.A."
            CameraConnected = False
        End If

        SGPreturn = SGP.FocuserStatus()
        If SGPreturn.Success = True Then
            If String.Compare(SGPreturn.Response, "DISCONNECTED") = 0 Then
                FocuserConnected = False
                Label_StatusFocuser.Text = "DISCONNECTED"
                Button_InFocusSet.Enabled = False
                Button_InFocusGoto.Enabled = False
                Button_ExtraFocusGoto.Enabled = False
                Button_IntraFocusGoto.Enabled = False
            Else
                FocuserConnected = True
                Label_StatusFocuser.Text = SGPreturn.Response
                FocusPos = SGP.GetFocuserPosition()
                Label_FocusPos.Text = FocusPos.Position.ToString
                Label_InFocusPos.Text = FocuserInFocusPosition.ToString
                Button_InFocusSet.Enabled = True
            End If
        Else
            Label_StatusFocuser.Text = "N.A."
            Label_FocusPos.Text = "N.A."
            Label_InFocusPos.Text = "N.A."
            FocuserConnected = False
            Button_InFocusSet.Enabled = False
            Button_InFocusGoto.Enabled = False
            Button_ExtraFocusGoto.Enabled = False
            Button_IntraFocusGoto.Enabled = False
        End If

    End Sub
    Public Sub UpdateTelescope()
        Dim ScopePos As New SGPClass.TelescopePos
        Dim RA_Text, DEC_Text As String

        ScopePos = SGP.TelescopePosition()
        If ScopePos.Success Then
            Astro.EqPos_ToString(ScopePos.RA / 24 * 360, ScopePos.DEC, RA_Text, DEC_Text)
            Label_Scope_RA.Text = RA_Text
            Label_Scope_DEC.Text = DEC_Text

            If CentreSet Then
                Label_Offset_RA.Text = ((ScopePos.RA / 24 * 360 - Centre_RA) * 60).ToString("F1") + " '"
                Label_Offset_DEC.Text = ((ScopePos.DEC - Centre_DEC) * 60).ToString("F1") + " '"
            Else
                Label_Offset_RA.Text = "NA"
                Label_Offset_DEC.Text = "NA"
            End If

        End If
    End Sub

    Public Sub CaptureAllPatternFrames_Sequence()
        Dim SGPreturn As New SGPClass.SGPresponse
        Dim exptime As Double
        Dim binning, framesize As Integer
        Dim newdir, filepath As String
        Dim fileNames(8) As String
        Dim ind, stepSize As Integer
        Dim result As Integer

        Dim CaptureForm As New SequenceForm

        abortSeq = False
        CaptureForm.lblAbort.Text = ""

        CaptureForm.Show()

        exptime = Double.Parse(TextBox_ExpTime.Text)
        binning = ComboBox_Binning.SelectedIndex + 1
        framesize = 1

        newdir = "CollimationFrames_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss")
        filepath = Path.Combine(Label_SaveDir.Text, newdir)

        If ComboBox_Pattern.SelectedIndex = 2 Then
            stepSize = 2
            ReDim fileNames(4)
        Else
            stepSize = 1
        End If

        ind = 0
        For k As Integer = 0 To 8 Step stepSize
            fileNames(ind) = Path.Combine(filepath, "CollimationFrame" + ind.ToString + ".fit")

            CaptureForm.lblPath.Text = fileNames(ind)
            CaptureForm.lblMessage.Text = "Slewing to position " + k.ToString + " ..."
            Application.DoEvents()

            CheckRadialButton(k)
            SlewToPosition(k)

            SGPreturn = SGP.TelescopeStatus() 'check that telescope is IDLE (hence not slewing)
            Do Until String.Compare(SGPreturn.Response, "IDLE") = 0
                Threading.Thread.Sleep(500)
                SGPreturn = SGP.TelescopeStatus()
            Loop

            'let mount settle
            CaptureForm.lblMessage.Text = "Mount settling..."
            Application.DoEvents()
            Threading.Thread.Sleep(3000)

            'take frame
            CaptureForm.lblMessage.Text = "Capturing frame..."
            Application.DoEvents()
            result = CaptureFrame(exptime, binning, framesize, fileNames(ind))
            Threading.Thread.Sleep(1000)    'make sure frame capture is finished
            If result > 0 Then 'then there was an error, abort!
                MessageBox.Show("Error when capturing frame, aborting sequence!")
                abortSeq = True
            End If

            ind = ind + 1

            'exiting capture for loop if there was camera error, or if the abort button was clicked
            If abortSeq = True Then
                Exit For
            End If
        Next

        'return to centre position
        CaptureForm.lblMessage.Text = "Return to centre position... "
        Application.DoEvents()
        If ComboBox_Pattern.SelectedIndex = 0 Then 'RADIAL pattern
            CheckRadialButton(0)
            SlewToPosition(0)
        ElseIf ComboBox_Pattern.SelectedIndex = 1 Or ComboBox_Pattern.SelectedIndex = 2 Then 'RECTANGULAR pattern
            CheckRadialButton(4)
            SlewToPosition(4)
        End If

        CaptureForm.Close()
        CaptureForm.Dispose()

        'stack files if checkbox checked
        If CheckBox_StackFrames.Checked And Not abortSeq Then
            StackFrames(fileNames)
        End If

    End Sub


    Public Function CaptureFrame(ByVal exptime As Single, ByVal binning As Integer, ByVal framesize As Integer, ByVal filepath As String) As Double
        Dim SGPreturn As New SGPClass.SGPresponse
        Dim response As String
        Dim error_message As String

        Dim timeout As Double = 30

        'START IMAGE CAPTURE
        SGPreturn = SGP.CameraStatus() 'check that it is IDLE
        If String.Compare(SGPreturn.Response, "IDLE") = 0 Or String.Compare(SGPreturn.Response, "READY") = 0 Then
            SGPreturn = SGP.ImageCapture(exptime, binning, framesize, "Light", filepath)
        Else
            error_message = "Camera Is busy Or Not connected. Aborting!"
            MessageBox.Show(error_message, "Error")
            Return -1   'return with error code -1
        End If

        'HANDLE WAIT FOR IMAGE CAPTURE
        If SGPreturn.Success Then
            response = WaitForImage(SGPreturn.Response, exptime, timeout)   'wait for image, returns either empty, "Abort" or actual filepath
            If response = String.Empty Then
                error_message = "SGP timed out - no image save confirmation. Aborting!"
                MessageBox.Show(error_message, "Error")
                Return -2   'return with error code -2
            ElseIf String.Compare(response, "Abort") = 0 Then

                Return -3   'return with error code -3
            Else
                Return 0 'return code WITHOUT error 0
            End If
        Else
            MessageBox.Show(SGPreturn.Response + ". Aborting!", "Error")
            Return -4   'return with error code -4
        End If

    End Function

    Public Function WaitForImage(ByVal imagereceipt As String, ByVal exptime As Double, ByVal timeout As Double) As String
        'wait for image. if all ok return image path from SGP, if aborted by user return "Abort", otherwise it timed out and returns ""

        Dim SGPreturn As New SGPClass.SGPresponse
        Dim start, finish, current As Double
        'Dim timeleft As TimeSpan
        Dim EndOfDay As Double = 86400

        start = DateAndTime.Timer
        finish = start + exptime + timeout
        Do
            current = DateAndTime.Timer
            'if finish is after midnight, adjust finish time
            If current < start Then
                current = current + EndOfDay
            End If
            'timeleft = TimeSpan.FromSeconds(finish - current) 'NOT USED

            'CHECK IF IMAGE READY
            SGPreturn = SGP.ImagePath(imagereceipt)
            If SGPreturn.Success Then
                'Logging("File saved to: " + SGPreturn.Response)
                Return SGPreturn.Response   'return saved file path if success
            End If

            Application.DoEvents()

            'if Abort has been clicked, stop camera and return "Abort" immediately
            'If AbortSequence Then
            ' Try
            'Dim dummy As String
            'SGP.Message("abortimage", dummy)
            'Catch ex As Exception
            ''ignore if SGP didnt respond
            'End Try
            'Return "Abort"
            'End If

        Loop While current < finish

        Return ""   'EMPTY IF NOTHING CAME BACK
    End Function

    Public Sub PopulateImagePattern()
        Dim RButton As RadioButton
        Dim RLabel As Label
        Dim MidX, MidY As Integer

        GroupBox_Pattern.Controls.Clear()   'start by clearing the old radio buttons

        MidX = GroupBox_Pattern.Width / 2
        MidY = GroupBox_Pattern.Height / 2

        'RADIAL pattern
        If ComboBox_Pattern.SelectedIndex = 0 Then
            Dim Radius As Integer
            Radius = Math.Min(GroupBox_Pattern.Width / 2, GroupBox_Pattern.Height / 2) * 0.5

            'add centre button
            RButton = New RadioButton
            RButton.UseVisualStyleBackColor = True
            RButton.Text = ""
            RButton.Size = New System.Drawing.Size(20, 20)
            RButton.Left = MidX
            RButton.Top = MidY
            RButton.Name = "ImagePos0"
            GroupBox_Pattern.Controls.Add(RButton)

            RLabel = New Label
            RLabel.Text = "0"
            RLabel.Left = MidX - 12
            RLabel.Top = MidY
            RLabel.Width = 12
            RLabel.Name = "ImagePosLabel0"
            GroupBox_Pattern.Controls.Add(RLabel)

            'add the circle of buttons
            For k As Integer = 0 To 7
                RButton = New RadioButton
                RButton.Name = "ImagePos" + (k + 1).ToString
                RButton.UseVisualStyleBackColor = True
                RButton.Text = ""
                RButton.Size = New System.Drawing.Size(20, 20)
                RButton.Left = MidX + Math.Sin(Math.PI / 4 * k) * Radius
                RButton.Top = MidY - Math.Cos(Math.PI / 4 * k) * Radius
                GroupBox_Pattern.Controls.Add(RButton)

                RLabel = New Label
                RLabel.Text = (k + 1).ToString
                RLabel.Left = MidX + Math.Sin(Math.PI / 4 * k) * Radius - 12
                RLabel.Top = MidY - Math.Cos(Math.PI / 4 * k) * Radius
                RLabel.Width = 12
                RLabel.Name = "ImagePosLabel" + (k + 1).ToString
                GroupBox_Pattern.Controls.Add(RLabel)
            Next

            'RECTANGULAR pattern
        ElseIf ComboBox_Pattern.SelectedIndex = 1 Or ComboBox_Pattern.SelectedIndex = 2 Then
            Dim dX, dY, n As Integer

            dX = GroupBox_Pattern.Width / 2 * 0.5
            dY = GroupBox_Pattern.Width / 2 * 0.5

            n = 0
            For k As Integer = 0 To 2
                For l As Integer = 0 To 2
                    RButton = New RadioButton
                    RButton.Name = "ImagePos" + n.ToString
                    RButton.UseVisualStyleBackColor = True
                    RButton.Text = ""
                    RButton.Size = New System.Drawing.Size(20, 20)
                    RButton.Left = MidX - dX + k * dX
                    RButton.Top = MidY - dY + l * dY
                    GroupBox_Pattern.Controls.Add(RButton)

                    RLabel = New Label
                    RLabel.Text = n.ToString
                    RLabel.Left = MidX - dX + k * dX - 12
                    RLabel.Top = MidY - dY + l * dY
                    RLabel.Width = 12
                    RLabel.Name = "ImagePosLabel" + n.ToString
                    GroupBox_Pattern.Controls.Add(RLabel)

                    n = n + 1
                Next
            Next
            If ComboBox_Pattern.SelectedIndex = 2 Then
                DisableRadialButton(1)
                DisableRadialButton(3)
                DisableRadialButton(5)
                DisableRadialButton(7)
            End If

        End If
    End Sub

    Public Sub SlewToPosition(ByVal Position As Integer)
        Dim NewPosRA, NewPosDEC As Double
        Dim FOVX, FOVY, Angle, FracDist As Double

        FOVX = Double.Parse(TextBox_FOV_X.Text) / 60 'arcmins to DEG
        FOVY = Double.Parse(TextBox_FOV_Y.Text) / 60 'arcmins to DEG
        Angle = Double.Parse(TextBox_FOV_Angle.Text)
        FracDist = Double.Parse(TextBox_Distance.Text)

        If ComboBox_Pattern.SelectedIndex = 0 Then 'RADIAL pattern
            If Position = 0 Then
                NewPosRA = Centre_RA
                NewPosDEC = Centre_DEC
            Else
                Dim Radius As Double
                Radius = Math.Min(FOVY / 2, FOVX / 2) * FracDist

                NewPosRA = Centre_RA + Math.Sin(Math.PI / 4 * (Position - 1) + Angle / 180 * Math.PI) * Radius / Math.Cos(Centre_DEC / 180 * Math.PI)   'the cos factor accounts relation between linear and angular scale for different DEC angles 
                NewPosDEC = Centre_DEC - Math.Cos(Math.PI / 4 * (Position - 1) + Angle / 180 * Math.PI) * Radius
            End If
        ElseIf ComboBox_Pattern.SelectedIndex = 1 Or ComboBox_Pattern.SelectedIndex = 2 Then 'RECTANGULAR pattern
            Dim dX, dY As Double
            Dim posX, posY As Double
            Dim posRA, posDEC As Double
            Dim k, l As Integer

            'pixel steps
            dX = FOVX / 2 * FracDist
            dY = FOVY / 2 * FracDist

            'position indices
            l = Position Mod 3
            k = (Position - l) / 3

            'relative pixel positions in camera frame
            posX = -dX + k * dX
            posY = -dY + l * dY

            'relative positions in RA and DEC frame
            posRA = Math.Cos(Angle / 180 * Math.PI) * posX - Math.Sin(Angle / 180 * Math.PI) * posY
            posDEC = Math.Sin(Angle / 180 * Math.PI) * posX + Math.Cos(Angle / 180 * Math.PI) * posY

            NewPosRA = Centre_RA + posRA / Math.Cos(Centre_DEC / 180 * Math.PI)     'the cos factor accounts relation between linear and angular scale for different DEC angles 
            NewPosDEC = Centre_DEC + posDEC
        End If

        SGP.SlewTelescope(NewPosRA / 360 * 24, NewPosDEC)
    End Sub

    Public Sub StackFrames(ByVal fileNames As String())
        Dim savedir As String
        Dim fitsim As New FITSImageClass.FITSImage
        Dim stackedfitsim As New FITSImageClass.FITSImage

        Dim stackedData() As Integer
        Dim meanBkg As Integer

        Dim StackingForm As New StackingProgressForm

        StackingForm.Show()
        StackingForm.ProgressBar_Stacking.Value = 0

        meanBkg = 0
        For k As Integer = 0 To fileNames.Count - 1
            StackingForm.Label_Stacking.Text = "Stacking frame " + k.ToString + "/" + fileNames.Count.ToString + " frames..."
            Application.DoEvents()

            Try
                fitsim = FITSworker.LoadFitsFile(fileNames(k))
            Catch ex As Exception
                MessageBox.Show("Something went wrong! : " + vbNewLine + ex.Message + vbNewLine + vbNewLine + "Stacktrace:" + ex.StackTrace, "PROGRAM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If k = 0 Then
                ReDim stackedData(fitsim.Data.Count - 1)
            End If

            'add to stack and subtract the background so that the pedestal is zero in average
            For m As Integer = 0 To fitsim.Data.Count - 1
                stackedData(m) = stackedData(m) + fitsim.Data(m) - fitsim.MeanADU
            Next

            meanBkg = meanBkg + fitsim.MeanADU

            StackingForm.ProgressBar_Stacking.Value = Math.Round((k + 1) / fileNames.Count * 100)
            Application.DoEvents()
        Next
        Application.DoEvents()
        meanBkg = meanBkg / fileNames.Count

        'add mean background to "lift" the general background pedestal from zero
        StackingForm.Label_Stacking.Text = "Adjusting mean background ADU level..."
        Application.DoEvents()
        For m As Integer = 0 To stackedData.Count - 1
            stackedData(m) = stackedData(m) + meanBkg

            'if pixel goes above maxADU, lets put it to mean background
            'if there is negative values, also put to mean background
            If stackedData(m) > fitsim.MaxADU Then
                stackedData(m) = meanBkg
            ElseIf stackedData(m) < 0 Then
                stackedData(m) = meanBkg
            End If
        Next

        'create new fits image
        stackedfitsim = fitsim
        stackedfitsim.MeanADU = meanBkg
        stackedfitsim.Data = stackedData

        'save it to a file
        savedir = Path.GetDirectoryName(fileNames(0))
        savedir = Path.Combine(savedir, "stacked_image.fit")
        StackingForm.Label_Stacking.Text = "Saving stacked image ..."
        Application.DoEvents()
        FITSworker.SaveFitsFile(stackedfitsim, savedir)

        'done!
        MessageBox.Show("Stacked collimation frames saved to: " + savedir)
        StackingForm.Close()
        StackingForm.Dispose()
    End Sub

    Public Sub ShowError(ByVal ex As Exception)
        MessageBox.Show("Something went wrong! : " + vbNewLine + ex.Message + vbNewLine + vbNewLine + "Stacktrace:" + ex.StackTrace, "PROGRAM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Button_SetToCenter_Click(sender As Object, e As EventArgs) Handles Button_SetToCenter.Click
        Dim ScopePos As New SGPClass.TelescopePos

        'get current position
        ScopePos = SGP.TelescopePosition()
        Centre_RA = ScopePos.RA / 24 * 360      'convert from HRS to DEG
        Centre_DEC = ScopePos.DEC

        'set centre radial button
        If ComboBox_Pattern.SelectedIndex = 0 Then 'RADIAL pattern
            CheckRadialButton(0)
        ElseIf ComboBox_Pattern.SelectedIndex = 1 Or ComboBox_Pattern.SelectedIndex = 2 Then 'RECTANGULAR pattern
            CheckRadialButton(4)
        End If

        If CentreSet = False Then
            CentreSet = True
        End If
    End Sub

    Public Sub CheckRadialButton(ByVal Position As Integer)
        Dim RButton As RadioButton

        RButton = GroupBox_Pattern.Controls.Find("ImagePos" + Position.ToString, True).First
        RButton.Checked = True
    End Sub

    Public Sub DisableRadialButton(ByVal Position As Integer)
        Dim RButton As RadioButton

        RButton = GroupBox_Pattern.Controls.Find("ImagePos" + Position.ToString, True).First
        RButton.Enabled = False
    End Sub

    Private Sub Button_CaptureFrame_Click(sender As Object, e As EventArgs) Handles Button_CaptureFrame.Click
        Dim exptime As Double
        Dim binning, framesize As Integer
        Dim filename, filepath As String
        Dim SaveDir As String

        SaveDir = Label_SaveDir.Text
        If Not Directory.Exists(SaveDir) Then
            MsgBox("The save directory does not exist. Aborting!")
            Exit Sub
        End If

        exptime = Double.Parse(TextBox_ExpTime.Text)
        binning = ComboBox_Binning.SelectedIndex + 1
        framesize = 1

        filename = "CollimationFrame_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss")
        filepath = Path.Combine(SaveDir, filename)

        CaptureFrame(exptime, binning, framesize, filepath)
    End Sub

    Private Sub Button_Capture_All_Frames_Click(sender As Object, e As EventArgs) Handles Button_Capture_All_Frames.Click
        Dim SaveDir As String

        SaveDir = Label_SaveDir.Text
        If Not Directory.Exists(SaveDir) Then
            MsgBox("The save directory does not exist. Aborting!")
            Exit Sub
        End If

        CaptureAllPatternFrames_Sequence()
    End Sub

    Private Sub Button_BrowseSaveDir_Click(sender As Object, e As EventArgs) Handles Button_BrowseSaveDir.Click
        FolderBrowserDialog.SelectedPath = Label_SaveDir.Text
        If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Label_SaveDir.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub ComboBox_Pattern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Pattern.SelectedIndexChanged
        PopulateImagePattern()

        If CentreSet Then
            'set centre radial button
            If ComboBox_Pattern.SelectedIndex = 0 Then 'RADIAL pattern
                CheckRadialButton(0)
            ElseIf ComboBox_Pattern.SelectedIndex = 1 Or ComboBox_Pattern.SelectedIndex = 2 Then 'RECTANGULAR pattern
                CheckRadialButton(4)
            End If
        End If

    End Sub

    Private Sub Button_SlewToPos_Click(sender As Object, e As EventArgs) Handles Button_SlewToPos.Click
        Dim RName As String = Nothing
        Dim ImagePos As Integer

        For Each RButton In GroupBox_Pattern.Controls.OfType(Of RadioButton)
            If RButton.Checked Then
                RName = RButton.Name
            End If
        Next

        If RName Is Nothing Then
            MsgBox("Please select an imaging position in the pattern!")
            Exit Sub
        Else
            ImagePos = Integer.Parse(RName(RName.Length - 1))
            SlewToPosition(ImagePos)
        End If

    End Sub

    Private Sub Button_InFocusSet_Click(sender As Object, e As EventArgs) Handles Button_InFocusSet.Click
        'set current focus position to In Focus position
        If FocuserConnected Then
            FocuserInFocusPosition = Integer.Parse(Label_FocusPos.Text)

            Button_InFocusGoto.Enabled = True
            Button_ExtraFocusGoto.Enabled = True
            Button_IntraFocusGoto.Enabled = True
        End If
    End Sub

    Private Sub Button_InFocusGoto_Click(sender As Object, e As EventArgs) Handles Button_InFocusGoto.Click
        If FocuserConnected And FocuserInFocusPosition > 0 Then
            SGP.SetFocuserPosition(FocuserInFocusPosition)
        End If
    End Sub

    Private Sub Button_ExtraFocusGoto_Click(sender As Object, e As EventArgs) Handles Button_ExtraFocusGoto.Click
        Dim FocusShift As Integer

        Try
            FocusShift = Integer.Parse(TextBox_FocusShift.Text)
        Catch ex As Exception
            MsgBox("Could not parse Focus Shift. Must be an integer value!")
        End Try

        If FocuserConnected And FocuserInFocusPosition > 0 Then
            SGP.SetFocuserPosition(FocuserInFocusPosition + FocusShift)
        End If
    End Sub

    Private Sub Button_IntraFocusGoto_Click(sender As Object, e As EventArgs) Handles Button_IntraFocusGoto.Click
        Dim FocusShift As Integer

        Try
            FocusShift = Integer.Parse(TextBox_FocusShift.Text)
        Catch ex As Exception
            MsgBox("Could not parse Focus Shift. Must be an integer value!")
        End Try

        If FocuserConnected And FocuserInFocusPosition > 0 Then
            SGP.SetFocuserPosition(FocuserInFocusPosition - FocusShift)
        End If
    End Sub

    Private Sub Button_StackFrames_Click(sender As Object, e As EventArgs) Handles Button_StackFrames.Click
        Dim SaveDir As String

        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.Filter = "fit files (*.fit)|*.fit|All files (*.*)|*.*"
        OpenFileDialog1.FileName = ""

        SaveDir = Label_SaveDir.Text
        If Directory.Exists(SaveDir) Then
            OpenFileDialog1.InitialDirectory = SaveDir
        End If

        Dim result As DialogResult = OpenFileDialog1.ShowDialog
        Dim fileNames As String()

        If result = Windows.Forms.DialogResult.OK Then
            fileNames = OpenFileDialog1.FileNames
            If fileNames.Length > 1 Then
                StackFrames(fileNames)
            Else
                MessageBox.Show("At least two files must be selected for stacking!")
            End If
        End If
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'save settings
        My.Settings.FOV_X = TextBox_FOV_X.Text
        My.Settings.FOV_Y = TextBox_FOV_Y.Text
        My.Settings.FOV_Angle = TextBox_FOV_Angle.Text
        My.Settings.PatternIdx = ComboBox_Pattern.SelectedIndex
        My.Settings.Distance = TextBox_Distance.Text
        My.Settings.SaveDir = Label_SaveDir.Text
        My.Settings.ExpTime = TextBox_ExpTime.Text
        My.Settings.BinningIdx = ComboBox_Binning.SelectedIndex
        My.Settings.FocusShift = TextBox_FocusShift.Text

        My.Settings.Save()
    End Sub
End Class
