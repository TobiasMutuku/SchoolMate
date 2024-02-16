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
    public partial class frmBusHolderStaff : Form
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
        public frmBusHolderStaff()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmEmployeeList frm = new frmEmployeeList(this);
            frm.lblSET.Text = "S";
            frm.Show();
        }
        public void Fill()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(BusNO) FROM Bus ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtBusNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillLocation()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Location) FROM Locations ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtLocationName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBusHolderStaff_Load(object sender, EventArgs e)
        {
            Fill();
            FillLocation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please Retrive Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffID.Focus();
                    return;
                }
                if (txtBusNo.Text == "")
                {
                    MessageBox.Show("Please enter BusNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBusNo.Focus();
                    return;
                }
               
                if (txtLocationName.Text == "")
                {
                    MessageBox.Show("Please enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocationName.Focus();
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
                string ct = "select Rtrim(Staffid) from StaffBusHolder where Staffid='" + txtStaffID.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBusNo.Text = "";
                    txtBusNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into StaffBusHolder(StaffID, Bus_ID, Location_ID, JoiningDate, Status) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtStaffID.Text);
                cmd.Parameters.AddWithValue("@d2", txtBusID.Text);
                cmd.Parameters.AddWithValue("@d3", txtLocationID.Text);
                cmd.Parameters.AddWithValue("@d4", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", txtStatus.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "New BusHolder '" + txtStaffName.Text + " is Added Successfully  Having StaffID'" + txtStaffID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(BusID) FROM Bus WHERE BusNo = '" + txtBusNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBusID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void txtLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(LocationID) FROM Locations WHERE Location = '" + txtLocationName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtLocationID.Text = rdr.GetValue(0).ToString().Trim();
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
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm3 = "select StaffBusHolder_ID from StaffBusFeesPayment where StaffBusHolder_ID='" + txtStaffBusHolderID.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Exam using on Staff's BusFee Payment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStaffBusHolderID.Text = "";
                    Reset();
                    txtStaffBusHolderID.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from StaffBusHolder where StaffBusHolderID='" + txtStaffBusHolderID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "BusHolder '" + txtStaffName.Text + " is Deleted Successfully  Having StaffID'" + txtStaffID.Text + "'";
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
        public void Reset()
        {
            txtJoiningDate.Text = System.DateTime.Now.ToString();
            txtStatus.SelectedIndex = -1;
            txtBusNo.SelectedIndex = -1;
            txtStaffName.Text = "";
            txtBusID.Text = "";
            txtStaffBusHolderID.Text = "";
            txtStaffID.Text = "";
            txtMaxID.Text = "";
            txtSchoolID.Text = "";
            txtDepartment.Text = "";
            txtdesignation.Text = "";
            txtSchoolName.Text = "";
            txtLocationName.SelectedIndex = -1;
            txtBusNo.DropDownStyle = ComboBoxStyle.DropDownList;
            txtLocationName.DropDownStyle = ComboBoxStyle.DropDownList;
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            txtStaffID.Focus();
        }
        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please Retrive Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffID.Focus();
                    return;
                }
                if (txtBusNo.Text == "")
                {
                    MessageBox.Show("Please enter BusNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBusNo.Focus();
                    return;
                }

                if (txtLocationName.Text == "")
                {
                    MessageBox.Show("Please enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocationName.Focus();
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
                string cb = "update Staffbusholder set Staffid=@d2,Bus_ID=@d3,Location_ID=@d4,JoiningDate=@d5,Status=@d6 where StaffbusholderID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtStaffBusHolderID.Text);
                cmd.Parameters.AddWithValue("@d2", txtStaffID.Text);
                cmd.Parameters.AddWithValue("@d3", txtBusID.Text);
                cmd.Parameters.AddWithValue("@d4", txtLocationID.Text);
                cmd.Parameters.AddWithValue("@d5", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtStatus.Text);
                cmd.ExecuteReader();
                st1 = lblUser.Text;
                st2 = "BusHolder '" + txtStaffName.Text + " is Updated Successfully  Having StaffID'" + txtStaffID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Staff Busholder Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            } 

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmBusHolderStaffList  frm = new frmBusHolderStaffList(this);
            frm.lblSET.Text = "R0";
            frm.ShowDialog();
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Staff info from Staff List");
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
