Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class clsMethod
    Private sqlDbMethod As New clsSqlDbMethod
    Private table As DataTable

    'allow single instance of a child form
    Public Sub FormLoader(ByVal frmParent As Form, ByVal frmChild As Form)
        Try
            For Each mdiChild As Form In frmParent.MdiChildren
                If mdiChild.Name = frmChild.Name Then
                    mdiChild.Activate()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = frmParent
            frmChild.Show()
            frmChild.StartPosition = FormStartPosition.CenterScreen
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'trap child form inside the parent form/mdi container
    Public Sub FormTrap(ByVal form As Form)
        If form.Left <= 0 Then
            form.Location = New Point(0, form.Location.Y)
            If form.Top < 0 Then
                form.Top = 0
            ElseIf form.Top > ((form.MdiParent.ClientRectangle.Height - 50) - form.Height) Then
                form.Top = (form.MdiParent.ClientRectangle.Height - 30) - form.Height
            End If
        ElseIf form.Right >= form.MdiParent.ClientRectangle.Width Then
            form.Left = (form.MdiParent.Width - 20) - form.Width
        ElseIf form.Top < 0 Then
            form.Top = 0
        ElseIf form.Top >= ((form.MdiParent.ClientRectangle.Height - 50) - form.Height) Then
            form.Top = (form.MdiParent.ClientRectangle.Height - 50) - form.Height
        End If
    End Sub

    'reset all controls of a form
    Public Sub FormReset(ByVal form As Control)
        Try
            For Each ctrl As Control In form.Controls
                FormReset(ctrl)
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Text = String.Empty
                End If
                If TypeOf ctrl Is ComboBox Then
                    CType(ctrl, ComboBox).SelectedValue = 0
                End If
                If TypeOf ctrl Is DateTimePicker Then
                    CType(ctrl, DateTimePicker).Value = Date.Now
                End If
            Next ctrl
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'double buffered datagridview for optimization
    Public Sub EnableDoubleBuffered(ByVal dgv As DataGridView)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub

    'fill combobox
    Public Sub FillCmb(ByVal spName As String, ByVal valueMember As String, ByVal displayMember As String, ByVal cmb As ComboBox, Optional params() As SqlParameter = Nothing)
        Try
            table = New DataTable
            table = sqlDbMethod.FillDataTable(spName, params)

            If table.Rows.Count > 0 Then
                cmb.ValueMember = valueMember
                cmb.DisplayMember = displayMember
                cmb.DataSource = table
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec

        Return Nothing
    End Function

    'convert bytes to readable format (round up)
    Public Function ReadableFileSize(ByVal fileLength As Long) As String
        Dim suffix As String = String.Empty

        If fileLength < 1000 Then
            suffix = " Bytes"
            GoTo showIt
        End If
        If fileLength > 1000000 Then
            fileLength = Int(fileLength / 1000000)
            suffix = " Mb"
            GoTo showIt
        Else
            fileLength = Int(fileLength / 1000)
            suffix = " Kb"
        End If

showIt: Return fileLength & suffix
    End Function

    '1\20
    'resize image to reduce file size
    'from http://mrbigglesworth79.blogspot.com/2011/04/resizing-image-on-fly-using-net.html
    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer

        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If

        Dim newImage As Image = New Bitmap(newWidth, newHeight)

        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function

    'set exception message to show line number
    Public Function SetExcpTitle(ByVal ex As Exception) As String
        Dim sTrace = New System.Diagnostics.StackTrace(ex, True)
        Dim frames() As StackFrame = sTrace.GetFrames()
        Dim title As String = String.Empty

        For Each frame As StackFrame In frames
            'title = frame.GetFileName & " " & frame.GetFileLineNumber().ToString
            title = frame.GetFileLineNumber().ToString
        Next

        Return title
    End Function

    'format date to capture am to pm
    Public Function FormatDate(ByVal _dateParam As DateTime, ByVal isStartDate As Boolean) As String
        Dim year As String = "" & _dateParam.Year
        Dim month As String = If((_dateParam.Month < 10), "0" & _dateParam.Month, "" & _dateParam.Month)
        Dim day As String = If((_dateParam.Day < 10), "0" & _dateParam.Day, "" & _dateParam.Day)

        If isStartDate = True Then
            Return year & "-" & month & "-" & day & " 00:00:00"
        Else
            Return year & "-" & month & "-" & day & " 23:59:59"
        End If
    End Function

    'set bindingsource relationships
    'Public Sub SetRelation(sender As DataSet, MasterTableName As String, ChildTableName As String, MasterKeyColumn As String, ChildKeyColumn As String)
    '    sender.Relations.Add(
    '     New DataRelation(String.Concat(MasterTableName, ChildTableName),
    '        sender.Tables(MasterTableName).Columns(MasterKeyColumn),
    '        sender.Tables(ChildTableName).Columns(ChildKeyColumn)
    '     )
    '  )
    'End Sub

End Class
