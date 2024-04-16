Public Class AstronomyClass

    Public Sub Sunset(ByVal LAT As Double, ByVal LON As Double, ByRef SSmin As Double, ByRef SSaz As Double)
        'Calculates Time (hrs since beginning of day in time tone) and Azimuth (deg) of sunset (SS) today
        Dim datenow As DateTime
        Dim date1stjanuary As DateTime
        Dim days, gamma, decl, ha, B, eot As Double
        Dim localZone As TimeZoneInfo = TimeZoneInfo.Local

        datenow = DateTime.Now
        date1stjanuary = New DateTime(DateTime.Now.Year, 1, 1)

        'days since 1st of January this year
        days = CType(DateDiff(DateInterval.Day, date1stjanuary, datenow) + 1, Double)

        'fractional year (rad)
        gamma = 2 * Math.PI / 365 * (days - 1)

        'declination of sun
        decl = Math.Asin(Math.Sin(-23.44 / 180 * Math.PI) * Math.Cos(2 * Math.PI / 365.24 * (days + 10) + 2 * 0.0167 * Math.Sin(2 * Math.PI / 365.24 * (days - 2))))

        'hour angle in degrees (90.8333 deg takes into account the approximate correction for
        'atmospheric refraction at sunrise And sunset, And the size of the solar disk)
        'Note that decl is already in rad
        ha = Math.Acos(Math.Cos(90.833 / 180 * Math.PI) / Math.Cos(LAT / 180 * Math.PI) / Math.Cos(decl) - Math.Tan(LAT / 180 * Math.PI) * Math.Tan(decl)) / Math.PI * 180

        'equation of time
        B = 2 * Math.PI / 365 * (days - 81)
        eot = 9.87 * Math.Sin(2 * B) - 7.53 * Math.Cos(B) - 1.5 * Math.Sin(B)

        'sunrise, sunset in minutes (UTC)
        SSmin = (720 + 4 * ha - 4 * LON - eot) / 60

        'add timezone shift for longitude
        SSmin = SSmin + localZone.BaseUtcOffset.Hours

        'check if Daylight Saving is used, then add 1 hour
        If TimeZone.CurrentTimeZone.IsDaylightSavingTime(datenow) Then
            SSmin = SSmin + 1
        End If

        'azimuth angle at sunset
        'Note that decl is already in rad
        SSaz = 360 - Math.Acos(Math.Sin(decl) * Math.Cos(LAT / 180 * Math.PI) - Math.Cos(decl) * Math.Sin(LAT / 180 * Math.PI) * Math.Cos(ha * Math.PI / 180)) / Math.PI * 180

    End Sub

    Public Sub EqPos_ToString(ByVal RA As Double, ByVal DEC As Double, ByRef RA_STR As String, ByRef DEC_STR As String)
        'Converts RA and DEC in degrees to 'HRS:MIN:SEC' (RA 24 hour based) 'DEG:AMIN:ASEC' (DEC 360 deg based) output strings RA_STR and DEC_STR

        Dim HRS, MINS, SECS As Double
        Dim DEG, AMINS, ASECS As Double
        Dim SIGN As String = ""

        HRS = RA / 360 * 24
        MINS = (HRS - Math.Floor(HRS)) * 60
        HRS = Math.Floor(HRS)
        SECS = Math.Round((MINS - Math.Floor(MINS)) * 60)
        MINS = Math.Floor(MINS)
        RA_STR = Integer.Parse(HRS).ToString("D2") + ":" + Integer.Parse(MINS).ToString("D2") + ":" + Integer.Parse(SECS).ToString("D2")

        If DEC < 0 Then
            SIGN = "-"
            DEC = Math.Abs(DEC)
        End If
        DEG = DEC
        AMINS = (DEG - Math.Floor(DEG)) * 60
        DEG = Math.Floor(DEG)
        ASECS = Math.Round((AMINS - Math.Floor(AMINS)) * 60)
        AMINS = Math.Floor(AMINS)
        DEC_STR = SIGN + Integer.Parse(DEG).ToString("D2") + ":" + Integer.Parse(AMINS).ToString("D2") + ":" + Integer.Parse(ASECS).ToString("D2")

    End Sub

    Public Sub AltAzPos_ToString(ByVal ALT As Double, ByVal AZ As Double, ByRef ALT_STR As String, ByRef AZ_STR As String)
        'Converts ALT and AZ in degrees to 'DEG:AMIN:ASEC' output strings ALT_STR and AZ_STR

        Dim DEG, AMINS, ASECS As Double
        Dim SIGN As String = ""

        If ALT < 0 Then
            SIGN = "-"
            ALT = Math.Abs(ALT)
        End If
        DEG = ALT
        AMINS = (DEG - Math.Floor(DEG)) * 60
        DEG = Math.Floor(DEG)
        ASECS = Math.Round((AMINS - Math.Floor(AMINS)) * 60)
        AMINS = Math.Floor(AMINS)
        ALT_STR = SIGN + Integer.Parse(DEG).ToString("D2") + ":" + Integer.Parse(AMINS).ToString("D2") + ":" + Integer.Parse(ASECS).ToString("D2")

        DEG = AZ
        AMINS = (DEG - Math.Floor(DEG)) * 60
        DEG = Math.Floor(DEG)
        ASECS = Math.Round((AMINS - Math.Floor(AMINS)) * 60)
        AMINS = Math.Floor(AMINS)
        AZ_STR = Integer.Parse(DEG).ToString("D2") + ":" + Integer.Parse(AMINS).ToString("D2") + ":" + Integer.Parse(ASECS).ToString("D2")

    End Sub

    Public Sub RADEC2AZALT(ByVal LMST As Double, ByVal RA As Double, ByVal DEC As Double, ByVal LAT As Double, ByRef AZ As Double, ByRef ALT As Double)
        'Converts RA and DEC to AZ and ALT (all in degrees), for observer LATiitude (degrees)
        'LMST is Local Mean Sidereal Time (degrees)
        'LMST should be a property of the ASCOM telescope driver, but which must be converted to form hours to degrees (Telescope.SiderealTime/24*360)
        'LMST can also be calculated by LMST = GMST(DT) + LON for the LONgitude (in degrees), where date DT must be in UTC time!! (use DT = DateTime.UtcNow for current time now)

        Dim HA, AZtemp As Double

        'Hour Angle (degrees)
        HA = LMST - RA

        'Altitude (degrees)
        ALT = Math.Asin(Math.Sin(DEC / 180 * Math.PI) * Math.Sin(LAT / 180 * Math.PI) + Math.Cos(DEC / 180 * Math.PI) * Math.Cos(LAT / 180 * Math.PI) * Math.Cos(HA / 180 * Math.PI)) / Math.PI * 180
        'Azimuth (degrees)
        AZtemp = Math.Acos((Math.Sin(DEC / 180 * Math.PI) - Math.Sin(ALT / 180 * Math.PI) * Math.Sin(LAT / 180 * Math.PI)) / (Math.Cos(ALT / 180 * Math.PI) * Math.Cos(LAT / 180 * Math.PI))) / Math.PI * 180

        If Math.Sin(HA / 180 * Math.PI) > 0 Then
            AZ = 360 - AZtemp
        Else
            AZ = AZtemp
        End If

    End Sub

    Public Sub AZALT2RADEC(ByVal LMST As Double, ByVal AZ As Double, ByVal ALT As Double, ByVal LAT As Double, ByRef RA As Double, ByRef DEC As Double)
        'Converts AZ and ALT to RA and DEC (all in degrees), for observer LATiitude and LONgitude (both in degrees)
        'LMST is Local Mean Sidereal Time (degrees)
        'LMST should be a property of the ASCOM telescope driver, but which must be converted to form hours to degrees (Telescope.SiderealTime/24*360)
        'LMST can also be calculated by LMST = GMST(DT) + LON for the LONgitude (in degrees), where date DT must be in UTC time!! (use DT = DateTime.UtcNow for current time now)

        Dim HA As Double

        'DEC (degrees)
        DEC = Math.Asin(Math.Sin(ALT / 180 * Math.PI) * Math.Sin(LAT / 180 * Math.PI) + Math.Cos(ALT / 180 * Math.PI) * Math.Cos(LAT / 180 * Math.PI) * Math.Cos(AZ / 180 * Math.PI)) / Math.PI * 180

        'Hour angle (degrees)
        HA = Math.Acos((Math.Sin(ALT / 180 * Math.PI) - Math.Sin(DEC / 180 * Math.PI) * Math.Sin(LAT / 180 * Math.PI)) / (Math.Cos(DEC / 180 * Math.PI) * Math.Cos(LAT / 180 * Math.PI))) / Math.PI * 180

        'RA (degrees)
        If AZ > 180 Then            'if approaching meridian
            RA = 360 + LMST - HA
            If RA > 360 Then
                RA = RA - 360
            End If
        Else                        'if moving away from meridian
            RA = LMST + HA
        End If
    End Sub

    Public Function GMST(DT As Date) As Double 'Greenwich Mean Sidereal Time in DEGREES for date "dt"
        Dim HRS, MINS, SECS As Integer
        Dim JD, TU, FunReturn As Double

        HRS = DT.Hour
        MINS = DT.Minute
        SECS = DT.Second

        'julian date 
        JD = JulianDate(DT)

        'universal time
        TU = (JD - 2451545.0) / 36525

        'Greenwich Mean Sidereal Time
        FunReturn = 24110.54841 + 8640184.812866 * TU + 0.093104 * TU ^ 2 - 0.0000062 * TU ^ 3
        FunReturn = FunReturn + HRS * 3600 + MINS * 60 + SECS

        'convert to degrees
        FunReturn = (FunReturn Mod 86400) / 86400 * 360

        Return FunReturn
    End Function

    Public Function JulianDate(DT As Date) As Double   'Julian date from date DT (use DT=DateTime.Now for current JD now)
        Dim A, B, C, E, F As Integer
        Dim Y, M, D As Integer
        Dim HRS, MINS, SECS As Integer
        Dim JD As Double

        Y = DT.Year
        M = DT.Month
        D = DT.Day

        HRS = DT.Hour
        MINS = DT.Minute
        SECS = DT.Second

        A = Math.Floor(Y / 100)
        B = Math.Floor(A / 4)
        C = 2 - A + B
        E = Math.Floor(365.25 * (Y + 4716))
        F = Math.Floor(30.6001 * (M + 1))

        JD = C + D + E + F - 1524   'integer julian day

        JD = JD + (HRS - 12) / 24 + MINS / 1440 + SECS / 86400  'add fraction of a day

        Return JD
    End Function

End Class

