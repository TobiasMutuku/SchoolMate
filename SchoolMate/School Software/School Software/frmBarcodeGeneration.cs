using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
namespace School_Software
{
    public partial class frmBarcodeGeneration : Form
    {
      
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        Connectionstring cs = new Connectionstring();
        
    
         public frmBarcodeGeneration()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT (AccessionNo) FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["AccessionNo"].ToString().Trim());

                }
                txtAccessionNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtAccessionNo.AutoCompleteCustomSource = col;
                txtAccessionNo.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBarcodeGenration_Load(object sender, EventArgs e)
        {
            Autocomplete();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
             if (txtAccessionNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the AccessionNo of Book");
            }
             else if (string.IsNullOrEmpty(txtNoPrint.Text))
            {
                MessageBox.Show("Please Enter Number of prints you want.");
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                RptBarCodes rpt = new RptBarCodes();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                DataSet myDS = new  DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                string st = "Select * from Book where AccessionNo='" + txtAccessionNo.Text + "'";
                for (int j = 1; j < Int32.Parse(txtNoPrint.Text); j++)
                {
                    st = st + "Union all select * from book where AccessionNo= '" + txtAccessionNo.Text + "'";
                }
                SqlDataAdapter myDA = new SqlDataAdapter(st, cs.ReadfromXML());
                myDA.Fill(myDS, "Book");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
     
        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                RptBarCodes rpt = new RptBarCodes();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                string st = "Select * from Book order by BookTitle";
                SqlDataAdapter myDA = new SqlDataAdapter(st, cs.ReadfromXML());
                myDA.Fill(myDS, "Book");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtAccessionNo.Text = "";
            txtNoPrint.Text = "1";
            crystalReportViewer1.ReportSource = null;
        }
    }
}
