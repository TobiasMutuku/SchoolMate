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
    public partial class frmJournalAndMagazinesBilling : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmJournalAndMagazinesBilling()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            txtBillNo.Text = "";
            txtSubNo.Text = "";
            dtpBillDate.Text = System.DateTime.Now.ToString();
            dtpPaidOn.Text = System.DateTime.Now.ToString();
            txtAmount.Text = "";
            txtIssueNo.Text = "";
            txttitle.Text = "";
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            txttitle.Focus();
            func();
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmJournalAndMagazinesBilling_Load(object sender, EventArgs e)
        {
         for (int i = 2010; i <= 2050; i++)
            {
                cmbYear.Items.Add(i);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
           
             if (txttitle.Text == "")
                {
                    MessageBox.Show("Please Retrive Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttitle.Focus();
                    return;
                }
                if (txtSubNo.Text == "")
                {
                    MessageBox.Show("Please Retrive SubscriptionNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Focus();
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    MessageBox.Show("Please Enter BillNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBillNo.Focus();
                    return;
                }
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Bill Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please Select month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (cmbYear.Text == "")
                {
                    MessageBox.Show("Please Select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYear.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select Sub_No,Month,Year from JMB where Sub_no='" + txtSubNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Bill of This Month Already Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Text = "";
                    txtSubNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into JMB(Sub_No,BillNo, BillDate,Amount,Paidon,IssueNo,Month,Year) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtBillNo.Text);
                cmd.Parameters.AddWithValue("@d3", dtpBillDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtAmount.Text);
                cmd.Parameters.AddWithValue("@d5", dtpPaidOn.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtIssueNo.Text);
                cmd.Parameters.AddWithValue("@d7", cmbMonth.Text);
                cmd.Parameters.AddWithValue("@d8", cmbYear.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                 MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazinesList frm = new frmJournalAndMagazinesList(this);
            frm.lblSET.Text = "R1";
            frm.Show();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {

                if (txttitle.Text == "")
                {
                    MessageBox.Show("Please Retrive Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttitle.Focus();
                    return;
                }
                if (txtSubNo.Text == "")
                {
                    MessageBox.Show("Please Retrive SubscriptionNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Focus();
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    MessageBox.Show("Please Enter BillNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBillNo.Focus();
                    return;
                }
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Bill Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please Select month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (cmbYear.Text == "")
                {
                    MessageBox.Show("Please Select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYear.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update JMB Set BillNo=@d2, BillDate=@d3,Amount=@d4,Paidon=@d5,IssueNo=@d6,Month=@d7,Year=@d8 where Sub_No=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtBillNo.Text);
                cmd.Parameters.AddWithValue("@d3", dtpBillDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtAmount.Text);
                cmd.Parameters.AddWithValue("@d5", dtpPaidOn.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtIssueNo.Text);
                cmd.Parameters.AddWithValue("@d7", cmbMonth.Text);
                cmd.Parameters.AddWithValue("@d8", cmbYear.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated Billing Info", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
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
                string cq1 = "delete from JMB  where JMBID=" + txtJMB.Text + "";
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
           frmJournalAndMagazineBillingList frm = new  frmJournalAndMagazineBillingList(this);
            frm.lblSET.Text = "R2";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
