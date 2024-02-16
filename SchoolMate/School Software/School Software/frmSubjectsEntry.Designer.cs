namespace School_Software
{
    partial class frmSubjectsEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectsEntry));
            this.label3 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSession = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWeekly = new System.Windows.Forms.TextBox();
            this.txtSubjectType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSchoolType = new System.Windows.Forms.TextBox();
            this.txtSchool = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.schools = new System.Windows.Forms.TextBox();
            this.subjectcodesss = new System.Windows.Forms.TextBox();
            this.sessions = new System.Windows.Forms.TextBox();
            this.txtSessionID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnUpdate_record = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.txtSchoolID = new System.Windows.Forms.TextBox();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Indigo;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(649, 43);
            this.label3.TabIndex = 185;
            this.label3.Text = "Subjects Entry";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.lblUser);
            this.Panel4.Controls.Add(this.label11);
            this.Panel4.Controls.Add(this.lblUserType);
            this.Panel4.Controls.Add(this.txtTo);
            this.Panel4.Controls.Add(this.label10);
            this.Panel4.Controls.Add(this.txtTimeFrom);
            this.Panel4.Controls.Add(this.txtSession);
            this.Panel4.Controls.Add(this.label9);
            this.Panel4.Controls.Add(this.label8);
            this.Panel4.Controls.Add(this.txtWeekly);
            this.Panel4.Controls.Add(this.txtSubjectType);
            this.Panel4.Controls.Add(this.label7);
            this.Panel4.Controls.Add(this.label5);
            this.Panel4.Controls.Add(this.txtSchoolType);
            this.Panel4.Controls.Add(this.txtSchool);
            this.Panel4.Controls.Add(this.label4);
            this.Panel4.Controls.Add(this.Label6);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Controls.Add(this.txtSubjectName);
            this.Panel4.Controls.Add(this.txtSubjectCode);
            this.Panel4.Controls.Add(this.txtClass);
            this.Panel4.Controls.Add(this.label1);
            this.Panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel4.Location = new System.Drawing.Point(3, 47);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(501, 309);
            this.Panel4.TabIndex = 186;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUser.Location = new System.Drawing.Point(357, 134);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(31, 16);
            this.lblUser.TabIndex = 347;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(254, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Time To :";
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.Transparent;
            this.lblUserType.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserType.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUserType.Location = new System.Drawing.Point(357, 99);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(56, 16);
            this.lblUserType.TabIndex = 346;
            this.lblUserType.Text = "UserType";
            this.lblUserType.Visible = false;
            // 
            // txtTo
            // 
            this.txtTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.CustomFormat = "hh:mm tt";
            this.txtTo.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTo.Location = new System.Drawing.Point(323, 266);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(88, 24);
            this.txtTo.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Time From:";
            // 
            // txtTimeFrom
            // 
            this.txtTimeFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeFrom.CustomFormat = "hh:mm tt";
            this.txtTimeFrom.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTimeFrom.Location = new System.Drawing.Point(151, 264);
            this.txtTimeFrom.Name = "txtTimeFrom";
            this.txtTimeFrom.Size = new System.Drawing.Size(90, 24);
            this.txtTimeFrom.TabIndex = 8;
            // 
            // txtSession
            // 
            this.txtSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSession.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSession.FormattingEnabled = true;
            this.txtSession.Location = new System.Drawing.Point(150, 107);
            this.txtSession.Name = "txtSession";
            this.txtSession.Size = new System.Drawing.Size(141, 25);
            this.txtSession.TabIndex = 3;
            this.txtSession.SelectedIndexChanged += new System.EventHandler(this.txtSession_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Session/Batch ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Max.Weekly Classes ";
            // 
            // txtWeekly
            // 
            this.txtWeekly.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeekly.Location = new System.Drawing.Point(150, 233);
            this.txtWeekly.Name = "txtWeekly";
            this.txtWeekly.Size = new System.Drawing.Size(111, 24);
            this.txtWeekly.TabIndex = 7;
            this.txtWeekly.Text = "0";
            this.txtWeekly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubjectType
            // 
            this.txtSubjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSubjectType.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectType.FormattingEnabled = true;
            this.txtSubjectType.Items.AddRange(new object[] {
            "Major ",
            "Optional"});
            this.txtSubjectType.Location = new System.Drawing.Point(150, 201);
            this.txtSubjectType.Name = "txtSubjectType";
            this.txtSubjectType.Size = new System.Drawing.Size(141, 25);
            this.txtSubjectType.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Subject Type ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "School Type ";
            // 
            // txtSchoolType
            // 
            this.txtSchoolType.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchoolType.Location = new System.Drawing.Point(150, 44);
            this.txtSchoolType.Name = "txtSchoolType";
            this.txtSchoolType.ReadOnly = true;
            this.txtSchoolType.Size = new System.Drawing.Size(200, 24);
            this.txtSchoolType.TabIndex = 1;
            // 
            // txtSchool
            // 
            this.txtSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSchool.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchool.FormattingEnabled = true;
            this.txtSchool.Location = new System.Drawing.Point(150, 12);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(263, 25);
            this.txtSchool.TabIndex = 0;
            this.txtSchool.SelectedIndexChanged += new System.EventHandler(this.txtSchool_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "School Name";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(8, 170);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(86, 17);
            this.Label6.TabIndex = 22;
            this.Label6.Text = "Subject Name ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(8, 138);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(82, 17);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "Subject Code ";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectName.Location = new System.Drawing.Point(150, 170);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(302, 24);
            this.txtSubjectName.TabIndex = 5;
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectCode.Location = new System.Drawing.Point(150, 139);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(148, 24);
            this.txtSubjectCode.TabIndex = 4;
            // 
            // txtClass
            // 
            this.txtClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtClass.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.FormattingEnabled = true;
            this.txtClass.Location = new System.Drawing.Point(150, 75);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(141, 25);
            this.txtClass.TabIndex = 2;
            this.txtClass.SelectedIndexChanged += new System.EventHandler(this.txtClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class";
            // 
            // schools
            // 
            this.schools.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schools.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schools.Location = new System.Drawing.Point(529, 258);
            this.schools.Name = "schools";
            this.schools.Size = new System.Drawing.Size(111, 15);
            this.schools.TabIndex = 345;
            this.schools.Visible = false;
            // 
            // subjectcodesss
            // 
            this.subjectcodesss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subjectcodesss.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectcodesss.Location = new System.Drawing.Point(531, 258);
            this.subjectcodesss.Name = "subjectcodesss";
            this.subjectcodesss.Size = new System.Drawing.Size(111, 15);
            this.subjectcodesss.TabIndex = 344;
            this.subjectcodesss.Visible = false;
            // 
            // sessions
            // 
            this.sessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sessions.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessions.Location = new System.Drawing.Point(530, 258);
            this.sessions.Name = "sessions";
            this.sessions.Size = new System.Drawing.Size(111, 15);
            this.sessions.TabIndex = 343;
            this.sessions.Visible = false;
            // 
            // txtSessionID
            // 
            this.txtSessionID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSessionID.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSessionID.Location = new System.Drawing.Point(529, 258);
            this.txtSessionID.Name = "txtSessionID";
            this.txtSessionID.Size = new System.Drawing.Size(111, 15);
            this.txtSessionID.TabIndex = 342;
            this.txtSessionID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGetData);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.btnUpdate_record);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNewRecord);
            this.panel1.Location = new System.Drawing.Point(529, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 195);
            this.panel1.TabIndex = 339;
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.Crimson;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetData.Location = new System.Drawing.Point(10, 155);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 32);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "&Get Data";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(42, 219);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "label22";
            // 
            // btnUpdate_record
            // 
            this.btnUpdate_record.BackColor = System.Drawing.Color.Maroon;
            this.btnUpdate_record.Enabled = false;
            this.btnUpdate_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_record.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_record.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate_record.Location = new System.Drawing.Point(10, 118);
            this.btnUpdate_record.Name = "btnUpdate_record";
            this.btnUpdate_record.Size = new System.Drawing.Size(92, 32);
            this.btnUpdate_record.TabIndex = 3;
            this.btnUpdate_record.Text = "&Update";
            this.btnUpdate_record.UseVisualStyleBackColor = false;
            this.btnUpdate_record.Click += new System.EventHandler(this.btnUpdate_record_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Indigo;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(10, 81);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(10, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.BackColor = System.Drawing.Color.Indigo;
            this.btnNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRecord.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRecord.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewRecord.Location = new System.Drawing.Point(10, 7);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(92, 32);
            this.btnNewRecord.TabIndex = 0;
            this.btnNewRecord.Text = "&New";
            this.btnNewRecord.UseVisualStyleBackColor = false;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // txtSchoolID
            // 
            this.txtSchoolID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchoolID.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchoolID.Location = new System.Drawing.Point(529, 258);
            this.txtSchoolID.Name = "txtSchoolID";
            this.txtSchoolID.Size = new System.Drawing.Size(111, 15);
            this.txtSchoolID.TabIndex = 37;
            this.txtSchoolID.Visible = false;
            // 
            // txtClassID
            // 
            this.txtClassID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClassID.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassID.Location = new System.Drawing.Point(531, 258);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(111, 15);
            this.txtClassID.TabIndex = 340;
            this.txtClassID.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(530, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 15);
            this.textBox1.TabIndex = 341;
            this.textBox1.Visible = false;
            // 
            // frmSubjectsEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(647, 363);
            this.Controls.Add(this.sessions);
            this.Controls.Add(this.subjectcodesss);
            this.Controls.Add(this.schools);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtClassID);
            this.Controls.Add(this.txtSchoolID);
            this.Controls.Add(this.txtSessionID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubjectsEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subjects Entry";
            this.Load += new System.EventHandler(this.frmSubjectsEntry_Load);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtWeekly;
        internal System.Windows.Forms.ComboBox txtSubjectType;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtSchoolType;
        internal System.Windows.Forms.ComboBox txtSchool;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtSubjectName;
        internal System.Windows.Forms.TextBox txtSubjectCode;
        internal System.Windows.Forms.ComboBox txtClass;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox txtSession;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.DateTimePicker txtTo;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DateTimePicker txtTimeFrom;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnGetData;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Button btnUpdate_record;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNewRecord;
        internal System.Windows.Forms.TextBox txtSchoolID;
        internal System.Windows.Forms.TextBox txtClassID;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.TextBox txtSessionID;
        internal System.Windows.Forms.TextBox schools;
        internal System.Windows.Forms.TextBox subjectcodesss;
        internal System.Windows.Forms.TextBox sessions;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblUserType;
    }
}