Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

Public Class CInileser
    Public strpath As String = ""

    Public Sub New(Optional ByVal dateipfad As String = "default")
        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then
            strpath = strpath.Substring(6)
        End If

        MsgBox(strpath)

        If dateipfad = "/kokev.ini" Then
            If File.Exists(strpath & dateipfad) Then
                Me.LoadIniValues(strpath & dateipfad)
                MsgBox("habe geladen")
            Else
                Me.neueIniDateiAnlegen()
            End If
        End If

        If dateipfad = "/kettentypen.txt" Then
            If File.Exists(strpath & dateipfad) Then
                Me.LoadKettenTypValues(strpath & dateipfad)
                MsgBox("habe geladen!")
            Else
                Me.neueKettenTypDateiAnlegen()
            End If
        End If
    End Sub

    Public iniwerte(31) As String 'für 32 werte
    'Public KettenTypwerteStr(9, 11) As String '12 werte
    Public KettenTypWerteSho(4, 11) As String 'string muss noch zu short gecastet werden...

    ' INI-API
    Private Declare Function WritePrivateProfileString Lib _
                "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, _
                                                               ByVal lpKeyName As String, _
                                                               ByVal lpString As String, _
                                                               ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib _
                "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, _
                                                             ByVal lpKeyName As String, _
                                                             ByVal lpDefault As String, _
                                                             ByVal lpReturnedString As String, _
                                                             ByVal nSize As Integer, _
                                                             ByVal lpFileName As String) As Integer

    ' Speichert einen INI-Wert
    Private Sub WriteINI(ByVal Pfad As String, ByVal Sektion As String, Optional ByVal Key As String = vbNullString, Optional ByVal Value As String = vbNullString)
        WritePrivateProfileString(Sektion, Key, Value, Pfad)
    End Sub

    ' Liest einen INI-Wert aus
    Private Function GetINI(ByVal Pfad As String, ByVal Sektion As String, ByVal Key As String, Optional ByVal DefaultValue As String = "def") As String
        Dim MyStr As String = Space(100)
        Dim MyLength As Integer = GetPrivateProfileString(Sektion, Key, DefaultValue, MyStr, MyStr.Length, Pfad)
        GetINI = Microsoft.VisualBasic.Left(MyStr, MyLength)
    End Function

    Public Sub SaveValues(ByVal Pfad As String, ByVal Sektion As String, Optional ByVal Key As String = vbNullString, Optional ByVal Value As String = vbNullString)
        ' Werte speichern
        WriteINI(Pfad, Sektion, Key, Value)
        ' WriteINI(Application.StartupPath & "\settings.INI", Number, "Name", TxtName.Text)
        'WriteINI(Application.StartupPath & "\settings.INI", Number, "Alter", TxtAlter.Text)
        'WriteINI(Application.StartupPath & "\settings.INI", Number, "Geschlecht", IIf(RdbWeiblich.Checked = True, "w", "m"))
        'WriteINI(Application.StartupPath & "\settings.INI", Number, "Gewicht", TxtGewicht.Text)
    End Sub


    Public Sub LoadIniValues(ByVal str_path As String)  'wenn die Ini datei existiert....
        ' Werte einlesen
        iniwerte(0) = GetINI(str_path, "Auftragsverwaltung", "ArtikelfilesPfad")
        iniwerte(1) = GetINI(str_path, "Auftragsverwaltung", "AktuellerArtikel")
        iniwerte(2) = GetINI(str_path, "Auftragsverwaltung", "MinChainLength")
        iniwerte(3) = GetINI(str_path, "Auftragsverwaltung", "MaxChainLength")
        iniwerte(4) = GetINI(str_path, "Maschinenstörungen", "MalFilePath")
        iniwerte(5) = GetINI(str_path, "Maschinenstörungen", "MalFileName")
        iniwerte(6) = GetINI(str_path, "Maschinenstörungen", "Analyse")
        iniwerte(7) = GetINI(str_path, "Maschinenstörungen", "WriteFile")
        iniwerte(8) = GetINI(str_path, "Kettenfehler", "ChainErrorFilePath")
        iniwerte(9) = GetINI(str_path, "Kettenfehler", "ChainErrorFileName")
        iniwerte(10) = GetINI(str_path, "Kettenfehler", "Analyse")
        iniwerte(11) = GetINI(str_path, "Kettenfehler", "WriteFile")
        iniwerte(12) = GetINI(str_path, "Systemfehler", "File")
        iniwerte(13) = GetINI(str_path, "Zuordnungsdateien", "Störungstexte")
        iniwerte(14) = GetINI(str_path, "Zuordnungsdateien", "Bedienernamen")
        iniwerte(15) = GetINI(str_path, "MasterUser", "Bedienernummer")
        iniwerte(16) = GetINI(str_path, "Remote", "Enable")
        iniwerte(17) = GetINI(str_path, "Remote", "RemoteDisableAV")
        iniwerte(18) = GetINI(str_path, "Remote", "RemotePort")
        iniwerte(19) = GetINI(str_path, "Remote", "ServerPort")
        iniwerte(20) = GetINI(str_path, "Remote", "ServerIP")
        iniwerte(21) = GetINI(str_path, "Konfiguration", "ColorTable")
        iniwerte(22) = GetINI(str_path, "Konfiguration", "MaschineName")
        iniwerte(23) = GetINI(str_path, "Konfiguration", "KettenFlexi")
        iniwerte(24) = GetINI(str_path, "Konfiguration", "NKRvisible")
        iniwerte(25) = GetINI(str_path, "Konfiguration", "HueRiApp")
        iniwerte(26) = GetINI(str_path, "Konfiguration", "HBBefuellen")
        iniwerte(27) = GetINI(str_path, "Konfiguration", "Topf2Drehzahl")
        iniwerte(28) = GetINI(str_path, "Maschinenparameter", "NKR_Einzug")
        iniwerte(29) = GetINI(str_path, "Maschinenparameter", "SM_Teller")
        iniwerte(30) = GetINI(str_path, "Maschinenparameter", "ServoMontage")
        iniwerte(31) = GetINI(str_path, "Maschinenparameter", "ServoMasspresse")
        'bsp zum anzeigen:
        MsgBox(iniwerte(0) & vbCrLf & iniwerte(1) & vbCrLf & iniwerte(31))
    End Sub

    '**************** iniwerte array Belegung zur Einsicht ************************
    '[Auftragsverwaltung]
    'iniwerte(0) =  ArtikelfilesPfad=c:\Visualisierung\AV\
    'iniwerte(1) =  AktuellerArtikel=89999999
    'iniwerte(2) =  MinChainLength=1
    'iniwerte(3) =  MaxChainLength=1000
    '[Maschinenstörungen]
    'iniwerte(4) =  MalFilePath=c:\Visualisierung\Störungen\
    'iniwerte(5) =  MalFileName=störungen
    'iniwerte(6) =  Analyse=0
    'iniwerte(7) =  WriteFile=1
    '[Kettenfehler]
    'iniwerte(8) =  ChainErrorFilePath=c:\Visualisierung\Kettenfehler\
    'iniwerte(9) =  ChainErrorFileName=Kettenfehler
    'iniwerte(10) =  Analyse=
    'iniwerte(11) =  WriteFile=0
    '[Systemfehler]
    'iniwerte(12) =  File=0
    '[Zuordnungsdateien]
    'iniwerte(13) =  Störungstexte=störungen.txt
    'iniwerte(14) =  Bedienernamen=bediener.txt
    '[MasterUser]
    'iniwerte(15) =  Bedienernummer=9999
    '[Remote]
    'iniwerte(16) =  Enable=0
    'iniwerte(17) =  RemoteDisableAV=0
    'iniwerte(18) =  RemotePort=5444
    'iniwerte(19) =  ServerPort=5445
    'iniwerte(20) =  ServerIP=192.168.0.45
    '[Konfiguration]
    'iniwerte(21) =  ColorTable=13FF-F51B-B2E0-2F49
    'iniwerte(22) =  MaschineName=kokev xxxxBeispiel
    'iniwerte(23) =  KettenFlexi=0
    'iniwerte(24) =  NKRvisible=0
    'iniwerte(25) =  HueRiApp=1
    'iniwerte(26) =  HBBefuellen=1
    'iniwerte(27) =  Topf2Drehzahl=0
    '[Maschinenparameter]
    'iniwerte(28) =  NKR_Einzug=0
    'iniwerte(29) =  SM_Teller=0
    'iniwerte(30) =  ServoMontage=0
    'iniwerte(31) =  ServoMasspresse=0


    Private Sub neueIniDateiAnlegen()  'wenn noch keine Ini datei existiert....(nur bei neustarts des systems ohne zugehörige ini)
        Dim defaultiniwerte As String
        Dim objDateiMacher As StreamWriter

        defaultiniwerte = "[Auftragsverwaltung]" & vbCrLf & _
                          "ArtikelfilesPfad=IBN\" & vbCrLf & _
                          "AktuellerArtikel=89999999" & vbCrLf & _
                          "MinChainLength=1" & vbCrLf & _
                          "MaxChainLength=1000" & vbCrLf & _
                          "[Maschinenstörungen]" & vbCrLf & _
                          "MalFilePath=IBN\Störungen\" & vbCrLf & _
                          "MalFileName=störungen" & vbCrLf & _
                          "Analyse=0" & vbCrLf & _
                          "WriteFile=1" & vbCrLf & _
                          "[Kettenfehler]" & vbCrLf & _
                          "ChainErrorFilePath=IBN\Kettenfehler\" & vbCrLf & _
                          "ChainErrorFileName=Kettenfehler" & vbCrLf & _
                          "Analyse=0" & vbCrLf & _
                          "WriteFile=0" & vbCrLf & _
                          "[Systemfehler]" & vbCrLf & _
                          "File=0" & vbCrLf & _
                          "[Zuordnungsdateien]" & vbCrLf & _
                          "Störungstexte=störungen.txt" & vbCrLf & _
                          "Bedienernamen=bediener.txt" & vbCrLf & _
                          "[MasterUser]" & vbCrLf & _
                          "Bedienernummer=9999" & vbCrLf & _
                          "[Remote]" & vbCrLf & _
                          "Enable=0" & vbCrLf & _
                          "RemoteDisableAV=0" & vbCrLf & _
                          "RemotePort=5444" & vbCrLf & _
                          "ServerPort=5445" & vbCrLf & _
                          "ServerIP=192.168.0.45" & vbCrLf & _
                          "[Konfiguration]" & vbCrLf & _
                          "ColorTable=13FF-F51B-B2E0-2F49" & vbCrLf & _
                          "MaschineName=IGLD G53_A" & vbCrLf & _
                          "KettenFlexi=0" & vbCrLf & _
                          "NKRvisible=0" & vbCrLf & _
                          "HueRiApp=1" & vbCrLf & _
                          "HBBefuellen=1" & vbCrLf & _
                          "Topf2Drehzahl=0" & vbCrLf & _
                          "[Maschinenparameter]" & vbCrLf & _
                          "NKR_Einzug=0" & vbCrLf & _
                          "SM_Teller=0" & vbCrLf & _
                          "ServoMontage=0" & vbCrLf & _
                          "ServoMasspresse=0"
        objDateiMacher = New StreamWriter(strpath & "/kokev.ini")
        objDateiMacher.Write(defaultiniwerte)
        objDateiMacher.Close()
        objDateiMacher = Nothing


        MsgBox(defaultiniwerte)


    End Sub

    Public Sub LoadKettenTypValues(ByVal str_path As String) 'wenn die Kettentyp datei existiert....
        ' Werte einlesen
        Dim TempTypSection As String = ""
        For n As Integer = 0 To 4
            Select Case n
                Case 0 : TempTypSection = "typ0"
                Case 1 : TempTypSection = "typ1"
                Case 2 : TempTypSection = "typ2"
                Case 3 : TempTypSection = "typ3"
                Case 4 : TempTypSection = "typ4"
            End Select

            'Short.parse castet rückgabestring als short wert( ist in twincad ein integer wert)
            KettenTypWerteSho(n, 0) = GetINI(str_path, TempTypSection, "typaktiv")
            KettenTypWerteSho(n, 1) = GetINI(str_path, TempTypSection, "klaenge")
            KettenTypWerteSho(n, 2) = GetINI(str_path, TempTypSection, "pos1")
            KettenTypWerteSho(n, 3) = GetINI(str_path, TempTypSection, "pos1farbe")
            KettenTypWerteSho(n, 4) = GetINI(str_path, TempTypSection, "pos2")
            KettenTypWerteSho(n, 5) = GetINI(str_path, TempTypSection, "pos2farbe")
            KettenTypWerteSho(n, 6) = GetINI(str_path, TempTypSection, "pos3")
            KettenTypWerteSho(n, 7) = GetINI(str_path, TempTypSection, "pos3farbe")
            KettenTypWerteSho(n, 8) = GetINI(str_path, TempTypSection, "pos4")
            KettenTypWerteSho(n, 9) = GetINI(str_path, TempTypSection, "pos4farbe")
            KettenTypWerteSho(n, 10) = GetINI(str_path, TempTypSection, "pos5")
            KettenTypWerteSho(n, 11) = GetINI(str_path, TempTypSection, "pos5farbe")
        Next

        MsgBox(KettenTypWerteSho(0, 0))
        MsgBox(KettenTypWerteSho(0, 1))
        'testen der ausgelesenen werte...
        'For s As Integer = 0 To 4
        'For q As Integer = 0 To 11
        'Debug.WriteLine(KettenTypwerte(s, q))
        'Next
        'Next

    End Sub

    Private Sub neueKettenTypDateiAnlegen()
        Dim DefaultKettenTypWerte As String
        Dim objDateiMacher As StreamWriter

        DefaultKettenTypWerte = "[typ0]" & vbCrLf & _
                                "typaktiv=1" & vbCrLf & _
                                "klaenge=0" & vbCrLf & _
                                "pos1=0" & vbCrLf & _
                                "pos1farbe=0" & vbCrLf & _
                                "pos2=0" & vbCrLf & _
                                "pos2farbe=0" & vbCrLf & _
                                "pos3=0" & vbCrLf & _
                                "pos3farbe=0" & vbCrLf & _
                                "pos4=0" & vbCrLf & _
                                "pos4farbe=0" & vbCrLf & _
                                "pos5=0" & vbCrLf & _
                                "pos5farbe=0" & vbCrLf & _
                                "[typ1]" & vbCrLf & _
                                "typaktiv=0" & vbCrLf & _
                                "klaenge=0" & vbCrLf & _
                                "pos1=0" & vbCrLf & _
                                "pos1farbe=0" & vbCrLf & _
                                "pos2=0" & vbCrLf & _
                                "pos2farbe=0" & vbCrLf & _
                                "pos3=0" & vbCrLf & _
                                "pos3farbe=0" & vbCrLf & _
                                "pos4=0" & vbCrLf & _
                                "pos4farbe=0" & vbCrLf & _
                                "pos5=0" & vbCrLf & _
                                "pos5farbe=0" & vbCrLf & _
                                "[typ2]" & vbCrLf & _
                                "typaktiv=0" & vbCrLf & _
                                "klaenge=0" & vbCrLf & _
                                "pos1=0" & vbCrLf & _
                                "pos1farbe=0" & vbCrLf & _
                                "pos2=0" & vbCrLf & _
                                "pos2farbe=0" & vbCrLf & _
                                "pos3=0" & vbCrLf & _
                                "pos3farbe=0" & vbCrLf & _
                                "pos4=0" & vbCrLf & _
                                "pos4farbe=0" & vbCrLf & _
                                "pos5=0" & vbCrLf & _
                                "pos5farbe=0" & vbCrLf & _
                                "[typ3]" & vbCrLf & _
                                "typaktiv=0" & vbCrLf & _
                                "klaenge=0" & vbCrLf & _
                                "pos1=0" & vbCrLf & _
                                "pos1farbe=0" & vbCrLf & _
                                "pos2=0" & vbCrLf & _
                                "pos2farbe=0" & vbCrLf & _
                                "pos3=0" & vbCrLf & _
                                "pos3farbe=0" & vbCrLf & _
                                "pos4=0" & vbCrLf & _
                                "pos4farbe=0" & vbCrLf & _
                                "pos5=0" & vbCrLf & _
                                "pos5farbe=0" & vbCrLf & _
                                "[typ4]" & vbCrLf & _
                                "typaktiv=0" & vbCrLf & _
                                "klaenge=0" & vbCrLf & _
                                "pos1=0" & vbCrLf & _
                                "pos1farbe=0" & vbCrLf & _
                                "pos2=0" & vbCrLf & _
                                "pos2farbe=0" & vbCrLf & _
                                "pos3=0" & vbCrLf & _
                                "pos3farbe=0" & vbCrLf & _
                                "pos4=0" & vbCrLf & _
                                "pos4farbe=0" & vbCrLf & _
                                "pos5=0" & vbCrLf & _
                                "pos5farbe=0"

        objDateiMacher = New StreamWriter(strpath & "/kettentypen.txt")
        objDateiMacher.Write(DefaultKettenTypWerte)
        objDateiMacher.Close()
        objDateiMacher = Nothing


        MsgBox(DefaultKettenTypWerte)

    End Sub

End Class
