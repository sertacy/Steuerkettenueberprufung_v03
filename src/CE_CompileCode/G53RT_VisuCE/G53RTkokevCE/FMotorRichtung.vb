Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class FMotorRichtung
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnEsc As System.Windows.Forms.Button

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtnVor1 As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnVor2 As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnZurueck1 As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnZurueck2 As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnEsc = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.rbtnVor1 = New System.Windows.Forms.CheckBox
        Me.rbtnVor2 = New System.Windows.Forms.CheckBox
        Me.rbtnZurueck1 = New System.Windows.Forms.CheckBox
        Me.rbtnZurueck2 = New System.Windows.Forms.CheckBox
        '
        'btnEsc
        '
        Me.btnEsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEsc.Location = New System.Drawing.Point(101, 216)
        Me.btnEsc.Size = New System.Drawing.Size(256, 64)
        Me.btnEsc.Text = "ESC"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(57, 16)
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.Text = "Motor 1:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(328, 16)
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.Text = "Motor 2:"
        '
        'rbtnVor1
        '
        Me.rbtnVor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.rbtnVor1.Location = New System.Drawing.Point(32, 56)
        Me.rbtnVor1.Size = New System.Drawing.Size(128, 64)
        Me.rbtnVor1.Text = " Vor >>"
        '
        'rbtnVor2
        '
        Me.rbtnVor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.rbtnVor2.Location = New System.Drawing.Point(304, 56)
        Me.rbtnVor2.Size = New System.Drawing.Size(128, 64)
        Me.rbtnVor2.Text = " Vor >>"
        '
        'rbtnZurueck1
        '
        Me.rbtnZurueck1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.rbtnZurueck1.Location = New System.Drawing.Point(32, 136)
        Me.rbtnZurueck1.Size = New System.Drawing.Size(128, 64)
        Me.rbtnZurueck1.Text = "<< Zurück"
        '
        'rbtnZurueck2
        '
        Me.rbtnZurueck2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.rbtnZurueck2.Location = New System.Drawing.Point(304, 136)
        Me.rbtnZurueck2.Size = New System.Drawing.Size(128, 64)
        Me.rbtnZurueck2.Text = "<< Zurück"
        '
        'FMotorRichtung
        '
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(458, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.rbtnZurueck2)
        Me.Controls.Add(Me.rbtnZurueck1)
        Me.Controls.Add(Me.rbtnVor2)
        Me.Controls.Add(Me.rbtnVor1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEsc)
        Me.Location = New System.Drawing.Point(300, 300)
        Me.Text = "Motor Handsteuerung"

    End Sub

#End Region
    Public vh1 As Integer 'handle für TP_M1_Hand_Vor
    Public vh2 As Integer 'handle für TP_M1_Hand_Rueck
    Public vh3 As Integer 'handle für TP_M2_Hand_Vor
    Public vh4 As Integer 'handle für TP_M2_Hand_Rueck


    Private Sub FMotorRichtung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'AppMgr.frm1.adsClient.DeleteDeviceNotification(AppMgr.frm1.hConnect(0))
            'AppMgr.frm1.adsClient.DeleteDeviceNotification(AppMgr.frm1.hConnect(1))
            'AppMgr.frm1.adsClient.DeleteDeviceNotification(AppMgr.frm1.hConnect(2))
            'AppMgr.frm1.adsClient.DeleteDeviceNotification(AppMgr.frm1.hConnect(3))

            vh1 = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_M1_Hand_Vor")
            vh2 = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_M1_Hand_Rueck")
            vh3 = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_M2_Hand_Vor")
            vh4 = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_M2_Hand_Rueck")
        Catch err As Exception
            MessageBox.Show(err.Message & vbCr & "fehler bei der verbindung oder kein handle verfügbar!")
        End Try
    End Sub


    Private Sub btnEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsc.Click
        Try
            AppMgr.frm1.adsClient.WriteAny(vh1, False)
            AppMgr.frm1.adsClient.WriteAny(vh2, False)
            AppMgr.frm1.adsClient.WriteAny(vh3, False)
            AppMgr.frm1.adsClient.WriteAny(vh4, False)
            AppMgr.frm1.adsClient.DeleteVariableHandle(vh1)
            AppMgr.frm1.adsClient.DeleteVariableHandle(vh2)
            AppMgr.frm1.adsClient.DeleteVariableHandle(vh3)
            AppMgr.frm1.adsClient.DeleteVariableHandle(vh4)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        AppMgr.frm1.Enabled() = True
        'AppMgr.frm1.Form1_Load(sender, e)
        Me.Close()
        AppMgr.frm1.motorrichtung1 = Nothing  'object löschen, für wiederholtes öffnen der steuerung...
    End Sub

    Private Sub rbtnVor1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnVor1.Click
        rbtnZurueck1.Checked = False
        AppMgr.frm1.adsClient.WriteAny(vh1, rbtnVor1.Checked)
        AppMgr.frm1.adsClient.WriteAny(vh2, rbtnZurueck1.Checked)
        
    End Sub

    Private Sub rbtnZurueck1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnZurueck1.Click
        rbtnVor1.Checked = False
        AppMgr.frm1.adsClient.WriteAny(vh2, rbtnZurueck1.Checked)
        AppMgr.frm1.adsClient.WriteAny(vh1, rbtnVor1.Checked)
    End Sub

    Private Sub rbtnVor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnVor2.Click
        rbtnZurueck2.Checked = False
        AppMgr.frm1.adsClient.WriteAny(vh3, rbtnVor2.Checked)
        AppMgr.frm1.adsClient.WriteAny(vh4, rbtnZurueck2.Checked)
    End Sub

    Private Sub rbtnZurueck2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnZurueck2.Click
        rbtnVor2.Checked = False
        AppMgr.frm1.adsClient.WriteAny(vh4, rbtnZurueck2.Checked)
        AppMgr.frm1.adsClient.WriteAny(vh3, rbtnVor2.Checked)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.DrawRectangle(New Pen(Color.Black), 28, 52, 132, 68)
        e.Graphics.DrawRectangle(New Pen(Color.Black), 28, 132, 132, 68)
        e.Graphics.DrawRectangle(New Pen(Color.Black), 300, 52, 132, 68)
        e.Graphics.DrawRectangle(New Pen(Color.Black), 300, 132, 132, 68)
        ' e.Graphics.FillRectangle(New SolidBrush(Color.Gray), lblPos1Farbe12.Location.X, lblPos1Farbe12.Location.Y + 100, lblPos1Farbe12.Width, lblPos1Farbe12.Height)
        MyBase.OnPaint(e)
    End Sub
End Class
