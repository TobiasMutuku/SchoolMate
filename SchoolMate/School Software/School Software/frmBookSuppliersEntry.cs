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
    public partial class frmBookSuppliersEntry : Form
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
        string txtStatus1 = null;
        string txtStatus2 = null;
        string txtStatus3 = null;
        public frmBookSuppliersEntry()
        {
            InitializeComponent();
        }
        public void Reset()
        {
        txtSupplierName.Text = "";
        txtAddress.Text = "";
        txtRemarks.Text = "";
        txtSupplierID.Text = "";
        txtSupplierMax.Text = "";
        txtContactNo.Text = "";
        txtEmailID.Text = "";
        chkBooks.Checked = false;
        ChkJM.Checked = false;
        ChkNewsPaper.Checked = false;
        txtSupplierName.Focus();
        Auto();
        btnSave.Enabled = true;
        btnUpdate_record.Enabled = false;
        btnDelete.Enabled = false;
    }
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT MAX(SupplierID+1) FROM Supplier";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtSupplierID.Text = Convert.ToString(Num);
                    txtSupplierMax.Text = Convert.ToString("SP-" + Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtSupplierID.Text = Convert.ToString(Num);
                    txtSupplierMax.Text = Convert.ToString("SP-" + Num);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierName.Text == "")
                {
                    MessageBox.Show("Please enter Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSupplierName.Focus();
                    return;
                }
                if ((chkBooks.Checked == false & ChkJM.Checked == false & ChkNewsPaper.Checked == false))
                {
                    MessageBox.Show("Please select Supplier Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contactno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if ((chkBooks.Checked == true))
                {
                    txtStatus1 = "Yes";
                }
                else
                {
                    txtStatus1 = "No";
                }
                if ((ChkNewsPaper.Checked == true))
                {
                    txtStatus2 = "Yes";
                }
                else
                {
                    txtStatus2 = "No";
                }
                if ((ChkJM.Checked == true))
                {
                    txtStatus3 = "Yes";
                }
                else
                {
                    txtStatus3 = "No";
                }
                Crypto();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into Supplier(SupplierID,SupplierMax,SupplierName,S_Books, S_NewsPaper, S_Magazines, Address, ContactNo, EmailID,Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSupplierMax.Text);
                cmd.Parameters.AddWithValue("@d3", txtSupplierName.Text);
                cmd.Parameters.AddWithValue("@d4", txtStatus1);
                cmd.Parameters.AddWithValue("@d5", txtStatus2);
                cmd.Parameters.AddWithValue("@d6", txtStatus3);
                cmd.Parameters.AddWithValue("@d7", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d8", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@d9", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@d10", txtRemarks.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Auto();
                st1 = lblUser.Text;
                st2 = "New Book Supplier '" + txtSupplierName.Text + "' is Added";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SupplierID),RTRIM(SupplierMax),RTRIM(SupplierName),RTRIM(S_Books),RTRIM(S_NewsPaper), RTRIM(S_Magazines), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks) from supplier order by supplierid", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBookSuppliersEntry_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierName.Text == "")
                {
                    MessageBox.Show("Please enter Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSupplierName.Focus();
                    return;
                }
                if ((chkBooks.Checked == false & ChkJM.Checked == false & ChkNewsPaper.Checked == false))
                {
                    MessageBox.Show("Please select Supplier Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contactno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if ((chkBooks.Checked == true))
                {
                    txtStatus1 = "Yes";
                }
                else
                {
                    txtStatus1 = "No";
                }
                if ((ChkNewsPaper.Checked == true))
                {
                    txtStatus2 = "Yes";
                }
                else
                {
                    txtStatus2 = "No";
                }
                if ((ChkJM.Checked == true))
                {
                    txtStatus3 = "Yes";
                }
                else
                {
                    txtStatus3 = "No";
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update Supplier set SupplierMax=@d2,SupplierName=@d3,S_Books=@d4, S_NewsPaper=@d5, S_Magazines=@d6, Address=@d7, ContactNo=@d8, EmailID=@d9,Remarks=@d10 where SupplierID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSupplierMax.Text);
                cmd.Parameters.AddWithValue("@d3", txtSupplierName.Text);
                cmd.Parameters.AddWithValue("@d4", txtStatus1);
                cmd.Parameters.AddWithValue("@d5", txtStatus2);
                cmd.Parameters.AddWithValue("@d6", txtStatus3);
                cmd.Parameters.AddWithValue("@d7", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d8", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@d9", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@d10", txtRemarks.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Auto();
                st1 = lblUser.Text;
                st2 = "Book Supplier '" + txtSupplierName.Text + "' is Updated";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
              DataGridViewRow dr = DataGridView1.SelectedRows[0];
             txtSupplierID.Text = dr.Cells[0].Value.ToString();
            txtSupplierMax.Text = dr.Cells[1].Value.ToString();
            txtSupplierName.Text = dr.Cells[2].Value.ToString();
           
            if ((dr.Cells[3].Value.ToString() =="Yes" ))
            {
                chkBooks.Checked = true;
            }
            else
            {
                chkBooks.Checked = false;
            }
            
             if ((dr.Cells[4].Value.ToString() =="Yes" ))
             {
                ChkNewsPaper.Checked = true;
             }
             else
             {
                ChkNewsPaper.Checked = false;
             }
            if ((dr.Cells[5].Value.ToString() =="Yes" ))
            {
              ChkJM.Checked = true;
            }
            else
            {
                ChkJM.Checked = false;
            }
              txtAddress.Text = dr.Cells[6].Value.ToString();
            txtContactNo.Text = dr.Cells[7].Value.ToString();
            txtEmailID.Text = dr.Cells[8].Value.ToString();
            txtRemarks.Text = dr.Cells[9].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate_record.Enabled = true;
             btnDelete.Enabled = true;
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
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm6 = "select SupplierID from JM  where SupplierID='" + txtSupplierID.Text + "'";
                cmd = new SqlCommand(ctm6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Record using on Journal and Magazine List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSupplierID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm7 = "select SupplierID from Book where SupplierID='" + txtSupplierID.Text + "'";
                cmd = new SqlCommand(ctm7);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Record using on Books List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSupplierID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Supplier where SupplierID='" + txtSupplierID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "BookSupplier '" + txtSupplierName.Text + "' is Deleted";
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
                Auto();
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
