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
    public partial class frmStudentRegistration : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        // bool IsImageChanged = false;

        public string TempFileNames2 = "";
        string txtStatus = null;
        string txtStatus1 = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public string Photoname = null;
        public frmStudentRegistration()
        {
            InitializeComponent();
        }
        public void Fillsession()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM Sessions ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
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
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName),classid FROM ClassSection INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID order by 2 ";
                cmd = new SqlCommand(ct1);
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

        public void Fillschool()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(SchoolName) FROM School ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtschoolName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void fillDocs()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(documentname) FROM Documentmaster ", con);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbDocumentsSubmitted.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbDocumentsSubmitted.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            func();
            Fillsession();
            fillDocs();
            Fillschool();
            FillClass();
           
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtResult.Text == "Pass")
            {
                txtPercentage.ReadOnly = false;
            }
            if (txtResult.Text == "Fail")
            {
                txtPercentage.ReadOnly = true;
            }

        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm1 = "select AdmissionNo from BookIssue_Student where AdmissionNo='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ctm1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Student using on Student BookIssue List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm2 = "select Admission_No from Doc where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Student using on Student Documents Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm3 = "select Admission_No from Hosteler where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Student using on Student Documents Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm4 = "select Admission_No from SchoolFeesPayment where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ctm4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Student using on SchoolFeesPayment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm5 = "select Admission_No from StudentBusHolder where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ctm5);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Student using on Student BusHolder List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm6 = "select Admission_No from StudentDiscount where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ctm6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Student using on Student Discount Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from STUDENT where admissionno='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted the Student'" + txtStudentName.Text + "' having AdmissionNo'" + txtAdmissionNo.Text + "' and Class'" + txtClass.Text + "' and School'" + txtschoolName.Text + "'";
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
        public void D1()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb1 = "insert into doc(Admission_No,Document_Name) VALUES (@d1,@d2)";
            cmd = new SqlCommand(cb1);
            cmd.Connection = con;
            cmd.Prepare();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                    cmd.Parameters.AddWithValue("@d2", row.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtAdmissionNo.Text == "")
                {
                    MessageBox.Show("Please Enter Student's Admission", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdmissionNo.Focus();
                    return;
                }
                if (txtschoolName.Text == "")
                {
                    MessageBox.Show("Please select SchoolName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtschoolName.Focus();
                    return;
                }
                if (txtStudentName.Text == "")
                {
                    MessageBox.Show("Please select Student Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStudentName.Focus();
                    return;
                }
                if ((radioButton1.Checked == false & radioButton2.Checked == false))
                {
                    MessageBox.Show("Please select Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((radioButton1.Checked == true))
                {
                    txtStatus = radioButton1.Text;
                }
                if ((radioButton2.Checked == true))
                {
                    txtStatus = radioButton2.Text;
                }
                if ((txtcheckBox.Checked == true))
                {
                    txtStatus1 = txtcheckBox.Text;
                }
                if ((txtcheckBox.Checked == false))
                {
                    txtStatus1 = "Inactive";
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSession.Focus();
                    return;
                }
                if (!txtDOB.MaskFull)
                {
                    MessageBox.Show("Please Enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDOB.Focus();
                    return;
                }

                if (txtEmailID.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.Focus();
                    return;
                }
                if (txtReligion.Text == "")
                {
                    MessageBox.Show("Please Select Religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtReligion.Focus();
                    return;
                }
                if (txtcity.Text == "")
                {
                    MessageBox.Show("Please enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcity.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please enter Country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCountry.Focus();
                    return;
                }
                if (txtTemporaryAddress.Text == "")
                {
                    MessageBox.Show("Please enter Temporary Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTemporaryAddress.Focus();
                    return;
                }
                if (txtPermanentAddress.Text == "")
                {
                    MessageBox.Show("Please enter Parmanent Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPermanentAddress.Focus();
                    return;
                }

                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtMotherName.Text == "")
                {
                    MessageBox.Show("Please enter Mother's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtMotherName.Text == "")
                {
                    MessageBox.Show("Please enter mother's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMotherName.Focus();
                    return;
                }

                if (txtReligion.Text == "")
                {
                    MessageBox.Show("Please select religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtReligion.Focus();
                    return;
                }
                if (txtPermanentAddress.Text == "")
                {
                    MessageBox.Show("Please select address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPermanentAddress.Focus();
                    return;
                }
                if (txtNationality.Text == "")
                {
                    MessageBox.Show("Please enter nationality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNationality.Focus();
                    return;
                }

                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please select class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtSection.Text == "")
                {
                    MessageBox.Show("Please select Section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSection.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtMotherName.Text == "")
                {
                    MessageBox.Show("Please enter Mother's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMotherName.Focus();
                    return;
                }
                if (txtParentContact.Text == "")
                {
                    MessageBox.Show("Please enter Parent's Contact No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParentContact.Focus();
                    return;
                }
                if (txtBloodGroup.Text == "")
                {
                    MessageBox.Show("Please Select Blood Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBloodGroup.Focus();
                    return;
                }
                if (dataGridView2.Rows.Count == 0)
                {
                    MessageBox.Show("Please add Submitted Documents in a Document Grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select AdmissionNo from Student where AdmissionNo='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("AdmissionNo Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdmissionNo.Text = "";
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into student(AdmissionNo, EnrollmentNo, StudentName, FatherName, FatherOcc, MotherName, MotherOcc, ParentContact, PermanentAddress, TemporaryAddress, ContactNo, Email, DOB, Gender, AdmissionDate, Category,Religion, Nationality, ClassSection_ID, School_ID, LastSchool, LastClass, PassingYr, percents, Board, BloodGroup, Height, Weight, GuardianName, Address, GuardianContact,Session_ID,Result,HomeContact,Status,Photo,Country,City) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtEnrollmentNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@d4", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@d5", txtFatherOcc.Text);
                cmd.Parameters.AddWithValue("@d6", txtMotherName.Text);
                cmd.Parameters.AddWithValue("@d7", txtMotherOcc.Text);
                cmd.Parameters.AddWithValue("@d8", txtParentContact.Text);
                cmd.Parameters.AddWithValue("@d9", txtPermanentAddress.Text);
                cmd.Parameters.AddWithValue("@d10", txtTemporaryAddress.Text);
                cmd.Parameters.AddWithValue("@d11", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@d12", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@d13", txtDOB.Text);
                cmd.Parameters.AddWithValue("@d14", txtStatus);
                cmd.Parameters.AddWithValue("@d15", dtpAdmissionDate.Value.Date);
                cmd.Parameters.AddWithValue("@d16", txtCategory.Text);
                cmd.Parameters.AddWithValue("@d17", txtReligion.Text);
                cmd.Parameters.AddWithValue("@d18", txtNationality.Text);
                cmd.Parameters.AddWithValue("@d19", txtClassSectionID.Text);
                cmd.Parameters.AddWithValue("@d20", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d21", txtlastschool.Text);
                cmd.Parameters.AddWithValue("@d22", txtLastClassName.Text);
                cmd.Parameters.AddWithValue("@d23", txtPassingYr.Text);
                cmd.Parameters.AddWithValue("@d24", txtPercentage.Text);
                cmd.Parameters.AddWithValue("@d25", txtBoard.Text);
                cmd.Parameters.AddWithValue("@d26", txtBloodGroup.Text);
                cmd.Parameters.AddWithValue("@d27", txtHight.Text);
                cmd.Parameters.AddWithValue("@d28", txtWeight.Text);
                cmd.Parameters.AddWithValue("@d29", txtGuardianName.Text);
                cmd.Parameters.AddWithValue("@d30", txtGuardianAddress.Text);
                cmd.Parameters.AddWithValue("@d31", txtGuardianContact.Text);
                cmd.Parameters.AddWithValue("@d32", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d33", txtResult.Text);
                cmd.Parameters.AddWithValue("@d34", txtHomePhoneNo.Text);
                cmd.Parameters.AddWithValue("@d35", txtStatus1);
                cmd.Parameters.AddWithValue("@d37", txtcity.Text);
                cmd.Parameters.AddWithValue("@d38", txtCountry.Text);
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(Picture.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d36", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteReader();
                con.Close();
                D1();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb3 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", "Class");
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb4 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb4);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", "Bus");
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb5 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb5);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", "Hostel");
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Added New Student'" + txtStudentName.Text + "' having AdmissionNo'" + txtAdmissionNo.Text + "' and Class'" + txtClass.Text + "' and School'" + txtschoolName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = OpenFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;

                OpenFileDialog1.FileName = "";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Picture.Image = Image.FromFile(OpenFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Picture.Image = School_Software.Properties.Resources.photo;
        }

        private void txtContactNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtContactNo.TextLength >= 15)
            {
                MessageBox.Show("Mobile Number Can not be Greater than 15 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
        }

        private void txtHomePhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtContactNo.TextLength >= 15)
            {
                MessageBox.Show("Mobile Number Can not be Greater than 15 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
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
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
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

        private void txtSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct Rtrim(ClasssectionID) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "' and Section.SectionName = '" + txtSection.Text + "'";
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

        private void txtschoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(School.SchoolID) FROM School Where School.SchoolName = '" + txtschoolName.Text + "'";
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
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(Sessions.SessionID) FROM Sessions Where Sessions.Session = '" + txtSession.Text + "'";
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
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList(this);
            frm.lblUser.Text = lblUser.Text;
            frm.lblSET.Text = "ST";
            frm.ShowDialog();
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtHomePhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtHight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtAdmissionNo.Text == "")
            {
                MessageBox.Show("Please Enter Student's Admission", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdmissionNo.Focus();
                return;
            }
            if (txtschoolName.Text == "")
            {
                MessageBox.Show("Please select SchoolName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtschoolName.Focus();
                return;
            }
            if (txtStudentName.Text == "")
            {
                MessageBox.Show("Please select Student Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentName.Focus();
                return;
            }
            if ((radioButton1.Checked == false & radioButton2.Checked == false))
            {
                MessageBox.Show("Please select Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((radioButton1.Checked == true))
            {
                txtStatus = radioButton1.Text;
            }
            if ((radioButton2.Checked == true))
            {
                txtStatus = radioButton2.Text;
            }
            if ((txtcheckBox.Checked == true))
            {
                txtStatus1 = txtcheckBox.Text;
            }
            if ((txtcheckBox.Checked == false))
            {
                txtStatus1 = "Inactive";
            }
            if (txtSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSession.Focus();
                return;
            }
            if (!txtDOB.MaskFull)
            {
                MessageBox.Show("Please Enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDOB.Focus();
                return;
            }

            if (txtEmailID.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailID.Focus();
                return;
            }
            if (txtReligion.Text == "")
            {
                MessageBox.Show("Please Select Religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReligion.Focus();
                return;
            }
            if (txtcity.Text == "")
            {
                MessageBox.Show("Please enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcity.Focus();
                return;
            }
            if (txtCountry.Text == "")
            {
                MessageBox.Show("Please enter Country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCountry.Focus();
                return;
            }
            if (txtTemporaryAddress.Text == "")
            {
                MessageBox.Show("Please enter Temporary Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTemporaryAddress.Focus();
                return;
            }
            if (txtPermanentAddress.Text == "")
            {
                MessageBox.Show("Please enter Parmanent Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPermanentAddress.Focus();
                return;
            }

            if (txtFatherName.Text == "")
            {
                MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFatherName.Focus();
                return;
            }
            if (txtMotherName.Text == "")
            {
                MessageBox.Show("Please enter Mother's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFatherName.Focus();
                return;
            }
            if (txtMotherName.Text == "")
            {
                MessageBox.Show("Please enter mother's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotherName.Focus();
                return;
            }

            if (txtReligion.Text == "")
            {
                MessageBox.Show("Please select religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReligion.Focus();
                return;
            }
            if (txtPermanentAddress.Text == "")
            {
                MessageBox.Show("Please select address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPermanentAddress.Focus();
                return;
            }
            if (txtNationality.Text == "")
            {
                MessageBox.Show("Please enter nationality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNationality.Focus();
                return;
            }

            if (txtClass.Text == "")
            {
                MessageBox.Show("Please select class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClass.Focus();
                return;
            }
            if (txtSection.Text == "")
            {
                MessageBox.Show("Please select Section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSection.Focus();
                return;
            }
            if (txtFatherName.Text == "")
            {
                MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFatherName.Focus();
                return;
            }
            if (txtMotherName.Text == "")
            {
                MessageBox.Show("Please enter Mother's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotherName.Focus();
                return;
            }
            if (txtParentContact.Text == "")
            {
                MessageBox.Show("Please enter Parent's Contact No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParentContact.Focus();
                return;
            }
            if (txtBloodGroup.Text == "")
            {
                MessageBox.Show("Please Select Blood Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBloodGroup.Focus();
                return;
            }
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Please add Submitted Documents in a Document Grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtAdmissionNo.Text) != (txtAdmissionNo1.Text))
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select AdmissionNo from Student where AdmissionNo='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("AdmissionNo Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdmissionNo.Text = "";
                    txtAdmissionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            if ((radioButton1.Checked == false & radioButton2.Checked == false))
            {
                MessageBox.Show("Please select Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((radioButton1.Checked == true))
            {
                txtStatus = radioButton1.Text;
            }
            if ((radioButton2.Checked == true))
            {
                txtStatus = radioButton2.Text;
            }
            if ((txtcheckBox.Checked == true))
            {
                txtStatus1 = txtcheckBox.Text;
            }
            if ((txtcheckBox.Checked == false))
            {
                txtStatus1 = "Inactive";
            }
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb = "update Student set EnrollmentNo=@d2, StudentName=@d3, FatherName=@d4, FatherOcc=@d5, MotherName=@d6, MotherOcc=@d7, ParentContact=@d8, PermanentAddress=@d9, TemporaryAddress=@d10, ContactNo=@d11, Email=@d12, DOB=@d13, Gender=@d14, AdmissionDate=@d15, Category=@d16,Religion=@d17, Nationality=@d18, ClassSection_ID=@d19, School_ID=@d20, LastSchool=@d21, LastClass=@d22, PassingYr=@d23, percents=@d24, Board=@d25, BloodGroup=@d26, Height=@d27, Weight=@d28, GuardianName=@d29, Address=@d30, GuardianContact=@d31,Session_ID=@d32,Result=@d33,HomeContact=@d34,Status=@d35,Photo=@d36,City=@d37,Country=@d38 ,AdmissionNo=@d1 where AdmissionNo=@d39";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
            cmd.Parameters.AddWithValue("@d2", txtEnrollmentNo.Text);
            cmd.Parameters.AddWithValue("@d3", txtStudentName.Text);
            cmd.Parameters.AddWithValue("@d4", txtFatherName.Text);
            cmd.Parameters.AddWithValue("@d5", txtFatherOcc.Text);
            cmd.Parameters.AddWithValue("@d6", txtMotherName.Text);
            cmd.Parameters.AddWithValue("@d7", txtMotherOcc.Text);
            cmd.Parameters.AddWithValue("@d8", txtParentContact.Text);
            cmd.Parameters.AddWithValue("@d9", txtPermanentAddress.Text);
            cmd.Parameters.AddWithValue("@d10", txtTemporaryAddress.Text);
            cmd.Parameters.AddWithValue("@d11", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@d12", txtEmailID.Text);
            cmd.Parameters.AddWithValue("@d13", txtDOB.Text);
            cmd.Parameters.AddWithValue("@d14", txtStatus);
            cmd.Parameters.AddWithValue("@d15", dtpAdmissionDate.Value.Date);
            cmd.Parameters.AddWithValue("@d16", txtCategory.Text);
            cmd.Parameters.AddWithValue("@d17", txtReligion.Text);
            cmd.Parameters.AddWithValue("@d18", txtNationality.Text);
            cmd.Parameters.AddWithValue("@d19", txtClassSectionID.Text);
            cmd.Parameters.AddWithValue("@d20", txtSchoolID.Text);
            cmd.Parameters.AddWithValue("@d21", txtlastschool.Text);
            cmd.Parameters.AddWithValue("@d22", txtLastClassName.Text);
            cmd.Parameters.AddWithValue("@d23", txtPassingYr.Text);
            cmd.Parameters.AddWithValue("@d24", txtPercentage.Text);
            cmd.Parameters.AddWithValue("@d25", txtBoard.Text);
            cmd.Parameters.AddWithValue("@d26", txtBloodGroup.Text);
            cmd.Parameters.AddWithValue("@d27", txtHight.Text);
            cmd.Parameters.AddWithValue("@d28", txtWeight.Text);
            cmd.Parameters.AddWithValue("@d29", txtGuardianName.Text);
            cmd.Parameters.AddWithValue("@d30", txtGuardianAddress.Text);
            cmd.Parameters.AddWithValue("@d31", txtGuardianContact.Text);
            cmd.Parameters.AddWithValue("@d32", txtSessionID.Text);
            cmd.Parameters.AddWithValue("@d33", txtResult.Text);
            cmd.Parameters.AddWithValue("@d34", txtHomePhoneNo.Text);
            cmd.Parameters.AddWithValue("@d35", txtStatus1);
            cmd.Parameters.AddWithValue("@d37", txtcity.Text);
            cmd.Parameters.AddWithValue("@d38", txtCountry.Text);
            cmd.Parameters.AddWithValue("@d39", txtAdmissionNo1.Text);
            MemoryStream ms = new MemoryStream();
            Bitmap bmpImage = new Bitmap(Picture.Image);
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.GetBuffer();
            SqlParameter p = new SqlParameter("@d36", SqlDbType.Image);
            p.Value = data;
            cmd.Parameters.Add(p);
            cmd.ExecuteReader();
            con.Close();
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cq1 = "delete from Doc where Admission_No='" + txtAdmissionNo1.Text + "'";
            cmd = new SqlCommand(cq1);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            D1();
            st1 = lblUser.Text;
            st2 = "Updated Student'" + txtStudentName.Text + "' having AdmissionNo'" + txtAdmissionNo.Text + "' and Class'" + txtClass.Text + "' and School'" + txtschoolName.Text + "'";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate_record.Enabled = false;
        }

        public void Reset()
        {
            txtAdmissionNo.Text = "";
            txtEnrollmentNo.Text = "";
            txtStudentName.Text = "";
            txtFatherName.Text = "";
            txtFatherOcc.Text = "";
            txtMotherName.Text = "";
            txtMotherOcc.Text = "";
            txtParentContact.Text = "";
            txtPermanentAddress.Text = "";
            txtTemporaryAddress.Text = "";
            txtContactNo.Text = "";
            txtCategory.Text = "";
            txtReligion.Text = "";
            txtNationality.Text = "";
            txtHomePhoneNo.Text = "";
            txtResult.Text = "";
            txtEmailID.Text = "";
            txtSessionID.Text = "";
            txtGuardianContact.Text = "";
            txtGuardianAddress.Text = "";
            dtpAdmissionDate.Text = System.DateTime.Now.ToString();
            txtDOB.Text = "";
            txtGuardianName.Text = "";
            txtWeight.Text = "";
            txtHight.Text = "";
            txtResult.SelectedIndex = -1;
            txtBloodGroup.SelectedIndex = -1;
            txtBoard.Text = "";
            txtAdmissionNo.Text = "";
            txtClass.Text = "";
            txtPercentage.Text = "";
            txtschoolName.Text = "";
            txtSession.Text = "";
            txtcity.Text = "";
            txtCountry.Text = "";
            txtPassingYr.Text = "";
            txtLastClassName.Text = "";
            txtSection.Enabled = false;
            txtlastschool.Text = "";
            txtSchoolID.Text = "";
            txtClassSectionID.Text = "";
            txtAdmissionNo.Focus();
            dataGridView2.Rows.Clear();
            cmbDocumentsSubmitted.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtcheckBox.Checked = true;
            Picture.Image = School_Software.Properties.Resources.photo;
            txtPercentage.ReadOnly = true;
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + lblUser.Text + "' ";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
        ////    Bitmap image1 = (Bitmap)Image.FromFile(@"C:\Documents and Settings\" +
        ////@"All Users\Documents\My Music\music.bmp", true);
        private void BStartCapture_Click(object sender, EventArgs e)
        {
            //frmCamera frm = new frmCamera();
            //frm.Show();
            //if (Convert.ToInt32(TempFileNames2.Length.ToString()) >= 0)
            //{

            //    Picture.Image = Image.FromFile(TempFileNames2);
            //   Photoname = TempFileNames2;
            //   IsImageChanged = true;
            // }

        }



        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                btnRemove.Enabled = true;
            }
            btnRemove.Enabled = true;
            btnAdd.Enabled = true;
           }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbDocumentsSubmitted.Text))
            {
                MessageBox.Show("Please Select Document", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbDocumentsSubmitted.Focus();
                return;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (cmbDocumentsSubmitted.Text == row.Cells[0].Value.ToString())
                {
                    MessageBox.Show("Document already added", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            dataGridView2.Rows.Add(cmbDocumentsSubmitted.Text);
        }

        private void btnRemovelist_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }

            btnRemove.Enabled = false;
 }
        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmailID.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmailID.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

