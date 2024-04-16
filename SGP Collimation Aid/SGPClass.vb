Imports RestSharp
Imports Newtonsoft.Json.Linq
Imports System.Globalization

Public Class SGPClass

    Public Property Address As String

    Public Structure SGPresponse
        Dim Success As Boolean
        Dim Response As String
    End Structure

    Public Structure CameraProps
        Dim Success As Boolean
        Dim SupportsSubframe As Boolean
        Dim NumPixelsX As Integer
        Dim NumPixelsY As Integer
    End Structure

    Public Structure TelescopePos
        Dim Success As Boolean
        Dim RA As Double
        Dim DEC As Double
    End Structure

    Public Structure FocuserPos
        Dim Success As Boolean
        Dim Position As Double
    End Structure

    Private response As String = ""
    Private json As JObject

    Public Sub New(Address_ As String)
        Me.Address = Address_
    End Sub

    Public Function CameraStatus() As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("devicestatus/camera", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("State")
        Return FunReturn
    End Function

    Public Function FilterwheelStatus() As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("devicestatus/filterwheel", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("State")
        Return FunReturn
    End Function

    Public Function FocuserStatus() As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("devicestatus/focuser", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("State")
        Return FunReturn
    End Function

    Public Function TelescopeStatus() As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("devicestatus/telescope", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("State")
        Return FunReturn
    End Function

    Public Function SetFilter(ByVal Position As Integer) As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("setfilterwheelpos/" + Position.ToString, response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("Message")
        Return FunReturn
    End Function

    Public Function GetFocuserPosition() As FocuserPos
        'Gets focuser position

        Dim FunReturn As New FocuserPos

        Try
            Me.Message("focuserpos", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Position = 0
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Position = json.SelectToken("Position")
        Return FunReturn
    End Function

    Public Function SetFocuserPosition(ByVal Position As Integer) As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("setfocuserpos/" + Position.ToString, response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("Message")
        Return FunReturn
    End Function

    Public Function TelescopeIsSlewing() As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("TelescopeIsSlewing", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("IsSlewing")
        Return FunReturn
    End Function

    Public Function TelescopePosition() As TelescopePos
        Dim FunReturn As New TelescopePos
        Try
            Me.Message("telescopepos", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.RA = 0
            FunReturn.DEC = 0
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.RA = json.SelectToken("Ra")
        FunReturn.DEC = json.SelectToken("Dec")
        Return FunReturn
    End Function

    Public Function SlewTelescope(ByVal RA As Double, ByVal DEC As Double) As SGPresponse
        'Slews telescope to RA and DEC coordinates
        'RA is in decimal HRS
        'DEC is in decimal DEG

        Dim rest_client As RestClient
        Dim request As RestRequest
        Dim rest_response As RestResponse
        Dim FunReturn As New SGPresponse

        rest_client = New RestClient(Me.Address)
        request = New RestRequest()
        request.Method = Method.Get
        request.RequestFormat = DataFormat.Json
        request.AddHeader("Accept", "application/json")
        request.Resource = "slewtelescopepos"
        request.Timeout = 1000

        request.Method = Method.Post
        request.AddQueryParameter("Ra", RA)
        request.AddQueryParameter("Dec", DEC)

        Try
            rest_response = rest_client.Execute(request)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = "Something went wrong with the SGP API call."
            MsgBox("Error during slew API call!")
            Return FunReturn
        End Try

        If rest_response.Content Is Nothing Then
            FunReturn.Success = False
            FunReturn.Response = "Something went wrong with the SGP API call."
            MsgBox("Error during slew API call!")
            Return FunReturn
        End If

        json = JObject.Parse(rest_response.Content)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("Message")

        Return FunReturn
    End Function

    Public Function GetCameraProps() As CameraProps
        Dim FunReturn As New CameraProps
        Try
            Me.Message("cameraprops", response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.SupportsSubframe = False
            FunReturn.NumPixelsX = 0
            FunReturn.NumPixelsY = 0
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.SupportsSubframe = json.SelectToken("SupportsSubframe")
        FunReturn.NumPixelsX = json.SelectToken("NumPixelsX")
        FunReturn.NumPixelsY = json.SelectToken("NumPixelsY")
        Return FunReturn
    End Function

    Public Function ImageCapture(ByVal exp As Single, ByVal bin As Integer, ByVal framesize As Integer, ByVal frametype As String, ByVal path As String) As SGPresponse
        Dim rest_client As RestClient
        Dim request As RestRequest
        Dim rest_response As RestResponse
        Dim FunReturn As New SGPresponse

        rest_client = New RestClient(Me.Address)
        request = New RestRequest()
        request.Method = Method.GET
        request.RequestFormat = DataFormat.Json
        request.AddHeader("Accept", "application/json")
        request.Resource = "image"
        request.Timeout = 1000

        request.Method = Method.POST
        request.AddQueryParameter("BinningMode", bin.ToString)   '1=1x1, 2=2x2, ...
        request.AddQueryParameter("ExposureLength", exp.ToString("F4", CultureInfo.InvariantCulture))   ' must specify number of digits "F4" as "F" for CultureInfo.InvariantCulture will by default only use 2 decimal places, sick...., to be safe we use 4 digital places
        request.AddQueryParameter("FrameType", frametype)
        request.AddQueryParameter("Path", path)

        'if framesize > 1, then calculate x,y,w,h , if framesize = 1 then skip
        If framesize > 1 Then
            Dim camera As New CameraProps
            camera = GetCameraProps()

            'get W and H of camera and check it is supports subframe
            If camera.Success = True And camera.SupportsSubframe = True Then
                Dim w0, h0, x, y, w, h As Integer

                'get camera size
                w0 = camera.NumPixelsX
                h0 = camera.NumPixelsY

                'change max frame width and height due to binning
                w0 = Math.Floor(w0 / bin)
                h0 = Math.Floor(h0 / bin)

                'calculate subframe coordinates
                w = Math.Floor(w0 / framesize)
                h = Math.Floor(h0 / framesize)
                x = Math.Floor((w0 * framesize - w0) / 2 / framesize)
                y = Math.Floor((h0 * framesize - h0) / 2 / framesize)

                'add subframe data to message
                request.AddQueryParameter("UseSubframe", True)
                request.AddQueryParameter("X", x)
                request.AddQueryParameter("Y", y)
                request.AddQueryParameter("Width", w)
                request.AddQueryParameter("Height", h)
            End If
        End If

        Try
            rest_response = rest_client.Execute(request)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = "Something went wrong with the SGP API call."
            Return FunReturn
        End Try

        json = JObject.Parse(rest_response.Content)
        FunReturn.Success = json.SelectToken("Success")
        If FunReturn.Success = True Then
            FunReturn.Response = json.SelectToken("Receipt")    'if call successful, return GUID receipt for image
        Else
            FunReturn.Response = json.SelectToken("Message")    'if not then return message containing error message
        End If
        Return FunReturn
    End Function

    Public Function ImagePath(ByVal imagereceipt As String) As SGPresponse
        Dim FunReturn As New SGPresponse

        Try
            Me.Message("imagepath/" + imagereceipt, response)
        Catch ex As Exception
            FunReturn.Success = False
            FunReturn.Response = ""
            Return FunReturn
        End Try

        json = JObject.Parse(response)
        FunReturn.Success = json.SelectToken("Success")
        FunReturn.Response = json.SelectToken("Message")
        Return FunReturn
    End Function

    Public Sub Message(ByVal Command As String, ByRef Response As String)
        Dim rest_client As RestClient
        Dim request As RestRequest

        rest_client = New RestClient(Me.Address)
        request = New RestRequest()
        request.Method = Method.GET
        request.RequestFormat = DataFormat.Json
        request.AddHeader("Accept", "application/json")
        request.Resource = Command
        request.Timeout = 1000

        Dim rest_response As RestResponse = rest_client.Execute(request)
        If IsNothing(rest_response.ErrorException) Then
            Response = rest_response.Content
        Else
            Throw New System.Exception("SGP not responding")
        End If

    End Sub

End Class
