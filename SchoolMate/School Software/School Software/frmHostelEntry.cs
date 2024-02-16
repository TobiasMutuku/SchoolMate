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
    public partial class frmHostelEntry : Form
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
        public frmHostelEntry()
        {
            InitializeComponent();
        }
        public void Reset()
        {
        txtAddress.Text = "";
        txtIncharge.Text = "";
        txtMobile.Text = "";
        txtPhoneNo.Text = "";
        txthostelID.Text = "";
        txtHostelName.Text = "";
        txtHostelName.Focus();
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
        GetData();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(HostelID),Rtrim(Hostelname),Rtrim(Address),Rtrim(Incharge),Rtrim(Phone),Rtrim(Mobile) FROM Hostel", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
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
                string ctm1 = "select HostelNames from HostelFeesPayment where HostelNames='" + txtHostelName.Text + "'";
                cmd = new SqlCommand(ctm1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Hostel using on HostelFeesPayment list Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtHostelName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm2 = "select Hostel_ID from Hosteler where Hostel_ID='" + txthostelID.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Hostel using on Student's Hosteler list Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtHostelName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm3 = "select Hostel_ID from HostelInstallment where Hostel_ID='" + txthostelID.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Hostel using on HostelInstallment Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtHostelName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Hostel where hostelID='" + txthostelID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted Hostel  '" + txtHostelName.Text + "'";
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
        private void frmHostelEntry_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHostelName.Text == "")
                {
                    MessageBox.Show("Please enter hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
                if (txtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please enter Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("Please enter Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobile.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select HostelName from Hostel where HostelName='" + txtHostelName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Hostel Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelName.Text = "";
                    txtHostelName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into Hostel(HostelName,Address,incharge,Phone,mobile) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtHostelName.Text);
                cmd.Parameters.AddWithValue("@d2", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d4", txtIncharge.Text);
                cmd.Parameters.AddWithValue("@d5", txtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@d6", txtMobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "added New  Hostel  '" + txtHostelName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

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
                if (txtHostelName.Text == "")
                {
                    MessageBox.Show("Please enter hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
                if (txtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please enter Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("Please enter Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobile.Focus();
                    return;
                }
               con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "update Hostel set Hostelname=@d2,address=@d3,Incharge=@d4,Phone=@d5,mobile=@d6 where HostelID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txthostelID.Text);
                cmd.Parameters.AddWithValue("@d2", txtHostelName.Text);
                cmd.Parameters.AddWithValue("@d3", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d4", txtIncharge.Text);
                cmd.Parameters.AddWithValue("@d5", txtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@d6", txtMobile.Text);
                cmd.ExecuteReader();
                GetData(); 
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
               con.Close();
               con = new SqlConnection(cs.ReadfromXML());
               con.Open();
               string cb3 = "Update HostelFeesPayment set Hostelnames= '" + txtHostelName.Text + "' where Hostelnames='" + textBox1.Text + "'";
               cmd = new SqlCommand(cb3);
               cmd.Connection = con;
               cmd.ExecuteReader();
               st1 = lblUser.Text;
               st2 = "Updated Hostel  '" + txtHostelName.Text + "'";
               cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully updated", "Hostel Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnUpdate.Enabled = false;
               con.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
                GetData();
            } 
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txthostelID.Text = dr.Cells[0].Value.ToString();
                txtHostelName.Text = dr.Cells[1].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                txtAddress.Text = dr.Cells[2].Value.ToString();
                txtIncharge.Text = dr.Cells[3].Value.ToString();
                txtPhoneNo.Text = dr.Cells[4].Value.ToString();
                txtMobile.Text = dr.Cells[5].Value.ToString();
                btnSave.Enabled = false;
                 btnUpdate.Enabled = true;
                 btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
