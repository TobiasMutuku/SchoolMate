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
    public partial class frmEmployeeSalaryPayment : Form
    {
       SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmReport frm = new frmReport();
        SqlDataAdapter adp;
        DataSet ds;
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmEmployeeSalaryPayment()
        {
            InitializeComponent();
        }
        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq = "delete from StaffPayment where id=" + txtID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Salary payment is Deleted For Staff'" + txtStaff.Text + "' having StaffID '" + StaffMaxID.Text + "' and PaymentID '" + PaymentID.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                   Reset();
                   }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void calculate()
        {
            decimal val1 = 0;
            decimal val2 = 0;
            decimal val3 = 0;
            decimal val4 = 0;
            decimal.TryParse(txtSalary.Text, out val1);
            decimal.TryParse(PresentDays.Text, out val2);
            decimal.TryParse(Deduction.Text, out val3);
            decimal.TryParse(Salary.Text, out val4);
            Salary.Text = ((val1 * val2) / 30).ToString("F");
            decimal i = (val4 - val3);
            NetPay.Text = i.ToString("F");
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Designations.Designation),Rtrim(salary) FROM Employee,Designations where designations.designationID=Employee.Designation_ID  order by EmployeeName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                datagridview1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    datagridview1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal val1 = 0;
                decimal val2 = 0;
                decimal val3 = 0;
                decimal.TryParse(Advance.Text, out val1);
                decimal.TryParse(Deduction.Text, out val2);
                decimal.TryParse(NetPay.Text, out val3);

                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please retrieve Staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStaffID.Focus();
                    return;
                }
                if (paymentmode.Text == "")
                {
                    MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    paymentmode.Focus();
                    return;
                }
                if (Advance.Text == null)
                {
                    Advance.Text = "0".ToString();
                }

                if (val1 < val2)
                {
                    MessageBox.Show("You can not deduct amount more than advance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Deduction.Focus();
                    return;
                }

                if (val3 < 0)
                {
                    MessageBox.Show("net pay should be more than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DateTo.Value.Date < DateFrom.Value.Date)
                {
                    MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateTo.Focus();
                    return;
                }
                if (DateTo.Value.Date == DateFrom.Value.Date)
                {
                    MessageBox.Show("Selected 'Date From' is equal to 'Date To'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateFrom.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT * FROM StaffPayment WHERE DateFrom <= @d1 AND DateTo >= @d2 and StaffID=" + txtStaffID.Text + "";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Salary already paid..Select correct payment date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into Staffpayment(ID,PaymentID,DateFrom,DateTo,StaffID,PresentDays,Salary,Advance,Deduction,PaymentDate,ModeOfPayment,PaymentModeDetails,Netpay) values(" + txtID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", PaymentID.Text);
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@d3", DateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtStaffID.Text);
                cmd.Parameters.AddWithValue("@d5", Convert.ToInt32(PresentDays.Text));
                cmd.Parameters.AddWithValue("@d6", Convert.ToDecimal(Salary.Text));
                cmd.Parameters.AddWithValue("@d7", Advance.Text);
                cmd.Parameters.AddWithValue("@d8", Convert.ToDecimal(Deduction.Text));
                cmd.Parameters.AddWithValue("@d9", PaymentDate.Value.Date);
                cmd.Parameters.AddWithValue("@d10", paymentmode.Text);
                cmd.Parameters.AddWithValue("@d11", PaymentModeDetails.Text);
                cmd.Parameters.AddWithValue("@d12", Convert.ToDecimal(NetPay.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb2 = "insert into advanceentry(workingdate,StaffID,amount,deduction) VALUES (@d1,@d2,@d3,@d4)";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", PaymentDate.Value.Date);
                cmd.Parameters.AddWithValue("@d2", txtStaffID.Text);
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(Deduction.Text));
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Salary is paid For Staff'" + txtStaff.Text + "' having StaffID '" + StaffMaxID.Text + "' and PaymentID '" + PaymentID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully paid", "Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT MAX(ID+1)FROM StaffPayment";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtID.Text = Convert.ToString(Num);
                    PaymentID.Text = Convert.ToString("EP-" + Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtID.Text = Convert.ToString(Num);
                    PaymentID.Text = Convert.ToString("EP-" + Num);
                }
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            DateFrom.Text = System.DateTime.Now.ToString();
            DateTo.Text= System.DateTime.Now.ToString();
            txtStaffID.Text = "";
            PaymentID.Text = "";
            StaffMaxID.Text = "";
            StaffName.Text = "";
            Designation.Text = "";
            Salary.Text = "0.00";
            PresentDays.Text = "";
            Advance.Text = "0.00";
            Deduction.Text = "0.00";
            PaymentDate.Text = System.DateTime.Now.ToString();
            paymentmode.SelectedIndex = -1;
            PaymentModeDetails.Text = "";
            NetPay.Text = "0.00";
            PaymentID.Text = "";
            txtStaff.Text = "";
            txtStaff.Text = "";
            GetData();
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
            func();
            DateFrom.Enabled = true;
            DateTo.Enabled = true;
            PaymentDate.Enabled = true;
            Deduction.ReadOnly = false;
            datagridview1.Enabled = true;
            Crypto();
        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Salary Payment' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblsave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblsave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;
        }
      
        private void frmEmployeeSalaryPayment_Load(object sender, EventArgs e)
        {
            Reset();
            
        }

        private void datagridview1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DateTo.Value.Date < DateFrom.Value.Date)
                {
                    MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateTo.Focus();
                    return;
                }
                if (DateTo.Value.Date == DateFrom.Value.Date)
                {
                    MessageBox.Show("Selected 'Date From' is equal to 'Date To'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateFrom.Focus();
                    return;
                }
                DataGridViewRow dr = datagridview1.SelectedRows[0];
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT * FROM StaffPayment WHERE DateFrom <= @d1 AND DateTo >= @d2 and StaffID=" + dr.Cells[0].Value.ToString() + "";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Salary already paid..Select correct payment date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                txtStaffID.Text = dr.Cells[0].Value.ToString();
                StaffMaxID.Text = dr.Cells[1].Value.ToString();
                StaffName.Text = dr.Cells[2].Value.ToString();
                Designation.Text = dr.Cells[3].Value.ToString();
                txtSalary.Text = dr.Cells[4].Value.ToString();
                con.Open();
                string cp = "SELECT COUNT(Status) AS Expr1 FROM  StaffAttendance WHERE (Status = 'P')  and  WorkingDate between @d1 and @d2 AND StaffID ='" + txtStaffID.Text + "'";
                cmd = new SqlCommand(cp);
                cmd.Connection = con;
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "WorkingDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "WorkingDate").Value = DateTo.Value.Date;
                dynamic result = cmd.ExecuteScalar();
                PresentDays.Text = Convert.ToString(result) ;
                decimal val1 = 0;
                decimal val2 = 0;
                decimal.TryParse(txtSalary.Text, out val1);
                decimal.TryParse(PresentDays.Text, out val2);
               Salary.Text = ((val1 * val2) / 30).ToString("F");
               if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string cp1 = "select sum(amount)-sum(deduction) from advanceentry where StaffID=" + txtStaffID.Text + "";
                cmd = new SqlCommand(cp1);
                cmd.Connection = con;
                dynamic result1 = cmd.ExecuteScalar();
                Advance.Text = Convert.ToString(result1);
                if (string.IsNullOrEmpty(Advance.Text))
                {
                    Advance.Text = "0.00".ToString();  
                 }
                //if (Advance.Text == null)
                //{
                    
                //}
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                Deduction.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Deduction_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                double val1 = 0;
                double val2 = 0;
                double.TryParse(Advance.Text, out val1);
                double.TryParse(Deduction.Text, out val2);

                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please retrieve Staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStaffID.Focus();
                    return;
                }
                if (paymentmode.Text == "")
                {
                    MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    paymentmode.Focus();
                    return;
                }
                if (Advance.Text == null)
                {
                    Advance.Text = "0".ToString();
                }

                if (val1 < val2)
                {
                    MessageBox.Show("You can not deduct amount more than advance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Deduction.Focus();
                    return;
                }

                if (Convert.ToDecimal(NetPay.Text) < 0)
                {
                    MessageBox.Show("net pay should be more than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DateTo.Value.Date < DateFrom.Value.Date)
                {
                    MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateTo.Focus();
                    return;
                }
                if (DateTo.Value.Date == DateFrom.Value.Date)
                {
                    MessageBox.Show("Selected 'Date From' is equal to 'Date To'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateFrom.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT * FROM StaffPayment WHERE DateFrom <= @d1 AND DateTo >= @d2 and StaffID=" + txtStaffID.Text + "";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Salary already paid..Select correct payment date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update Staffpayment set PaymentID=@d1,DateFrom=@d2,DateTo=@d3,StaffID=@d4,PresentDays=@d5,Salary=@d6,Advance=@d7,Deduction=@d8,PaymentDate=@d9,ModeOfPayment=@d10,PaymentModeDetails=@d11,Netpay=@d12 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", PaymentID.Text);
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@d3", DateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d4", Convert.ToInt32(txtStaffID.Text));
                cmd.Parameters.AddWithValue("@d5", Convert.ToInt32(PresentDays.Text));
                cmd.Parameters.AddWithValue("@d6", Convert.ToDecimal(Salary.Text));
                cmd.Parameters.AddWithValue("@d7", Convert.ToDecimal(Advance.Text));
                cmd.Parameters.AddWithValue("@d8", Convert.ToDecimal(Deduction.Text));
                cmd.Parameters.AddWithValue("@d9", PaymentDate.Value.Date);
                cmd.Parameters.AddWithValue("@d10", paymentmode.Text);
                cmd.Parameters.AddWithValue("@d11", PaymentModeDetails.Text);
                cmd.Parameters.AddWithValue("@d12", Convert.ToDecimal(NetPay.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Paid Salary is Updated For Staff'" + txtStaff.Text + "' having StaffID '" + StaffMaxID.Text + "' and PaymentID '" + PaymentID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully paid", "Staff Salary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteRecord();
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
           frmEmployeeSalaryPaymentList frm = new frmEmployeeSalaryPaymentList(this);
            frm.lblSET.Text = "R2";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PaymentID.Text))
                {
                    MessageBox.Show("Please retrieve Payment ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PaymentID.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT StaffPayment.Id, StaffPayment.PaymentID, StaffPayment.DateFrom, StaffPayment.DateTo, StaffPayment.StaffID, Employee.EMPMAXID, Employee.EmployeeName, Employee.Gender, Employee.DOB,Employee.FatherName, Employee.MotherName, Employee.ContactNo, StaffPayment.PresentDays, StaffPayment.Salary, StaffPayment.Advance, StaffPayment.Deduction, StaffPayment.PaymentDate,StaffPayment.ModeOfPayment, StaffPayment.PaymentModeDetails, StaffPayment.NetPay, Department.DepartmentName, Designations.Designation, School.SchoolName, School.Address,School.ContactNo AS Expr1, School.Email, School.Fax, School.Website, School.City, School.Country, School.Photo FROM StaffPayment INNER JOIN Employee ON StaffPayment.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN School ON Employee.SchoolID = School.SchoolID where StaffPayment.Id=@d1 ", con);
                cmd.Parameters.AddWithValue("@d1", txtID.Text);
                adp = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adp.Fill(table);
                ds = new DataSet();
                con.Close();
                ds.Tables.Add(table);
                ds.WriteXmlSchema("SalaryPayment.xml");
                RptSalaryReceipt rpt = new RptSalaryReceipt();
                rpt.SetDataSource(ds);
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

        private void Advance_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void Salary_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void txtStaff_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Designations.Designation),Rtrim(salary) FROM Employee,Designations where designations.designationID=Employee.Designation_ID  order by EmployeeName where Employee.EmployeeName like '%"+txtStaff.Text+"%'";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                datagridview1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    datagridview1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagridview1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (datagridview1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    datagridview1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void Deduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
