Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung


Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem

    'picturebuttons f�r Stationen 1 bis 4!
    Friend WithEvents btnStation1Farbe As New PictureButton
    Friend WithEvents btnStation2Laser As New PictureButton
    Friend WithEvents btnStation3Hoehe As New PictureButton
    Friend WithEvents btnStation4Kamera As New PictureButton
    Friend WithEvents btnAusschuss As New PictureButton


    'variablen aus der SPS:**************  short hat 2 byte
    Public myNot_Aus As Boolean
    Public myV_Autogestoppt As Boolean
    Public myV_Autogestartet As Boolean
    Public myH_Hand As Boolean
    Public myREF_IO As Boolean
    Public myREF_Enable As Boolean
    Public myStoerunganlage As Short            ' (8byte)
    Public myStoerunganlage_arr(15) As Boolean  'Dient zum erzeugen des boolean arrays aus bit folge word...
    Public myKS1_EnInput As Boolean
    Public myKS1_EnOutput As Boolean
    Public myKS2_EnInput As Boolean
    Public myKS2_EnOutput As Boolean
    Public myFehlerspeicher1 As Short            '(14byte)
    Public myFehlerspeicher1_arr(15) As Boolean  'Dient zum erzeugen des boolean arrays aus bit folge word...
    Public myKontrolle_Aktiv As Short            '(16byte)
    Public myKontrolle_Aktiv_arr(15) As Boolean  'Dient zum erzeugen des boolean arrays aus bit folge word...
    Public myS0_Automatik As Boolean = False
    Public myS1_Rueck_1 As Boolean = False
    Public myS2_Vor_1 As Boolean = False
    Public myS3_Rueck_2 As Boolean = False
    Public myS4_Trennen_1 As Boolean = False
    Public myS5_Rueck_3 As Boolean = False
    Public myS6_Trennen_2 As Boolean = False     '(23byte)
    Public myZeiger_Fehler_S1 As Short  'Fehlerglied position der Kette f�r s1 bis s4
    Public myZeiger_Fehler_S2 As Short
    Public myZeiger_Fehler_S3 As Short
    Public myZeiger_Fehler_S4 As Short          '(31byte)
    Public myFZ_Farbe As Short          'Anzahl der Fehler f�r jede Stoerung
    Public myFZ_Bolzenhoehe As Short
    Public myFZ_Laschenabst_1 As Short
    Public myFZ_Laschenabstand_2 As Short
    Public myFZ_Rolle_F As Short
    Public myFZ_Lasche_F As Short               '(43byte)
    Public myFZ_Gesammt As Short        'Anzahl gesammtfehler
    Public myIOZ_Kette As Short         'Anzahl IO ketten
    Public myFlaechenSp1_IO As Boolean  'Flachensp 1 strang bereit...(vorspeicher)
    Public myFlaechenSp2_IO As Boolean  'Flachensp 2 strang bereit...(vorspeicher) (51byte)
    Public myFehlerspeicher2 As Short            'fehlerspeicher der kamera fuer station4 (53byte)
    Public myFehlerspeicher2_arr(15) As Boolean  'Dient zum erzeugen des boolean arrays aus bit folge word...
    Public myFZ_Rolle_F_R As Short
    Public myFZ_Lasche_F_ALU As Short
    Public myFZ_Lasche_F_ILU As Short
    Public myFZ_Lasche_F_ILO As Short   '(61byte)
    Public myDummy_NIO As Boolean = False
    Public myTP_Dummy_Quitt As Boolean = False
    Public myH_KettenAnfang As Boolean = False
    Public myWLaser As Boolean = False  '(65byte)
    Public myFZ_PseudoF As Short
    Public myTP_Klappe As Boolean = False '(68byte)
    Public myST_Behvoll As Boolean = False    'ausschuss behaelter voll?
    Public myST_Behfehlt As Boolean = False   'ausschuss behaelter fehlt?
    Public myZ_Beh As Short '(72 byte)        'ausschuss zaehler
    Public myST_AusschussKetteRaus As Boolean = False '(73 byte)
    Public myDummy As Boolean ' (74 byte)
    Public myST_AnfDummyPruefung As Boolean ' (75 byte)

    'ende variablen aus der SPS**********

    'hier jeweils byte erweitern!
    Public stranytype(76) As String
    '****************************
    'Grafikbalken f�r Speicher 1 und 2
    'Public sp1G As Graphics
    'Public sp2G As Graphics
    '*******************************
    
    Public twincataktif As Boolean
    Public strvalue As String
    Public strpath As String = ""    'verzeichnissstruktur 
    Public systemCE As Boolean = False
    Public Shared auftragsverw As FAuftragsverwaltung
    Public Shared motorrichtung1 As FMotorRichtung
    Public Shared station As FStationAktif
    Public Shared myKettenfehler As FKettenfehler

    Public stationFehlerColorRed As Color

    Public adsClient As TcAdsClient
    Public hConnect() As Integer   'variablen handler array f�r notification events....
    Private dataStream As AdsStream
    Private binRead As BinaryReader


    Private varHandle1 As Integer
    Private varHandle2 As Integer
    Private varHandle3 As Integer

#Region " Vom Windows Form-Designer generierter Code "

    Public Sub New()

        MyBase.New()

        'Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        'Beliebige Initialisierung nach dem InitializeComponent()-Aufruf hinzuf�gen
        stationFehlerColorRed = Color.Red
        ' Create an instance of the PictureButton custom control, btnStation1Farbe
        With btnStation1Farbe
            .Parent = Me
            .Bounds = New Rectangle(175, 380, 120, 300)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnStation1Farbe.Width, btnStation1Farbe.Height)
            .PressedImageValue = MakeBitmap(Color.LightGray, _
                btnStation1Farbe.Width, btnStation1Farbe.Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .farbwert = 0
            .BringToFront()
        End With


        ' Create an instance of the PictureButton custom control, btnStation2Laser
        With btnStation2Laser
            .Parent = Me
            .Bounds = New Rectangle(305, 380, 120, 300)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnStation2Laser.Width, btnStation2Laser.Height)
            .PressedImageValue = MakeBitmap(Color.LightGray, _
                btnStation2Laser.Width, btnStation2Laser.Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .farbwert = 0
            .BringToFront()
        End With

        ' Create an instance of the PictureButton custom control, btnStation3Hoehe
        With btnStation3Hoehe
            .Parent = Me
            .Bounds = New Rectangle(435, 380, 120, 300)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnStation3Hoehe.Width, btnStation3Hoehe.Height)
            .PressedImageValue = MakeBitmap(Color.LightGray, _
                btnStation3Hoehe.Width, btnStation3Hoehe.Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .farbwert = 0
            .BringToFront()
        End With

        ' Create an instance of the PictureButton custom control, btnStation4Kamera
        With btnStation4Kamera
            .Parent = Me
            .Bounds = New Rectangle(565, 380, 120, 300)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnStation4Kamera.Width, btnStation4Kamera.Height)
            .PressedImageValue = MakeBitmap(Color.LightGray, _
                btnStation4Kamera.Width, btnStation4Kamera.Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .farbwert = 0
            .BringToFront()
        End With

        ' Create an instance of the PictureButton custom control, btnStation4Kamera
        With btnAusschuss
            .Parent = Me
            .Bounds = New Rectangle(10, 380, 74, 150)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnStation4Kamera.Width, btnStation4Kamera.Height)
            .PressedImageValue = MakeBitmap(Color.LightGray, _
                btnStation4Kamera.Width, btnStation4Kamera.Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .farbwert = 0
            .BringToFront()
        End With
    End Sub

    

    'HINWEIS: Die folgende Prozedur ist f�r den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnKettentypen As System.Windows.Forms.Button
    Friend WithEvents lblzeit As System.Windows.Forms.Label
    Friend WithEvents lbldatum As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents picboxTwincat As System.Windows.Forms.PictureBox
    Friend WithEvents picboxTcpIp As System.Windows.Forms.PictureBox
    Friend WithEvents picboxblau1 As System.Windows.Forms.PictureBox
    Public resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Friend WithEvents picboxrot0 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot1 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen0 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen1 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgelb1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatusMaschine As System.Windows.Forms.Label
    Friend WithEvents picboxstatusmaschine As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblFehler As System.Windows.Forms.Label
    Friend WithEvents lblFehlerMain As System.Windows.Forms.Label
    Friend WithEvents lblSp2Laser As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picboxsp2laser As System.Windows.Forms.PictureBox
    Friend WithEvents picboxsp1laser As System.Windows.Forms.PictureBox
    Friend WithEvents lblSpeicher1status As System.Windows.Forms.Label
    Friend WithEvents lblSpeicher2status As System.Windows.Forms.Label
    Friend WithEvents lblFarbpruefer As System.Windows.Forms.Label
    Friend WithEvents lblLasersensor As System.Windows.Forms.Label
    Friend WithEvents lblMechHoehe As System.Windows.Forms.Label
    Friend WithEvents lblKamera As System.Windows.Forms.Label
    Friend WithEvents picboxst1farbfehler As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation1Aktiv As System.Windows.Forms.Label
    Friend WithEvents picboxst1aktiv As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation1Farbfehler As System.Windows.Forms.Label
    Friend WithEvents lblStation2Laschenabstand As System.Windows.Forms.Label
    Friend WithEvents picboxst2laschenabstand As System.Windows.Forms.PictureBox
    Friend WithEvents picboxst2aktivlabstand As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation2AktivLabstand As System.Windows.Forms.Label
    Friend WithEvents lblStation2Bolzenhoehe As System.Windows.Forms.Label
    Friend WithEvents picboxst2bhoehe As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation2aktivBhoehe As System.Windows.Forms.Label
    Friend WithEvents picboxst2aktivbhoehe As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation3Distanz As System.Windows.Forms.Label
    Friend WithEvents picboxst3distanz As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation3AktivDistanz As System.Windows.Forms.Label
    Friend WithEvents picboxst3aktivdistanz As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation4LascheFehler As System.Windows.Forms.Label
    Friend WithEvents picboxst4aktivkamera As System.Windows.Forms.PictureBox
    Friend WithEvents picboxst4laschefehler As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation4AktivKamera As System.Windows.Forms.Label
    Friend WithEvents lblStation4RolleFehler As System.Windows.Forms.Label
    Friend WithEvents picboxst4rollefehler As System.Windows.Forms.PictureBox
    Friend WithEvents lblGliederzahlMain As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picbox1normalbetrieb As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents picbox2ruck1 As System.Windows.Forms.PictureBox
    Friend WithEvents picbox3zweitepruf As System.Windows.Forms.PictureBox
    Friend WithEvents picbox4ruck2 As System.Windows.Forms.PictureBox
    Friend WithEvents picbox5trennende As System.Windows.Forms.PictureBox
    Friend WithEvents picbox6ruck3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents picbox7trennanfang As System.Windows.Forms.PictureBox
    Friend WithEvents picboxkupplung1 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxkupplung2 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrotfett As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruenfett As System.Windows.Forms.PictureBox
    Friend WithEvents btnKettenfehler As System.Windows.Forms.Button
    Friend WithEvents lblmyZeiger_Fehler_S1 As System.Windows.Forms.Label
    Friend WithEvents lblmyZeiger_Fehler_S2 As System.Windows.Forms.Label
    Friend WithEvents lblmyZeiger_Fehler_S3 As System.Windows.Forms.Label
    Friend WithEvents lblmyZeiger_Fehler_S4 As System.Windows.Forms.Label
    Friend WithEvents btnKettenIO As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnKettenNIO As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Bolzenhoehe As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Laschenabst_1 As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Laschenabstand_2 As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Lasche_F As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Rolle_F As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Farbe As System.Windows.Forms.Label
    Friend WithEvents lblFlaechenSpStatus As System.Windows.Forms.Label
    Friend WithEvents btnNIOruecksetz As System.Windows.Forms.Button
    Friend WithEvents btnNIOnotRuecksetz As System.Windows.Forms.Button
    Friend WithEvents btnIOnotRuecksetz As System.Windows.Forms.Button
    Friend WithEvents btnIOruecksetz As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStation4RolleRFehler As System.Windows.Forms.Label
    Friend WithEvents lblStation4LascheUFehler As System.Windows.Forms.Label
    Friend WithEvents lblStation4ILascheUFehler As System.Windows.Forms.Label
    Friend WithEvents lblStation4ILascheOFehler As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Rolle_F_R As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Lasche_F_ALU As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Lasche_F_ILO As System.Windows.Forms.Label
    Friend WithEvents lblmyFZ_Lasche_F_ILU As System.Windows.Forms.Label
    Friend WithEvents picboxst4lascheufehler As System.Windows.Forms.PictureBox
    Friend WithEvents picboxst4innenlascheufehler As System.Windows.Forms.PictureBox
    Friend WithEvents picboxst4innenlascheofehler As System.Windows.Forms.PictureBox
    Friend WithEvents picboxst4rollerfehler As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents btnArtikelnummer As System.Windows.Forms.Button
    Friend WithEvents lblAktKettentyp As System.Windows.Forms.Label
    Friend WithEvents listboxArtikelnr As System.Windows.Forms.ListBox
    Friend WithEvents btnArtikelnrEsc As System.Windows.Forms.Button
    Friend WithEvents lblWLaser As System.Windows.Forms.Label
    Friend WithEvents LeseTimer As System.Windows.Forms.Timer
    Friend WithEvents lbldruckfehler As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblPseudoF As System.Windows.Forms.Label
    Friend WithEvents lblausschuss As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents picboxausschusszu As System.Windows.Forms.PictureBox
    Friend WithEvents lblausschusszaehler As System.Windows.Forms.Label
    Friend WithEvents lblAusschussBehVoll As System.Windows.Forms.Label
    Friend WithEvents lblAusschussBehFehlt As System.Windows.Forms.Label
    Friend WithEvents lblmyST_AusschussKetteRaus As System.Windows.Forms.Label
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents lblmyST_AnfDummyPruefung As System.Windows.Forms.Label
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblzeit = New System.Windows.Forms.Label
        Me.btnKettentypen = New System.Windows.Forms.Button
        Me.lbldatum = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.picboxTwincat = New System.Windows.Forms.PictureBox
        Me.picboxTcpIp = New System.Windows.Forms.PictureBox
        Me.picboxrot0 = New System.Windows.Forms.PictureBox
        Me.picboxrot1 = New System.Windows.Forms.PictureBox
        Me.picboxgruen0 = New System.Windows.Forms.PictureBox
        Me.picboxgruen1 = New System.Windows.Forms.PictureBox
        Me.picboxgelb1 = New System.Windows.Forms.PictureBox
        Me.picboxblau1 = New System.Windows.Forms.PictureBox
        Me.lblStatusMaschine = New System.Windows.Forms.Label
        Me.picboxstatusmaschine = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.picboxkupplung1 = New System.Windows.Forms.PictureBox
        Me.picboxkupplung2 = New System.Windows.Forms.PictureBox
        Me.lblFehler = New System.Windows.Forms.Label
        Me.lblFehlerMain = New System.Windows.Forms.Label
        Me.lblSpeicher2status = New System.Windows.Forms.Label
        Me.lblSpeicher1status = New System.Windows.Forms.Label
        Me.lblSp2Laser = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.picboxsp2laser = New System.Windows.Forms.PictureBox
        Me.picboxsp1laser = New System.Windows.Forms.PictureBox
        Me.lblFarbpruefer = New System.Windows.Forms.Label
        Me.lblLasersensor = New System.Windows.Forms.Label
        Me.lblMechHoehe = New System.Windows.Forms.Label
        Me.lblKamera = New System.Windows.Forms.Label
        Me.lblStation1Farbfehler = New System.Windows.Forms.Label
        Me.picboxst1farbfehler = New System.Windows.Forms.PictureBox
        Me.lblStation1Aktiv = New System.Windows.Forms.Label
        Me.picboxst1aktiv = New System.Windows.Forms.PictureBox
        Me.lblStation2Laschenabstand = New System.Windows.Forms.Label
        Me.picboxst2laschenabstand = New System.Windows.Forms.PictureBox
        Me.lblStation2AktivLabstand = New System.Windows.Forms.Label
        Me.picboxst2aktivlabstand = New System.Windows.Forms.PictureBox
        Me.lblStation2Bolzenhoehe = New System.Windows.Forms.Label
        Me.picboxst2bhoehe = New System.Windows.Forms.PictureBox
        Me.lblStation2aktivBhoehe = New System.Windows.Forms.Label
        Me.picboxst2aktivbhoehe = New System.Windows.Forms.PictureBox
        Me.lblStation3Distanz = New System.Windows.Forms.Label
        Me.picboxst3distanz = New System.Windows.Forms.PictureBox
        Me.lblStation3AktivDistanz = New System.Windows.Forms.Label
        Me.picboxst3aktivdistanz = New System.Windows.Forms.PictureBox
        Me.lblStation4LascheFehler = New System.Windows.Forms.Label
        Me.picboxst4laschefehler = New System.Windows.Forms.PictureBox
        Me.lblStation4AktivKamera = New System.Windows.Forms.Label
        Me.picboxst4aktivkamera = New System.Windows.Forms.PictureBox
        Me.lblStation4RolleFehler = New System.Windows.Forms.Label
        Me.picboxst4rollefehler = New System.Windows.Forms.PictureBox
        Me.lblGliederzahlMain = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.picbox1normalbetrieb = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.picbox2ruck1 = New System.Windows.Forms.PictureBox
        Me.picbox3zweitepruf = New System.Windows.Forms.PictureBox
        Me.picbox4ruck2 = New System.Windows.Forms.PictureBox
        Me.picbox5trennende = New System.Windows.Forms.PictureBox
        Me.picbox6ruck3 = New System.Windows.Forms.PictureBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.picbox7trennanfang = New System.Windows.Forms.PictureBox
        Me.picboxrotfett = New System.Windows.Forms.PictureBox
        Me.picboxgruenfett = New System.Windows.Forms.PictureBox
        Me.btnKettenfehler = New System.Windows.Forms.Button
        Me.lblmyZeiger_Fehler_S1 = New System.Windows.Forms.Label
        Me.lblmyZeiger_Fehler_S2 = New System.Windows.Forms.Label
        Me.lblmyZeiger_Fehler_S3 = New System.Windows.Forms.Label
        Me.lblmyZeiger_Fehler_S4 = New System.Windows.Forms.Label
        Me.btnKettenIO = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnKettenNIO = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblmyFZ_Farbe = New System.Windows.Forms.Label
        Me.lblmyFZ_Bolzenhoehe = New System.Windows.Forms.Label
        Me.lblmyFZ_Laschenabst_1 = New System.Windows.Forms.Label
        Me.lblmyFZ_Laschenabstand_2 = New System.Windows.Forms.Label
        Me.lblmyFZ_Lasche_F = New System.Windows.Forms.Label
        Me.lblmyFZ_Rolle_F = New System.Windows.Forms.Label
        Me.lblFlaechenSpStatus = New System.Windows.Forms.Label
        Me.btnNIOruecksetz = New System.Windows.Forms.Button
        Me.btnNIOnotRuecksetz = New System.Windows.Forms.Button
        Me.btnIOnotRuecksetz = New System.Windows.Forms.Button
        Me.btnIOruecksetz = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lblStation4RolleRFehler = New System.Windows.Forms.Label
        Me.lblStation4LascheUFehler = New System.Windows.Forms.Label
        Me.lblStation4ILascheUFehler = New System.Windows.Forms.Label
        Me.lblStation4ILascheOFehler = New System.Windows.Forms.Label
        Me.lblmyFZ_Rolle_F_R = New System.Windows.Forms.Label
        Me.lblmyFZ_Lasche_F_ALU = New System.Windows.Forms.Label
        Me.lblmyFZ_Lasche_F_ILO = New System.Windows.Forms.Label
        Me.lblmyFZ_Lasche_F_ILU = New System.Windows.Forms.Label
        Me.lbl1 = New System.Windows.Forms.Label
        Me.picboxst4lascheufehler = New System.Windows.Forms.PictureBox
        Me.lbl2 = New System.Windows.Forms.Label
        Me.lbl3 = New System.Windows.Forms.Label
        Me.picboxst4innenlascheufehler = New System.Windows.Forms.PictureBox
        Me.picboxst4innenlascheofehler = New System.Windows.Forms.PictureBox
        Me.lbl4 = New System.Windows.Forms.Label
        Me.lbl5 = New System.Windows.Forms.Label
        Me.picboxst4rollerfehler = New System.Windows.Forms.PictureBox
        Me.lbl6 = New System.Windows.Forms.Label
        Me.btnArtikelnummer = New System.Windows.Forms.Button
        Me.lblAktKettentyp = New System.Windows.Forms.Label
        Me.listboxArtikelnr = New System.Windows.Forms.ListBox
        Me.btnArtikelnrEsc = New System.Windows.Forms.Button
        Me.lblWLaser = New System.Windows.Forms.Label
        Me.LeseTimer = New System.Windows.Forms.Timer
        Me.lbldruckfehler = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblPseudoF = New System.Windows.Forms.Label
        Me.lblausschusszaehler = New System.Windows.Forms.Label
        Me.lblausschuss = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.picboxausschusszu = New System.Windows.Forms.PictureBox
        Me.lblAusschussBehVoll = New System.Windows.Forms.Label
        Me.lblAusschussBehFehlt = New System.Windows.Forms.Label
        Me.lblmyST_AusschussKetteRaus = New System.Windows.Forms.Label
        Me.lblmyST_AnfDummyPruefung = New System.Windows.Forms.Label
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.MainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem1.Text = "Datei"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "Visu beenden"
        '
        'MenuItem2
        '
        Me.MenuItem2.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem2.Text = "Info"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "Version"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 26)
        Me.PictureBox1.Size = New System.Drawing.Size(1021, 87)
        '
        'lblzeit
        '
        Me.lblzeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblzeit.Location = New System.Drawing.Point(314, 84)
        Me.lblzeit.Size = New System.Drawing.Size(104, 19)
        Me.lblzeit.Text = "00:00:00"
        Me.lblzeit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnKettentypen
        '
        Me.btnKettentypen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnKettentypen.Location = New System.Drawing.Point(840, 120)
        Me.btnKettentypen.Size = New System.Drawing.Size(176, 40)
        Me.btnKettentypen.Text = "Auftragsverwaltung"
        '
        'lbldatum
        '
        Me.lbldatum.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbldatum.Location = New System.Drawing.Point(310, 40)
        Me.lbldatum.Size = New System.Drawing.Size(110, 22)
        Me.lbldatum.Text = "00.00.0000"
        Me.lbldatum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'picboxTwincat
        '
        Me.picboxTwincat.Image = CType(resources.GetObject("picboxTwincat.Image"), System.Drawing.Image)
        Me.picboxTwincat.Location = New System.Drawing.Point(208, 63)
        Me.picboxTwincat.Size = New System.Drawing.Size(20, 20)
        '
        'picboxTcpIp
        '
        Me.picboxTcpIp.Image = CType(resources.GetObject("picboxTcpIp.Image"), System.Drawing.Image)
        Me.picboxTcpIp.Location = New System.Drawing.Point(208, 86)
        Me.picboxTcpIp.Size = New System.Drawing.Size(20, 20)
        '
        'picboxrot0
        '
        Me.picboxrot0.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)
        Me.picboxrot0.Location = New System.Drawing.Point(9, 72)
        Me.picboxrot0.Size = New System.Drawing.Size(20, 20)
        '
        'picboxrot1
        '
        Me.picboxrot1.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Me.picboxrot1.Location = New System.Drawing.Point(33, 72)
        Me.picboxrot1.Size = New System.Drawing.Size(20, 20)
        '
        'picboxgruen0
        '
        Me.picboxgruen0.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Me.picboxgruen0.Location = New System.Drawing.Point(69, 66)
        Me.picboxgruen0.Size = New System.Drawing.Size(20, 20)
        '
        'picboxgruen1
        '
        Me.picboxgruen1.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        Me.picboxgruen1.Location = New System.Drawing.Point(102, 60)
        Me.picboxgruen1.Size = New System.Drawing.Size(20, 20)
        '
        'picboxgelb1
        '
        Me.picboxgelb1.Image = CType(resources.GetObject("picboxgelb1.Image"), System.Drawing.Image)
        Me.picboxgelb1.Location = New System.Drawing.Point(135, 63)
        Me.picboxgelb1.Size = New System.Drawing.Size(20, 20)
        '
        'picboxblau1
        '
        Me.picboxblau1.Image = CType(resources.GetObject("picboxblau1.Image"), System.Drawing.Image)
        Me.picboxblau1.Location = New System.Drawing.Point(171, 66)
        Me.picboxblau1.Size = New System.Drawing.Size(20, 20)
        '
        'lblStatusMaschine
        '
        Me.lblStatusMaschine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblStatusMaschine.Location = New System.Drawing.Point(846, 42)
        Me.lblStatusMaschine.Size = New System.Drawing.Size(141, 18)
        Me.lblStatusMaschine.Text = "Status"
        Me.lblStatusMaschine.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxstatusmaschine
        '
        Me.picboxstatusmaschine.Image = CType(resources.GetObject("picboxstatusmaschine.Image"), System.Drawing.Image)
        Me.picboxstatusmaschine.Location = New System.Drawing.Point(993, 41)
        Me.picboxstatusmaschine.Size = New System.Drawing.Size(20, 20)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 114)
        Me.PictureBox2.Size = New System.Drawing.Size(829, 612)
        '
        'picboxkupplung1
        '
        Me.picboxkupplung1.Image = CType(resources.GetObject("picboxkupplung1.Image"), System.Drawing.Image)
        Me.picboxkupplung1.Location = New System.Drawing.Point(44, 610)
        Me.picboxkupplung1.Size = New System.Drawing.Size(50, 50)
        '
        'picboxkupplung2
        '
        Me.picboxkupplung2.Image = CType(resources.GetObject("picboxkupplung2.Image"), System.Drawing.Image)
        Me.picboxkupplung2.Location = New System.Drawing.Point(720, 610)
        Me.picboxkupplung2.Size = New System.Drawing.Size(50, 50)
        '
        'lblFehler
        '
        Me.lblFehler.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblFehler.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFehler.Location = New System.Drawing.Point(846, 84)
        Me.lblFehler.Size = New System.Drawing.Size(168, 18)
        Me.lblFehler.Text = "St�rungen"
        Me.lblFehler.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFehlerMain
        '
        Me.lblFehlerMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblFehlerMain.ForeColor = System.Drawing.Color.Red
        Me.lblFehlerMain.Location = New System.Drawing.Point(176, 260)
        Me.lblFehlerMain.Size = New System.Drawing.Size(578, 26)
        Me.lblFehlerMain.Text = "St�rung!"
        Me.lblFehlerMain.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblFehlerMain.Visible = False
        '
        'lblSpeicher2status
        '
        Me.lblSpeicher2status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSpeicher2status.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblSpeicher2status.Location = New System.Drawing.Point(339, 147)
        Me.lblSpeicher2status.Size = New System.Drawing.Size(246, 21)
        Me.lblSpeicher2status.Text = "Speicher 2 Status"
        Me.lblSpeicher2status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblSpeicher2status.Visible = False
        '
        'lblSpeicher1status
        '
        Me.lblSpeicher1status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSpeicher1status.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblSpeicher1status.Location = New System.Drawing.Point(339, 228)
        Me.lblSpeicher1status.Size = New System.Drawing.Size(246, 21)
        Me.lblSpeicher1status.Text = "Speicher 1 Status"
        Me.lblSpeicher1status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblSpeicher1status.Visible = False
        '
        'lblSp2Laser
        '
        Me.lblSp2Laser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblSp2Laser.Location = New System.Drawing.Point(15, 126)
        Me.lblSp2Laser.Size = New System.Drawing.Size(60, 54)
        Me.lblSp2Laser.Text = "Speicher 2 Laser"
        Me.lblSp2Laser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(15, 204)
        Me.Label1.Size = New System.Drawing.Size(60, 54)
        Me.Label1.Text = "Speicher 1 Laser"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxsp2laser
        '
        Me.picboxsp2laser.Image = CType(resources.GetObject("picboxsp2laser.Image"), System.Drawing.Image)
        Me.picboxsp2laser.Location = New System.Drawing.Point(36, 156)
        Me.picboxsp2laser.Size = New System.Drawing.Size(20, 20)
        '
        'picboxsp1laser
        '
        Me.picboxsp1laser.Image = CType(resources.GetObject("picboxsp1laser.Image"), System.Drawing.Image)
        Me.picboxsp1laser.Location = New System.Drawing.Point(36, 234)
        Me.picboxsp1laser.Size = New System.Drawing.Size(20, 20)
        '
        'lblFarbpruefer
        '
        Me.lblFarbpruefer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFarbpruefer.Location = New System.Drawing.Point(192, 681)
        Me.lblFarbpruefer.Size = New System.Drawing.Size(90, 15)
        Me.lblFarbpruefer.Text = "Station 1"
        Me.lblFarbpruefer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLasersensor
        '
        Me.lblLasersensor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLasersensor.Location = New System.Drawing.Point(321, 681)
        Me.lblLasersensor.Size = New System.Drawing.Size(90, 15)
        Me.lblLasersensor.Text = "Station 2"
        Me.lblLasersensor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMechHoehe
        '
        Me.lblMechHoehe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMechHoehe.Location = New System.Drawing.Point(450, 681)
        Me.lblMechHoehe.Size = New System.Drawing.Size(90, 15)
        Me.lblMechHoehe.Text = "Station 3"
        Me.lblMechHoehe.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblKamera
        '
        Me.lblKamera.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblKamera.Location = New System.Drawing.Point(579, 681)
        Me.lblKamera.Size = New System.Drawing.Size(90, 15)
        Me.lblKamera.Text = "Station 4"
        Me.lblKamera.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStation1Farbfehler
        '
        Me.lblStation1Farbfehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation1Farbfehler.Location = New System.Drawing.Point(210, 634)
        Me.lblStation1Farbfehler.Size = New System.Drawing.Size(78, 18)
        Me.lblStation1Farbfehler.Text = "Fehler"
        '
        'picboxst1farbfehler
        '
        Me.picboxst1farbfehler.Image = CType(resources.GetObject("picboxst1farbfehler.Image"), System.Drawing.Image)
        Me.picboxst1farbfehler.Location = New System.Drawing.Point(183, 633)
        Me.picboxst1farbfehler.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation1Aktiv
        '
        Me.lblStation1Aktiv.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation1Aktiv.Location = New System.Drawing.Point(210, 607)
        Me.lblStation1Aktiv.Size = New System.Drawing.Size(78, 18)
        Me.lblStation1Aktiv.Text = "Aktiv"
        '
        'picboxst1aktiv
        '
        Me.picboxst1aktiv.Image = CType(resources.GetObject("picboxst1aktiv.Image"), System.Drawing.Image)
        Me.picboxst1aktiv.Location = New System.Drawing.Point(183, 606)
        Me.picboxst1aktiv.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation2Laschenabstand
        '
        Me.lblStation2Laschenabstand.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation2Laschenabstand.Location = New System.Drawing.Point(339, 634)
        Me.lblStation2Laschenabstand.Size = New System.Drawing.Size(78, 18)
        Me.lblStation2Laschenabstand.Text = "Fehler"
        '
        'picboxst2laschenabstand
        '
        Me.picboxst2laschenabstand.Image = CType(resources.GetObject("picboxst2laschenabstand.Image"), System.Drawing.Image)
        Me.picboxst2laschenabstand.Location = New System.Drawing.Point(312, 633)
        Me.picboxst2laschenabstand.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation2AktivLabstand
        '
        Me.lblStation2AktivLabstand.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation2AktivLabstand.Location = New System.Drawing.Point(339, 607)
        Me.lblStation2AktivLabstand.Size = New System.Drawing.Size(78, 18)
        Me.lblStation2AktivLabstand.Text = "Aktiv"
        '
        'picboxst2aktivlabstand
        '
        Me.picboxst2aktivlabstand.Image = CType(resources.GetObject("picboxst2aktivlabstand.Image"), System.Drawing.Image)
        Me.picboxst2aktivlabstand.Location = New System.Drawing.Point(312, 606)
        Me.picboxst2aktivlabstand.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation2Bolzenhoehe
        '
        Me.lblStation2Bolzenhoehe.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation2Bolzenhoehe.Location = New System.Drawing.Point(339, 544)
        Me.lblStation2Bolzenhoehe.Size = New System.Drawing.Size(78, 18)
        Me.lblStation2Bolzenhoehe.Text = "Fehler"
        '
        'picboxst2bhoehe
        '
        Me.picboxst2bhoehe.Image = CType(resources.GetObject("picboxst2bhoehe.Image"), System.Drawing.Image)
        Me.picboxst2bhoehe.Location = New System.Drawing.Point(312, 542)
        Me.picboxst2bhoehe.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation2aktivBhoehe
        '
        Me.lblStation2aktivBhoehe.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation2aktivBhoehe.Location = New System.Drawing.Point(339, 516)
        Me.lblStation2aktivBhoehe.Size = New System.Drawing.Size(78, 18)
        Me.lblStation2aktivBhoehe.Text = "Aktiv"
        '
        'picboxst2aktivbhoehe
        '
        Me.picboxst2aktivbhoehe.Image = CType(resources.GetObject("picboxst2aktivbhoehe.Image"), System.Drawing.Image)
        Me.picboxst2aktivbhoehe.Location = New System.Drawing.Point(312, 516)
        Me.picboxst2aktivbhoehe.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation3Distanz
        '
        Me.lblStation3Distanz.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation3Distanz.Location = New System.Drawing.Point(469, 634)
        Me.lblStation3Distanz.Size = New System.Drawing.Size(78, 18)
        Me.lblStation3Distanz.Text = "Fehler"
        '
        'picboxst3distanz
        '
        Me.picboxst3distanz.Image = CType(resources.GetObject("picboxst3distanz.Image"), System.Drawing.Image)
        Me.picboxst3distanz.Location = New System.Drawing.Point(442, 633)
        Me.picboxst3distanz.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation3AktivDistanz
        '
        Me.lblStation3AktivDistanz.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation3AktivDistanz.Location = New System.Drawing.Point(469, 607)
        Me.lblStation3AktivDistanz.Size = New System.Drawing.Size(78, 18)
        Me.lblStation3AktivDistanz.Text = "Aktiv"
        '
        'picboxst3aktivdistanz
        '
        Me.picboxst3aktivdistanz.Image = CType(resources.GetObject("picboxst3aktivdistanz.Image"), System.Drawing.Image)
        Me.picboxst3aktivdistanz.Location = New System.Drawing.Point(442, 606)
        Me.picboxst3aktivdistanz.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation4LascheFehler
        '
        Me.lblStation4LascheFehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4LascheFehler.Location = New System.Drawing.Point(569, 562)
        Me.lblStation4LascheFehler.Size = New System.Drawing.Size(39, 18)
        Me.lblStation4LascheFehler.Text = "ALO"
        '
        'picboxst4laschefehler
        '
        Me.picboxst4laschefehler.Image = CType(resources.GetObject("picboxst4laschefehler.Image"), System.Drawing.Image)
        Me.picboxst4laschefehler.Location = New System.Drawing.Point(592, 446)
        Me.picboxst4laschefehler.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation4AktivKamera
        '
        Me.lblStation4AktivKamera.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4AktivKamera.Location = New System.Drawing.Point(599, 412)
        Me.lblStation4AktivKamera.Size = New System.Drawing.Size(78, 18)
        Me.lblStation4AktivKamera.Text = "Aktiv"
        '
        'picboxst4aktivkamera
        '
        Me.picboxst4aktivkamera.Image = CType(resources.GetObject("picboxst4aktivkamera.Image"), System.Drawing.Image)
        Me.picboxst4aktivkamera.Location = New System.Drawing.Point(572, 411)
        Me.picboxst4aktivkamera.Size = New System.Drawing.Size(20, 20)
        '
        'lblStation4RolleFehler
        '
        Me.lblStation4RolleFehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4RolleFehler.Location = New System.Drawing.Point(569, 634)
        Me.lblStation4RolleFehler.Size = New System.Drawing.Size(39, 18)
        Me.lblStation4RolleFehler.Text = "RoL"
        '
        'picboxst4rollefehler
        '
        Me.picboxst4rollefehler.Image = CType(resources.GetObject("picboxst4rollefehler.Image"), System.Drawing.Image)
        Me.picboxst4rollefehler.Location = New System.Drawing.Point(613, 490)
        Me.picboxst4rollefehler.Size = New System.Drawing.Size(20, 20)
        '
        'lblGliederzahlMain
        '
        Me.lblGliederzahlMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblGliederzahlMain.Location = New System.Drawing.Point(636, 32)
        Me.lblGliederzahlMain.Size = New System.Drawing.Size(63, 18)
        Me.lblGliederzahlMain.Text = "0"
        Me.lblGliederzahlMain.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(186, 584)
        Me.Label2.Size = New System.Drawing.Size(102, 18)
        Me.Label2.Text = "Farbsensor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(306, 584)
        Me.Label3.Size = New System.Drawing.Size(117, 18)
        Me.Label3.Text = "Laschenabstand 1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label4.Location = New System.Drawing.Point(436, 584)
        Me.Label4.Size = New System.Drawing.Size(117, 18)
        Me.Label4.Text = "Laschenabstand 2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label5.Location = New System.Drawing.Point(315, 494)
        Me.Label5.Size = New System.Drawing.Size(96, 18)
        Me.Label5.Text = "Bolzenh�he"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label6.Location = New System.Drawing.Point(574, 390)
        Me.Label6.Size = New System.Drawing.Size(102, 18)
        Me.Label6.Text = "Kamera"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picbox1normalbetrieb
        '
        Me.picbox1normalbetrieb.Image = CType(resources.GetObject("picbox1normalbetrieb.Image"), System.Drawing.Image)
        Me.picbox1normalbetrieb.Location = New System.Drawing.Point(848, 366)
        Me.picbox1normalbetrieb.Size = New System.Drawing.Size(20, 20)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(872, 368)
        Me.Label7.Size = New System.Drawing.Size(150, 18)
        Me.Label7.Text = "Normalbetrieb"
        '
        'picbox2ruck1
        '
        Me.picbox2ruck1.Image = CType(resources.GetObject("picbox2ruck1.Image"), System.Drawing.Image)
        Me.picbox2ruck1.Location = New System.Drawing.Point(848, 396)
        Me.picbox2ruck1.Size = New System.Drawing.Size(20, 20)
        '
        'picbox3zweitepruf
        '
        Me.picbox3zweitepruf.Image = CType(resources.GetObject("picbox3zweitepruf.Image"), System.Drawing.Image)
        Me.picbox3zweitepruf.Location = New System.Drawing.Point(848, 426)
        Me.picbox3zweitepruf.Size = New System.Drawing.Size(20, 20)
        '
        'picbox4ruck2
        '
        Me.picbox4ruck2.Image = CType(resources.GetObject("picbox4ruck2.Image"), System.Drawing.Image)
        Me.picbox4ruck2.Location = New System.Drawing.Point(848, 456)
        Me.picbox4ruck2.Size = New System.Drawing.Size(20, 20)
        '
        'picbox5trennende
        '
        Me.picbox5trennende.Image = CType(resources.GetObject("picbox5trennende.Image"), System.Drawing.Image)
        Me.picbox5trennende.Location = New System.Drawing.Point(848, 486)
        Me.picbox5trennende.Size = New System.Drawing.Size(20, 20)
        '
        'picbox6ruck3
        '
        Me.picbox6ruck3.Image = CType(resources.GetObject("picbox6ruck3.Image"), System.Drawing.Image)
        Me.picbox6ruck3.Location = New System.Drawing.Point(848, 516)
        Me.picbox6ruck3.Size = New System.Drawing.Size(20, 20)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(872, 398)
        Me.Label8.Size = New System.Drawing.Size(150, 18)
        Me.Label8.Text = "R�ckfahrt 1"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(872, 428)
        Me.Label9.Size = New System.Drawing.Size(150, 18)
        Me.Label9.Text = "2. Pr�fung"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(872, 458)
        Me.Label10.Size = New System.Drawing.Size(150, 18)
        Me.Label10.Text = "R�ckfahrt 2"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(872, 488)
        Me.Label11.Size = New System.Drawing.Size(150, 18)
        Me.Label11.Text = "Kt.ende Trennen"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(872, 518)
        Me.Label12.Size = New System.Drawing.Size(150, 18)
        Me.Label12.Text = "R�ckfahrt 3"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(872, 548)
        Me.Label13.Size = New System.Drawing.Size(150, 18)
        Me.Label13.Text = "Kt.anfang Trennen"
        '
        'picbox7trennanfang
        '
        Me.picbox7trennanfang.Image = CType(resources.GetObject("picbox7trennanfang.Image"), System.Drawing.Image)
        Me.picbox7trennanfang.Location = New System.Drawing.Point(848, 546)
        Me.picbox7trennanfang.Size = New System.Drawing.Size(20, 20)
        '
        'picboxrotfett
        '
        Me.picboxrotfett.Image = CType(resources.GetObject("picboxrotfett.Image"), System.Drawing.Image)
        Me.picboxrotfett.Location = New System.Drawing.Point(24, 406)
        Me.picboxrotfett.Size = New System.Drawing.Size(50, 50)
        '
        'picboxgruenfett
        '
        Me.picboxgruenfett.Image = CType(resources.GetObject("picboxgruenfett.Image"), System.Drawing.Image)
        Me.picboxgruenfett.Location = New System.Drawing.Point(24, 474)
        Me.picboxgruenfett.Size = New System.Drawing.Size(50, 50)
        '
        'btnKettenfehler
        '
        Me.btnKettenfehler.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnKettenfehler.Location = New System.Drawing.Point(840, 166)
        Me.btnKettenfehler.Size = New System.Drawing.Size(176, 40)
        Me.btnKettenfehler.Text = "Kettenfehler"
        '
        'lblmyZeiger_Fehler_S1
        '
        Me.lblmyZeiger_Fehler_S1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyZeiger_Fehler_S1.Location = New System.Drawing.Point(216, 366)
        Me.lblmyZeiger_Fehler_S1.Size = New System.Drawing.Size(42, 14)
        Me.lblmyZeiger_Fehler_S1.Text = "000"
        Me.lblmyZeiger_Fehler_S1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyZeiger_Fehler_S2
        '
        Me.lblmyZeiger_Fehler_S2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyZeiger_Fehler_S2.Location = New System.Drawing.Point(342, 366)
        Me.lblmyZeiger_Fehler_S2.Size = New System.Drawing.Size(42, 14)
        Me.lblmyZeiger_Fehler_S2.Text = "000"
        Me.lblmyZeiger_Fehler_S2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyZeiger_Fehler_S3
        '
        Me.lblmyZeiger_Fehler_S3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyZeiger_Fehler_S3.Location = New System.Drawing.Point(474, 366)
        Me.lblmyZeiger_Fehler_S3.Size = New System.Drawing.Size(42, 14)
        Me.lblmyZeiger_Fehler_S3.Text = "000"
        Me.lblmyZeiger_Fehler_S3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyZeiger_Fehler_S4
        '
        Me.lblmyZeiger_Fehler_S4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyZeiger_Fehler_S4.Location = New System.Drawing.Point(602, 366)
        Me.lblmyZeiger_Fehler_S4.Size = New System.Drawing.Size(42, 14)
        Me.lblmyZeiger_Fehler_S4.Text = "000"
        Me.lblmyZeiger_Fehler_S4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnKettenIO
        '
        Me.btnKettenIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnKettenIO.Location = New System.Drawing.Point(732, 31)
        Me.btnKettenIO.Size = New System.Drawing.Size(102, 20)
        Me.btnKettenIO.Text = "0"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Label14.Location = New System.Drawing.Point(732, 50)
        Me.Label14.Size = New System.Drawing.Size(102, 17)
        Me.Label14.Text = "Anzahl IO"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnKettenNIO
        '
        Me.btnKettenNIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnKettenNIO.Location = New System.Drawing.Point(732, 73)
        Me.btnKettenNIO.Size = New System.Drawing.Size(102, 20)
        Me.btnKettenNIO.Text = "0"
        Me.btnKettenNIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Label16.Location = New System.Drawing.Point(732, 92)
        Me.Label16.Size = New System.Drawing.Size(102, 17)
        Me.Label16.Text = "Anzahl NIO"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Farbe
        '
        Me.lblmyFZ_Farbe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Farbe.Location = New System.Drawing.Point(186, 656)
        Me.lblmyFZ_Farbe.Size = New System.Drawing.Size(102, 14)
        Me.lblmyFZ_Farbe.Text = "000"
        Me.lblmyFZ_Farbe.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Bolzenhoehe
        '
        Me.lblmyFZ_Bolzenhoehe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Bolzenhoehe.Location = New System.Drawing.Point(315, 566)
        Me.lblmyFZ_Bolzenhoehe.Size = New System.Drawing.Size(102, 14)
        Me.lblmyFZ_Bolzenhoehe.Text = "000"
        Me.lblmyFZ_Bolzenhoehe.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Laschenabst_1
        '
        Me.lblmyFZ_Laschenabst_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Laschenabst_1.Location = New System.Drawing.Point(315, 656)
        Me.lblmyFZ_Laschenabst_1.Size = New System.Drawing.Size(102, 14)
        Me.lblmyFZ_Laschenabst_1.Text = "000"
        Me.lblmyFZ_Laschenabst_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Laschenabstand_2
        '
        Me.lblmyFZ_Laschenabstand_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Laschenabstand_2.Location = New System.Drawing.Point(445, 656)
        Me.lblmyFZ_Laschenabstand_2.Size = New System.Drawing.Size(102, 14)
        Me.lblmyFZ_Laschenabstand_2.Text = "000"
        Me.lblmyFZ_Laschenabstand_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Lasche_F
        '
        Me.lblmyFZ_Lasche_F.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Lasche_F.Location = New System.Drawing.Point(607, 564)
        Me.lblmyFZ_Lasche_F.Size = New System.Drawing.Size(74, 14)
        Me.lblmyFZ_Lasche_F.Text = "000"
        Me.lblmyFZ_Lasche_F.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Rolle_F
        '
        Me.lblmyFZ_Rolle_F.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Rolle_F.Location = New System.Drawing.Point(607, 636)
        Me.lblmyFZ_Rolle_F.Size = New System.Drawing.Size(74, 14)
        Me.lblmyFZ_Rolle_F.Text = "000"
        Me.lblmyFZ_Rolle_F.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlaechenSpStatus
        '
        Me.lblFlaechenSpStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblFlaechenSpStatus.ForeColor = System.Drawing.Color.Yellow
        Me.lblFlaechenSpStatus.Location = New System.Drawing.Point(186, 180)
        Me.lblFlaechenSpStatus.Size = New System.Drawing.Size(550, 25)
        Me.lblFlaechenSpStatus.Text = "Fl�chenspeicher"
        Me.lblFlaechenSpStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblFlaechenSpStatus.Visible = False
        '
        'btnNIOruecksetz
        '
        Me.btnNIOruecksetz.Enabled = False
        Me.btnNIOruecksetz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnNIOruecksetz.Location = New System.Drawing.Point(506, 150)
        Me.btnNIOruecksetz.Size = New System.Drawing.Size(278, 58)
        Me.btnNIOruecksetz.Text = "NIO Z�hler zur�cksetzen!"
        Me.btnNIOruecksetz.Visible = False
        '
        'btnNIOnotRuecksetz
        '
        Me.btnNIOnotRuecksetz.Enabled = False
        Me.btnNIOnotRuecksetz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnNIOnotRuecksetz.Location = New System.Drawing.Point(506, 92)
        Me.btnNIOnotRuecksetz.Size = New System.Drawing.Size(278, 58)
        Me.btnNIOnotRuecksetz.Text = "ESC"
        Me.btnNIOnotRuecksetz.Visible = False
        '
        'btnIOnotRuecksetz
        '
        Me.btnIOnotRuecksetz.Enabled = False
        Me.btnIOnotRuecksetz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnIOnotRuecksetz.Location = New System.Drawing.Point(506, 50)
        Me.btnIOnotRuecksetz.Size = New System.Drawing.Size(278, 58)
        Me.btnIOnotRuecksetz.Text = "ESC"
        Me.btnIOnotRuecksetz.Visible = False
        '
        'btnIOruecksetz
        '
        Me.btnIOruecksetz.Enabled = False
        Me.btnIOruecksetz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnIOruecksetz.Location = New System.Drawing.Point(506, 108)
        Me.btnIOruecksetz.Size = New System.Drawing.Size(278, 58)
        Me.btnIOruecksetz.Text = "Alle Z�hler zur�cksetzen!"
        Me.btnIOruecksetz.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(46, 32)
        Me.Label15.Size = New System.Drawing.Size(118, 14)
        Me.Label15.Text = "Kokev G53 RT"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(52, 48)
        Me.PictureBox3.Size = New System.Drawing.Size(105, 61)
        '
        'lblStation4RolleRFehler
        '
        Me.lblStation4RolleRFehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4RolleRFehler.Location = New System.Drawing.Point(569, 652)
        Me.lblStation4RolleRFehler.Size = New System.Drawing.Size(39, 18)
        Me.lblStation4RolleRFehler.Text = "RoR"
        '
        'lblStation4LascheUFehler
        '
        Me.lblStation4LascheUFehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4LascheUFehler.Location = New System.Drawing.Point(569, 580)
        Me.lblStation4LascheUFehler.Size = New System.Drawing.Size(39, 18)
        Me.lblStation4LascheUFehler.Text = "ALU"
        '
        'lblStation4ILascheUFehler
        '
        Me.lblStation4ILascheUFehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4ILascheUFehler.Location = New System.Drawing.Point(569, 616)
        Me.lblStation4ILascheUFehler.Size = New System.Drawing.Size(39, 18)
        Me.lblStation4ILascheUFehler.Text = "ILU"
        '
        'lblStation4ILascheOFehler
        '
        Me.lblStation4ILascheOFehler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStation4ILascheOFehler.Location = New System.Drawing.Point(569, 598)
        Me.lblStation4ILascheOFehler.Size = New System.Drawing.Size(39, 18)
        Me.lblStation4ILascheOFehler.Text = "ILO"
        '
        'lblmyFZ_Rolle_F_R
        '
        Me.lblmyFZ_Rolle_F_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Rolle_F_R.Location = New System.Drawing.Point(607, 654)
        Me.lblmyFZ_Rolle_F_R.Size = New System.Drawing.Size(74, 14)
        Me.lblmyFZ_Rolle_F_R.Text = "000"
        Me.lblmyFZ_Rolle_F_R.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Lasche_F_ALU
        '
        Me.lblmyFZ_Lasche_F_ALU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Lasche_F_ALU.Location = New System.Drawing.Point(607, 582)
        Me.lblmyFZ_Lasche_F_ALU.Size = New System.Drawing.Size(74, 14)
        Me.lblmyFZ_Lasche_F_ALU.Text = "000"
        Me.lblmyFZ_Lasche_F_ALU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Lasche_F_ILO
        '
        Me.lblmyFZ_Lasche_F_ILO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Lasche_F_ILO.Location = New System.Drawing.Point(607, 600)
        Me.lblmyFZ_Lasche_F_ILO.Size = New System.Drawing.Size(74, 14)
        Me.lblmyFZ_Lasche_F_ILO.Text = "000"
        Me.lblmyFZ_Lasche_F_ILO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyFZ_Lasche_F_ILU
        '
        Me.lblmyFZ_Lasche_F_ILU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyFZ_Lasche_F_ILU.Location = New System.Drawing.Point(607, 618)
        Me.lblmyFZ_Lasche_F_ILU.Size = New System.Drawing.Size(74, 14)
        Me.lblmyFZ_Lasche_F_ILU.Text = "000"
        Me.lblmyFZ_Lasche_F_ILU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl1.Location = New System.Drawing.Point(570, 452)
        Me.lbl1.Size = New System.Drawing.Size(66, 10)
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxst4lascheufehler
        '
        Me.picboxst4lascheufehler.Image = CType(resources.GetObject("picboxst4lascheufehler.Image"), System.Drawing.Image)
        Me.picboxst4lascheufehler.Location = New System.Drawing.Point(592, 533)
        Me.picboxst4lascheufehler.Size = New System.Drawing.Size(20, 20)
        '
        'lbl2
        '
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl2.Location = New System.Drawing.Point(570, 538)
        Me.lbl2.Size = New System.Drawing.Size(66, 10)
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl3
        '
        Me.lbl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl3.Location = New System.Drawing.Point(608, 470)
        Me.lbl3.Size = New System.Drawing.Size(70, 10)
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxst4innenlascheufehler
        '
        Me.picboxst4innenlascheufehler.Image = CType(resources.GetObject("picboxst4innenlascheufehler.Image"), System.Drawing.Image)
        Me.picboxst4innenlascheufehler.Location = New System.Drawing.Point(634, 515)
        Me.picboxst4innenlascheufehler.Size = New System.Drawing.Size(20, 20)
        '
        'picboxst4innenlascheofehler
        '
        Me.picboxst4innenlascheofehler.Image = CType(resources.GetObject("picboxst4innenlascheofehler.Image"), System.Drawing.Image)
        Me.picboxst4innenlascheofehler.Location = New System.Drawing.Point(634, 465)
        Me.picboxst4innenlascheofehler.Size = New System.Drawing.Size(20, 20)
        '
        'lbl4
        '
        Me.lbl4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl4.Location = New System.Drawing.Point(608, 520)
        Me.lbl4.Size = New System.Drawing.Size(70, 10)
        Me.lbl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl5
        '
        Me.lbl5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl5.Location = New System.Drawing.Point(658, 482)
        Me.lbl5.Size = New System.Drawing.Size(10, 35)
        Me.lbl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxst4rollerfehler
        '
        Me.picboxst4rollerfehler.Image = CType(resources.GetObject("picboxst4rollerfehler.Image"), System.Drawing.Image)
        Me.picboxst4rollerfehler.Location = New System.Drawing.Point(653, 490)
        Me.picboxst4rollerfehler.Size = New System.Drawing.Size(20, 20)
        '
        'lbl6
        '
        Me.lbl6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl6.Location = New System.Drawing.Point(618, 482)
        Me.lbl6.Size = New System.Drawing.Size(10, 35)
        Me.lbl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnArtikelnummer
        '
        Me.btnArtikelnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnArtikelnummer.Location = New System.Drawing.Point(432, 31)
        Me.btnArtikelnummer.Size = New System.Drawing.Size(180, 20)
        Me.btnArtikelnummer.Text = "0"
        '
        'lblAktKettentyp
        '
        Me.lblAktKettentyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.lblAktKettentyp.Location = New System.Drawing.Point(432, 50)
        Me.lblAktKettentyp.Size = New System.Drawing.Size(180, 17)
        Me.lblAktKettentyp.Text = "aktueller Kettentyp"
        Me.lblAktKettentyp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'listboxArtikelnr
        '
        Me.listboxArtikelnr.Enabled = False
        Me.listboxArtikelnr.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.listboxArtikelnr.Location = New System.Drawing.Point(431, 66)
        Me.listboxArtikelnr.Size = New System.Drawing.Size(182, 314)
        Me.listboxArtikelnr.Visible = False
        '
        'btnArtikelnrEsc
        '
        Me.btnArtikelnrEsc.Enabled = False
        Me.btnArtikelnrEsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular)
        Me.btnArtikelnrEsc.Location = New System.Drawing.Point(431, 360)
        Me.btnArtikelnrEsc.Size = New System.Drawing.Size(182, 52)
        Me.btnArtikelnrEsc.Text = "ESC"
        Me.btnArtikelnrEsc.Visible = False
        '
        'lblWLaser
        '
        Me.lblWLaser.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblWLaser.ForeColor = System.Drawing.Color.Black
        Me.lblWLaser.Location = New System.Drawing.Point(288, 286)
        Me.lblWLaser.Size = New System.Drawing.Size(350, 26)
        Me.lblWLaser.Text = "Warten auf Laser"
        Me.lblWLaser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblWLaser.Visible = False
        '
        'LeseTimer
        '
        Me.LeseTimer.Interval = 1000
        '
        'lbldruckfehler
        '
        Me.lbldruckfehler.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lbldruckfehler.ForeColor = System.Drawing.Color.Red
        Me.lbldruckfehler.Location = New System.Drawing.Point(288, 334)
        Me.lbldruckfehler.Size = New System.Drawing.Size(350, 26)
        Me.lbldruckfehler.Text = "St�rung Druckluft!"
        Me.lbldruckfehler.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbldruckfehler.Visible = False
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Label17.Location = New System.Drawing.Point(620, 92)
        Me.Label17.Size = New System.Drawing.Size(102, 17)
        Me.Label17.Text = "Pseudofehler"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPseudoF
        '
        Me.lblPseudoF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPseudoF.Location = New System.Drawing.Point(620, 73)
        Me.lblPseudoF.Size = New System.Drawing.Size(102, 20)
        Me.lblPseudoF.Text = "0"
        Me.lblPseudoF.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblausschusszaehler
        '
        Me.lblausschusszaehler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblausschusszaehler.Location = New System.Drawing.Point(26, 366)
        Me.lblausschusszaehler.Size = New System.Drawing.Size(42, 14)
        Me.lblausschusszaehler.Text = "000"
        Me.lblausschusszaehler.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblausschuss
        '
        Me.lblausschuss.Font = New System.Drawing.Font("Times New Roman", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblausschuss.Location = New System.Drawing.Point(12, 386)
        Me.lblausschuss.Size = New System.Drawing.Size(70, 30)
        Me.lblausschuss.Text = "Ausschuss-beh�lter"
        Me.lblausschuss.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(46, 474)
        Me.Label20.Size = New System.Drawing.Size(30, 18)
        Me.Label20.Text = "zu"
        '
        'picboxausschusszu
        '
        Me.picboxausschusszu.Image = CType(resources.GetObject("picboxausschusszu.Image"), System.Drawing.Image)
        Me.picboxausschusszu.Location = New System.Drawing.Point(18, 473)
        Me.picboxausschusszu.Size = New System.Drawing.Size(20, 20)
        '
        'lblAusschussBehVoll
        '
        Me.lblAusschussBehVoll.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblAusschussBehVoll.ForeColor = System.Drawing.Color.Red
        Me.lblAusschussBehVoll.Location = New System.Drawing.Point(288, 286)
        Me.lblAusschussBehVoll.Size = New System.Drawing.Size(350, 26)
        Me.lblAusschussBehVoll.Text = "Ausschussbeh�lter voll !"
        Me.lblAusschussBehVoll.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblAusschussBehVoll.Visible = False
        '
        'lblAusschussBehFehlt
        '
        Me.lblAusschussBehFehlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblAusschussBehFehlt.ForeColor = System.Drawing.Color.Red
        Me.lblAusschussBehFehlt.Location = New System.Drawing.Point(288, 310)
        Me.lblAusschussBehFehlt.Size = New System.Drawing.Size(350, 26)
        Me.lblAusschussBehFehlt.Text = "Ausschussbeh�lter fehlt !"
        Me.lblAusschussBehFehlt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblAusschussBehFehlt.Visible = False
        '
        'lblmyST_AusschussKetteRaus
        '
        Me.lblmyST_AusschussKetteRaus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyST_AusschussKetteRaus.ForeColor = System.Drawing.Color.Red
        Me.lblmyST_AusschussKetteRaus.Location = New System.Drawing.Point(288, 334)
        Me.lblmyST_AusschussKetteRaus.Size = New System.Drawing.Size(350, 26)
        Me.lblmyST_AusschussKetteRaus.Text = "Ausschusskette entfernen!"
        Me.lblmyST_AusschussKetteRaus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblmyST_AusschussKetteRaus.Visible = False
        '
        'lblmyST_AnfDummyPruefung
        '
        Me.lblmyST_AnfDummyPruefung.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular)
        Me.lblmyST_AnfDummyPruefung.ForeColor = System.Drawing.Color.Red
        Me.lblmyST_AnfDummyPruefung.Location = New System.Drawing.Point(186, 180)
        Me.lblmyST_AnfDummyPruefung.Size = New System.Drawing.Size(550, 25)
        Me.lblmyST_AnfDummyPruefung.Text = "Dummypr�fung durchf�hren!"
        Me.lblmyST_AnfDummyPruefung.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblmyST_AnfDummyPruefung.Visible = False
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(1020, 755)
        Me.Controls.Add(Me.lblmyST_AnfDummyPruefung)
        Me.Controls.Add(Me.lblmyST_AusschussKetteRaus)
        Me.Controls.Add(Me.lblAusschussBehFehlt)
        Me.Controls.Add(Me.lblAusschussBehVoll)
        Me.Controls.Add(Me.picboxausschusszu)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblausschusszaehler)
        Me.Controls.Add(Me.lblausschuss)
        Me.Controls.Add(Me.lblAktKettentyp)
        Me.Controls.Add(Me.lblPseudoF)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lbldruckfehler)
        Me.Controls.Add(Me.lblWLaser)
        Me.Controls.Add(Me.btnArtikelnrEsc)
        Me.Controls.Add(Me.btnArtikelnummer)
        Me.Controls.Add(Me.picboxst4rollefehler)
        Me.Controls.Add(Me.lbl6)
        Me.Controls.Add(Me.picboxst4rollerfehler)
        Me.Controls.Add(Me.lbl5)
        Me.Controls.Add(Me.picboxst4innenlascheufehler)
        Me.Controls.Add(Me.lbl4)
        Me.Controls.Add(Me.picboxst4innenlascheofehler)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.picboxst4lascheufehler)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.picboxst4laschefehler)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.lblmyFZ_Lasche_F_ILU)
        Me.Controls.Add(Me.lblmyFZ_Lasche_F_ILO)
        Me.Controls.Add(Me.lblmyFZ_Lasche_F_ALU)
        Me.Controls.Add(Me.lblmyFZ_Rolle_F_R)
        Me.Controls.Add(Me.lblStation4ILascheOFehler)
        Me.Controls.Add(Me.lblStation4ILascheUFehler)
        Me.Controls.Add(Me.lblStation4LascheUFehler)
        Me.Controls.Add(Me.lblStation4RolleRFehler)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.picboxst4aktivkamera)
        Me.Controls.Add(Me.picboxst3aktivdistanz)
        Me.Controls.Add(Me.picboxst2aktivlabstand)
        Me.Controls.Add(Me.picboxst1aktiv)
        Me.Controls.Add(Me.picboxst2aktivbhoehe)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblFlaechenSpStatus)
        Me.Controls.Add(Me.lblmyFZ_Rolle_F)
        Me.Controls.Add(Me.lblmyFZ_Lasche_F)
        Me.Controls.Add(Me.lblmyFZ_Laschenabstand_2)
        Me.Controls.Add(Me.lblmyFZ_Laschenabst_1)
        Me.Controls.Add(Me.lblmyFZ_Bolzenhoehe)
        Me.Controls.Add(Me.lblmyFZ_Farbe)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnKettenNIO)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnKettenIO)
        Me.Controls.Add(Me.lblmyZeiger_Fehler_S4)
        Me.Controls.Add(Me.lblmyZeiger_Fehler_S3)
        Me.Controls.Add(Me.lblmyZeiger_Fehler_S2)
        Me.Controls.Add(Me.lblmyZeiger_Fehler_S1)
        Me.Controls.Add(Me.btnKettenfehler)
        Me.Controls.Add(Me.picboxkupplung2)
        Me.Controls.Add(Me.picboxkupplung1)
        Me.Controls.Add(Me.picbox7trennanfang)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.picbox6ruck3)
        Me.Controls.Add(Me.picbox5trennende)
        Me.Controls.Add(Me.picbox4ruck2)
        Me.Controls.Add(Me.picbox3zweitepruf)
        Me.Controls.Add(Me.picbox2ruck1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.picbox1normalbetrieb)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblGliederzahlMain)
        Me.Controls.Add(Me.lblStation4RolleFehler)
        Me.Controls.Add(Me.lblStation4AktivKamera)
        Me.Controls.Add(Me.lblStation4LascheFehler)
        Me.Controls.Add(Me.lblStation3AktivDistanz)
        Me.Controls.Add(Me.picboxst3distanz)
        Me.Controls.Add(Me.lblStation3Distanz)
        Me.Controls.Add(Me.lblStation2aktivBhoehe)
        Me.Controls.Add(Me.picboxst2bhoehe)
        Me.Controls.Add(Me.lblStation2Bolzenhoehe)
        Me.Controls.Add(Me.lblStation2AktivLabstand)
        Me.Controls.Add(Me.picboxst2laschenabstand)
        Me.Controls.Add(Me.lblStation2Laschenabstand)
        Me.Controls.Add(Me.lblStation1Aktiv)
        Me.Controls.Add(Me.picboxst1farbfehler)
        Me.Controls.Add(Me.lblStation1Farbfehler)
        Me.Controls.Add(Me.lblKamera)
        Me.Controls.Add(Me.lblMechHoehe)
        Me.Controls.Add(Me.lblLasersensor)
        Me.Controls.Add(Me.lblFarbpruefer)
        Me.Controls.Add(Me.picboxsp1laser)
        Me.Controls.Add(Me.picboxsp2laser)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSp2Laser)
        Me.Controls.Add(Me.lblSpeicher1status)
        Me.Controls.Add(Me.lblSpeicher2status)
        Me.Controls.Add(Me.lblFehlerMain)
        Me.Controls.Add(Me.lblFehler)
        Me.Controls.Add(Me.picboxstatusmaschine)
        Me.Controls.Add(Me.lblStatusMaschine)
        Me.Controls.Add(Me.picboxTcpIp)
        Me.Controls.Add(Me.picboxTwincat)
        Me.Controls.Add(Me.lbldatum)
        Me.Controls.Add(Me.btnKettentypen)
        Me.Controls.Add(Me.lblzeit)
        Me.Controls.Add(Me.picboxgelb1)
        Me.Controls.Add(Me.picboxgruen1)
        Me.Controls.Add(Me.picboxgruen0)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnIOnotRuecksetz)
        Me.Controls.Add(Me.btnIOruecksetz)
        Me.Controls.Add(Me.btnNIOnotRuecksetz)
        Me.Controls.Add(Me.btnNIOruecksetz)
        Me.Controls.Add(Me.picboxblau1)
        Me.Controls.Add(Me.picboxrot1)
        Me.Controls.Add(Me.picboxrot0)
        Me.Controls.Add(Me.picboxrotfett)
        Me.Controls.Add(Me.picboxgruenfett)
        Me.Controls.Add(Me.listboxArtikelnr)
        Me.Menu = Me.MainMenu1
        Me.Text = "Kokev Visualisierung"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

    End Sub


#End Region

    '*******************************************************************
    'farbbutton steurung f�r zb. motor1 motor2
    ' Clean up any resources being used.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

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

    ' Because PictureButton inherits from Control, 
    ' you can use the default Click event.
    Private Sub btnStation1Farbe_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles btnStation1Farbe.Click
        If myH_Hand = True Then
            station = New FStationAktif(1)
            station.Show()
            station.BringToFront()
            Me.Enabled = False
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Sub

    ' Because PictureButton inherits from Control, 
    ' you can use the default Click event.
    Private Sub btnStation2Laser_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles btnStation2Laser.Click
        If myH_Hand = True Then
            station = New FStationAktif(2)
            station.Show()
            station.BringToFront()
            Me.Enabled = False
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Sub

    ' Because PictureButton inherits from Control, 
    ' you can use the default Click event.
    Private Sub btnStation3Hoehe_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles btnStation3Hoehe.Click
        If myH_Hand = True Then
            station = New FStationAktif(3)
            station.Show()
            station.BringToFront()
            Me.Enabled = False
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Sub

    ' Because PictureButton inherits from Control, 
    ' you can use the default Click event.
    Private Sub btnStation4Kamera_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles btnStation4Kamera.Click
        If myH_Hand = True Then
            station = New FStationAktif(4)
            station.Show()
            station.BringToFront()
            Me.Enabled = False
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Sub

    ' Because PictureButton inherits from Control, 
    ' you can use the default Click event.
    Private Sub btnAusschuss_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles btnAusschuss.Click
        If myH_Hand = True Then
            Dim pw As New FPassw(8)
            pw.Show()
            pw.BringToFront()
            Me.Enabled = False
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Sub
    'Private Sub btnMotor2_Click(ByVal sender As Object, ByVal e As EventArgs) _
    '   Handles btnMotor2.Click
    '  btnMotor1_Click(sender, e)
    'Add code here to respond to button click. 
    'End Sub

    '******************************************************************
    'Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
    '   Close()
    'End Sub

    'Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Beispiel f�r connection auf main.
    'Try
    'adsClient = New TcAdsClient
    'adsClient.Connect(801)
    'varHandle1 = adsClient.CreateVariableHandle("MAIN.text")
    'varHandle2 = adsClient.CreateVariableHandle("MAIN.PLCVar")
    'varHandle3 = adsClient.CreateVariableHandle("MAIN.PLCVar")
    'twincataktif = True
    'Catch err As Exception
    '   MessageBox.Show(Err.Message)
    '  twincataktif = False
    ' End Try
    'End Sub


    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dataStream = New AdsStream(4)  'Streamlaenge in Byte... hier m�ssen byte dazugerechnet werden bei verlaengerung...
        'Encoding wird auf ASCII gesetzt, um Strings lesen zu k�nnen
        binRead = New BinaryReader(dataStream)

        verbindeSpsVariablen()  ' createVariableHandles mit SPS variablen

        'Setze statuslaempchen von station in die Front damit sie sichtbar sind...
        'station 1
        Me.lblStation1Farbfehler.BringToFront()
        Me.picboxst1farbfehler.BringToFront()
        Me.lblStation1Aktiv.BringToFront()
        Me.picboxst1aktiv.BringToFront()
        Me.Label2.BringToFront()
        Me.lblmyFZ_Farbe.BringToFront()
        'station 2
        Me.lblStation2Laschenabstand.BringToFront()
        Me.picboxst2laschenabstand.BringToFront()
        Me.lblStation2AktivLabstand.BringToFront()
        Me.picboxst2aktivlabstand.BringToFront()
        Me.lblStation2Bolzenhoehe.BringToFront()
        Me.picboxst2bhoehe.BringToFront()
        Me.lblStation2aktivBhoehe.BringToFront()
        Me.picboxst2aktivbhoehe.BringToFront()
        Me.Label3.BringToFront()
        Me.Label5.BringToFront()
        Me.lblmyFZ_Bolzenhoehe.BringToFront()
        Me.lblmyFZ_Laschenabst_1.BringToFront()
        'station 3
        Me.lblStation3Distanz.BringToFront()
        Me.picboxst3distanz.BringToFront()
        Me.lblStation3AktivDistanz.BringToFront()
        Me.picboxst3aktivdistanz.BringToFront()
        Me.Label6.BringToFront()
        Me.lblmyFZ_Laschenabstand_2.BringToFront()
        'station 4
        Me.lbl1.BringToFront()
        Me.lbl2.BringToFront()
        Me.lbl3.BringToFront()
        Me.lbl4.BringToFront()
        Me.lbl5.BringToFront()
        Me.lbl6.BringToFront()
        Me.lblStation4LascheFehler.BringToFront()
        Me.picboxst4laschefehler.BringToFront()
        Me.lblStation4AktivKamera.BringToFront()
        Me.picboxst4aktivkamera.BringToFront()
        Me.lblStation4RolleFehler.BringToFront()
        Me.picboxst4rollefehler.BringToFront()
        Me.Label4.BringToFront()
        Me.lblmyFZ_Lasche_F.BringToFront()
        Me.lblmyFZ_Rolle_F.BringToFront()
        Me.lblmyFZ_Lasche_F_ALU.BringToFront()
        Me.lblmyFZ_Lasche_F_ILO.BringToFront()
        Me.lblmyFZ_Lasche_F_ILU.BringToFront()
        Me.lblmyFZ_Rolle_F_R.BringToFront()
        Me.lblStation4ILascheOFehler.BringToFront()
        Me.lblStation4ILascheUFehler.BringToFront()
        Me.lblStation4LascheFehler.BringToFront()
        Me.lblStation4LascheUFehler.BringToFront()
        Me.lblStation4RolleFehler.BringToFront()
        Me.lblStation4RolleRFehler.BringToFront()
        Me.picboxst4innenlascheofehler.BringToFront()
        Me.picboxst4innenlascheufehler.BringToFront()
        Me.picboxst4lascheufehler.BringToFront()
        Me.picboxst4rollerfehler.BringToFront()

        'station ausschussbehaelter
        Me.lblausschuss.BringToFront()
        Me.Label20.BringToFront()
        Me.picboxausschusszu.BringToFront()
        Me.lblAusschussBehVoll.BringToFront()
        Me.lblAusschussBehFehlt.BringToFront()
        Me.lblmyST_AusschussKetteRaus.BringToFront()

        'btnStation1Farbe.Refresh()
        'btnStation2Laser.Refresh()
        'btnStation3Hoehe.Refresh()
        'btnStation4Kamera.Refresh()
        'Xml configurationsdateien einlesen...oder anlegen...
        'kokevini = New CInileser("/kokev.ini")
        'kettentypenXml = New CXml("/kettentypen.xml")

        Timer1_Tick(Me, e)
        If (twincataktif = True) Then
            LeseTimer.Enabled = True
            LeseTimer_Tick(Me, e) 'lese Variablenwerte aus SPS
        End If

        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then
            strpath = strpath.Substring(6)
            systemCE = True
        End If

        Dim artikel As New FAuftragsverwaltung
        artikel.leseTypdaten()
        Me.lblGliederzahlMain.Text = artikel.tbKlaenge00.Text
        Me.lblAktKettentyp.Text = artikel.textboxBezeichnung.Text
        artikel = Nothing
    End Sub

    Private Sub verbindeSpsVariablen()
        'Instanz der Klasse TcAdsClient erzeugen
        adsClient = New TcAdsClient
        ReDim hConnect(51)  'auch wichtig, immer erweitern!

        'Verbindung mit Port 801 
        Try
            adsClient.Connect(801)
            twincataktif = True

            hConnect(0) = adsClient.CreateVariableHandle(".Not_Aus")
            hConnect(1) = adsClient.CreateVariableHandle(".V_Autogestoppt")
            hConnect(2) = adsClient.CreateVariableHandle(".V_Autogestartet")
            hConnect(3) = adsClient.CreateVariableHandle(".H_Hand")
            hConnect(4) = adsClient.CreateVariableHandle(".REF_IO")
            hConnect(5) = adsClient.CreateVariableHandle(".REF_Enable")
            hConnect(6) = adsClient.CreateVariableHandle(".Stoerunganlage")
            hConnect(7) = adsClient.CreateVariableHandle(".KS1.EnInput")
            hConnect(8) = adsClient.CreateVariableHandle(".KS1.EnOutput")
            hConnect(9) = adsClient.CreateVariableHandle(".KS2.EnInput")
            hConnect(10) = adsClient.CreateVariableHandle(".KS2.EnOutput")
            hConnect(11) = adsClient.CreateVariableHandle(".Fehlerspeicher1")
            hConnect(12) = adsClient.CreateVariableHandle(".Kontrolle_Aktiv")
            hConnect(13) = adsClient.CreateVariableHandle(".S0_Automatik")
            hConnect(14) = adsClient.CreateVariableHandle(".S1_Rueck_1")
            hConnect(15) = adsClient.CreateVariableHandle(".S2_Vor_1")
            hConnect(16) = adsClient.CreateVariableHandle(".S3_Rueck_2")
            hConnect(17) = adsClient.CreateVariableHandle(".S4_Trennen_1")
            hConnect(18) = adsClient.CreateVariableHandle(".S5_Rueck_3")
            hConnect(19) = adsClient.CreateVariableHandle(".S6_Trennen_2")
            hConnect(20) = adsClient.CreateVariableHandle(".Zeiger_Fehler_S1")
            hConnect(21) = adsClient.CreateVariableHandle(".Zeiger_Fehler_S2")
            hConnect(22) = adsClient.CreateVariableHandle(".Zeiger_Fehler_S3")
            hConnect(23) = adsClient.CreateVariableHandle(".Zeiger_Fehler_S4")
            hConnect(24) = adsClient.CreateVariableHandle(".FZ_Farbe")
            hConnect(25) = adsClient.CreateVariableHandle(".FZ_Bolzenhoehe")
            hConnect(26) = adsClient.CreateVariableHandle(".FZ_Laschenabst_1")
            hConnect(27) = adsClient.CreateVariableHandle(".FZ_Laschenabstand_2")
            hConnect(28) = adsClient.CreateVariableHandle(".FZ_Rolle_F")
            hConnect(29) = adsClient.CreateVariableHandle(".FZ_Lasche_F")
            hConnect(30) = adsClient.CreateVariableHandle(".FZ_Gesammt")
            hConnect(31) = adsClient.CreateVariableHandle(".IOZ_Kette")
            hConnect(32) = adsClient.CreateVariableHandle(".FlaechenSp1_IO")
            hConnect(33) = adsClient.CreateVariableHandle(".FlaechenSp2_IO")
            hConnect(34) = adsClient.CreateVariableHandle(".Fehlerspeicher2")
            hConnect(35) = adsClient.CreateVariableHandle(".FZ_Rolle_F_R")
            hConnect(36) = adsClient.CreateVariableHandle(".FZ_Lasche_F_ALU")
            hConnect(37) = adsClient.CreateVariableHandle(".FZ_Lasche_F_ILO")
            hConnect(38) = adsClient.CreateVariableHandle(".FZ_Lasche_F_ILU")
            hConnect(39) = adsClient.CreateVariableHandle(".Dummy_NIO")
            hConnect(40) = adsClient.CreateVariableHandle(".TP_Dummy_Quitt")
            hConnect(41) = adsClient.CreateVariableHandle(".H_KettenAnfang")
            hConnect(42) = adsClient.CreateVariableHandle(".WLaser")
            hConnect(43) = adsClient.CreateVariableHandle(".FZ_PseudoF")
            hConnect(44) = adsClient.CreateVariableHandle(".TP_Klappe")
            hConnect(45) = adsClient.CreateVariableHandle(".Z_Beh")
            hConnect(46) = adsClient.CreateVariableHandle(".ST_Behvoll")
            hConnect(47) = adsClient.CreateVariableHandle(".ST_Behfehlt")
            hConnect(48) = adsClient.CreateVariableHandle(".ST_AusschussKetteRaus")
            hConnect(49) = adsClient.CreateVariableHandle(".Dummy")
            hConnect(50) = adsClient.CreateVariableHandle(".ST_AnfDummyPruefung")
            ' Handle events (1):
            'AddHandler adsClient.AdsNotification, AddressOf OnNotification

        Catch err As Exception
            MessageBox.Show("Keine Verbindung!" & vbCrLf & err.Message)
            adsClient.Dispose()
            twincataktif = False
        End Try
    End Sub

    Private Sub LeseTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeseTimer.Tick
        dataStream.Position = 0
        adsClient.Read(hConnect(0), dataStream)
        myNot_Aus = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(1), dataStream)
        myV_Autogestoppt = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(2), dataStream)
        myV_Autogestartet = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(3), dataStream)
        myH_Hand = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(4), dataStream)
        myREF_IO = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(5), dataStream)
        myREF_Enable = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(6), dataStream)
        myStoerunganlage = binRead.ReadInt16()
        myStoerunganlage_arr = BitsToBooleanArray(myStoerunganlage)

        dataStream.Position = 0
        adsClient.Read(hConnect(7), dataStream)
        myKS1_EnInput = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(8), dataStream)
        myKS1_EnOutput = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(9), dataStream)
        myKS2_EnInput = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(10), dataStream)
        myKS2_EnOutput = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(11), dataStream)
        myFehlerspeicher1 = binRead.ReadInt16()
        myFehlerspeicher1_arr = BitsToBooleanArray(myFehlerspeicher1)

        dataStream.Position = 0
        adsClient.Read(hConnect(12), dataStream)
        myKontrolle_Aktiv = binRead.ReadInt16()
        myKontrolle_Aktiv_arr = BitsToBooleanArray(myKontrolle_Aktiv)

        dataStream.Position = 0
        adsClient.Read(hConnect(13), dataStream)
        myS0_Automatik = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(14), dataStream)
        myS1_Rueck_1 = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(15), dataStream)
        myS2_Vor_1 = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(16), dataStream)
        myS3_Rueck_2 = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(17), dataStream)
        myS4_Trennen_1 = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(18), dataStream)
        myS5_Rueck_3 = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(19), dataStream)
        myS6_Trennen_2 = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(20), dataStream)
        myZeiger_Fehler_S1 = binRead.ReadInt16()
        lblmyZeiger_Fehler_S1.Text = myZeiger_Fehler_S1.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(21), dataStream)
        myZeiger_Fehler_S2 = binRead.ReadInt16()
        lblmyZeiger_Fehler_S2.Text = myZeiger_Fehler_S2.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(22), dataStream)
        myZeiger_Fehler_S3 = binRead.ReadInt16()
        lblmyZeiger_Fehler_S3.Text = myZeiger_Fehler_S3.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(23), dataStream)
        myZeiger_Fehler_S4 = binRead.ReadInt16()
        lblmyZeiger_Fehler_S4.Text = myZeiger_Fehler_S4.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(24), dataStream)
        myFZ_Farbe = binRead.ReadInt16()
        lblmyFZ_Farbe.Text = myFZ_Farbe.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(25), dataStream)
        myFZ_Bolzenhoehe = binRead.ReadInt16()
        lblmyFZ_Bolzenhoehe.Text = myFZ_Bolzenhoehe.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(26), dataStream)
        myFZ_Laschenabst_1 = binRead.ReadInt16()
        lblmyFZ_Laschenabst_1.Text = myFZ_Laschenabst_1.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(27), dataStream)
        myFZ_Laschenabstand_2 = binRead.ReadInt16()
        lblmyFZ_Laschenabstand_2.Text = myFZ_Laschenabstand_2.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(28), dataStream)
        myFZ_Rolle_F = binRead.ReadInt16()
        lblmyFZ_Rolle_F.Text = myFZ_Rolle_F.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(29), dataStream)
        myFZ_Lasche_F = binRead.ReadInt16()
        lblmyFZ_Lasche_F.Text = myFZ_Lasche_F.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(30), dataStream)
        myFZ_Gesammt = binRead.ReadInt16()
        btnKettenNIO.Text = myFZ_Gesammt.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(31), dataStream)
        myIOZ_Kette = binRead.ReadInt16()
        btnKettenIO.Text = myIOZ_Kette.ToString

        ' flaechenspeicherabfrage neu vom 02_04_2008
        dataStream.Position = 0
        adsClient.Read(hConnect(32), dataStream)
        myFlaechenSp1_IO = binRead.ReadBoolean()
        If myFlaechenSp1_IO = True Then
            lblFlaechenSpStatus.Text = "Fl�chenspeicher 1 nicht bereit!"
            lblFlaechenSpStatus.Visible = True
            'Else
            'lblFlaechenSpStatus.Visible = False
        End If

        dataStream.Position = 0
        adsClient.Read(hConnect(33), dataStream)
        myFlaechenSp2_IO = binRead.ReadBoolean()
        If myFlaechenSp2_IO = True Then
            lblFlaechenSpStatus.Text = "Fl�chenspeicher 2 nicht bereit!"
            lblFlaechenSpStatus.Visible = True
            'Else
            'lblFlaechenSpStatus.Visible = False
        End If

        If (myFlaechenSp1_IO = True And myFlaechenSp2_IO = True) Then
            lblFlaechenSpStatus.Text = "Fl�chenspeicher 1 und 2 nicht bereit!"
            lblFlaechenSpStatus.Visible = True
            'Else
            'lblFlaechenSpStatus.Visible = False
        End If

        If myFlaechenSp1_IO = False And myFlaechenSp2_IO = False Then
            lblFlaechenSpStatus.Visible = False
        End If
        ' flaechenspeicher abfrage ende

        dataStream.Position = 0
        adsClient.Read(hConnect(34), dataStream)
        myFehlerspeicher2 = binRead.ReadInt16()
        myFehlerspeicher2_arr = BitsToBooleanArray(myFehlerspeicher2)

        dataStream.Position = 0
        adsClient.Read(hConnect(35), dataStream)
        myFZ_Rolle_F_R = binRead.ReadInt16()
        lblmyFZ_Rolle_F_R.Text = myFZ_Rolle_F_R.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(36), dataStream)
        myFZ_Lasche_F_ALU = binRead.ReadInt16()
        lblmyFZ_Lasche_F_ALU.Text = myFZ_Lasche_F_ALU.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(37), dataStream)
        myFZ_Lasche_F_ILO = binRead.ReadInt16()
        lblmyFZ_Lasche_F_ILO.Text = myFZ_Lasche_F_ILO.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(38), dataStream)
        myFZ_Lasche_F_ILU = binRead.ReadInt16()
        lblmyFZ_Lasche_F_ILU.Text = myFZ_Lasche_F_ILU.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(39), dataStream)
        myDummy_NIO = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(40), dataStream)
        myTP_Dummy_Quitt = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(41), dataStream)
        myH_KettenAnfang = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(42), dataStream)
        myWLaser = binRead.ReadBoolean()
        If (myWLaser = True) Then
            lblWLaser.Visible = True
        Else
            lblWLaser.Visible = False
        End If

        dataStream.Position = 0
        adsClient.Read(hConnect(43), dataStream)
        myFZ_PseudoF = binRead.ReadInt16()
        lblPseudoF.Text = myFZ_PseudoF.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(44), dataStream)
        myTP_Klappe = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(45), dataStream)
        myZ_Beh = binRead.ReadInt16()
        lblausschusszaehler.Text = myZ_Beh.ToString

        dataStream.Position = 0
        adsClient.Read(hConnect(46), dataStream)
        myST_Behvoll = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(47), dataStream)
        myST_Behfehlt = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(48), dataStream)
        myST_AusschussKetteRaus = binRead.ReadBoolean()
        If (myST_AusschussKetteRaus = True) Then
            lblmyST_AusschussKetteRaus.Visible = True
        Else
            lblmyST_AusschussKetteRaus.Visible = False
        End If

        dataStream.Position = 0
        adsClient.Read(hConnect(49), dataStream)
        myDummy = binRead.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(50), dataStream)
        myST_AnfDummyPruefung = binRead.ReadBoolean()

        auswerten()

    End Sub

    'zum lesen der sps variablen bei events...
    Private Sub auswerten()

        '****ende onnotificationeventabfrage********

        If myNot_Aus = True Then
            lblStatusMaschine.Text = "***NOT AUS***"
            lblStatusMaschine.ForeColor = Color.Red
            Me.picboxstatusmaschine.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        End If

        If myV_Autogestoppt = True Then
            lblStatusMaschine.Text = "Automatik gestoppt"
            lblStatusMaschine.ForeColor = Color.FromArgb(200, 200, 20)
            Me.picboxstatusmaschine.Image = CType(resources.GetObject("picboxgelb1.Image"), System.Drawing.Image)
        End If

        If myV_Autogestartet = True Then
            lblStatusMaschine.Text = "Automatik gestartet"
            lblStatusMaschine.ForeColor = Color.YellowGreen
            Me.picboxstatusmaschine.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        If myH_Hand = True Then
            lblStatusMaschine.Text = "Handbedienung"
            lblStatusMaschine.ForeColor = Color.YellowGreen
            Me.picboxstatusmaschine.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        If (myREF_IO = True) And (myREF_Enable = True) Then
            lblFehler.Text = "Referenz OK"
            lblFehler.ForeColor = Color.YellowGreen
            lblFehlerMain.Visible = False
        ElseIf (myREF_IO = False) And (myREF_Enable = True) Then
            lblFehler.Text = "REFERENZFEHLER!!!"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Trennstelle positionieren und Kettenanfangstaste dr�cken!"
            lblFehlerMain.Visible = True
        ElseIf (myREF_IO = False) And (myREF_Enable = False) Then
            lblFehler.Text = "REFERENZFEHLER!!!"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Kette weiter zur�ckfahren!"
            lblFehlerMain.Visible = True
        ElseIf (myREF_IO = True) And (myREF_Enable = False) Then
            lblFehler.Text = "REFERENZFEHLER!!!"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Kette weiter zur�ckfahren!"
            lblFehlerMain.Visible = True
        End If

        'stoerunganlage boolean array checken und status setzen bzw ver�ndern...
        If myStoerunganlage_arr(0) = True Then  'Wenn Sensor Station 3 defekt
            lblFehler.Text = "Sensor Station 3 defekt"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Sensor Station 3 defekt!"
            lblFehlerMain.Visible = True
        End If


        If myStoerunganlage_arr(1) = True Then  'Wenn NotAus ausgeloest
            lblFehler.Text = "NOT AUS"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Not-Aus wurde ausgel�st!"
            lblFehlerMain.Visible = True
        End If

        If myStoerunganlage_arr(2) = True Then 'wenn Schutzhaube offen (an trennstation)
            lblFehler.Text = "Schutzhaube offen!"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Schutzhaube offen!"
            lblFehlerMain.Visible = True
        End If
        If myStoerunganlage_arr(3) = True Then 'wenn Schutzhaube speicher 1 oder 2 offen
            lblFehler.Text = "Schutz Trennstelle!"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Trennstelle Schutz offen!"
            lblFehlerMain.Visible = True
        End If

        If myStoerunganlage_arr(4) = True Then  'Wenn Sensor Station 3 defekt
            lblFehler.Text = "Sensor Station 2 defekt"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Sensor Station 2 defekt!"
            lblFehlerMain.Visible = True
        End If

        If myStoerunganlage_arr(5) = True Then  'Wenn Speicher 2 Laser fehler
            Me.picboxsp2laser.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxsp2laser.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        If myStoerunganlage_arr(6) = True Then  'wenn speicher 1 Laser fehler
            Me.picboxsp1laser.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxsp1laser.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If


        If myStoerunganlage_arr(7) = True Then 'wenn Kupplung Motor 2
            Me.picboxkupplung2.Image = CType(resources.GetObject("picboxrotfett.Image"), System.Drawing.Image)
            lblFehler.Text = "Kupplung M2"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "St�rung Kupplung Motor 2"
            lblFehlerMain.Visible = True
        Else
            Me.picboxkupplung2.Image = CType(resources.GetObject("picboxgruenfett.Image"), System.Drawing.Image)
        End If

        If myStoerunganlage_arr(8) = True Then 'wenn Kupplung Motor 1
            Me.picboxkupplung1.Image = CType(resources.GetObject("picboxrotfett.Image"), System.Drawing.Image)
            lblFehler.Text = "Kupplung M1"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "St�rung Kupplung Motor 1"
            lblFehlerMain.Visible = True
        Else
            Me.picboxkupplung1.Image = CType(resources.GetObject("picboxgruenfett.Image"), System.Drawing.Image)
        End If

        If myStoerunganlage_arr(9) = True Then  'Wenn Kamera Station 4 defekt
            lblFehler.Text = "Kamera Station 4 defekt"
            lblFehler.ForeColor = Color.Red
            lblFehlerMain.Text = "Kamera Station 4 defekt!"
            lblFehlerMain.Visible = True
        End If

        If myStoerunganlage_arr(10) = True Then   ' wenn druckluft aus...
            lbldruckfehler.Text = "St�rung Druckluft!"
            lbldruckfehler.ForeColor = Color.Red
            lbldruckfehler.Visible = True
        Else
            lbldruckfehler.Text = ""
            lbldruckfehler.Visible = False
        End If

        'Speicher 1 und 2 voll oder leer anzeige!
        If myKS1_EnInput = False And myKS1_EnOutput = True Then
            lblSpeicher1status.Text = "Speicher 1 voll!"
            lblSpeicher1status.ForeColor = Color.Blue
            lblSpeicher1status.Visible = True
        ElseIf myKS1_EnInput = True And myKS1_EnOutput = False Then
            lblSpeicher1status.Text = "Speicher 1 leer!"
            lblSpeicher1status.ForeColor = Color.Red
            lblSpeicher1status.Visible = True
        Else
            lblSpeicher1status.Visible = False
        End If

        If myKS2_EnInput = False And myKS2_EnOutput = True Then
            lblSpeicher2status.Text = "Speicher 2 voll!"
            lblSpeicher2status.ForeColor = Color.Blue
            lblSpeicher2status.Visible = True
        ElseIf myKS2_EnInput = True And myKS2_EnOutput = False Then
            lblSpeicher2status.Text = "Speicher 2 leer!"
            lblSpeicher2status.ForeColor = Color.Red
            lblSpeicher2status.Visible = True
        Else
            lblSpeicher2status.Visible = False
        End If

        '********************************************************************************************
        '********************************************************************************************
        '*********Fehlerspeicher1 bit ueberpruefung f�r die Stationen 1 bis 4  **********************
        'Farbsensorfehler Station 1 *****************************************************************
        If myFehlerspeicher1_arr(0) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Farblaschenfehler Station 1 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Farblaschenfehler Station 1") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
            Me.picboxst1farbfehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
            If (btnStation1Farbe.farbwert = 0) Then
                btnStation1Farbe.BackgroundImageValue = MakeBitmap(stationFehlerColorRed, _
                    btnStation1Farbe.Width, btnStation1Farbe.Height)              'Setze auf rot wenn fehler...
                btnStation1Farbe.farbwert = 1
                btnStation1Farbe.Refresh()
            End If
        Else
            Me.picboxst1farbfehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
            If (btnStation1Farbe.farbwert = 1) Then
                btnStation1Farbe.BackgroundImageValue = MakeBitmap(Color.LightGray, _
                    btnStation1Farbe.Width, btnStation1Farbe.Height) 'Setze auf grau wenn kein fehler...
                btnStation1Farbe.farbwert = 0
                btnStation1Farbe.Refresh()
            End If
        End If
        '************************************************************
        '************************************************************
        'Lasersensorfehler L-Abstand Station 2 *********************************
        If myFehlerspeicher1_arr(1) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Laschenabstandfehler (Kettenhoehe) Station 2 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Laschenabstandfehler (Kettenhoehe) Station 2") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
            Me.picboxst2laschenabstand.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst2laschenabstand.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Lasersensorfehler B-Hoehe Station 2 *********************************
        If myFehlerspeicher1_arr(2) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Bolzenhoehenfehler Station 2 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Bolzenhoehenfehler Station 2") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
            Me.picboxst2bhoehe.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst2bhoehe.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Bei mehreren fehlern muss noch �berpr�ft werden ob gesamtfehler existiert f�r jeweilige station,
        'da sonst station nicht rot wird wenn ein fehler ist, aber anderen nicht ist....
        If myFehlerspeicher1_arr(1) = True Or myFehlerspeicher1_arr(2) = True Then
            If btnStation2Laser.farbwert = 0 Then
                btnStation2Laser.BackgroundImageValue = MakeBitmap(stationFehlerColorRed, _
                    btnStation2Laser.Width, btnStation2Laser.Height)  'Setze auf rot wenn fehler...
                btnStation2Laser.farbwert = 1
                btnStation2Laser.Refresh()
            End If

        Else
            If btnStation2Laser.farbwert = 1 Then
                btnStation2Laser.BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnStation2Laser.Width, btnStation2Laser.Height)  'Setze auf grau wenn kein fehler...
                btnStation2Laser.farbwert = 0
                btnStation2Laser.Refresh()
            End If
        End If

        '***********************************************************************
        '***********************************************************************

        'Distanzfehler H�he Station 3 *********************************
        If myFehlerspeicher1_arr(3) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Distanzfehler (Kettenhoehe) Station 3 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Distanzfehler (Kettenhoehe) Station 3") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
                Me.picboxst3distanz.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
                If btnStation3Hoehe.farbwert = 0 Then
                    btnStation3Hoehe.BackgroundImageValue = MakeBitmap(stationFehlerColorRed, _
                        btnStation3Hoehe.Width, btnStation3Hoehe.Height)              'Setze auf rot wenn fehler...
                    btnStation3Hoehe.farbwert = 1
                    btnStation3Hoehe.Refresh()
                End If
            Else
            Me.picboxst3distanz.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
            If btnStation3Hoehe.farbwert = 1 Then
                btnStation3Hoehe.BackgroundImageValue = MakeBitmap(Color.LightGray, _
                    btnStation3Hoehe.Width, btnStation3Hoehe.Height)  'Setze auf rot wenn fehler...
                btnStation3Hoehe.farbwert = 0
                btnStation3Hoehe.Refresh()
            End If
        End If
        '************************************************************
        '************************************************************

        'Kamerafehler AL oben Station 4 *********************************
        If myFehlerspeicher2_arr(1) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Kamera Fehler AL Oben Station 4 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Kamera Fehler AL Oben Station 4") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
            Me.picboxst4laschefehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst4laschefehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Kamerafehler AL unten Station 4 *********************************
        If myFehlerspeicher2_arr(2) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Kamera Fehler AL Unten Station 4 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Kamera Fehler AL Unten Station 4") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
            Me.picboxst4lascheufehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst4lascheufehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Kamerafehler IL oben Station 4 *********************************
        If myFehlerspeicher2_arr(3) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Kamera Fehler IL Oben Station 4 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Kamera Fehler IL Oben Station 4") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
                Me.picboxst4innenlascheofehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
            Else
            Me.picboxst4innenlascheofehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Kamerafehler IL unten Station 4 *********************************
        If myFehlerspeicher2_arr(4) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Kamera Fehler IL Unten Station 4 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Kamera Fehler IL Unten Station 4") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
            Me.picboxst4innenlascheufehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst4innenlascheufehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Kamerafehler Rolle Links Station 4 *********************************
        If myFehlerspeicher2_arr(5) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Kamera Fehler Rolle Links Station 4 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Kamera Fehler Rolle Links Station 4") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
                Me.picboxst4rollefehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
            Else
            Me.picboxst4rollefehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If

        'Kamerafehler Rolle Rechts Station 4 *********************************
        If myFehlerspeicher2_arr(6) = True Then
            If (myS2_Vor_1) Then
                If (myDummy = True) Then
                    Dim f As New CFehlerschreiber("Kamera Fehler Rolle Rechts Station 4 (Dummypr�fung)") 'schreibe in kettenfehler.txt
                    f = Nothing
                Else
                    Dim f As New CFehlerschreiber("Kamera Fehler Rolle Rechts Station 4") 'schreibe in kettenfehler.txt
                    f = Nothing
                End If
            End If
                Me.picboxst4rollerfehler.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
            Else
            Me.picboxst4rollerfehler.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If


        'Bei mehreren fehlern muss noch �berpr�ft werden ob gesamtfehler existiert f�r jeweilige station,
        'da sonst station nicht rot wird wenn ein fehler ist, aber anderen nicht ist....
        If (myFehlerspeicher2_arr(1) Or myFehlerspeicher2_arr(2) Or _
            myFehlerspeicher2_arr(3) Or myFehlerspeicher2_arr(4) Or _
            myFehlerspeicher2_arr(5) Or myFehlerspeicher2_arr(6)) Then
            If btnStation4Kamera.farbwert = 0 Then
                btnStation4Kamera.BackgroundImageValue = MakeBitmap(stationFehlerColorRed, _
                    btnStation4Kamera.Width, btnStation4Kamera.Height)  'Setze auf rot wenn fehler...
                btnStation4Kamera.farbwert = 1
                btnStation4Kamera.Refresh()
            End If

        Else
            If btnStation4Kamera.farbwert = 1 Then
                btnStation4Kamera.BackgroundImageValue = MakeBitmap(Color.LightGray, _
                    btnStation4Kamera.Width, btnStation4Kamera.Height) 'Setze auf grau wenn kein fehler...
                btnStation4Kamera.farbwert = 0
                btnStation4Kamera.Refresh()
            End If
        End If

        '***********************************************************************
        '*********  Fehlerspeicher1 f�r stationen 1 bis 4 ENDE   ***************        

        '***********************************************************************
        '***********  Kontrolle_Aktiv bit ueberpruefung f�r die Stationen 1 bis 4  *********************
        'Kontrolle_Aktiv uberpr�fung Station 1 *********************************
        'Farbsensor aktif oder nicht....
        If myKontrolle_Aktiv_arr(0) = False Then  'wenn pruefung nicht aktiv dann...
            Me.picboxst1aktiv.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst1aktiv.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '************************************************************
        '************************************************************
        'Kontrolle_Aktiv uberpr�fung Station 2 *********************************
        'Lasersensor Laschenabstand aktif oder nicht...
        If myKontrolle_Aktiv_arr(1) = False Then  'wenn pruefung nicht aktiv dann...
            Me.picboxst2aktivlabstand.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst2aktivlabstand.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        'Lasersensor Bolzenhoehe aktif oder nicht....
        If myKontrolle_Aktiv_arr(2) = False Then  'wenn pruefung nicht aktiv dann...
            Me.picboxst2aktivbhoehe.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst2aktivbhoehe.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '************************************************************
        '************************************************************
        'Kontrolle_Aktiv uberpr�fung Station 3 *********************************
        'Lasche Distanz aktif oder nicht ....
        If myKontrolle_Aktiv_arr(3) = False Then  'wenn pruefung nicht aktiv dann...
            Me.picboxst3aktivdistanz.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst3aktivdistanz.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '************************************************************
        '************************************************************
        'Kontrolle_Aktiv uberpr�fung Station 4 *********************************
        'Kamera aktif oder nicht ....
        If myKontrolle_Aktiv_arr(5) = False Then  'wenn pruefung nicht aktiv dann...
            Me.picboxst4aktivkamera.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Else
            Me.picboxst4aktivkamera.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '************************************************************
        '*****Ende kontrolle aktif pruefung**********************************

        '******* Uberpruefung bei fehlern, r�ckfahrt 1 2 und anfang und ende trennen **************
        '******* Normalbetrieb:
        If myS0_Automatik = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox1normalbetrieb.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox1normalbetrieb.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '******* rueck 1:
        If myS1_Rueck_1 = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox2ruck1.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox2ruck1.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '******* 2.Pruefung:
        If myS2_Vor_1 = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox3zweitepruf.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox3zweitepruf.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '******* rueck 2:
        If myS3_Rueck_2 = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox4ruck2.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox4ruck2.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '******* Trenn ende:
        If myS4_Trennen_1 = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox5trennende.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox5trennende.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '******* rueck 3:
        If myS5_Rueck_3 = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox6ruck3.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox6ruck3.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '******* trenn anfang:
        If myS6_Trennen_2 = False Then  'wenn pruefung nicht aktiv dann...
            Me.picbox7trennanfang.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picbox7trennanfang.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        '********** Ende ketten pruefung rueck 1 ... 3 und trennen ende und anfang
        '*****************************************************************************************

        '*********************************************
        'ausschussbehaelter ueberpruefungen:
        If myTP_Klappe = True Then  ' wenn klappe auf dann...
            Me.picboxausschusszu.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Else
            Me.picboxausschusszu.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        End If
        'uberpruefe ob ausschussbehaelter voll oder ausschussbehaelterfehlt
        If myST_Behvoll = True Or myST_Behfehlt = True Then
            If btnAusschuss.farbwert = 0 Then
                btnAusschuss.BackgroundImageValue = MakeBitmap(stationFehlerColorRed, _
                    btnAusschuss.Width, btnAusschuss.Height)  'Setze auf rot wenn fehler...
                btnAusschuss.farbwert = 1
                btnAusschuss.Refresh()
            End If
        Else
            If btnAusschuss.farbwert = 1 Then
                btnAusschuss.BackgroundImageValue = MakeBitmap(Color.LightGray, _
                btnAusschuss.Width, btnAusschuss.Height)  'Setze auf grau wenn kein fehler...
                btnAusschuss.farbwert = 0
                btnAusschuss.Refresh()
            End If
        End If

        If myST_Behvoll = True Then
            lblAusschussBehVoll.Visible = True
        Else
            lblAusschussBehVoll.Visible = False
        End If

        If myST_Behfehlt = True Then
            lblAusschussBehFehlt.Visible = True
        Else
            lblAusschussBehFehlt.Visible = False
        End If

        If myST_AnfDummyPruefung = True Then
            lblmyST_AnfDummyPruefung.Visible = True
        Else
            lblmyST_AnfDummyPruefung.Visible = False
        End If


        'uberpruefung ob beide Flaechenspeicher nicht bereit sind:
        'If (myFlaechenSp1_IO) & (myFlaechenSp2_IO) Then
        'lblFlaechenSpStatus.Text = "Fl�chenspeicher 1 und 2 nicht bereit!"
        'lblFlaechenSpStatus.Visible = True
        'End If

        'IIf(myV_Autogestoppt, lblStatusMaschine.Text = "Automatik gestoppt", lblStatusMaschine.Text = "Automatik laeuft")
        ' tbString.Text = New String(binread.ReadChars(30))
        'tbString.Text = New String(binRead.ReadBoolean.ToString)
        'tbString.Text = New String(Handle1.KettenTyp(0).ToString)
    End Sub

    Public Shared Function BitsToBooleanArray(ByVal value As Short) As Boolean()
        'Array mit boolean-werten aus twincat word (in VB ein Uint16 oder short)
        Dim bits(15) As Boolean
        'bitmaske fuer das unterste Bit
        Dim mask As Short = 1
        'Schleife ueber alle Bits
        For i As Integer = 0 To 15
            'bitwert pr�fen und speichern
            bits(i) = (value And mask) <> 0
            'Maske f�r naechstes bit setzen
            mask <<= 1
        Next
        Return bits
    End Function

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'resourcen freigeben
        adsClient.Dispose()
    End Sub


    'Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
    '    Dim length As Integer
    '    Dim text As String
    '    Dim dataStream As AdsStream
    '    Dim reader As AdsBinaryReader
    '    Try
    '        dataStream = New AdsStream(30)
    '        reader = New AdsBinaryReader(dataStream)
    '        adsClient.Read(varHandle1, dataStream)
    '        TextBox1.Text = reader.ReadPlcString(30)
    '    Catch err As Exception
    '        MessageBox.Show(err.Message)
    '    End Try
    ' End Sub

    'Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
    '   Dim dataStream As AdsStream
    '   Dim writer As AdsBinaryWriter
    '   Try
    '       dataStream = New AdsStream(30)
    '       writer = New AdsBinaryWriter(dataStream)
    '       writer.WritePlcString(TextBox1.Text, 30)
    '       adsClient.Write(varHandle1, dataStream)
    '   Catch err As Exception
    '       MessageBox.Show(err.Message)
    '   End Try
    'End Sub

    'Private Sub btnwriteStruct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnwriteStruct.Click
    '    Dim dataStream As New AdsStream(4)
    '    Dim binWrite As New BinaryWriter(dataStream)

    '    dataStream.Position = 0
    '    Try
    '        binWrite.Write(Short.Parse(tbInt.Text))
    '        binWrite.Write(Boolean.Parse(tbBool.Text))
    '        binWrite.Write(Byte.Parse(tbmerker.Text))
    '        adsClient.Write(varHandle3, dataStream)

    '    Catch err As Exception
    '        MessageBox.Show(err.Message)
    '    End Try
    '
    'Dim dataStream As New AdsStream(3)
    'Dim binwriter As New BinaryWriter(dataStream)
    'dataStream.Position = 0
    'Try
    'binwriter.Write(Integer.Parse(tbInt.Text))
    'binwriter.Write(Boolean.Parse(tbBool.Text))
    'adsClient.Write(varHandle3, dataStream)
    'Catch err As Exception
    '   MessageBox.Show(Err.Message)
    '  End Try
    'End Sub

    'Private Sub btnreadstruct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreadstruct.Click
    '   Dim dataStream As AdsStream
    '  Dim binreader As AdsBinaryReader

    ' Try
    '    dataStream = New AdsStream(3)
    '   binreader = New AdsBinaryReader(dataStream)
    '        adsClient.Read(varHandle2, dataStream)
    '        tbInt.Text = binreader.ReadInt16
    '        tbBool.Text = binreader.ReadByte
    '    Catch err As Exception
    '        MessageBox.Show(err.Message)
    '    End Try
    'End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbldatum.Text = DateTime.Today  'Datum anzeigen
        lblzeit.Text = DateTime.Now.ToLongTimeString  'Uhrzeit anzeigen
        Try

            If adsClient.ReadState.AdsState = AdsState.Run Then
                If (Me.picboxTwincat.Image Is CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)) Then
                    Me.picboxTwincat.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
                Else
                    Me.picboxTwincat.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
                End If
                Me.picboxTcpIp.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)

            Else
                Me.picboxTwincat.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
                Me.picboxTcpIp.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)

            End If
        Catch err As Exception
            Timer1.Enabled = False
            MessageBox.Show("Twincat System nicht bereit!" & vbCrLf & err.Message)
            Me.picboxTwincat.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
            Me.picboxTcpIp.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)
        End Try
    End Sub

    Private Sub btnKettentypen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKettentypen.Click
        If myH_Hand = True Then
            auftragsverw = New FAuftragsverwaltung
            auftragsverw.Show()
            auftragsverw.BringToFront()
            'Me.Enabled = False
        Else
            'Dim mydialog As New FDialog
            'mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            'mydialog.lblmeldung.ForeColor = Color.Black
            'mydialog.BringToFront()
            'mydialog.Show()
            'MsgBox("Nur im Handbetrieb m�glich!")
        End If
    End Sub

    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    'If myStoerunganlage_arr(5) = False Then
    'e.Graphics.FillRectangle(New SolidBrush(Color.Red), 50, 350, 100, 20)
    'End If
    'If myStoerunganlage_arr(6) = False Then
    'e.Graphics.FillRectangle(New SolidBrush(Color.Red), 5, 650, 100, 5)
    'End If
    'MyBase.Refresh()

    'e.Graphics.DrawRectangle(New Pen(Color.Black), 28, 132, 132, 68)
    'e.Graphics.DrawRectangle(New Pen(Color.Black), 300, 52, 132, 68)
    'e.Graphics.DrawRectangle(New Pen(Color.Black), 300, 132, 132, 68)
    ' e.Graphics.FillRectangle(New SolidBrush(Color.Gray), lblPos1Farbe12.Location.X, lblPos1Farbe12.Location.Y + 100, lblPos1Farbe12.Width, lblPos1Farbe12.Height)
    'MyBase.OnPaint(e)
    'End Sub

    Private Sub picboxgruenfett_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxkupplung1.Click
        If myH_Hand = True And IsNothing(motorrichtung1) Then
            motorrichtung1 = New FMotorRichtung
            motorrichtung1.Text = "Motoren Handsteuerung"
            motorrichtung1.Show()
            motorrichtung1.BringToFront()
            Me.Enabled = False
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        End If
    End Sub

    Private Sub picboxrotfett_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxkupplung2.Click
        picboxgruenfett_Click(sender, e)
    End Sub

    Private Sub btnKettenfehler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKettenfehler.Click
        myKettenfehler = New FKettenfehler
        myKettenfehler.Show()
        myKettenfehler.BringToFront()
        Me.Enabled = False
    End Sub

    '******** kettenzaehler NIO nullen
    Private del As Threading.ThreadStart
    Private myFirstThread As Threading.Thread
    'Private Sub btnKettenNIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKettenNIO.Click
    'If (myFirstThread Is Nothing) Then
    'btnNIOruecksetz.Visible = True
    'btnNIOruecksetz.Enabled = True
    'btnNIOruecksetz.BringToFront()
    'btnNIOnotRuecksetz.Visible = True
    'btnNIOnotRuecksetz.Enabled = True
    'btnNIOnotRuecksetz.BringToFront()
    'del = New Threading.ThreadStart(AddressOf buttonthread1)
    'myFirstThread = New Threading.Thread(del)
    'myFirstThread.Start()
    'End If
    'End Sub
    'Public Sub buttonthread1()
    'myFirstThread.Sleep(2000)  'disable buttons nach 2 sec
    'btnNIOruecksetz.Visible = False
    'btnNIOruecksetz.Enabled = False
    'btnNIOnotRuecksetz.Visible = False
    'btnNIOnotRuecksetz.Enabled = False
    'myFirstThread = Nothing
    'del = Nothing
    'End Sub
    'Private Sub btnNIOnotRuecksetz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNIOnotRuecksetz.Click
    'btnNIOruecksetz.Visible = False
    'btnNIOruecksetz.Enabled = False
    'btnNIOnotRuecksetz.Visible = False
    'btnNIOnotRuecksetz.Enabled = False
    'End Sub

    'Private Sub btnNIOruecksetz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNIOruecksetz.Click
    'End Sub

    '***** kettenzaehler IO ketten nullen
    Private Sub btnKettenIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKettenIO.Click
        If (myFirstThread Is Nothing) Then
            btnIOruecksetz.Visible = True
            btnIOruecksetz.Enabled = True
            btnIOruecksetz.BringToFront()
            btnIOnotRuecksetz.Visible = True
            btnIOnotRuecksetz.Enabled = True
            btnIOnotRuecksetz.BringToFront()
            del = New Threading.ThreadStart(AddressOf buttonthread2)
            myFirstThread = New Threading.Thread(del)
            myFirstThread.Start()
        End If
    End Sub
    Public Sub buttonthread2()
        myFirstThread.Sleep(2000)  'disable buttons nach 2 sec
        btnIOruecksetz.Visible = False
        btnIOruecksetz.Enabled = False
        btnIOnotRuecksetz.Visible = False
        btnIOnotRuecksetz.Enabled = False
        myFirstThread = Nothing
        del = Nothing
    End Sub

    Private Sub btnIOnotRuecksetz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIOnotRuecksetz.Click
        btnIOruecksetz.Visible = False
        btnIOruecksetz.Enabled = False
        btnIOnotRuecksetz.Visible = False
        btnIOnotRuecksetz.Enabled = False
    End Sub

    Private Sub btnIOruecksetz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIOruecksetz.Click
        Dim vh_0 As Integer
        Dim vh_1 As Integer
        Dim vh_2 As Integer
        Dim vh_3 As Integer
        Dim vh_4 As Integer
        Dim vh_5 As Integer
        Dim vh_6 As Integer
        Dim vh_7 As Integer
        Dim vh_8 As Integer
        Dim vh_9 As Integer
        Dim vh_10 As Integer
        Dim vh_11 As Integer
        Dim vh_12 As Integer
        Dim sh As Short = 0
        Try
            vh_0 = adsClient.CreateVariableHandle(".IOZ_Kette")
            vh_1 = adsClient.CreateVariableHandle(".FZ_Gesammt")
            vh_2 = adsClient.CreateVariableHandle(".FZ_Farbe")
            vh_3 = adsClient.CreateVariableHandle(".FZ_Bolzenhoehe")
            vh_4 = adsClient.CreateVariableHandle(".FZ_Laschenabst_1")
            vh_5 = adsClient.CreateVariableHandle(".FZ_Laschenabstand_2")
            vh_6 = adsClient.CreateVariableHandle(".FZ_Rolle_F")
            vh_7 = adsClient.CreateVariableHandle(".FZ_Lasche_F")
            vh_8 = adsClient.CreateVariableHandle(".FZ_Lasche_F_ALU")
            vh_9 = adsClient.CreateVariableHandle(".FZ_Lasche_F_ILO")
            vh_10 = adsClient.CreateVariableHandle(".FZ_Lasche_F_ILU")
            vh_11 = adsClient.CreateVariableHandle(".FZ_Rolle_F_R")
            vh_12 = adsClient.CreateVariableHandle(".FZ_PseudoF")
            adsClient.WriteAny(vh_0, sh)
            adsClient.WriteAny(vh_1, sh)
            adsClient.WriteAny(vh_2, sh)
            adsClient.WriteAny(vh_3, sh)
            adsClient.WriteAny(vh_4, sh)
            adsClient.WriteAny(vh_5, sh)
            adsClient.WriteAny(vh_6, sh)
            adsClient.WriteAny(vh_7, sh)
            adsClient.WriteAny(vh_8, sh)
            adsClient.WriteAny(vh_9, sh)
            adsClient.WriteAny(vh_10, sh)
            adsClient.WriteAny(vh_11, sh)
            adsClient.WriteAny(vh_12, sh)
            adsClient.DeleteVariableHandle(vh_0)
            adsClient.DeleteVariableHandle(vh_1)
            adsClient.DeleteVariableHandle(vh_2)
            adsClient.DeleteVariableHandle(vh_3)
            adsClient.DeleteVariableHandle(vh_4)
            adsClient.DeleteVariableHandle(vh_5)
            adsClient.DeleteVariableHandle(vh_6)
            adsClient.DeleteVariableHandle(vh_7)
            adsClient.DeleteVariableHandle(vh_8)
            adsClient.DeleteVariableHandle(vh_9)
            adsClient.DeleteVariableHandle(vh_10)
            adsClient.DeleteVariableHandle(vh_11)
            adsClient.DeleteVariableHandle(vh_12)
        Catch err As Exception
            MessageBox.Show(err.Message & "---" & "Z�hler konnten nicht genullt werden")
        End Try
        vh_0 = Nothing
        vh_1 = Nothing
        vh_2 = Nothing
        vh_3 = Nothing
        vh_4 = Nothing
        vh_5 = Nothing
        vh_6 = Nothing
        vh_7 = Nothing
        vh_8 = Nothing
        vh_9 = Nothing
        vh_10 = Nothing
        vh_11 = Nothing
        vh_12 = Nothing
        sh = Nothing
    End Sub
    '***** kettenzaehler IO nullen ende*************
    '*****************************************************************
    '***** auswahl ketten typ ueber hauptform ************************
    Private Sub btnArtikelnummer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArtikelnummer.Click
        If listboxArtikelnr.Enabled = True And myH_Hand = True Then
            auftragsverw = New FAuftragsverwaltung
            auftragsverw.Show()
            auftragsverw.BringToFront()
            listboxArtikelnr.Visible = False
            listboxArtikelnr.Enabled = False
            btnArtikelnrEsc.Visible = False
            btnArtikelnrEsc.Enabled = False
        Else
            listboxArtikelnr.Visible = True
            listboxArtikelnr.Enabled = True
            btnArtikelnrEsc.Visible = True
            btnArtikelnrEsc.Enabled = True
            listboxArtikelnr.Items.Clear()
            leseVerzeichnis()
            listboxArtikelnr.BringToFront()
            btnArtikelnrEsc.BringToFront()
        End If
    End Sub
    Public Sub leseVerzeichnis()
        Try
            Dim dname As String = ""
            Dim mydir As New DirectoryInfo(Me.strpath & "\AV\")
            Dim myFiles() As FileInfo
            myFiles = mydir.GetFiles()
            For i As Integer = 0 To myFiles.Length - 1
                dname = myFiles(i).Name.Remove(8, 4)  'schneide die dateiendung .art raus
                listboxArtikelnr.Items.Add(dname)
            Next
            mydir = Nothing
            myFiles = Nothing
        Catch err As Exception
            MsgBox("Keine Ketten-Artikel Datei vorhanden! Bitte zuerst eine Artikelnummer �ber Auftragverwaltung anlegen!")
        End Try
    End Sub
    Public artikelno As String
    Public artikel As String
    Public mydialog As FDialog
    Public Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listboxArtikelnr.SelectedIndexChanged
        artikelno = ""
        artikel = ""
        artikel = listboxArtikelnr.Items(listboxArtikelnr.SelectedIndex)
        artikelno = artikel & ".art"   'fuege die dateiendung .art ein f�r dateisuche
        artikelno = strpath & "\AV\" & artikelno
        If ((myH_Hand = False) And (myH_KettenAnfang = False) And (myDummy_NIO = True)) Then
            mydialog = New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.lblmeldung2.Text = "Kettenanfang nicht eingerichtet!"
            mydialog.lblmeldung2.Visible = True
            mydialog.lblmeldung3.Text = "Dummypr�fung erfolglos! Segment verst�ndigen!"
            mydialog.lblmeldung3.Visible = True
            mydialog.BringToFront()
            mydialog.Show()
        ElseIf ((myH_Hand = False) And (myH_KettenAnfang = False)) Then
            mydialog = New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.lblmeldung2.Text = "Kettenanfang nicht eingerichtet!"
            mydialog.lblmeldung2.Visible = True
            mydialog.BringToFront()
            mydialog.Show()
        ElseIf (myH_Hand = False) Then
            mydialog = New FDialog
            mydialog.lblmeldung.Text = "Nur im Handbetrieb m�glich!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.BringToFront()
            mydialog.Show()
        ElseIf (myH_KettenAnfang = False) Then
            mydialog = New FDialog
            mydialog.lblmeldung2.Text = "Kettenanfang nicht eingerichtet!"
            mydialog.lblmeldung2.ForeColor = Color.Black
            mydialog.lblmeldung2.Visible = True
            mydialog.BringToFront()
            mydialog.Show()
        ElseIf (myDummy_NIO = True) Then
            mydialog = New FDialog
            mydialog.lblmeldung.Text = "Dummypr�fung erfolglos!"
            mydialog.lblmeldung.ForeColor = Color.Black
            mydialog.lblmeldung2.Text = "Segment verst�ndigen!"
            mydialog.lblmeldung2.ForeColor = Color.Black
            mydialog.lblmeldung2.Visible = True
            mydialog.btnDummyQuit.Enabled = True
            mydialog.btnDummyQuit.Visible = True
            mydialog.BringToFront()
            mydialog.Show()
        Else
            kettentypwechseln()
        End If

    End Sub
    Public Sub kettentypwechseln()
        If Not (mydialog Is Nothing) Then
            Me.mydialog.Close()
        End If

        If File.Exists(artikelno) = True Then
            Dim bezeichnung As String = ""
            Dim kettenlaenge As Short = 0
            Dim pos1 As Short = 0
            Dim farbe1 As Short = 0
            Dim pos2 As Short = 0
            Dim farbe2 As Short = 0
            Dim pos3 As Short = 0
            Dim farbe3 As Short = 0
            Dim pos4 As Short = 0
            Dim farbe4 As Short = 0
            Dim pos5 As Short = 0
            Dim farbe5 As Short = 0
            Dim objDateiLeser As StreamReader
            objDateiLeser = New StreamReader(artikelno)
            bezeichnung = objDateiLeser.ReadLine
            kettenlaenge = objDateiLeser.ReadLine
            pos1 = objDateiLeser.ReadLine
            farbe1 = objDateiLeser.ReadLine
            pos2 = objDateiLeser.ReadLine
            farbe2 = objDateiLeser.ReadLine
            pos3 = objDateiLeser.ReadLine
            farbe3 = objDateiLeser.ReadLine
            pos4 = objDateiLeser.ReadLine
            farbe4 = objDateiLeser.ReadLine
            pos5 = objDateiLeser.ReadLine
            farbe5 = objDateiLeser.ReadLine
            objDateiLeser.Close()
            objDateiLeser = Nothing

            Dim vh_artikelnr As Integer
            Dim vh_artikelstring As Integer
            Dim vHandleKettentyp As Integer
            Dim dataStream As New AdsStream(22) 'fuer kettentypen array
            Dim stringstream As New AdsStream(20) 'f�r bezeichnerstring
            Dim writer As New AdsBinaryWriter(stringstream)  'fuer string
            Dim binWrite As New BinaryWriter(dataStream)     'fuer array
            dataStream.Position = 0
            Try
                vh_artikelnr = adsClient.CreateVariableHandle(".ArtikelNr")
                vh_artikelstring = adsClient.CreateVariableHandle(".ArtikelString")
                vHandleKettentyp = adsClient.CreateVariableHandle(".KettenTyp")
                adsClient.WriteAny(vh_artikelnr, Integer.Parse(artikel))
                writer.WritePlcString(bezeichnung, 20)
                adsClient.Write(vh_artikelstring, stringstream)
                'da in der sps zuerst die farbe steht, ist hier der speicher ablauf zuerst farbe, dann farbposition.
                binWrite.Write(kettenlaenge)
                binWrite.Write(farbe1)
                binWrite.Write(pos1)
                binWrite.Write(farbe2)
                binWrite.Write(pos2)
                binWrite.Write(farbe3)
                binWrite.Write(pos3)
                binWrite.Write(farbe4)
                binWrite.Write(pos4)
                binWrite.Write(farbe5)
                binWrite.Write(pos5)
                adsClient.Write(vHandleKettentyp, dataStream)

                adsClient.DeleteVariableHandle(vHandleKettentyp)
                adsClient.DeleteVariableHandle(vh_artikelnr)
                adsClient.DeleteVariableHandle(vh_artikelstring)
                btnArtikelnummer.Text = artikel
                lblAktKettentyp.Text = bezeichnung
                lblGliederzahlMain.Text = kettenlaenge.ToString

                Dim mydialog As New FDialog
                mydialog.lblmeldung.Text = "Kettentyp wurde gewechselt!"
                mydialog.lblmeldung.ForeColor = Color.Black
                mydialog.BringToFront()
                mydialog.Show()

            Catch err As Exception
                MessageBox.Show(err.Message & "---" & "fehler beim schreiben in SPS")
            End Try
            vh_artikelnr = Nothing
            vh_artikelstring = Nothing
            writer = Nothing
            dataStream = Nothing
            stringstream = Nothing

        Else
            MsgBox("datei existiert nicht" & "   " & artikelno)
        End If
        listboxArtikelnr.Visible = False
        listboxArtikelnr.Enabled = False
        btnArtikelnrEsc.Visible = False
        btnArtikelnrEsc.Enabled = False
    End Sub

    Public Sub dummyquittieren()
        Dim vh_1 As Integer
        Dim quittierer As Boolean = True
        Try
            vh_1 = adsClient.CreateVariableHandle(".TP_Dummy_Quitt")
            adsClient.WriteAny(vh_1, quittierer)
            System.Threading.Thread.Sleep(500)
            quittierer = False
            adsClient.WriteAny(vh_1, quittierer)
            adsClient.DeleteVariableHandle(vh_1)
            kettentypwechseln()
            Me.Enabled = True
        Catch err As Exception
            MessageBox.Show(err.Message & "---" & "Dummy konnte nicht quittiert werden!")
        End Try
        vh_1 = Nothing
    End Sub

    Private Sub btnArtikelnrEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArtikelnrEsc.Click
        listboxArtikelnr.Visible = False
        listboxArtikelnr.Enabled = False
        btnArtikelnrEsc.Visible = False
        btnArtikelnrEsc.Enabled = False
    End Sub


    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Me.Close()
    End Sub

    'Private Sub btnBehaelterSchliessen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '   Dim vh As Integer
    '    Dim _bool As Boolean = False
    '    Try
    '        vh = adsClient.CreateVariableHandle(".TP_Klappe")
    '        adsClient.WriteAny(vh, _bool)
    '        adsClient.DeleteVariableHandle(vh)
    '    Catch err As Exception
    '        MessageBox.Show(err.Message & "---" & "Ausschussbeh�lter Klappe konnte nicht geschlossen werden!")
    '    End Try
    '    vh = Nothing
    '    _bool = Nothing

    'btnBehaelterOeffnen.Visible = False
    'btnBehaelterOeffnen.Enabled = False
    'btnBehaelterSchliessen.Visible = False
    'btnBehaelterSchliessen.Enabled = False
    'End Sub

    Public Sub behaelteroeffnen()
        Dim vh As Integer
        Dim _bool As Boolean = True
        Try
            vh = adsClient.CreateVariableHandle(".TP_Klappe")
            adsClient.WriteAny(vh, _bool)
            adsClient.DeleteVariableHandle(vh)
        Catch err As Exception
            MessageBox.Show(err.Message & "---" & "Ausschussbeh�lter Klappe konnte nicht ge�ffnet werden!")
        End Try
        vh = Nothing
        _bool = Nothing
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        MessageBox.Show("Version: 09042008" & vbCrLf & "IWIS TCM" & vbCrLf & "Programmierung" & vbCrLf & "Visu: SY" & vbCrLf & "SPS: MK")
    End Sub
End Class
