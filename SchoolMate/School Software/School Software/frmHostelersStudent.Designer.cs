﻿namespace School_Software
{
    partial class frmHostelersStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHostelersStudent));
            this.txtSession = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtHostelName = new System.Windows.Forms.ComboBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.btnUpdate_record = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtHostelID = new System.Windows.Forms.TextBox();
            this.txtJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAdmissionNo = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtHostelerID = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblGetdata = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lbldelete = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSession
            // 
            this.txtSession.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSession.Location = new System.Drawing.Point(129, 122);
            this.txtSession.Name = "txtSession";
            this.txtSession.ReadOnly = true;
            this.txtSession.Size = new System.Drawing.Size(85, 24);
            this.txtSession.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Indigo;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(648, 41);
            this.label3.TabIndex = 142;
            this.label3.Text = "Hosteler\'s Students";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(9, 42);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(7, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 114;
            this.label10.Text = "Session";
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.BackColor = System.Drawing.Color.Indigo;
            this.btnNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRecord.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRecord.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewRecord.Location = new System.Drawing.Point(9, 7);
            this.btnNewRecord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(92, 32);
            this.btnNewRecord.TabIndex = 0;
            this.btnNewRecord.Text = "&New";
            this.btnNewRecord.UseVisualStyleBackColor = false;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(7, 215);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(43, 17);
            this.Label9.TabIndex = 112;
            this.Label9.Text = "Hostel";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Indigo;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(9, 79);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtStatus.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.FormattingEnabled = true;
            this.txtStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.txtStatus.Location = new System.Drawing.Point(129, 278);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(127, 25);
            this.txtStatus.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(389, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(10, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = ".";
            // 
            // txtHostelName
            // 
            this.txtHostelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHostelName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostelName.FormattingEnabled = true;
            this.txtHostelName.Location = new System.Drawing.Point(129, 215);
            this.txtHostelName.Name = "txtHostelName";
            this.txtHostelName.Size = new System.Drawing.Size(247, 25);
            this.txtHostelName.TabIndex = 6;
            this.txtHostelName.SelectedIndexChanged += new System.EventHandler(this.txtHostelName_SelectedIndexChanged);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(7, 277);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(44, 17);
            this.Label19.TabIndex = 110;
            this.Label19.Text = "Status ";
            // 
            // btnUpdate_record
            // 
            this.btnUpdate_record.BackColor = System.Drawing.Color.Maroon;
            this.btnUpdate_record.Enabled = false;
            this.btnUpdate_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_record.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_record.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate_record.Location = new System.Drawing.Point(9, 119);
            this.btnUpdate_record.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate_record.Name = "btnUpdate_record";
            this.btnUpdate_record.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate_record.Size = new System.Drawing.Size(92, 32);
            this.btnUpdate_record.TabIndex = 3;
            this.btnUpdate_record.Text = "&Update";
            this.btnUpdate_record.UseVisualStyleBackColor = false;
            this.btnUpdate_record.Click += new System.EventHandler(this.btnUpdate_record_Click);
            // 
            // Button2
            // 
            this.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.Black;
            this.Button2.Location = new System.Drawing.Point(286, 28);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(35, 23);
            this.Button2.TabIndex = 9;
            this.Button2.Text = "...";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Button2.MouseHover += new System.EventHandler(this.Button2_MouseHover);
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchoolName.Location = new System.Drawing.Point(129, 91);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.ReadOnly = true;
            this.txtSchoolName.Size = new System.Drawing.Size(248, 24);
            this.txtSchoolName.TabIndex = 2;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(7, 91);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(83, 17);
            this.Label8.TabIndex = 17;
            this.Label8.Text = "School Name ";
            // 
            // txtHostelID
            // 
            this.txtHostelID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHostelID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHostelID.Location = new System.Drawing.Point(495, 278);
            this.txtHostelID.Name = "txtHostelID";
            this.txtHostelID.Size = new System.Drawing.Size(113, 13);
            this.txtHostelID.TabIndex = 145;
            this.txtHostelID.Visible = false;
            // 
            // txtJoiningDate
            // 
            this.txtJoiningDate.CustomFormat = "dd/MM/yyyy";
            this.txtJoiningDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtJoiningDate.Location = new System.Drawing.Point(129, 247);
            this.txtJoiningDate.Name = "txtJoiningDate";
            this.txtJoiningDate.Size = new System.Drawing.Size(96, 24);
            this.txtJoiningDate.TabIndex = 7;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(7, 246);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 17);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "Joining Date ";
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.Crimson;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetData.Location = new System.Drawing.Point(9, 159);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGetData.Size = new System.Drawing.Size(92, 32);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtClass
            // 
            this.txtClass.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(129, 153);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(85, 24);
            this.txtClass.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGetData);
            this.panel1.Controls.Add(this.btnUpdate_record);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNewRecord);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(494, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 205);
            this.panel1.TabIndex = 144;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(7, 153);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 17);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Class ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtSession);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Label9);
            this.groupBox1.Controls.Add(this.txtHostelName);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.Label19);
            this.groupBox1.Controls.Add(this.Button2);
            this.groupBox1.Controls.Add(this.txtSchoolName);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Controls.Add(this.txtJoiningDate);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.txtClass);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.txtAdmissionNo);
            this.groupBox1.Controls.Add(this.txtStudentName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSection);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(5, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 324);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hostelers Info";
            // 
            // txtAdmissionNo
            // 
            this.txtAdmissionNo.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdmissionNo.Location = new System.Drawing.Point(129, 29);
            this.txtAdmissionNo.Name = "txtAdmissionNo";
            this.txtAdmissionNo.ReadOnly = true;
            this.txtAdmissionNo.Size = new System.Drawing.Size(142, 24);
            this.txtAdmissionNo.TabIndex = 0;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(129, 60);
            this.txtStudentName.Multiline = true;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(247, 24);
            this.txtStudentName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Admission No. ";
            // 
            // txtSection
            // 
            this.txtSection.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(129, 184);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(85, 24);
            this.txtSection.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(7, 184);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(50, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Section ";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(7, 60);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(89, 17);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Student Name ";
            // 
            // txtHostelerID
            // 
            this.txtHostelerID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHostelerID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHostelerID.Location = new System.Drawing.Point(495, 278);
            this.txtHostelerID.Name = "txtHostelerID";
            this.txtHostelerID.Size = new System.Drawing.Size(113, 13);
            this.txtHostelerID.TabIndex = 147;
            this.txtHostelerID.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Location = new System.Drawing.Point(502, 278);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 349;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.Transparent;
            this.lblUserType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUserType.Location = new System.Drawing.Point(502, 281);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 13);
            this.lblUserType.TabIndex = 348;
            this.lblUserType.Text = "UserType";
            this.lblUserType.Visible = false;
            // 
            // lblGetdata
            // 
            this.lblGetdata.AutoSize = true;
            this.lblGetdata.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGetdata.Location = new System.Drawing.Point(492, 281);
            this.lblGetdata.Name = "lblGetdata";
            this.lblGetdata.Size = new System.Drawing.Size(55, 13);
            this.lblGetdata.TabIndex = 351;
            this.lblGetdata.Text = "lblGetdata";
            this.lblGetdata.Visible = false;
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSave.Location = new System.Drawing.Point(492, 281);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(55, 13);
            this.lblSave.TabIndex = 350;
            this.lblSave.Text = "lblupdates";
            this.lblSave.Visible = false;
            // 
            // lbldelete
            // 
            this.lbldelete.AutoSize = true;
            this.lbldelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbldelete.Location = new System.Drawing.Point(503, 299);
            this.lbldelete.Name = "lbldelete";
            this.lbldelete.Size = new System.Drawing.Size(30, 13);
            this.lbldelete.TabIndex = 352;
            this.lbldelete.Text = "save";
            this.lbldelete.Visible = false;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 5000;
            this.ToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToolTip1.InitialDelay = 500;
            this.ToolTip1.OwnerDraw = true;
            this.ToolTip1.ReshowDelay = 50;
            // 
            // frmHostelersStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(648, 376);
            this.Controls.Add(this.lbldelete);
            this.Controls.Add(this.lblGetdata);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHostelID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtHostelerID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHostelersStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hostelers Student";
            this.Load += new System.EventHandler(this.frmHostelersStudent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtSession;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnNewRecord;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.ComboBox txtStatus;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.ComboBox txtHostelName;
        public System.Windows.Forms.Label Label19;
        public System.Windows.Forms.Button btnUpdate_record;
        public System.Windows.Forms.Button Button2;
        public System.Windows.Forms.TextBox txtSchoolName;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.TextBox txtHostelID;
        public System.Windows.Forms.DateTimePicker txtJoiningDate;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Button btnGetData;
        public System.Windows.Forms.TextBox txtClass;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtAdmissionNo;
        public System.Windows.Forms.TextBox txtStudentName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSection;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.TextBox txtHostelerID;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblUserType;
        public System.Windows.Forms.Label lblGetdata;
        public System.Windows.Forms.Label lblSave;
        public System.Windows.Forms.Label lbldelete;
        internal System.Windows.Forms.ToolTip ToolTip1;
    }
}