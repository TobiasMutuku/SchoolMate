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


namespace School_Software
{
    public partial class frmStudentList : Form
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
        public frmStudentList(frmStudentRegistration par)
        {
            frm = par;
            InitializeComponent();
        }
        public frmStudentList(frmBookIssue par1)
        {
            frmBI = par1;
            InitializeComponent();
        }
        public frmStudentList(frmStudentsIdentityCards par8)
        {
            frmCards = par8;
            InitializeComponent();
        }
        public frmStudentList(frmFinalMarksEntry par5)
        {
            frmresult = par5;
            InitializeComponent();
        }
        public frmStudentList()
        {
          InitializeComponent();
        }
        public frmStudentList(frmMainmenu pars)
        {
            main = pars;
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
        public frmStudentList(frmBusHolderStudents par1)
        {
            frmBusholder = par1;
            InitializeComponent();
        }
        public frmStudentList(frmHostelersStudent par2)
        {
            frmhosteler = par2;
            InitializeComponent();
        }
        public frmStudentList(frmSchoolFeesPayment par3)
        {
            frmFee = par3;
            InitializeComponent();
        }
        public void auto1()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.Status='Active'order by Student.ClassSection_ID,Student.Session_ID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID order by Student.ClassSection_ID,Student.Session_ID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R1")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmBusholder.Show();
                frmBusholder.txtSchoolName.Text = dr.Cells[1].Value.ToString();
                frmBusholder.txtSession.Text = dr.Cells[3].Value.ToString();
                frmBusholder.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmBusholder.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmBusholder.txtClass.Text = dr.Cells[9].Value.ToString();
                frmBusholder.txtSection.Text = dr.Cells[10].Value.ToString();
            }
            else if (lblSET.Text == "R2")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmhosteler.Show();
                frmhosteler.txtSchoolName.Text = dr.Cells[1].Value.ToString();
                frmhosteler.txtSession.Text = dr.Cells[3].Value.ToString();
                frmhosteler.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmhosteler.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmhosteler.txtClass.Text = dr.Cells[9].Value.ToString();
                frmhosteler.txtSection.Text = dr.Cells[10].Value.ToString();
            }
            else if (lblSET.Text == "V1")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmresult.Show();
                frmresult.txtSchoolName.Text = dr.Cells[1].Value.ToString();
                frmresult.txtSession.Text = dr.Cells[3].Value.ToString();
                frmresult.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmresult.txtEnrollmentNo.Text = dr.Cells[7].Value.ToString();
                frmresult.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmresult.txtClass.Text = dr.Cells[9].Value.ToString();
                frmresult.txtSection.Text = dr.Cells[10].Value.ToString();
                frmresult.FillSub();
            }
            else if (lblSET.Text == "V5")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmCards.Show();
                frmCards.txtSchoolName.Text = dr.Cells[1].Value.ToString();
                frmCards.txtSession.Text = dr.Cells[3].Value.ToString();
                frmCards.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmCards.txtEnrollmentNo.Text = dr.Cells[7].Value.ToString();
                frmCards.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmCards.txtClass.Text = dr.Cells[9].Value.ToString();
                frmCards.txtSection.Text = dr.Cells[10].Value.ToString();
    }
            else if (lblSET.Text == "S")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmFee.Show();
                frmFee.txtSchoolName.Text = dr.Cells[1].Value.ToString();
                frmFee.txtSession.Text = dr.Cells[3].Value.ToString();
                frmFee.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmFee.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmFee.txtClass.Text = dr.Cells[9].Value.ToString();
                frmFee.txtSection.Text = dr.Cells[10].Value.ToString();
                frmFee.txtEnrollmentNo.Text = dr.Cells[7].Value.ToString();
                frmFee.fillMonths();
                frmFee.fillMonthssss();
            }
            else if (lblSET.Text == "BI")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmBI.Show();
                frmBI.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmBI.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmBI.txtClass.Text = dr.Cells[9].Value.ToString();
           }
            else if(lblSET.Text == "ST")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm.Activate();
                frm.BringToFront();
                frm.txtSchoolID.Text = dr.Cells[0].Value.ToString();
                frm.txtschoolName.Text = dr.Cells[1].Value.ToString();
                frm.txtSessionID.Text = dr.Cells[2].Value.ToString();
                frm.txtSession.Text = dr.Cells[3].Value.ToString();
                frm.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frm.txtAdmissionNo1.Text = dr.Cells[4].Value.ToString();
                frm.dtpAdmissionDate.Text = dr.Cells[5].Value.ToString();
                frm.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frm.txtEnrollmentNo.Text = dr.Cells[7].Value.ToString();
                frm.txtClassSectionID.Text = dr.Cells[8].Value.ToString();
                frm.txtClass.Text = dr.Cells[9].Value.ToString();
                frm.txtSection.Text = dr.Cells[10].Value.ToString();
                if ((dr.Cells[11].Value.ToString() == "Male"))
                {
                    frm.radioButton1.Checked = true;
                }
                if ((dr.Cells[11].Value.ToString() == "Female"))
                {
                    frm.radioButton2.Checked = true;
                }

                frm.txtDOB.Text = dr.Cells[12].Value.ToString();
                frm.txtContactNo.Text = dr.Cells[13].Value.ToString();
                frm.txtHomePhoneNo.Text = dr.Cells[14].Value.ToString();
                frm.txtEmailID.Text = dr.Cells[15].Value.ToString();
                frm.txtFatherName.Text = dr.Cells[16].Value.ToString();
                frm.txtFatherOcc.Text = dr.Cells[17].Value.ToString();
                frm.txtMotherName.Text = dr.Cells[18].Value.ToString();
                frm.txtMotherOcc.Text = dr.Cells[19].Value.ToString();
                frm.txtParentContact.Text = dr.Cells[20].Value.ToString();
                frm.txtcity.Text = dr.Cells[21].Value.ToString();
                frm.txtCountry.Text = dr.Cells[22].Value.ToString();
                frm.txtPermanentAddress.Text = dr.Cells[23].Value.ToString();
                frm.txtTemporaryAddress.Text = dr.Cells[24].Value.ToString();
                frm.txtCategory.Text = dr.Cells[25].Value.ToString();
                frm.txtReligion.Text = dr.Cells[26].Value.ToString();
                frm.txtNationality.Text = dr.Cells[27].Value.ToString();
                frm.txtlastschool.Text = dr.Cells[28].Value.ToString();
                frm.txtLastClassName.Text = dr.Cells[29].Value.ToString();
                frm.txtPassingYr.Text = dr.Cells[30].Value.ToString();
                frm.txtResult.Text = dr.Cells[31].Value.ToString();
                frm.txtPercentage.Text = dr.Cells[32].Value.ToString();
                frm.txtBoard.Text = dr.Cells[33].Value.ToString();
                frm.txtGuardianName.Text = dr.Cells[34].Value.ToString();
                frm.txtGuardianAddress.Text = dr.Cells[35].Value.ToString();
                frm.txtGuardianContact.Text = dr.Cells[36].Value.ToString();
                frm.txtBloodGroup.Text = dr.Cells[37].Value.ToString();
                frm.txtHight.Text = dr.Cells[38].Value.ToString();
                frm.txtWeight.Text = dr.Cells[39].Value.ToString();

                if ((dr.Cells[40].Value.ToString() == "Active"))
                {
                    frm.txtcheckBox.Checked = true;
                }
                if ((dr.Cells[40].Value.ToString() == "Inactive"))
                {
                    frm.txtcheckBox.Checked = false;
                }
                byte[] data = (byte[])dr.Cells[41].Value;
                MemoryStream ms = new MemoryStream(data);
                frm.Picture.Image = Image.FromStream(ms);
                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;
                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT distinct Rtrim(Doc.Document_Name) FROM Doc INNER JOIN DocumentMaster ON Doc.Document_Name = DocumentMaster.DocumentName INNER JOIN Student ON Doc.Admission_No = Student.AdmissionNo and Doc.Admission_No='" + dr.Cells[4].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                frm.dataGridView2.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    frm.dataGridView2.Rows.Add(rdr[0]);
                }
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
               cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + lblUser.Text + "'";
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
                    frm.btnUpdate_record.Enabled = true;
                else
                    frm.btnUpdate_record.Enabled = false;


                if (lbldelete.Text == "True")
                    frm.btnDelete.Enabled = true;
                else
                    frm.btnDelete.Enabled = false;  
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

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.StudentName like '%" + txtStudentName.Text + "%'order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.StudentName like '%" + txtStudentName.Text + "%'order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.StudentName like '%" + txtStudentName.Text + "%'order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.admissionno like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and Student.admissionno like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.admissionno like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID,Student.Session_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and SchoolName=@d1 and Session=@d2 and ClassName=@d3 and SectionName=@d4 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and SchoolName=@d1 and Session=@d2 and ClassName=@d3order by StudentName and SectionName=@d4 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where SchoolName=@d1 and Session=@d2 and ClassName=@d3 and SectionName=@d4 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.Status='Active' and admissionDate Between @date1 and @Date2 order by Student.ClassSection_ID,Student.Session_ID ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and Student.Status='Active' and admissionDate Between @date1 and @Date2 order by Student.ClassSection_ID,Student.Session_ID ", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
                    cmd = new SqlCommand("SELECT Rtrim(Student.School_ID),Rtrim(School.SchoolName),Rtrim(Student.Session_ID),Rtrim(Sessions.Session),Rtrim(Student.AdmissionNo),Student.AdmissionDate,Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(Student.ClassSection_ID),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Student.Gender),Rtrim(Student.DOB),Rtrim(Student.ContactNo),Rtrim(Student.HomeContact),Rtrim(Student.Email),Rtrim(Student.FatherName),Rtrim(Student.FatherOcc),Rtrim(Student.MotherName),Rtrim(Student.MotherOcc),Rtrim(Student.ParentContact),Rtrim(Student.City),Rtrim(Student.Country),Rtrim(Student.PermanentAddress),Rtrim(Student.TemporaryAddress),Rtrim(Student.Category),Rtrim(Student.Religion),Rtrim(Student.Nationality),Rtrim(Student.LastSchool),Rtrim(Student.LastClass),Rtrim(Student.PassingYr),Rtrim(Student.Result),Rtrim(Student.percents),Rtrim(Student.Board),Rtrim(Student.GuardianName),Rtrim(Student.Address),Rtrim(Student.GuardianContact),Rtrim(Student.BloodGroup),Rtrim(Student.Height),Rtrim(Student.Weight),Rtrim(Student.Status),Student.Photo FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID and admissionDate Between @date1 and @Date2 order by Student.ClassSection_ID,Student.Session_ID", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AdmissionDate").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41]);
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
 }
}
