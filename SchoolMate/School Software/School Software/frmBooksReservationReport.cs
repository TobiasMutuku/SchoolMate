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
    public partial class frmBooksReservationReport : Form
    {
     DataTable dtable = new DataTable();
     frmReport frm = new frmReport();
       DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
      
        public frmBooksReservationReport()
        {
            InitializeComponent();
        }

      private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptBooksReservation rpt = new RptBooksReservation();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where R_Date between @d1 and @d2 order by R_Date";
                MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "R_Date").Value = dtpDateFrom.Value.Date;
                MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "R_Date").Value = dtpDateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "BookReservation");
                myDA.Fill(myDS, "Employee");
                myDA.Fill(myDS, "Book");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }

        private void frmBooksReservationReport_Load(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
