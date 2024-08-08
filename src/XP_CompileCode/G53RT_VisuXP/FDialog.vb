Imports System
Imports System.String
Imports System.IO
Imports System.Xml
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class FDialog
    Inherits System.Windows.Forms.Form
    Friend WithEvents lblmeldung As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button

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
    Friend WithEvents lblmeldung2 As System.Windows.Forms.Label
    Friend WithEvents btnDummyQuit As System.Windows.Forms.Button
    Friend WithEvents lblmeldung3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblmeldung = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.lblmeldung2 = New System.Windows.Forms.Label
        Me.lblmeldung3 = New System.Windows.Forms.Label
        Me.btnDummyQuit = New System.Windows.Forms.Button
        '
        'lblmeldung
        '
        Me.lblmeldung.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular)
        Me.lblmeldung.ForeColor = System.Drawing.Color.Black
        Me.lblmeldung.Location = New System.Drawing.Point(12, 16)
        Me.lblmeldung.Size = New System.Drawing.Size(298, 24)
        Me.lblmeldung.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnOK.Location = New System.Drawing.Point(77, 160)
        Me.btnOK.Size = New System.Drawing.Size(168, 56)
        Me.btnOK.Text = "OK"
        '
        'lblmeldung2
        '
        Me.lblmeldung2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular)
        Me.lblmeldung2.ForeColor = System.Drawing.Color.Black
        Me.lblmeldung2.Location = New System.Drawing.Point(12, 48)
        Me.lblmeldung2.Size = New System.Drawing.Size(298, 24)
        Me.lblmeldung2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblmeldung2.Visible = False
        '
        'lblmeldung3
        '
        Me.lblmeldung3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular)
        Me.lblmeldung3.ForeColor = System.Drawing.Color.Black
        Me.lblmeldung3.Location = New System.Drawing.Point(12, 112)
        Me.lblmeldung3.Size = New System.Drawing.Size(298, 40)
        Me.lblmeldung3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblmeldung3.Visible = False
        '
        'btnDummyQuit
        '
        Me.btnDummyQuit.Enabled = False
        Me.btnDummyQuit.Location = New System.Drawing.Point(73, 72)
        Me.btnDummyQuit.Size = New System.Drawing.Size(176, 32)
        Me.btnDummyQuit.Text = "Dummy Quittieren!"
        Me.btnDummyQuit.Visible = False
        '
        'FDialog
        '
        Me.ClientSize = New System.Drawing.Size(330, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnDummyQuit)
        Me.Controls.Add(Me.lblmeldung3)
        Me.Controls.Add(Me.lblmeldung2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblmeldung)
        Me.Location = New System.Drawing.Point(350, 290)
        Me.Text = "Meldung"

    End Sub

#End Region


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnDummyQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDummyQuit.Click
        Dim artikeleingabe As New FPassw(7, sender)
        artikeleingabe.Show()
        artikeleingabe.BringToFront()
        Me.Close()
    End Sub
End Class
