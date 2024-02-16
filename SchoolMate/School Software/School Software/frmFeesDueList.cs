using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmFeesDueList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmReport frm = new frmReport();
        public frmFeesDueList()
        {
            InitializeComponent();
        }
        public void SessionS()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM SchoolFeesPayment";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbSession.Items.Clear();
                while (rdr.Read())
                {
                    cmbSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SessionH()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT Distinct Rtrim(Session) FROM HostelFeesPayment";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSession1.Items.Clear();
                while (rdr.Read())
                {
                    txtSession1.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmFeesDueList_Load(object sender, EventArgs e)
        {
            SessionS();
            SessionsB();
            SessionH();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           cmbSection.Items.Clear();
           cmbSection.Text = "";
           cmbSection.Enabled = true;
           cmbSection.Focus();
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Section) FROM SchoolFeesPayment where Classname = '" + cmbClass.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSection.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbClass.Items.Clear();
                cmbClass.Text = "";
                cmbClass.Enabled = true;
                cmbClass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim (Classname) FROM SchoolFeesPayment where session='" + cmbSession.Text + "'";
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSection.Text == "")
                {
                    MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbSection.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT  Rtrim(T1.Admission_No),Rtrim(Student.StudentName), Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM SchoolFeesPayment AS T1 INNER JOIN Student ON T1.Admission_No = Student.AdmissionNo WHERE (T1.SFP_ID = (SELECT MAX(SFP_ID) AS Expr1 FROM SchoolFeesPayment WHERE (T1.Admission_No = Admission_No))) and T1.Session='" + cmbSession.Text + "' and  T1.Classname='" + cmbClass.Text + "' and T1.Section='" + cmbSection.Text + "' and PaymentDue > 0 ORDER BY T1.SFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.DataGridView1.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[3].Value);
                }
                sum = Math.Round(sum, 2);
                txtTotalDue.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SessionsB()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM BusFeesPayment";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSession.Items.Clear();
                while (rdr.Read())
                {
                    txtSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSession.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                if (txtInstallment.Text == "")
                {
                    MessageBox.Show("Please select Installment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstallment.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM BusFeesPayment AS T1 INNER JOIN StudentBusHolder ON T1.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo WHERE (T1.BFP_ID = (SELECT MAX(BFP_ID) AS Expr1 FROM BusFeesPayment  WHERE(T1.BusHolder_ID = BusHolder_ID))) and StudentBusHolder.Status='Active' and T1.Session='" + txtSession.Text + "' and  T1.Classname='" + txtClass.Text + "' and T1.Installment='" + txtInstallment.Text + "' and PaymentDue > 0 ORDER BY T1.BFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.dataGridView2.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[3].Value);
                }
                sum = Math.Round(sum, 2);
                txttotalDue1.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtClass.Items.Clear();
                txtClass.Text = "";
                txtClass.Enabled = true;
                txtClass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim (Classname) FROM BusFeesPayment where session='" + txtSession.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInstallment.Items.Clear();
            txtInstallment.Text = "";
            txtInstallment.Enabled = true;
            txtInstallment.Focus();
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct  Rtrim(T1.Installment) FROM BusFeesPayment AS T1 INNER JOIN StudentBusHolder ON T1.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo WHERE (T1.BFP_ID = (SELECT MAX(BFP_ID) AS Expr1 FROM BusFeesPayment WHERE (T1.BusHolder_ID = BusHolder_ID))) and StudentBusHolder.Status='Active' and  T1.Classname='" + txtClass.Text + "' and PaymentDue > 0 ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtInstallment.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSession1.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSession1.Focus();
                    return;
                }
                if (txtClass1.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClass1.Focus();
                    return;
                }
                if (txtInstallment1.Text == "")
                {
                    MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstallment1.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(T1.Hostelnames),Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM HostelFeesPayment AS T1 INNER JOIN Hosteler ON T1.Hosteler_ID = Hosteler.HostelerID INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo WHERE (T1.HFP_ID = (SELECT MAX(HFP_ID) AS Expr1 FROM HostelFeesPayment WHERE (T1.Hosteler_ID = Hosteler_ID))) and Hosteler.Status='Active' and T1.Session='" + txtSession1.Text + "' and  T1.Classname='" + txtClass1.Text + "' and T1.Installment='" + txtInstallment1.Text + "' and PaymentDue > 0 ORDER BY T1.HFP_ID DESC", con);
               rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.dataGridView3.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[4].Value);
                }
                sum = Math.Round(sum, 2);
                txtTotalDue2.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSession1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtClass1.Items.Clear();
                txtClass1.Text = "";
                txtClass1.Enabled = true;
                txtClass1.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim (Classname) FROM HostelFeesPayment where session='" + txtSession1.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass1.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInstallment1.Items.Clear();
            txtInstallment1.Text = "";
            txtInstallment1.Enabled = true;
            txtInstallment1.Focus();
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(T1.Installment) FROM HostelFeesPayment AS T1 INNER JOIN Hosteler ON T1.Hosteler_ID = Hosteler.HostelerID INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo WHERE (T1.HFP_ID = (SELECT MAX(HFP_ID) AS Expr1 FROM HostelFeesPayment WHERE (T1.Hosteler_ID = Hosteler_ID))) and Classname = '" + txtClass1.Text + "' and PaymentDue > 0 ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtInstallment1.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT  Rtrim(T1.Admission_No),Rtrim(Student.StudentName), Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM SchoolFeesPayment AS T1 INNER JOIN Student ON T1.Admission_No = Student.AdmissionNo WHERE (T1.SFP_ID = (SELECT MAX(SFP_ID) AS Expr1 FROM SchoolFeesPayment WHERE (T1.Admission_No = Admission_No))) and T1.Admission_no like '%" + txtAdmissionNo.Text + "%'  and PaymentDue > 0 ORDER BY T1.SFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.DataGridView1.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[3].Value);
                }
                sum = Math.Round(sum, 2);
                txtTotalDue.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAdmissionNo1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Student.AdmissionNo, Student.StudentName, T1.School, T1.PaymentDue FROM BusFeesPayment AS T1 INNER JOIN StudentBusHolder ON T1.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo WHERE (T1.BFP_ID = (SELECT MAX(BFP_ID) AS Expr1 FROM BusFeesPayment  WHERE(T1.BusHolder_ID = BusHolder_ID))) and StudentBusHolder.Admission_No like'%" + txtAdmissionNo1.Text + "%' and StudentBusHolder.Status='Active' and PaymentDue > 0 ORDER BY T1.BFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.dataGridView2.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[3].Value);
                }
                sum = Math.Round(sum, 2);
                txttotalDue1.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentName1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM BusFeesPayment AS T1 INNER JOIN StudentBusHolder ON T1.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo WHERE (T1.BFP_ID = (SELECT MAX(BFP_ID) AS Expr1 FROM BusFeesPayment  WHERE(T1.BusHolder_ID = BusHolder_ID))) and Student.StudentName like'%" + txtStudentName1.Text + "%' and StudentBusHolder.Status='Active' and PaymentDue > 0 ORDER BY T1.BFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.dataGridView2.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[3].Value);
                }
                sum = Math.Round(sum, 2);
                txttotalDue1.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT  Rtrim(T1.Admission_No),Rtrim(Student.StudentName), Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM SchoolFeesPayment AS T1 INNER JOIN Student ON T1.Admission_No = Student.AdmissionNo WHERE (T1.SFP_ID = (SELECT MAX(SFP_ID) AS Expr1 FROM SchoolFeesPayment WHERE (T1.Admission_No = Admission_No))) and Studentname like '%" + txtStudentName.Text + "%'  and PaymentDue > 0 ORDER BY T1.SFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.DataGridView1.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[3].Value);
                }
                sum = Math.Round(sum, 2);
                txtTotalDue.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAdmissionNo2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(T1.Hostel),Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM HostelFeesPayment AS T1 INNER JOIN Hosteler ON T1.Hosteler_ID = Hosteler.HostelerID INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo WHERE (T1.HFP_ID = (SELECT MAX(HFP_ID) AS Expr1 FROM HostelFeesPayment WHERE (T1.Hosteler_ID = Hosteler_ID))) and Hosteler.Status='Active' and Hosteler.Admission_No like '%" + txtAdmissionNo2.Text + "%' and PaymentDue > 0 ORDER BY T1.HFP_ID DESC", con);
               rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.dataGridView3.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[4].Value);
                }
                sum = Math.Round(sum, 2);
                txtTotalDue2.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentName2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(T1.Hostel),Rtrim(T1.School),Rtrim(T1.PaymentDue) FROM HostelFeesPayment AS T1 INNER JOIN Hosteler ON T1.Hosteler_ID = Hosteler.HostelerID INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo WHERE (T1.HFP_ID = (SELECT MAX(HFP_ID) AS Expr1 FROM HostelFeesPayment WHERE (T1.Hosteler_ID = Hosteler_ID))) and Hosteler.Status='Active' and Student.StudentName like '%" + txtStudentName2.Text + "%' and PaymentDue > 0 ORDER BY T1.HFP_ID DESC", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
                decimal sum = 0;
                foreach (DataGridViewRow r in this.dataGridView3.Rows)
                {
                    sum = sum + Convert.ToDecimal(r.Cells[4].Value);
                }
                sum = Math.Round(sum, 2);
                txtTotalDue2.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void reset()
        {
            txtStudentName.Text = "";
            txtStudentName1.Text = "";
            txtStudentName2.Text = "";
            txtAdmissionNo.Text = "";
            txtAdmissionNo1.Text = "";
            txtAdmissionNo2.Text = "";
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;
           txtSession.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtInstallment.SelectedIndex = -1;
            txtSession1.SelectedIndex = -1;
            txtClass1.SelectedIndex = -1;
            txtInstallment1.SelectedIndex = -1;
            cmbClass.Enabled = false;
            cmbSection.Enabled = false;
             txtClass.Enabled = false;
            txtInstallment.Enabled = false;
            txtClass1.Enabled = false;
            txtInstallment1.Enabled = false;
            txtTotalDue.Text = "";
            txttotalDue1.Text = "";
            txtTotalDue2.Text = "";
            DataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            SessionS();
            SessionsB();
            SessionH();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
               RptSchoolFeesDue rpt = new RptSchoolFeesDue();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM SchoolFeesPayment AS T1 INNER JOIN Student ON T1.Admission_No = Student.AdmissionNo WHERE (T1.SFP_ID = (SELECT MAX(SFP_ID) AS Expr1 FROM SchoolFeesPayment WHERE (T1.Admission_No = Admission_No))) and T1.Session='" + cmbSession.Text + "' and  T1.Classname='" + cmbClass.Text + "' and T1.Section='" + cmbSection.Text + "' and PaymentDue > 0 ORDER BY T1.SFP_ID DESC";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SchoolFeesPayment");
                myDA.Fill(myDS, "Student");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtInstallment1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptBusFeesPayment rpt = new RptBusFeesPayment();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
               DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM BusFeesPayment AS T1 INNER JOIN StudentBusHolder ON T1.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo WHERE (T1.BFP_ID = (SELECT MAX(BFP_ID) AS Expr1 FROM BusFeesPayment  WHERE(T1.BusHolder_ID = BusHolder_ID))) and  T1.installment='" + txtInstallment.Text + "' and T1.Session='" + txtSession.Text + "' and  T1.Classname='" + txtClass.Text + "' and  PaymentDue > 0 ORDER BY T1.BFP_ID DESC";
               MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "BusFeesPayment");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "StudentBusHolder");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhostel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptHostelFeesPayment rpt = new RptHostelFeesPayment();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new  DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM HostelFeesPayment AS T1 INNER JOIN Hosteler ON T1.Hosteler_ID = Hosteler.HostelerID INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo WHERE (T1.HFP_ID = (SELECT MAX(HFP_ID) AS Expr1 FROM HostelFeesPayment  WHERE(T1.Hosteler_ID = Hosteler_ID))) and  T1.installment='" + txtInstallment1.Text + "' and T1.Session='" + txtSession1.Text + "' and  T1.Classname='" + txtClass1.Text + "' and  PaymentDue > 0 ORDER BY T1.HFP_ID DESC";
               MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "HostelFeesPayment");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "Hosteler");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add data in datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = DataGridView1.RowCount;
                colsTotal = DataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Please add data in datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = dataGridView2.RowCount;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Please add data in datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = dataGridView3.RowCount;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        
    }
}
