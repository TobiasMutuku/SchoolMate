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
    public partial class frmBusHolderStaffList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
     frmBusHolderStaff frm = null;
      frmBusFeePaymentStaff frm1 = null;
        Connectionstring cs = new Connectionstring();
        public frmBusHolderStaffList()
        {
            InitializeComponent();
        }
        public frmBusHolderStaffList(frmBusHolderStaff par)
        {
            frm = par;
            InitializeComponent();
        }
        public frmBusHolderStaffList(frmBusFeePaymentStaff par1)
        {
            frm1 = par1;
            InitializeComponent();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusHolder.StaffBusHolderID),Rtrim(StaffBusHolder.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(StaffBusHolder.Bus_ID),Rtrim(Bus.BusNo),Rtrim(StaffBusHolder.Location_ID),Rtrim(Locations.Location),Rtrim(StaffBusHolder.JoiningDate),Rtrim(StaffBusHolder.Status) FROM StaffBusHolder INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN  Bus ON StaffBusHolder.Bus_ID = Bus.BusID INNER JOIN Locations ON StaffBusHolder.Location_ID = Locations.LocationID INNER JOIN School ON Employee.SchoolID = School.SchoolID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBusHolderStaffList_Load(object sender, EventArgs e)
        {
            Auto();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm1.Show();
                frm1.txtStaffBusHolderID.Text = dr.Cells[0].Value.ToString();
                frm1.txtStaffID.Text = dr.Cells[1].Value.ToString();
                frm1.txtMaxID.Text = dr.Cells[2].Value.ToString();
                frm1.txtStaffName.Text = dr.Cells[3].Value.ToString();
                frm1.txtSchoolName.Text = dr.Cells[4].Value.ToString();
                frm1.txtDepartment.Text = dr.Cells[5].Value.ToString();
                frm1.txtdesignation.Text = dr.Cells[6].Value.ToString();
                frm1.txtLocation.Text = dr.Cells[10].Value.ToString();
                frm1.Fillinstallment();
                frm1.txtInstallment.Enabled = true;
            }
              
            else if (lblSET.Text == "R0")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm.Show();
                frm.txtStaffBusHolderID.Text = dr.Cells[0].Value.ToString();
                frm.txtStaffID.Text = dr.Cells[1].Value.ToString();
                 frm.txtMaxID.Text = dr.Cells[2].Value.ToString();
                frm.txtStaffName.Text = dr.Cells[3].Value.ToString();
                frm.txtSchoolName.Text = dr.Cells[4].Value.ToString();
                frm.txtDepartment.Text = dr.Cells[5].Value.ToString();
                frm.txtdesignation.Text = dr.Cells[6].Value.ToString();
                frm.txtBusID.Text = dr.Cells[7].Value.ToString();
                frm.txtBusNo.DropDownStyle = ComboBoxStyle.DropDown;
                frm.txtBusNo.Text = dr.Cells[8].Value.ToString();
                frm.txtLocationID.Text = dr.Cells[9].Value.ToString();
                frm.txtLocationName.DropDownStyle = ComboBoxStyle.DropDown;
                frm.txtLocationName.Text = dr.Cells[10].Value.ToString();
                frm.txtJoiningDate.Text = dr.Cells[11].Value.ToString();
                frm.txtStatus.DropDownStyle = ComboBoxStyle.DropDown;
                frm.txtStatus.Text = dr.Cells[12].Value.ToString();
                frm.btnSave.Enabled = false;
                frm.btnUpdate_record.Enabled = true;
                frm.btnDelete.Enabled = true;
            }
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

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusHolder.StaffBusHolderID),Rtrim(StaffBusHolder.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(StaffBusHolder.Bus_ID),Rtrim(Bus.BusNo),Rtrim(StaffBusHolder.Location_ID),Rtrim(Locations.Location),Rtrim(StaffBusHolder.JoiningDate),Rtrim(StaffBusHolder.Status) FROM StaffBusHolder INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN  Bus ON StaffBusHolder.Bus_ID = Bus.BusID INNER JOIN Locations ON StaffBusHolder.Location_ID = Locations.LocationID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.EmployeeName like '%"+txtStaffName.Text+"%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtstaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StaffBusHolder.StaffBusHolderID),Rtrim(StaffBusHolder.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(School.SchoolName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(StaffBusHolder.Bus_ID),Rtrim(Bus.BusNo),Rtrim(StaffBusHolder.Location_ID),Rtrim(Locations.Location),Rtrim(StaffBusHolder.JoiningDate),Rtrim(StaffBusHolder.Status) FROM StaffBusHolder INNER JOIN Employee ON StaffBusHolder.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN  Bus ON StaffBusHolder.Bus_ID = Bus.BusID INNER JOIN Locations ON StaffBusHolder.Location_ID = Locations.LocationID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.EMPMAXID like '%" + txtstaffID.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void reset()
        {
            txtStaffName.Text = "";
            txtstaffID.Text = "";
          DataGridView1.Rows.Clear();
          Auto();
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }
}
}
