Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung


Public Class FKettenfehler
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        'Beliebige Initialisierung nach dem InitializeComponent()-Aufruf hinzufügen

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lboxFehlerGesamt As System.Windows.Forms.ListBox
    Friend WithEvents lboxFehlerAktuell As System.Windows.Forms.ListBox
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Rolle_F As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Rolle_F_R As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Lasche_F_ILO As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Lasche_F As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Lasche_F_ALU As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblRIOZ_Kette As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Gesammt As System.Windows.Forms.Label
    Friend WithEvents bntNullen As System.Windows.Forms.Button
    Friend WithEvents lblRFZ_Farbe As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Bolzenhoehe As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Laschenabst_1 As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Laschenabstand_2 As System.Windows.Forms.Label
    Friend WithEvents lblRFZ_Lasche_F_ILU As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.lboxFehlerGesamt = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lboxFehlerAktuell = New System.Windows.Forms.ListBox
        Me.btnESC = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblRFZ_Farbe = New System.Windows.Forms.Label
        Me.lblRFZ_Bolzenhoehe = New System.Windows.Forms.Label
        Me.lblRFZ_Laschenabst_1 = New System.Windows.Forms.Label
        Me.lblRFZ_Laschenabstand_2 = New System.Windows.Forms.Label
        Me.lblRFZ_Rolle_F = New System.Windows.Forms.Label
        Me.lblRFZ_Rolle_F_R = New System.Windows.Forms.Label
        Me.lblRFZ_Lasche_F_ILO = New System.Windows.Forms.Label
        Me.lblRFZ_Lasche_F_ILU = New System.Windows.Forms.Label
        Me.lblRFZ_Lasche_F = New System.Windows.Forms.Label
        Me.lblRFZ_Lasche_F_ALU = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblRIOZ_Kette = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblRFZ_Gesammt = New System.Windows.Forms.Label
        Me.bntNullen = New System.Windows.Forms.Button
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Size = New System.Drawing.Size(184, 24)
        Me.Label1.Text = "Kettenfehler (Gesamt)"
        '
        'lboxFehlerGesamt
        '
        Me.lboxFehlerGesamt.Location = New System.Drawing.Point(6, 36)
        Me.lboxFehlerGesamt.Size = New System.Drawing.Size(1008, 444)
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 483)
        Me.Label2.Size = New System.Drawing.Size(184, 24)
        Me.Label2.Text = "letzter Kettenfehler"
        '
        'lboxFehlerAktuell
        '
        Me.lboxFehlerAktuell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lboxFehlerAktuell.Location = New System.Drawing.Point(6, 507)
        Me.lboxFehlerAktuell.Size = New System.Drawing.Size(1008, 42)
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnESC.Location = New System.Drawing.Point(807, 3)
        Me.btnESC.Size = New System.Drawing.Size(207, 30)
        Me.btnESC.Text = "ESC"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(246, 603)
        Me.Label5.Size = New System.Drawing.Size(135, 18)
        Me.Label5.Text = "Laschenabstand 1 :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(27, 579)
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.Text = "Farbsensor :"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(246, 579)
        Me.Label4.Size = New System.Drawing.Size(135, 18)
        Me.Label4.Text = "Bolzenhöhe :"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(510, 579)
        Me.Label6.Size = New System.Drawing.Size(135, 18)
        Me.Label6.Text = "Laschenabstand 2 :"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(774, 675)
        Me.Label7.Size = New System.Drawing.Size(114, 18)
        Me.Label7.Text = "Rolle links :"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(774, 699)
        Me.Label8.Size = New System.Drawing.Size(114, 18)
        Me.Label8.Text = "Rolle rechts :"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(774, 627)
        Me.Label9.Size = New System.Drawing.Size(114, 18)
        Me.Label9.Text = "IL oben :"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(774, 651)
        Me.Label10.Size = New System.Drawing.Size(114, 18)
        Me.Label10.Text = "IL unten :"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(774, 579)
        Me.Label11.Size = New System.Drawing.Size(114, 18)
        Me.Label11.Text = "AL oben :"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(774, 603)
        Me.Label12.Size = New System.Drawing.Size(114, 18)
        Me.Label12.Text = "AL unten :"
        '
        'lblRFZ_Farbe
        '
        Me.lblRFZ_Farbe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Farbe.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Farbe.Location = New System.Drawing.Point(120, 579)
        Me.lblRFZ_Farbe.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Farbe.Text = "0000"
        '
        'lblRFZ_Bolzenhoehe
        '
        Me.lblRFZ_Bolzenhoehe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Bolzenhoehe.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Bolzenhoehe.Location = New System.Drawing.Point(384, 579)
        Me.lblRFZ_Bolzenhoehe.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Bolzenhoehe.Text = "0000"
        '
        'lblRFZ_Laschenabst_1
        '
        Me.lblRFZ_Laschenabst_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Laschenabst_1.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Laschenabst_1.Location = New System.Drawing.Point(384, 603)
        Me.lblRFZ_Laschenabst_1.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Laschenabst_1.Text = "0000"
        '
        'lblRFZ_Laschenabstand_2
        '
        Me.lblRFZ_Laschenabstand_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Laschenabstand_2.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Laschenabstand_2.Location = New System.Drawing.Point(648, 579)
        Me.lblRFZ_Laschenabstand_2.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Laschenabstand_2.Text = "0000"
        '
        'lblRFZ_Rolle_F
        '
        Me.lblRFZ_Rolle_F.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Rolle_F.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Rolle_F.Location = New System.Drawing.Point(891, 675)
        Me.lblRFZ_Rolle_F.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Rolle_F.Text = "0000"
        '
        'lblRFZ_Rolle_F_R
        '
        Me.lblRFZ_Rolle_F_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Rolle_F_R.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Rolle_F_R.Location = New System.Drawing.Point(891, 699)
        Me.lblRFZ_Rolle_F_R.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Rolle_F_R.Text = "0000"
        '
        'lblRFZ_Lasche_F_ILO
        '
        Me.lblRFZ_Lasche_F_ILO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Lasche_F_ILO.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Lasche_F_ILO.Location = New System.Drawing.Point(891, 627)
        Me.lblRFZ_Lasche_F_ILO.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Lasche_F_ILO.Text = "0000"
        '
        'lblRFZ_Lasche_F_ILU
        '
        Me.lblRFZ_Lasche_F_ILU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Lasche_F_ILU.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Lasche_F_ILU.Location = New System.Drawing.Point(891, 651)
        Me.lblRFZ_Lasche_F_ILU.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Lasche_F_ILU.Text = "0000"
        '
        'lblRFZ_Lasche_F
        '
        Me.lblRFZ_Lasche_F.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Lasche_F.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Lasche_F.Location = New System.Drawing.Point(891, 579)
        Me.lblRFZ_Lasche_F.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Lasche_F.Text = "0000"
        '
        'lblRFZ_Lasche_F_ALU
        '
        Me.lblRFZ_Lasche_F_ALU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Lasche_F_ALU.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Lasche_F_ALU.Location = New System.Drawing.Point(891, 603)
        Me.lblRFZ_Lasche_F_ALU.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Lasche_F_ALU.Text = "0000"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(246, 663)
        Me.Label13.Size = New System.Drawing.Size(90, 18)
        Me.Label13.Text = "Anzahl IO:"
        '
        'lblRIOZ_Kette
        '
        Me.lblRIOZ_Kette.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRIOZ_Kette.ForeColor = System.Drawing.Color.Red
        Me.lblRIOZ_Kette.Location = New System.Drawing.Point(339, 663)
        Me.lblRIOZ_Kette.Size = New System.Drawing.Size(105, 18)
        Me.lblRIOZ_Kette.Text = "0000"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(246, 687)
        Me.Label14.Size = New System.Drawing.Size(90, 18)
        Me.Label14.Text = "Anzahl NIO:"
        '
        'lblRFZ_Gesammt
        '
        Me.lblRFZ_Gesammt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRFZ_Gesammt.ForeColor = System.Drawing.Color.Red
        Me.lblRFZ_Gesammt.Location = New System.Drawing.Point(339, 687)
        Me.lblRFZ_Gesammt.Size = New System.Drawing.Size(105, 18)
        Me.lblRFZ_Gesammt.Text = "0000"
        '
        'bntNullen
        '
        Me.bntNullen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.bntNullen.Location = New System.Drawing.Point(27, 663)
        Me.bntNullen.Size = New System.Drawing.Size(201, 39)
        Me.bntNullen.Text = "Zähler nullen!"
        '
        'FKettenfehler
        '
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(1020, 731)
        Me.ControlBox = False
        Me.Controls.Add(Me.bntNullen)
        Me.Controls.Add(Me.lblRFZ_Gesammt)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblRIOZ_Kette)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblRFZ_Lasche_F_ALU)
        Me.Controls.Add(Me.lblRFZ_Lasche_F)
        Me.Controls.Add(Me.lblRFZ_Lasche_F_ILU)
        Me.Controls.Add(Me.lblRFZ_Lasche_F_ILO)
        Me.Controls.Add(Me.lblRFZ_Rolle_F_R)
        Me.Controls.Add(Me.lblRFZ_Rolle_F)
        Me.Controls.Add(Me.lblRFZ_Laschenabstand_2)
        Me.Controls.Add(Me.lblRFZ_Laschenabst_1)
        Me.Controls.Add(Me.lblRFZ_Bolzenhoehe)
        Me.Controls.Add(Me.lblRFZ_Farbe)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lboxFehlerAktuell)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lboxFehlerGesamt)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Kettenfehler"

    End Sub

#End Region

    Public passwortOK As Boolean = False
    Public myRIOZ_Kette As Short
    Public myRFZ_Farbe As Short
    Public myRFZ_Bolzenhoehe As Short
    Public myRFZ_Laschenabst_1 As Short
    Public myRFZ_Laschenabstand_2 As Short
    Public myRFZ_Rolle_F As Short
    Public myRFZ_Rolle_F_R As Short
    Public myRFZ_Lasche_F As Short
    Public myRFZ_Lasche_F_ALU As Short
    Public myRFZ_Lasche_F_ILO As Short
    Public myRFZ_Lasche_F_ILU As Short
    Public myRFZ_Gesammt As Short
    Public vh(11) As Integer  'handle zur sps

    Public strpath As String = ""
    Public dateipfad As String = "/Kettenfehler.txt"
    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click

        AppMgr.frm1.Enabled() = True
        Me.Close()
    End Sub

    Private Sub FKettenfehler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then  'hier nur überprüfung zum compilieren auf laptop.
            strpath = strpath.Substring(6)
        End If
        If File.Exists(strpath & dateipfad) Then
            Dim sR As New StreamReader(strpath & dateipfad)
            Dim sRR As New StreamReader(strpath & dateipfad)
            Dim line As String, temp As String = ""
            Dim textlaenge As Integer = 0
            Dim i As Integer = 0

            Do Until sRR.Peek = -1   'laenge ermitteln für die anzeige.
                line = sRR.ReadLine()
                textlaenge = textlaenge + 1
            Loop
            sRR.Close()

            Do Until sR.Peek = -1
                i = i + 1
                line = sR.ReadLine()
                If (i > (textlaenge - 50)) Then
                    lboxFehlerGesamt.Items.Insert(0, line)  'füge an erster stelle ein damit aktuellster fehler oben ist.
                End If
            Loop
            sR.Close()
            If (line <> "") Then
                lboxFehlerAktuell.Items.Add(line)
            Else
                lboxFehlerAktuell.Items.Add("Kettenfehlerdatei ist leer!")
            End If
        Else
            Dim sw As StreamWriter
            sw = New StreamWriter(strpath & dateipfad, False)  'mit false wird neue datei erstellt...
            sw.Close()
            lboxFehlerAktuell.Items.Add("Kettenfehlerdatei ist leer!")
            lboxFehlerGesamt.Items.Add("Kettenfehlerdatei ist leer!")
        End If
        'MsgBox("ausgabe ist: " & line)
        'Me.Refresh()

        Me.einlesen()

       
    End Sub

    Public Sub bntNullen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNullen.Click
        Dim passwortcheck As New FPassw(5)
        passwortcheck.Show()
        passwortcheck.BringToFront()
        Me.Enabled = False
        Me.nullen()

    End Sub
    Public Sub nullen()
        If passwortOK = True Then
            Dim sh As Short = 0
            Try
                AppMgr.frm1.adsClient.WriteAny(vh(0), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(1), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(2), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(3), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(4), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(5), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(6), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(7), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(8), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(9), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(10), sh)
                AppMgr.frm1.adsClient.WriteAny(vh(11), sh)
                Me.einlesen()
            Catch err As Exception
                MessageBox.Show(err.Message & vbCr & "fehler bei der verbindung oder kein handle verfügbar!")
            End Try
        End If
    End Sub

    Public Sub einlesen()
        Try
            vh(0) = AppMgr.frm1.adsClient.CreateVariableHandle(".RIOZ_Kette")
            vh(1) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Farbe")
            vh(2) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Bolzenhoehe")
            vh(3) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Laschenabst_1")
            vh(4) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Laschenabstand_2")
            vh(5) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Rolle_F")
            vh(6) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Rolle_F_R")
            vh(7) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Lasche_F")
            vh(8) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Lasche_F_ALU")
            vh(9) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Lasche_F_ILO")
            vh(10) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Lasche_F_ILU")
            vh(11) = AppMgr.frm1.adsClient.CreateVariableHandle(".RFZ_Gesammt")

            lblRIOZ_Kette.Text = AppMgr.frm1.adsClient.ReadAny(vh(0), GetType(Short)).ToString
            lblRFZ_Farbe.Text = AppMgr.frm1.adsClient.ReadAny(vh(1), GetType(Short)).ToString
            lblRFZ_Bolzenhoehe.Text = AppMgr.frm1.adsClient.ReadAny(vh(2), GetType(Short)).ToString
            lblRFZ_Laschenabst_1.Text = AppMgr.frm1.adsClient.ReadAny(vh(3), GetType(Short)).ToString
            lblRFZ_Laschenabstand_2.Text = AppMgr.frm1.adsClient.ReadAny(vh(4), GetType(Short)).ToString
            lblRFZ_Rolle_F.Text = AppMgr.frm1.adsClient.ReadAny(vh(5), GetType(Short)).ToString
            lblRFZ_Rolle_F_R.Text = AppMgr.frm1.adsClient.ReadAny(vh(6), GetType(Short)).ToString
            lblRFZ_Lasche_F.Text = AppMgr.frm1.adsClient.ReadAny(vh(7), GetType(Short)).ToString
            lblRFZ_Lasche_F_ALU.Text = AppMgr.frm1.adsClient.ReadAny(vh(8), GetType(Short)).ToString
            lblRFZ_Lasche_F_ILO.Text = AppMgr.frm1.adsClient.ReadAny(vh(9), GetType(Short)).ToString
            lblRFZ_Lasche_F_ILU.Text = AppMgr.frm1.adsClient.ReadAny(vh(10), GetType(Short)).ToString
            lblRFZ_Gesammt.Text = AppMgr.frm1.adsClient.ReadAny(vh(11), GetType(Short)).ToString

        Catch err As Exception
            MessageBox.Show(err.Message & vbCr & "fehler bei der verbindung oder kein handle verfügbar!")
        End Try
    End Sub

End Class
