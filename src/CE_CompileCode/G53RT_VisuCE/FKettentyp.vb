Imports System
Imports System.IO
Imports System.Xml
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung


Public Class FKettentyp
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

        farblaschen(0, 0) = lblPos1Farbe02
        farblaschen(0, 1) = lblPos2Farbe04
        farblaschen(0, 2) = lblPos3Farbe06
        farblaschen(0, 3) = lblPos4Farbe08
        farblaschen(0, 4) = lblPos5Farbe010
       




        With farblaschen(0, 0)
            .myx = 10
            .myy = 100
            .Parent = Me
            .Bounds = New Rectangle(10, 100, 30, 30)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(0, 0).Width, farblaschen(0, 0).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(0, 0).Width, farblaschen(0, 0).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(0, 1)
            .myx = 50
            .myy = 100
            .Parent = Me
            .Bounds = New Rectangle(50, 100, 30, 30)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(0, 1).Width, farblaschen(0, 1).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(0, 1).Width, farblaschen(0, 1).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(0, 2)
            .myx = 150
            .myy = 100
            .Parent = Me
            .Bounds = New Rectangle(150, 100, 30, 30)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(0, 2).Width, farblaschen(0, 2).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(0, 2).Width, farblaschen(0, 2).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(0, 3)
            .myx = 200
            .myy = 100
            .Parent = Me
            .Bounds = New Rectangle(200, 100, 30, 30)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(0, 3).Width, farblaschen(0, 3).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(0, 3).Width, farblaschen(0, 3).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        With farblaschen(0, 4)
            .myx = 250
            .myy = 100
            .Parent = Me
            .Bounds = New Rectangle(250, 100, 30, 30)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                farblaschen(0, 4).Width, farblaschen(0, 4).Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                farblaschen(0, 4).Width, farblaschen(0, 4).Height)
            .Text = ""
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With
        
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
    Friend WithEvents cbtyp0 As System.Windows.Forms.CheckBox
    Friend WithEvents tbKlaenge00 As System.Windows.Forms.Button
    Friend WithEvents tbPos01 As System.Windows.Forms.Button
    Friend WithEvents tbPos03 As System.Windows.Forms.Button
    Friend WithEvents tbPos05 As System.Windows.Forms.Button
    Friend WithEvents tbPos07 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnEsc As System.Windows.Forms.Button
    Friend WithEvents tbPos09 As System.Windows.Forms.Button
    Friend WithEvents GroupBox0 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cbtyp0 = New System.Windows.Forms.CheckBox
        Me.GroupBox0 = New System.Windows.Forms.Panel
        Me.tbKlaenge00 = New System.Windows.Forms.Button
        Me.tbPos01 = New System.Windows.Forms.Button
        Me.tbPos03 = New System.Windows.Forms.Button
        Me.tbPos05 = New System.Windows.Forms.Button
        Me.tbPos07 = New System.Windows.Forms.Button
        Me.tbPos09 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnEsc = New System.Windows.Forms.Button
        '
        'cbtyp0
        '
        Me.cbtyp0.Location = New System.Drawing.Point(5, 8)
        Me.cbtyp0.Size = New System.Drawing.Size(100, 50)
        Me.cbtyp0.Text = "Typ 0"
        '
        'GroupBox0
        '
        Me.GroupBox0.Controls.Add(Me.cbtyp0)
        Me.GroupBox0.Controls.Add(Me.tbKlaenge00)
        Me.GroupBox0.Controls.Add(Me.tbPos01)
        Me.GroupBox0.Controls.Add(Me.tbPos03)
        Me.GroupBox0.Controls.Add(Me.tbPos05)
        Me.GroupBox0.Controls.Add(Me.tbPos07)
        Me.GroupBox0.Controls.Add(Me.tbPos09)
        Me.GroupBox0.Controls.Add(Me.Label8)
        Me.GroupBox0.Location = New System.Drawing.Point(12, 340)
        Me.GroupBox0.Size = New System.Drawing.Size(900, 136)
        '
        'tbKlaenge00
        '
        Me.tbKlaenge00.Location = New System.Drawing.Point(120, 24)
        '
        'tbPos01
        '
        Me.tbPos01.Location = New System.Drawing.Point(224, 24)
        Me.tbPos01.Size = New System.Drawing.Size(56, 20)
        '
        'tbPos03
        '
        Me.tbPos03.Location = New System.Drawing.Point(360, 24)
        Me.tbPos03.Size = New System.Drawing.Size(56, 20)
        '
        'tbPos05
        '
        Me.tbPos05.Location = New System.Drawing.Point(496, 24)
        Me.tbPos05.Size = New System.Drawing.Size(56, 20)
        '
        'tbPos07
        '
        Me.tbPos07.Location = New System.Drawing.Point(632, 24)
        Me.tbPos07.Size = New System.Drawing.Size(56, 20)
        '
        'tbPos09
        '
        Me.tbPos09.Location = New System.Drawing.Point(768, 24)
        Me.tbPos09.Size = New System.Drawing.Size(56, 20)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(20, 316)
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.Text = "Kettentyp"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(124, 316)
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.Text = "Glieder"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(236, 316)
        Me.Label3.Size = New System.Drawing.Size(53, 23)
        Me.Label3.Text = "Pos1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label4.Location = New System.Drawing.Point(372, 316)
        Me.Label4.Size = New System.Drawing.Size(53, 23)
        Me.Label4.Text = "Pos2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label5.Location = New System.Drawing.Point(508, 316)
        Me.Label5.Size = New System.Drawing.Size(53, 23)
        Me.Label5.Text = "Pos3"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label6.Location = New System.Drawing.Point(644, 316)
        Me.Label6.Size = New System.Drawing.Size(53, 23)
        Me.Label6.Text = "Pos4"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label7.Location = New System.Drawing.Point(780, 316)
        Me.Label7.Size = New System.Drawing.Size(53, 23)
        Me.Label7.Text = "Pos5"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label8.Location = New System.Drawing.Point(224, 56)
        Me.Label8.Size = New System.Drawing.Size(56, 23)
        Me.Label8.Text = "Farbe"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label9.Location = New System.Drawing.Point(372, 396)
        Me.Label9.Size = New System.Drawing.Size(56, 23)
        Me.Label9.Text = "Farbe"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label10.Location = New System.Drawing.Point(508, 396)
        Me.Label10.Size = New System.Drawing.Size(56, 23)
        Me.Label10.Text = "Farbe"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label11.Location = New System.Drawing.Point(644, 396)
        Me.Label11.Size = New System.Drawing.Size(56, 23)
        Me.Label11.Text = "Farbe"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label12.Location = New System.Drawing.Point(780, 396)
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.Text = "Farbe"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(68, 48)
        Me.btnOK.Size = New System.Drawing.Size(184, 48)
        Me.btnOK.Text = "AUSWAHL  SPEICHERN"
        '
        'btnEsc
        '
        Me.btnEsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEsc.Location = New System.Drawing.Point(848, 8)
        Me.btnEsc.Size = New System.Drawing.Size(64, 52)
        Me.btnEsc.Text = "ESC"
        '
        'FKettentyp
        '
        Me.ClientSize = New System.Drawing.Size(922, 499)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEsc)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox0)
        Me.Location = New System.Drawing.Point(50, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Kettentyp und Farblascheneinstellungen"

    End Sub

#End Region

    Friend WithEvents lblPos1Farbe02 As New PictureButton
    Friend WithEvents lblPos2Farbe04 As New PictureButton
    Friend WithEvents lblPos3Farbe06 As New PictureButton
    Friend WithEvents lblPos4Farbe08 As New PictureButton
    Friend WithEvents lblPos5Farbe010 As New PictureButton
   

    Public Shared CheckedBoxArr(1, 6) As Control
    Public Shared GroupboxArr(1) As System.Object
    Public Shared farblaschen(1, 4) As PictureButton
    Public Shared tempEingabeAusFKettentypen As String
    Public passwortOK As Boolean = False

    '*******************************************************************
    'farbbutton steurung für zb. motor1 motor2
 

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
    '***********************************************************************************

    Private Sub FKettentyp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'frm1.Enabled = False
        'frm1.grafikfenster.Enabled = False
        ''KettenTypLeser.LoadKettenTypValues() 'über object wird nochmals eingelesen, damit die daten bei wiederholtem aufruf,aktuell sind in der FKettentyp form.
        LadeArreyDaten()  'funktion dient zur vereinfachung der control,indem alles in ein array gepackt wird.
        LadeAusConfig()
        'refresh()  nicht nötig....
        For i As Integer = 0 To 4
            For j As Integer = 0 To 4
                AddHandler Me.farblaschen(i, j).Click, AddressOf Farbwahloeffnen
            Next
        Next


        AddHandler cbtyp0.Click, AddressOf checkedcheck

        For i As Integer = 0 To 4
            For j As Integer = 1 To 6
                AddHandler Me.CheckedBoxArr(i, j).click, AddressOf EingabeOeffnen
            Next
        Next

    End Sub


    Private Sub LadeAusConfig()
        ' hier werden beim aufruf die daten aus der kettentypen.xml in das formular geladen!
        'Try
        'If (AppMgr.frm1.kettentypenXml.kettentypenstr(0, 0) = 1) Then
        'Me.cbtyp0.Checked = True
        'ElseIf (AppMgr.frm1.kettentypenXml.kettentypenstr(1, 0) = 1) Then
        '    Me.cbtyp0.Checked = False
        
        ' ElseIf (AppMgr.frm1.kettentypenXml.kettentypenstr(2, 0) = 1) Then
        '    Me.cbtyp0.Checked = False
        '   Me.cbtyp1.Checked = False
        '   Me.cbtyp2.Checked = True
        '   Me.cbtyp3.Checked = False
        '   Me.cbtyp4.Checked = False
        'ElseIf (AppMgr.frm1.kettentypenXml.kettentypenstr(3, 0) = 1) Then
        '    Me.cbtyp0.Checked = False
        '    Me.cbtyp1.Checked = False
        '    Me.cbtyp2.Checked = False
        '    Me.cbtyp3.Checked = True
        '    Me.cbtyp4.Checked = False
        'ElseIf (AppMgr.frm1.kettentypenXml.kettentypenstr(4, 0) = 1) Then
        '    Me.cbtyp0.Checked = False
        '    Me.cbtyp1.Checked = False
        '    Me.cbtyp2.Checked = False
        '    Me.cbtyp3.Checked = False
        '    Me.cbtyp4.Checked = True
        'End If

        'kettenlaengen und positionen...
        tbKlaenge00.Text = AppMgr.frm1.kettentypenXml.kettentypenstr(0, 1)
       
        tbPos01.Text = AppMgr.frm1.kettentypenXml.kettentypenstr(0, 2)

        tbPos03.Text = AppMgr.frm1.kettentypenXml.kettentypenstr(0, 4)
       

        tbPos05.Text = AppMgr.frm1.kettentypenXml.kettentypenstr(0, 6)
       
        tbPos07.Text = AppMgr.frm1.kettentypenXml.kettentypenstr(0, 8)
     

        tbPos09.Text = AppMgr.frm1.kettentypenXml.kettentypenstr(0, 10)
    

        'farblaschen aus xml...
        Dim n As Integer = 0
        For s As Integer = 0 To 4 Step 1
            n = 0
            For z As Integer = 3 To 11 Step 2
                Select Case AppMgr.frm1.kettentypenXml.kettentypenstr(s, z)
                    Case 0 : Me.farblaschen(s, n).BackgroundImageValue = MakeBitmap(Color.Gray, _
                             Me.farblaschen(s, n).Width, Me.farblaschen(s, n).Height)
                        Me.farblaschen(s, n).Refresh()
                        Me.farblaschen(s, n).farbwert = 0
                        n = n + 1
                    Case 1 : Me.farblaschen(s, n).BackgroundImageValue = MakeBitmap(Color.Yellow, _
                             Me.farblaschen(s, n).Width, Me.farblaschen(s, n).Height)
                        Me.farblaschen(s, n).Refresh()
                        Me.farblaschen(s, n).farbwert = 1
                        n = n + 1
                    Case 2 : Me.farblaschen(s, n).BackgroundImageValue = MakeBitmap(Color.OrangeRed, _
                             Me.farblaschen(s, n).Width, Me.farblaschen(s, n).Height)
                        Me.farblaschen(s, n).Refresh()
                        Me.farblaschen(s, n).farbwert = 2
                        n = n + 1
                    Case 3 : Me.farblaschen(s, n).BackgroundImageValue = MakeBitmap(Color.Blue, _
                             Me.farblaschen(s, n).Width, Me.farblaschen(s, n).Height)
                        Me.farblaschen(s, n).Refresh()
                        Me.farblaschen(s, n).farbwert = 3
                        n = n + 1
                    Case Else : MsgBox("es gibt einen fehlerhaften wert in der kettentypen.xml!")
                End Select
            Next
        Next
        'Catch ex As Exception
        'MsgBox(ex)
        'MessageBox.Show("Problem: Keine Verbindung zum Twincat-System!" & vbCr & _
        '               "Lösung: Zuerst Twincat System starten und ins Run-Modus setzen," & vbCr & _
        '              "danach Visualisierung starten!" & vbCr & _
        '             "System Fehlermeldung:" & err.Message)
        ' umgebung.AppMgr.frm1.Enabled = True
        '  Me.Close()
        'Application.Exit()
        '   End Try
    End Sub



    Private Sub LadeArreyDaten()
        'lade objecte in ein gemeinsames array!
        Dim i As Integer = 0
        For Each ctrl As Control In Me.GroupBox0.Controls
            CheckedBoxArr(0, i) = ctrl
            'MsgBox(CheckedBoxArr(0, i).ToString)
            i = i + 1

        Next
        i = 0

        'groupbox array in array kopieren, zur einfachen handhabung.
        GroupboxArr(0) = Me.GroupBox0

    End Sub


    Private Sub EingabeOeffnen(ByVal sender As Object, ByVal e As EventArgs)
        If (passwortOK = True) Then
            Dim laengeneingabe As New FPassw(3, sender)
            laengeneingabe.Show()
            laengeneingabe.BringToFront()
            Me.Enabled = False
        Else
            Dim passworteingabe As New FPassw(2, sender)
            passworteingabe.Show()
            passworteingabe.BringToFront()
            Me.Enabled = False
        End If

    End Sub

    Private Sub Farbwahloeffnen(ByVal sender As Object, ByVal e As EventArgs)
        If (passwortOK = True) Then
            Dim farbeingabe As New FFarbwahl(sender)
            farbeingabe.Show()
            farbeingabe.BringToFront()
            Me.Enabled() = False
        Else
            Dim passworteingabe As New FPassw(2, sender)
            passworteingabe.Show()
            passworteingabe.BringToFront()
            Me.Enabled = False
        End If
    End Sub

    Private Sub checkedcheck(ByVal sender As Object, ByVal e As EventArgs)
        If cbtyp0 Is (sender) Then
            cbtyp0.Checked = True
            ' cbtyp1.Checked = False
            ' cbtyp2.Checked = False
            ' cbtyp3.Checked = False
            ' cbtyp4.Checked = False
            'ElseIf cbtyp1 Is (sender) Then
            '    cbtyp1.Checked = True
            '   cbtyp0.Checked = False
            '  cbtyp2.Checked = False
            ' cbtyp3.Checked = False
            'cbtyp4.Checked = False
            'ElseIf cbtyp2 Is (sender) Then
            '   cbtyp2.Checked = True
            '  cbtyp1.Checked = False
            ' cbtyp0.Checked = False
            'cbtyp3.Checked = False
            'cbtyp4.Checked = False
            'ElseIf cbtyp3 Is (sender) Then
            '    cbtyp3.Checked = True
            '    cbtyp1.Checked = False
            '   cbtyp2.Checked = False
            '  cbtyp0.Checked = False
            ' cbtyp4.Checked = False
            'ElseIf cbtyp4 Is (sender) Then
            '   cbtyp4.Checked = True
            '  cbtyp1.Checked = False
            ' cbtyp2.Checked = False
            'cbtyp3.Checked = False
            'cbtyp0.Checked = False
        End If
    End Sub

    Private Sub kettentypenSpeichernXml(ByVal str_path As String)
        Dim gecheckt As Integer = 0 'wird zugleich gemerkt welcher typ gecheckt ist, für die sps speicher routine!
        'aktiver kettentyp:
        If Me.cbtyp0.Checked = True Then
            AppMgr.frm1.kettentypenXml.kettentypenstr(0, 0) = "1"
            gecheckt = 0
        Else
            AppMgr.frm1.kettentypenXml.kettentypenstr(0, 0) = "0"
        End If

        'kettenlaengen und farblaschenpositionen...
        AppMgr.frm1.kettentypenXml.kettentypenstr(0, 1) = tbKlaenge00.Text
        AppMgr.frm1.kettentypenXml.kettentypenstr(0, 2) = tbPos01.Text
        AppMgr.frm1.kettentypenXml.kettentypenstr(0, 4) = tbPos03.Text
        AppMgr.frm1.kettentypenXml.kettentypenstr(0, 6) = tbPos05.Text
        AppMgr.frm1.kettentypenXml.kettentypenstr(0, 8) = tbPos07.Text
        AppMgr.frm1.kettentypenXml.kettentypenstr(0, 10) = tbPos09.Text
     
        'farbwerte speichern.
        Dim n As Integer = 0
        For s As Integer = 0 To 4 Step 1
            n = 0
            For z As Integer = 3 To 11 Step 2
                AppMgr.frm1.kettentypenXml.kettentypenstr(s, z) = Me.farblaschen(s, n).farbwert
                n = n + 1
            Next
        Next

        AppMgr.frm1.kettentypenXml.neueXmlKettenTypDateiAnlegen(str_path)

        'speichere aktuellen kettentyp in der SPS!
        Try
            Dim vHandleKettentyp As Integer
            Dim dataStream As New AdsStream(22)
            Dim binWrite As New BinaryWriter(dataStream)
            vHandleKettentyp = AppMgr.frm1.adsClient.CreateVariableHandle(".KettenTyp")
            dataStream.Position = 0
            'da in der sps zuerst die farbe steht, ist hier der speicher ablauf zuerst farbe, dann farbposition.
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 1)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 3)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 2)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 5)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 4)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 7)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 6)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 9)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 8)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 11)))
            binWrite.Write(Short.Parse(AppMgr.frm1.kettentypenXml.kettentypenstr(gecheckt, 10)))
            AppMgr.frm1.adsClient.Write(vHandleKettentyp, dataStream)
            AppMgr.frm1.adsClient.DeleteVariableHandle(vHandleKettentyp)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim strpath As String = ""
        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then
            strpath = strpath.Substring(6)
        End If

        strpath = strpath & "/kettentypen.xml"
        If File.Exists(strpath) Then
            Me.kettentypenSpeichernXml(strpath)
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Änderungen wurden nicht gespeichert!"
            mydialog.BringToFront()
            mydialog.Show()
            'MsgBox("Kettentypen.xml nicht vorhanden.Kettentypenauswahl konnte nicht gespeichert werden!")
        End If
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsc.Click
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.DrawRectangle(New Pen(Color.Black), 5, 351, 910, 120)

        ' e.Graphics.FillRectangle(New SolidBrush(Color.Gray), lblPos1Farbe12.Location.X, lblPos1Farbe12.Location.Y + 100, lblPos1Farbe12.Width, lblPos1Farbe12.Height)
        'MyBase.OnPaint(e)
        MyBase.OnPaint(e)

    End Sub

End Class

