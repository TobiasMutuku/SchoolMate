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
    public partial class frmBusEntry : Form
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
        public frmBusEntry()
        {
            InitializeComponent();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm1 = "select Bus_ID from StaffBusHolder where Bus_ID='" + txtBusID.Text + "'";
                cmd = new SqlCommand(ctm1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Bus using on StaffBusHolder List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBusID.Text = "";
                    Reset();
                    txtBusID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm2 = "select Bus_ID from StudentBusHolder where Bus_ID='" + txtBusID.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Bus using on Student BusHolder List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBusID.Text = "";
                    Reset();
                    txtBusID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Bus where BusID='" + txtBusID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted Bus having BusNo'" + txtBusNo.Text + "'";
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
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BusID),Rtrim(BusNo),Rtrim(DriverName),Rtrim(ContactNo),Rtrim(SupporterName),Rtrim(Scontactno) FROM  Bus", con);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBusNo.Text == "")
                {
                    MessageBox.Show("Please enter BusNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBusNo.Focus();
                    return;
                }
                if (txtDriverName.Text == "")
                {
                    MessageBox.Show("Please enter Driver Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDriverName.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contactno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select BusNo from Bus where BusNo='" + txtBusNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("BusNo Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string cb = "insert into Bus(BusNo, DriverName, ContactNo, SupporterName, Scontactno) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtBusNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@d3", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@d4", txtSupporterName.Text);
                cmd.Parameters.AddWithValue("@d5", txtContactNo_S.Text);
                cmd.ExecuteNonQuery();
                con.Close();
               GetData();
               st1 = lblUser.Text;
               st2 = "New Bus is Added having BusNo'" + txtBusNo.Text + "'";
               cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
        txtDriverName.Text = "";
        txtSupporterName.Text = "";
        txtContactNo.Text = "";
        txtContactNo_S.Text = "";
        txtBusID.Text = "";
        txtBusNo.Text = "";
        txtBusNo.Focus();
        btnSave.Enabled = true;
        btnUpdate_record.Enabled = false;
        btnDelete.Enabled = false;
        GetData();
        }
        private void frmBusEntry_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb2 = "Update Bus set BusNo= '" + txtBusNo.Text + "',DriverName= '" + txtDriverName.Text + "',ContactNo= '" + txtContactNo.Text + "',SupporterName= '" + txtSupporterName.Text + "',Scontactno= '" + txtContactNo_S.Text + "' where BusID='" + txtBusID.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "Bus is Updated having BusNo'" + txtBusNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", " Bus Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtBusID.Text = dr.Cells[0].Value.ToString();
                txtBusNo.Text = dr.Cells[1].Value.ToString();
                txtDriverName.Text = dr.Cells[2].Value.ToString();
                txtContactNo.Text = dr.Cells[3].Value.ToString();
                txtSupporterName.Text = dr.Cells[4].Value.ToString();
                txtContactNo_S.Text = dr.Cells[5].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtContactNo_S_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtContactNo_S_Validating(object sender, CancelEventArgs e)
        {
            if (txtContactNo_S.TextLength >= 15)
            {
                MessageBox.Show("Mobile Number Can not be Greater than 15 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo_S.Focus();
                return;
            }
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
    }
}
