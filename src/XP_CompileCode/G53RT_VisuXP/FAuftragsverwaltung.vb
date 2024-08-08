Imports System
Imports System.IO
Imports System.Xml
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class FAuftragsverwaltung
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        farblaschen(0) = lblFarbe0
        farblaschen(1) = lblFarbe1
        farblaschen(2) = lblFarbe2
        farblaschen(3) = lblFarbe3
        farblaschen(4) = lblFarbe4

        Dim ypos As Integer = 400
        Dim _x As Integer = 50
        Dim _y As Integer = 50

        With farblaschen(0)
            .myx = 363
            .myy = ypos
            .Parent = Me
            .Bounds = New Rectangle(363, ypos, _x, _y)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                 farblaschen(0).Width, farblaschen(0).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                 farblaschen(0).Width, farblaschen(0).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(1)
            .myx = 459
            .myy = ypos
            .Parent = Me
            .Bounds = New Rectangle(459, ypos, _x, _y)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(1).Width, farblaschen(1).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(1).Width, farblaschen(1).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(2)
            .myx = 555
            .myy = ypos
            .Parent = Me
            .Bounds = New Rectangle(555, ypos, _x, _y)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(2).Width, farblaschen(2).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(2).Width, farblaschen(2).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(3)
            .myx = 651
            .myy = ypos
            .Parent = Me
            .Bounds = New Rectangle(651, ypos, _x, _y)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(3).Width, farblaschen(3).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(3).Width, farblaschen(3).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(4)
            .myx = 747
            .myy = ypos
            .Parent = Me
            .Bounds = New Rectangle(747, ypos, _x, _y)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(4).Width, farblaschen(4).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(4).Width, farblaschen(4).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With
        'Beliebige Initialisierung nach dem InitializeComponent()-Aufruf hinzufügen

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents tbPos01 As System.Windows.Forms.Button
    Friend WithEvents tbPos03 As System.Windows.Forms.Button
    Friend WithEvents tbPos05 As System.Windows.Forms.Button
    Friend WithEvents tbPos07 As System.Windows.Forms.Button
    Friend WithEvents tbPos09 As System.Windows.Forms.Button
    Friend WithEvents btnEsc As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbKlaenge00 As System.Windows.Forms.Button
    Friend WithEvents btnNeuerArtikel As System.Windows.Forms.Button
    Friend WithEvents lblAktArtikelnr As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents textboxBezeichnung As System.Windows.Forms.Button
    Friend WithEvents btnArtikelnrSpeichern As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tbPos01 = New System.Windows.Forms.Button
        Me.tbPos03 = New System.Windows.Forms.Button
        Me.tbPos05 = New System.Windows.Forms.Button
        Me.tbPos07 = New System.Windows.Forms.Button
        Me.tbPos09 = New System.Windows.Forms.Button
        Me.btnEsc = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbKlaenge00 = New System.Windows.Forms.Button
        Me.btnNeuerArtikel = New System.Windows.Forms.Button
        Me.lblAktArtikelnr = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.textboxBezeichnung = New System.Windows.Forms.Button
        Me.btnArtikelnrSpeichern = New System.Windows.Forms.Button
        '
        'tbPos01
        '
        Me.tbPos01.Location = New System.Drawing.Point(360, 369)
        Me.tbPos01.Size = New System.Drawing.Size(56, 20)
        Me.tbPos01.Text = "0"
        '
        'tbPos03
        '
        Me.tbPos03.Location = New System.Drawing.Point(456, 369)
        Me.tbPos03.Size = New System.Drawing.Size(56, 20)
        Me.tbPos03.Text = "0"
        '
        'tbPos05
        '
        Me.tbPos05.Location = New System.Drawing.Point(552, 369)
        Me.tbPos05.Size = New System.Drawing.Size(56, 20)
        Me.tbPos05.Text = "0"
        '
        'tbPos07
        '
        Me.tbPos07.Location = New System.Drawing.Point(648, 369)
        Me.tbPos07.Size = New System.Drawing.Size(56, 20)
        Me.tbPos07.Text = "0"
        '
        'tbPos09
        '
        Me.tbPos09.Location = New System.Drawing.Point(744, 369)
        Me.tbPos09.Size = New System.Drawing.Size(56, 20)
        Me.tbPos09.Text = "0"
        '
        'btnEsc
        '
        Me.btnEsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEsc.Location = New System.Drawing.Point(768, 8)
        Me.btnEsc.Size = New System.Drawing.Size(66, 52)
        Me.btnEsc.Text = "ESC"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(216, 342)
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.Text = "Glieder"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(360, 342)
        Me.Label3.Size = New System.Drawing.Size(53, 23)
        Me.Label3.Text = "Pos1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label4.Location = New System.Drawing.Point(456, 342)
        Me.Label4.Size = New System.Drawing.Size(53, 23)
        Me.Label4.Text = "Pos2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label5.Location = New System.Drawing.Point(552, 342)
        Me.Label5.Size = New System.Drawing.Size(53, 23)
        Me.Label5.Text = "Pos3"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label6.Location = New System.Drawing.Point(648, 342)
        Me.Label6.Size = New System.Drawing.Size(53, 23)
        Me.Label6.Text = "Pos4"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label7.Location = New System.Drawing.Point(744, 342)
        Me.Label7.Size = New System.Drawing.Size(53, 23)
        Me.Label7.Text = "Pos5"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(24, 342)
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.Text = "Artikelnummer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label8.Location = New System.Drawing.Point(355, 453)
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.Text = "Farbe1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label9.Location = New System.Drawing.Point(452, 453)
        Me.Label9.Size = New System.Drawing.Size(64, 23)
        Me.Label9.Text = "Farbe2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label10.Location = New System.Drawing.Point(548, 453)
        Me.Label10.Size = New System.Drawing.Size(64, 23)
        Me.Label10.Text = "Farbe3"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label11.Location = New System.Drawing.Point(644, 453)
        Me.Label11.Size = New System.Drawing.Size(64, 23)
        Me.Label11.Text = "Farbe4"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label12.Location = New System.Drawing.Point(740, 453)
        Me.Label12.Size = New System.Drawing.Size(64, 23)
        Me.Label12.Text = "Farbe5"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbKlaenge00
        '
        Me.tbKlaenge00.Location = New System.Drawing.Point(216, 369)
        Me.tbKlaenge00.Size = New System.Drawing.Size(70, 20)
        Me.tbKlaenge00.Text = "0"
        '
        'btnNeuerArtikel
        '
        Me.btnNeuerArtikel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnNeuerArtikel.Location = New System.Drawing.Point(63, 162)
        Me.btnNeuerArtikel.Size = New System.Drawing.Size(237, 57)
        Me.btnNeuerArtikel.Text = "Neue Artikelnummer anlegen"
        '
        'lblAktArtikelnr
        '
        Me.lblAktArtikelnr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAktArtikelnr.Location = New System.Drawing.Point(24, 369)
        Me.lblAktArtikelnr.Size = New System.Drawing.Size(147, 21)
        Me.lblAktArtikelnr.Text = "0"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label13.Location = New System.Drawing.Point(522, 147)
        Me.Label13.Size = New System.Drawing.Size(112, 23)
        Me.Label13.Text = "Bezeichnung"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label14.Location = New System.Drawing.Point(522, 87)
        Me.Label14.Size = New System.Drawing.Size(112, 23)
        Me.Label14.Text = "Artikelnummer"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(504, 114)
        Me.Label15.Size = New System.Drawing.Size(147, 21)
        Me.Label15.Text = "0"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'textboxBezeichnung
        '
        Me.textboxBezeichnung.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.textboxBezeichnung.Location = New System.Drawing.Point(468, 174)
        Me.textboxBezeichnung.Size = New System.Drawing.Size(228, 36)
        Me.textboxBezeichnung.Text = "G53RT"
        '
        'btnArtikelnrSpeichern
        '
        Me.btnArtikelnrSpeichern.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnArtikelnrSpeichern.Location = New System.Drawing.Point(63, 63)
        Me.btnArtikelnrSpeichern.Size = New System.Drawing.Size(237, 57)
        Me.btnArtikelnrSpeichern.Text = "Artikelnummer speichern"
        '
        'FAuftragsverwaltung
        '
        Me.ClientSize = New System.Drawing.Size(843, 482)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnArtikelnrSpeichern)
        Me.Controls.Add(Me.textboxBezeichnung)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblAktArtikelnr)
        Me.Controls.Add(Me.btnNeuerArtikel)
        Me.Controls.Add(Me.tbKlaenge00)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEsc)
        Me.Controls.Add(Me.tbPos09)
        Me.Controls.Add(Me.tbPos07)
        Me.Controls.Add(Me.tbPos05)
        Me.Controls.Add(Me.tbPos03)
        Me.Controls.Add(Me.tbPos01)
        Me.Location = New System.Drawing.Point(50, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Auftragsverwaltung"

    End Sub

#End Region

    Friend WithEvents lblFarbe0 As New PictureButton
    Friend WithEvents lblFarbe1 As New PictureButton
    Friend WithEvents lblFarbe2 As New PictureButton
    Friend WithEvents lblFarbe3 As New PictureButton
    Friend WithEvents lblFarbe4 As New PictureButton

    Public Shared farblaschen(4) As PictureButton


    ' Create a bitmap object and fill it with the specified color.   
    ' To make it look like a custom image, draw an ellipse in it.
    Function MakeBitmap(ByVal ButtonColor As Color, ByVal width As Integer, _
        ByVal height As Integer) As Bitmap

        Dim bmp As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.FillRectangle(New SolidBrush(ButtonColor), 0, 0, bmp.Width, bmp.Height)
        'g.DrawEllipse(New Pen(Color.LightGray), 3, 3, width - 6, height - 6)
        g.Dispose()
        Return bmp
    End Function

    Public passwortOK As Boolean = False
    Private Sub FAuftragsverwaltung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lese aktuellen kettentyp aus der SPS!
        leseTypdaten()

        For i As Integer = 0 To 4
            Select Case farblaschen(i).farbwert
                Case 0 : Me.farblaschen(i).BackgroundImageValue = MakeBitmap(Color.Gray, _
                    Me.farblaschen(i).Width, Me.farblaschen(i).Height)
                    Me.farblaschen(i).Refresh()
                Case 1 : Me.farblaschen(i).BackgroundImageValue = MakeBitmap(Color.Yellow, _
                    Me.farblaschen(i).Width, Me.farblaschen(i).Height)
                    Me.farblaschen(i).Refresh()
                Case 2 : Me.farblaschen(i).BackgroundImageValue = MakeBitmap(Color.OrangeRed, _
                    Me.farblaschen(i).Width, Me.farblaschen(i).Height)
                    Me.farblaschen(i).Refresh()
                Case 3 : Me.farblaschen(i).BackgroundImageValue = MakeBitmap(Color.Blue, _
                    Me.farblaschen(i).Width, Me.farblaschen(i).Height)
                    Me.farblaschen(i).Refresh()
                Case Else : MsgBox("Fehlerhafter farbwert aus der SPS!")
            End Select
        Next

        For j As Integer = 0 To 4
            AddHandler Me.farblaschen(j).Click, AddressOf Farbwahloeffnen
        Next
        Label15.Text = Me.lblAktArtikelnr.Text

    End Sub

    Public Sub leseTypdaten()
        'lese aktuellen kettentyp aus der SPS!
        Try
            Dim vHandleKettentyp As Integer
            Dim dataStream As New AdsStream(22)
            Dim binreader As New BinaryReader(dataStream)
            vHandleKettentyp = AppMgr.frm1.adsClient.CreateVariableHandle(".KettenTyp")
            AppMgr.frm1.adsClient.Read(vHandleKettentyp, dataStream)
            'da in der sps zuerst die farbe steht, ist hier der speicher ablauf zuerst farbe, dann farbposition.
            tbKlaenge00.Text = binreader.ReadInt16
            farblaschen(0).farbwert = binreader.ReadInt16
            tbPos01.Text = binreader.ReadInt16
            farblaschen(1).farbwert = binreader.ReadInt16
            tbPos03.Text = binreader.ReadInt16
            farblaschen(2).farbwert = binreader.ReadInt16
            tbPos05.Text = binreader.ReadInt16
            farblaschen(3).farbwert = binreader.ReadInt16
            tbPos07.Text = binreader.ReadInt16
            farblaschen(4).farbwert = binreader.ReadInt16
            tbPos09.Text = binreader.ReadInt16
            AppMgr.frm1.adsClient.DeleteVariableHandle(vHandleKettentyp)

            Dim varhandle1 As Integer   'lese bezeichnerstring aus der SPS
            Dim stringStream As New AdsStream(20)
            Dim reader As New AdsBinaryReader(stringStream)
            varhandle1 = AppMgr.frm1.adsClient.CreateVariableHandle(".ArtikelString")
            AppMgr.frm1.adsClient.Read(varhandle1, stringStream)
            textboxBezeichnung.Text = reader.ReadPlcString(20)
            AppMgr.frm1.adsClient.DeleteVariableHandle(varhandle1)
            varhandle1 = Nothing

            Dim artikelnoString As String = ""
            Dim vh As Integer 'lese artikelnummer aus der SPS
            vh = AppMgr.frm1.adsClient.CreateVariableHandle(".ArtikelNr")
            artikelnoString = AppMgr.frm1.adsClient.ReadAny(vh, GetType(UInt32)).ToString
            If artikelnoString = "0" Then
                artikelnoString = "00000000"
            End If
            If artikelnoString.Length < 8 Then
                artikelnoString = artikelnoString.PadLeft(8, "0")
            End If
            AppMgr.frm1.lblAktKettentyp.Text = textboxBezeichnung.Text
            AppMgr.frm1.btnArtikelnummer.Text = artikelnoString
            lblAktArtikelnr.Text = artikelnoString
            Label15.Text = artikelnoString
            AppMgr.frm1.lblGliederzahlMain.Text = tbKlaenge00.Text
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Farbwahloeffnen(ByVal sender As Object, ByVal e As EventArgs)
        Dim farbeingabe As New FFarbwahl(sender)
        farbeingabe.Show()
        farbeingabe.BringToFront()
        Me.Enabled() = False
    End Sub

    Private Sub btnEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsc.Click
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.DrawRectangle(New Pen(Color.Black), 5, 336, 910, 140)

        ' e.Graphics.FillRectangle(New SolidBrush(Color.Gray), lblPos1Farbe12.Location.X, lblPos1Farbe12.Location.Y + 100, lblPos1Farbe12.Width, lblPos1Farbe12.Height)
        'MyBase.OnPaint(e)
        MyBase.OnPaint(e)

    End Sub
    Public mykeyboard As FKeyboard = Nothing
    Private Sub textboxBezeichnung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textboxBezeichnung.Click
        mykeyboard = New FKeyboard(textboxBezeichnung)
        mykeyboard.Show()
        mykeyboard.BringToFront()
    End Sub

    Private Sub btnNeuerArtikel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNeuerArtikel.Click
        Dim artikeleingabe As New FPassw(6, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub tbKlaenge00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbKlaenge00.Click
        Dim artikeleingabe As New FPassw(3, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub tbPos01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPos01.Click
        Dim artikeleingabe As New FPassw(3, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub tbPos03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPos03.Click
        Dim artikeleingabe As New FPassw(3, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub tbPos05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPos05.Click
        Dim artikeleingabe As New FPassw(3, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub tbPos07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPos07.Click
        Dim artikeleingabe As New FPassw(3, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub tbPos09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPos09.Click
        Dim artikeleingabe As New FPassw(3, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub btnArtikelnrSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArtikelnrSpeichern.Click
        If (lblAktArtikelnr.Text.Length <> 8) Or (textboxBezeichnung.Text.Length = 0) Then
            MsgBox("Artikelnummer oder Kettenbezeichnung nicht korrekt")
        Else
            Dim schreibeArt As New CArtikelschreiber
            schreibeArt.legeNeuenArtikelAn(lblAktArtikelnr.Text, textboxBezeichnung.Text, tbKlaenge00.Text, _
                                           tbPos01.Text, Me.farblaschen(0).farbwert, _
                                           tbPos03.Text, Me.farblaschen(1).farbwert, _
                                           tbPos05.Text, Me.farblaschen(2).farbwert, _
                                           tbPos07.Text, Me.farblaschen(3).farbwert, _
                                           tbPos09.Text, Me.farblaschen(4).farbwert)
            schreibeArt = Nothing
            AppMgr.frm1.Enabled = True
            Me.Close()
        End If
    End Sub


End Class
