Imports System
Imports System.String
Imports System.IO
Imports System.Xml
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class FPassw
    Inherits System.Windows.Forms.Form


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btnDEL As System.Windows.Forms.Button
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblpasslength As System.Windows.Forms.Label
    Friend WithEvents lblpassshort As System.Windows.Forms.Label
    Friend WithEvents tbpassw As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblpasslength = New System.Windows.Forms.Label
        Me.lblpassshort = New System.Windows.Forms.Label
        Me.btn0 = New System.Windows.Forms.Button
        Me.btn1 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btnDEL = New System.Windows.Forms.Button
        Me.btnSign = New System.Windows.Forms.Button
        Me.btnESC = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.tbpassw = New System.Windows.Forms.Label
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblpasslength)
        Me.Panel1.Controls.Add(Me.lblpassshort)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Size = New System.Drawing.Size(315, 40)
        '
        'lblpasslength
        '
        Me.lblpasslength.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblpasslength.Location = New System.Drawing.Point(88, 10)
        Me.lblpasslength.Size = New System.Drawing.Size(216, 22)
        Me.lblpasslength.Text = "MAX : 9999"
        Me.lblpasslength.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblpassshort
        '
        Me.lblpassshort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblpassshort.Location = New System.Drawing.Point(12, 10)
        Me.lblpassshort.Size = New System.Drawing.Size(64, 22)
        Me.lblpassshort.Text = "MIN : 0"
        '
        'btn0
        '
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn0.Location = New System.Drawing.Point(8, 280)
        Me.btn0.Size = New System.Drawing.Size(155, 60)
        Me.btn0.Text = "0"
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn1.Location = New System.Drawing.Point(8, 216)
        Me.btn1.Size = New System.Drawing.Size(75, 60)
        Me.btn1.Text = "1"
        '
        'btn2
        '
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn2.Location = New System.Drawing.Point(88, 216)
        Me.btn2.Size = New System.Drawing.Size(75, 60)
        Me.btn2.Text = "2"
        '
        'btn3
        '
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn3.Location = New System.Drawing.Point(168, 216)
        Me.btn3.Size = New System.Drawing.Size(75, 60)
        Me.btn3.Text = "3"
        '
        'btn4
        '
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn4.Location = New System.Drawing.Point(8, 152)
        Me.btn4.Size = New System.Drawing.Size(75, 60)
        Me.btn4.Text = "4"
        '
        'btn5
        '
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn5.Location = New System.Drawing.Point(88, 152)
        Me.btn5.Size = New System.Drawing.Size(75, 60)
        Me.btn5.Text = "5"
        '
        'btn6
        '
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn6.Location = New System.Drawing.Point(168, 152)
        Me.btn6.Size = New System.Drawing.Size(75, 60)
        Me.btn6.Text = "6"
        '
        'btn7
        '
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn7.Location = New System.Drawing.Point(8, 88)
        Me.btn7.Size = New System.Drawing.Size(75, 60)
        Me.btn7.Text = "7"
        '
        'btn8
        '
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn8.Location = New System.Drawing.Point(88, 88)
        Me.btn8.Size = New System.Drawing.Size(75, 60)
        Me.btn8.Text = "8"
        '
        'btn9
        '
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btn9.Location = New System.Drawing.Point(168, 88)
        Me.btn9.Size = New System.Drawing.Size(75, 60)
        Me.btn9.Text = "9"
        '
        'btnDEL
        '
        Me.btnDEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btnDEL.Location = New System.Drawing.Point(248, 88)
        Me.btnDEL.Size = New System.Drawing.Size(75, 60)
        Me.btnDEL.Text = "DEL"
        '
        'btnSign
        '
        Me.btnSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btnSign.Location = New System.Drawing.Point(248, 152)
        Me.btnSign.Size = New System.Drawing.Size(75, 60)
        Me.btnSign.Text = "+/-"
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btnESC.Location = New System.Drawing.Point(248, 216)
        Me.btnESC.Size = New System.Drawing.Size(75, 60)
        Me.btnESC.Text = "ESC"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.btnOK.Location = New System.Drawing.Point(248, 280)
        Me.btnOK.Size = New System.Drawing.Size(75, 60)
        Me.btnOK.Text = "OK"
        '
        'tbpassw
        '
        Me.tbpassw.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular)
        Me.tbpassw.ForeColor = System.Drawing.Color.Blue
        Me.tbpassw.Location = New System.Drawing.Point(44, 56)
        Me.tbpassw.Size = New System.Drawing.Size(244, 24)
        Me.tbpassw.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FPassw
        '
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(332, 349)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbpassw)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.btnDEL)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(340, 190)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Passwort eingabe"

    End Sub

#End Region
    Public Sub New(ByVal passmodus As Integer, Optional ByVal sender As Object = Nothing)
        MyBase.New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        mysender = sender
        pmodus = passmodus 'weitergabe der modus nummer um später eigenschaften festzulegen....

        Select Case passmodus
            Case 1 : Me.UserID()
            Case 2 : Me.PasswortModus("Bitte Passwort eingeben!")
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = False
            Case 3 : Me.KettentypeModus()
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = False
            Case 4 : Me.StationPasswort()
                umgebung.AppMgr.frm1.station.Enabled() = False
            Case 5 : Me.PasswortModus("Bitte Passwort eingeben!")
                umgebung.AppMgr.frm1.myKettenfehler.Enabled() = False
            Case 6 : Me.ArtikelModus()
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = False
            Case 7 : Me.PasswortModus("Bitte Passwort eingeben!")
                umgebung.AppMgr.frm1.mydialog.Enabled() = False
            Case 8 : Me.PasswortModus("Ausschussbehälter Passwort eingeben!")
                umgebung.AppMgr.frm1.Enabled() = False
            Case Else
                Me.Text = "???????????"
        End Select


    End Sub
    Public mysender As Object
    Public passwort As String
    Public sternchenpasswort As String
    Public pmodus As Integer
    Public sternchen As Boolean = False

    Private Sub UserID()
        Me.Text = "Bitte UserID eingeben!"
    End Sub
    Private Sub PasswortModus(ByVal str As String)
        Me.Text = str
        sternchen = True
    End Sub
    Private Sub StationPasswort()
        Me.Text = "Bitte Passwort eingeben!"
        sternchen = True
    End Sub
    Private Sub KettentypeModus()
        Me.Text = "Gliedernzahl eingeben!"
    End Sub
    Private Sub ArtikelModus()
        Me.Text = "Neue Artikelnummer eingeben!"
        lblpasslength.Text = "MAX :99999999"
    End Sub

    Private Sub FPassw_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        passwort = ""
        sternchenpasswort = ""
    End Sub

    Private Function uberpruefelaenge() As Boolean
        If sternchen = True Then
            tbpassw.Text = sternchenpasswort
        Else
            tbpassw.Text = passwort
        End If
        Dim i As Integer = 0
        Dim j As Integer = 0

        If pmodus = 6 Then   'fuer Artikelnummer eingabe!
            If passwort.Length <> 8 Then
                lblpasslength.ForeColor = Color.Red
                lblpasslength.Text = "!Bitte genau 8 Ziffern!"
                i = 1
            Else
                lblpasslength.ForeColor = Color.Black
                lblpasslength.Text = "MAX :99999999"
                i = 0
            End If
            If passwort.StartsWith("-") Then
                lblpassshort.ForeColor = Color.Red
                j = 1
            Else
                lblpassshort.ForeColor = Color.Black
                j = 0
            End If

            If ((j = 1) Or (i = 1)) Then
                Return False
            Else
                Return True
            End If
        Else    'fuer genau 4 zeichen laenge bei gliedern oder passwort!
            If passwort.Length > 4 Then
                lblpasslength.ForeColor = Color.Red
                lblpasslength.Text = "!maximal 4 Ziffern!"
                i = 1
            Else
                lblpasslength.ForeColor = Color.Black
                lblpasslength.Text = "MAX : 9999"
                i = 0
            End If
            If passwort.StartsWith("-") Then
                lblpassshort.ForeColor = Color.Red
                j = 1
            Else
                lblpassshort.ForeColor = Color.Black
                j = 0
            End If
            If ((j = 1) Or (i = 1) Or (passwort.Length = 0)) Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        passwort = passwort & "0"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()

    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        passwort = passwort & "1"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        passwort = passwort & "2"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        passwort = passwort & "3"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        passwort = passwort & "4"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        passwort = passwort & "5"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        passwort = passwort & "6"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        passwort = passwort & "7"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        passwort = passwort & "8"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn9.Click
        passwort = passwort & "9"
        sternchenpasswort = sternchenpasswort & "*"
        uberpruefelaenge()
    End Sub

    Private Sub btnDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDEL.Click
        Dim i As Integer = passwort.Length()
        If i > 0 Then
            passwort = passwort.Remove(i - 1, 1)   'letztes zeichen wird gelöscht!
            sternchenpasswort = sternchenpasswort.Remove(i - 1, 1)
        End If
        uberpruefelaenge()
    End Sub

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        If Not passwort.StartsWith("-") Then   'wenn passwort nicht mit "-" startet,
            passwort = passwort.Insert(0, "-")  'dann stelle "-" vorne an.
            sternchenpasswort = sternchenpasswort.Insert(0, "*")
        Else
            passwort = passwort.Replace("-", "") 'sonst entferne "-" am anfang des strings(bei wiederholtem drücken zum umschalten!)
            sternchenpasswort = sternchenpasswort.Remove(0, 1)
        End If
        uberpruefelaenge()
    End Sub


    Public Sub CheckeUserName()
        ' hier ist ein fehler, es gibt einfehler bie zugriff auf erste dim, nuller index, mit object nicht inzanziiert!!!
        'MsgBox(frm1.userdaten.DatenArrayWerte(1, 0))
        'Debug.WriteLine(frm1.userdaten.DatenArrayWerte(1, 1))
    End Sub

    Public Function checkepassword()
        If ((uberpruefelaenge() = True) And (passwort = "4711")) Then
            If pmodus = 2 Then
                umgebung.AppMgr.frm1.auftragsverw.passwortOK = True
            End If
            If pmodus = 5 Then
                umgebung.AppMgr.frm1.myKettenfehler.passwortOK = True
                umgebung.AppMgr.frm1.myKettenfehler.nullen()
                umgebung.AppMgr.frm1.myKettenfehler.einlesen()
            End If
            If pmodus = 7 Then
                umgebung.AppMgr.frm1.dummyquittieren()
            End If
            If pmodus = 8 Then
                umgebung.AppMgr.frm1.behaelteroeffnen()
            End If
            'Dim mydialog As New FDialog
            'mydialog.lblmeldung.Text = "Passwort OK!"
            'mydialog.lblmeldung.ForeColor = Color.DarkGreen
            'mydialog.BringToFront()
            'mydialog.Show()
        Else
            If pmodus = 2 Then
                umgebung.AppMgr.frm1.auftragsverw.passwortOK = False
            End If
            If pmodus = 5 Then
                umgebung.AppMgr.frm1.myKettenfehler.passwortOK = False
            End If
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Passwort falsch!"
            mydialog.lblmeldung.ForeColor = Color.Red
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Function

    Public Function checkeStationpassword()
        If ((uberpruefelaenge() = True) And (passwort = "4711")) Then
            umgebung.AppMgr.frm1.station.passwortOK = True
            'Dim mydialog As New FDialog
            'mydialog.lblmeldung.Text = "Passwort OK!"
            'mydialog.lblmeldung.ForeColor = Color.DarkGreen
            'mydialog.BringToFront()
            'mydialog.Show()
        Else
            umgebung.AppMgr.frm1.station.passwortOK = False
            umgebung.AppMgr.frm1.station.Enabled = True
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Passwort falsch!"
            mydialog.lblmeldung.ForeColor = Color.Red
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Function

    Public Function checkeeingabe() As String
        If ((uberpruefelaenge() = True)) Then
            If AppMgr.frm1.auftragsverw.tbKlaenge00 Is Me.mysender Then
                AppMgr.frm1.auftragsverw.tbKlaenge00.Text = passwort
            ElseIf AppMgr.frm1.auftragsverw.tbPos01 Is Me.mysender Then
                AppMgr.frm1.auftragsverw.tbPos01.Text = passwort
            ElseIf AppMgr.frm1.auftragsverw.tbPos03 Is Me.mysender Then
                AppMgr.frm1.auftragsverw.tbPos03.Text = passwort
            ElseIf AppMgr.frm1.auftragsverw.tbPos05 Is Me.mysender Then
                AppMgr.frm1.auftragsverw.tbPos05.Text = passwort
            ElseIf AppMgr.frm1.auftragsverw.tbPos07 Is Me.mysender Then
                AppMgr.frm1.auftragsverw.tbPos07.Text = passwort
            ElseIf AppMgr.frm1.auftragsverw.tbPos09 Is Me.mysender Then
                AppMgr.frm1.auftragsverw.tbPos09.Text = passwort
            ElseIf AppMgr.frm1.auftragsverw.btnNeuerArtikel Is Me.mysender Then
                AppMgr.frm1.auftragsverw.lblAktArtikelnr.Text = passwort
                AppMgr.frm1.auftragsverw.Label15.Text = passwort
            End If
        End If
    End Function

    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        Select Case pmodus
            Case 1 : umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
                'frm1.grafikfenster.Enabled = True
            Case 2 : umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 3 : umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 4 : umgebung.AppMgr.frm1.station.Enabled() = True
            Case 5 : umgebung.AppMgr.frm1.myKettenfehler.Enabled() = True
            Case 6 : umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 7 : umgebung.AppMgr.frm1.mydialog.Enabled() = True
            Case 8 : umgebung.AppMgr.frm1.Enabled = True
        End Select

        Me.Close()
    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'fehlt noch die überprüfung ob user vorhanden und die eingabe ins hauptfenster.

        Select Case pmodus
            Case 1 : CheckeUserName()
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 2 : checkepassword()
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 3 : checkeeingabe()
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 4 : checkeStationpassword()
                umgebung.AppMgr.frm1.station.Enabled() = True
            Case 5 : checkepassword()
                umgebung.AppMgr.frm1.myKettenfehler.Enabled() = True
            Case 6 : checkeeingabe()
                umgebung.AppMgr.frm1.auftragsverw.Enabled() = True
            Case 7 : checkepassword()
                'umgebung.AppMgr.frm1.mydialog.Enabled() = True  da mydialog bei dummyquit gleich geschlossen wird, gibt das hier ein object disposed fehler!
            Case 8 : checkepassword()
                umgebung.AppMgr.frm1.Enabled = True
        End Select

        Me.Close()

    End Sub
End Class
