CoDeSys+X   �         �         @        @   2.3.6.0    @    @             &��G A   C:\TwinCAT\Plc\Upload\ @                           �f/F   |C:\TwinCAT\Plc\Upload\VisuBmp\   C:\TwinCAT\Plc\Upload\PLCCONF\�D   @      C:\TWINCAT\PLC\LIB\STANDARD.LIB          CONCAT               STR1               ��              STR2               ��                 CONCAT                                         ��66  �   ����           CTD           M             ��           Variable for CD Edge Detection      CD            ��           Count Down on rising edge    LOAD            ��           Load Start Value    PV           ��           Start Value       Q            ��           Counter reached 0    CV           ��           Current Counter Value             ��66  �   ����           CTU           M             ��            Variable for CU Edge Detection       CU            ��       
    Count Up    RESET            ��           Reset Counter to 0    PV           ��           Counter Limit       Q            ��           Counter reached the Limit    CV           ��           Current Counter Value             ��66  �   ����           CTUD           MU             ��            Variable for CU Edge Detection    MD             ��            Variable for CD Edge Detection       CU            ��	       
    Count Up    CD            ��
           Count Down    RESET            ��           Reset Counter to Null    LOAD            ��           Load Start Value    PV           ��           Start Value / Counter Limit       QU            ��           Counter reached Limit    QD            ��           Counter reached Null    CV           ��           Current Counter Value             ��66  �   ����           DELETE               STR               ��              LEN           ��              POS           ��                 DELETE                                         ��66  �   ����           F_TRIG           M             ��
                 CLK            ��           Signal to detect       Q            ��           Edge detected             ��66  �   ����           FIND               STR1               ��              STR2               ��                 FIND                                     ��66  �   ����           INSERT               STR1               ��              STR2               ��              POS           ��                 INSERT                                         ��66  �   ����           LEFT               STR               ��              SIZE           ��                 LEFT                                         ��66  �   ����           LEN               STR               ��                 LEN                                     ��66  �   ����           MID               STR               ��              LEN           ��              POS           ��                 MID                                         ��66  �   ����           R_TRIG           M             ��
                 CLK            ��           Signal to detect       Q            ��           Edge detected             ��66  �   ����           REPLACE               STR1               ��              STR2               ��              L           ��              P           ��                 REPLACE                                         ��66  �   ����           RIGHT               STR               ��              SIZE           ��                 RIGHT                                         ��66  �   ����           RS               SET            ��              RESET1            ��                 Q1            ��
                       ��66  �   ����           SEMA           X             ��                 CLAIM            ��	              RELEASE            ��
                 BUSY            ��                       ��66  �   ����           SR               SET1            ��              RESET            ��                 Q1            ��	                       ��66  �   ����           TOF           M             ��           internal variable 	   StartTime            ��           internal variable       IN            ��       ?    starts timer with falling edge, resets timer with rising edge    PT           ��           time to pass, before Q is set       Q            ��	       2    is FALSE, PT seconds after IN had a falling edge    ET           ��
           elapsed time             ��66  �   ����           TON           M             ��           internal variable 	   StartTime            ��           internal variable       IN            ��       ?    starts timer with rising edge, resets timer with falling edge    PT           ��           time to pass, before Q is set       Q            ��	       0    is TRUE, PT seconds after IN had a rising edge    ET           ��
           elapsed time             ��66  �   ����           TP        	   StartTime            ��           internal variable       IN            ��       !    Trigger for Start of the Signal    PT           ��       '    The length of the High-Signal in 10ms       Q            ��	           The pulse    ET           ��
       &    The current phase of the High-Signal             ��66  �   ����                  _ASM_FU_SOLLW           Pos_Abw_Abs            #               SollwFix    �>     #                  AutoPos            #               SollW           #               Brems_Fenster           #               IstW           #               P           #               Pos_Fenster           #               VFix_Vor            # 	           
   VFix_Rueck            # 
                 SollwReg           #               MotVor            #               MotRueck            #               Pos_Erreicht            #                        ���F  @    ����           ANLAGESTOERUNG     	      TON1                    TON    $               PF_1                 R_TRIG    $               TON2                    TON    $               TOF1                    TOF    $               TON3                    TON    $               TON4                    TON    $               TOF2                    TOF    $               RS_1                 RS    $               RS_2                 RS    $                  Taste_Ventil_Ein            $               Taste_Ventil_Aus            $               H_Hand            $                  Antriebe_Stoerung            $               V_Ventil            $ 	                       ���F  @    ����           BETRIEBSARTENANWAHL               Antriebe_Stoerung            %               Kette_Fehler            %                  V_Autogestoppt            %               V_Autogestartet            %                        ���F  @    ����        
   FARBSENSOR           Fehler_Farbe_Reg             )               grau             )               gelb             )               rot             )               blau             )               keine             )               Offset_Pos_Farbsensor    %      )                  Quitt_Fehler            )               Farbsensor_Aktiv            )                  Fehler_Farbe            )                        ���F  @    ����           FB_TRIG_KAMM           TP1                   TP    F                      VIndDistTiming            F                        ���F  @    ����           FEHLERZAEHLER           PF1                 R_TRIG    E               PF2                 R_TRIG    E               PF3                 R_TRIG    E 	              PF4                 R_TRIG    E 
              PF5                 R_TRIG    E               PF6                 R_TRIG    E               PF7                 R_TRIG    E               PF8                 R_TRIG    E               PF9                 R_TRIG    E               PF10                 R_TRIG    E               PF11                 R_TRIG    E               PF12                 R_TRIG    E                                ���F  @    ����           INIT           RESET             5               CTUD2        
                CTUD    5               Glieder_zurueck    P      5 
                               ���F  @    ����           KAMMERA     
      Zeiger_Kammera            *               Fehler_Kammera_Reg             *               TP1                   TP    *               V1             *               V2             *               V3             *               PF1                 R_TRIG    *               NF1                 F_TRIG    *               Kamm_Trig_Frg             *               Offset_Pos_Kammera    L      *                  Quitt_Fehler            *               Kammera_Aktiv            *               
   Fehler_ALO            *            
   Fehler_ALU            *            
   Fehler_ILO            * 	           
   Fehler_ILU            * 
           
   Fehler_ROL            *            
   Fehler_ROR            *                        ���F  @    ����           KAMMPRG           KAMM_TRIG_POS            H               FB_TRIG_KAMM_1                FB_Trig_KAMM    H               IC_alt            H               Delta            H               Offsett    @    H 
                               ���F  @    ����           KETTEENDKONTROLLE           Offset_Endkontrolle    P      +                  Quitt_Fehler            +               Kontrolle_Aktiv            +                  Fehler_Kette            +                        ���F  @    ����           KETTENSPEICHER           KettenspGeschlossen             6        !    alle Kettenspeicher geschlossen    _Kettenpeicher1                KS    6               _Kettenpeicher2                KS    6               _Act_Pos_KS             6               FB_Sollw_Mot1                            _ASM_FU_SOLLW    6               FB_Sollw_Mot2                            _ASM_FU_SOLLW    6               Ventil_Integer1                Ventil_Integer    6 
              Frg_Reg_MotVor2             6               Frg_reg_MotRueck2             6               Mot2_Pos_Erreicht             6               Frg_Reg_MotVor1             6               Frg_Reg_MotRueck1             6               Mot1_Pos_Erreicht             6               CTU3                    CTU    6               PF1                 R_TRIG    6               PF2                 R_TRIG    6               CTU4                    CTU    6               PF3                 R_TRIG    6               PF4                 R_TRIG    6               SR_1                 SR    6               NF_1                 F_TRIG    6               SR_2                 SR    6               NF_2                 F_TRIG    6               PF_10                 R_TRIG    6               SR_3                 SR    6               RS_4                 RS    6                                ���F  @    ����           KS           KS_ready             ,            Kettenspeicher bereit       URL_Geschlossen            ,            Umlenkrolle geschlossen    SpannzylinderGespannt            ,        '    Spannzylinder Kettenspeicher gespannt    ActPress           ,            Druck-Istwert Spannzylinder 
   ActPos_ULR           ,            Positions-Istwert Umlenkrolle    MinPress           ,            minimaler Druck Spannzylinder    MaxPress           ,            maximaler Druck Spannzylinder 
   MinPos_ULR           , 	           minimale Position Umlenkrolle 
   MaxPos_ULR           , 
           maximale Position Umlenkrolle       En_Input            ,            Freigabe Bef�llen 	   En_Output            ,            Freigabe Entnahme    ActState           ,            aktueller Zustand f�r Visu             ���F  @    ����           LASCHEDISTSENSOR           Zeiger_LascheDistSensor            - 
              TP1                   TP    -               Fehler_DIST_Reg             -               Offset_LascheDistSensor    <      -               LasDist_Schwelle    �     -                  Quitt_Fehler            -               LascheDist_Aktiv            -                  Fehler_LascheDistSensor            -                        ��F  @    ����           LASERSENSOR           Zeiger_Lasersensor            .               v1             .               Fehler_Laser_Reg             .               V23             .               S2            .               Offset_Lasersensor    0      .               Las_Schwelle    x7     .            Schwelle f�r Laschenabstand   Las_Schwelle_2    (#     .            Schwelle f�r Bolzenh�che       Quitt_Fehler            .               Laschenabstand_Aktiv            .               Bolzenhoehe_Aktiv            .               !   Fehler_Lasersensor_Laschenabstand            .               Fehler_Lasersensor_Bolzenhoeche            . 	                       "�F  @    ����           MAIN_1     !      Trennstelle1                Trennstelle    7               Farbsensor1        
             
   Farbsensor    7               Lasersensor1                           Lasersensor    7               LascheDistSensor1                      LascheDistSensor    7               Kammera1                                Kammera    7               KetteEndKontrolle1                  KetteEndKontrolle    7               Anlagenstoerung1                            Anlagestoerung    7 
              Betriebsartenanwahl1                  Betriebsartenanwahl    7               Antriebe_Stoerung             7               V1             7               SR1                 SR    7               V_Fehlerspeicher5             7               SR2                 SR    7               Z1                    CTU    7               V2             7               SR3                 SR    7               V_Fehlerspeicher1             7               SR4                 SR    7               V_Fehlerspeicher2             7               SR5                 SR    7               PF_F10                 R_TRIG    7               VH_KettenAnfang             7               TP1                   TP    7               Fehlrz_1                          Fehlerzaehler    7               RS2                 RS    7               TON_1                    TON    7            	   PF_REF_IO                 R_TRIG    7               PF_Dummy_Erkennung                 R_TRIG    7               SR_Dymmy_FRG                 SR    7                TON_Sperre2                    TON    7 !              PF_SP1                 R_TRIG    7 "              PF_SP2                 R_TRIG    7 #              SR_Spere2Pruef                 SR    7 $                               ���F  @    ����           MAIN_2                             ���F  @    ����           NOCKENSCHALTWERK     	      Zeiger            9               Nocke             9               Zaeler            9           Skal_IC_SSI_DG_Input: DINT;   Skal_IC_SSI_DG_Input_Alt            9               Skal_IC_SSI_DG_Input_Delta            9            
   K_DG_Input            9 	              K_DG_In_Alt            9 
              K_DG_In_Delta            9               CTU2            9                                ���F  @    ����           SCHRITTKETTE           INIT                           _INIT                        	   AUTOMATIK                         
   _AUTOMATIK                            RUECK_1                            _RUECK_1                            VOR_1                            _VOR_1                            RUECK_2                            _RUECK_2                         	   TRENNEN_1                         
   _TRENNEN_1                            RUECK_3                            _RUECK_3                         	   TRENNEN_2                         
   _TRENNEN_2                                             ���F  @    ����           TRENNSTELLE           J            3 
              Gliederzahl_Alt            3               V1             3                  TasteKettenanfang            3            Taste am Bedienpanell    H_Handbetrieb            3        3   Leuchte am Bedienpanell Maschine ist in Handbetrieb      H_KettenAnfang            3           Leuchte am Bedienpanell            ���F  @    ����           VENTIL_INTEGER               K            4            
   IN_Integer           4                  OUT_Integer           4                        ���F  @    ����            
 �  % E             R   I   G   U   V   W      %   )   9   8      7   J   H      6   +   5   F   -   #   ,   4   3   *   .   $   C   D   ����<   B   ( �F      K   �F     K   �F     K   �F     K   �F                 �F         +     ��localhost       �¿w   �A     �       ��    ��      � �\�wp �w�����¿w>�3     �� �A        @����A     x.bP� H.b\�        H.b   P.b�!���   ��    �� t� X� �|��|������|�� �A        �� �A     ��� ��E���� � ��� ��E����,� =��     ,   ,                                                        K         @   ���F�H  /*BECKCONFI3*/
        !�� @   @   �   �     3                 Standard     P   Panel            	&��G                        VAR_GLOBAL
END_VAR
                                                                                  "   , , : ��              Standard        	MAIN_1();
Kammprg();����                 PanelP        	MAIN_2();����               ���F                 $����                         x*�)0+�+           Standard �f/F	�f/F      �788p8�9                         	b��G                        VAR_CONFIG
END_VAR
                                                                                   '           B   , n � �           Globale_Variablen ���F	&��GB     ����           �&  VAR_GLOBAL


	(* Hardwareeing�nge *)
	Not_Aus 			 	AT %IX0.0 : BOOL; (* Eingang 1 *)
	Schutzhaube_Auf  	AT %IX0.1 : BOOL; (* Eingang 2 *)
	DruckW	  			AT %IX0.2 : BOOL; (* Eingang 3 *)
	RES_1  				AT %IX0.3 : BOOL; (* Eingang 4 *)
	FlaechenSp1_IO_ 	AT %IX0.4 : BOOL; (* Eingang 5 *)
	FlaechenSp2_IO_		AT %IX0.5 : BOOL; (* Eingang 6 *)
	HWT_VISU  			AT %IX0.6 : BOOL; (* Eingang 7 *)
	HWT_Kammera		AT %IX0.7 : BOOL; (* Eingang 8 *)

       LaserDistOUT1  		AT %IX1.0 : BOOL; (* Eingang 9 *)
	LaserDistOUT2  		AT %IX1.1 : BOOL; (* Eingang 10 *)
	LaserDistDirt  			AT %IX1.2 : BOOL; (* Eingang 11 *)
	LaserDistPuls  		AT %IX1.3 : BOOL; (* Eingang 12 *)
	Speicher12Offen  		AT %IX1.4 : BOOL; (* Eingang 13 *)
	IndDistLow 			AT %IX1.5 : BOOL; (* Eingang 14 *)
	IndDistGo				AT %IX1.6 : BOOL; (* Speicher 1 ist geschlo�en *)
	IndDistHigh 			AT %IX1.7 : BOOL; (* Speicher 2 ist geschlo�en *)

	KammOut0  			AT %IX2.0 : BOOL; (* Eingang 17 *)
	KammOut1  			AT %IX2.1 : BOOL; (* Eingang 18 *)
	KammOut2  			AT %IX2.2 : BOOL; (* Eingang 19 *)
	KammOut3 			AT %IX2.3 : BOOL; (* Eingang 20 *)
	KammOut4 			AT %IX2.4 : BOOL; (* Eingang 21 *)
	KammOut5			AT %IX2.5 : BOOL; (* Eingang 22 *)
	KammOut6			AT %IX2.6 : BOOL; (* Eingang 23 *)
	KammOut7			AT %IX2.7 : BOOL; (* Eingang 24 *)

	Farbe1 				AT %IX5.0 : BOOL; (* Farbe1 *)
	Farbe2 				AT %IX5.1 : BOOL; (* Farbe2 *)
	Farbe3 				AT %IX5.2 : BOOL; (* Farbe3 *)
	Farbe4 				AT %IX5.3 : BOOL; (* Farbe4 *)

	(*Eing�nge f�r die Panel Tasten*)
	T_Quitt_NA  AT %IX10.0 : BOOL; (* Eingang 9 *)
	T_Qiutt_Stoerung  AT %IX10.1 : BOOL; (* Eingang 10 *)
	T_Hand  AT %IX10.2 : BOOL; (* Eingang 11 *)
	T_Auto  AT %IX10.3 : BOOL; (* Eingang 12 *)
	T_Visu  AT %IX10.4 : BOOL; (* Eingang 13 *)
	T_KammBild  AT %IX10.5 : BOOL; (* Eingang 14 *)

	T_Start  AT %IX11.0 : BOOL; (* Eingang 15 *)
	T_Stop  AT %IX11.1 : BOOL; (* Eingang 16 *)
	T_Rueck_Fehlerstelle   AT %IX11.2 : BOOL; (* Eingang 17 *)
	T_Rueck_Kettenanfang  AT %IX11.3 : BOOL; (* Eingang 18 *)
	T_Druckluft_Ein AT %IX11.4 : BOOL; (* Eingang 19 *)
	T_Druckluft_Aus  AT %IX11.5 : BOOL; (* Eingang 20 *)
	ET13  AT %IX11.6 : BOOL; (* Eingang 21 *)
	ET14  AT %IX11.7 : BOOL; (* Eingang 22 *)
	T_KettenAnfang  AT %IX12.0 : BOOL; (* Eingang 23 *)
	ET16  AT %IX12.1 : BOOL; (* Eingang 24 *)


	IA_Pos_KS1_Input  	AT%IW20:INT;	 	(*Speicher 1 F�llstand analoger Eingang*)
	IA_Pos_KS2_Input	AT%IW22:INT;   	(*Speicher 2 F�llstand analoger Eingang*)
	VW_Act_Pos_KS1: INT;					(*Aktueller F�llstand Kettenspeicher 1 skaliert*)
	VW_Act_Pos_KS2:INT;					(*Aktueller F�llstand Kettenspeicher 2 skaliert*)
	IA_Las_Sensor	AT%IW24:INT; 		(*Analogwert von Lasersensor*)
	IA_EW4  	AT%IW26:INT; 				(*Analogeingang 4*)
	IC_SSI_DG_Input  AT %ID44:UDINT;	(* Drehgeber *)
	My_IC_SSI_DG_Input:UDINT;

	_PneumPressEin 	AT %QX0.0 : BOOL; (* Ventil Pneumatik  *)
	IndDistTiming  		AT %QX0.1 : BOOL; (* Ausgang 2 *)
	RESA1 				AT %QX0.2 : BOOL; (* Ausgang 3 *)
	AntriebeEin			AT %QX0.3 : BOOL; (* Ausgang 4 *)
	Motor1Vor				AT %QX0.4 : BOOL; (* Ausgang 5 *)
	Motor1Rueck			AT %QX0.5 : BOOL; (* Ausgang 6 *)
	Motor2Vor				AT %QX0.6 : BOOL; (* Ausgang 7 *)
	Motor2Rueck			AT %QX0.7 : BOOL; (* Ausgang 8 *)

	Leuchte_Rot			AT %QX1.0 : BOOL; (* Ausgang 9 *)
	Leuchte_Gelb			AT %QX1.1 : BOOL; (* Ausgang 10 *)
	Leuchte_Gruen		AT %QX1.2 : BOOL; (* Ausgang 11 *)
	RESA5					AT %QX1.3 : BOOL; (* Ausgang 12 *)
	FreigabenachfogeM	AT %QX1.4 : BOOL; (* Ausgang 13 *)
	TP_Anzeige			AT %QX1.5 : BOOL; (* Ausgang 14 *)
	Kamm_Anzeige		AT %QX1.6 : BOOL; (* Ausgang 15 *)
	Kamm_Trig     		AT %QX1.7 : BOOL; (* Ausgang 16 *)

	H_Quitt_NA  AT %QX10.0 : BOOL; (* Ausgang 1 *)
	H_Quitt_Stoerung  AT %QX10.1 : BOOL; (* Ausgang 2 *)
	H_Hand  AT %QX10.2 : BOOL; (* Ausgang 3 *)
	H_Auto  AT %QX10.3 : BOOL; (* Ausgang 4 *)
	H_Visu  AT %QX10.4 : BOOL; (* Ausgang 5 *)
	H_KammBild  AT %QX10.5 : BOOL; (* Ausgang 6 *)

	H_Start  AT %QX11.0 : BOOL; (* Ausgang 7 *)
	H_Stop  AT %QX11.1 : BOOL; (* Ausgang 8 *)
	H_Rueck_Fehlerstelle  AT %QX11.2 : BOOL; (* Ausgang 9 *)
	H_Rueck_Kettenanfang  AT %QX11.3 : BOOL; (* Ausgang 10 *)
	H_Ventil_Ein  AT %QX11.4 : BOOL; (* Ausgang 11 *)
	H_Ventil_Aus  AT %QX11.5 : BOOL; (* Ausgang 12 *)
	AT13  AT %QX11.6 : BOOL; (* Ausgang 13 *)
	AT14  AT %QX11.7 : BOOL; (* Ausgang 14 *)
	H_KettenAnfang  AT %QX12.0 : BOOL; (* Ausgang 15 *)
	AT16  AT %QX12.1 : BOOL; (* Ausgang 16 *)


	QA_Sollw_Mot1   AT%QW4:WORD; (*Ausgangswort 1*)
	QA_Sollw_Mot2   AT%QW6:WORD; (*Ausgangswort 2*)

								(* Nummer des g�ltigen Kettentyps ( 1-10)   *)
	Speicher_Reg: ARRAY[0..500] OF WORD;		(* Speicherregister f�r Glieder es werden maximal 500 Glieder beobachtet *)
	Ketten_Reg: ARRAY[0..220] OF WORD;			(* Kettenregister f�r dien Aktuellen Kettentyp *)
	Zeiger_Speicher_Trennstelle: INT;				(* Zeiger f�r die Glieder in der Anlage zeigt auf das Glied unter der Trennstelle *)
	Zeiger_Kette_Trennstelle:INT;					(* Zeiger f�r die Glieder der Kette zeigt auf das Glied unter der Trennstelle*)
	Zeiger_Kette_Anfang:INT;						(* Zeiger auf Anfang der Kette *)
	Zeiger_Loeschen: INT;							(* Zeiger zum L�schen der Register beim �berlauf *)
	Zeiger_Fehler_S1:INT;							(* Zeigt die Fehlerstelle (Glied ) des Fehlers an der Station 1 *)
	Zeiger_Fehler_S2:INT;							(* Zeigt die Fehlerstelle (Glied ) des Fehlers an der Station 2 *)
	Zeiger_Fehler_S3:INT;							(* Zeigt die Fehlerstelle (Glied ) des Fehlers an der Station 3 *)
	Zeiger_Fehler_S4:INT;							(* Zeigt die Fehlerstelle (Glied ) des Fehlers an der Station 4 *)


	M1:BOOL;
	ImpulsPos:BOOL;									(*Impuls wenn Drehgeber um ein Kettenglied nach weiter dreht*)
	ImpulsNeg:BOOL;								(*Impuls wenn Drehgeber um ein Kettenglied zur�ckdreht*)
	CTU1: CTU;

	Fehlerspeicher1 AT%QW200:WORD;			(* Fehler der einzigellnen Stationen*)
	Fehlerspeicher2 AT%QW196:WORD;			(*Fehler der Kammera*)
	Kontrolle_Aktiv AT%QW204:WORD:=47;			(*Aktivieren der einzellnen Stationen*)
	REF_IO:BOOL;									(*Anlage Referenziert*)
	REF_Enable:BOOL;								(*Referenzieren nach einschalten m�glich*)

	Stoerunganlage AT%QW208:WORD;			(*St�rungen der Anlage*)
	Antriebe_Stoerung:BOOL;
	Sammelstoerung AT%MX100.0 : BOOL;
	V_Autogestoppt:BOOL;
				(*Betriebsart*)
	V_Autogestartet:BOOL;							(*Betriebsart*)
	TP_M1_Hand_Vor:BOOL;							(*Startbefehl vom Touchpanell M1 vorw�rts Hand*)
	TP_M1_Hand_Rueck:BOOL;						(*Startbefehl vom Touchpanell M1 r�ckw�rts Hand*)
	TP_M2_Hand_Vor:BOOL;							(*Startbefehl vom Touchpanell M2 vorw�rts Hand*)
	TP_M2_Hand_Rueck:BOOL;						(*Startbefehl vom Touchpanell M1 r�ckw�rts Hand*)

	TP_Klappe:BOOL;
	Z_Beh:INT;
	ST_Behvoll:BOOL;
	ST_Behfehlt:BOOL;
	ST_AusschussKetteRaus: BOOL;

	KS1:KS_Control;
	KS2:KS_Control;

	Zureuck_2: BOOL:=TRUE;
	V_Erster_Zyklus:BOOL;



	Grund_Trig: BOOL;
	Neustart: BOOL;
	PF_Neustart: BOOL;
	XY: BOOL;
	wert: BOOL;
	PF_Fehlerspeicher1_6: R_TRIG;
	M2_Start_R: BOOL;
	Quitt_Auto: BOOL;
	Zeiger_Farbsensor:INT;
	Zeiger_Endkontrolle: INT;
	M2_Start_V: BOOL;									(*Ansteuerung M2 Vor von der Schrittkette*)
	Automatik2: BOOL;
	Z1SK: CTU;											(*Schrittkette*)
	Z2SK: CTU;											(*Schrittkette*)
	Z3SK: CTU;
		(*Schrittkette*)
	Z4SK: CTU;											(*Schrittkette*)
	FRG_DLA: BOOL;										(*Schrittkette*)
	S0_Automatik: BOOL;									(*Schrittkette*)
	S1_Rueck_1: BOOL;									(*Schrittkette*)
	S2_Vor_1: BOOL;										(*Schrittkette*)
	S3_Rueck_2: BOOL;									(*Schrittkette*)
	S4_Trennen_1: BOOL;								(*Schrittkette*)
	S5_Rueck_3: BOOL;									(*Schrittkette*)
	S6_Trennen_2: BOOL;								(*Schrittkette*)
	FlaechenSpFr: BOOL;
	Skal_IC_SSI_DG_Input: DINT;
	V_KettenAnfang: BOOL;
	Blink_TON1: TON;
	Blink_TON2: TON;
	Sperre_2Pruef: BOOL;

	FlaechenSp1_IO:BOOL;
	FlaechenSp2_IO:BOOL;
	KAMM_TRIG_Scal_: DINT;
	PF_KAMM_TRIG: R_TRIG;
	IO_KETTE: BOOL;
	TP_Dummy_Quitt:		BOOL;
	Dummy_NIO :				BOOL;
	WLaser:					BOOL;




	Dummy: BOOL;
	Sperre_21: BOOL;
	Sperre_22: BOOL;
	Sperre_23: BOOL;
	Sperre_24: BOOL;
END_VAR

VAR_GLOBAL RETAIN

	(* KettenTyp[0] = Gliederzahl,  Kettentyp[1] Farbe1 0=grau 1=gelb 2=rot 3=blau, Kettentyp[2]=position der ersten Farblasche (Nr.d. Au�enlasche*)
	(*Kettentyp[3] Farbe2  Kettentyp[4] Position der zweiten Farblasche *)
	(*Kettentyp[6] Farbe3  Kettentyp[6] Position der dritten Farblasche *)
	(*Kettentyp[7] Farbe4  Kettentyp[8] Position der vierten Farblasche *)
	(*Kettentyp[9] Farbe5  Kettentyp[10] Position der f�nften Farblasche *)


(*   Fehlerz�hler f�r die erste Seite. Fehler k�nnen ohne Password zur�ckgesetzt werden*)
	KettenTyp					AT%QW100:ARRAY [0..11] OF WORD :=124,1,1,2,27,2,33;
	IOZ_Kette 					AT%QW300: INT;
	FZ_Farbe					AT%QW302: INT;
	FZ_Bolzenhoehe			AT%QW304: INT;
	FZ_Laschenabst_1		AT%QW308: INT;
	FZ_Laschenabstand_2	AT%QW312: INT;
	FZ_Rolle_F				AT%QW316: INT;
	FZ_Rolle_F_R			AT%QW320: INT;
	FZ_Lasche_F				AT%QW324: INT;
	FZ_Lasche_F_ALU		AT%QW328: INT;
	FZ_Lasche_F_ILO		AT%QW332: INT;
	FZ_Lasche_F_ILU		AT%QW336: INT;
	FZ_KAMM_Schmutz		AT%QW340: INT;
	FZ_KAMM_Bereich		AT%QW344: INT;
	FZ_Gesammt				AT%QW348: INT;
	FZ_PseudoF : INT;

(*   Fehlerz�hler f�R die Kettenfehler Seite. Fehler k�nnen mit Password zur�ckgesetzt werden*)
	RIOZ_Kette 					AT%QW400: INT;
	RFZ_Farbe					AT%QW402: INT;
	RFZ_Bolzenhoehe			AT%QW404: INT;
	RFZ_Laschenabst_1			AT%QW408: INT;
	RFZ_Laschenabstand_2		AT%QW412: INT;
	RFZ_Rolle_F					AT%QW416: INT;
	RFZ_Rolle_F_R				AT%QW420: INT;
	RFZ_Lasche_F				AT%QW424: INT;
	RFZ_Lasche_F_ALU			AT%QW428: INT;
	RFZ_Lasche_F_ILO			AT%QW432: INT;
	RFZ_Lasche_F_ILU			AT%QW436: INT;
	RFZ_KAMM_Schmutz			AT%QW440: INT;
	RFZ_KAMM_Bereich			AT%QW444: INT;
	RFZ_Gesammt				AT%QW448: INT;
	RFZ_PseudoF :INT;

	ArtikelString			  		AT%QW552: STRING;
	ArtikelNr						AT%QW656: DINT;






END_VAR                                                                                               '           C   , X t �}           Variable_Configuration ���F	���FC                        VAR_CONFIG
END_VAR
                                                                                               '           D   , n � ��           Variablen_Konfiguration ���F	���FD     ����              VAR_CONFIG
END_VAR
                                                                                                    |0|0         ~      �   ���  �3 ���   � ���                  DEFAULT             System         |0|0   HH':'mm':'ss   dd'-'MM'-'yyyy'   :                        DriveControl ���F	���F                      M  TYPE DriveControl :
STRUCT
	ManOn: BOOL := FALSE; (* Visu -> SPS: Antrieb ein (nur bei FU-Antrieben) *)
	ManOff: BOOL := FALSE; (* Visu -> SPS: Antrieb aus (nur bei FU-Antrieben) *)
	ManFwd: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb langsam vorw�rts *)
	ManBwd: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb langsam r�ckw�rts *)
	TeilungVor: BOOL := FALSE; (* Visu -> SPS: Kette um eine Teilung vor (nur bei Servo-Antrieben) *)
	TeilungZur: BOOL := FALSE; (* Visu -> SPS: Kette um eine Teilung zur�ck (nur bei Servo-Antrieben) *)
	EnManCtrl: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
             ;     is->PSAn        	   KettenTyp ���F	���F      E;* su>         �   TYPE KettenTyp :
STRUCT
	PF: ARRAY [0..19] OF UDINT := 0,410,819,1229,1638,2048,2458,2867,3277,3686,4049,4506,4915,5328,5734,6144,6554,6963,7373,7782;

END_STRUCT
END_TYPE             <   , , : ��        
   KS_Control ���F	���F                      �   TYPE KS_Control :
STRUCT
	EnInput: BOOL := FALSE; (* Freigabe Bef�llen *)
	EnOutput: BOOL := FALSE; (* Freigabe Entleeren *)
	ActState: INT := 0; (* aktueller zustand f�r Visu *)
END_STRUCT
END_TYPE             =      Aga 7)            MotorControl ���F	���F       �t@t@        �  TYPE MotorControl :
STRUCT
	ManOn: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb ein *)
	ManOff: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb aus *)
	EnManCtrl: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
             >                        PneumControl ���F	���F                      �  TYPE PneumControl :
STRUCT
	SetOn: BOOL := FALSE; (* Visu -> SPS: Arbeitsstellung anfahren *)
	SetOff: BOOL := FALSE; (* Visu -> SPS: Grundstellung anfahren *)
	EnSet: BOOL := FALSE; (* SPS -> Visu: Freigabe manuell Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Zylinder in Arbeitsstellung *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Zylinder in Grundstellung *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Zylinder oder Endschalter *)
END_STRUCT
END_TYPE
             ?        /         
   PosControl ���F	���F          �|          �  TYPE PosControl :
STRUCT
	PosSet: INT := 0; (* Positionssollwert [mm] *)
	ActPos: INT := 0; (* Positionsistwert [mm] *)
	PosLimitLo: INT := 0; (* unterer Grenzwert Sollposition [mm] *)
	PosLimitHi: INT := 0; (* oberer Grenzwert Sollposition [mm] *)
	StartPos: BOOL := FALSE; (* Visu -> SPS: Positionierung starten *)
	StoppPos: BOOL := FALSE; (* Visu -> SPS: Positionierung abbrechen *)
	ManPosUp: BOOL := FALSE; (* Visu -> SPS: Handbetrieb Positon erh�hen *)
	ManPosDn: BOOL := FALSE; (* Visu -> SPS: Handbetrieb Positon verringern *)
	EnPosSet: BOOL := FALSE; (* SPS -> Visu: Freigabe Sollwerteingabe *)
	EnManPos: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Positionierung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
             @                        StationControl ���F	���F                      O  TYPE StationControl :
STRUCT
	StepCounter: INT; (* SPS -> Visu: Schrittz�hler *)
	SingleStep: BOOL := FALSE; (* Visu -> SPS: Einzelschritt weiterschalten *)
	SingleCycle: BOOL := FALSE; (* Visu -> SPS: Einzelzyklus ausf�hren *)
	StartCycle: BOOL := FALSE; (* Zyklus im Auto-Betrieb starten *)
	ManInit: BOOL := FALSE; (* Visu -> SPS: Grundstellung anfahren *)
	AutoInit: BOOL := FALSE; (* Grundstellung im Auto-Betrieb anfahren *)
	SetFinished: BOOL := FALSE; (* Visu -> SPS: Fertigmeldung setzen *)
	WaitPos: BOOL := FALSE; (* Station in Warteposition f�r Stopp *)
	EnSemiAutoCtrl: BOOL := FALSE; (* SPS -> Visu: Steuerung Halbautomatikbetrieb freigeben; Freigabe f�r SingleStep, SingleCycle, InitPos und SetFinished *)
	InitPos: BOOL := FALSE; (* Station in Grundstellung *)
	Finished: BOOL := FALSE; (* Station fertig *)
	ErrorInitPos: BOOL := FALSE; (* St�rung Grundstellung nicht erreicht *)
	ErrorCycleTime: BOOL := FALSE; (* St�rung Zeit�berschreitung Zyklus *)
	ActState: INT := 0; (* SPS -> Visu: Zustand der Station: 0 = St�rung, 1 = bereit, 2 = aktiv *)
END_STRUCT
END_TYPE
              #   , n � �]           _ASM_FU_SOLLW ���F	���F       G���        \  FUNCTION_BLOCK _ASM_FU_SOLLW
VAR_INPUT
	AutoPos: BOOL;
	SollW: INT;
	Brems_Fenster:INT;
	IstW:INT;
	P:INT;
	Pos_Fenster:INT;
	VFix_Vor:BOOL;
	VFix_Rueck:BOOL;
END_VAR
VAR_OUTPUT
	SollwReg:INT;
	MotVor:BOOL;
	MotRueck:BOOL;
	Pos_Erreicht:BOOL;
END_VAR
VAR
	Pos_Abw_Abs:INT;
END_VAR
VAR CONSTANT
	SollwFix: INT := 16000;
END_VAR�  IF AutoPos THEN
		Pos_Abw_Abs:=ABS( SollW-IstW);
		IF SollW>=IstW THEN
				SollwReg := ( SollW-IstW) *P;
				MotVor := TRUE;
				MotRueck:=FALSE;
		ELSE
				SollwReg := ( IstW-SollW) *P;
				MotVor := FALSE;
				MotRueck:=TRUE;
		END_IF
		IF	Pos_Abw_Abs>Brems_Fenster THEN
		SollwReg:=32000;
		END_IF


	IF ABS( SollW-IstW)<Pos_Fenster THEN
			Pos_Erreicht := TRUE;
			MotVor := FALSE;
			MotRueck:=FALSE;
	ELSE
			Pos_Erreicht := FALSE;
	END_IF
END_IF

IF AutoPos=FALSE THEN
	IF VFix_Vor=TRUE THEN
		SollwReg:=SollwFix;
		MotVor:=TRUE;
		MotRueck:=FALSE;
	ELSE
		MotVor:=FALSE;
	END_IF

	IF VFix_Rueck=TRUE THEN
		SollwReg:=SollwFix;
		MotVor:=FALSE;
		MotRueck:=TRUE;
	ELSE
		MOTRueck:=FALSE;
	END_IF
END_IF




               $   , � � �z           Anlagestoerung �2�F	���F      c_itar          9  FUNCTION_BLOCK Anlagestoerung
VAR_INPUT
	Taste_Ventil_Ein:BOOL;
	Taste_Ventil_Aus:BOOL;
	H_Hand:BOOL;
END_VAR
VAR_OUTPUT
	Antriebe_Stoerung: BOOL;
	V_Ventil:BOOL;
END_VAR
VAR

	TON1: TON;
	PF_1: R_TRIG;
	TON2: TON;
	TOF1: TOF;
	TON3: TON;
	TON4: TON;
	TOF2: TOF;
	RS_1: RS;
	RS_2: RS;
END_VAR      �T_Qiutt_Stoerung Stoerunganlage.0Stoerunganlage.1Stoerunganlage.2Stoerunganlage.3Stoerunganlage.4Stoerunganlage.5Stoerunganlage.6Stoerunganlage.7Stoerunganlage.8Stoerunganlage.10SammelstoerungH_Quitt_Stoerung     Stoerunganlage.0Not_Aus Stoerunganlage.1Schutzhaube_Auf Stoerunganlage.2Speicher12Offen�S4_Trennen_1�
S5_Rueck_3�S6_Trennen_2AND Stoerunganlage.3Stoerunganlage.4Stoerunganlage.5Stoerunganlage.6Stoerunganlage.7Stoerunganlage.8AStoerunganlage.10OR Sammelstoerung     �Sammelstoerung  AntriebeEin     �Sammelstoerung�S4_Trennen_1�S6_Trennen_2ASpeicher12OffenANDAND  V_Ventil     Sammelstoerung�FlaechenSpFrORABlink_TON1.QAND  H_Quitt_Stoerung     �SammelstoerungAV_VentilAND  Antriebe_Stoerung     Not_AusABlink_TON1.QAND  
H_Quitt_NA     IA_EW4A100LTBIA_EW4A10000GTORAKontrolle_Aktiv.3AND Stoerunganlage.0     IA_Las_SensorA1000LTBIA_Las_SensorA20000GTORBKontrolle_Aktiv.2AKontrolle_Aktiv.1ORAND Stoerunganlage.4     TON3IA_Pos_KS2_InputA1000LTBIA_Pos_KS2_InputA32500GTORAT#1sTON        Stoerunganlage.5     TON4IA_Pos_KS1_InputA1000LTBIA_Pos_KS1_InputA32500GTORAT#1sTON        Stoerunganlage.6     ETOF1PF_1BSkal_IC_SSI_DG_InputA5EQBSkal_IC_SSI_DG_InputA15EQORB	Motor2VorAMotor2RueckORANDR_TRIG      B�	Motor2Vor�Motor2RueckANDORAT#4sTOF       NOT Stoerunganlage.7     TON2�KS1.EnOutputA	Motor1VorANDAT#2sTON        Stoerunganlage.8     �DruckW�S4_Trennen_1�
S5_Rueck_3�S6_Trennen_2AND Stoerunganlage.10     �FlaechenSp1_IO�FlaechenSp2_IOAND  FlaechenSpFr     RS_1�FlaechenSp1_IO_�T_Qiutt_StoerungRS        FlaechenSp1_IO     RS_2�FlaechenSp2_IO_�T_Qiutt_StoerungRS        FlaechenSp2_IO     SammelstoerungS4_Trennen_1
S5_Rueck_3S6_Trennen_2
S3_Rueck_2B
S1_Rueck_1BKS1.EnOutputAKS2.EnInputORANDOR  Leuchte_Rot     �FlaechenSpFr
S1_Rueck_1S2_Vor_1�V_AutogestartetOR  Leuchte_Gelb     �SammelstoerungV_Autogestartet�
Automatik2FlaechenSpFr�Leuchte_RotAND  Leuchte_Gruend                  %   , B W �#           Betriebsartenanwahl ���F	���F      F � ��        �   FUNCTION_BLOCK Betriebsartenanwahl
VAR_INPUT
	Antriebe_Stoerung:BOOL;
	Kette_Fehler:BOOL;
END_VAR
VAR_OUTPUT
	V_Autogestoppt:BOOL;
	V_Autogestartet:BOOL;
END_VAR

VAR

END_VAR      �T_HandSammelstoerung�REF_IOOR H_HandV_AutogestartetV_Autogestoppt     V_Autogestartet�T_StopS4_Trennen_1AS6_Trennen_2OR�SammelstoerungAREF_IOANDBH_Hand�T_Auto�SammelstoerungAREF_IOANDOR V_AutogestopptV_AutogestartetH_Hand     �T_Start�T_StartA
S5_Rueck_3ANDB�T_StartAS0_AutomatikANDORV_Autogestoppt�SammelstoerungAREF_IOAND V_AutogestartetH_HandV_Autogestoppt     V_AutogestartetAV_AutogestopptOR  H_Auto     V_AutogestartetV_AutogestopptBlink_TON1.QAS0_AutomatikANDV_AutogestopptBlink_TON1.QAS4_Trennen_1ANDV_AutogestopptBlink_TON1.QS6_Trennen_2�Speicher12OffenANDBH_Hand�REF_IOABlink_TON1.QANDOR  H_Start     �V_Autogestartet  H_Stop     
Blink_TON2
Blink_TON1�Blink_TON2.QAT#1sTON       AT#1sTON       |                  )   , � � �z        
   Farbsensor S¤F	���F      �L�L8�          /  FUNCTION_BLOCK Farbsensor
VAR_INPUT
	Quitt_Fehler:BOOL;
	Farbsensor_Aktiv:BOOL;
END_VAR
VAR_OUTPUT
	Fehler_Farbe:BOOL;
END_VAR
VAR

	Fehler_Farbe_Reg:BOOL;
	grau: BOOL;
	gelb: BOOL;
	rot: BOOL;
	blau: BOOL;
	keine: BOOL;
END_VAR
VAR CONSTANT
	Offset_Pos_Farbsensor: INT := 37;
END_VAR�  
Zeiger_Farbsensor:=Zeiger_Speicher_Trennstelle-Offset_Pos_Farbsensor;

IF 	Zeiger_Farbsensor < 1 THEN
	Zeiger_Farbsensor:=Zeiger_Speicher_Trennstelle-Offset_Pos_Farbsensor+500;
END_IF





(* Bearbeitung nur wenn Trigger n�chstes Glied und Eintrag G�ltig und Sperre zweite Pr�fung nicht aktiv*)
IF	ImpulsPos=TRUE AND Zeiger_Kette_Trennstelle.0=FALSE AND Speicher_Reg[Zeiger_Farbsensor].0=TRUE AND Farbsensor_Aktiv= TRUE  AND Sperre_21=FALSE THEN

	(* Wenn der Farbsensor grau erkennen soll (Farbe 1)*)
	IF Speicher_Reg[Zeiger_Farbsensor].3=FALSE AND Speicher_Reg[Zeiger_Farbsensor].4 =FALSE THEN
		IF	Farbe1=TRUE  THEN
			Speicher_Reg[Zeiger_Farbsensor].6:=TRUE;
		ELSE
			Speicher_Reg[Zeiger_Farbsensor].6:=FALSE;
			Fehler_Farbe_Reg:=TRUE;
			IF	Fehler_Farbe=FALSE THEN
				Zeiger_Fehler_S1:=Zeiger_Kette_Trennstelle-Offset_Pos_Farbsensor-1;
				IF Zeiger_Fehler_S1 < 1 THEN
					Zeiger_Fehler_S1:=Zeiger_Fehler_S1+KettenTyp[0];
				END_IF
				(*Zeiger_Fehler_S1:=Zeiger_Fehler_S1/2;*)
			END_IF
			Speicher_Reg[Zeiger_Farbsensor].5:=FALSE;
			Fehler_Farbe:=TRUE;
			grau:=TRUE;
		END_IF
	END_IF

	(* Wenn der Farbsensor gelb erkennen soll (Farbe 2)*)
	IF Speicher_Reg[Zeiger_Farbsensor].3=FALSE AND Speicher_Reg[Zeiger_Farbsensor].4 =TRUE THEN
		IF	Farbe2=TRUE THEN
			Speicher_Reg[Zeiger_Farbsensor].6:=TRUE;
		ELSE
			Speicher_Reg[Zeiger_Farbsensor].6:=FALSE;
			Fehler_Farbe_Reg:=TRUE;
			IF	Fehler_Farbe=FALSE THEN
				Zeiger_Fehler_S1:=Zeiger_Kette_Trennstelle-Offset_Pos_Farbsensor-1;
				IF Zeiger_Fehler_S1 < 1 THEN
					Zeiger_Fehler_S1:=Zeiger_Fehler_S1+KettenTyp[0];
				END_IF
				(*Zeiger_Fehler_S1:=Zeiger_Fehler_S1/2;*)
			END_IF
			Speicher_Reg[Zeiger_Farbsensor].5:=FALSE;
			Fehler_Farbe:=TRUE;
			gelb:=TRUE;
		END_IF
	END_IF

	(* Wenn der Farbsensor rot erkennen soll (Farbe 3)*)
	IF Speicher_Reg[Zeiger_Farbsensor].3=TRUE AND Speicher_Reg[Zeiger_Farbsensor].4 =FALSE THEN
		IF	Farbe3=TRUE THEN
			Speicher_Reg[Zeiger_Farbsensor].6:=TRUE;
		ELSE
			Speicher_Reg[Zeiger_Farbsensor].6:=FALSE;
			Fehler_Farbe_Reg:=TRUE;
			IF	Fehler_Farbe=FALSE THEN
				Zeiger_Fehler_S1:=Zeiger_Kette_Trennstelle-Offset_Pos_Farbsensor-1;
				IF Zeiger_Fehler_S1 < 1 THEN
					Zeiger_Fehler_S1:=Zeiger_Fehler_S1+KettenTyp[0];
				END_IF
				(*Zeiger_Fehler_S1:=Zeiger_Fehler_S1/2;*)
			END_IF
			Speicher_Reg[Zeiger_Farbsensor].5:=FALSE;
			Fehler_Farbe:=TRUE;
			rot:=TRUE;
		END_IF
	END_IF


(* Wenn der Farbsensor farbe 4 erkennen soll*)
	IF Speicher_Reg[Zeiger_Farbsensor].3=TRUE AND Speicher_Reg[Zeiger_Farbsensor].4 =TRUE THEN
		IF	Farbe4=TRUE THEN
			Speicher_Reg[Zeiger_Farbsensor].6:=TRUE;
		ELSE
			Speicher_Reg[Zeiger_Farbsensor].6:=FALSE;
			Fehler_Farbe_Reg:=TRUE;
			Speicher_Reg[Zeiger_Farbsensor].5:=FALSE;
			IF	Fehler_Farbe=FALSE THEN
				Zeiger_Fehler_S1:=Zeiger_Kette_Trennstelle-Offset_Pos_Farbsensor-1;
				IF Zeiger_Fehler_S1 < 1 THEN
					Zeiger_Fehler_S1:=Zeiger_Fehler_S1+KettenTyp[0];
				END_IF
				(*Zeiger_Fehler_S1:=Zeiger_Fehler_S1/2;*)
			END_IF
			Fehler_Farbe:=TRUE;
			blau:=TRUE;
		END_IF
	END_IF

(* Wenn der Farbsensor keine Farbe erkennt (Nicht definierte Farbe der Lasche oder Sensor Defekt)*)
(*	IF	Farbe1=FALSE AND Farbe2=FALSE AND Farbe3=FALSE AND Farbe4=FALSE THEN
			Speicher_Reg[Zeiger_Farbsensor].6:=FALSE;
			Fehler_Farbe_Reg:=TRUE;
			Speicher_Reg[Zeiger_Farbsensor].5:=FALSE;
			IF	Fehler_Farbe=FALSE THEN
				Zeiger_Fehler_S1:=Zeiger_Kette_Trennstelle-Offset_Pos_Farbsensor-1;
				IF Zeiger_Fehler_S1 < 1 THEN
					Zeiger_Fehler_S1:=Zeiger_Fehler_S1+KettenTyp[0];
				END_IF
				(*Zeiger_Fehler_S1:=Zeiger_Fehler_S1/2;*)
			END_IF
			Fehler_Farbe:=TRUE;
			keine:=TRUE;
	END_IF*)

	(* Wenn Anfang der Kette unter Farbsensor und Farbfehler liegt an dann Fehler in Register eintragen und r�cksetzen*)
	IF	Speicher_Reg[Zeiger_Farbsensor].1=TRUE AND Fehler_Farbe_Reg=TRUE THEN
		Speicher_Reg[Zeiger_Farbsensor].15:=FALSE;
		Fehler_Farbe_Reg:=FALSE;
		Speicher_Reg[Zeiger_Farbsensor].5:=FALSE;
	END_IF
END_IF



IF	Quitt_Fehler= TRUE THEN
	Fehler_Farbe:=FALSE;
	grau:=FALSE;
	gelb:=FALSE;
	rot:=FALSE;
	blau:=FALSE;
	keine:=FALSE;
END_IF


IF  Speicher_Reg[Zeiger_Farbsensor].1=TRUE THEN
	Sperre_21:=FALSE;
END_IF
               F   ,     ��           FB_Trig_KAMM ���F	���F                      u   FUNCTION_BLOCK FB_Trig_KAMM
VAR_INPUT
END_VAR
VAR_OUTPUT
	VIndDistTiming: BOOL;
END_VAR
VAR
	TP1: TP;
END_VAR      TP1KAMM_TRIG_Scal_.0A	Kamm_TrigANDAT#50msTP         VIndDistTimingd                  E   ,   �&           Fehlerzaehler ���F	���F                      
  FUNCTION_BLOCK Fehlerzaehler
VAR_INPUT
END_VAR
VAR_OUTPUT
END_VAR
VAR
	PF1: R_TRIG;
	PF2: R_TRIG;
	PF3: R_TRIG;
	PF4: R_TRIG;
	PF5: R_TRIG;
	PF6: R_TRIG;
	PF7: R_TRIG;
	PF8: R_TRIG;
	PF9: R_TRIG;
	PF10: R_TRIG;
	PF11: R_TRIG;
	PF12: R_TRIG;
END_VAR1      ELSE1_0�PF1BFehlerspeicher1.0AS2_Vor_1ANDR_TRIG           FZ_FarbeA1ADD  FZ_Farbe     	RFZ_FarbeA1ADD  	RFZ_Farbe    end1_0:TRUE    ELSE1_0:ELSE2_0�PF2BFehlerspeicher1.1AS2_Vor_1ANDR_TRIG           FZ_Laschenabst_1A1ADD  FZ_Laschenabst_1     RFZ_Laschenabst_1A1ADD  RFZ_Laschenabst_1    end2_0:TRUE    ELSE2_0:ELSE3_0�PF3BFehlerspeicher1.2AS2_Vor_1ANDR_TRIG           FZ_BolzenhoeheA1ADD  FZ_Bolzenhoehe     RFZ_BolzenhoeheA1ADD  RFZ_Bolzenhoehe    end3_0:TRUE    ELSE3_0:ELSE4_0�PF4BFehlerspeicher1.3AS2_Vor_1ANDR_TRIG           FZ_Laschenabstand_2A1ADD  FZ_Laschenabstand_2     RFZ_Laschenabstand_2A1ADD  RFZ_Laschenabstand_2    end4_0:TRUE    ELSE4_0:ELSE5_0�PF5BFehlerspeicher2.1AS2_Vor_1ANDR_TRIG           FZ_Lasche_FA1ADD  FZ_Lasche_F     RFZ_Lasche_FA1ADD  RFZ_Lasche_F    end5_0:TRUE    ELSE5_0:ELSE6_0�PF6BFehlerspeicher2.2AS2_Vor_1ANDR_TRIG           FZ_Lasche_F_ALUA1ADD  FZ_Lasche_F_ALU     RFZ_Lasche_F_ALUA1ADD  RFZ_Lasche_F_ALU    end6_0:TRUE    ELSE6_0:ELSE7_0�PF7A
S3_Rueck_2R_TRIG           
FZ_GesammtA1ADD  
FZ_Gesammt     RFZ_GesammtA1ADD  RFZ_Gesammt    end7_0:TRUE    ELSE7_0:ELSE8_0�PF8BIO_KETTEAS0_AutomatikANDR_TRIG           	IOZ_KetteA1ADD  	IOZ_Kette     
RIOZ_KetteA1ADD  
RIOZ_Kette    end8_0:TRUE    ELSE8_0FALSE  IO_KETTE     ELSE9_0�PF9BFehlerspeicher2.3AS2_Vor_1ANDR_TRIG           FZ_Lasche_F_ILOA1ADD  FZ_Lasche_F_ILO     RFZ_Lasche_F_ILOA1ADD  RFZ_Lasche_F_ILO    end9_0:TRUE    ELSE9_0ELSE10_0�PF10BFehlerspeicher2.4AS2_Vor_1ANDR_TRIG           FZ_Lasche_F_ILUA1ADD  FZ_Lasche_F_ILU     RFZ_Lasche_F_ILUA1ADD  RFZ_Lasche_F_ILU    end10_0:TRUE    ELSE10_0ELSE11_0�PF11BFehlerspeicher2.5AS2_Vor_1ANDR_TRIG           
FZ_Rolle_FA1ADD  
FZ_Rolle_F     RFZ_Rolle_FA1ADD  RFZ_Rolle_F    end11_0:TRUE    ELSE11_0ELSE12_0�PF12BFehlerspeicher2.6AS2_Vor_1ANDR_TRIG           FZ_Rolle_F_RA1ADD  FZ_Rolle_F_R     RFZ_Rolle_F_RA1ADD  RFZ_Rolle_F_R    ELSE12_0TRUEd                  5   , , : �           INIT ���F	���F      0�              s   PROGRAM INIT

VAR

	RESET: BOOL;
	CTUD2:CTUD;
END_VAR
VAR CONSTANT

	Glieder_zurueck: WORD := 80;
END_VAR^  (* Wenn die Maschine eingeschaltet wird ist eine Ref Fahrt durchzuf�hren *)
(* Die Kette mu� im Handbetrieb zur�ckgezogen werden  und die Kettenanfang Taste mu� gedr�ckt werden*)



IF V_Erster_Zyklus=FALSE THEN
	REF_IO:=FALSE;
	REF_Enable:=FALSE;
	RESET:=TRUE;
	REF_Enable:=FALSE;
END_IF

IF REF_IO=FALSE AND T_Qiutt_Stoerung=FALSE THEN
	Quitt_Auto:=TRUE;
END_IF

IF REF_IO=FALSE AND  T_Qiutt_Stoerung=TRUE THEN
	Quitt_Auto:=FALSE;
END_IF



CTUD2(
	CU:=ImpulsNeg ,
	CD:= ImpulsPos,
	RESET:=RESET ,
	LOAD:=RESET ,
	PV:= 80,
	QU=> ,
	QD=> ,
	CV=> );

RESET:=FALSE;
V_Erster_Zyklus:=TRUE;



IF	CTUD2.QU=TRUE THEN
	REF_Enable:=TRUE;
	ELSE
	REF_Enable:=FALSE;
END_IF

IF	REF_IO=TRUE THEN
	REF_Enable:=TRUE;
END_IF

(*
IF	Freigabe_EndKontrolle= FALSE THEN;
	REF_Enable:=FALSE;
END_IF
*)

IF	CTUD2.QU=TRUE AND	T_KettenAnfang=FALSE  AND  REF_IO= FALSE THEN
	V_KettenAnfang:=TRUE;
	REF_IO:= TRUE;
END_IF
V_KettenAnfang:=FALSE;



(* Initialiseren und �ndern der Quelle der Anzeige Kammerarechner  oder Steuerungsrechner *)

IF	HWT_Visu=TRUE  THEN
	TP_Anzeige:=TRUE;
	Kamm_Anzeige:=FALSE;
	H_Visu:=TRUE;
	H_KammBild:=FALSE;
ELSE
	TP_Anzeige:=FALSE;
END_IF

IF	HWT_Kammera=TRUE  THEN
	TP_Anzeige:=FALSE;
	Kamm_Anzeige:=TRUE;
	H_Visu:=FALSE;
	H_KammBild:=TRUE;
ELSE
	Kamm_Anzeige:=FALSE;
END_IF




               *   ,   ��           Kammera ���F	���F       -X�H�        �  FUNCTION_BLOCK Kammera
VAR_INPUT
	Quitt_Fehler:BOOL;
	Kammera_Aktiv:BOOL;
END_VAR
VAR_OUTPUT
	Fehler_ALO:BOOL;
	Fehler_ALU:BOOL;
	Fehler_ILO:BOOL;
	Fehler_ILU:BOOL;
	Fehler_ROL:BOOL;
	Fehler_ROR:BOOL;
END_VAR
VAR
	Zeiger_Kammera:INT;
	Fehler_Kammera_Reg:BOOL;
	TP1:TP;
	V1:BOOL;
	V2:BOOL;
	V3:BOOL;
	PF1:R_TRIG;
	NF1:F_TRIG;


	Kamm_Trig_Frg: BOOL;
END_VAR
VAR CONSTANT
	Offset_Pos_Kammera: INT := 76;
END_VAR�  Zeiger_Kammera:=Zeiger_Speicher_Trennstelle-Offset_Pos_Kammera;

IF	Zeiger_Kammera < 1 THEN
	Zeiger_Kammera:=Zeiger_Speicher_Trennstelle-Offset_Pos_Kammera+500;
END_IF




(* Triggerimpuls f�r Kammera *)

IF ImpulsPos= TRUE AND Zeiger_Kette_Trennstelle.0 = 1 THEN
	V1:=TRUE;
ELSE
	V1:=FALSE;
END_IF


TP1(IN:= V1, PT:=T#10ms , Q=> , ET=> );


IF   TP1.Q= TRUE THEN
	Grund_Trig:=TRUE;
ELSE
	Grund_Trig:=FALSE;
END_IF




(* Bearbeitung nur wenn Trigger n�chstes Glied und Eintrag G�ltig und keine Sperre 2 Pr�fung*)
IF	 Zeiger_Kette_Trennstelle.0=TRUE AND Kammera_Aktiv=TRUE AND ImpulsPos AND Sperre_24=FALSE THEN

	(* Kammera erkennt obere Aussenlasche fehlt *)
	IF	KammOut0=FALSE THEN
		Speicher_Reg[Zeiger_Kammera].10:=FALSE;
		Speicher_Reg[Zeiger_Kammera].5:=FALSE;
		IF	Fehler_ALO=FALSE THEN
		Zeiger_Fehler_S4:=Zeiger_Kette_Trennstelle-Offset_Pos_Kammera-1;
			IF Zeiger_Fehler_S4 < 1 THEN
				Zeiger_Fehler_S4:=Zeiger_Fehler_S4+KettenTyp[0];
			END_IF
			(*Zeiger_Fehler_S4:=Zeiger_Fehler_S4+1;*)
		END_IF
		Fehler_Kammera_Reg:=TRUE;
		Fehler_ALO:=TRUE;
	ELSE
			Speicher_Reg[Zeiger_Kammera].10:=TRUE;
	END_IF

	(* Kammera erkennt untere Aussenlasche fehlt *)
	IF	KammOut1=FALSE  THEN
		Speicher_Reg[Zeiger_Kammera].10:=FALSE;
		Speicher_Reg[Zeiger_Kammera].5:=FALSE;
		IF	Fehler_ALU=FALSE THEN
		Zeiger_Fehler_S4:=Zeiger_Kette_Trennstelle-Offset_Pos_Kammera-1;
			IF Zeiger_Fehler_S4 < 1 THEN
				Zeiger_Fehler_S4:=Zeiger_Fehler_S4+KettenTyp[0];
			END_IF
			(*Zeiger_Fehler_S4:=Zeiger_Fehler_S4+1;*)
		END_IF
		Fehler_Kammera_Reg:=TRUE;
		Fehler_ALU:=TRUE;
	ELSE
			Speicher_Reg[Zeiger_Kammera].10:=TRUE;
	END_IF

	(* Kammera erkennt obere Inenlasche fehlt *)
	IF	KammOut2=FALSE THEN
		Speicher_Reg[Zeiger_Kammera].11:=FALSE;
		Speicher_Reg[Zeiger_Kammera].5:=FALSE;
		IF	Fehler_ILO=FALSE THEN
			Zeiger_Fehler_S4:=Zeiger_Kette_Trennstelle-Offset_Pos_Kammera-2;
			IF Zeiger_Fehler_S4 < 1 THEN
				Zeiger_Fehler_S4:=Zeiger_Fehler_S4+KettenTyp[0];
			END_IF
			(*Zeiger_Fehler_S4:=Zeiger_Fehler_S4+1;*)
		END_IF
		Fehler_Kammera_Reg:=TRUE;
		Fehler_ILO:=TRUE;
	ELSE
			Speicher_Reg[Zeiger_Kammera].11:=TRUE;
	END_IF

	(* Kammera erkennt untere Inennnlasche fehlt *)
	IF	KammOut3=FALSE THEN
		Speicher_Reg[Zeiger_Kammera].11:=FALSE;
		Speicher_Reg[Zeiger_Kammera].5:=FALSE;
		IF	Fehler_ILU=FALSE THEN
			Zeiger_Fehler_S4:=Zeiger_Kette_Trennstelle-Offset_Pos_Kammera-2;
			IF Zeiger_Fehler_S4 < 1 THEN
				Zeiger_Fehler_S4:=Zeiger_Fehler_S4+KettenTyp[0];
			END_IF
			(*Zeiger_Fehler_S4:=Zeiger_Fehler_S4+1;*)
		END_IF
		Fehler_Kammera_Reg:=TRUE;
		Fehler_ILU:=TRUE;
	ELSE
			Speicher_Reg[Zeiger_Kammera].11:=TRUE;
	END_IF
	(* Kammera erkennt  Rolle links fehlt *)
	IF	KammOut5=FALSE THEN
		Speicher_Reg[Zeiger_Kammera].12:=FALSE;
		IF	Fehler_ROL=FALSE THEN
			Speicher_Reg[Zeiger_Kammera].5:=FALSE;
			Zeiger_Fehler_S4:=Zeiger_Kette_Trennstelle-Offset_Pos_Kammera-2;
			IF Zeiger_Fehler_S4 < 1 THEN
				Zeiger_Fehler_S4:=Zeiger_Fehler_S4+KettenTyp[0];
			END_IF
			(*Zeiger_Fehler_S4:=Zeiger_Fehler_S4+1;*)
		END_IF
		Fehler_Kammera_Reg:=TRUE;
		Fehler_ROL:=TRUE;
	ELSE
			Speicher_Reg[Zeiger_Kammera].12:=TRUE;
	END_IF

	(* Kammera erkennt  Rolle rechts fehlt *)
	IF	KammOut4=FALSE  THEN
		Speicher_Reg[Zeiger_Kammera].13:=FALSE;
		IF	Fehler_ROR=FALSE THEN
			Speicher_Reg[Zeiger_Kammera].5:=FALSE;
			Zeiger_Fehler_S4:=Zeiger_Kette_Trennstelle-Offset_Pos_Kammera-2;
			IF Zeiger_Fehler_S4 < 1 THEN
			Zeiger_Fehler_S4:=Zeiger_Fehler_S4+KettenTyp[0];
			END_IF
			(*Zeiger_Fehler_S4:=Zeiger_Fehler_S4+1;*)
		END_IF
			Fehler_Kammera_Reg:=TRUE;
			Fehler_ROR:=TRUE;
	ELSE
			Speicher_Reg[Zeiger_Kammera].13:=TRUE;
	END_IF

END_IF

(* Wenn Anfang der Kette unter Kammera und Fehler liegt an dann Fehler in Register eintragen und r�cksetzen*)
IF	Speicher_Reg[Zeiger_Kammera].1=TRUE AND Fehler_Kammera_Reg=TRUE AND Kammera_Aktiv THEN
		Speicher_Reg[Zeiger_Kammera].15:=FALSE;
		Fehler_Kammera_Reg:=FALSE;
END_IF

IF	 (KammOut4=FALSE OR KammOut5=FALSE  OR  KammOut0=FALSE OR  KammOut1=FALSE OR  KammOut2=FALSE OR  KammOut3=FALSE) AND S2_Vor_1=TRUE  AND Dummy=FALSE  THEN
	Kamm_Trig:=FALSE;
END_IF



IF 	Quitt_Fehler= TRUE  THEN
	V2:=TRUE;
	Kamm_Trig:=TRUE;
ELSE
	V2:=FALSE;
END_IF

IF	V2= TRUE THEN
	Fehler_ALO:=FALSE;
	Fehler_ALU:=FALSE;
	Fehler_ILO:=FALSE;
	Fehler_ILU:=FALSE;
	Fehler_ROL:=FALSE;
	Fehler_ROR:=FALSE;
END_IF



IF  Speicher_Reg[Zeiger_Kammera].1=TRUE THEN
	Sperre_24:=FALSE;
END_IF
               H   ,   ��           Kammprg ���F	���F                   �   PROGRAM Kammprg
VAR
	KAMM_TRIG_POS: DINT;
	FB_TRIG_KAMM_1: FB_Trig_KAMM;
	IC_alt:UDINT;
	Delta:DINT;

END_VAR
VAR CONSTANT
	Offsett: DINT:=200000;
END_VAR    
 IC_SSI_DG_InputAOffsettSUB  KAMM_TRIG_POS     else1_0�KAMM_TRIG_POSA1LT     KAMM_TRIG_POSA16777216ADD  KAMM_TRIG_POS    end1_0:TRUE    else1_0:20BKAMM_TRIG_POSA20MULA16777216DIVSUB  KAMM_TRIG_Scal_     PF_KAMM_TRIG�KAMM_TRIG_Scal_.0R_TRIG           FB_TRIG_KAMM_1�FB_Trig_KAMM        IndDistTimingd                  +   , B W ��           KetteEndKontrolle ���F	���F      27   @         �   FUNCTION_BLOCK KetteEndKontrolle
VAR_INPUT
	Quitt_Fehler:BOOL;
	Kontrolle_Aktiv:BOOL;
END_VAR
VAR_OUTPUT
	Fehler_Kette:BOOL;
END_VAR
VAR
END_VAR
VAR CONSTANT
	Offset_Endkontrolle:INT:=80;
END_VARq  

Zeiger_Endkontrolle:=Zeiger_Speicher_Trennstelle-Offset_Endkontrolle;

IF Zeiger_Endkontrolle<1  THEN
	Zeiger_Endkontrolle:=Zeiger_Speicher_Trennstelle-Offset_Endkontrolle+500;
END_IF



(* Bearbeitung nur wenn Trigger n�chstes Glied und Eintrag G�ltig *)
IF	ImpulsPos=TRUE  AND Kontrolle_Aktiv= TRUE THEN
	IF Speicher_Reg[Zeiger_Endkontrolle].1 = TRUE THEN
		IF  Sperre_2Pruef= TRUE THEN
		     	Speicher_Reg[Zeiger_Endkontrolle].15 := TRUE;
		END_IF
		IF Speicher_Reg[Zeiger_Endkontrolle].15 = TRUE THEN
			Fehler_Kette:=FALSE;
		ELSE
			Fehler_Kette:=TRUE;
			(*Speicher_Reg[Zeiger_Endkontrolle].15 := TRUE;*)
		END_IF
		IF Speicher_Reg[Zeiger_Endkontrolle].15 = TRUE AND Sperre_2Pruef=FALSE THEN
			IO_KETTE:=TRUE;
		END_IF
		Sperre_2Pruef:= FALSE;
	END_IF
END_IF

IF	Quitt_Fehler= TRUE OR Quitt_Auto= TRUE THEN
	Fehler_Kette:=FALSE;
END_IF

               6   , B W ��           Kettenspeicher ���F	���F           g         h  PROGRAM Kettenspeicher
VAR
	KettenspGeschlossen: BOOL; (* alle Kettenspeicher geschlossen *)
	_Kettenpeicher1: KS;
	_Kettenpeicher2: KS;
	_Act_Pos_KS: BOOL;
	FB_Sollw_Mot1: _ASM_FU_SOLLW;
	FB_Sollw_Mot2: _ASM_FU_SOLLW;

	Ventil_Integer1: Ventil_Integer;
	Frg_Reg_MotVor2: BOOL;
	Frg_reg_MotRueck2: BOOL;
	Mot2_Pos_Erreicht: BOOL;
	Frg_Reg_MotVor1: BOOL;
	Frg_Reg_MotRueck1: BOOL;
	Mot1_Pos_Erreicht: BOOL;

	CTU3: CTU;
	PF1: R_TRIG;
	PF2: R_TRIG;
	CTU4: CTU;
	PF3: R_TRIG;
	PF4: R_TRIG;
	SR_1: SR;
	NF_1: F_TRIG;
	SR_2: SR;
	NF_2: F_TRIG;
	PF_10: R_TRIG;
	SR_3: SR;
	RS_4: RS;
END_VAR
      FB_Sollw_Mot1V_Autogestartet�
Automatik2AND60001000IA_Pos_KS1_Input20500TP_M1_Hand_VorAH_HandANDB
Automatik2�_Kettenpeicher1.En_OutputANDORBTP_M1_Hand_RueckAH_HandANDBH_Hand�REF_IO�TP_M1_Hand_Rueck�TP_M1_Hand_VorESR_2NF_2AT_StartF_TRIG      BT_StartEPF_10A
REF_EnableR_TRIG      ORSR      ANDOR_ASM_FU_SOLLW  Frg_Reg_MotVor1 Frg_Reg_MotRueck1 Mot1_Pos_Erreicht    EVentil_Integer1V_AutogestartetAQA_Sollw_Mot2Ventil_Integer      ADD24000A32000LIMIT  QA_Sollw_Mot1   _Steuerung Kettenspeicher 1 _Kettenpeicher1�Schutzhaube_Auf_PneumPressEinAFRG_DLAOR2IA_Pos_KS1_Input134000A29000KS  KS1.EnOutput KS1.ActState      KS1.EnInput     FB_Sollw_Mot2V_Autogestartet�
Automatik2AND300002000VW_Act_Pos_KS210500TP_M2_Hand_VorH_Hand�
Automatik2ANDB
Automatik2
M2_Start_V�H_HandANDORBH_HandATP_M2_Hand_RueckAND
Automatik2
M2_Start_R�H_HandANDBH_Hand�REF_IO�TP_M2_Hand_Rueck�TP_M2_Hand_VorSR_1NF_1AT_StartF_TRIG      BT_StartAPF_10.QORSR      ESR_3�_Kettenpeicher1.En_Output�SammelstoerungAND�
T_Quitt_NASR      ANDOR_ASM_FU_SOLLW  Frg_Reg_MotVor2 Frg_reg_MotRueck2 Mot2_Pos_Erreicht    24000A32000LIMIT  QA_Sollw_Mot2     32676AIA_Pos_KS2_InputSUB  VW_Act_Pos_KS2   Steuerung Kettenspeicher 2 _Kettenpeicher2�Schutzhaube_Auf_PneumPressEinAFRG_DLAOR2VW_Act_Pos_KS2135000A28000KS  KS2.EnOutput KS2.ActState      KS2.EnInput9   Freigabe Ketteneinzug Endlos von Ausgang Kettenspeicher 2 RS_4�KS2.EnInputB�S0_AutomatikBVW_Act_Pos_KS2A24000LTORAKS2.EnInputANDASammelstoerungORRS        FreigabenachfogeM   alle Kettenspeicher geschlossen �Speicher12Offen�Speicher12OffenAND  KettenspGeschlossen.   Ansteuerung des Motors M2 in Positive richtung V_AutogestartetFrg_Reg_MotVor2�
Automatik2ANDH_HandFrg_Reg_MotVor2�T_Start�Fehlerspeicher1.6ANDB
Automatik2Frg_Reg_MotVor2AV_AutogestartetANDOR_Kettenpeicher2.En_Input_Kettenpeicher1.En_Output�Motor2Rueck
REF_EnableAFlaechenSpFrAND  	Motor2Vor)   Ansteuerung Motor M2 in negative Richtung H_HandFrg_reg_MotRueck2�T_StartANDV_AutogestartetFrg_reg_MotRueck2A
Automatik2ANDBV_AutogestartetFrg_reg_MotRueck2�
Automatik2ANDOR_Kettenpeicher1.En_Input_Kettenpeicher2.En_Output�	Motor2VorAND  Motor2Rueck.   Ansteuerung des Motors M1 in Positive richtung V_AutogestartetAFrg_Reg_MotVor1ANDBH_HandFrg_Reg_MotVor1�T_StartANDOR_Kettenpeicher1.En_InputTRUE�Motor1RueckAFlaechenSpFrAND  	Motor1Vor)   Ansteuerung Motor M1 in negative Richtung H_HandFrg_reg_MotRueck1�T_StartANDBV_AutogestartetFrg_reg_MotRueck1AFALSEANDOR_Kettenpeicher1.En_OutputTRUE�	Motor1VorAND  Motor1Rueckd                  ,   , n � �           KS ���F	���F      ���            �  FUNCTION_BLOCK KS
VAR_INPUT
	URL_Geschlossen: BOOL; (* Umlenkrolle geschlossen *)
	SpannzylinderGespannt: BOOL; (* Spannzylinder Kettenspeicher gespannt *)
	ActPress: INT; (* Druck-Istwert Spannzylinder *)
	ActPos_ULR: INT; (* Positions-Istwert Umlenkrolle *)
	MinPress: INT; (* minimaler Druck Spannzylinder *)
	MaxPress: INT; (* maximaler Druck Spannzylinder *)
	MinPos_ULR: INT; (* minimale Position Umlenkrolle *)
	MaxPos_ULR: INT; (* maximale Position Umlenkrolle *)
END_VAR
VAR_OUTPUT
	En_Input: BOOL; (* Freigabe Bef�llen *)
	En_Output: BOOL; (* Freigabe Entnahme *)
	ActState: INT; (* aktueller Zustand f�r Visu *)
END_VAR
VAR
	KS_ready: BOOL; (* Kettenspeicher bereit *)

END_VAR  (* Kettenspeicher betriebsbereit *)

KS_ready := ActPress >= MinPress AND ActPress <= MaxPress AND URL_Geschlossen AND SpannzylinderGespannt;

(* Berechnung der aktuellen Kettenspeicher-Kapazit�t in Gliedern *)



(* Freigaben f�r Bef�llen *)

IF	ActPos_ULR < MaxPos_ULR THEN
	En_Input:=TRUE;
	ELSE
	En_Input:=FALSE;
END_IF

(* Freigaben f�r Entnahme *)

IF ActPos_ULR >MinPos_ULR THEN
	En_Output:=TRUE;
	ELSE
	En_Output:=FALSE;
END_IF





(* Freigaben sperren wenn Kettenspeicher nicht bereit (offen oder entspannt oder Druck nicht OK *)

IF NOT KS_ready THEN
	En_Input := FALSE;
	En_Output := FALSE;
END_IF;

(* aktueller Zustand f�r Visu *)

IF KS_ready THEN
	ActState := 1;				(* bereit *)
ELSE
	ActState := 0;				(* St�rung *)
END_IF;               -   , B W �#           LascheDistSensor ��F	��F         ��        A  FUNCTION_BLOCK LascheDistSensor
VAR_INPUT
	Quitt_Fehler:BOOL;
	LascheDist_Aktiv:BOOL;
END_VAR
VAR_OUTPUT
	Fehler_LascheDistSensor:BOOL;
END_VAR
VAR
	Zeiger_LascheDistSensor:INT;
	TP1:TP;
	Fehler_DIST_Reg: BOOL;
END_VAR
VAR CONSTANT
	Offset_LascheDistSensor:INT:=60;
	LasDist_Schwelle: INT := 2000;
END_VARV  Zeiger_LascheDistSensor := Zeiger_Speicher_Trennstelle - Offset_LascheDistSensor;
IF Zeiger_LascheDistSensor < 1  THEN
	Zeiger_LascheDistSensor := Zeiger_Speicher_Trennstelle - Offset_LascheDistSensor+500;
END_IF


(* Bearbeitung nur wenn Trigger n�chstes Glied und Eintrag G�ltig und keine Sperre zweite Pr�fung *)
IF	ImpulsPos=TRUE AND Speicher_Reg[Zeiger_LascheDistSensor].0=TRUE AND Sperre_23=FALSE THEN
(* Fehlerauswertung nur wenn Pr�fung Aktiv, nur f�r Aussenlaschen und nicht f�r Trennstelle*)
		IF LascheDist_Aktiv= TRUE AND Speicher_Reg[Zeiger_LascheDistSensor].1=FALSE AND Zeiger_LascheDistSensor.0=TRUE THEN
			IF IA_EW4< LasDist_Schwelle THEN
				Speicher_Reg[Zeiger_LascheDistSensor].8:=FALSE;
				Fehler_DIST_Reg:=TRUE;
				Speicher_Reg[Zeiger_LascheDistSensor].5:=FALSE;
				IF	Fehler_LascheDistSensor = FALSE THEN
					Zeiger_Fehler_S3:=Zeiger_Kette_Trennstelle-Offset_LascheDistSensor-1;
					IF Zeiger_Fehler_S3 < 1 THEN
						Zeiger_Fehler_S3:=Zeiger_Fehler_S3+KettenTyp[0];
					END_IF
				END_IF
				Fehler_LascheDistSensor := TRUE;
			ELSE
				Speicher_Reg[Zeiger_LascheDistSensor].8:=TRUE;
			END_IF
		END_IF

			(* Wenn Anfang der Kette unter Lasersensor und Laserfehler liegt an dann Fehler in Register eintragen und r�cksetzen*)
		IF	Speicher_Reg[Zeiger_LascheDistSensor].1=TRUE AND Fehler_DIST_Reg=TRUE THEN
			Speicher_Reg[Zeiger_LascheDistSensor].15:=FALSE;
			Fehler_DIST_Reg:=FALSE;
		END_IF
END_IF

IF	Quitt_Fehler= TRUE THEN
	Fehler_LascheDistSensor:=FALSE;
END_IF


IF  Speicher_Reg[Zeiger_LascheDistSensor].1=TRUE THEN
	Sperre_23:=FALSE;
END_IF
               .   ,   ��           Lasersensor "�F	"�F                      �  FUNCTION_BLOCK Lasersensor
VAR_INPUT
	Quitt_Fehler:BOOL;
	Laschenabstand_Aktiv:BOOL;
	Bolzenhoehe_Aktiv:BOOL;
END_VAR
VAR_OUTPUT
	Fehler_Lasersensor_Laschenabstand:BOOL;
	Fehler_Lasersensor_Bolzenhoeche: BOOL;
END_VAR
VAR
	Zeiger_Lasersensor:INT;
	v1:BOOL;
	Fehler_Laser_Reg: BOOL;
	V23: BOOL;
	S2: INT;
END_VAR
VAR CONSTANT
	Offset_Lasersensor:INT:=48;
	Las_Schwelle: INT := 14200;	(* Schwelle f�r Laschenabstand*)
	Las_Schwelle_2:INT:=9000; (* Schwelle f�r Bolzenh�che *)

END_VAR�	  Zeiger_Lasersensor:=Zeiger_Speicher_Trennstelle-Offset_Lasersensor;
IF Zeiger_Lasersensor < 1  THEN
	Zeiger_Lasersensor:=Zeiger_Speicher_Trennstelle-Offset_Lasersensor+500;
END_IF





(* Bearbeitung nur wenn Trigger n�chstes Glied und Eintrag G�ltig und f�r gerade glieder und keine Sperre zweite Pr�fung*)
IF	PF_KAMM_TRIG.Q=TRUE AND Speicher_Reg[Zeiger_Lasersensor].0 =TRUE  AND Sperre_22=FALSE THEN
	(* Bearbeitung wenn Laschenabstandpr�fung aktiv und nicht Trennstelle*)
	IF Laschenabstand_Aktiv= TRUE AND Speicher_Reg[Zeiger_Lasersensor].1 =FALSE AND Zeiger_Lasersensor.0=TRUE THEN
		IF IA_Las_Sensor< Las_Schwelle THEN
			Speicher_Reg[Zeiger_Lasersensor].7:=FALSE;
			Speicher_Reg[Zeiger_Lasersensor].5:=FALSE;
			Fehler_Laser_Reg:=TRUE;
			IF Fehler_Lasersensor_Laschenabstand=FALSE THEN
				Zeiger_Fehler_S2:=Zeiger_Kette_Trennstelle-Offset_Lasersensor-1;
				IF Zeiger_Fehler_S2 < 1 THEN
					Zeiger_Fehler_S2:=Zeiger_Fehler_S2+KettenTyp[0];
				END_IF
					(*Zeiger_Fehler_S2:=Zeiger_Fehler_S2/2;*)
			END_IF
			Fehler_Lasersensor_Laschenabstand:=TRUE;
		ELSE
			Speicher_Reg[Zeiger_Lasersensor].7:=TRUE;
		END_IF
	END_IF
END_IF

IF	ImpulsPos=TRUE AND Speicher_Reg[Zeiger_Lasersensor].0 =TRUE   AND Sperre_22=FALSE THEN
	IF  Bolzenhoehe_Aktiv=TRUE THEN
		IF  V1=TRUE THEN
			Speicher_Reg[Zeiger_Lasersensor].9:=TRUE;
		ELSE

			Speicher_Reg[Zeiger_Lasersensor].9:=FALSE;
			Fehler_Laser_Reg:=TRUE;
			Speicher_Reg[Zeiger_Lasersensor].5:=FALSE;
			IF Fehler_Lasersensor_Bolzenhoeche=FALSE THEN
				Zeiger_Fehler_S2:=Zeiger_Kette_Trennstelle-Offset_Lasersensor-2;
				IF Zeiger_Fehler_S2 < 1 THEN
					Zeiger_Fehler_S2:=Zeiger_Fehler_S2+KettenTyp[0];
				END_IF
				(*Zeiger_Fehler_S2:=Zeiger_Fehler_S2/2;*)
			END_IF
			Fehler_Lasersensor_Bolzenhoeche:=TRUE;
		END_IF
	END_IF
		V1:=FALSE;

		(* Wenn Anfang der Kette unter Lasersensor und Laserfehler liegt an dann Fehler in Register eintragen und r�cksetzen*)
	IF	Speicher_Reg[Zeiger_Lasersensor].1=TRUE AND Fehler_Laser_Reg=TRUE THEN
		Speicher_Reg[Zeiger_Lasersensor].15:=FALSE;
		Fehler_Laser_Reg:=FALSE;
	END_IF
END_IF

IF	S6_Trennen_2= TRUE THEN
	Fehler_Laser_Reg:=FALSE;
END_IF

(* Bolzenh�che Kontrolle *)

IF IA_Las_Sensor < Las_Schwelle_2 THEN
	V1:= TRUE;
END_IF


IF	Quitt_Fehler= TRUE THEN
	Fehler_Lasersensor_Laschenabstand:=FALSE;
	Fehler_Lasersensor_Bolzenhoeche:=FALSE;
END_IF



IF  Speicher_Reg[Zeiger_Lasersensor].1=TRUE THEN
	Sperre_22:=FALSE;
END_IF
               7   , X t ��           MAIN_1 ���F	���F      �               �  PROGRAM MAIN_1
VAR
	Trennstelle1:Trennstelle;
	Farbsensor1: Farbsensor;
	Lasersensor1: Lasersensor;
	LascheDistSensor1:LascheDistSensor;
	Kammera1: Kammera;
	KetteEndKontrolle1: KetteEndKontrolle;

	Anlagenstoerung1: Anlagestoerung;
	Betriebsartenanwahl1: Betriebsartenanwahl;
	Antriebe_Stoerung: BOOL;
	V1: BOOL;
	SR1: SR;
	V_Fehlerspeicher5: BOOL;
	SR2: SR;
	Z1: CTU;
	V2: BOOL;
	SR3: SR;
	V_Fehlerspeicher1: BOOL;
	SR4: SR;
	V_Fehlerspeicher2: BOOL;
	SR5: SR;
	PF_F10: R_TRIG;
	VH_KettenAnfang: BOOL;
	TP1: TP;
	Fehlrz_1: Fehlerzaehler;
	RS2: RS;
	TON_1: TON;
	PF_REF_IO: R_TRIG;
	PF_Dummy_Erkennung: R_TRIG;
	SR_Dymmy_FRG: SR;
	TON_Sperre2: TON;
	PF_SP1: R_TRIG;
	PF_SP2: R_TRIG;
	SR_Spere2Pruef: SR;
END_VAR      ???�INIT           Anlagenstoerung1�T_Druckluft_Ein�T_Druckluft_AusAH_HandAnlagestoerung  _PneumPressEin         ???�Schrittkette           ???�Nockenschaltwerk           ???�Kettenspeicher           Fehlrz_1�Fehlerzaehler           Betriebsartenanwahl1Antriebe_StoerungA
Automatik2Betriebsartenanwahl  V_Autogestartet      V_Autogestoppt     Trennstelle1�T_KettenAnfangE	PF_REF_IOAREF_IOR_TRIG      ANDAH_HandTrennstelle        VH_KettenAnfang     VH_KettenAnfangAREF_IOANDB�REF_IO
REF_EnableABlink_TON1.QANDOR  H_KettenAnfang     Farbsensor1�T_Qiutt_StoerungA
Quitt_AutoORAKontrolle_Aktiv.0
Farbsensor        Fehlerspeicher1.0     Lasersensor1�T_Qiutt_StoerungA
Quitt_AutoORKontrolle_Aktiv.1AKontrolle_Aktiv.2Lasersensor  Fehlerspeicher1.2      Fehlerspeicher1.1     LascheDistSensor1�T_Qiutt_StoerungA
Quitt_AutoORAKontrolle_Aktiv.3LascheDistSensor        Fehlerspeicher1.3     Kammera1RS2�T_Qiutt_StoerungA
Quitt_AutoOREZ1	ImpulsPosAFALSEOR�T_Qiutt_Stoerung
Quitt_AutoAZ1.QORA4CTU       RS      AKontrolle_Aktiv.5Kammera  Fehlerspeicher2.2 Fehlerspeicher2.3 Fehlerspeicher2.4 Fehlerspeicher2.5 Fehlerspeicher2.6      Fehlerspeicher2.1     KetteEndKontrolle1�TRUEATRUEKetteEndKontrolle        Fehlerspeicher1.6     PF_Fehlerspeicher1_6AFehlerspeicher1.6R_TRIG           KettenTyp[0]A123EQ  Dummy     PF_Dummy_ErkennungADummyR_TRIG       Sperre_2Pruef     TON_Sperre2Sperre_2PruefAT#1sTON            PF_SP1ATON_Sperre2.QR_TRIG           PF_SP2ASperre_2PruefR_TRIG       	Sperre_22	Sperre_23	Sperre_24 	Sperre_21     SR_Spere2PruefPF_SP2.QAPF_SP1.QSR        
Quitt_Auto     SR_Dymmy_FRGPF_Dummy_Erkennung.QBTP_Dummy_QuittBFehlerspeicher2.1Fehlerspeicher2.2Fehlerspeicher2.3Fehlerspeicher2.5Fehlerspeicher2.6Fehlerspeicher1.3Fehlerspeicher1.2Fehlerspeicher1.0AFehlerspeicher1.1ANDORSR        	Dummy_NIO     Z1SKZ1SK.CU
Z1SK.RESETA2CTU            Z2SKZ2SK.CU
Z2SK.RESETA3CTU            Z3SKZ3SK.CU
Z3SK.RESETA1CTU            Z4SKZ4SK.CU
Z4SK.RESETA1CTU       |                  8   , n � �           MAIN_2 ���F	���F          	 `            PROGRAM MAIN_2
VAR
END_VAR   ;               9   , � � 8           Nockenschaltwerk ���F	���F       � PX8�          PROGRAM Nockenschaltwerk
VAR
	Zeiger :INT:=0;
	Nocke:BOOL:=FALSE;
	Zaeler:WORD;
	(*Skal_IC_SSI_DG_Input: DINT;*)
	Skal_IC_SSI_DG_Input_Alt:DINT;
	Skal_IC_SSI_DG_Input_Delta:DINT;
	K_DG_Input: DINT;
	K_DG_In_Alt:DINT;
	K_DG_In_Delta:DINT;
	CTU2:WORD;
END_VAR
�  (*  Miroslav Knezevic TCM 19.03.07  *)
(*  Das Nockenschaltwerk liefert 20 Impulse bei einer Umdrehung des SSI Drehgebers *)
(* Voller Kreis = 8192 Inkremente,  1 Impuls= 20 Inkremente *)



Skal_IC_SSI_DG_Input:=20-IC_SSI_DG_Input* 20 / 16777216;
Skal_IC_SSI_DG_Input_Delta:=Skal_IC_SSI_DG_Input - Skal_IC_SSI_DG_Input_Alt;

IF Skal_IC_SSI_DG_Input_Delta<-5 THEN
	Skal_IC_SSI_DG_Input_Delta:=1;
END_IF

IF Skal_IC_SSI_DG_Input_Delta>5 THEN
	Skal_IC_SSI_DG_Input_Delta:=-1;
END_IF

Zeiger_Speicher_Trennstelle:=DINT_TO_INT(Zeiger_Speicher_Trennstelle+Skal_IC_SSI_DG_Input_Delta);
IF Zeiger_Speicher_Trennstelle>500 THEN
	Zeiger_Speicher_Trennstelle:=1;
END_IF
IF Zeiger_Speicher_Trennstelle<1 THEN
	Zeiger_Speicher_Trennstelle:=500;
END_IF

CTU1(
	CU:=M1 ,
	RESET:= ,
	PV:=500 ,
	Q=> ,
	CV=> );

CTU2:=CTU1.CV;


Zeiger_Kette_Trennstelle:=DINT_TO_INT(Zeiger_Kette_Trennstelle+Skal_IC_SSI_DG_Input_Delta);
IF Zeiger_Kette_Trennstelle>KettenTyp[0] THEN
	Zeiger_Kette_Trennstelle:=1;
END_IF

IF Zeiger_Kette_Trennstelle<1 THEN
	Zeiger_Kette_Trennstelle:=KettenTyp[0];
END_IF

IF ABS(Skal_IC_SSI_DG_Input_Delta)>1 THEN
		M1:=TRUE;
ELSE
		M1:=FALSE;

END_IF


IF Skal_IC_SSI_DG_Input_Delta=1 THEN
	ImpulsPos:=TRUE;
ELSE
	ImpulsPos:=FALSE;
END_IF;

IF Skal_IC_SSI_DG_Input_Delta=-1 THEN
	ImpulsNeg:=TRUE;
ELSE
	ImpulsNeg:=FALSE;
END_IF;



Skal_IC_SSI_DG_Input_Alt:=Skal_IC_SSI_DG_Input;

(* Verschiebbahrer Triggerpunkt f�r die Kammera *)



                  , n � ��           Schrittkette ���F	���F                      "   PROGRAM Schrittkette
VAR
END_VAR	       Init         TRUE      	   Automatik                         Aktion Automatik �F      	AUTOMATIK 
M2_Start_R
Automatik2FRG_DLA
M2_Start_V     	AUTOMATIK 
Z1SK.RESET
Z2SK.RESET
Z3SK.RESET
Z4SK.RESET     	AUTOMATIK S2_Vor_1S6_Trennen_2S0_Automatikd          Trans2                         Transition Trans2 	�F      PF_Fehlerspeicher1_6.Qd          Rueck_1      ANSpch_R           Aktion Rueck_1 �F      RUECK_1 
M2_Start_R
Automatik2
M2_Start_V     RUECK_1 
Z1SK.RESET
Z2SK.RESET
Z3SK.RESET
Z4SK.RESET     RUECK_1 S0_Automatik
S1_Rueck_1     H_KettenAnfang  Z1SK.CUd      J                        Aktion Rueck_1 - Exit �F      TRUE 
Quitt_Autod      Z1SK.Q         Vor_1                          Aktion Vor_1 �F      H_KettenAnfang  Z2SK.CU     VOR_1 
S1_Rueck_1S2_Vor_1
Quitt_Auto     VOR_1 
M2_Start_R
M2_Start_Vd        	    Trans0 I                        Transition Trans0 	�F      Z2SK.Q#Speicher_Reg[Zeiger_Endkontrolle].1AFehlerspeicher1.6ANDd          Rueck_2 R                        Aktion Rueck_2 �F      RUECK_2 S2_Vor_1
S3_Rueck_2
M2_Start_R
M2_Start_V     H_KettenAnfang  Z3SK.CUd          Z3SK.Q      	   Trennen_1 U                        Aktion Trennen_1 �F      	TRENNEN_1 
S3_Rueck_2S4_Trennen_1
M2_Start_RFRG_DLA
M2_Start_Vd          NOT(T_Start)         Rueck_3 V                        Aktion Rueck_3 �F      H_KettenAnfang  Z4SK.CU     RUECK_3 S4_Trennen_1
S5_Rueck_3
Quitt_Auto     RUECK_3 
M2_Start_RFRG_DLA
M2_Start_Vd          Z4SK.Q      	   Trennen_2 W                        Aktion Trennen_2 �F      	TRENNEN_2 
S5_Rueck_3S6_Trennen_2
Quitt_Auto     	TRENNEN_2 
M2_Start_RFRG_DLASperre_2Pruef
M2_Start_Vd          NOT(T_Start)      Trans4 G                        Transition Trans4 	�F      Z2SK.Q#Speicher_Reg[Zeiger_Endkontrolle].1�Fehlerspeicher1.6ANDd      Init   Initd                  3   , B W ��           Trennstelle ���F	���F                   9  FUNCTION_BLOCK Trennstelle
VAR_INPUT
	TasteKettenanfang:BOOL;    (* Taste am Bedienpanell *)
	H_Handbetrieb:BOOL; 	(*Leuchte am Bedienpanell Maschine ist in Handbetrieb*)
END_VAR
VAR_OUTPUT
	H_KettenAnfang:BOOL;	(*Leuchte am Bedienpanell*)
END_VAR
VAR
	J:INT;
	Gliederzahl_Alt: INT;
	V1: BOOL;
END_VARY  
(* Kettenanfang im Handbetrieb setzen *)
IF H_Handbetrieb= TRUE AND TasteKettenanfang=TRUE  THEN
	Zeiger_Kette_Trennstelle:=KettenTyp[0];
	Sperre_2Pruef :=TRUE;
END_IF


(* Auftragswechsel *)

IF	KettenTyp[0] <> Gliederzahl_Alt THEN
	Zeiger_Kette_Trennstelle:= KettenTyp[0];
	Sperre_2Pruef :=TRUE;
END_IF
Gliederzahl_Alt:=KettenTyp[0];



(*Kettenanfang ist gerade unter der Trennstelle signalisieren*)
IF Zeiger_Kette_Trennstelle= KettenTyp[0] THEN
	H_KettenAnfang:=TRUE;
ELSE
	H_KettenAnfang:=FALSE;
END_IF


IF	ImpulsPos=TRUE THEN

	(* In Speicherregister die Farben der Laschen eintragen*)
	FOR J:=1 TO 5  DO
	IF KettenTyp[2*J]*2+1=Zeiger_Kette_Trennstelle THEN;
		IF KettenTyp[2*J-1]=0 THEN
		Speicher_Reg[Zeiger_Speicher_Trennstelle].2:=FALSE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].3:=FALSE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].4:=FALSE;
		END_IF
		IF KettenTyp[2*J-1]=1 THEN
		Speicher_Reg[Zeiger_Speicher_Trennstelle].2:=FALSE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].3:=FALSE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].4:=TRUE;
		END_IF
		IF KettenTyp[2*J-1]=2 THEN
		Speicher_Reg[Zeiger_Speicher_Trennstelle].2:=FALSE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].3:=TRUE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].4:=FALSE;
		END_IF
		IF KettenTyp[2*J-1]=3 THEN
		Speicher_Reg[Zeiger_Speicher_Trennstelle].2:=FALSE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].3:=TRUE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].4:=TRUE;
		END_IF
	END_IF
	END_FOR


	(* In Speicherregister Anfang der Kette eintragen *)
	IF Zeiger_Kette_Trennstelle=1 THEN
		Speicher_Reg[Zeiger_Speicher_Trennstelle].1:=TRUE;
		Speicher_Reg[Zeiger_Speicher_Trennstelle].15:=TRUE;
	ELSE
		Speicher_Reg[Zeiger_Speicher_Trennstelle].1:=FALSE;
	END_IF

	(* Registereintrag g�ltig,  n�chsten ung�ltig setzen und Glied IO setzen*)
	Speicher_Reg[Zeiger_Speicher_Trennstelle].0:=TRUE;
	IF	Zeiger_Speicher_Trennstelle<500 THEN
		Speicher_Reg[Zeiger_Speicher_Trennstelle+1]:=0;
	ELSE
		Speicher_Reg[1]:=0;
	END_IF
	Speicher_Reg[Zeiger_Speicher_Trennstelle].5:=TRUE;

END_IF
               4   , � � z           Ventil_Integer ���F	���F                      �   FUNCTION_BLOCK Ventil_Integer
VAR_INPUT
	K:BOOL;
	IN_Integer:INT;
END_VAR
VAR_OUTPUT
	OUT_Integer:INT;
END_VAR
VAR
END_VARM   IF K=TRUE THEN
	OUT_Integer:=IN_Integer;
ELSE
	OUT_Integer:=0;
END_IF

                A                        visu ���F       d                                                                                                              � Z -� �   ���     ���                                                                      ���                                                                                                                                            �2 1� �n   ���     ���                                                                     ���                                                                                                                                            � ��M@  ���     ���                                                                     ���                                                                                                                                            rhO���  ���     ���                                                                     ���                                          �   ��   �   ��   � � � ���     �   ��   �   ��   � � � ���                  ����, � � g         "   STANDARD.LIB 5.6.98 12:03:02 @V�w5      CONCAT @                	   CTD @        	   CTU @        
   CTUD @           DELETE @           F_TRIG @        
   FIND @           INSERT @        
   LEFT @        	   LEN @        	   MID @           R_TRIG @           REPLACE @           RIGHT @           RS @        
   SEMA @           SR @        	   TOF @        	   TON @           TP @              Global Variables 0 @                        , B W ��           2                ����������������  
             ����  X���            ����  r_eierre                  	   Bausteine	            
   Funktionen  ����              Funktionsbausteine                 _ASM_FU_SOLLW  #                   Anlagestoerung  $                   Betriebsartenanwahl  %                
   Farbsensor  )                   FB_Trig_KAMM  F                   Fehlerzaehler  E                   Kammera  *                   KetteEndKontrolle  +                   KS  ,                   LascheDistSensor  -                   Lasersensor  .                   Trennstelle  3                   Ventil_Integer  4   ����                INIT  5                   Kammprg  H                   Kettenspeicher  6                   MAIN_1  7                   MAIN_2  8                   Nockenschaltwerk  9                   Schrittkette     ����           
   Datentypen                 DriveControl  :                	   KettenTyp  ;               
   KS_Control  <                   MotorControl  =                   PneumControl  >                
   PosControl  ?                   StationControl  @   ����             Visualisierungen                 visu  A   ����              Globale Variablen                Globale_Variablen  B                   Variable_Configuration  C                   Variablen_Konfiguration  D   ����                                                              �f/F                         	   localhost            P      	   localhost            P      	   localhost            P             ���`