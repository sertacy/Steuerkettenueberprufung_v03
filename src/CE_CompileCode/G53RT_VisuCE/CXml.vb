Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlDocument
'Imports TwinCAT.Ads
'Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung


Public Class CXml
    Public strpath As String = ""

    'kettentypen variablen:
    Public kettentypenstr(4, 11) As String 'alle werte aus der kettentypen.xml


    Public Sub New(Optional ByVal dateipfad As String = "default")
        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then
            strpath = strpath.Substring(6)
        End If

        For i As Integer = 0 To 4
            For j As Integer = 0 To 11
                kettentypenstr(i, j) = "0"
            Next
        Next

        If dateipfad = "/kokev.xml" Then
            If File.Exists(strpath & dateipfad) Then
                Me.loadXmlKokevValues(strpath & dateipfad)
                MsgBox("Kokev.XML erfolgreich geladen!", MsgBoxStyle.OKOnly)
                
            Else
                Me.neueXmlKokevDateiAnlegen()
            End If
        End If

        If dateipfad = "/kettentypen.xml" Then
            If File.Exists(strpath & dateipfad) Then
                Me.loadXmlKettenTypValues(strpath & dateipfad)
                MsgBox("kettentypen.XML wurde erfolgreich geladen!",MsgBoxStyle.OKOnly)
                
            Else
                Me.neueXmlKettenTypDateiAnlegen(strpath & dateipfad)
            End If
        End If

    End Sub

    Private Sub loadXmlKokevValues(ByRef pfad As String)

    End Sub

    Private Sub neueXmlKokevDateiAnlegen()

    End Sub

    Private Sub loadXmlKettenTypValues(ByRef pfad As String)
        Dim gecheckt As Integer = 0
        Dim xml As New Xml.XmlDocument
        xml.Load(pfad)
        'kettentypenstr(4, 11) daten werden in dieses public arr gespeichert.
        'lade daten von typ0 bis typ4
        For n As Integer = 0 To 4
            For m As Integer = 0 To 11
                kettentypenstr(n, m) = xml.ChildNodes(1).ChildNodes(n).ChildNodes(m).InnerText
                If kettentypenstr(n, 0) = "1" Then
                    gecheckt = n  'um gecheckten typen zu erkennen.
                End If
                'MsgBox(kettentypenstr(n, m))
            Next
        Next
        'kettengliederzahl in das lbl auf der mainform schreiben.
        AppMgr.frm1.lblGliederzahlMain.Text = kettentypenstr(gecheckt, 1)
    End Sub

    Public Sub neueXmlKettenTypDateiAnlegen(ByRef pfad As String)
        Dim xml As New Xml.XmlDocument
        Dim xmlKD As Xml.XmlElement
        Dim xmlUnterKD0 As Xml.XmlElement
        Dim xmlUnterKD1 As Xml.XmlElement
        Dim xmlUnterKD2 As Xml.XmlElement
        Dim xmlUnterKD3 As Xml.XmlElement
        Dim xmlUnterKD4 As Xml.XmlElement
        Dim xmlUnterKD5 As Xml.XmlElement
        Dim xmlUnterKD6 As Xml.XmlElement
        Dim xmlUnterKD7 As Xml.XmlElement
        Dim xmlUnterKD8 As Xml.XmlElement
        Dim xmlUnterKD9 As Xml.XmlElement
        Dim xmlUnterKD10 As Xml.XmlElement
        Dim xmlUnterKD11 As Xml.XmlElement
        Dim xmlText As Xml.XmlText
        xml.LoadXml("<?xml version='1.0'?><kettentypen/>")

        For i As Integer = 0 To 4 Step 1
            xmlKD = xml.CreateElement("typ" & i.ToString)
            xmlUnterKD0 = xml.CreateElement("typaktiv")
            xmlUnterKD1 = xml.CreateElement("klaenge")
            xmlUnterKD2 = xml.CreateElement("pos1")
            xmlUnterKD3 = xml.CreateElement("pos1farbe")
            xmlUnterKD4 = xml.CreateElement("pos2")
            xmlUnterKD5 = xml.CreateElement("pos2farbe")
            xmlUnterKD6 = xml.CreateElement("pos3")
            xmlUnterKD7 = xml.CreateElement("pos3farbe")
            xmlUnterKD8 = xml.CreateElement("pos4")
            xmlUnterKD9 = xml.CreateElement("pos4farbe")
            xmlUnterKD10 = xml.CreateElement("pos5")
            xmlUnterKD11 = xml.CreateElement("pos5farbe")

            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 0))
            xmlUnterKD0.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 1))
            xmlUnterKD1.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 2))
            xmlUnterKD2.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 3))
            xmlUnterKD3.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 4))
            xmlUnterKD4.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 5))
            xmlUnterKD5.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 6))
            xmlUnterKD6.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 7))
            xmlUnterKD7.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 8))
            xmlUnterKD8.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 9))
            xmlUnterKD9.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 10))
            xmlUnterKD10.AppendChild(xmlText)
            xmlText = xml.CreateTextNode(Me.kettentypenstr(i, 11))
            xmlUnterKD11.AppendChild(xmlText)

            xmlKD.AppendChild(xmlUnterKD0)
            xmlKD.AppendChild(xmlUnterKD1)
            xmlKD.AppendChild(xmlUnterKD2)
            xmlKD.AppendChild(xmlUnterKD3)
            xmlKD.AppendChild(xmlUnterKD4)
            xmlKD.AppendChild(xmlUnterKD5)
            xmlKD.AppendChild(xmlUnterKD6)
            xmlKD.AppendChild(xmlUnterKD7)
            xmlKD.AppendChild(xmlUnterKD8)
            xmlKD.AppendChild(xmlUnterKD9)
            xmlKD.AppendChild(xmlUnterKD10)
            xmlKD.AppendChild(xmlUnterKD11)
            xml.DocumentElement.AppendChild(xmlKD)
        Next

        xml.Save(pfad)
        loadXmlKettenTypValues(pfad)  'nach dem erstellen der daten, ins vb laden!
        Dim mydialog As New FDialog
        mydialog.lblmeldung.Text = "kettentypen.xml wurde gespeichert und übertragen!"
        mydialog.lblmeldung.ForeColor = Color.Green
        mydialog.Show()
        mydialog.BringToFront()

        'MsgBox("kettentypen.xml wurde gespeichert und geladen!")

    End Sub
End Class
