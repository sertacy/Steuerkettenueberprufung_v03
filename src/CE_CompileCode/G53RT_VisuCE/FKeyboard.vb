Imports System
Imports System.IO
Imports System.Windows.Forms
Imports umgebung


Public Class FKeyboard
    Inherits System.Windows.Forms.Form

    Public mytext As System.Windows.Forms.Button
    Public tempstring As String 'halte alten String falls ESC gedrueckt wird.
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        'Beliebige Initialisierung nach dem InitializeComponent()-Aufruf hinzufügen

    End Sub

    Public Sub New(ByVal parenttext As System.Object)
        MyBase.New()
        'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        mytext = parenttext
        tempstring = mytext.Text   'halte alten wert falls ESC gedrueckt wird.
        mytext.Text = ""
        'Beliebige Initialisierung nach dem InitializeComponent()-Aufruf hinzufügen
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents btnI As System.Windows.Forms.Button
    Friend WithEvents btnU As System.Windows.Forms.Button
    Friend WithEvents btnZ As System.Windows.Forms.Button
    Friend WithEvents btnT As System.Windows.Forms.Button
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents btnE As System.Windows.Forms.Button
    Friend WithEvents btnW As System.Windows.Forms.Button
    Friend WithEvents btnA As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents btnDEL As System.Windows.Forms.Button
    Friend WithEvents btnP As System.Windows.Forms.Button
    Friend WithEvents btnO As System.Windows.Forms.Button
    Friend WithEvents btnQ As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnStrich As System.Windows.Forms.Button
    Friend WithEvents btnL As System.Windows.Forms.Button
    Friend WithEvents btnK As System.Windows.Forms.Button
    Friend WithEvents btnJ As System.Windows.Forms.Button
    Friend WithEvents btnH As System.Windows.Forms.Button
    Friend WithEvents btnG As System.Windows.Forms.Button
    Friend WithEvents btnF As System.Windows.Forms.Button
    Friend WithEvents btnD As System.Windows.Forms.Button
    Friend WithEvents btnS As System.Windows.Forms.Button
    Friend WithEvents btnPunkt As System.Windows.Forms.Button
    Friend WithEvents btnKomma As System.Windows.Forms.Button
    Friend WithEvents btnM As System.Windows.Forms.Button
    Friend WithEvents btnN As System.Windows.Forms.Button
    Friend WithEvents btnB As System.Windows.Forms.Button
    Friend WithEvents btnV As System.Windows.Forms.Button
    Friend WithEvents btnC As System.Windows.Forms.Button
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents btnY As System.Windows.Forms.Button
    Friend WithEvents btnShift1 As System.Windows.Forms.Button
    Friend WithEvents btnShift2 As System.Windows.Forms.Button
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents btnLeertaste As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btn1 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btn0 = New System.Windows.Forms.Button
        Me.btnESC = New System.Windows.Forms.Button
        Me.btnDEL = New System.Windows.Forms.Button
        Me.btnP = New System.Windows.Forms.Button
        Me.btnO = New System.Windows.Forms.Button
        Me.btnI = New System.Windows.Forms.Button
        Me.btnU = New System.Windows.Forms.Button
        Me.btnZ = New System.Windows.Forms.Button
        Me.btnT = New System.Windows.Forms.Button
        Me.btnR = New System.Windows.Forms.Button
        Me.btnE = New System.Windows.Forms.Button
        Me.btnW = New System.Windows.Forms.Button
        Me.btnQ = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnStrich = New System.Windows.Forms.Button
        Me.btnL = New System.Windows.Forms.Button
        Me.btnK = New System.Windows.Forms.Button
        Me.btnJ = New System.Windows.Forms.Button
        Me.btnH = New System.Windows.Forms.Button
        Me.btnG = New System.Windows.Forms.Button
        Me.btnF = New System.Windows.Forms.Button
        Me.btnD = New System.Windows.Forms.Button
        Me.btnS = New System.Windows.Forms.Button
        Me.btnA = New System.Windows.Forms.Button
        Me.btnPlus = New System.Windows.Forms.Button
        Me.btnPunkt = New System.Windows.Forms.Button
        Me.btnKomma = New System.Windows.Forms.Button
        Me.btnM = New System.Windows.Forms.Button
        Me.btnN = New System.Windows.Forms.Button
        Me.btnB = New System.Windows.Forms.Button
        Me.btnV = New System.Windows.Forms.Button
        Me.btnC = New System.Windows.Forms.Button
        Me.btnX = New System.Windows.Forms.Button
        Me.btnY = New System.Windows.Forms.Button
        Me.btnShift1 = New System.Windows.Forms.Button
        Me.btnLeertaste = New System.Windows.Forms.Button
        Me.btnShift2 = New System.Windows.Forms.Button
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn1.Location = New System.Drawing.Point(2, 2)
        Me.btn1.Size = New System.Drawing.Size(64, 56)
        Me.btn1.Text = "1"
        '
        'btn2
        '
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn2.Location = New System.Drawing.Point(66, 2)
        Me.btn2.Size = New System.Drawing.Size(64, 56)
        Me.btn2.Text = "2"
        '
        'btn3
        '
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn3.Location = New System.Drawing.Point(130, 2)
        Me.btn3.Size = New System.Drawing.Size(64, 56)
        Me.btn3.Text = "3"
        '
        'btn4
        '
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn4.Location = New System.Drawing.Point(194, 2)
        Me.btn4.Size = New System.Drawing.Size(64, 56)
        Me.btn4.Text = "4"
        '
        'btn5
        '
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn5.Location = New System.Drawing.Point(258, 2)
        Me.btn5.Size = New System.Drawing.Size(64, 56)
        Me.btn5.Text = "5"
        '
        'btn6
        '
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn6.Location = New System.Drawing.Point(322, 2)
        Me.btn6.Size = New System.Drawing.Size(64, 56)
        Me.btn6.Text = "6"
        '
        'btn7
        '
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn7.Location = New System.Drawing.Point(386, 2)
        Me.btn7.Size = New System.Drawing.Size(64, 56)
        Me.btn7.Text = "7"
        '
        'btn8
        '
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn8.Location = New System.Drawing.Point(450, 2)
        Me.btn8.Size = New System.Drawing.Size(64, 56)
        Me.btn8.Text = "8"
        '
        'btn9
        '
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn9.Location = New System.Drawing.Point(514, 2)
        Me.btn9.Size = New System.Drawing.Size(64, 56)
        Me.btn9.Text = "9"
        '
        'btn0
        '
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btn0.Location = New System.Drawing.Point(578, 2)
        Me.btn0.Size = New System.Drawing.Size(64, 56)
        Me.btn0.Text = "0"
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnESC.Location = New System.Drawing.Point(642, 2)
        Me.btnESC.Size = New System.Drawing.Size(128, 56)
        Me.btnESC.Text = "ESC"
        '
        'btnDEL
        '
        Me.btnDEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnDEL.Location = New System.Drawing.Point(642, 62)
        Me.btnDEL.Size = New System.Drawing.Size(128, 56)
        Me.btnDEL.Text = "DEL"
        '
        'btnP
        '
        Me.btnP.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnP.Location = New System.Drawing.Point(578, 62)
        Me.btnP.Size = New System.Drawing.Size(64, 56)
        Me.btnP.Text = "P"
        '
        'btnO
        '
        Me.btnO.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnO.Location = New System.Drawing.Point(514, 62)
        Me.btnO.Size = New System.Drawing.Size(64, 56)
        Me.btnO.Text = "O"
        '
        'btnI
        '
        Me.btnI.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnI.Location = New System.Drawing.Point(450, 62)
        Me.btnI.Size = New System.Drawing.Size(64, 56)
        Me.btnI.Text = "I"
        '
        'btnU
        '
        Me.btnU.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnU.Location = New System.Drawing.Point(386, 62)
        Me.btnU.Size = New System.Drawing.Size(64, 56)
        Me.btnU.Text = "U"
        '
        'btnZ
        '
        Me.btnZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnZ.Location = New System.Drawing.Point(322, 62)
        Me.btnZ.Size = New System.Drawing.Size(64, 56)
        Me.btnZ.Text = "Z"
        '
        'btnT
        '
        Me.btnT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnT.Location = New System.Drawing.Point(258, 62)
        Me.btnT.Size = New System.Drawing.Size(64, 56)
        Me.btnT.Text = "T"
        '
        'btnR
        '
        Me.btnR.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnR.Location = New System.Drawing.Point(194, 62)
        Me.btnR.Size = New System.Drawing.Size(64, 56)
        Me.btnR.Text = "R"
        '
        'btnE
        '
        Me.btnE.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnE.Location = New System.Drawing.Point(130, 62)
        Me.btnE.Size = New System.Drawing.Size(64, 56)
        Me.btnE.Text = "E"
        '
        'btnW
        '
        Me.btnW.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnW.Location = New System.Drawing.Point(66, 62)
        Me.btnW.Size = New System.Drawing.Size(64, 56)
        Me.btnW.Text = "W"
        '
        'btnQ
        '
        Me.btnQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnQ.Location = New System.Drawing.Point(2, 62)
        Me.btnQ.Size = New System.Drawing.Size(64, 56)
        Me.btnQ.Text = "Q"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnOK.Location = New System.Drawing.Point(642, 122)
        Me.btnOK.Size = New System.Drawing.Size(128, 116)
        Me.btnOK.Text = "Enter"
        '
        'btnStrich
        '
        Me.btnStrich.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnStrich.Location = New System.Drawing.Point(578, 122)
        Me.btnStrich.Size = New System.Drawing.Size(64, 56)
        Me.btnStrich.Text = "-"
        '
        'btnL
        '
        Me.btnL.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnL.Location = New System.Drawing.Point(514, 122)
        Me.btnL.Size = New System.Drawing.Size(64, 56)
        Me.btnL.Text = "L"
        '
        'btnK
        '
        Me.btnK.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnK.Location = New System.Drawing.Point(450, 122)
        Me.btnK.Size = New System.Drawing.Size(64, 56)
        Me.btnK.Text = "K"
        '
        'btnJ
        '
        Me.btnJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnJ.Location = New System.Drawing.Point(386, 122)
        Me.btnJ.Size = New System.Drawing.Size(64, 56)
        Me.btnJ.Text = "J"
        '
        'btnH
        '
        Me.btnH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnH.Location = New System.Drawing.Point(322, 122)
        Me.btnH.Size = New System.Drawing.Size(64, 56)
        Me.btnH.Text = "H"
        '
        'btnG
        '
        Me.btnG.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnG.Location = New System.Drawing.Point(258, 122)
        Me.btnG.Size = New System.Drawing.Size(64, 56)
        Me.btnG.Text = "G"
        '
        'btnF
        '
        Me.btnF.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnF.Location = New System.Drawing.Point(194, 122)
        Me.btnF.Size = New System.Drawing.Size(64, 56)
        Me.btnF.Text = "F"
        '
        'btnD
        '
        Me.btnD.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnD.Location = New System.Drawing.Point(130, 122)
        Me.btnD.Size = New System.Drawing.Size(64, 56)
        Me.btnD.Text = "D"
        '
        'btnS
        '
        Me.btnS.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnS.Location = New System.Drawing.Point(66, 122)
        Me.btnS.Size = New System.Drawing.Size(64, 56)
        Me.btnS.Text = "S"
        '
        'btnA
        '
        Me.btnA.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnA.Location = New System.Drawing.Point(2, 122)
        Me.btnA.Size = New System.Drawing.Size(64, 56)
        Me.btnA.Text = "A"
        '
        'btnPlus
        '
        Me.btnPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnPlus.Location = New System.Drawing.Point(578, 182)
        Me.btnPlus.Size = New System.Drawing.Size(64, 56)
        Me.btnPlus.Text = "+"
        '
        'btnPunkt
        '
        Me.btnPunkt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnPunkt.Location = New System.Drawing.Point(514, 182)
        Me.btnPunkt.Size = New System.Drawing.Size(64, 56)
        Me.btnPunkt.Text = "."
        '
        'btnKomma
        '
        Me.btnKomma.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnKomma.Location = New System.Drawing.Point(450, 182)
        Me.btnKomma.Size = New System.Drawing.Size(64, 56)
        Me.btnKomma.Text = ","
        '
        'btnM
        '
        Me.btnM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnM.Location = New System.Drawing.Point(386, 182)
        Me.btnM.Size = New System.Drawing.Size(64, 56)
        Me.btnM.Text = "M"
        '
        'btnN
        '
        Me.btnN.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnN.Location = New System.Drawing.Point(322, 182)
        Me.btnN.Size = New System.Drawing.Size(64, 56)
        Me.btnN.Text = "N"
        '
        'btnB
        '
        Me.btnB.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnB.Location = New System.Drawing.Point(258, 182)
        Me.btnB.Size = New System.Drawing.Size(64, 56)
        Me.btnB.Text = "B"
        '
        'btnV
        '
        Me.btnV.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnV.Location = New System.Drawing.Point(194, 182)
        Me.btnV.Size = New System.Drawing.Size(64, 56)
        Me.btnV.Text = "V"
        '
        'btnC
        '
        Me.btnC.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnC.Location = New System.Drawing.Point(130, 182)
        Me.btnC.Size = New System.Drawing.Size(64, 56)
        Me.btnC.Text = "C"
        '
        'btnX
        '
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnX.Location = New System.Drawing.Point(66, 182)
        Me.btnX.Size = New System.Drawing.Size(64, 56)
        Me.btnX.Text = "X"
        '
        'btnY
        '
        Me.btnY.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnY.Location = New System.Drawing.Point(2, 182)
        Me.btnY.Size = New System.Drawing.Size(64, 56)
        Me.btnY.Text = "Y"
        '
        'btnShift1
        '
        Me.btnShift1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnShift1.Location = New System.Drawing.Point(2, 242)
        Me.btnShift1.Size = New System.Drawing.Size(128, 56)
        Me.btnShift1.Text = "Shift"
        '
        'btnLeertaste
        '
        Me.btnLeertaste.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnLeertaste.Location = New System.Drawing.Point(130, 242)
        Me.btnLeertaste.Size = New System.Drawing.Size(512, 56)
        Me.btnLeertaste.Text = "Leertaste"
        '
        'btnShift2
        '
        Me.btnShift2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular)
        Me.btnShift2.Location = New System.Drawing.Point(642, 242)
        Me.btnShift2.Size = New System.Drawing.Size(128, 56)
        Me.btnShift2.Text = "Shift"
        '
        'FKeyboard
        '
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(776, 301)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnShift2)
        Me.Controls.Add(Me.btnLeertaste)
        Me.Controls.Add(Me.btnShift1)
        Me.Controls.Add(Me.btnPlus)
        Me.Controls.Add(Me.btnPunkt)
        Me.Controls.Add(Me.btnKomma)
        Me.Controls.Add(Me.btnM)
        Me.Controls.Add(Me.btnN)
        Me.Controls.Add(Me.btnB)
        Me.Controls.Add(Me.btnV)
        Me.Controls.Add(Me.btnC)
        Me.Controls.Add(Me.btnX)
        Me.Controls.Add(Me.btnY)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnStrich)
        Me.Controls.Add(Me.btnL)
        Me.Controls.Add(Me.btnK)
        Me.Controls.Add(Me.btnJ)
        Me.Controls.Add(Me.btnH)
        Me.Controls.Add(Me.btnG)
        Me.Controls.Add(Me.btnF)
        Me.Controls.Add(Me.btnD)
        Me.Controls.Add(Me.btnS)
        Me.Controls.Add(Me.btnA)
        Me.Controls.Add(Me.btnDEL)
        Me.Controls.Add(Me.btnP)
        Me.Controls.Add(Me.btnO)
        Me.Controls.Add(Me.btnI)
        Me.Controls.Add(Me.btnU)
        Me.Controls.Add(Me.btnZ)
        Me.Controls.Add(Me.btnT)
        Me.Controls.Add(Me.btnR)
        Me.Controls.Add(Me.btnE)
        Me.Controls.Add(Me.btnW)
        Me.Controls.Add(Me.btnQ)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Location = New System.Drawing.Point(100, 350)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Keyboard"

    End Sub

#End Region

    Private grossbuchstaben As Boolean = True

    Private Sub FKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.btn1.Click, AddressOf schreibeZeichen
        AddHandler Me.btn2.Click, AddressOf schreibeZeichen
        AddHandler Me.btn3.Click, AddressOf schreibeZeichen
        AddHandler Me.btn4.Click, AddressOf schreibeZeichen
        AddHandler Me.btn5.Click, AddressOf schreibeZeichen
        AddHandler Me.btn6.Click, AddressOf schreibeZeichen
        AddHandler Me.btn7.Click, AddressOf schreibeZeichen
        AddHandler Me.btn8.Click, AddressOf schreibeZeichen
        AddHandler Me.btn9.Click, AddressOf schreibeZeichen
        AddHandler Me.btn0.Click, AddressOf schreibeZeichen
        AddHandler Me.btnQ.Click, AddressOf schreibeZeichen
        AddHandler Me.btnW.Click, AddressOf schreibeZeichen
        AddHandler Me.btnE.Click, AddressOf schreibeZeichen
        AddHandler Me.btnR.Click, AddressOf schreibeZeichen
        AddHandler Me.btnT.Click, AddressOf schreibeZeichen
        AddHandler Me.btnZ.Click, AddressOf schreibeZeichen
        AddHandler Me.btnU.Click, AddressOf schreibeZeichen
        AddHandler Me.btnI.Click, AddressOf schreibeZeichen
        AddHandler Me.btnO.Click, AddressOf schreibeZeichen
        AddHandler Me.btnP.Click, AddressOf schreibeZeichen
        AddHandler Me.btnA.Click, AddressOf schreibeZeichen
        AddHandler Me.btnS.Click, AddressOf schreibeZeichen
        AddHandler Me.btnD.Click, AddressOf schreibeZeichen
        AddHandler Me.btnF.Click, AddressOf schreibeZeichen
        AddHandler Me.btnG.Click, AddressOf schreibeZeichen
        AddHandler Me.btnH.Click, AddressOf schreibeZeichen
        AddHandler Me.btnJ.Click, AddressOf schreibeZeichen
        AddHandler Me.btnK.Click, AddressOf schreibeZeichen
        AddHandler Me.btnL.Click, AddressOf schreibeZeichen
        AddHandler Me.btnStrich.Click, AddressOf schreibeZeichen
        AddHandler Me.btnY.Click, AddressOf schreibeZeichen
        AddHandler Me.btnX.Click, AddressOf schreibeZeichen
        AddHandler Me.btnC.Click, AddressOf schreibeZeichen
        AddHandler Me.btnV.Click, AddressOf schreibeZeichen
        AddHandler Me.btnB.Click, AddressOf schreibeZeichen
        AddHandler Me.btnN.Click, AddressOf schreibeZeichen
        AddHandler Me.btnM.Click, AddressOf schreibeZeichen
        AddHandler Me.btnKomma.Click, AddressOf schreibeZeichen
        AddHandler Me.btnPunkt.Click, AddressOf schreibeZeichen
        AddHandler Me.btnPlus.Click, AddressOf schreibeZeichen
    End Sub

    Private Sub schreibeZeichen(ByVal sender As Object, ByVal e As EventArgs)
        If (Not zulang()) Then
            mytext.Text = mytext.Text & CType(sender, Button).Text  'muss zuruechgecastet werden da spaetes binden nicht möglich auf CE
        Else
            MessageBox.Show("Text ist zu lang! (nur 15 Zeichen erlaubt)")
        End If
    End Sub

    Function zulang() As Boolean
        If mytext.Text.Length > 15 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        mytext.Text = tempstring
        Me.Close()
    End Sub


    Private Sub btnDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDEL.Click
        Dim i As Integer = mytext.Text.Length()
        If i > 0 Then
            mytext.Text = mytext.Text.Remove(i - 1, 1)   'letztes zeichen wird gelöscht!
        End If
    End Sub

    Private Sub btnShift1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShift1.Click
        If grossbuchstaben = True Then
            Me.btnQ.Text = "q"
            Me.btnW.Text = "w"
            Me.btnE.Text = "e"
            Me.btnR.Text = "r"
            Me.btnT.Text = "t"
            Me.btnZ.Text = "z"
            Me.btnU.Text = "u"
            Me.btnI.Text = "i"
            Me.btnO.Text = "o"
            Me.btnP.Text = "p"
            Me.btnA.Text = "a"
            Me.btnS.Text = "s"
            Me.btnD.Text = "d"
            Me.btnF.Text = "f"
            Me.btnG.Text = "g"
            Me.btnH.Text = "h"
            Me.btnJ.Text = "j"
            Me.btnK.Text = "k"
            Me.btnL.Text = "l"
            Me.btnStrich.Text = "_"
            Me.btnY.Text = "y"
            Me.btnX.Text = "x"
            Me.btnC.Text = "c"
            Me.btnV.Text = "v"
            Me.btnB.Text = "b"
            Me.btnN.Text = "n"
            Me.btnM.Text = "m"
            Me.btnKomma.Text = ";"
            Me.btnPunkt.Text = ":"
            Me.btnPlus.Text = "/"
            grossbuchstaben = False
        Else
            Me.btnQ.Text = "Q"
            Me.btnW.Text = "W"
            Me.btnE.Text = "E"
            Me.btnR.Text = "R"
            Me.btnT.Text = "T"
            Me.btnZ.Text = "Z"
            Me.btnU.Text = "U"
            Me.btnI.Text = "I"
            Me.btnO.Text = "O"
            Me.btnP.Text = "P"
            Me.btnA.Text = "A"
            Me.btnS.Text = "S"
            Me.btnD.Text = "D"
            Me.btnF.Text = "F"
            Me.btnG.Text = "G"
            Me.btnH.Text = "H"
            Me.btnJ.Text = "J"
            Me.btnK.Text = "K"
            Me.btnL.Text = "L"
            Me.btnStrich.Text = "-"
            Me.btnY.Text = "Y"
            Me.btnX.Text = "X"
            Me.btnC.Text = "C"
            Me.btnV.Text = "V"
            Me.btnB.Text = "B"
            Me.btnN.Text = "N"
            Me.btnM.Text = "M"
            Me.btnKomma.Text = ","
            Me.btnPunkt.Text = "."
            Me.btnPlus.Text = "+"
            grossbuchstaben = True
        End If
    End Sub

    Private Sub btnShift2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShift2.Click
        btnShift1_Click(sender, e)
    End Sub
    Private Sub btnLeertaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeertaste.Click
        If (Not zulang()) Then
            mytext.Text = mytext.Text & " "
        Else
            MessageBox.Show("Text ist zu lang! (nur 15 Zeichen erlaubt)")
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class
