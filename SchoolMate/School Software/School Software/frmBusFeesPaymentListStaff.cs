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
    public partial class frmBusFeesPaymentListStaff : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmBusFeePaymentStaff  frm = null;
        Connectionstring cs = new Connectionstring();
        public frmBusFeesPaymentListStaff()
        {
            InitializeComponent();
        }
        public frmBusFeesPaymentListStaff(frmBusFeePaymentStaff par)
        {
            frm = par;
            InitializeComponent();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusFeesPayment.FP_ID),Rtrim(StaffBusFeesPayment.MaxID),StaffBusFeesPayment.PaymentDate,Rtrim(StaffBusFeesPayment.StaffBusHolder_ID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(School.SchoolName),Rtrim(StaffBusFeesPayment.Location),Rtrim(StaffBusFeesPayment.Installment),Rtrim(StaffBusFeesPayment.Session),Rtrim(StaffBusFeesPayment.ModeOfPayment),Rtrim(StaffBusFeesPayment.PaymentModeDetails),Rtrim(StaffBusFeesPayment.TotalFee),Rtrim(StaffBusFeesPayment.DiscountPer),Rtrim(StaffBusFeesPayment.DiscountAmt),Rtrim(StaffBusFeesPayment.PreviousDue),Rtrim(StaffBusFeesPayment.Fine),Rtrim(StaffBusFeesPayment.GrandTotal),Rtrim(StaffBusFeesPayment.TotalPaid),Rtrim(StaffBusFeesPayment.PaymentDue) FROM StaffBusFeesPayment INNER JOIN StaffBusHolder ON StaffBusFeesPayment.StaffBusHolder_ID = StaffBusHolder.StaffBusHolderID INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_id = Department.DepartmentID INNER JOIN Designations ON Designations.DesignationID = Employee.Designation_ID", con);
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
        private void frmBusFeesPaymentListStaff_Load(object sender, EventArgs e)
        {
            Auto();
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
                frm.txtStaffBusHolderID.Text = dr.Cells[3].Value.ToString();
                frm.txtMaxID .Text = dr.Cells[4].Value.ToString();
                frm.txtStaffName.Text = dr.Cells[5].Value.ToString();
                frm.txtDepartment .Text = dr.Cells[6].Value.ToString();
                frm.txtdesignation.Text = dr.Cells[7].Value.ToString();
                frm.txtSchoolName.Text = dr.Cells[8].Value.ToString();
                frm.txtLocation.Text = dr.Cells[9].Value.ToString();
                frm.txtInstallment.DropDownStyle = ComboBoxStyle.DropDown;
                frm.txtInstallment.Text = dr.Cells[10].Value.ToString();
                frm.txtInstallment.Enabled = false;
                frm.txtSession.DropDownStyle = ComboBoxStyle.DropDown;
                frm.txtSession.Text = dr.Cells[11].Value.ToString();
                frm.txtPaymentMode.DropDownStyle = ComboBoxStyle.DropDown;
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
                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Staff' and Users.UserID='" + lblUser.Text + "'";
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

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
             try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusFeesPayment.FP_ID),Rtrim(StaffBusFeesPayment.MaxID),StaffBusFeesPayment.PaymentDate,Rtrim(StaffBusFeesPayment.StaffBusHolder_ID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(School.SchoolName),Rtrim(StaffBusFeesPayment.Location),Rtrim(StaffBusFeesPayment.Installment),Rtrim(StaffBusFeesPayment.Session),Rtrim(StaffBusFeesPayment.ModeOfPayment),Rtrim(StaffBusFeesPayment.PaymentModeDetails),Rtrim(StaffBusFeesPayment.TotalFee),Rtrim(StaffBusFeesPayment.DiscountPer),Rtrim(StaffBusFeesPayment.DiscountAmt),Rtrim(StaffBusFeesPayment.PreviousDue),Rtrim(StaffBusFeesPayment.Fine),Rtrim(StaffBusFeesPayment.GrandTotal),Rtrim(StaffBusFeesPayment.TotalPaid),Rtrim(StaffBusFeesPayment.PaymentDue) FROM StaffBusFeesPayment INNER JOIN StaffBusHolder ON StaffBusFeesPayment.StaffBusHolder_ID = StaffBusHolder.StaffBusHolderID INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_id = Department.DepartmentID INNER JOIN Designations ON Designations.DesignationID = Employee.Designation_ID where location like '%" +txtLocation .Text + "%'", con);
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

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusFeesPayment.FP_ID),Rtrim(StaffBusFeesPayment.MaxID),StaffBusFeesPayment.PaymentDate,Rtrim(StaffBusFeesPayment.StaffBusHolder_ID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(School.SchoolName),Rtrim(StaffBusFeesPayment.Location),Rtrim(StaffBusFeesPayment.Installment),Rtrim(StaffBusFeesPayment.Session),Rtrim(StaffBusFeesPayment.ModeOfPayment),Rtrim(StaffBusFeesPayment.PaymentModeDetails),Rtrim(StaffBusFeesPayment.TotalFee),Rtrim(StaffBusFeesPayment.DiscountPer),Rtrim(StaffBusFeesPayment.DiscountAmt),Rtrim(StaffBusFeesPayment.PreviousDue),Rtrim(StaffBusFeesPayment.Fine),Rtrim(StaffBusFeesPayment.GrandTotal),Rtrim(StaffBusFeesPayment.TotalPaid),Rtrim(StaffBusFeesPayment.PaymentDue) FROM StaffBusFeesPayment INNER JOIN StaffBusHolder ON StaffBusFeesPayment.StaffBusHolder_ID = StaffBusHolder.StaffBusHolderID INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_id = Department.DepartmentID INNER JOIN Designations ON Designations.DesignationID = Employee.Designation_ID where Employee.Employeename like '%" + txtEmployeeName.Text + "%'", con);
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

        private void txtStaffid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusFeesPayment.FP_ID),Rtrim(StaffBusFeesPayment.MaxID),StaffBusFeesPayment.PaymentDate,Rtrim(StaffBusFeesPayment.StaffBusHolder_ID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(School.SchoolName),Rtrim(StaffBusFeesPayment.Location),Rtrim(StaffBusFeesPayment.Installment),Rtrim(StaffBusFeesPayment.Session),Rtrim(StaffBusFeesPayment.ModeOfPayment),Rtrim(StaffBusFeesPayment.PaymentModeDetails),Rtrim(StaffBusFeesPayment.TotalFee),Rtrim(StaffBusFeesPayment.DiscountPer),Rtrim(StaffBusFeesPayment.DiscountAmt),Rtrim(StaffBusFeesPayment.PreviousDue),Rtrim(StaffBusFeesPayment.Fine),Rtrim(StaffBusFeesPayment.GrandTotal),Rtrim(StaffBusFeesPayment.TotalPaid),Rtrim(StaffBusFeesPayment.PaymentDue) FROM StaffBusFeesPayment INNER JOIN StaffBusHolder ON StaffBusFeesPayment.StaffBusHolder_ID = StaffBusHolder.StaffBusHolderID INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_id = Department.DepartmentID INNER JOIN Designations ON Designations.DesignationID = Employee.Designation_ID where Employee.maxid like '%" + txtStaffid .Text + "%'", con);
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

