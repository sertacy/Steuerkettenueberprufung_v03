Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports umgebung

'Button with an image custom control.
Public Class PictureButton
    Inherits Control
    Public myx As Integer = 0
    Public myy As Integer = 0
    Public farbwert As Integer = 0
    Private backgroundImg As Image
    Private pressedImg As Image
    Private pressed As Boolean = False

    ' Property for the background image to be drawn behind the button text.
    Public Property BackgroundImageValue() As Image
        Get
            Return Me.backgroundImg
        End Get
        Set(ByVal Value As Image)
            Me.backgroundImg = Value
        End Set
    End Property

    ' Property for the background image to be drawn behind the button text when
    ' the button is pressed.
    Public Property PressedImageValue() As Image
        Get
            Return Me.pressedImg
        End Get
        Set(ByVal Value As Image)
            Me.pressedImg = Value
        End Set
    End Property

    ' When the mouse button is pressed, set the "pressed" flag to true
    ' and ivalidate the form to cause a repaint.  The .NET Compact Framework
    ' sets the mouse capture automatically.
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Me.pressed = True
        Me.Invalidate()
        MyBase.OnMouseDown(e)
    End Sub

    ' When the mouse is released, reset the "pressed" flag
    ' and invalidate to redraw the button in the unpressed state.
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        Me.pressed = False
        Me.Invalidate()
        MyBase.OnMouseUp(e)
    End Sub

    ' Override the OnPaint method to draw the background image and the text.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Me.pressed AndAlso Not (Me.pressedImg Is Nothing) Then
            e.Graphics.DrawImage(Me.pressedImg, 0, 0)
        Else
            e.Graphics.DrawImage(Me.backgroundImg, 0, 0)
        End If

        ' Draw the text if there is any.
        If Me.Text.Length > 0 Then
            Dim size As SizeF = e.Graphics.MeasureString(Me.Text, Me.Font)

            ' Center the text inside the client area of the PictureButton.
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), _
                (Me.ClientSize.Width - size.Width) / 2, _
                (Me.ClientSize.Height - size.Height) / 2)
        End If

        ' Draw a border around the outside of the   
        ' control to look like Pocket PC buttons.
        e.Graphics.DrawRectangle(New Pen(Color.Black), 0, 0, _
           Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)

        MyBase.OnPaint(e)
    End Sub
End Class
