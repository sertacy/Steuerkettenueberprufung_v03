Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class FFarbwahl
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnEsc As System.Windows.Forms.Button

    Friend WithEvents btnGelb As New PictureButton
    Friend WithEvents btnOrange As New PictureButton
    Friend WithEvents btnBlau As New PictureButton
    Friend WithEvents btnGrau As New PictureButton

    Public mysender As Object   'aufrufendes object.

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal sender As Object)
        MyBase.New()

        'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        mysender = sender

        'Beliebige Initialisierung nach dem InitializeComponent()-Aufruf hinzufügen

        ' Create an instance of the PictureButton custom control,btngelb
        With btnGelb
            .Parent = Me
            .Bounds = New Rectangle(20, 20, 50, 50)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Yellow, _
                btnGelb.Width, btnGelb.Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                btnGelb.Width, btnGelb.Height)
            .Text = "Gelb"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        ' Create an instance of the PictureButton custom control,btnorange
        With btnOrange
            .Parent = Me
            .Bounds = New Rectangle(80, 45, 50, 50)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.OrangeRed, _
                btnOrange.Width, btnOrange.Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                btnOrange.Width, btnOrange.Height)
            .Text = "Orange"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        ' Create an instance of the PictureButton custom control,btnBlau
        With btnBlau
            .Parent = Me
            .Bounds = New Rectangle(20, 80, 50, 50)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Blue, _
                btnBlau.Width, btnBlau.Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                btnBlau.Width, btnBlau.Height)
            .Text = "Blau"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With

        ' Create an instance of the PictureButton custom control,btnBlau
        With btnGrau
            .Parent = Me
            .Bounds = New Rectangle(80, 105, 50, 50)
            .ForeColor = Color.Black
            .BackgroundImageValue = MakeBitmap(Color.Gray, _
                btnGrau.Width, btnGrau.Height)
            .PressedImageValue = MakeBitmap(Color.White, _
                btnGrau.Width, btnGrau.Height)
            .Text = "Grau"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
            .BringToFront()
        End With


    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnEsc = New System.Windows.Forms.Button
        '
        'btnEsc
        '
        Me.btnEsc.Location = New System.Drawing.Point(26, 168)
        Me.btnEsc.Size = New System.Drawing.Size(96, 40)
        Me.btnEsc.Text = "ESC"
        '
        'FFarbwahl
        '
        Me.ClientSize = New System.Drawing.Size(149, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEsc)
        Me.Location = New System.Drawing.Point(400, 300)
        Me.Text = "Farblaschenwahl"

    End Sub

#End Region


    '*******************************************************************
    'farbbutton steurung für zb. btngelb,btnorange,btnblau,btngrau
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
    Private Sub btnGelb_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnGelb.Click
        'Add code here to respond to button click. 
        For j As Integer = 0 To 4
            If AppMgr.frm1.auftragsverw.farblaschen(j) Is mysender Then
                AppMgr.frm1.auftragsverw.farblaschen(j).BackgroundImageValue = MakeBitmap(Color.Yellow, _
                    AppMgr.frm1.auftragsverw.farblaschen(j).Width, AppMgr.frm1.auftragsverw.farblaschen(j).Height)
                AppMgr.frm1.auftragsverw.farblaschen(j).Refresh()
                AppMgr.frm1.auftragsverw.farblaschen(j).farbwert = 1
            End If
        Next

        AppMgr.frm1.auftragsverw.Enabled() = True
        Me.Close()
    End Sub

    Private Sub btnOrange_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnOrange.Click
        'Add code here to respond to button click. 
        For j As Integer = 0 To 4
            If AppMgr.frm1.auftragsverw.farblaschen(j) Is mysender Then
                AppMgr.frm1.auftragsverw.farblaschen(j).BackgroundImageValue = MakeBitmap(Color.OrangeRed, _
                    AppMgr.frm1.auftragsverw.farblaschen(j).Width, AppMgr.frm1.auftragsverw.farblaschen(j).Height)
                AppMgr.frm1.auftragsverw.farblaschen(j).Refresh()
                AppMgr.frm1.auftragsverw.farblaschen(j).farbwert = 2
            End If
        Next

        AppMgr.frm1.auftragsverw.Enabled() = True
        Me.Close()
    End Sub

    Private Sub btnBlau_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnBlau.Click
        'Add code here to respond to button click.
        For j As Integer = 0 To 4
            If AppMgr.frm1.auftragsverw.farblaschen(j) Is mysender Then
                AppMgr.frm1.auftragsverw.farblaschen(j).BackgroundImageValue = MakeBitmap(Color.Blue, _
                    AppMgr.frm1.auftragsverw.farblaschen(j).Width, AppMgr.frm1.auftragsverw.farblaschen(j).Height)
                AppMgr.frm1.auftragsverw.farblaschen(j).Refresh()
                AppMgr.frm1.auftragsverw.farblaschen(j).farbwert = 3
            End If
        Next

        AppMgr.frm1.auftragsverw.Enabled() = True
        Me.Close()

    End Sub

    Private Sub btnGrau_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnGrau.Click
        'Add code here to respond to button click. 
        For j As Integer = 0 To 4
            If AppMgr.frm1.auftragsverw.farblaschen(j) Is mysender Then
                AppMgr.frm1.auftragsverw.farblaschen(j).BackgroundImageValue = MakeBitmap(Color.Gray, _
                    AppMgr.frm1.auftragsverw.farblaschen(j).Width, AppMgr.frm1.auftragsverw.farblaschen(j).Height)
                AppMgr.frm1.auftragsverw.farblaschen(j).Refresh()
                AppMgr.frm1.auftragsverw.farblaschen(j).farbwert = 0
            End If
        Next

        AppMgr.frm1.auftragsverw.Enabled() = True
        Me.Close()
    End Sub

    '******************************************************************

    Private Sub btnEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsc.Click
        AppMgr.frm1.auftragsverw.Enabled() = True
        Me.Close()
    End Sub
End Class
