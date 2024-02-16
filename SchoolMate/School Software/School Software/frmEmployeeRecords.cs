using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmEmployeeRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmEmployeeEntry frm = null;
        frmBusHolderStaff frm1 = null;
        frmBookReservations frmBR = null;
        frmBookIssue frmBI = null;
        public frmEmployeeRecord()
        {
            InitializeComponent();
        }
        public void auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID  order by Employee.EMPID";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void auto1()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID Where Employee.Status='Active'order by Employee.EMPID";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                auto1();
            }
            else if (lblSET.Text == "BI")
            {
                auto1();
            }
            else
            {
                auto();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ButtonHighlight;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and EmployeeName like '%" + txtEmployeeName.Text + "%'  order by Employee.EMPIDe";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and EmployeeName like '%" + txtEmployeeName.Text + "%' order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where EmployeeName like '%" + txtEmployeeName.Text + "%' order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and DateOfJoining Between @date1 and @Date2 order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfJoining").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfJoining").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and DateOfJoining between @d1 and @d2 order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status), Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where DateOfJoining between @d1 and @d2 order by EmployeeName Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        public void Reset()
        {
            txtEmployeeName.Text = "";
            dataGridView1.Rows.Clear();
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            if (lblSET.Text == "S")
            {
                auto1();
            }
            else if (lblSET.Text == "BI")
            {
                auto1();
            }
            else
            {
                auto();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
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
                rowsTotal = dataGridView1.RowCount;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
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

