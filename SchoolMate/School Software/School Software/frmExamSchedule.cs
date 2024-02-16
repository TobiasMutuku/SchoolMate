using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_Software
{
    public partial class frmExamSchedule : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        DataTable table = new DataTable();
        int indexRow;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmExamSchedule()
        {
            InitializeComponent();
        }
        public void FillExam()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(ExamName) FROM ExamMaster";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbExamName.Items.Clear();
                while (rdr.Read())
                {
                    cmbExamName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AutoSub()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName) FROM Subject INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID where Schoolname='" + cmbSchool.Text + "' and Classname='" + cmbClass.Text + "' and Session='" + cmbSession.Text + "'order by Subjectcode,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Examination Schedule' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblsave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblsave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName),Classid FROM ClassSection INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID order by classid";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbClass.Items.Clear();
                while (rdr.Read())
                {
                    cmbClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillSession()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM Sessions";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbSession.Items.Clear();
                while (rdr.Read())
                {
                    cmbSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct RTRIM(SchoolName) FROM School";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbSchool.Items.Clear();
                while (rdr.Read())
                {
                    cmbSchool.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmExamSchedule_Load(object sender, EventArgs e)
        {
            Reset();

        }

        private void cmbExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(ExamID) FROM  ExamMaster WHERE ExamName = '" + cmbExamName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtExamID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                txtSubjectID.Text = dr.Cells[0].Value.ToString();
                txtSubjectCode.Text = dr.Cells[1].Value.ToString();
                txtSubjectname.Text = dr.Cells[2].Value.ToString();
                btnAdd.Enabled = true;
                btnRefresh.Enabled = true;
                BtnUpdatelist.Enabled = false;
                btnRemovelist.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSubjectCode.Text))
            {
                MessageBox.Show("Please retrieve subject code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSubjectCode.Focus();
                return;
            }
            if ((txtStarttime.Value) >= (txtEndTime.Value))
            {
                MessageBox.Show("Start time can not be Greater than or Equal to End Time", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndTime.Focus();
                return;
            }
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (txtSubjectID.Text == row.Cells[0].Value.ToString())
                {
                    MessageBox.Show("Subject code already added", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DataGridView1.Rows.Add(txtSubjectID.Text, txtSubjectCode.Text, txtSubjectname.Text, txtExamDate.Value.Date, txtMaxMarks.Text, txtminMarks.Text, txtStarttime.Text, txtEndTime.Text);
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
        }
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT MAX(ScheduleID+1) FROM ExamSchedule";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtScheduleID.Text = Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtScheduleID.Text = Convert.ToString(Num);
                }
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void D1()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb1 = "insert into Scheduling(Schedule_ID,Subject_ID,ExamDate,MaxMarks,MinMarks,Starttime,Endtime) VALUES (" + txtScheduleID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6)";
            cmd = new SqlCommand(cb1);
            cmd.Connection = con;
            cmd.Prepare();
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@d2", row.Cells[3].Value);
                    cmd.Parameters.AddWithValue("@d3", Convert.ToDecimal(row.Cells[4].Value));
                    cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(row.Cells[5].Value));
                    cmd.Parameters.AddWithValue("@d5", row.Cells[6].Value);
                    cmd.Parameters.AddWithValue("@d6", row.Cells[7].Value);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add Exam Schedule in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT ExamSchedule.ExamID, ExamSchedule.School_ID, ExamSchedule.Session_ID, ExamSchedule.ClassSection_ID FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID where ExamID=@d1 and School_ID=@d2 and Session_ID=@d3 and ClassSection_ID=@d4";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d4", txtClassSectionID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Already Scheduled For This Batch", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into ExamSchedule(ScheduleID,ExamID, School_ID, Session_ID, ClassSection_ID) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtScheduleID.Text);
                cmd.Parameters.AddWithValue("@d2", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d5", txtClassSectionID.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                D1();
                st1 = lblUser.Text;
                st2 = "Exam is Schedule  having ExamName'" + cmbExamName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Scheduled", "Exam Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmExamScheduleList frm = new frmExamScheduleList(this);
            frm.lblSET.Text = "R3";
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add Exam Schedule in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtExamID.Text) != (examid.Text) || (txtSchoolID.Text) != (Schoolid.Text) || (txtSessionID.Text) != (sessionid.Text) || (txtClassSectionID.Text) != (classsectionid.Text))
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT ExamSchedule.ExamID, ExamSchedule.School_ID, ExamSchedule.Session_ID, ExamSchedule.ClassSection_ID FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID where ExamID=@d1 and School_ID=@d2 and Session_ID=@d3 and ClassSection_ID=@d4";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d4", txtClassSectionID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Already Scheduled For This Batch", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "update  ExamSchedule set ExamID=@d2, School_ID=@d3, Session_ID=@d4, ClassSection_ID=@d5 where ScheduleID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtScheduleID.Text);
                cmd.Parameters.AddWithValue("@d2", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d5", txtClassSectionID.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from scheduling where Schedule_ID='" + txtScheduleID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                D1();
                st1 = lblUser.Text;
                st2 = "Scheduled Exam is Updated having ExamName'" + cmbExamName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Exam Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txtScheduleID.Text = "";
            txtExamID.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtMaxMarks.Text = "";
            txtminMarks.Text = "";
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
            txtExamID.Text = "";
            txtScheduleID.Text = "";
            txtExamID.Text = "";
            txtScheduleID.Text = "";
            txtExamID.Text = "";
            DataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            cmbExamName.SelectedIndex = -1;
            cmbSchool.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            cmbSession.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSchool.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSessionID.Text = "";
            txtSchoolID.Text = "";
            txtClassSectionID.Text = "";
            FillExam();
            FillSchool();
            FillClass();
            FillSession();
            Crypto();
            func();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnRemovelist.Enabled = false;
            BtnUpdatelist.Enabled = false;
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from ExamSchedule where ScheduleID='" + txtScheduleID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Scheduled Exam is Deleted having ExamName'" + cmbExamName.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGridView1.Rows.Count > 0)
            {
                btnRemovelist.Enabled = true;
            }

            BtnUpdatelist.Enabled = true;
            btnRemovelist.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnRemovelist_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                DataGridView1.Rows.Remove(row);
            }
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
            btnRemovelist.Enabled = false;
        }

        private void BtnUpdatelist_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = DataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtSubjectID.Text;
            newDataRow.Cells[1].Value = txtSubjectCode.Text;
            newDataRow.Cells[2].Value = txtSubjectname.Text;
            newDataRow.Cells[3].Value = txtExamDate.Value.Date;
            newDataRow.Cells[4].Value = txtMaxMarks.Text;
            newDataRow.Cells[5].Value = txtminMarks.Text;
            newDataRow.Cells[6].Value = txtStarttime.Text;
            newDataRow.Cells[7].Value = txtEndTime.Text;
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow dr = DataGridView1.Rows[indexRow];
            txtSubjectID.Text = dr.Cells[0].Value.ToString();
            txtSubjectCode.Text = dr.Cells[1].Value.ToString();
            txtSubjectname.Text = dr.Cells[2].Value.ToString();
            txtExamDate.Text = dr.Cells[3].Value.ToString();
            txtMaxMarks.Text = dr.Cells[4].Value.ToString();
            txtminMarks.Text = dr.Cells[5].Value.ToString();
            txtStarttime.Text = dr.Cells[6].Value.ToString();
            txtEndTime.Text = dr.Cells[7].Value.ToString();
        }
        public void refresh()
        {
            txtMaxMarks.Text = "";
            txtminMarks.Text = "";
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtMaxMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtminMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
               cmd.CommandText = "SELECT distinct Rtrim(ClasssectionID) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + cmbClass.Text + "' and Section.SectionName = '" + cmbSection.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassSectionID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(School.SchoolID)FROM School INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID WHERE SchoolName = '" + cmbSchool.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSchoolID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AutoSub();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SessionID FROM Sessions WHERE Session = '" + cmbSession.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSessionID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AutoSub();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSection.Items.Clear();
                cmbSection.Text = "";
                cmbSection.Enabled = true;
                cmbSection.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT Rtrim(Section.SectionName) FROM ClassSection INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Classname=@d1";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbClass.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSection.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AutoSub();
        }
    }
}
