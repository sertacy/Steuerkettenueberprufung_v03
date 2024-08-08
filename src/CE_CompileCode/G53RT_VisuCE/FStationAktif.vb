Imports System
Imports System.IO
Imports System.Xml
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class FStationAktif
    Inherits System.Windows.Forms.Form
    Friend WithEvents cb1aktiv As System.Windows.Forms.CheckBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents cb2aktiv As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Public mystation As Integer = 0
    Public passwortOK As Boolean = False
    Private tempAktiv As Short
    Private vHandle As Integer



#Region " Windows Form Designer generated code "

    Public Sub New(ByVal station As Integer)
        MyBase.New()

        'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        mystation = station

        Select Case mystation
            Case 1 : ladeStation1()
            Case 2 : ladeStation2()
            Case 3 : ladeStation3()
            Case 4 : ladeStation4()
        End Select

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cb1aktiv = New System.Windows.Forms.CheckBox
        Me.lblStation = New System.Windows.Forms.Label
        Me.cb2aktiv = New System.Windows.Forms.CheckBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnESC = New System.Windows.Forms.Button
        '
        'cb1aktiv
        '
        Me.cb1aktiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cb1aktiv.Location = New System.Drawing.Point(19, 54)
        Me.cb1aktiv.Size = New System.Drawing.Size(216, 54)
        Me.cb1aktiv.Text = "CheckBox1"
        '
        'lblStation
        '
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblStation.Location = New System.Drawing.Point(23, 8)
        Me.lblStation.Size = New System.Drawing.Size(208, 28)
        Me.lblStation.Text = "Station"
        Me.lblStation.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cb2aktiv
        '
        Me.cb2aktiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cb2aktiv.Location = New System.Drawing.Point(19, 132)
        Me.cb2aktiv.Size = New System.Drawing.Size(216, 54)
        Me.cb2aktiv.Text = "CheckBox2"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnOK.Location = New System.Drawing.Point(12, 201)
        Me.btnOK.Size = New System.Drawing.Size(99, 66)
        Me.btnOK.Text = "OK"
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnESC.Location = New System.Drawing.Point(147, 201)
        Me.btnESC.Size = New System.Drawing.Size(99, 66)
        Me.btnESC.Text = "ESC"
        '
        'FStationAktif
        '
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(255, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cb2aktiv)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.cb1aktiv)
        Me.Location = New System.Drawing.Point(390, 200)
        Me.Text = "Station"

    End Sub

#End Region


    Public Sub ladeStation1()
        MyBase.Text = "Station 1: Farblaschenprüfung"
        Me.lblStation.Text = "Station 1"
        Me.cb1aktiv.Visible = True
        Me.cb1aktiv.Text = "Farblaschen Aktiv"
        Me.cb2aktiv.Visible = False


        If AppMgr.frm1.myKontrolle_Aktiv_arr(0) = True Then
            Me.cb1aktiv.Checked = True
        End If
    End Sub
    Public Sub ladeStation2()
        MyBase.Text = "Station 2: Lasersensor"
        Me.lblStation.Text = "Station 2"
        Me.cb2aktiv.Visible = True
        Me.cb2aktiv.Text = "Laschenabstand Aktiv"
        Me.cb1aktiv.Visible = True
        Me.cb1aktiv.Text = "Bolzenhöhe Aktiv"
      
        If AppMgr.frm1.myKontrolle_Aktiv_arr(1) = True Then
            Me.cb2aktiv.Checked = True
        End If
        If AppMgr.frm1.myKontrolle_Aktiv_arr(2) = True Then
            Me.cb1aktiv.Checked = True
        End If
    End Sub
    Public Sub ladeStation3()
        MyBase.Text = "Station 3: Kettenhöhenprüfung"
        Me.lblStation.Text = "Station 3"
        Me.cb1aktiv.Visible = True
        Me.cb1aktiv.Text = "Distanz Aktiv"
        Me.cb2aktiv.Visible = False

        If AppMgr.frm1.myKontrolle_Aktiv_arr(3) = True Then
            Me.cb1aktiv.Checked = True
        End If
    End Sub
    Public Sub ladeStation4()
        MyBase.Text = "Station 4: Kamera"
        Me.lblStation.Text = "Station 4"
        Me.cb1aktiv.Visible = True
        Me.cb1aktiv.Text = "Kamera Aktiv"
        Me.cb2aktiv.Visible = False

        If AppMgr.frm1.myKontrolle_Aktiv_arr(5) = True Then
            Me.cb1aktiv.Checked = True
        End If
    End Sub



    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If passwortOK = True Then
            tempAktiv = AppMgr.frm1.myKontrolle_Aktiv
            If mystation = 1 Then
                SetBit(tempAktiv, 0, cb1aktiv.Checked())   'setze Farbsensor
                schreibeInSPS()
            End If

            If mystation = 2 Then
                SetBit(tempAktiv, 1, cb2aktiv.Checked())   'setze Lasersensor bolzenhöhe
                SetBit(tempAktiv, 2, cb1aktiv.Checked())   'setze Lasersensor laschenabstand
                schreibeInSPS()
            End If

            If mystation = 3 Then
                SetBit(tempAktiv, 3, cb1aktiv.Checked())   'sezte laschendistanz
                schreibeInSPS()
            End If

            If mystation = 4 Then
                SetBit(tempAktiv, 5, cb1aktiv.Checked())   'kamera aktif gesamt
                schreibeInSPS()
            End If
        Else
            Dim mydialog As New FDialog
            mydialog.lblmeldung.Text = "Daten nicht gespeichert!"
            mydialog.BringToFront()
            mydialog.Show()
        End If

        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Public Shared Sub SetBit(ByRef value As Short, ByVal bitNumber As Integer, ByVal bitvalue As Boolean)
        'bitmaske fuer verknuepfung erzeugen
        Dim mask As Integer = 1 << bitNumber
        If bitvalue Then
            'bit setzen
            value = value Or mask
        Else
            'bit loeschen
            value = value And Not mask
        End If
    End Sub

    Private Sub schreibeInSPS()
        Dim dataStream As New AdsStream(2)
        Dim binWrite As New BinaryWriter(dataStream)

        dataStream.Position = 0
        Try
            vHandle = AppMgr.frm1.adsClient.CreateVariableHandle(".Kontrolle_Aktiv")
            binWrite.Write(tempAktiv)
            AppMgr.frm1.adsClient.Write(vHandle, dataStream)

        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try

    End Sub



    Private Sub cb1aktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1aktiv.Click
        passwortOK = False
        If Me.cb1aktiv.Checked() = True Then
            passwortOK = True
        Else
            passwortOK = False
        End If

        If passwortOK = False Then
            Dim passwortcheck As New FPassw(4)
            passwortcheck.Show()
            passwortcheck.BringToFront()
            Me.Enabled = False
        End If
    End Sub

    Private Sub cb2aktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb2aktiv.Click
        passwortOK = False
        If Me.cb2aktiv.Checked() = True Then
            passwortOK = True
        Else
            passwortOK = False
        End If

        If passwortOK = False Then
            Dim passwortcheck As New FPassw(4)
            passwortcheck.Show()
            passwortcheck.BringToFront()
            Me.Enabled = False
        End If
    End Sub
End Class
