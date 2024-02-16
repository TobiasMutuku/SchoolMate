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
    public partial class frmBusInstallments : Form
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
        public frmBusInstallments()
        {
            InitializeComponent();
        }
        public void FillLocation()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Location) FROM Locations";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtLocation.Items.Clear();
                while (rdr.Read())
                {
                    txtLocation.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBusInstallments_Load(object sender, EventArgs e)
        {
            Reset();
        }

        public void  Reset()
        {
        txtInstallment.Text = "";
        txtLocation.SelectedIndex = -1;
        txtCharges.Text = "0.00";
        txtlocationID.Text = "";
        txtIBID.Text = "";
        txtInstallment.Focus();
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
        txtSearchByLocation.Text = "";
        txtinstallment1.Text = "";
        txtLocation1.Text = "";
        FillLocation();
        GetData();
   }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT distinct Rtrim(BusInstallment.InstallmentID),Rtrim(BusInstallment.Installment),Rtrim(BusInstallment.Location_ID),Rtrim(Locations.Location), Rtrim(BusInstallment.Charges) FROM  BusInstallment INNER JOIN Locations ON BusInstallment.Location_ID = Locations.LocationID order by 2,3", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtInstallment.Text == "")
            {
                MessageBox.Show("Please Enter installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInstallment.Focus();
                return;
            }
            if (txtLocation.Text == "")
            {
                MessageBox.Show("Please Select location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
                return;
            }
            if (txtCharges.Text == "")
            {
                MessageBox.Show("Please Enter Charges", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCharges.Focus();
                return;
            }
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string ct = "SELECT BusInstallment.Installment, Locations.Location FROM BusInstallment INNER JOIN Locations ON BusInstallment.Location_ID = Locations.LocationID where Installment=@d1 and Location=@d2";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
            cmd.Parameters.AddWithValue("@d2", txtLocation.Text);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInstallment.Text = "";
                Reset();
                txtInstallment.Focus();

                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb = "insert into BusInstallment(Installment,Charges,Location_ID) VALUES (@d1,@d2,@d3)";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
            cmd.Parameters.AddWithValue("@d2", txtCharges.Text);
            cmd.Parameters.AddWithValue("@d3", txtlocationID.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetData();
            st1 = lblUser.Text;
            st2 = "New BusInstallment '" + txtInstallment.Text + " is Added Successfully  For Location'" + txtLocation.Text + "'";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
        }

        private void txtLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(Locations.LocationID) FROM Locations WHERE Location = '" + txtLocation.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtlocationID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInstallment.Text == "")
                {
                    MessageBox.Show("Please Enter installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInstallment.Focus();
                    return;
                }
                if (txtLocation.Text == "")
                {
                    MessageBox.Show("Please Select location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocation.Focus();
                    return;
                }
                if (txtCharges.Text == "")
                {
                    MessageBox.Show("Please Enter Charges", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCharges.Focus();
                    return;
                }
                if ((txtInstallment.Text) != (txtinstallment1.Text) || (txtLocation.Text) != (txtLocation1.Text))
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct = "SELECT BusInstallment.Installment, Locations.Location FROM BusInstallment INNER JOIN Locations ON BusInstallment.Location_ID = Locations.LocationID where Installment=@d1 and Location=@d2";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                    cmd.Parameters.AddWithValue("@d2", txtLocation.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInstallment.Text = "";
                        Reset();
                        txtInstallment.Focus();

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "update BusInstallment set Installment=@d1,Charges=@d2,Location_ID=@d3 where InstallmentID=@d4";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d2", txtCharges.Text);
                cmd.Parameters.AddWithValue("@d3", txtlocationID.Text);
                cmd.Parameters.AddWithValue("@d4", txtIBID.Text);
                cmd.ExecuteReader();
                GetData();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb1 = "update BusFeesPayment set Installment=@d1 where Installment=@d4";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d4", textBox1.Text);
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb2 = "update StaffBusFeesPayment set Installment=@d1 where Installment=@d4";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d4", textBox1.Text);
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                st1 = lblUser.Text;
                st2 = "BusInstallment '" + txtInstallment.Text + " is Updated Successfully  For Location'" + txtLocation.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Bus Installment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
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
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm5 = "select installment from Busfeespayment where installment=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "installment"));
                cmd.Parameters["@find"].Value = textBox1.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already Use in BusFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm6 = "select installment from StaffBusfeespayment where installment=@find";
                cmd = new SqlCommand(cm6);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "installment"));
                cmd.Parameters["@find"].Value = textBox1.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already Use in StaffBusFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from BusInstallment  where InstallmentID=" + txtIBID.Text + "";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "New BusInstallment '" + txtInstallment.Text + " is Deleted Successfully  For Location'" + txtLocation.Text + "'";
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtIBID.Text = dr.Cells[0].Value.ToString();
                txtInstallment.Text = dr.Cells[1].Value.ToString();
                txtinstallment1.Text = dr.Cells[1].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                txtlocationID.Text = dr.Cells[2].Value.ToString();
                txtLocation.Text = dr.Cells[3].Value.ToString();
                txtLocation1.Text = dr.Cells[3].Value.ToString();
                txtCharges.Text = dr.Cells[4].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                lblUser.Text = lblUser.Text;
                lblUserType.Text = lblUserType.Text;
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

        private void txtSearchByLocation_TextChanged(object sender, EventArgs e)
        {
             try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT  Rtrim(BusInstallment.InstallmentID),Rtrim(BusInstallment.Installment),Rtrim(BusInstallment.Location_ID),Rtrim(Locations.Location), Rtrim(BusInstallment.Charges) FROM  BusInstallment INNER JOIN Locations ON BusInstallment.Location_ID = Locations.LocationID where Location like '%" + txtSearchByLocation.Text + "%' order by 2,3", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
        }
    }
