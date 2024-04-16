Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.IO
Imports nom.tam.fits
Imports nom.tam.util

Public Class FITSImageClass

    Public Structure FITSImage
        Public Property Data As Integer()
        Public Property SizeX As Integer
        Public Property SizeY As Integer
        Public Property MaxADU As Integer
        Public Property MeanADU As Integer
        Public Property Scale As Double
        Public Property RA As Double
        Public Property DEC As Double
    End Structure

    Public Function LoadFitsFile(ByVal filename As String) As FITSImage
        Dim FITS_BZERO As Integer
        Dim FITS_NAXIS1 As Integer
        Dim FITS_NAXIS2 As Integer

        Dim hdu As BasicHDU
        Dim fits As New Fits(filename)

        Dim image As Integer()
        Dim loadedFitsImage As New FITSImage

        'get header information
        hdu = fits.ReadHDU()
        FITS_BZERO = hdu.Header.GetIntValue("BZERO")
        FITS_NAXIS1 = hdu.Header.GetIntValue("NAXIS1")
        FITS_NAXIS2 = hdu.Header.GetIntValue("NAXIS2")

        ReDim image(FITS_NAXIS1 * FITS_NAXIS2 - 1)      ''set image dimensions

        Dim obj As Object = hdu.Kernel
        Dim buffer As Short()
        Dim mm As Integer = 0
        Dim temp As Long = 0    'for calculating mean value, use long to avoid overflow
        For kk As Integer = 0 To FITS_NAXIS2 - 1
            buffer = DirectCast(obj(kk), Short())
            For ll As Integer = 0 To FITS_NAXIS1 - 1
                image(mm) = CType(buffer(ll), Integer) + FITS_BZERO
                temp = temp + image(mm)
                mm = mm + 1
            Next
        Next

        'create new fits image object
        loadedFitsImage.Data = image
        loadedFitsImage.MeanADU = CInt(temp / image.Length)
        loadedFitsImage.MaxADU = 2 ^ 16 - 1    'THIS WILL AT MOST WORK WITH 16 BIT IMAGES 
        loadedFitsImage.SizeX = FITS_NAXIS1
        loadedFitsImage.SizeY = FITS_NAXIS2
        loadedFitsImage.Scale = hdu.Header.GetDoubleValue("PIXSCALE")
        loadedFitsImage.RA = hdu.Header.GetDoubleValue("RA")
        loadedFitsImage.DEC = hdu.Header.GetDoubleValue("DEC")

        Return loadedFitsImage
    End Function

    Public Sub SaveFitsFile(ByVal fitsImage As FITSImage, ByVal fileName As String)
        Dim FITS_BZERO As Integer
        Dim FITS_DATELOC As String

        Dim fitsArray(fitsImage.SizeX * fitsImage.SizeY - 1) As Short

        'setting FITS keywords
        FITS_BZERO = 2 ^ 15 'by defintion as we will always store fits of 16 bit
        FITS_DATELOC = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        'convert from Integer to Short
        For m As Integer = 0 To fitsImage.Data.Length - 1
            fitsArray(m) = Convert.ToInt16(fitsImage.Data(m) - FITS_BZERO) 'THIS WILL AT MOST WORK WITH 16 BIT IMAGES 
        Next

        'Save to fits file 16 bit
        Dim fs As FileStream = File.Create(fileName, FileMode.Create)
        Dim bds As New BufferedDataStream(fs)
        Dim fits As New Fits()
        Dim hdu As BasicHDU

        hdu = FitsFactory.HDUFactory(ArrayFuncs.Curl(fitsArray, {fitsImage.SizeY, fitsImage.SizeX}))
        'add keywors not automatically defined
        hdu.AddValue("BZERO", FITS_BZERO, "offset for signed short")
        hdu.AddValue("PIXSCALE", fitsImage.Scale, "pixel scale (arcsec/pixel)")
        hdu.AddValue("DATE-LOC", FITS_DATELOC, "DATETIME of saved image")
        hdu.AddValue("RA", fitsImage.RA, "Object Right Ascension in degrees")
        hdu.AddValue("DEC", fitsImage.DEC, "Object Right Ascension in degrees")

        fits.AddHDU(hdu)
        fits.Write(bds)

        bds.Close()
        bds.Dispose()
        bds = Nothing
        fs.Close()
        fs.Dispose()
        fs = Nothing
    End Sub

    Public Function ImageZoom(ByVal imageArray As Integer(), ByVal imgWidth As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer) As Integer()
        Dim zoom_imageArray(W * H - 1) As Integer
        Dim m, mm As Integer

        m = 0
        For k As Integer = 0 To H - 1
            For j As Integer = 0 To W - 1
                mm = (Y + k) * imgWidth + X + j
                zoom_imageArray(m) = imageArray(mm)
                m = m + 1
            Next
        Next

        Return zoom_imageArray
    End Function
    Public Function StretchImage(ByVal imageArray As Integer(), ByVal maxcount As Integer, ByVal stretch_level As Integer) As Integer()
        Dim str_imageArray(imageArray.Length - 1) As Integer
        Dim a As Integer = 0
        Dim b As Integer = maxcount - 1
        Dim hist(maxcount - 1) As Integer
        Dim hmax As Integer
        Dim frac As Double
        Dim max_str_range As Double
        Dim k As Integer
        Dim gamma As Double

        'set fraction of the considered part of the histogram up to the level of 4 sigma (assuming roughly normal distribution): exp(-0.5*4^2)
        frac = Math.Exp(-0.5 * Math.Pow(4, 2))

        'stretch_level can take low, medium, And high values
        Select Case stretch_level
            Case 1
                gamma = 1
                max_str_range = 1
            Case 2
                gamma = 0.5
                max_str_range = 1
            Case 3
                gamma = 0.25
                max_str_range = 1
        End Select

        'make histogram (max possible value in hist is SizeX*SizeY)
        hist = Histogram(imageArray, maxcount)
        'make sure that first and last histogram values are not making trouble
        hist(0) = 0
        hist(hist.Length - 1) = 0
        'find max peak in histogram
        hmax = hist.Max()

        'find low cut at hmax*frac
        Dim lowcut As Integer = 1
        k = 0
        Do While hist(k) < hmax * frac
            lowcut = k
            k = k + 1
        Loop

        'find high cut at hmax*frac
        Dim highcut As Integer = 1
        k = hist.Length - 1
        Do While hist(k) < hmax * frac
            highcut = k
            k = k - 1
        Loop

        'STRETCH METHOD: FIRST LINEAR STRETCH UP TO max_str_range, THEN A NONLINEAR GAMMA STRETCH WITH gamma PARAMETER
        '0.95 value before round is to avoid having too large values with respect to maxcount
        For k = 0 To imageArray.Length - 1
            If imageArray(k) < lowcut Then
                str_imageArray(k) = 0
            ElseIf imageArray(k) > highcut Then
                str_imageArray(k) = maxcount
            Else
                'str_imageArray(k)  = Math.Round((imageArray(k) - lowcut) * maxcount / (highcut - lowcut)* max_str_range* 0.95) 'ONLY LINEAR STRETCH
                str_imageArray(k) = Math.Round(Math.Pow((imageArray(k) - lowcut) / (highcut - lowcut) * max_str_range, gamma) * maxcount * 0.95)
            End If
        Next

        Return str_imageArray
    End Function

    Public Function Histogram(ByVal array As Integer(), ByVal maxvalue As Integer) As Integer()
        Dim hist(maxvalue - 1) As Integer
        Dim pixel_value As Integer

        For k As Integer = 0 To array.Length - 1
            pixel_value = array(k)

            'SAVEGUARD AGAINST MAXCOUNT NOT CORRECT
            If pixel_value < maxvalue - 1 Then
                hist(pixel_value) = hist(pixel_value) + 1
            End If
        Next

        Return hist
    End Function

    Public Function Convert2dArrayToBitmap(ByVal imageArray As Integer(), ByVal imgWidth As Integer, ByVal imgHeight As Integer, ByVal maxcount As Integer, ByVal ColorScheme As String) As Bitmap
        'this code is taken from some forum
        'very similar code is found on MSDN pages

        Dim tempNumber As UShort
        Dim imageBytes(imageArray.Length - 1) As Byte
        Dim b As New Bitmap(imgWidth, imgHeight, PixelFormat.Format8bppIndexed)
        Dim ncp As ColorPalette = b.Palette
        Dim i As Integer

        'convert to 8 bit image, store as byte in "imageBytes"
        For ctr As Integer = 0 To imageArray.Length - 1
            tempNumber = imageArray(ctr) / maxcount * 255
            tempNumber = Math.Round(tempNumber)

            'make sure there will be no overflow error
            If tempNumber < 0 Then
                imageBytes(ctr) = Convert.ToByte(0)
            ElseIf tempNumber > 255 Then
                imageBytes(ctr) = Convert.ToByte(255)
            Else
                imageBytes(ctr) = Convert.ToByte(tempNumber)
            End If
        Next

        ' Define a greyscale colour palette
        For i = 0 To 255
            Select Case ColorScheme
                Case "gray"
                    ncp.Entries(i) = Color.FromArgb(255, i, i, i)
                Case "hsv"
                    'Dim rgbdata = HSVColorClass.HSVToRGB(New HSVColorClass.HSV((255 - i) / 255 * 240, 1, 1))
                    Dim rgbdata = HSVColorClass.HSVToRGB(New HSVColorClass.HSV(i / 255 * 360, 1, 1))
                    ncp.Entries(i) = Color.FromArgb(255, rgbdata.R, rgbdata.G, rgbdata.B)
            End Select
        Next
        b.Palette = ncp

        ' Copy the bytes to the bitmap's data region
        Dim BoundsRect As New Rectangle(0, 0, imgWidth, imgHeight)
        Dim bmpData As BitmapData = b.LockBits(BoundsRect, ImageLockMode.WriteOnly, b.PixelFormat)

        ' *** Attention  Bitmap specification requires, to pad row size to a multiple of 4 Bytes 
        ' *** See:        https : //upload.wikimedia.org/wikipedia/commons/c/c4/BMPfileFormat.png
        ' *** Solution:  buffer2() And pay attention to padding (!!) at the end of each row
        Dim imageBytes2(imgHeight * bmpData.Stride - 1) As Byte
        For y As Integer = 0 To imgHeight - 2
            Buffer.BlockCopy(imageBytes, y * imgWidth, imageBytes2, y * bmpData.Stride, imgWidth * 2)
        Next

        'COPY
        Marshal.Copy(imageBytes2, 0, bmpData.Scan0, imageBytes2.Length)
        b.UnlockBits(bmpData)

        Return b

    End Function

End Class
