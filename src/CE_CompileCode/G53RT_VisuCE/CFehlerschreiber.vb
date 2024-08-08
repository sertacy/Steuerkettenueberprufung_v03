Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class CFehlerschreiber

    Public dateipfad As String = "/Kettenfehler.txt"
    Private strpath As String = ""
    Private datumstr As String = ""
    Private zeitstr As String = ""
    Private werteanhaengen As Boolean = True


    Public Sub New(ByVal fehlerstring As String)

        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then  'hier nur überprüfung zum compilieren auf laptop.
            strpath = strpath.Substring(6)
        End If
        datumstr = DateTime.Today  'Datum anzeigen
        zeitstr = DateTime.Now.ToLongTimeString  'Uhrzeit anzeigen

        Dim finfo As New FileInfo(strpath & dateipfad)
        Dim filelaenge As Long = 0
        filelaenge = finfo.Length

        If (filelaenge > 102400) Then
            werteanhaengen = False
        Else
            werteanhaengen = True
        End If
        filelaenge = Nothing
        finfo = Nothing
        Dim sw As StreamWriter
        sw = New StreamWriter(strpath & dateipfad, werteanhaengen) 'mit true werden daten angehaengt
        sw.WriteLine(datumstr & "-" & zeitstr & "-" & fehlerstring)
        sw.Close()
        sw = Nothing

    End Sub
End Class
