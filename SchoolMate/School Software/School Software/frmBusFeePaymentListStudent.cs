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
    public partial class frmBusFeePaymentListStudent : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmBusFeesPaymentStudent frm = null;
       Connectionstring cs = new Connectionstring();
        public frmBusFeePaymentListStudent()
        {
            InitializeComponent();
        }
        public frmBusFeePaymentListStudent(frmBusFeesPaymentStudent par)
        {
            frm = par;
            InitializeComponent();
        }
        public void Sessions()
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
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BusFeesPayment.BFP_ID),Rtrim(BusFeesPayment.MaxID),BusFeesPayment.PaymentDate,Rtrim(BusFeesPayment.BusHolder_ID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(BusFeesPayment.School),Rtrim(BusFeesPayment.Classname),Rtrim(BusFeesPayment.Section),Rtrim(BusFeesPayment.Location),Rtrim(BusFeesPayment.Installment),Rtrim(BusFeesPayment.Session),Rtrim(BusFeesPayment.ModeOfPayment),Rtrim(BusFeesPayment.PaymentModeDetails),Rtrim(BusFeesPayment.TotalFee),Rtrim(BusFeesPayment.DiscountPer),Rtrim(BusFeesPayment.DiscountAmt),Rtrim(BusFeesPayment.PreviousDue),Rtrim(BusFeesPayment.Fine),Rtrim(BusFeesPayment.GrandTotal),Rtrim(BusFeesPayment.TotalPaid),Rtrim(BusFeesPayment.PaymentDue) FROM BusFeesPayment INNER JOIN StudentBusHolder ON BusFeesPayment.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBusFeePaymentListStudent_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BusFeesPayment.BFP_ID),Rtrim(BusFeesPayment.MaxID),BusFeesPayment.PaymentDate,Rtrim(BusFeesPayment.BusHolder_ID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(BusFeesPayment.School),Rtrim(BusFeesPayment.Classname),Rtrim(BusFeesPayment.Section),Rtrim(BusFeesPayment.Location),Rtrim(BusFeesPayment.Installment),Rtrim(BusFeesPayment.Session),Rtrim(BusFeesPayment.ModeOfPayment),Rtrim(BusFeesPayment.PaymentModeDetails),Rtrim(BusFeesPayment.TotalFee),Rtrim(BusFeesPayment.DiscountPer),Rtrim(BusFeesPayment.DiscountAmt),Rtrim(BusFeesPayment.PreviousDue),Rtrim(BusFeesPayment.Fine),Rtrim(BusFeesPayment.GrandTotal),Rtrim(BusFeesPayment.TotalPaid),Rtrim(BusFeesPayment.PaymentDue) FROM BusFeesPayment INNER JOIN StudentBusHolder ON BusFeesPayment.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo where Admissionno like '%" + txtAdmissionNo.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21]);
                }
                con.Close();
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
                cmd = new SqlCommand("SELECT Rtrim(BusFeesPayment.BFP_ID),Rtrim(BusFeesPayment.MaxID),BusFeesPayment.PaymentDate,Rtrim(BusFeesPayment.BusHolder_ID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(BusFeesPayment.School),Rtrim(BusFeesPayment.Classname),Rtrim(BusFeesPayment.Section),Rtrim(BusFeesPayment.Location),Rtrim(BusFeesPayment.Installment),Rtrim(BusFeesPayment.Session),Rtrim(BusFeesPayment.ModeOfPayment),Rtrim(BusFeesPayment.PaymentModeDetails),Rtrim(BusFeesPayment.TotalFee),Rtrim(BusFeesPayment.DiscountPer),Rtrim(BusFeesPayment.DiscountAmt),Rtrim(BusFeesPayment.PreviousDue),Rtrim(BusFeesPayment.Fine),Rtrim(BusFeesPayment.GrandTotal),Rtrim(BusFeesPayment.TotalPaid),Rtrim(BusFeesPayment.PaymentDue) FROM BusFeesPayment INNER JOIN StudentBusHolder ON BusFeesPayment.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo where StudentName like '%" + txtStudentName.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BusFeesPayment.BFP_ID),Rtrim(BusFeesPayment.MaxID),BusFeesPayment.PaymentDate,Rtrim(BusFeesPayment.BusHolder_ID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(BusFeesPayment.School),Rtrim(BusFeesPayment.Classname),Rtrim(BusFeesPayment.Section),Rtrim(BusFeesPayment.Location),Rtrim(BusFeesPayment.Installment),Rtrim(BusFeesPayment.Session),Rtrim(BusFeesPayment.ModeOfPayment),Rtrim(BusFeesPayment.PaymentModeDetails),Rtrim(BusFeesPayment.TotalFee),Rtrim(BusFeesPayment.DiscountPer),Rtrim(BusFeesPayment.DiscountAmt),Rtrim(BusFeesPayment.PreviousDue),Rtrim(BusFeesPayment.Fine),Rtrim(BusFeesPayment.GrandTotal),Rtrim(BusFeesPayment.TotalPaid),Rtrim(BusFeesPayment.PaymentDue) FROM BusFeesPayment INNER JOIN StudentBusHolder ON BusFeesPayment.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo where Location like '%" + txtLocation.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21]);
                }
                con.Close();
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
            txtSection.Items.Clear();
            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Section) FROM BusFeesPayment where Classname = '" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSection.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClass.Focus();
                    return;
                }
                if (txtSection.Text == "")
                {
                    MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSection.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BusFeesPayment.BFP_ID),Rtrim(BusFeesPayment.MaxID),BusFeesPayment.PaymentDate,Rtrim(BusFeesPayment.BusHolder_ID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(BusFeesPayment.School),Rtrim(BusFeesPayment.Classname),Rtrim(BusFeesPayment.Section),Rtrim(BusFeesPayment.Location),Rtrim(BusFeesPayment.Installment),Rtrim(BusFeesPayment.Session),Rtrim(BusFeesPayment.ModeOfPayment),Rtrim(BusFeesPayment.PaymentModeDetails),Rtrim(BusFeesPayment.TotalFee),Rtrim(BusFeesPayment.DiscountPer),Rtrim(BusFeesPayment.DiscountAmt),Rtrim(BusFeesPayment.PreviousDue),Rtrim(BusFeesPayment.Fine),Rtrim(BusFeesPayment.GrandTotal),Rtrim(BusFeesPayment.TotalPaid),Rtrim(BusFeesPayment.PaymentDue) FROM BusFeesPayment INNER JOIN StudentBusHolder ON BusFeesPayment.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo where BusfeesPayment.Session='" + txtSession.Text + "' and BusfeesPayment.Classname='" + txtClass.Text + "' and BusfeesPayment.Section='" + txtSection.Text + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (lblSET.Text == "R1")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm.Activate();
                frm.BringToFront();
                  frm.txtBFPID.Text = dr.Cells[0].Value.ToString();
                frm.txtFeePaymentID.Text = dr.Cells[1].Value.ToString();
                frm.dtpPaymentDate.Text = dr.Cells[2].Value.ToString();
                 frm.txtBusHolderID.Text = dr.Cells[3].Value.ToString();
                frm.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frm.txtStudentName.Text = dr.Cells[5].Value.ToString();
                frm.txtSchoolname.Text = dr.Cells[6].Value.ToString();
                frm.txtClass.Text = dr.Cells[7].Value.ToString();
                frm.txtSection.Text = dr.Cells[8].Value.ToString();
                frm.txtLocation.Text = dr.Cells[9].Value.ToString();
                frm.txtInstallment.DropDownStyle = ComboBoxStyle.DropDown;
                 frm.txtInstallment.Text = dr.Cells[10].Value.ToString();
                 frm.txtInstallment.Enabled = false;
                frm.txtSession.Text = dr.Cells[11].Value.ToString();
                 frm.txtPaymentMode.Text = dr.Cells[12].Value.ToString();
                frm.txtPaymentModeDetails.Text = dr.Cells[13].Value.ToString();
                frm.txtBusFee.Text = dr.Cells[14].Value.ToString();
                 frm.txtDiscountPer.Text = dr.Cells[15].Value.ToString();
                 frm.txtDiscount.Text = dr.Cells[16].Value.ToString();
                 frm.txtPreviousDue.Text = dr.Cells[17].Value.ToString();
                frm.txtFine.Text = dr.Cells[18].Value.ToString();
                 frm.txtGrandTotal.Text = dr.Cells[19].Value.ToString();
                frm.txtTotalPaid.Text = dr.Cells[20].Value.ToString();
                frm.txtBalance.Text = dr.Cells[21].Value.ToString();
                frm.btnSave.Enabled = false;
                frm.Button2.Enabled = false;
                frm.btnPrint.Enabled = true;
              con = new SqlConnection(cs.ReadfromXML());
              con.Open();
              cmd = con.CreateCommand();
              cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Student' and Users.UserID='" + lblUser.Text + "'";
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
        public void reset()
        {
            txtStudentName.Text = "";
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            txtAdmissionNo.Text = "";
            DataGridView1.Rows.Clear();
            Sessions();
            Auto();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button10_Click(object sender, EventArgs e)
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
    }
}
