Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung



Public Class CArtikelschreiber
    Private ordnername As String = "/AV"
    Private strpath As String = ""
    Private werteanhaengen As Boolean = True

    Public Sub New()
        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then  'hier nur überprüfung zum compilieren auf laptop.
            strpath = strpath.Substring(6)
        End If
        strpath = strpath & ordnername
        If (Directory.Exists(strpath)) = False Then
            Directory.CreateDirectory(strpath)
        End If
    End Sub

    Public Sub legeNeuenArtikelAn(ByVal dateiname As String, ByVal bezeichnung As String, ByVal glieder As String, _
                                    ByVal pos1 As String, ByVal farbe1 As Integer, _
                                    ByVal pos2 As String, ByVal farbe2 As Integer, _
                                    ByVal pos3 As String, ByVal farbe3 As Integer, _
                                    ByVal pos4 As String, ByVal farbe4 As Integer, _
                                    ByVal pos5 As String, ByVal farbe5 As Integer)
        Dim sw As StreamWriter
        sw = New StreamWriter(strpath & "/" & dateiname & ".art", False) 'mit true werden daten angehaengt
        sw.WriteLine(bezeichnung)
        sw.WriteLine(glieder)
        sw.WriteLine(pos1)
        sw.WriteLine(farbe1.ToString)
        sw.WriteLine(pos2)
        sw.WriteLine(farbe2.ToString)
        sw.WriteLine(pos3)
        sw.WriteLine(farbe3.ToString)
        sw.WriteLine(pos4)
        sw.WriteLine(farbe4.ToString)
        sw.WriteLine(pos5)
        sw.WriteLine(farbe5.ToString)
        sw.Close()
        sw = Nothing
    End Sub
End Class
