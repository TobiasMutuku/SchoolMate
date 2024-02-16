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
    public partial class frmHostelersStudent : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmHostelersStudent()
        {
            InitializeComponent();
        }
        public void Fill()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Hostelname) FROM Hostel ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtHostelName.Items.Clear();
                while (rdr.Read())
                {
                    txtHostelName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmHostelersStudent_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList(this);
            frm.lblSET.Text = "R2";
            frm.Show();
        }

        private void txtHostelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(HostelID) FROM Hostel WHERE HostelName = '" + txtHostelName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtHostelID.Text = rdr.GetValue(0).ToString().Trim();
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
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostelers Entry' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblSave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblSave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtAdmissionNo.Text == "")
                {
                    MessageBox.Show("Please Retrive Admissionno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdmissionNo.Focus();
                    return;
                }
                if (txtHostelName.Text == "")
                {
                    MessageBox.Show("Please enter HostelName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelName.Focus();
                    return;
                }
               
                if (txtStatus.Text == "")
                {
                    MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStatus.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select Admission_No from Hosteler where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string cb = "insert into Hosteler(Admission_No, Hostel_ID, JoiningDate, Status) VALUES (@d1,@d2,@d3,@d4)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtHostelID.Text);
                cmd.Parameters.AddWithValue("@d3", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtStatus.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Added Hosteler  '" + txtStudentName+ "' having AdmissionNo'"+txtAdmissionNo.Text+"'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdmissionNo.Text == "")
                {
                    MessageBox.Show("Please Retrive Admissionno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdmissionNo.Focus();
                    return;
                }
                if (txtHostelName.Text == "")
                {
                    MessageBox.Show("Please enter HostelName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelName.Focus();
                    return;
                }

                if (txtStatus.Text == "")
                {
                    MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStatus.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "update Hosteler set Admission_No=@d1,Hostel_ID=@d2,JoiningDate=@d3,Status=@d4 where HostelerID=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtHostelID.Text);
                cmd.Parameters.AddWithValue("@d3", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtStatus.Text);
                cmd.Parameters.AddWithValue("@d5", txtHostelerID.Text);
                cmd.ExecuteReader();
                st1 = lblUser.Text;
                st2 = "Updated Hosteler  '" + txtStudentName + "' having AdmissionNo'" + txtAdmissionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Student Hostelers Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            txtJoiningDate.Text = System.DateTime.Now.ToString();
            txtStatus.SelectedIndex = 0;
            txtHostelName.SelectedIndex = -1;
            txtHostelName.DropDownStyle =ComboBoxStyle.DropDownList;
            txtStudentName.Text = "";
            txtSection.Text = "";
            txtSession.Text = "";
            txtHostelerID.Text = "";
            txtAdmissionNo.Text = "";
            txtClass.Text = "";
            txtSchoolName.Text = "";
            Fill();
            func();
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            txtAdmissionNo.Focus();
          }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm2 = "select Hosteler_ID from HostelFeesPayment where Hosteler_ID='" + txtHostelerID.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Record using on HostelfeePayment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAdmissionNo.Text = "";
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
                string cq1 = "delete from Hosteler where HostelerID='" + txtHostelerID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted Hosteler  '" + txtStudentName + "' having AdmissionNo'" + txtAdmissionNo.Text + "'";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmHostelerStudentList frm = new frmHostelerStudentList(this);
            frm.lblSET.Text = "R1";
            frm.ShowDialog();
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from Student's List");
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
