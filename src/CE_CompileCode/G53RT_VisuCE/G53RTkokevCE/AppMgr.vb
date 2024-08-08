Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung


Public Class AppMgr

    Public Shared frm1 As Form1
    'Public Shared gfxobj As Cgfx

    Shared Sub Main()
        ' Declare a variable named frm1 of type Form1.
        ' Instantiate (create) a new Form1 object and assign
        ' it to variable frm1.
        frm1 = New Form1    'lade hauptfenster

        ' Call the Application class' Run method
        ' passing it the Form1 object created above.
        Application.Run(frm1)
    End Sub
End Class
