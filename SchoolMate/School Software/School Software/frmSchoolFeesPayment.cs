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
    public partial class frmSchoolFeesPayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmReport frm = new frmReport();
        Connectionstring cs = new Connectionstring();
        public frmSchoolFeesPayment()
        {
            InitializeComponent();
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
            decimal.TryParse(txtCourseFee.Text, out val20);
            decimal.TryParse(txtFine.Text, out val21);
            decimal.TryParse(txtPreviousDue.Text, out val22);
            decimal.TryParse(txtDiscount.Text, out val23);
            decimal I = (val22 + val20 + val21) - val23;
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
                cmd.CommandText = "SELECT Discount from StudentDiscount where Admission_No=@d1 and FeeType='Class'";
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtDiscountPer.Text = rdr.GetValue(0).ToString();
                    decimal val1 = 0;
                    decimal val2 = 0;
                    decimal.TryParse(txtCourseFee.Text, out val1);
                    decimal.TryParse(txtDiscountPer.Text, out val2);
                    decimal I = (val1 * val2) / 100;
                    txtDiscount.Text = I.ToString();
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
                string cq1 = "delete from SchoolFeesPayment where SFP_ID='" + txtSFPID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
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
        txtAdmissionNo.Text = "";
        txtCourseFee.Text = "0.00";
        txtPaymentModeDetails.Text = "";
        txtBalance.Text = "0.00";
        txtClass.Text = "";
        txtDiscount.Text = "0.00";
        txtDiscountPer.Text = "0.00";
        txtEnrollmentNo.Text = "";
        txtFine.Text = "0.00";
        txtGrandTotal.Text = "";
        txtPreviousDue.Text = "0.00";
        txtSchoolName.Text = "";
        txtSection.Text = "";
        txtSession.Text = "";
        txtStudentName.Text = "";
        txtTotalPaid.Text = "0.00";
        cmbPaymentMode.SelectedIndex = 0;
        lvMonth.Items.Clear();
        listView1.Items.Clear();
        dtpPaymentDate.Text = System.DateTime.Now.ToString();
        dgw.Rows.Clear();
        func();
        btnUpdate_record.Enabled = false;
        btnDelete.Enabled = false;
       Button2.Enabled = true;
       btnPrint.Enabled = false;
        dtpPaymentDate.Enabled = true;
        lvMonth.Enabled = true;
        }
        public void fillMonths()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT DISTINCT Rtrim(SchoolFees.Month) FROM SchoolFees INNER JOIN Class ON SchoolFees.Class_ID = Class.ClassID INNER JOIN ClassSection ON Class.ClassID = ClassSection.Class_ID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON SchoolFees.School_ID = School.SchoolID Where ClassName=@d1 and SchoolName=@d2 order by 1", con);
                cmd.Parameters.AddWithValue("@d1", txtClass.Text);
                cmd.Parameters.AddWithValue("@d2", txtSchoolName.Text);
                rdr = cmd.ExecuteReader();
                lvMonth.Items.Clear();
                while (rdr.Read())
                {
                    dynamic item = new ListViewItem();
                    item.Text = rdr[0].ToString().Trim();
                    lvMonth.Items.Add(item);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fillMonthssss()
        {
            try
            {
               con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Distinct Rtrim(CourseFeePayment_Join.Month) FROM SchoolFeesPayment INNER JOIN CourseFeePayment_Join ON SchoolFeesPayment.SFP_ID = CourseFeePayment_Join.SF_PaymentID where Admission_No=@d1  order by 1 desc", con);
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
               rdr = cmd.ExecuteReader();
               listView1.Items.Clear();
                while (rdr.Read())
                {
                    dynamic items = new ListViewItem();
                    items.Text = rdr[0].ToString().Trim();
                    listView1.Items.Add(items);
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
                string sql = "SELECT MAX(SFP_ID+1) FROM SchoolFeesPayment";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtSFPID.Text = Convert.ToString(Num);
                    txtFeePaymentID.Text = Convert.ToString("SFP-" + Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtSFPID.Text = Convert.ToString(Num);
                    txtFeePaymentID.Text = Convert.ToString("SFP-" + Num);
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
            frmStudentList frm = new frmStudentList(this);
            frm.lblSET.Text = "S";
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve Student's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            if (dgw.Rows.Count == 0)
            {
                MessageBox.Show("Please add fees info in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (cmbPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
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
            if (Convert.ToDecimal(txtTotalPaid.Text) == 0)
            {
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
            try
            {
               foreach (DataGridViewRow r in dgw.Rows)
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct = "select Session,Admission_No,Month from SchoolFeesPayment,CourseFeePayment_Join where SchoolFeesPayment.SFP_ID=CourseFeePayment_Join.SF_PaymentID and Session=@d1 and Admission_No=@d2 and Month=@d3";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d2", txtAdmissionNo.Text);
                    cmd.Parameters.AddWithValue("@d3", r.Cells[0].Value);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Fees Already paid ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                Crypto();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into SchoolFeesPayment(SFP_ID,MaxID, Admission_No, Session,TotalFee, DiscountPer, DiscountAmt, PreviousDue, Fine, GrandTotal, TotalPaid, ModeOfPayment, PaymentModeDetails, PaymentDate, PaymentDue,School,Classname,Section) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSFPID.Text);
                cmd.Parameters.AddWithValue("@d2", txtFeePaymentID.Text);
                cmd.Parameters.AddWithValue("@d3", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
                cmd.Parameters.AddWithValue("@d5", txtCourseFee.Text);
                cmd.Parameters.AddWithValue("@d6", txtDiscountPer.Text);
                cmd.Parameters.AddWithValue("@d7", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@d8", txtPreviousDue.Text);
                cmd.Parameters.AddWithValue("@d9", txtFine.Text);
                cmd.Parameters.AddWithValue("@d10", txtGrandTotal.Text);
                cmd.Parameters.AddWithValue("@d11", txtTotalPaid.Text);
                cmd.Parameters.AddWithValue("@d12", cmbPaymentMode.Text);
                cmd.Parameters.AddWithValue("@d13", txtPaymentModeDetails.Text);
                cmd.Parameters.AddWithValue("@d14", dtpPaymentDate.Value.Date);
                cmd.Parameters.AddWithValue("@d15", txtBalance.Text);
                cmd.Parameters.AddWithValue("@d16", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d17", txtClass.Text);
                cmd.Parameters.AddWithValue("@d18", txtSection.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb1 = "insert into CourseFeePayment_Join(SF_PaymentID,Month, FeeID, Fee) VALUES (" + txtSFPID.Text + ",@d1,@d2,@d3)";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Prepare();
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@d2", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@d3", Convert.ToDecimal(row.Cells[2].Value));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                con.Close();
                MessageBox.Show("Successfully paid", "Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
                con.Close();
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='School Fees Payment' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmSchoolFeesPayment_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve Student's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            if (dgw.Rows.Count == 0)
            {
                MessageBox.Show("Please add fees info in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (cmbPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
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
            if (Convert.ToDecimal(txtTotalPaid.Text) == 0)
            {
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
             
             try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update SchoolFeesPayment set MaxID=@d2, Admission_No=@d3, Session=@d4,TotalFee=@d5, DiscountPer=@d6, DiscountAmt=@d7, PreviousDue=@d8, Fine=@d9, GrandTotal=@d10, TotalPaid=@d11, ModeOfPayment=@d12, PaymentModeDetails=@d13,paymentdate=@d14, PaymentDue=@d15,School=@d16,Classname=@d17,Section=@d18 where SfP_ID= " + txtSFPID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d2", txtFeePaymentID.Text);
                cmd.Parameters.AddWithValue("@d3", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d4", txtSession.Text);
                cmd.Parameters.AddWithValue("@d5", txtCourseFee.Text);
                cmd.Parameters.AddWithValue("@d6", txtDiscountPer.Text);
                cmd.Parameters.AddWithValue("@d7", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@d8", txtPreviousDue.Text);
                cmd.Parameters.AddWithValue("@d9", txtFine.Text);
                cmd.Parameters.AddWithValue("@d10", txtGrandTotal.Text);
                cmd.Parameters.AddWithValue("@d11", txtTotalPaid.Text);
                cmd.Parameters.AddWithValue("@d12", cmbPaymentMode.Text);
                cmd.Parameters.AddWithValue("@d13", txtPaymentModeDetails.Text);
                cmd.Parameters.AddWithValue("@d14", dtpPaymentDate.Value.Date);
                cmd.Parameters.AddWithValue("@d15", txtBalance.Text);
                cmd.Parameters.AddWithValue("@d16", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d17", txtClass.Text);
                cmd.Parameters.AddWithValue("@d18", txtSection.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq = "delete from CourseFeePayment_Join where SF_PaymentID= " + txtSFPID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                string cb1 = "insert into CourseFeePayment_Join(SF_PaymentID,Month, FeeID, Fee) VALUES (" + txtSFPID.Text + ",@d1,@d2,@d3)";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Prepare();
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@d2", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@d3", Convert.ToDecimal(row.Cells[2].Value));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                con.Close();
               MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lvMonth_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                
                if (lvMonth.CheckedItems.Count > 0)
                {
                    string Condition = "";

                    for (int I = 0; I <= lvMonth.CheckedItems.Count - 1; I++)
                    {
                        Condition += string.Format("'{0}',", lvMonth.CheckedItems[I].Text);
                    }
                    Condition = Condition.Substring(0, Condition.Length - 1);
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string sql = "Select RTRIM(Month),RTRIM(Feename),Fee,FeeID from SchoolFees,School,Fee,Class where SchoolFees.School_ID=School.SchoolID and Class.ClassID=SchoolFees.Class_ID and Fee.ID=SchoolFees.FeeID and Month in (" + Condition + ") and SchoolName=@d1 and ClassName=@d2 order by Month,FeeName";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@d1", txtSchoolName.Text);
                    cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dgw.Rows.Clear();
                    while ((rdr.Read() == true))
                    {
                        dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                    }
                    con.Close();
                   
                    double sum = 0;
                    foreach (DataGridViewRow r in this.dgw.Rows)
                    {
                        sum = sum +Convert.ToDouble(r.Cells[2].Value);
                    }
                    sum = Math.Round(sum, 2);
                    txtCourseFee.Text = sum.ToString();
                    con.Close();
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT Sum(PaymentDue-PreviousDue) from SchoolFeesPayment where Admission_No=@d1 group by Admission_No";
                    cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
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
                else
                {
                    dgw.Rows.Clear();
                    txtCourseFee.Text = "0.00";
                }
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
                delete_records();
            }
        }

        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmSchoolFeesPaymentList frm = new frmSchoolFeesPaymentList(this);
            frm.lblSET.Text = "R3";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptSchoolFeeRecipt rpt = new RptSchoolFeeRecipt();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlCommand MyCommand1 = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                SqlDataAdapter myDA1 = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.ReadfromXML());
                MyCommand.Connection = myConnection;
                MyCommand1.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM SchoolFeesPayment INNER JOIN CourseFeePayment_Join ON SchoolFeesPayment.SFP_ID = CourseFeePayment_Join.SF_PaymentID INNER JOIN Fee ON CourseFeePayment_Join.FeeId = Fee.Id INNER JOIN Student ON SchoolFeesPayment.Admission_No = Student.AdmissionNo where SchoolFeesPayment.maxid='" + txtFeePaymentID.Text + "'";
                MyCommand1.CommandText = "SELECT * FROM school  where SchoolName='" + txtSchoolName.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                MyCommand1.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA1.SelectCommand = MyCommand1;
                myDA.Fill(myDS, "SchoolFeesPayment");
                myDA.Fill(myDS, "CourseFeePayment_Join");
                myDA.Fill(myDS, "Student");
                myDA1.Fill(myDS, "School");
                myDA.Fill(myDS, "Fee");
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
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from Student's List");

        }

        private void dgw_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void txtDiscountPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPreviousDue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtGrandTotal_KeyPress(object sender, KeyPressEventArgs e)
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

       
        }
    }

