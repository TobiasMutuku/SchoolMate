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
    public partial class frmFinalMarksEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlCommand cmd1 = null;
       frmReport frm = new frmReport();
       SqlDataAdapter adp;
        SqlDataAdapter adp1;
        DataSet ds;
        Connectionstring cs = new Connectionstring();
       string stX = null;
        public frmFinalMarksEntry()
        {
            InitializeComponent();
        }

        public void FinalGrade()
        {
            decimal val8 = 1;
            decimal val9 = 1;
            decimal.TryParse(txtMaxMarksP.Text, out val8);
            decimal.TryParse(txtOMPractical.Text, out val9);
            decimal val1 = 1;
            decimal val2 = 1;
            decimal.TryParse(txtMaxMarksT.Text, out val1);
            decimal.TryParse(txtOMTheory.Text, out val2);

               if (!string.IsNullOrEmpty(txtOMPractical.Text) & !string.IsNullOrEmpty(txtOMTheory.Text))
                {
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 90 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 100)
                    {
                        txtFinalGrade.Text = "A+";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 80 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 89)
                    {
                        txtFinalGrade.Text = "A";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 70 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 79)
                    {
                        txtFinalGrade.Text = "B+";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 60 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 69)
                    {
                        txtFinalGrade.Text = "B";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 50 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 59)
                    {
                        txtFinalGrade.Text = "C+";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 40 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 49)
                    {
                        txtFinalGrade.Text = "C";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 33 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 39)
                    {
                        txtFinalGrade.Text = "D";
                    }
                    if ((((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) >= 0 & (((((val9) * 100) / (val8)) + (((val2) * 100) / (val1))) / 2) <= 33)
                    {
                        txtFinalGrade.Text = "E";
                    }
                   
                }
                else  if (string.IsNullOrEmpty(txtOMPractical.Text) & !string.IsNullOrEmpty(txtOMTheory.Text))
                {

                    if ( (((val2) * 100) / (val1)) >= 90 & ((((val2) * 100) / (val1))) <= 100)
                    {
                        txtFinalGrade.Text = "A+";
                    }
                    if ((((val2) * 100) / (val1)) >= 80 & ((((val2) * 100) / (val1))) <= 89)
                    {
                        txtFinalGrade.Text = "A";
                    }
                    if ( (((val2) * 100) / (val1)) >= 70 & ((((val2) * 100) / (val1))) <= 79)
                    {
                        txtFinalGrade.Text = "B+";
                    }
                    if ((((val2) * 100) / (val1)) >= 60 & ((((val2) * 100) / (val1))) <= 69)
                    {
                        txtFinalGrade.Text = "B";
                    }
                    if ((((val2) * 100) / (val1)) >= 50 & ((((val2) * 100) / (val1))) <= 59)
                    {
                        txtFinalGrade.Text = "C+";
                    }
                    if ((((val2) * 100) / (val1)) >= 40 & ((((val2) * 100) / (val1))) <= 49)
                    {
                        txtFinalGrade.Text = "C";
                    }
                    if ((((val2) * 100) / (val1)) >= 33 & ((((val2) * 100) / (val1))) <= 39)
                    {
                        txtFinalGrade.Text = "D";
                    }
                    if ((((val2) * 100) / (val1)) >= 0 & ((((val2) * 100) / (val1))) <= 33)
                    {
                        txtFinalGrade.Text = "E";
                    }
                }
                else if (!string.IsNullOrEmpty(txtOMPractical.Text) & string.IsNullOrEmpty(txtOMTheory.Text))
                {


                    if ((((val9) * 100) / (val8)) >= 90 & ((((val9) * 100) / (val8))) <= 100)
                    {
                        txtFinalGrade.Text = "A+";
                    }
                    if ((((val9) * 100) / (val8)) >= 80 & ((((val9) * 100) / (val8))) <= 89)
                    {
                        txtFinalGrade.Text = "A";
                    }
                    if ((((val9) * 100) / (val8)) >= 70 & ((((val9) * 100) / (val8))) <= 79)
                    {
                        txtFinalGrade.Text = "B+";
                    }
                    if ((((val9) * 100) / (val8)) >= 60 & ((((val9) * 100) / (val8))) <= 69)
                    {
                        txtFinalGrade.Text = "B";
                    }
                    if ((((val9) * 100) / (val8)) >= 50 & ((((val9) * 100) / (val8))) <= 59)
                    {
                        txtFinalGrade.Text = "C+";
                    }
                    if ((((val9) * 100) / (val8)) >= 40 & ((((val9) * 100) / (val8))) <= 49)
                    {
                        txtFinalGrade.Text = "C";
                    }
                    if ((((val9) * 100) / (val8)) >= 33 & ((((val9) * 100) / (val8))) <= 39)
                    {
                        txtFinalGrade.Text = "D";
                    }
                    if ((((val9) * 100) / (val8)) >= 0 & ((((val9) * 100) / (val8))) <= 33)
                    {
                        txtFinalGrade.Text = "E";
                    }

  }
                else if (!string.IsNullOrEmpty(txtOMPractical.Text) & !string.IsNullOrEmpty(txtOMTheory.Text) & string.IsNullOrEmpty(txtMaxMarksP.Text))
                {
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 90 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 100)
                    {
                        txtFinalGrade.Text = "A+";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 80 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 89)
                    {
                        txtFinalGrade.Text = "A";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 70 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 79)
                    {
                        txtFinalGrade.Text = "B+";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 60 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 69)
                    {
                        txtFinalGrade.Text = "B";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 50 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 59)
                    {
                        txtFinalGrade.Text = "C+";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 40 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 49)
                    {
                        txtFinalGrade.Text = "C";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 33 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 39)
                    {
                        txtFinalGrade.Text = "D";
                    }
                    if ((((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) >= 0 & (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) / 2) <= 33)
                    {
                        txtFinalGrade.Text = "E";
                    }
                   
                }
                else if (string.IsNullOrEmpty(txtOMPractical.Text) & !string.IsNullOrEmpty(txtOMTheory.Text) & string.IsNullOrEmpty(txtMaxMarksP.Text))
                {
                    if ((((val9) * 100) / 1) + (((val2) * 100) / (val1)) >= 90 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 100)
                    {
                        txtFinalGrade.Text = "A+";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 80 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 89)
                    {
                        txtFinalGrade.Text = "A";
                    }
                    if ((((val9) * 100) / 1) + (((val2) * 100) / (val1)) >= 70 & (((val9) * 100) / 1) + (((val2) * 100) / (val1)) <= 79)
                    {
                        txtFinalGrade.Text = "B+";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 60 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 69)
                    {
                        txtFinalGrade.Text = "B";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 50 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 59)
                    {
                        txtFinalGrade.Text = "C+";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 40 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 49)
                    {
                        txtFinalGrade.Text = "C";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 33 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 39)
                    {
                        txtFinalGrade.Text = "D";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 0 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 33)
                    {
                        txtFinalGrade.Text = "E";
                    }
                   }
                else    if (!string.IsNullOrEmpty(txtOMPractical.Text) & string.IsNullOrEmpty(txtOMTheory.Text) & string.IsNullOrEmpty(txtMaxMarksP.Text))
                {
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 90 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 100)
                    {
                        txtFinalGrade.Text = "A+";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 80 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 89)
                    {
                        txtFinalGrade.Text = "A";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 70 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 79)
                    {
                        txtFinalGrade.Text = "B+";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 60 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 69)
                    {
                        txtFinalGrade.Text = "B";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 50 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 59)
                    {
                        txtFinalGrade.Text = "C+";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 40 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 49)
                    {
                        txtFinalGrade.Text = "C";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 33 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 39)
                    {
                        txtFinalGrade.Text = "D";
                    }
                    if (((((val9) * 100) / 1) + (((val2) * 100) / (val1))) >= 0 & ((((val9) * 100) / 1) + (((val2) * 100) / (val1))) <= 33)
                    {
                        txtFinalGrade.Text = "E";
                    }
                   }
                else if (string.IsNullOrEmpty(txtOMPractical.Text) & string.IsNullOrEmpty(txtOMTheory.Text))
                {
                    txtFinalGrade.Text = "";
                    txtGradePoint.Text = "";
                }
           }
        public void FillSub()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Subject.SubjectName) FROM Section INNER JOIN ClassSection ON Section.SectionID = ClassSection.Section_ID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Subject INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN School ON Subject.SchoolID = School.SchoolID ON Class.ClassID = Subject.ClassID where School.SchoolName=@d1 and ClassName=@d2 and Sectionname=@d3 and Sessions.Session=@d4";
               cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                cmd.Parameters.AddWithValue("@d3", txtSection.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
               rdr = cmd.ExecuteReader();
               cmbSubjectName.Items.Clear();
                while (rdr.Read())
                {
                    cmbSubjectName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList(this);
            frm.lblSET.Text = "V1";
            frm.Show();
        }

        private void CmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Subject.SubjectID, Subject.SubjectCode FROM Section INNER JOIN ClassSection ON Section.SectionID = ClassSection.Section_ID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Subject INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN School ON Subject.SchoolID = School.SchoolID ON Class.ClassID = Subject.ClassID WHERE SubjectName = '" + cmbSubjectName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSubjectID.Text = rdr.GetValue(0).ToString().Trim();
                    txtSubjectCode.Text = rdr.GetValue(1).ToString().Trim();
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

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtOMTheory_TextChanged(object sender, EventArgs e)
        {
            if (txtMaxMarksT.Text=="")
            {
                MessageBox.Show("Enter Maximum Marks of Theory", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOMTheory.Text = "";
                txtMaxMarksT.Focus();
                return;
            }

            decimal val1 = 1;
            decimal val2 = 1;
            decimal.TryParse(txtMaxMarksT.Text, out val1);
            decimal.TryParse(txtOMTheory.Text, out val2);
            if ((((val2) * 100) / (val1)) >= 90 & (((val2) * 100) / (val1)) <= 100)
            {
                txtOGTheory.Text = "A+";
            }
            if ((((val2) * 100) / (val1)) >= 80 & (((val2) * 100) / (val1)) <= 89)
            {
                txtOGTheory.Text = "A";
            }
            if ((((val2) * 100) / (val1)) >= 70 & (((val2) * 100) / (val1)) <= 79)
            {
                txtOGTheory.Text = "B+";
            }
            if ((((val2) * 100) / (val1)) >= 60 & (((val2) * 100) / (val1)) <= 69)
            {
                txtOGTheory.Text = "B";
            }
            if ((((val2) * 100) / (val1)) >= 50 & (((val2) * 100) / (val1)) <= 59)
            {
                txtOGTheory.Text = "C+";
            }
            if ((((val2) * 100) / (val1)) >= 40 & (((val2) * 100) / (val1)) <= 49)
            {
                txtOGTheory.Text = "C";
            }
            if ((((val2) * 100) / (val1)) >= 33 & (((val2) * 100) / (val1)) <= 39)
            {
                txtOGTheory.Text = "D";
            }
            if ((((val2) * 100) / (val1)) >= 0 & (((val2) * 100) / (val1)) <= 33)
            {
                txtOGTheory.Text = "E";
            }

            if (string.IsNullOrEmpty(txtOMTheory.Text))
            {
               txtOGTheory.Text="";
            }
      FinalGrade();
      GetGradePoint();
        }

        private void txtOMPractical_TextChanged(object sender, EventArgs e)
        {
            if (txtMaxMarksP.Text == "")
            {
                MessageBox.Show("Enter Maximum Marks of Practical", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOMPractical.Text = "";
                txtMaxMarksP.Focus();
                return;
            }
             decimal val8 = 1;
            decimal val9 = 1;
           decimal.TryParse(txtMaxMarksP.Text, out val8);
            decimal.TryParse(txtOMPractical.Text, out val9);
           
            if ((((val9) * 100) / (val8)) >= 90 & (((val9) * 100) / (val8)) <= 100)
                {
                    txtOGPractical.Text = "A+";
                }
                if ((((val9) * 100) / (val8)) >= 80 & (((val9) * 100) / (val8)) <= 89)
                {
                    txtOGPractical.Text = "A";
                }
                if ((((val9) * 100) / (val8)) >= 70 & (((val9) * 100) / (val8)) <= 79)
                {
                    txtOGPractical.Text = "B+";
                }
                if ((((val9) * 100) / (val8)) >= 60 & (((val9) * 100) / (val8)) <= 69)
                {
                    txtOGPractical.Text = "B";
                }
                if ((((val9) * 100) / (val8)) >= 50 & (((val9) * 100) / (val8)) <= 59)
                {
                    txtOGPractical.Text = "C+";
                }
                if ((((val9) * 100) / (val8)) >= 40 & (((val9) * 100) / (val8)) <= 49)
                {
                    txtOGPractical.Text = "C";
                }
                if ((((val9) * 100) / (val8)) >= 33 & (((val9) * 100) / (val8)) <= 39)
                {
                    txtOGPractical.Text = "D";
                }
                if ((((val9) * 100) / (val8)) >= 0 & (((val9) * 100) / (val8)) <= 33)
                {
                    txtOGPractical.Text = "E";
                }

                if (string.IsNullOrEmpty(txtOMPractical.Text))
                {
                    txtOGPractical.Text = "";
                }
    
            FinalGrade();
            GetGradePoint();
        }

        private void txtOGTheory_TextChanged(object sender, EventArgs e)
        {

        }
        public void GetGradePoint()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT GradePoint from Grades where Grade=@d1";
                cmd.Parameters.AddWithValue("@d1", txtFinalGrade.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtGradePoint.Text = rdr.GetValue(0).ToString();
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
        public void clear()
        {
       
            txtGradePoint.Text = "";
            txtFinalGrade.Text = "";
            txtOGTheory.Text = "";
            txtOGPractical.Text = "";
            txtOMTheory.Text = "";
            txtOMPractical.Text = "";
            txtMaxMarksP.Text = "";
            txtMaxMarksT.Text = "";
            txtCreditPoint.Text = "";
            txtSubjectCode.Text = "";
            cmbSubjectName.SelectedIndex = -1;
            txtStatus.SelectedIndex = -1;
            btnAdd.Enabled = true;
        }
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT MAX(M_ID+1) FROM MarksEntry";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtMarksID.Text = Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtMarksID.Text = Convert.ToString(Num);
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
        private void frmFinalMarksEntry_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtMaxMarksT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }
        public void Reset()
        {
            txtAdmissionNo.Text = "";
            txtClass.Text = "";
            txtSection.Text = "";
             txtEnrollmentNo.Text = "";
           txtSchoolName.Text = "";
            txtStudentName.Text = "";
            txtSubjectCode.Text = "";
            txtSession.Text = "";
            cmbSubjectName.SelectedIndex = -1;
            DataGridView1.Rows.Clear();
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnRemovelist.Enabled = false;
            btnPrint.Enabled = false;
            btnPrint2.Enabled = false;
            rbPass.Checked = true;
            rbFail.Checked = false;
            clear();
             Crypto();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
            if (txtStatus.Text == "Present")
            {
                decimal val11 = 0;
                decimal val12 = 0;
                decimal.TryParse(txtMaxMarksT.Text, out val11);
                decimal.TryParse(txtOMTheory.Text, out val12);

                decimal val18 = 0;
                decimal val19 = 0;
                decimal.TryParse(txtMaxMarksP.Text, out val18);
                decimal.TryParse(txtOMPractical.Text, out val19);
                if (string.IsNullOrEmpty(cmbSubjectName.Text))
                {
                    MessageBox.Show("Please select subject name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubjectName.Focus();
                    return;
                }
                if (((val11 + val18) > 100 | (val11 + val18) < 100))
                {
                    MessageBox.Show("Max. Marks(T) + Max Marks(P) must be equal to 100", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtCreditPoint.Text))
                {
                    MessageBox.Show("Please enter credit point", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCreditPoint.Focus();
                    return;
                }
                if ((string.IsNullOrEmpty(txtOMPractical.Text)) & (string.IsNullOrEmpty(txtOMTheory.Text)))
                {
                    MessageBox.Show("Please enter obtained marks", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (((val19 + val12) > 100))
                {
                    MessageBox.Show("Obtained marks(Theory + Practical) must be less than or equal to 100", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {
                    if (cmbSubjectName.Text == row.Cells[2].Value.ToString())
                    {
                        MessageBox.Show("Subject already added", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DataGridView1.Rows.Add(txtSubjectID.Text, txtSubjectCode.Text, cmbSubjectName.Text, txtStatus.Text, txtMaxMarksT.Text, txtMaxMarksP.Text, txtCreditPoint.Text, txtOMTheory.Text, txtOMPractical.Text, txtOGTheory.Text, txtOGPractical.Text, txtFinalGrade.Text, txtGradePoint.Text);
                clear();
            }
            if (txtStatus.Text == "Absent")
            {
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {
                    if (cmbSubjectName.Text == row.Cells[2].Value.ToString())
                    {
                        MessageBox.Show("Subject already added", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DataGridView1.Rows.Add(txtSubjectID.Text, txtSubjectCode.Text, cmbSubjectName.Text, txtStatus.Text, txtMaxMarksT1.Text, txtMaxMarksP1.Text, txtCreditPoint1.Text, txtOMT1.Text, txtOMP1.Text, txtOGT1.Text, txtOGP1.Text, txtFinalGrade1.Text, txtGradepoint1.Text);
                clear();
            }

          
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemovelist_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridView1.SelectedRows)
            {
                DataGridView1.Rows.Remove(row);
            }
           btnRemovelist.Enabled = false;
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                btnRemovelist.Enabled = true;
            }
            btnRemovelist.Enabled = true;
        }
        public void D1()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb1 = "insert into MarksEntry_Join(MarksID,Subject_ID,Status, MaxMarks,MMPractical, CreditHours, OMTheory,OMPractical ,OGTheory, OGPractical, FinalGrade, GradePoint) VALUES (" + txtMarksID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
            cmd = new SqlCommand(cb1);
            cmd.Connection = con;
            cmd.Prepare();
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    cmd.Parameters.AddWithValue("@d1", Convert.ToInt32(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@d2", row.Cells[3].Value);
              
                    if ((row.Cells[4].Value.ToString() == ""))
                    {
                        cmd.Parameters.AddWithValue("@d3", "0.00");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@d3", Convert.ToDecimal(row.Cells[4].Value));
                    }
                
                    if ((row.Cells[5].Value.ToString() == ""))
                    {
                        cmd.Parameters.AddWithValue("@d4", "0.00");
                    }
                    else 
                    {
                        cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(row.Cells[5].Value));
                    }
                    cmd.Parameters.AddWithValue("@d5", Convert.ToDecimal(row.Cells[6].Value));
                    if ((row.Cells[7].Value.ToString() == ""))
                    {
                        cmd.Parameters.AddWithValue("@d6", "0.00");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@d6", Convert.ToDecimal(row.Cells[7].Value));
                    }
                   
                    if ((row.Cells[8].Value.ToString() == ""))
                    {
                        cmd.Parameters.AddWithValue("@d7", "0.00");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@d7", Convert.ToDecimal(row.Cells[8].Value));
                    }
                    cmd.Parameters.AddWithValue("@d8", row.Cells[9].Value);
                    cmd.Parameters.AddWithValue("@d9", row.Cells[10].Value);
                    cmd.Parameters.AddWithValue("@d10", row.Cells[11].Value);
                    cmd.Parameters.AddWithValue("@d11", Convert.ToDecimal(row.Cells[12].Value));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAdmissionNo.Text == "")
            {
                MessageBox.Show("Please retrieve student info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add subject and grade info in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select Session,AdmissionNo from MarksEntry where Session=@d1 and AdmissionNo=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                cmd.Parameters.AddWithValue("@d2", txtAdmissionNo.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record already exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                if (rbPass.Checked == true)
                {
                    stX = rbPass.Text;
                }
                else
                {
                    stX = rbFail.Text;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into MarksEntry(M_ID, AdmissionNo,StudentSchool,Session,StudentClass,StudentSection,EntryDate,Result) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtMarksID.Text);
                cmd.Parameters.AddWithValue("@d2", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
                cmd.Parameters.AddWithValue("@d5", txtClass.Text);
                cmd.Parameters.AddWithValue("@d6", txtSection.Text);
                cmd.Parameters.AddWithValue("@d7", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@d8", stX);
                cmd.ExecuteNonQuery();
                con.Close();
                D1();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                btnAdd.Enabled = false;
                btnRemovelist.Enabled = false;
                btnPrint.Enabled = true;
                btnPrint2.Enabled = true;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtMaxMarksT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtAdmissionNo.Text == "")
                {
                    MessageBox.Show("Please retrieve student info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdmissionNo.Focus();
                    return;
                }
                if (DataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Please add subject and grade info in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {

                    if ((txtSession.Text) != (txtSession1.Text) || (txtAdmissionNo.Text) != (txtAdmissionNo1.Text))
                    {

                        con = new SqlConnection(cs.ReadfromXML());
                        con.Open();
                        string ct = "SELECT MarksEntry.AdmissionNo, MarksEntry.Session, Subject.SubjectName FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID INNER JOIN Subject ON MarksEntry_Join.Subject_ID = Subject.SubjectID where Session=@d1 and AdmissionNo=@d2 and SubjectName=@d3";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                        cmd.Parameters.AddWithValue("@d2", txtAdmissionNo.Text);
                        cmd.Parameters.AddWithValue("@d3", cmbSubjectName.Text);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            MessageBox.Show("Record already exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            return;
                        }
                    }
                }
                if (rbPass.Checked == true)
                {
                    stX = rbPass.Text;
                }
                else
                {
                    stX = rbFail.Text;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update MarksEntry set AdmissionNo=@d2,StudentSchool=@d3,Session=@d4,StudentClass=@d5,StudentSection=@d6,Result=@d8 Where M_ID=@d1 ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtMarksID.Text);
                cmd.Parameters.AddWithValue("@d2", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
                cmd.Parameters.AddWithValue("@d5", txtClass.Text);
                cmd.Parameters.AddWithValue("@d6", txtSection.Text);
                cmd.Parameters.AddWithValue("@d8", stX);
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from MarksEntry_Join where MarksID='" + txtMarksID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                D1();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                btnPrint2.Enabled = true;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from MarksEntry where M_ID='" + txtMarksID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmFinalMarksList  frm = new  frmFinalMarksList(this);
            frm.lblUser.Text = lblUser.Text;
            frm.lblSET.Text = "R3";
            frm.ShowDialog();
        }

        private void txtOGPractical_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void txtOMPractical_Validating(object sender, CancelEventArgs e)
        {
            decimal val5 = 1;
            decimal val6 = 1;
            decimal.TryParse(txtMaxMarksP.Text, out val5);
            decimal.TryParse(txtOMPractical.Text, out val6);
            if (val6 > val5)
            {
                MessageBox.Show("Obtained marks must be less than or equal to max. marks", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOMTheory.Focus();
            }
        }

        private void txtOMTheory_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtOMTheory_Validating(object sender, CancelEventArgs e)
        {
            decimal val5 = 1;
            decimal val6 = 1;
            decimal.TryParse(txtMaxMarksT.Text, out val5);
            decimal.TryParse(txtOMTheory.Text, out val6);
            if (val6 > val5)
            {
                MessageBox.Show("Obtained marks must be less than or equal to max. marks", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOMTheory.Focus();
            }
        }

        private void txtOMPractical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtOMTheory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

          if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCreditPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

          if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMaxMarksP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

      private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Present")
            {
                txtMaxMarksP1.Visible = false;
                txtMaxMarksT1.Visible = false;
                txtOMT1.Visible = false;
                txtOMP1.Visible = false;
                txtGradepoint1.Visible = false;
                txtFinalGrade1.Visible = false;
                txtOGT1.Visible = false;
                txtOGP1.Visible = false;
                txtCreditPoint1.Visible = false;

            }
            if (txtStatus.Text == "Absent")
            {
               txtMaxMarksP1.Visible  = true;
               txtMaxMarksT1.Visible = true;
               txtOMT1.Visible = true;
               txtOMP1.Visible = true;
               txtGradepoint1.Visible = true;
               txtFinalGrade1.Visible = true;
               txtOGT1.Visible = true;
               txtOGP1.Visible = true;
                 txtCreditPoint1.Visible = true;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAdmissionNo.Text))
                {
                    MessageBox.Show("Please retrieve Admission No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdmissionNo.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT  MarksEntry_Join.TBID, MarksEntry.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Student.FatherName, Student.MotherName, Student.Gender, Student.DOB, Student.Photo, MarksEntry.StudentSchool, MarksEntry.Session,MarksEntry.StudentClass, MarksEntry.StudentSection, MarksEntry.Result, MarksEntry_Join.Subject_ID, Subject.SubjectCode, Subject.SubjectName, MarksEntry_Join.MaxMarks, MarksEntry_Join.MMPractical,MarksEntry_Join.CreditHours, MarksEntry_Join.OMTheory, MarksEntry_Join.OMPractical, MarksEntry_Join.OGTheory, MarksEntry_Join.OGPractical, MarksEntry_Join.FinalGrade, MarksEntry_Join.GradePoint,MarksEntry_Join.Status FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID INNER JOIN Subject ON MarksEntry_Join.Subject_ID = Subject.SubjectID INNER JOIN Student ON Student.AdmissionNo = MarksEntry.AdmissionNo where marksentry.admissionno='" + txtAdmissionNo.Text + "'", con);
                cmd1 = new SqlCommand("SELECT * FROM school  where SchoolName='" + txtSchoolName.Text + "'", con);
                adp = new SqlDataAdapter(cmd);
                adp1 = new SqlDataAdapter(cmd1);
                DataTable table = new DataTable();
                DataTable table1 = new DataTable();
                adp.Fill(table);
                adp1.Fill(table1);
                ds = new DataSet();
                con.Close();
                ds.Tables.Add(table);
                ds.Tables.Add(table1);
                ds.WriteXmlSchema("V2.xml");
                RptSheet rpt = new RptSheet();
                rpt.SetDataSource(ds);
               frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAdmissionNo.Text))
                {
                    MessageBox.Show("Please retrieve Admission No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdmissionNo.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT  MarksEntry_Join.TBID, MarksEntry.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Student.FatherName, Student.MotherName, Student.Gender, Student.DOB, Student.Photo, MarksEntry.StudentSchool, MarksEntry.Session,MarksEntry.StudentClass, MarksEntry.StudentSection, MarksEntry.Result, MarksEntry_Join.Subject_ID, Subject.SubjectCode, Subject.SubjectName, MarksEntry_Join.MaxMarks, MarksEntry_Join.MMPractical,MarksEntry_Join.CreditHours, MarksEntry_Join.OMTheory, MarksEntry_Join.OMPractical, MarksEntry_Join.OGTheory, MarksEntry_Join.OGPractical, MarksEntry_Join.FinalGrade, MarksEntry_Join.GradePoint,MarksEntry_Join.Status FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID INNER JOIN Subject ON MarksEntry_Join.Subject_ID = Subject.SubjectID INNER JOIN Student ON Student.AdmissionNo = MarksEntry.AdmissionNo where marksentry.admissionno='" + txtAdmissionNo.Text + "'", con);
                cmd1 = new SqlCommand("SELECT * FROM school  where SchoolName='" + txtSchoolName.Text + "'", con);
                adp = new SqlDataAdapter(cmd);
                adp1 = new SqlDataAdapter(cmd1);
                DataTable table = new DataTable();
                DataTable table1 = new DataTable();
                adp.Fill(table);
                adp1.Fill(table1);
                ds = new DataSet();
                con.Close();
                ds.Tables.Add(table);
                ds.Tables.Add(table1);
                ds.WriteXmlSchema("V1.xml");
               Sheet2 rpt = new Sheet2();
                rpt.SetDataSource(ds);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();

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

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from Student's List");
        }

        private void txtMaxMarksT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
