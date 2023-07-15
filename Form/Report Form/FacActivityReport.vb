Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary
Imports Microsoft.Reporting.WinForms

Public Class FacActivityReport
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private directory As New Directory
    Private imgDirectory As String = directory.ImgIniDirectoryFc

    Private shift As Char = String.Empty

    Private dtTrxImgAttachment As New DataTable

    Private containerTable As New DataTable

    Private Sub frmMntActivityReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim prmTechnician(1) As SqlParameter
            prmTechnician(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmTechnician(0).Value = 3
            prmTechnician(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmTechnician(1).Value = True
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbUserName, "< All > ", prmTechnician)
            AddHandler cmbUserName.Validated, AddressOf cmbUserName_Validated

            rdBoth.Checked = True

            Dim prmArea(0) As SqlParameter
            prmArea(0) = New SqlParameter("@AreaId", SqlDbType.Int)
            prmArea(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdFacArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbArea, "< All > ", prmArea)
            AddHandler cmbArea.Validated, AddressOf cmbArea_Validated

            Dim prmTrxStatus(0) As SqlParameter
            prmTrxStatus(0) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
            prmTrxStatus(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus, "< All > ", prmTrxStatus)

            Dim prMachineStatus(0) As SqlParameter
            prMachineStatus(0) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
            prMachineStatus(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdFacMachineSubStatus", CommandType.StoredProcedure, "MachineSubStatusId", "MachineSubStatusName", cmbMachineDowntimeSubStatus, "< All > ", prMachineStatus)

            dbMethod.FillCmbWithCaption("RdFacMachine", CommandType.StoredProcedure, "MachineId", "MachineCode", cmbMachine, "< All > ")
            AddHandler cmbMachine.Validated, AddressOf cmbMachine_Validated

            Me.ActiveControl = btnGenerate

            BuildContainerTable(containerTable)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntActivityReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpStartDate.Value.Date = dtpEndDate.Value.Date Then
                GenerateReport()
            Else
                GenerateReport()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
        dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date
        cmbUserName.SelectedValue = 0
        rdBoth.Checked = True
        cmbArea.SelectedValue = 0
        cmbTransactionStatus.SelectedValue = 0
        cmbMachineDowntimeSubStatus.SelectedValue = 0
        cmbMachine.SelectedValue = 0
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GenerateReport()
        Dim prmRpt(7) As SqlParameter
        prmRpt(0) = New SqlParameter("@StartDate", SqlDbType.Date)
        prmRpt(0).Value = dbMain.FormatDate(dtpStartDate.Value.Date, True)
        prmRpt(1) = New SqlParameter("@EndDate", SqlDbType.Date)
        prmRpt(1).Value = dbMain.FormatDate(dtpEndDate.Value.Date, False)
        prmRpt(2) = New SqlParameter("@ShiftId", SqlDbType.Char)
        prmRpt(2).Value = GetShift()
        prmRpt(3) = New SqlParameter("@AreaId", SqlDbType.Int)
        prmRpt(3).Value = GetArea()
        prmRpt(4) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
        prmRpt(4).Value = GetTransactionStatus()
        prmRpt(5) = New SqlParameter("@DowntimeMachineSubStatusId", SqlDbType.Int)
        prmRpt(5).Value = GetDowntimeMachineSubStatus()
        prmRpt(6) = New SqlParameter("@MachineId", SqlDbType.Int)
        prmRpt(6).Value = GetMachine()
        prmRpt(7) = New SqlParameter("@UserId", SqlDbType.Int)
        prmRpt(7).Value = GetUserName()

        Dim dtReport As DataTable
        dtReport = dbMethod.FillDataTable("RptFacActivityReport2", CommandType.StoredProcedure, prmRpt)

        If Not rdBoth.Checked = True Then
            If rdDay.Checked = True Then
                shift = "DS"
            Else
                shift = "NS"
            End If
        Else
            shift = "BS"
        End If

        If containerTable.Rows.Count > 0 Then
            containerTable.Clear()
        End If

        Dim bmps As List(Of Bitmap) = New List(Of Bitmap)

        For i As Integer = 0 To dtReport.Rows.Count - 1
            Dim conNewRow As DataRow = containerTable.NewRow
            conNewRow("TrxId") = dtReport.Rows(i).Item("TrxId")
            conNewRow("TrxDate") = dtReport.Rows(i).Item("TrxDate")
            conNewRow("ShiftId") = IIf(dtReport.Rows(i).Item("ShiftId") = "D", "DS", "NS")
            conNewRow("AreaId") = dtReport.Rows(i).Item("AreaId")
            conNewRow("AreaName") = dtReport.Rows(i).Item("AreaName")
            conNewRow("MachineId") = dtReport.Rows(i).Item("MachineId")
            conNewRow("MachineName") = dtReport.Rows(i).Item("MachineName")
            conNewRow("DowntimeMachineSubStatusId") = dtReport.Rows(i).Item("DowntimeMachineSubStatusId")
            conNewRow("MachineSubStatusName") = dtReport.Rows(i).Item("MachineSubStatusName")
            conNewRow("DatetimeStarted") = dtReport.Rows(i).Item("DatetimeStarted")
            conNewRow("DatetimeEnded") = dtReport.Rows(i).Item("DatetimeEnded")
            conNewRow("UserId") = dtReport.Rows(i).Item("UserId")
            conNewRow("Duration") = dtReport.Rows(i).Item("Duration")
            conNewRow("PicName") = dtReport.Rows(i).Item("PicName")
            conNewRow("Problem") = dtReport.Rows(i).Item("Problem")
            conNewRow("RootCause") = dtReport.Rows(i).Item("RootCause")
            conNewRow("ActionTaken") = dtReport.Rows(i).Item("ActionTaken")
            conNewRow("JoNumber") = dtReport.Rows(i).Item("JoNumber")
            conNewRow("JoRequestor") = dtReport.Rows(i).Item("JoRequestor")
            conNewRow("TrxStatusId") = dtReport.Rows(i).Item("TrxStatusId")
            conNewRow("TrxStatusName") = dtReport.Rows(i).Item("TrxStatusName")
            conNewRow("SparePartName") = dtReport.Rows(i).Item("SparePartName")
            conNewRow("SparePartNo") = dtReport.Rows(i).Item("SparePartNo")

            Dim aCount As Integer
            Dim prmCount(0) As SqlParameter
            prmCount(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmCount(0).Value = dtReport.Rows(i).Item("TrxId")

            aCount = dbMethod.ExecuteScalar("CntTransactionImgAttachmentByTrxId", CommandType.StoredProcedure, prmCount)

            If aCount > 0 Then
                Dim prmRead(0) As SqlParameter
                prmRead(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmRead(0).Value = dtReport.Rows(i).Item("TrxId")

                dtTrxImgAttachment = dbMethod.FillDataTable("RdFacTransactionImgAttachmentByTrxId", CommandType.StoredProcedure, prmRead)

                For j As Integer = 0 To dtTrxImgAttachment.Rows.Count - 1
                    Dim bmp As New Bitmap(Path.Combine(imgDirectory, dtTrxImgAttachment.Rows(j).Item("Filename")))
                    bmps.Add(bmp)
                Next

                Dim ms As MemoryStream = New MemoryStream()
                MergeImages(bmps).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim imagedata As Byte() = ms.ToArray()

                conNewRow("Filename") = imagedata

                containerTable.Rows.Add(conNewRow)
            End If

            dtTrxImgAttachment.Clear()
            bmps.Clear()
        Next

        If dtReport.Rows.Count > 0 Then
            rptViewer.LocalReport.ReportPath = "ReportFile\FacActivityReport.rdlc"
            rptViewer.LocalReport.EnableExternalImages = True
            rptViewer.LocalReport.DataSources.Clear()
            rptViewer.LocalReport.DataSources.Add(New ReportDataSource("RptFacActivityReport2", containerTable))

            Dim rptParam As New ReportParameterCollection
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("StartDate", dtpStartDate.Value.Date.ToString("MMMM dd, yyyy")))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EndDate", dtpEndDate.Value.Date.ToString("MMMM dd, yyyy")))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("Shift", shift))
            rptViewer.LocalReport.SetParameters(rptParam)

            rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
            rptViewer.ZoomMode = ZoomMode.PageWidth
            rptViewer.LocalReport.DisplayName = "Activity Report"
            rptViewer.RefreshReport()
        Else
            MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BuildContainerTable(table As DataTable)
        Try
            Dim column As DataColumn

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "TrxId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = True
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.DateTime")
            column.ColumnName = "TrxDate"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "ShiftId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "AreaId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "AreaName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "MachineId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "MachineName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "DowntimeMachineSubStatusId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "MachineSubStatusName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.DateTime")
            column.ColumnName = "DatetimeStarted"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.DateTime")
            column.ColumnName = "DatetimeEnded"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "UserId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Byte[]")
            column.ColumnName = "Filename"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Duration"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "PicName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Problem"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "RootCause"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "ActionTaken"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "JoNumber"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "JoRequestor"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "TrxStatusId"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "TrxStatusName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SparePartName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SparePartNo"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function MergeImages(ByVal images As IEnumerable(Of Bitmap)) As Bitmap
        Dim enumerable = If(TryCast(images, IList(Of Bitmap)), images.ToList())
        Dim width = 0
        Dim height = 0

        'For Each image In enumerable
        '    width += image.Width
        '    height = If(image.Height > height, image.Height, height)
        'Next

        'Dim bitmap = New Bitmap(width, height)

        'Using g = Graphics.FromImage(bitmap)
        '    Dim localWidth = 0

        '    For Each image In enumerable
        '        Dim resImg As Image = dbMain.ResizeImage(image, New Size(width / enumerable.Count, image.Height))
        '        'g.DrawImage(image, localWidth, 0)
        '        g.DrawImage(resImg, localWidth, 0)
        '        'g.DrawImage(resImg, localWidth, 0, localWidth, height)
        '        'localWidth += image.Width
        '        localWidth += resImg.Width
        '        'localWidth += width / enumerable.Count
        '    Next
        'End Using

        For Each image In enumerable
            width += image.Width
            height = If(image.Height > height, image.Height, height)
        Next

        Dim bitmap = New Bitmap(width, height)

        Using g = Graphics.FromImage(bitmap)
            Dim localWidth = 0

            For Each image In enumerable
                g.DrawImage(image, localWidth, 0)
                localWidth += image.Width
            Next
        End Using

        Return bitmap
    End Function

    Private Function GetShift() As Object
        If Not rdBoth.Checked = True Then
            If rdDay.Checked = True Then
                Return "D"
            Else
                Return "N"
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Function GetArea() As Object
        If Not cmbArea.SelectedValue = 0 Then
            Return cmbArea.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetTransactionStatus() As Object
        If Not cmbTransactionStatus.SelectedValue = 0 Then
            Return cmbTransactionStatus.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetDowntimeMachineSubStatus() As Object
        If Not cmbMachineDowntimeSubStatus.SelectedValue = 0 Then
            Return cmbMachineDowntimeSubStatus.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetMachine() As Object
        If Not cmbMachine.SelectedValue = 0 Then
            Return cmbMachine.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetUserName() As Object
        If Not cmbUserName.SelectedValue = 0 Then
            Return cmbUserName.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Sub cmbUserName_Validated(sender As Object, e As EventArgs)
        Try
            If cmbUserName.SelectedValue = 0 Then cmbUserName.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbArea_Validated(sender As Object, e As EventArgs)
        Try
            If cmbArea.SelectedValue = 0 Then cmbArea.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachine_Validated(sender As Object, e As EventArgs)
        Try
            If cmbMachine.SelectedValue = 0 Then cmbMachine.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class