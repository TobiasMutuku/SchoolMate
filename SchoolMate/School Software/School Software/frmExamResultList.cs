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
    public partial class frmExamResultList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        frmExamResultsEntry frm = null;
       
        public frmExamResultList()
        {
            InitializeComponent();
        }
        public frmExamResultList(frmExamResultsEntry par)
        {
            frm = par;
            InitializeComponent();
        }
        private void frmStudentResultList_Load(object sender, EventArgs e)
        {
            Auto();
            Auto1();
            FillSchool();
        }
        public void FillExam()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(ExamMaster.ExamName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID and SchoolName=@d1 and Session=@d2 and classname=@d3 and Sectionname=@d4 ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSection.Text);
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
        public void FillExam1()
        {
            try
            {
                
                txtexam.Items.Clear();
                txtexam.Text = "";
                txtexam.Enabled = true;
                txtexam.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(ExamMaster.ExamName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID and SchoolName=@d1 and Session=@d2 and classname=@d3 and Sectionname=@d4 ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtschool.Text);
                cmd.Parameters.AddWithValue("@d2", txtsession.Text);
                cmd.Parameters.AddWithValue("@d3", txtclass.Text);
                cmd.Parameters.AddWithValue("@d4", txtsection.Text);
                rdr = cmd.ExecuteReader();
                txtexam.Items.Clear();
                while (rdr.Read())
                {
                    txtexam.Items.Add(rdr[0]);
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
                string ct1 = "SELECT distinct Rtrim(School.SchoolName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbSchool.Items.Clear();
                while (rdr.Read())
                {
                    cmbSchool.Items.Add(rdr[0]);
                    txtschool.Items.Add(rdr[0]);
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
                cmd = new SqlCommand("SELECT distinct Rtrim(Result.ResultID),Rtrim(Result.ScheduleID),Rtrim(ExamMaster.ExamName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Sessions.Session),Rtrim(Result.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Scheduling.ExamDate,Rtrim(Scheduling.MaxMarks),Rtrim(Scheduling.MinMarks) FROM Result INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN  ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID order by 1,3,4,5,6", con);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Auto1()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Result.ResultID),Rtrim(ExamMaster.ExamName),Rtrim(School.SchoolName),Rtrim(Sessions.Session),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Resulting.AdmissionNo),Rtrim(Student.EnrollmentNo),Rtrim(Student.StudentName),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Scheduling.ExamDate,Rtrim(Scheduling.MaxMarks),Rtrim(Scheduling.MinMarks),Rtrim(Resulting.Marks),Resulting.Absent FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN Student ON Student.AdmissionNo = Resulting.AdmissionNo INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID GROUP BY Result.ResultID, ExamMaster.ExamName, School.SchoolName, Sessions.Session, Class.ClassName, Section.SectionName, Resulting.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Subject.SubjectCode, Subject.SubjectName, Scheduling.ExamDate, Scheduling.MaxMarks, Scheduling.MinMarks, Resulting.Marks, Resulting.Absent ORDER BY Resulting.AdmissionNo, School.SchoolName, Class.ClassName, Sessions.Session, Section.SectionName, Subject.SubjectCode ", con);
                rdr = cmd.ExecuteReader();
                dgw.Rows.Clear();
                while (rdr.Read())
                {
                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchList_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchool.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSection.Text == "")
                {
                    MessageBox.Show("Please select Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSection.Focus();
                    return;
                }
                if (cmbExamName.Text == "")
                {
                    MessageBox.Show("Please select Exam", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbExamName.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT distinct Rtrim(Result.ResultID),Rtrim(Result.ScheduleID),Rtrim(ExamMaster.ExamName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Sessions.Session),Rtrim(Result.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Scheduling.ExamDate,Rtrim(Scheduling.MaxMarks),Rtrim(Scheduling.MinMarks) FROM Result INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN  ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID where Session=@d1 and SchoolName=@d2 and ClassName=@d3 and ExamName=@d4 order by 1,3,4,5,6", con);
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d4", cmbExamName.Text);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbExamName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSession.Items.Clear();
                cmbSession.Text = "";
                cmbSession.Enabled = true;
                cmbSession.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Sessions.Session) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID where schoolname='" + cmbSchool.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
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
            FillExam();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbClass.Items.Clear();
                cmbClass.Text = "";
                cmbClass.Enabled = true;
                cmbClass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Class.ClassName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Session=@d1 and SchoolName=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSchool.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClass.Items.Add(rdr[0]);
                    txtclass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillExam();
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
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Session=@d1 and SchoolName=@d2 and ClassName=@d3 ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
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
            FillExam();
        }

        private void cmbExamName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                btnSubject.Enabled = true;
                CmbSubjectName.Items.Clear();
                CmbSubjectName.Text = "";
                CmbSubjectName.Enabled = true;
                CmbSubjectName.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Subject.SubjectName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID where Session=@d1 and SchoolName=@d2 and ClassName=@d3 and ExamName=@d4";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d4", cmbExamName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CmbSubjectName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R3")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm.Activate();
                frm.BringToFront();
                frm.txtResultID.Text = dr.Cells[0].Value.ToString();
                frm.txtExamScheduleID.Text = dr.Cells[1].Value.ToString();
                frm.txtExamScheduleid1.Text = dr.Cells[1].Value.ToString();
                frm.txtExamName.Text = dr.Cells[2].Value.ToString();
                frm.txtSchool.Text = dr.Cells[3].Value.ToString();
                frm.txtSession.Text = dr.Cells[4].Value.ToString();
                frm.txtclass.Text = dr.Cells[5].Value.ToString();
                frm.txtSection.Text = dr.Cells[6].Value.ToString();
                frm.txtSubjectID.Text = dr.Cells[7].Value.ToString();
                frm.txtSubjectid1.Text = dr.Cells[7].Value.ToString();
                frm.txtSubjectCode.Text = dr.Cells[8].Value.ToString();
                frm.cmbSubjectName.DropDownStyle = ComboBoxStyle.DropDown;
                frm.cmbSubjectName.Text = dr.Cells[9].Value.ToString();

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Resulting.AdmissionNo),Rtrim(Student.EnrollmentNo),Rtrim(Student.StudentName),Rtrim(Resulting.Marks),Resulting.Absent FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN Student ON Student.AdmissionNo = Resulting.AdmissionNo and Resulting.Result_ID=" + dr.Cells[0].Value + "", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                frm.DataGridView1.Rows.Clear();
              while (rdr.Read())
              {
               frm.DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
              }
                con.Close();
                frm.btnGetstudent.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.btnDelete.Enabled = true;
                }

            }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillExam();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchool.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSection.Text == "")
                {
                    MessageBox.Show("Please select Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSection.Focus();
                    return;
                }
                if (cmbExamName.Text == "")
                {
                    MessageBox.Show("Please select Exam", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbExamName.Focus();
                    return;
                }
                if (CmbSubjectName.Text == "")
                {
                    MessageBox.Show("Please select Subject", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbSubjectName.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT distinct Rtrim(Result.ResultID),Rtrim(Result.ScheduleID),Rtrim(ExamMaster.ExamName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Sessions.Session),Rtrim(Result.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Scheduling.ExamDate,Rtrim(Scheduling.MaxMarks),Rtrim(Scheduling.MinMarks) FROM Result INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN  ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID where Session=@d1 and SchoolName=@d2 and ClassName=@d3 and ExamName=@d4 and SubjectName=@d5", con);
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d4", cmbExamName.Text);
                cmd.Parameters.AddWithValue("@d5", CmbSubjectName.Text);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtschool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtsession.Items.Clear();
                txtsession.Text = "";
                txtsession.Enabled = true;
                txtsession.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Sessions.Session) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID where schoolname='" + txtschool.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtsession.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillExam1();
        }

        private void txtsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtclass.Items.Clear();
                txtclass.Text = "";
                txtclass.Enabled = true;
                txtclass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Class.ClassName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Session=@d1 and SchoolName=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtsession.Text);
                cmd.Parameters.AddWithValue("@d2", txtschool.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtclass.Items.Add(rdr[0]);
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillExam1();
      
        }

        private void txtclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtsection.Items.Clear();
                txtsection.Text = "";
                txtsection.Enabled = true;
                txtsection.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Resulting INNER JOIN Result ON Resulting.Result_ID = Result.ResultID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Session=@d1 and SchoolName=@d2 and ClassName=@d3 ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtsession.Text);
                cmd.Parameters.AddWithValue("@d2", txtschool.Text);
                cmd.Parameters.AddWithValue("@d3", txtclass.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtsection.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillExam1();
        }

        private void txtsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillExam1();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtschool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtschool.Focus();
                    return;
                }
                if (txtsession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsession.Focus();
                    return;
                }
                if (txtclass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtclass.Focus();
                    return;
                }
                if (txtsection.Text == "")
                {
                    MessageBox.Show("Please select Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsection.Focus();
                    return;
                }
                if (txtexam.Text == "")
                {
                    MessageBox.Show("Please select Exam", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtexam.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Result.ResultID),Rtrim(ExamMaster.ExamName),Rtrim(School.SchoolName),Rtrim(Sessions.Session),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Resulting.AdmissionNo),Rtrim(Student.EnrollmentNo),Rtrim(Student.StudentName),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Scheduling.ExamDate,Rtrim(Scheduling.MaxMarks),Rtrim(Scheduling.MinMarks),Rtrim(Resulting.Marks),Resulting.Absent FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN Student ON Student.AdmissionNo = Resulting.AdmissionNo INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID where Session=@d1 and SchoolName=@d2 and ClassName=@d3 and SectionName=@d4 and ExamName=@d5 GROUP BY Result.ResultID, ExamMaster.ExamName, School.SchoolName, Sessions.Session, Class.ClassName, Section.SectionName, Resulting.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Subject.SubjectCode, Subject.SubjectName, Scheduling.ExamDate, Scheduling.MaxMarks, Scheduling.MinMarks, Resulting.Marks, Resulting.Absent  ORDER BY Resulting.AdmissionNo, School.SchoolName, Class.ClassName, Sessions.Session, Section.SectionName, Subject.SubjectCode ", con);
                cmd.Parameters.AddWithValue("@d1", txtsession.Text);
                cmd.Parameters.AddWithValue("@d2", txtschool.Text);
                cmd.Parameters.AddWithValue("@d3", txtclass.Text);
                cmd.Parameters.AddWithValue("@d4", txtsection.Text);
                cmd.Parameters.AddWithValue("@d5", txtexam.Text);
                rdr = cmd.ExecuteReader();
                dgw.Rows.Clear();
                while (rdr.Read())
                {
                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtexam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtadmissionNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtschool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtschool.Focus();
                    return;
                }
                if (txtsession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsession.Focus();
                    return;
                }
                if (txtclass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtclass.Focus();
                    return;
                }
                if (txtsection.Text == "")
                {
                    MessageBox.Show("Please select Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsection.Focus();
                    return;
                }
                if (txtexam.Text == "")
                {
                    MessageBox.Show("Please select Exam", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtexam.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Result.ResultID),Rtrim(ExamMaster.ExamName),Rtrim(School.SchoolName),Rtrim(Sessions.Session),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Resulting.AdmissionNo),Rtrim(Student.EnrollmentNo),Rtrim(Student.StudentName),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Scheduling.ExamDate,Rtrim(Scheduling.MaxMarks),Rtrim(Scheduling.MinMarks),Rtrim(Resulting.Marks),Resulting.Absent FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN School ON ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Sessions ON ExamSchedule.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN Student ON Student.AdmissionNo = Resulting.AdmissionNo INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID and Resulting.AdmissionNo like '%" + txtadmissionNo.Text + "%' and Session=@d1 and SchoolName=@d2 and ClassName=@d3 and ExamName=@d4 GROUP BY Result.ResultID, ExamMaster.ExamName, School.SchoolName, Sessions.Session, Class.ClassName, Section.SectionName, Resulting.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Subject.SubjectCode, Subject.SubjectName, Scheduling.ExamDate, Scheduling.MaxMarks, Scheduling.MinMarks, Resulting.Marks, Resulting.Absent  ORDER BY Resulting.AdmissionNo, School.SchoolName, Class.ClassName, Sessions.Session, Section.SectionName, Subject.SubjectCode ", con);
                cmd.Parameters.AddWithValue("@d1", txtsession.Text);
                cmd.Parameters.AddWithValue("@d2", txtschool.Text);
                cmd.Parameters.AddWithValue("@d3", txtclass.Text);
                cmd.Parameters.AddWithValue("@d4", txtexam.Text);
                rdr = cmd.ExecuteReader();
                dgw.Rows.Clear();
                while (rdr.Read())
                {
                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15]);
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


