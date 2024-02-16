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
    public partial class frmBookIssueListStaff : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmBookIssue BI = null;
        frmBookReturn BR = null;
        public frmBookIssueListStaff(frmBookIssue par)
        {
            BI = par;
            InitializeComponent();
        }
        public frmBookIssueListStaff(frmBookReturn par1)
        {
            BR = par1;
            InitializeComponent();
        }
        public frmBookIssueListStaff()
        {

            InitializeComponent();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBookIssueListStaff_Load(object sender, EventArgs e)
        {
            Auto();
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

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where BookIssue_Staff.AccessionNo like '%" + txtAccessionNo.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where Book.BookTitle like '%" + txtBookTitle.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where BookIssue_Staff.StaffID like '%" + txtStaffID.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where Employee.EmployeeName like '%" + txtStaffName.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssueDate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where BookIssue_Staff.IssueDate Between @date1 and @Date2 Order by DueDate", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            txtAccessionNo.Text = "";
            txtBookTitle.Text = "";
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            txtBookTitle.Text = "";
             dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            txtFrom.Text = System.DateTime.Now.ToString();
            txtTo.Text = System.DateTime.Now.ToString();
            Auto();
        }
        private void btnduedate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Staff.ID),BookIssue_Staff.IssueDate,BookIssue_Staff.DueDate,Rtrim(BookIssue_Staff.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Staff.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(BookIssue_Staff.Status),Rtrim(BookIssue_Staff.Remarks) FROM BookIssue_Staff INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where BookIssue_Staff.DueDate Between @date1 and @Date2 Order by DueDate", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DueDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DueDate").Value = txtTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14]);
                }
                con.Close();
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

        private void txtTo_Validating(object sender, CancelEventArgs e)
        {
            if ((txtFrom.Value.Date) > (txtTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTo.Focus();
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
                    BI.Activate();
                    BI.BringToFront();
                    BI.Reset1();
                    BI.txtID1.Text = dr.Cells[0].Value.ToString();
                    BI.dtpIssueDate1.Text = dr.Cells[1].Value.ToString();
                    BI.dtpDueDate1.Text = dr.Cells[2].Value.ToString();
                    BI.txtAccessionNo1.Text = dr.Cells[3].Value.ToString();
                    BI.txtBookTitle1.Text = dr.Cells[4].Value.ToString();
                    BI.txtAuthor1.Text = dr.Cells[5].Value.ToString();
                    BI.txtJointAuthors1.Text = dr.Cells[6].Value.ToString();
                   BI.txtS_ID.Text = dr.Cells[7].Value.ToString();
                    BI.txtStaffID.Text = dr.Cells[8].Value.ToString();
                    BI.txtStaffName.Text = dr.Cells[9].Value.ToString();
                    BI.txtStatus.Text = dr.Cells[13].Value.ToString();
                    BI.txtRemarks1.Text = dr.Cells[14].Value.ToString();
                    BI.btnSave1.Enabled = true;
                    BI.FillStaffs();
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + lblUser.Text + "'";
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
                        BI.btnUpdate1.Enabled = true;
                    else
                        BI.btnUpdate1.Enabled = false;


                    if (lbldelete.Text == "True")
                        BI.btnDelete1.Enabled = true;
                    else
                        BI.btnDelete1.Enabled = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BR")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    BR.Activate();
                    BR.BringToFront();
                    BR.txtIssueID_Staff.Text = dr.Cells[0].Value.ToString();
                    BR.dtpIssueDate1.Text = dr.Cells[1].Value.ToString();
                    BR.dtpDueDate1.Text = dr.Cells[2].Value.ToString();
                    BR.txtAccessionNo1.Text = dr.Cells[3].Value.ToString();
                    BR.txtBookTitle1.Text = dr.Cells[4].Value.ToString();
                    BR.txtAuthor1.Text = dr.Cells[5].Value.ToString();
                    BR.txtJointAuthors1.Text = dr.Cells[6].Value.ToString();
                    BR.txtS_ID.Text = dr.Cells[7].Value.ToString();
                    BR.txtStaffID.Text = dr.Cells[8].Value.ToString();
                    BR.txtStaffName.Text = dr.Cells[9].Value.ToString();
                    BR.btnUpdate1.Enabled = true;
                    BR.btnDelete1.Enabled = true;
                    BR.btnSave1.Enabled = true;
                    BR.FillDatastaff();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
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
