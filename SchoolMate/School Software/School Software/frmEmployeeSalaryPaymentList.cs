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
    public partial class frmEmployeeSalaryPaymentList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmEmployeeSalaryPayment frm = null;
        public frmEmployeeSalaryPaymentList()
        {
            InitializeComponent();
        }
        public frmEmployeeSalaryPaymentList(frmEmployeeSalaryPayment par)
        {
            frm = par;
            InitializeComponent();
        }
        public void auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(StaffPayment.Id),Rtrim(StaffPayment.PaymentID),StaffPayment.PaymentDate,StaffPayment.DateFrom, StaffPayment.DateTo,Rtrim(StaffPayment.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(StaffPayment.ModeOfPayment),Rtrim(StaffPayment.PaymentModeDetails),Rtrim(StaffPayment.PresentDays),Rtrim(StaffPayment.Salary),Rtrim(StaffPayment.Advance),Rtrim(StaffPayment.Deduction),Rtrim(StaffPayment.NetPay) FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID  order by PaymentDate";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16]);
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
                String sql = "SELECT Rtrim(StaffPayment.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),sum(StaffPayment.Salary),sum(StaffPayment.Deduction),sum(StaffPayment.NetPay) FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID group by StaffID,EMPMAXID,Employeename,Departmentname,designation order by EmployeeName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEmployeeSalaryPaymentList_Load(object sender, EventArgs e)
        {
            reset();
           
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
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
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(StaffPayment.Id),Rtrim(StaffPayment.PaymentID),StaffPayment.PaymentDate,StaffPayment.DateFrom, StaffPayment.DateTo,Rtrim(StaffPayment.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(StaffPayment.ModeOfPayment),Rtrim(StaffPayment.PaymentModeDetails),Rtrim(StaffPayment.PresentDays),Rtrim(StaffPayment.Salary),Rtrim(StaffPayment.Advance),Rtrim(StaffPayment.Deduction),Rtrim(StaffPayment.NetPay) FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID Where employeeName like'%"+txtStaffName.Text+"%'  order by PaymentDate";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(StaffPayment.Id),Rtrim(StaffPayment.PaymentID),StaffPayment.PaymentDate,StaffPayment.DateFrom, StaffPayment.DateTo,Rtrim(StaffPayment.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),Rtrim(StaffPayment.ModeOfPayment),Rtrim(StaffPayment.PaymentModeDetails),Rtrim(StaffPayment.PresentDays),Rtrim(StaffPayment.Salary),Rtrim(StaffPayment.Advance),Rtrim(StaffPayment.Deduction),Rtrim(StaffPayment.NetPay) FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID  where StaffPayment.PaymentDate between @d1 and @d2  order by PaymentDate";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "PaymentDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "PaymentDate").Value = txtTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStaff_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(StaffPayment.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),sum(StaffPayment.Salary),sum(StaffPayment.Deduction),sum(StaffPayment.NetPay) FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID where EmployeeName like '%"+txtStaff.Text+"%' group by StaffID,EMPMAXID,Employeename,Departmentname,designation order by EmployeeName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
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
                String sql = "SELECT Rtrim(StaffPayment.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Department.DepartmentName),Rtrim(Designations.Designation),sum(StaffPayment.Salary),sum(StaffPayment.Deduction),sum(StaffPayment.NetPay) FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID where EMPMAXID like '%" + txtStaffID.Text + "%' group by StaffID,EMPMAXID,Employeename,Departmentname,designation order by EmployeeName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
           
        }
        public void reset()
        {
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            txtFrom.Text = System.DateTime.Now.ToString();
            txtTo.Text = System.DateTime.Now.ToString();
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            auto1();
            auto();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R2")
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frm.Activate();
                    frm.BringToFront();
                    frm.txtID.Text = dr.Cells[0].Value.ToString();
                    frm.PaymentID.Text = dr.Cells[1].Value.ToString();
                    frm.PaymentDate.Text = dr.Cells[2].Value.ToString();
                    frm.DateFrom.Text = dr.Cells[3].Value.ToString();
                    frm.DateTo.Text = dr.Cells[4].Value.ToString();
                    frm.txtStaffID.Text = dr.Cells[5].Value.ToString();
                    frm.StaffMaxID.Text = dr.Cells[6].Value.ToString();
                    frm.StaffName.Text = dr.Cells[7].Value.ToString();
                    frm.Designation.Text = dr.Cells[9].Value.ToString();
                    frm.paymentmode.Text = dr.Cells[10].Value.ToString();
                    frm.PaymentModeDetails.Text = dr.Cells[11].Value.ToString();
                    frm.PresentDays.Text = dr.Cells[12].Value.ToString();
                    frm.Salary.Text = dr.Cells[13].Value.ToString();
                    frm.Advance.Text = dr.Cells[14].Value.ToString();
                    frm.Deduction.Text = dr.Cells[15].Value.ToString();
                    frm.NetPay.Text = dr.Cells[16].Value.ToString();
                    frm.btnSave.Enabled = false;
                    frm.btnPrint.Enabled = true;
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Salary Payment' and Users.UserID='" + lblUser.Text + "'";
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

       
    }
}
