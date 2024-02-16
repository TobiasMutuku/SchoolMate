using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmExamScheduleList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmExamSchedule frm = null;
        frmExamResultsEntry frm1 = null;
        public frmExamScheduleList()
        {
            InitializeComponent();
        }
        public frmExamScheduleList(frmExamSchedule par)
        {
            frm = par;
            InitializeComponent();
        }
        public frmExamScheduleList(frmExamResultsEntry par1)
        {
            frm1 = par1;
            InitializeComponent();
        }
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT  distinct Rtrim(School.SchoolName) FROM ExamSchedule INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSchoolSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT ExamSchedule.ScheduleID, ExamSchedule.ExamID, ExamMaster.ExamName, ExamSchedule.School_ID, School.SchoolName, ExamSchedule.Session_ID, Sessions.Session, ExamSchedule.ClassSection_ID,Class.ClassName, Section.SectionName FROM ExamSchedule INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmExamScheduleList_Load(object sender, EventArgs e)
        {
            Auto();
            FillSchool();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void cmbSchoolSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBatchSearch.Items.Clear();
                cmbBatchSearch.Text = "";
                cmbBatchSearch.Enabled = true;
                cmbBatchSearch.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT Sessions.Session FROM ExamSchedule INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where schoolname='" + cmbSchoolSearch.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBatchSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBatchSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbClassSearch.Items.Clear();
                CmbClassSearch.Text = "";
                CmbClassSearch.Enabled = true;
                CmbClassSearch.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM ExamSchedule INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where schoolname=@d1 and Session=@d2";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CmbClassSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchoolSearch.Text == "")
                {
                    MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolSearch.Focus();
                    return;
                }
                if (cmbBatchSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Batch", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBatchSearch.Focus();
                    return;
                }
                if (CmbClassSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbClassSearch.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(ExamSchedule.ScheduleID),Rtrim(ExamSchedule.ExamID),Rtrim(ExamMaster.ExamName),Rtrim(ExamSchedule.School_ID),Rtrim(School.SchoolName),Rtrim(ExamSchedule.Session_ID),Rtrim(Sessions.Session),Rtrim(ExamSchedule.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName) FROM ExamSchedule INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID Where School.SchoolName=@d1 and Session=@d2 and ClassName=@d3 and SectionName=@d4", con);
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                cmd.Parameters.AddWithValue("@d3", CmbClassSearch.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSection.Text);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtExamName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(ExamSchedule.ScheduleID),Rtrim(ExamSchedule.ExamID),Rtrim(ExamMaster.ExamName),Rtrim(ExamSchedule.School_ID),Rtrim(School.SchoolName),Rtrim(ExamSchedule.Session_ID),Rtrim(Sessions.Session),Rtrim(ExamSchedule.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName) FROM ExamSchedule INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID Where ExamName like'%" + txtExamName.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R3")
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frm.Activate();
                frm.BringToFront();
                frm.txtScheduleID.Text = dr.Cells[0].Value.ToString();
                frm.txtExamID.Text = dr.Cells[1].Value.ToString();
                frm.examid.Text = dr.Cells[1].Value.ToString();
                frm.cmbExamName.Text = dr.Cells[2].Value.ToString();
                frm.txtSchoolID.Text = dr.Cells[3].Value.ToString();
                frm.Schoolid.Text = dr.Cells[3].Value.ToString();
                frm.cmbSchool.DropDownStyle = ComboBoxStyle.DropDown;
                frm.cmbSchool.Text = dr.Cells[4].Value.ToString();
                frm.txtSessionID.Text = dr.Cells[5].Value.ToString();
                frm.cmbSession.DropDownStyle = ComboBoxStyle.DropDown;
                frm.sessionid.Text = dr.Cells[5].Value.ToString();
                frm.cmbSession.Text = dr.Cells[6].Value.ToString();
                frm.classsectionid.Text = dr.Cells[7].Value.ToString();
                frm.txtClassSectionID.Text = dr.Cells[7].Value.ToString();
                frm.cmbClass.DropDownStyle = ComboBoxStyle.DropDown;
                frm.cmbClass.Text = dr.Cells[8].Value.ToString();
                frm.cmbSection.DropDownStyle = ComboBoxStyle.DropDown;
                frm.cmbSection.Text = dr.Cells[9].Value.ToString();
                frm.cmbExamName.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Scheduling.Subject_ID, Subject.SubjectCode, Subject.SubjectName, Scheduling.ExamDate, Scheduling.MaxMarks, Scheduling.MinMarks, Scheduling.StartTime,Scheduling.EndTime FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN Subject ON Subject.SubjectID = Scheduling.Subject_ID and Scheduling.Schedule_ID=" + dr.Cells[0].Value + "", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                frm.DataGridView1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    frm.DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
                }
                con.Close();
                frm.refresh();
                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Examination Schedule' and Users.UserID='" + lblUser.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblupdate.Text = rdr[0].ToString().Trim();
                    lbldelete.Text = rdr[1].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (lblupdate.Text == "True")
                    frm.btnUpdate.Enabled = true;
                else
                    frm.btnUpdate.Enabled = false;


                if (lbldelete.Text == "True")
                    frm.btnDelete.Enabled = true;
                else
                    frm.btnDelete.Enabled = false;
                frm.btnSave.Enabled = false;

            }
            else if (lblSET.Text == "Result")
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frm1.Activate();
                    frm1.BringToFront();
                    frm1.txtExamScheduleID.Text = dr.Cells[0].Value.ToString();
                   frm1.txtExamName.Text = dr.Cells[2].Value.ToString();
                    frm1.txtSchool.Text = dr.Cells[4].Value.ToString();
                    frm1.txtSession.Text = dr.Cells[6].Value.ToString();
                    frm1.txtclass.Text = dr.Cells[8].Value.ToString();
                    frm1.txtSection.Text = dr.Cells[9].Value.ToString();

                }
            }
        public void Reset()
        {
           
            txtExamName.Text = "";
            CmbClassSearch.SelectedIndex = -1;
            cmbBatchSearch.SelectedIndex = -1;
            cmbSchoolSearch.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;
            CmbClassSearch.Enabled = false;
            cmbBatchSearch.Enabled = false;
            cmbSection.Enabled = false;
            dataGridView1.Rows.Clear();
            Auto();
            
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void CmbClassSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSection.Items.Clear();
                cmbSection.Text = "";
                cmbSection.Enabled = true;
                cmbSection.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct rtrim(Section.SectionName) FROM ExamSchedule INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where schoolname=@d1 and Session=@d2 and ClassName=@d3";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                cmd.Parameters.AddWithValue("@d3", CmbClassSearch.Text);
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
        }

    }
}

