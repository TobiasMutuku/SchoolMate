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
    public partial class frmSchoolFeesEntry : Form
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
        public frmSchoolFeesEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Enter School Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Focus();
                    return;
                }
                if (cmbFeeName.Text == "")
                {
                    MessageBox.Show("Please select Fee Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFeeName.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please select Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (txtFee.Text == "")
                {
                    MessageBox.Show("Please Enter Fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFee.Focus();
                    return;
                }
              
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select distinct SchoolFees.class_ID ,FeeID,Month,School_ID  from Schoolfees,class,fee where class.ClassID=SchoolFees.Class_ID and Fee.ID=SchoolFees.FeeID and  class.classname='" + cmbClass.Text + "' and Fee.feename='" + cmbFeeName.Text + "' and  Month='" + cmbMonth.Text + "' and School_ID=" + txtSchoolID.Text + "";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Text = "";
                    Reset();
                    cmbClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into SchoolFees(Class_ID,FeeID,Fee,Month,School_ID) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtClassID.Text);
                cmd.Parameters.AddWithValue("@d2", txtFeeID.Text);
                cmd.Parameters.AddWithValue("@d3", txtFee.Text);
                cmd.Parameters.AddWithValue("@d4", cmbMonth.Text);
                cmd.Parameters.AddWithValue("@d5", txtSchoolID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Added the New School Fees having Class='" + cmbClass.Text + "' and FeeName='" + cmbFeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID FROM Fee where FeeName = '" + cmbFeeName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtFeeID.Text = rdr.GetInt32(0).ToString().Trim();
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
        private void Reset()
        {
            cmbClass.SelectedIndex = -1;
            cmbFeeName.SelectedIndex = -1;
            txtSchooFeesID.Text = "";
            txtFee.Text = "0.00";
            txtFeeID.Text = "";
            txtClassID.Text = "";
            txtSchoolName.SelectedIndex = -1;
            txtSchoolID.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            cmbMonth.SelectedIndex = -1;
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm1 = "SELECT CourseFeePayment_Join.FeeId, CourseFeePayment_Join.Month, SchoolFeesPayment.School, SchoolFeesPayment.ClassName FROM SchoolFeesPayment INNER JOIN CourseFeePayment_Join ON SchoolFeesPayment.SFP_ID = CourseFeePayment_Join.SF_PaymentID where CourseFeePayment_Join.FeeId=@d1 and CourseFeePayment_Join.Month=@d2 and SchoolFeesPayment.School=@d3 and SchoolFeesPayment.ClassName=@d4";
                cmd = new SqlCommand(ctm1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtFeeID.Text);
                cmd.Parameters.AddWithValue("@d2", cmbMonth.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d4", cmbClass.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Record using on SchoolFeesPayment list Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSchoolName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from SchoolFees where schoolFeeID='" + txtSchooFeesID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
               if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Deleted the School Fee having Class='" + cmbClass.Text + "' and FeeName='" + cmbFeeName.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Enter School Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Focus();
                    return;
                }
                if (cmbFeeName.Text == "")
                {
                    MessageBox.Show("Please select Fee Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFeeName.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please select Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (txtFee.Text == "")
                {
                    MessageBox.Show("Please Enter Fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFee.Focus();
                    return;
                }
                if ((txtClassID.Text) != (txtClassQ.Text) || (txtSchoolID.Text) != (txtSchoolQ.Text) || (txtFeeID.Text) != (txtFeeIDQ.Text) || (cmbMonth.Text) != (txtMonthQ.Text)) 
                {

                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct = "select distinct SchoolFees.class_ID ,FeeID,Month,School_ID  from Schoolfees,class,fee where class.ClassID=SchoolFees.Class_ID and Fee.ID=SchoolFees.FeeID and  class.classname='" + cmbClass.Text + "' and Fee.feename='" + cmbFeeName.Text + "' and  Month='" + cmbMonth.Text + "' and School_ID=" + txtSchoolID.Text + "";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbClass.Text = "";
                        Reset();
                        cmbClass.Focus();

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "select Rtrim(SchoolFeeID) from SchoolFees where SchoolFeeID='" + txtSchooFeesID.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb2 = "Update SchoolFees set month='" + cmbMonth.Text + "', Class_ID= '" + txtClassID.Text + "',FeeID= '" + txtFeeID.Text + "',Fee= '" + txtFee.Text + "',School_ID= " + txtSchoolID.Text + " where SchoolFeeID = '" + txtSchooFeesID.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Updated the School Fee having Class='" + cmbClass.Text + "' and FeeName='" + cmbFeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
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
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(ClassName),classid FROM class order by 2";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
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

        public void FillFee()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct RTRIM(FeeName) FROM Fee";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbFeeName.Items.Add(rdr[0]);
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
                while (rdr.Read())
                {
                    txtSchoolName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void frmSchoolFeesEntry_Load(object sender, EventArgs e)
        {
            FillClass();
            FillFee();
            FillSchool();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassID FROM Class where ClassName = '" + cmbClass.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassID.Text = rdr.GetInt32(0).ToString().Trim();
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
           frmSchoolFeesList frm = new frmSchoolFeesList(this);
            frm.lblSET.Text = "R1";
            frm.ShowDialog();
        }

        private void txtSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(SchoolID) FROM School where SchoolName = '" + txtSchoolName.Text + "'";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
