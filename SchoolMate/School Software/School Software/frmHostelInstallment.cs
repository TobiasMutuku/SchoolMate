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
    public partial class frmHostelInstallment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmHostelInstallment()
        {
            InitializeComponent();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm5 = "select installment from HostelFeesPayment where installment=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "installment"));
                cmd.Parameters["@find"].Value = textBox1.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already Use in HostelFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from HostelInstallment  where IHID=" + txtIHID.Text + "";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted HostelInstallment'" + txtInstallment.Text + "' having SchoolName'" + txtSchoolName.Text + "' and Class'" + txtClass.Text + "' and Hostel'" + txtHostel.Text + "'";
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
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct RTRIM(SchoolName) FROM School";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSchoolName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillHostel()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct RTRIM(HostelName) FROM Hostel";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtHostel.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(ClassName) FROM class";
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
        private void frmHostelInstallment_Load(object sender, EventArgs e)
        {
            FillClass();
            FillSchool();
            FillHostel();
            GetData();
        }

        private void txtSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(SchoolID) FROM School where SchoolName = '" + txtSchoolName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSchoolID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassID FROM Class where ClassName = '" + txtClass.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassID.Text = rdr.GetInt32(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(HostelInstallment.IHID),Rtrim(HostelInstallment.Installment),Rtrim(HostelInstallment.Hostel_ID),Rtrim(Hostel.Hostelname),Rtrim(HostelInstallment.School_ID),Rtrim(School.SchoolName),Rtrim(HostelInstallment.Class_ID),Rtrim(Class.ClassName),Rtrim(HostelInstallment.Charges) FROM HostelInstallment INNER JOIN Hostel ON HostelInstallment.Hostel_ID = Hostel.HostelID INNER JOIN School ON HostelInstallment.School_ID = School.SchoolID INNER JOIN Class ON HostelInstallment.Class_ID = Class.ClassID order by Installment,SchoolName,ClassName,HostelName ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtHostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(HostelID) FROM Hostel where HostelName = '" + txtHostel.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txthostelID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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
        txtInstallment.Text = "";
        txtHostel.SelectedIndex = -1;
        txtClass.SelectedIndex = -1;
        txtSchoolName.SelectedIndex = -1;
        txtSearchByClass.Text = "";
        txtCharges.Text = "0.00";
        txtSchoolID.Text = "";
        txthostelID.Text = "";
        txtClassID.Text = "";
        txtIHID.Text = "";
        txtInstallment.Focus();
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
        GetData();
         }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInstallment.Text == "")
            {
                MessageBox.Show("Please enter Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInstallment.Focus();
                return;
            }
            if (txtHostel.Text == "")
            {
                MessageBox.Show("Please enter Hostel Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHostel.Focus();
                return;
            }
            if (txtSchoolName.Text == "")
            {
                MessageBox.Show("Please enter School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSchoolName.Focus();
                return;
            }
            if (txtClass.Text == "")
            {
                MessageBox.Show("Please enter Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClass.Focus();
                return;
            }
            if (txtCharges.Text == "")
            {
                MessageBox.Show("Please enter Charges", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCharges.Focus();
                return;
            }
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string ct = "SELECT School.SchoolName, Hostel.Hostelname, Class.ClassName, HostelInstallment.Installment FROM HostelInstallment INNER JOIN School ON HostelInstallment.School_ID = School.SchoolID INNER JOIN Hostel ON HostelInstallment.Hostel_ID = Hostel.HostelID INNER JOIN Class ON HostelInstallment.Class_ID = Class.ClassID where  HostelInstallment.Installment=@d1 and Hostelname=@d2 and ClassName=@d3 and School.SchoolName=@d4";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
            cmd.Parameters.AddWithValue("@d2", txtHostel.Text);
            cmd.Parameters.AddWithValue("@d3", txtClass.Text);
            cmd.Parameters.AddWithValue("@d4", txtSchoolName.Text);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInstallment.Text = "";
                Reset();
                txtInstallment.Focus();

                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb = "insert into HostelInstallment(Installment, Hostel_ID, Class_ID, School_ID, Charges) VALUES (@d1,@d2,@d3,@d4,@d5)";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
            cmd.Parameters.AddWithValue("@d2", txthostelID.Text);
            cmd.Parameters.AddWithValue("@d3", txtClassID.Text);
            cmd.Parameters.AddWithValue("@d4", txtSchoolID.Text);
            cmd.Parameters.AddWithValue("@d5", txtCharges.Text);
            cmd.ExecuteNonQuery();
            con.Close();
          GetData();
          st1 = lblUser.Text;
          st2 = "Added New HostelInstallment'" + txtInstallment.Text + "' having SchoolName'" + txtSchoolName.Text + "' and Class'" + txtClass.Text + "' and Hostel'" + txtHostel.Text + "'";
          cf.LogFunc(st1, System.DateTime.Now, st2);
           MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
        }

        private void txtSearchByClass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(HostelInstallment.IHID),Rtrim(HostelInstallment.Installment),Rtrim(HostelInstallment.Hostel_ID),Rtrim(Hostel.Hostelname),Rtrim(HostelInstallment.School_ID),Rtrim(School.SchoolName),Rtrim(HostelInstallment.Class_ID),Rtrim(Class.ClassName),Rtrim(HostelInstallment.Charges) FROM HostelInstallment INNER JOIN Hostel ON HostelInstallment.Hostel_ID = Hostel.HostelID INNER JOIN School ON HostelInstallment.School_ID = School.SchoolID INNER JOIN Class ON HostelInstallment.Class_ID = Class.ClassID where Class.classname like '%" + txtSearchByClass.Text + "%' order by 2,3", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearchBySchool_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(HostelInstallment.IHID),Rtrim(HostelInstallment.Installment),Rtrim(HostelInstallment.Hostel_ID),Rtrim(Hostel.Hostelname),Rtrim(HostelInstallment.School_ID),Rtrim(School.SchoolName),Rtrim(HostelInstallment.Class_ID),Rtrim(Class.ClassName),Rtrim(HostelInstallment.Charges) FROM HostelInstallment INNER JOIN Hostel ON HostelInstallment.Hostel_ID = Hostel.HostelID INNER JOIN School ON HostelInstallment.School_ID = School.SchoolID INNER JOIN Class ON HostelInstallment.Class_ID = Class.ClassID where School.Schoolname like '%" + txtsearchBySchool.Text + "%' order by Installment,SchoolName,ClassName,HostelName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtIHID.Text = dr.Cells[0].Value.ToString();
                txtInstallment.Text = dr.Cells[1].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                txthostelID.Text = dr.Cells[2].Value.ToString();
                txtHostel.Text = dr.Cells[3].Value.ToString();
                txtSchoolID.Text = dr.Cells[4].Value.ToString();
                txtSchoolName.Text = dr.Cells[5].Value.ToString();
                txtClassID.Text = dr.Cells[6].Value.ToString();
                txtClass.Text = dr.Cells[7].Value.ToString();
                txtCharges.Text = dr.Cells[8].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                //lblUser.Text = lblUser.Text;
                //lblUserType.Text = lblUserType.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtInstallment.Text == "")
                {
                    MessageBox.Show("Please enter Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInstallment.Focus();
                    return;
                }
                if (txtHostel.Text == "")
                {
                    MessageBox.Show("Please enter Hostel Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostel.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please enter School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please enter Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtCharges.Text == "")
                {
                    MessageBox.Show("Please enter Charges", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCharges.Focus();
                    return;
                }
                if ((txtInstallment.Text) != (txtInstallment1.Text) || (txtHostel.Text) != (txtHostel1.Text) || (txtClass.Text) != (txtclass1.Text) || (txtSchoolName.Text) != (txtSchool1.Text))
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct = "SELECT School.SchoolName, Hostel.Hostelname, Class.ClassName, HostelInstallment.Installment FROM HostelInstallment INNER JOIN School ON HostelInstallment.School_ID = School.SchoolID INNER JOIN Hostel ON HostelInstallment.Hostel_ID = Hostel.HostelID INNER JOIN Class ON HostelInstallment.Class_ID = Class.ClassID where  HostelInstallment.Installment=@d1 and Hostelname=@d2 and ClassName=@d3 and School.SchoolName=@d4";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                    cmd.Parameters.AddWithValue("@d2", txtHostel.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSchoolName.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInstallment.Text = "";
                        Reset();
                        txtInstallment.Focus();

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "update HostelInstallment set Installment=@d1,Hostel_ID=@d2, Class_ID=@d3,School_ID=@d4,Charges=@d5 where IHID=@d6";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d2", txthostelID.Text);
                cmd.Parameters.AddWithValue("@d3", txtClassID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d5", txtCharges.Text);
                cmd.Parameters.AddWithValue("@d6", txtIHID.Text);
                cmd.ExecuteReader();
                GetData();
                st1 = lblUser.Text;
                st2 = "Updated HostelInstallment'" + txtInstallment.Text + "' having SchoolName'" + txtSchoolName.Text + "' and Class'" + txtClass.Text + "' and Hostel'" + txtHostel.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Hostel Installment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb2 = "update HostelFeesPayment set Installment=@d1 where Installment=@d4";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.Parameters.AddWithValue("@d4", textBox1.Text);
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
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
                delete_records();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
