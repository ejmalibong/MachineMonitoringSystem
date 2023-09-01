'Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied

Imports System.ComponentModel

''' <summary>
''' Animates a form when it is shown, hidden or closed
''' </summary>
''' <remarks>
''' MDI child forms do not support the Fade method and only support other methods while being displayed for the first time and when closing
''' </remarks>
Public NotInheritable Class FormAnimator

#Region "Types"

    ''' <summary>
    ''' The directions in which the Roll and Slide animations can be shown
    ''' </summary>
    ''' <remarks>
    ''' Horizontal and vertical directions can be combined to create diagonal animations
    ''' </remarks>
    <Flags>
    Public Enum AnimationDirection

        ''' <summary>
        ''' From left to right
        ''' </summary>
        Right = &H1

        ''' <summary>
        ''' From right to left
        ''' </summary>
        Left = &H2

        ''' <summary>
        ''' From top to bottom
        ''' </summary>
        Down = &H4

        ''' <summary>
        ''' From bottom to top
        ''' </summary>
        Up = &H8

    End Enum

    ''' <summary>
    ''' The methods of animation available.
    ''' </summary>
    Public Enum AnimationMethod

        ''' <summary>
        ''' Rolls out from edge when showing and into edge when hiding
        ''' </summary>
        ''' <remarks>
        ''' This is the default animation method and requires a direction
        ''' </remarks>
        Roll = &H0

        ''' <summary>
        ''' Expands out from center when showing and collapses into center when hiding
        ''' </summary>
        Center = &H10

        ''' <summary>
        ''' Slides out from edge when showing and slides into edge when hiding
        ''' </summary>
        ''' <remarks>
        ''' Requires a direction
        ''' </remarks>
        Slide = &H40000

        ''' <summary>
        ''' Fades from transaprent to opaque when showing and from opaque to transparent when hiding
        ''' </summary>
        Fade = &H80000

    End Enum

#End Region

#Region "Constants"

    ''' <summary>
    ''' Activate the form
    ''' </summary>
    Private Const AwActivate As Integer = &H20000

    ''' <summary>
    ''' Hide the form
    ''' </summary>
    Private Const AwHide As Integer = &H10000

    ''' <summary>
    ''' The number of milliseconds over which the animation occurs if no value is specified
    ''' </summary>
    Private Const DefaultDuration As Integer = 250

#End Region

#Region "Variables"

    ''' <summary>
    ''' The form to be animated
    ''' </summary>
    Private ReadOnly _form As Form

    ''' <summary>
    ''' The direction in which to Roll or Slide the form
    ''' </summary>
    Private _direction As AnimationDirection

    ''' <summary>
    ''' The number of milliseconds over which the animation is played
    ''' </summary>
    Private _duration As Integer

    ''' <summary>
    ''' The animation method used to show and hide the form
    ''' </summary>
    Private _method As AnimationMethod

#End Region

#Region "Proerties"

    ''' <summary>
    ''' Gets or Sets the direction in which the animation is performed
    ''' </summary>
    ''' <value>
    ''' The direction in which the animation is performed
    ''' </value>
    ''' <remarks>
    ''' The direction is only applicable to the <b>Roll</b> and <b>Slide</b> methods
    ''' </remarks>
    Public Property Direction As AnimationDirection
        Get
            Return _direction
        End Get
        Set(ByVal value As AnimationDirection)
            _direction = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or Sets the number of milliseconds over which the animation is played
    ''' </summary>
    ''' <value>
    ''' The number of milliseconds over which the animation is played
    ''' </value>
    Public Property Duration As Integer
        Get
            Return _duration
        End Get
        Set(ByVal value As Integer)
            _duration = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the form to be animated
    ''' </summary>
    ''' <value>
    ''' The form to be animated
    ''' </value>
    Public ReadOnly Property Form As Form
        Get
            Return _form
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the animation method used to show and hide the form
    ''' </summary>
    ''' <value>
    ''' The animation method used to show and hide the form
    ''' </value>
    ''' <remarks>
    ''' <b>Roll</b> is used by default if no method is specified
    ''' </remarks>
    Public Property Method As AnimationMethod
        Get
            Return _method
        End Get
        Set(ByVal value As AnimationMethod)
            _method = value
        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Creates a new <b>FormAnimator</b> object for the specified form
    ''' </summary>
    ''' <param name="form">
    ''' The form to be animated
    ''' </param>>
    ''' <remarks>
    ''' No animation will be used unless the <b>Method</b> and/or <b>Direction</b> properties are set independently. The <b>Duration</b> is set to quarter of a second by default.
    ''' </remarks>
    Public Sub New(ByVal form As Form)
        _form = form

        AddHandler _form.Load, AddressOf Form_Load
        AddHandler _form.VisibleChanged, AddressOf Form_VisibleChanged
        AddHandler _form.Closing, AddressOf Form_Closing

        _duration = DefaultDuration
    End Sub

    ''' <summary>
    ''' Creates a new <b>FormAnimator</b> object for the specified form using the specified method over the specified duration
    ''' </summary>
    ''' <param name="form">
    ''' The form to be animated
    ''' </param>
    ''' <param name="method">
    ''' The animation method used to show and hide the form
    ''' </param>
    ''' <param name="duration">
    ''' The number of milliseconds over which the animation is played
    ''' </param>
    ''' <remarks>
    ''' No animation will be used for the <b>Roll</b> or <b>Slide</b> methods unless the <b>Direction</b> property is set independently
    ''' </remarks>
    Public Sub New(ByVal form As Form, ByVal method As AnimationMethod, ByVal duration As Integer)
        Me.New(form)
        _method = method
        _duration = duration
    End Sub

    ''' <summary>
    ''' Creates a new <b>FormAnimator</b> object for the specified form using the specified method in the specified direction over the specified duration
    ''' </summary>
    ''' <param name="form">
    ''' The form to be animated
    ''' </param>
    ''' <param name = "method">
    ''' The animation method used to show and hide the form
    ''' </param>
    ''' <param name="direction">
    ''' The direction in which to animate the form
    ''' </param>
    ''' <param name="duration">
    ''' The number of milliseconds over which the animation is played
    ''' </param>
    ''' <remarks>
    ''' The <i>direction</i> argument will have no effect if the <b>Center</b> or <b>Fade</b> method is
    ''' specified
    ''' </remarks>
    Public Sub New(ByVal form As Form, ByVal method As AnimationMethod, ByVal direction As AnimationDirection, ByVal duration As Integer)
        Me.New(form, method, duration)
        _direction = direction
    End Sub

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' Animates the form automatically when it closes
    ''' </summary>
    Private Sub Form_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
        If Not e.Cancel Then
            ' MDI child forms do not support transparency so do not try to use the Fade method.
            If _form.MdiParent Is Nothing OrElse _method <> AnimationMethod.Fade Then
                NativeMethods.AnimateWindow(_form.Handle, _duration, AwHide Or _method Or _direction)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Animates the form automatically when it is loaded
    ''' </summary>
    Private Sub Form_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' MDI child forms do not support transparency so do not try to use the Fade method
        If _form.MdiParent Is Nothing OrElse _method <> AnimationMethod.Fade Then
            NativeMethods.AnimateWindow(_form.Handle, _duration, AwActivate Or _method Or _direction)
        End If
    End Sub

    ''' <summary>
    ''' Animates the form automatically when it is shown or hidden
    ''' </summary>
    Private Sub Form_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Do not attempt to animate MDI child forms while showing or hiding as they do not behave as expected
        If _form.MdiParent Is Nothing Then
            Dim flags = _method Or _direction

            If _form.Visible Then
                flags = flags Or AwActivate
            Else
                flags = flags Or AwHide
            End If

            NativeMethods.AnimateWindow(_form.Handle, _duration, flags)
        End If
    End Sub

#End Region

End Class