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
    public partial class frmJournalAndMagazineBillingList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmJournalAndMagazinesBilling frm = null;
        public frmJournalAndMagazineBillingList()
        {
            InitializeComponent();
        }
        public frmJournalAndMagazineBillingList(frmJournalAndMagazinesBilling par)
        {
            frm = par;
            InitializeComponent();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(JMB.JMBID),Rtrim(JMB.Sub_No),Rtrim(JM.Title),JM.SubscriptionDate,Rtrim(JM.Subscription),JM.SubscriptionDateFrom, JM.SubscriptionDateTo, Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(JMB.BillNo),JMB.BillDate,Rtrim(JMB.IssueNo),Rtrim(JMB.Month),Rtrim(JMB.Year),Rtrim(JMB.Amount),JMB.PaidON FROM JM INNER JOIN JMB ON JM.SubNo = JMB.Sub_No INNER JOIN Supplier ON JM.SupplierID = Supplier.SupplierID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmJournalAndMagazineBillingList_Load(object sender, EventArgs e)
        {
            GetData();
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R2")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    frm.Activate();
                    frm.BringToFront();
                    frm.txtJMB.Text = dr.Cells[0].Value.ToString();
                    frm.txtSubNo.Text = dr.Cells[1].Value.ToString();
                    frm.txttitle.Text = dr.Cells[2].Value.ToString();
                    frm.txtBillNo.Text = dr.Cells[9].Value.ToString();
                    frm.dtpBillDate.Text = dr.Cells[10].Value.ToString();
                    frm.txtIssueNo.Text = dr.Cells[11].Value.ToString();
                    frm.cmbMonth.Text = dr.Cells[12].Value.ToString();
                    frm.cmbYear.Text = dr.Cells[13].Value.ToString();
                    frm.txtAmount.Text = dr.Cells[14].Value.ToString();
                   frm.btnSave.Enabled = false;
                   con = new SqlConnection(cs.ReadfromXML());
                   con.Open();
                   cmd = con.CreateCommand();
                   cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + lblUser.Text + "'";
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       lblupdate.Text = rdr[0].ToString().Trim();
                       lbldelete.Text = rdr[1].ToString().Trim();

                   }
                   if ((rdr != null))
                   {
                       rdr.Close();
                   }
                   if (con.State == ConnectionState.Open)
                   {
                       con.Close();
                   }
                   if (lblupdate.Text == "True")
                       frm.btnUpdate_record.Enabled = true;
                   else
                       frm.btnUpdate_record.Enabled = false;

                   if (lbldelete.Text == "True")
                       frm.btnDelete.Enabled = true;
                   else
                       frm.btnDelete.Enabled = false;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(JMB.JMBID),Rtrim(JMB.Sub_No),Rtrim(JM.Title),JM.SubscriptionDate,Rtrim(JM.Subscription),JM.SubscriptionDateFrom, JM.SubscriptionDateTo, Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(JMB.BillNo),JMB.BillDate,Rtrim(JMB.IssueNo),Rtrim(JMB.Month),Rtrim(JMB.Year),Rtrim(JMB.Amount),JMB.PaidON FROM JM INNER JOIN JMB ON JM.SubNo = JMB.Sub_No INNER JOIN Supplier ON JM.SupplierID = Supplier.SupplierID where Title like '%"+txtTitle.Text+"%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15]);
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
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(JMB.JMBID),Rtrim(JMB.Sub_No),Rtrim(JM.Title),JM.SubscriptionDate,Rtrim(JM.Subscription),JM.SubscriptionDateFrom, JM.SubscriptionDateTo, Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(JMB.BillNo),JMB.BillDate,Rtrim(JMB.IssueNo),Rtrim(JMB.Month),Rtrim(JMB.Year),Rtrim(JMB.Amount),JMB.PaidON FROM JM INNER JOIN JMB ON JM.SubNo = JMB.Sub_No INNER JOIN Supplier ON JM.SupplierID = Supplier.SupplierID where PaidOn between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaidON").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaidON").Value = dtpDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            txtTitle.Text = "";
            GetData();
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }
    }
}
