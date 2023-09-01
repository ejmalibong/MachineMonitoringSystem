Partial Public Class Notification
    Inherits Form

    Private Shared ReadOnly OpenNotifications As List(Of Notification) = New List(Of Notification)()
    Private ReadOnly _animator As FormAnimator
    Private _allowFocus As Boolean
    Private _currentForegroundWindow As IntPtr

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="headerText"></param>
    ''' <param name="detailText"></param>
    ''' <param name="duration"></param>
    ''' <param name="animation"></param>
    ''' <param name="direction"></param>
    Public Sub New(headerText As String, detailText As List(Of String), duration As Integer, animation As FormAnimator.AnimationMethod, direction As FormAnimator.AnimationDirection, style As Integer)
        InitializeComponent()

        If duration < 0 Then
            duration = Integer.MaxValue
        Else
            duration = duration * 1000
        End If

        tmrNotification.Interval = duration
        lblHeader.Text = headerText

        lsvDetail.Columns.Add("Pending", HorizontalAlignment.Left)

        For Each item In detailText
            lsvDetail.Items.Add(item.ToString)
        Next

        lsvDetail.Columns.Item(0).Width = -1
        lsvDetail.View = View.List
        lsvDetail.ShowItemToolTips = True

        _animator = New FormAnimator(Me, animation, direction, 500)

        Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 5, Height - 5, 20, 20))

        Select Case style
            Case 1 'zero stock
                lblHeader.BackColor = Color.DarkRed
                lsvDetail.BackColor = Color.DarkRed
                Me.BackColor = Color.DarkRed

                lblHeader.ForeColor = Color.Yellow
                lsvDetail.ForeColor = Color.White

            Case 2 'below ordering point
                lblHeader.BackColor = Color.Yellow
                lsvDetail.BackColor = Color.Yellow
                Me.BackColor = Color.Yellow

                lblHeader.ForeColor = Color.DarkRed
                lsvDetail.ForeColor = Color.Black

            Case 3 'below min stock
                lblHeader.BackColor = Color.Orange
                lsvDetail.BackColor = Color.Orange
                Me.BackColor = Color.Orange

                lblHeader.ForeColor = Color.DarkRed
                lsvDetail.ForeColor = Color.Black
        End Select
    End Sub

#Region "Methods"

    ''' <summary>
    ''' Displays the form
    ''' </summary>
    ''' <remarks>
    ''' Required to allow the form to determine the current foreground window before being displayed
    ''' </remarks>
    Public Overloads Sub Show()
        ' Determine the current foreground window so it can be reactivated each time this form tries to get the focus
        _currentForegroundWindow = NativeMethods.GetForegroundWindow()

        MyBase.Show()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub lblNotifText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblHeader.Click
        Close()
    End Sub

    Private Sub lsvDetail_Click(sender As Object, e As EventArgs) Handles lsvDetail.Click
        Close()
    End Sub

    Private Sub lsvDetail_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lsvDetail.ItemSelectionChanged
        If e.IsSelected Then
            e.Item.Selected = False
        End If
    End Sub

    Private Sub lsvDetail_MouseClick(sender As Object, e As MouseEventArgs) Handles lsvDetail.MouseClick
        Close()
    End Sub

    Private Sub lsvDetail_MouseDown(sender As Object, e As MouseEventArgs) Handles lsvDetail.MouseDown
        Close()
    End Sub

    Private Sub Notification_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        ' Prevent the form taking focus when it is initially shown
        If Not _allowFocus Then
            ' Activate the window that previously had focus
            NativeMethods.SetForegroundWindow(_currentForegroundWindow)
        End If
    End Sub

    Private Sub Notification_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Click
        Close()
    End Sub

    Private Sub Notification_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Move down any open forms above this one
        For Each openForm In OpenNotifications
            If openForm Is Me Then
                ' Remaining forms are below this one
                Exit For
            End If
            openForm.Top += Height
        Next

        OpenNotifications.Remove(Me)
    End Sub

    Private Sub Notification_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Display the form just above the system tray.
        Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height)

        ' Move each open form upwards to make room for this one
        For Each openForm In OpenNotifications
            openForm.Top -= Height
        Next

        OpenNotifications.Add(Me)
        tmrNotification.Start()
    End Sub

    Private Sub Notification_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Close()
    End Sub

    Private Sub Notification_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        ' Once the animation has completed the form can receive focus
        _allowFocus = True

        ' Close the form by sliding down.
        _animator.Duration = 0
        _animator.Direction = FormAnimator.AnimationDirection.Down
    End Sub

    Private Sub tmrNotification_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrNotification.Tick
        Close()
    End Sub
#End Region

End Class