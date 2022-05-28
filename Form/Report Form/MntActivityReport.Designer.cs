using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MachineMonitoringSystem
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class MntActivityReport : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            cmbUserName = new SergeUtils.EasyCompletionComboBox();
            cmbArea = new SergeUtils.EasyCompletionComboBox();
            cmbJigDowntimeStatus = new ComboBox();
            lblJigDowntimeStatus = new Label();
            lblJig = new Label();
            cmbJig = new SergeUtils.EasyCompletionComboBox();
            lblMachine = new Label();
            cmbMachine = new SergeUtils.EasyCompletionComboBox();
            btnReset = new PinkieControls.ButtonXP();
            btnReset.Click += new EventHandler(btnReset_Click);
            btnClose = new PinkieControls.ButtonXP();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnGenerate = new PinkieControls.ButtonXP();
            btnGenerate.Click += new EventHandler(btnGenerate_Click);
            lblTransactionStatus = new Label();
            cmbTransactionStatus = new ComboBox();
            lblArea = new Label();
            cmbMachineDowntimeStatus = new ComboBox();
            lblMachineDowntimeStatus = new Label();
            lblShift = new Label();
            lblUserName = new Label();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            grpShift = new GroupBox();
            rdBoth = new RadioButton();
            rdDay = new RadioButton();
            rdNight = new RadioButton();
            rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            pnlLeft.SuspendLayout();
            grpShift.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(cmbUserName);
            pnlLeft.Controls.Add(cmbArea);
            pnlLeft.Controls.Add(cmbJigDowntimeStatus);
            pnlLeft.Controls.Add(lblJigDowntimeStatus);
            pnlLeft.Controls.Add(lblJig);
            pnlLeft.Controls.Add(cmbJig);
            pnlLeft.Controls.Add(lblMachine);
            pnlLeft.Controls.Add(cmbMachine);
            pnlLeft.Controls.Add(btnReset);
            pnlLeft.Controls.Add(btnClose);
            pnlLeft.Controls.Add(btnGenerate);
            pnlLeft.Controls.Add(lblTransactionStatus);
            pnlLeft.Controls.Add(cmbTransactionStatus);
            pnlLeft.Controls.Add(lblArea);
            pnlLeft.Controls.Add(cmbMachineDowntimeStatus);
            pnlLeft.Controls.Add(lblMachineDowntimeStatus);
            pnlLeft.Controls.Add(lblShift);
            pnlLeft.Controls.Add(lblUserName);
            pnlLeft.Controls.Add(lblEndDate);
            pnlLeft.Controls.Add(dtpEndDate);
            pnlLeft.Controls.Add(lblStartDate);
            pnlLeft.Controls.Add(dtpStartDate);
            pnlLeft.Controls.Add(grpShift);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(210, 586);
            pnlLeft.TabIndex = 0;
            // 
            // cmbUserName
            // 
            cmbUserName.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUserName.FormattingEnabled = true;
            cmbUserName.Location = new Point(7, 110);
            cmbUserName.Name = "cmbUserName";
            cmbUserName.Size = new Size(196, 23);
            cmbUserName.TabIndex = 2;
            // 
            // cmbArea
            // 
            cmbArea.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(7, 203);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(196, 23);
            cmbArea.TabIndex = 4;
            // 
            // cmbJigDowntimeStatus
            // 
            cmbJigDowntimeStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJigDowntimeStatus.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbJigDowntimeStatus.FormattingEnabled = true;
            cmbJigDowntimeStatus.Location = new Point(7, 379);
            cmbJigDowntimeStatus.Name = "cmbJigDowntimeStatus";
            cmbJigDowntimeStatus.Size = new Size(196, 23);
            cmbJigDowntimeStatus.TabIndex = 8;
            // 
            // lblJigDowntimeStatus
            // 
            lblJigDowntimeStatus.AutoSize = true;
            lblJigDowntimeStatus.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJigDowntimeStatus.Location = new Point(4, 362);
            lblJigDowntimeStatus.Name = "lblJigDowntimeStatus";
            lblJigDowntimeStatus.Size = new Size(114, 15);
            lblJigDowntimeStatus.TabIndex = 161;
            lblJigDowntimeStatus.Text = "Jig Downtime Status";
            // 
            // lblJig
            // 
            lblJig.AutoSize = true;
            lblJig.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJig.Location = new Point(4, 406);
            lblJig.Name = "lblJig";
            lblJig.Size = new Size(56, 15);
            lblJig.TabIndex = 159;
            lblJig.Text = "Jig Name";
            // 
            // cmbJig
            // 
            cmbJig.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbJig.FormattingEnabled = true;
            cmbJig.Location = new Point(7, 424);
            cmbJig.Name = "cmbJig";
            cmbJig.Size = new Size(196, 23);
            cmbJig.TabIndex = 9;
            // 
            // lblMachine
            // 
            lblMachine.AutoSize = true;
            lblMachine.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMachine.Location = new Point(4, 318);
            lblMachine.Name = "lblMachine";
            lblMachine.Size = new Size(88, 15);
            lblMachine.TabIndex = 157;
            lblMachine.Text = "Machine Name";
            // 
            // cmbMachine
            // 
            cmbMachine.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMachine.FormattingEnabled = true;
            cmbMachine.Location = new Point(7, 335);
            cmbMachine.Name = "cmbMachine";
            cmbMachine.Size = new Size(196, 23);
            cmbMachine.TabIndex = 7;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.BackColor = Color.FromArgb(0, 240, 240, 240);
            btnReset.DefaultScheme = false;
            btnReset.DialogResult = DialogResult.None;
            btnReset.Font = new Font("Verdana", 8.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.Hint = "";
            btnReset.Location = new Point(11, 504);
            btnReset.Name = "btnReset";
            btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            btnReset.Size = new Size(187, 35);
            btnReset.TabIndex = 155;
            btnReset.TabStop = false;
            btnReset.Text = "Reset";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(0, 240, 240, 240);
            btnClose.DefaultScheme = false;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Verdana", 8.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Hint = "";
            btnClose.Location = new Point(11, 545);
            btnClose.Name = "btnClose";
            btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            btnClose.Size = new Size(187, 35);
            btnClose.TabIndex = 154;
            btnClose.TabStop = false;
            btnClose.Text = "Close";
            // 
            // btnGenerate
            // 
            btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerate.BackColor = Color.FromArgb(0, 240, 240, 240);
            btnGenerate.DefaultScheme = false;
            btnGenerate.DialogResult = DialogResult.None;
            btnGenerate.Font = new Font("Verdana", 8.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerate.Hint = "";
            btnGenerate.Location = new Point(11, 463);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            btnGenerate.Size = new Size(187, 35);
            btnGenerate.TabIndex = 153;
            btnGenerate.TabStop = false;
            btnGenerate.Text = "Generate";
            // 
            // lblTransactionStatus
            // 
            lblTransactionStatus.AutoSize = true;
            lblTransactionStatus.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTransactionStatus.Location = new Point(4, 230);
            lblTransactionStatus.Name = "lblTransactionStatus";
            lblTransactionStatus.Size = new Size(102, 15);
            lblTransactionStatus.TabIndex = 33;
            lblTransactionStatus.Text = "Transaction Status";
            // 
            // cmbTransactionStatus
            // 
            cmbTransactionStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransactionStatus.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTransactionStatus.FormattingEnabled = true;
            cmbTransactionStatus.Location = new Point(7, 247);
            cmbTransactionStatus.Name = "cmbTransactionStatus";
            cmbTransactionStatus.Size = new Size(196, 23);
            cmbTransactionStatus.TabIndex = 5;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArea.Location = new Point(8, 186);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(31, 15);
            lblArea.TabIndex = 32;
            lblArea.Text = "Area";
            // 
            // cmbMachineDowntimeStatus
            // 
            cmbMachineDowntimeStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMachineDowntimeStatus.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMachineDowntimeStatus.FormattingEnabled = true;
            cmbMachineDowntimeStatus.Location = new Point(7, 291);
            cmbMachineDowntimeStatus.Name = "cmbMachineDowntimeStatus";
            cmbMachineDowntimeStatus.Size = new Size(196, 23);
            cmbMachineDowntimeStatus.TabIndex = 6;
            // 
            // lblMachineDowntimeStatus
            // 
            lblMachineDowntimeStatus.AutoSize = true;
            lblMachineDowntimeStatus.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMachineDowntimeStatus.Location = new Point(4, 274);
            lblMachineDowntimeStatus.Name = "lblMachineDowntimeStatus";
            lblMachineDowntimeStatus.Size = new Size(146, 15);
            lblMachineDowntimeStatus.TabIndex = 31;
            lblMachineDowntimeStatus.Text = "Machine Downtime Status";
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShift.Location = new Point(4, 137);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(31, 15);
            lblShift.TabIndex = 29;
            lblShift.Text = "Shift";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(4, 93);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(63, 15);
            lblUserName.TabIndex = 26;
            lblUserName.Text = "Technician";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEndDate.Location = new Point(4, 49);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 15);
            lblEndDate.TabIndex = 24;
            lblEndDate.Text = "End Date";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "  MMMM dd, yyyy";
            dtpEndDate.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(7, 66);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(196, 23);
            dtpEndDate.TabIndex = 1;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStartDate.Location = new Point(4, 5);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(58, 15);
            lblStartDate.TabIndex = 21;
            lblStartDate.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "  MMMM dd, yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(7, 22);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(196, 23);
            dtpStartDate.TabIndex = 0;
            // 
            // grpShift
            // 
            grpShift.Controls.Add(rdBoth);
            grpShift.Controls.Add(rdDay);
            grpShift.Controls.Add(rdNight);
            grpShift.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpShift.Location = new Point(7, 147);
            grpShift.Name = "grpShift";
            grpShift.Size = new Size(196, 36);
            grpShift.TabIndex = 3;
            grpShift.TabStop = false;
            grpShift.UseCompatibleTextRendering = true;
            // 
            // rdBoth
            // 
            rdBoth.AutoSize = true;
            rdBoth.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdBoth.Location = new Point(6, 12);
            rdBoth.Name = "rdBoth";
            rdBoth.Size = new Size(50, 19);
            rdBoth.TabIndex = 0;
            rdBoth.TabStop = true;
            rdBoth.Text = "Both";
            rdBoth.UseVisualStyleBackColor = true;
            // 
            // rdDay
            // 
            rdDay.AutoSize = true;
            rdDay.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdDay.Location = new Point(66, 12);
            rdDay.Name = "rdDay";
            rdDay.Size = new Size(45, 19);
            rdDay.TabIndex = 1;
            rdDay.TabStop = true;
            rdDay.Text = "Day";
            rdDay.UseVisualStyleBackColor = true;
            // 
            // rdNight
            // 
            rdNight.AutoSize = true;
            rdNight.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdNight.Location = new Point(125, 12);
            rdNight.Name = "rdNight";
            rdNight.Size = new Size(55, 19);
            rdNight.TabIndex = 2;
            rdNight.TabStop = true;
            rdNight.Text = "Night";
            rdNight.UseVisualStyleBackColor = true;
            // 
            // rptViewer
            // 
            rptViewer.Dock = DockStyle.Fill;
            rptViewer.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            rptViewer.Location = new Point(210, 0);
            rptViewer.Name = "rptViewer";
            rptViewer.Size = new Size(1094, 586);
            rptViewer.TabIndex = 156;
            rptViewer.TabStop = false;
            // 
            // MntActivityReport
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            CancelButton = btnClose;
            CausesValidation = false;
            ClientSize = new Size(1304, 586);
            Controls.Add(rptViewer);
            Controls.Add(pnlLeft);
            DoubleBuffered = true;
            Font = new Font("Verdana", 8.0f);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Name = "MntActivityReport";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activity Report";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            grpShift.ResumeLayout(false);
            grpShift.PerformLayout();
            Load += new EventHandler(frmMntActivityReport_Load);
            KeyDown += new KeyEventHandler(frmMntActivityReport_KeyDown);
            ResumeLayout(false);

        }
        internal Panel pnlLeft;
        internal Label lblTransactionStatus;
        internal ComboBox cmbTransactionStatus;
        internal Label lblArea;
        internal ComboBox cmbMachineDowntimeStatus;
        internal Label lblMachineDowntimeStatus;
        internal Label lblShift;
        internal Label lblUserName;
        internal Label lblEndDate;
        internal DateTimePicker dtpEndDate;
        internal Label lblStartDate;
        internal DateTimePicker dtpStartDate;
        internal GroupBox grpShift;
        internal RadioButton rdBoth;
        internal RadioButton rdDay;
        internal RadioButton rdNight;
        internal PinkieControls.ButtonXP btnReset;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnGenerate;
        internal Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        internal Label lblMachine;
        internal SergeUtils.EasyCompletionComboBox cmbMachine;
        internal Label lblJig;
        internal SergeUtils.EasyCompletionComboBox cmbJig;
        internal ComboBox cmbJigDowntimeStatus;
        internal Label lblJigDowntimeStatus;
        internal SergeUtils.EasyCompletionComboBox cmbArea;
        internal SergeUtils.EasyCompletionComboBox cmbUserName;
    }
}