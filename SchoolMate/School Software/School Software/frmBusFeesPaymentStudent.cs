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
    public partial class frmBusFeesPaymentStudent : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmBusFeesPaymentStudent()
        {
            InitializeComponent();
        }
        public void Fillinstallment()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(BusInstallment.Installment) FROM BusInstallment INNER JOIN Locations ON BusInstallment.Location_ID = Locations.LocationID where  Locations.Location='" + txtLocation.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtInstallment.Items.Clear();
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
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT MAX(BFP_ID+1) FROM BusFeesPayment";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtBFPID.Text = Convert.ToString(Num);
                    txtFeePaymentID.Text = Convert.ToString("BFP-" + Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtBFPID.Text = Convert.ToString(Num);
                    txtFeePaymentID.Text = Convert.ToString("BFP-" + Num);
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
      
        private void Button2_Click(object sender, EventArgs e)
        {
            frmBusHolderStudentList frm = new frmBusHolderStudentList(this);
            frm.lblSET.Text = "R";
            frm.Show();
        }
        public void Fees()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAdmissionNo.Text))
                {
                    MessageBox.Show("Please retrieve busHolder's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdmissionNo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtInstallment.Text))
                {
                    MessageBox.Show("Please select installment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstallment.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct Rtrim(BusInstallment.Charges) FROM BusInstallment,locations where locations.locationID=businstallment.location_ID and Installment=@d1 and location=@d2";
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d2", txtLocation.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBusFee.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Sum(PaymentDue-PreviousDue) from BusFeesPayment where Busholder_ID=@d1 group by Busholder_ID";
                cmd.Parameters.AddWithValue("@d1", txtBusHolderID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtPreviousDue.Text = rdr.GetValue(0).ToString().Trim();
                }
                else
                {
                    txtPreviousDue.Text = ("0".ToString());
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
       
        public void dues()
        {
            decimal val1 = 0;
            decimal val3 = 0;
            decimal.TryParse(txtGrandTotal.Text, out val1);
            decimal.TryParse(txtTotalPaid.Text, out val3);
            decimal I = (val1 - val3);
            txtBalance.Text = I.ToString("F");
        }
        public void Calculate()
        {
            decimal val20 = 0;
            decimal val21 = 0;
            decimal val22 = 0;
            decimal val23 = 0;
            decimal.TryParse(txtBusFee.Text, out val20);
            decimal.TryParse(txtFine.Text, out val21);
            decimal.TryParse(txtPreviousDue.Text, out val22);
            decimal.TryParse(txtDiscount.Text, out val23);
           decimal I = (val22 + val20 + val21)-val23;
            txtGrandTotal.Text = I.ToString("F");
            dues();
           }
        public void Fill()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Discount from StudentDiscount where Admission_No=@d1 and FeeType='Bus'";
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtDiscountPer.Text = rdr.GetValue(0).ToString();
                    decimal val1 = 0;
                    decimal val2 = 0;
                    decimal.TryParse(txtBusFee.Text, out val1);
                    decimal.TryParse(txtDiscountPer.Text, out val2);
                    decimal I = (val1 * val2) / 100;
                    txtDiscount.Text = I.ToString("F");
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from BusFeesPayment where BFP_ID='" + txtBFPID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "BusFeesPayment '" + txtInstallment.Text + " Installment'is Successfully Deleted For Student'" + txtStudentName.Text + "' Having AdmissionNo'" + txtAdmissionNo.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void Reset()
        {
           
            txtInstallment.SelectedIndex = -1;
            txtInstallment.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBFPID.Text="";
            txtBusHolderID.Text="";
            txtFeePaymentID.Text="";
            dtpPaymentDate.Text = System.DateTime.Now.ToString();
            txtPaymentMode.SelectedIndex = -1;
            txtPaymentModeDetails.Text = "";
            txtStudentName.Text = "";
            txtSection.Text = "";
            txtSession.Text = "";
            txtBusFee.Text = "0.00";
            txtDiscountPer.Text = "0.00";
            txtAdmissionNo.Text = "";
            txtClass.Text = "";
            txtSchoolname.Text = "";
            txtLocation.Text = "";
            txtPreviousDue.Text="0.00";
            txtFine.Text="";
            txtDiscount.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtTotalPaid.Text="0.00";
            txtPaymentMode.Text="";
            txtPaymentModeDetails.Text="";
            txtBalance.Text="0.00";
            func();
            btnPrint.Enabled = false;
            Button2.Enabled = true;
            txtInstallment.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            txtAdmissionNo.Focus();
           }
        private void frmBusFeesPaymentStudent_Load(object sender, EventArgs e)
        {
            Reset();
        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Student' and Users.UserID='" + lblUser.Text + "' ";
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
        private void txtInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fees();
        }
       
        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            Fill();
           
        }

        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void txtTotalPaid_Validating(object sender, CancelEventArgs e)
        {
            decimal val1 = 0;
            decimal val3 = 0;
            decimal.TryParse(txtGrandTotal.Text, out val1);
            decimal.TryParse(txtTotalPaid.Text, out val3);
            if (val3 > val1)
            {
                MessageBox.Show("Total Paid can not be more than Grand Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve busHolder's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtInstallment.Text))
            {
                MessageBox.Show("Please select installment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallment.Focus();
                return;
            }
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (txtPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
           
            if (Convert.ToDecimal(txtTotalPaid.Text) < 0)
            {
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
            if (Convert.ToDecimal(txtBalance.Text) < 0)
            {
                MessageBox.Show("Balance is not possible less than zero", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select Session,BusHolder_ID,Installment from BusFeesPayment where Session=@d1 and BusHolder_ID=@d2 and Installment=@d3";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                cmd.Parameters.AddWithValue("@d2", txtBusHolderID.Text);
                cmd.Parameters.AddWithValue("@d3", txtInstallment.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Already paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                Crypto();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into BusFeesPayment(BFP_ID, MaxID, BusHolder_ID, Session,installment,TotalFee, DiscountPer, DiscountAmt, PreviousDue, Fine, GrandTotal, TotalPaid, ModeOfPayment, PaymentModeDetails, PaymentDate, PaymentDue,Location,School,Classname,Section) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtBFPID.Text);
                cmd.Parameters.AddWithValue("@d2", txtFeePaymentID.Text);
                cmd.Parameters.AddWithValue("@d3", txtBusHolderID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
                cmd.Parameters.AddWithValue("@d5", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d6", txtBusFee.Text);
                cmd.Parameters.AddWithValue("@d7", txtDiscountPer.Text);
                cmd.Parameters.AddWithValue("@d8", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@d9", txtPreviousDue.Text);
                cmd.Parameters.AddWithValue("@d10", txtFine.Text);
                cmd.Parameters.AddWithValue("@d11", txtGrandTotal.Text);
                cmd.Parameters.AddWithValue("@d12", txtTotalPaid.Text);
                cmd.Parameters.AddWithValue("@d13", txtPaymentMode.Text);
                cmd.Parameters.AddWithValue("@d14", txtPaymentModeDetails.Text);
                cmd.Parameters.AddWithValue("@d15", dtpPaymentDate.Value);
                cmd.Parameters.AddWithValue("@d16", txtBalance.Text);
                cmd.Parameters.AddWithValue("@d17", txtLocation.Text);
                cmd.Parameters.AddWithValue("@d18", txtSchoolname.Text);
                cmd.Parameters.AddWithValue("@d19", txtClass.Text);
                cmd.Parameters.AddWithValue("@d20", txtSection.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "BusFeesPayment '" + txtInstallment.Text + " Installment'is Successfully Paid By Student'" + txtStudentName.Text + "' Having AdmissionNo'"+txtAdmissionNo.Text+"'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully paid", "Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve busHolder's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtInstallment.Text))
            {
                MessageBox.Show("Please select installment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallment.Focus();
                return;
            }
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (txtPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }

            if (Convert.ToDecimal(txtTotalPaid.Text) < 0)
            {
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
            if (Convert.ToDecimal(txtBalance.Text) < 0)
            {
                MessageBox.Show("Balance is not possible less than zero", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
               con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update BusFeesPayment Set MaxID=@d2, BusHolder_ID=@d3, Session=@d4,installment=@d5,TotalFee=@d6, DiscountPer=@d7, DiscountAmt=@d8, PreviousDue=@d9, Fine=@d10, GrandTotal=@d11, TotalPaid=@d12, ModeOfPayment=@d13, PaymentModeDetails=@d14, PaymentDate=@d15, PaymentDue=@d16,Location=@d17,School=@d18,Classname=@d19,Section=@d20 where BFP_ID=@d1 ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtBFPID.Text);
                cmd.Parameters.AddWithValue("@d2", txtFeePaymentID.Text);
                cmd.Parameters.AddWithValue("@d3", txtBusHolderID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
                cmd.Parameters.AddWithValue("@d5", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d6", txtBusFee.Text);
                cmd.Parameters.AddWithValue("@d7", txtDiscountPer.Text);
                cmd.Parameters.AddWithValue("@d8", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@d9", txtPreviousDue.Text);
                cmd.Parameters.AddWithValue("@d10", txtFine.Text);
                cmd.Parameters.AddWithValue("@d11", txtGrandTotal.Text);
                cmd.Parameters.AddWithValue("@d12", txtTotalPaid.Text);
                cmd.Parameters.AddWithValue("@d13", txtPaymentMode.Text);
                cmd.Parameters.AddWithValue("@d14", txtPaymentModeDetails.Text);
                cmd.Parameters.AddWithValue("@d15", dtpPaymentDate.Value);
                cmd.Parameters.AddWithValue("@d16", txtBalance.Text);
                cmd.Parameters.AddWithValue("@d17", txtLocation.Text);
                cmd.Parameters.AddWithValue("@d18", txtSchoolname.Text);
                cmd.Parameters.AddWithValue("@d19", txtClass.Text);
                cmd.Parameters.AddWithValue("@d20", txtSection.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "BusFeesPayment '" + txtInstallment.Text + " Installment'is Successfully Updated For Student'" + txtStudentName.Text + "' Having AdmissionNo'" + txtAdmissionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated paid", "Bus Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmBusFeePaymentListStudent frm = new frmBusFeePaymentListStudent(this);
            frm.lblSET.Text = "R1";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
           } 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptBusFeeReceipt  rpt = new RptBusFeeReceipt();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlCommand MyCommand1 = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                SqlDataAdapter myDA1 = new SqlDataAdapter();
                 DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                MyCommand1.Connection = myConnection;
                MyCommand.CommandText = "SELECT  *  FROM  BusFeesPayment INNER JOIN StudentBusHolder ON BusFeesPayment.BusHolder_ID = StudentBusHolder.BusHolderID INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo INNER JOIN Locations ON StudentBusHolder.Location_ID = Locations.LocationID where BusFeesPayment.Maxid='" + txtFeePaymentID .Text + "'";
                MyCommand1.CommandText = "SELECT *  FROM  School where SchoolName='" + txtSchoolname.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                MyCommand1.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA1.SelectCommand = MyCommand1;
                myDA.Fill(myDS, "BusFeesPayment");
                myDA.Fill(myDS, "Locations");
                myDA.Fill(myDS, "Student");
                myDA1.Fill(myDS, "School");
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from BusHolder's List");
        }

        private void txtFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTotalPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

      }
}
