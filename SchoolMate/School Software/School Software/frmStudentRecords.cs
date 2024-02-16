using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmStudentRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmStudentRegistration frm = null;
        frmSchoolFeesPayment frmFee = null;
        frmBusHolderStudents frmBusholder = null;
        frmHostelersStudent frmhosteler = null;
        frmFinalMarksEntry frmresult = null;
        frmStudentsIdentityCards frmCards = null;
        frmBookIssue frmBI = null;
       frmMainmenu main = null;
     
        public frmStudentRecord()
        {
          InitializeComponent();
        }
       
        public void Sessions()
        {
            try
            {
                txtSession.Items.Clear();
                txtSession.Text = "";
                txtSession.Enabled = true;
                txtSession.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Sessions.Session) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where School.schoolname='" + txtSchool.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSession.Items.Clear();
                while (rdr.Read())
                {
                    txtSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void School()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(School.SchoolName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSchool.Items.Clear();
                while (rdr.Read())
                {
                    txtSchool.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        public void auto1()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.Status='Active'order by Student.ClassSection_ID,Student.Session_ID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID order by Student.ClassSection_ID,Student.Session_ID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStudentList_Load(object sender, EventArgs e)
        {
            Reset();
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

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.StudentName like '%" + txtStudentName.Text + "%'order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.StudentName like '%" + txtStudentName.Text + "%'order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.StudentName like '%" + txtStudentName.Text + "%'order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.admissionno like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.admissionno like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.admissionno like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtClass.Items.Clear();
                txtClass.Text = "";
                txtClass.Enabled = true;
                txtClass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where Sessions.session= @d2 and schoolname= @d1";
                cmd = new SqlCommand(ct1);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSection.Items.Clear();
            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID  and SchoolName=@d1 and Session=@d2 and class.className =@d3";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSection.Items.Add(rdr[0]);
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
            if (lblSET.Text == "S")
            {
                try
                {
                    if (txtSchool.Text == "")
                    {
                        MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSchool.Focus();
                        return;
                    }
                    if (txtSession.Text == "")
                    {
                        MessageBox.Show("Please Enter Session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       txtSession.Focus();
                        return;
                    }
                    if (txtClass.Text == "")
                    {
                        MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClass.Focus();
                        return;
                    }
                    if (txtSection.Text == "")
                    {
                        MessageBox.Show("Please Enter Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSection.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and SchoolName=@d1 and Session=@d2 and ClassName=@d3 and SectionName=@d4 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (lblSET.Text == "BI")
            {
                try
                {
                    if (txtSchool.Text == "")
                    {
                        MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSchool.Focus();
                        return;
                    }
                    if (txtSession.Text == "")
                    {
                        MessageBox.Show("Please Enter Session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSession.Focus();
                        return;
                    }
                    if (txtClass.Text == "")
                    {
                        MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClass.Focus();
                        return;
                    }
                    if (txtSection.Text == "")
                    {
                        MessageBox.Show("Please Enter Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSection.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and SchoolName=@d1 and Session=@d2 and ClassName=@d3order by StudentName and SectionName=@d4 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (txtSchool.Text == "")
                    {
                        MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSchool.Focus();
                        return;
                    }
                    if (txtSession.Text == "")
                    {
                        MessageBox.Show("Please Enter Session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSession.Focus();
                        return;
                    }
                    if (txtClass.Text == "")
                    {
                        MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClass.Focus();
                        return;
                    }
                    if (txtSection.Text == "")
                    {
                        MessageBox.Show("Please Enter Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSection.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where SchoolName=@d1 and Session=@d2 and ClassName=@d3 and SectionName=@d4 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.Status='Active' and admissionDate Between @date1 and @Date2 order by Student.ClassSection_ID,Student.Session_ID ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.Status='Active' and admissionDate Between @date1 and @Date2 order by Student.ClassSection_ID,Student.Session_ID ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and admissionDate Between @date1 and @Date2 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Reset()
        {
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            txtStudentName.Text = "";
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            txtAdmissionNo.Text = "";
            DataGridView1.Rows.Clear();
            School();
            if (lblSET.Text == "S")
            {
                auto1();
            }
            else if (lblSET.Text == "BI")
            {
                auto1();
            }
            else
            {
                auto();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }

        private void cmbSchoolSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sessions();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add data in datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = DataGridView1.RowCount;
                colsTotal = DataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }
 }
}
