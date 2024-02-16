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
    public partial class frmBooksFineSetting : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmBooksFineSetting()
        {
            InitializeComponent();
        }

        private void frmBooksFineSetting_Load(object sender, EventArgs e)
        {
            Getdata();
        }
        public void Reset()
        {
            txtMaxDaysAllowedStaff.Text = "";
            txtFinePerDayStaff.Text = "";
            txtFinePerDayStudent.Text = "";
            txtMaxDaysAllowedStudent.Text = "";
            txtMaxBooksAllowedStaff.Text = "";
            txtMaxBooksAllowedStudent.Text = "";
            cmbBookType.SelectedIndex = -1;
            textBox1.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtMaxDaysAllowedStaff.Focus();
        }
        public void Getdata()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML() );
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(BookType),MaxBooks_Student,MaxBooks_Staff, MaxDays_Student, MaxDays_Staff, FinePerDay_Student, FinePerDay_Staff from setting order by BookType", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                }
                con.Close();
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
                string cq1 = "delete from Setting where where BookType=@d1";
                cmd = new SqlCommand(cq1);
                cmd.Parameters.AddWithValue("@d1", cmbBookType.Text);
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
                Getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBookType.Text))
            {
                MessageBox.Show("Please select book type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBookType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStaff.Text))
            {
                MessageBox.Show("Please enter fine per day (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStudent.Text))
            {
                MessageBox.Show("Please enter fine per day (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStudent.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select BookType from Setting where BookType=@d1";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", cmbBookType.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Setting for selected book type Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML() );
                con.Open();

                string cb = "insert into Setting(BookType, MaxDays_Staff, MaxDays_Student, FinePerDay_Student, FinePerDay_Staff,MaxBooks_Staff,MaxBooks_Student) VALUES ('" + cmbBookType.Text + "'," + txtMaxDaysAllowedStaff.Text + "," + txtMaxDaysAllowedStudent.Text + "," + txtFinePerDayStudent.Text + "," + txtFinePerDayStaff.Text + "," + txtMaxBooksAllowedStaff.Text + "," + txtMaxBooksAllowedStudent.Text + ")";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
               Getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1 .SelectedRows[0];
                cmbBookType.Text = dr.Cells[0].Value.ToString();
                textBox1.Text = dr.Cells[0].Value.ToString();
                txtMaxBooksAllowedStudent.Text = dr.Cells[1].Value.ToString();
                txtMaxBooksAllowedStaff.Text = dr.Cells[2].Value.ToString();
                txtMaxDaysAllowedStudent.Text = dr.Cells[3].Value.ToString();
                txtMaxDaysAllowedStaff.Text = dr.Cells[4].Value.ToString();
                txtFinePerDayStudent.Text = dr.Cells[5].Value.ToString();
                txtFinePerDayStaff.Text = dr.Cells[6].Value.ToString();
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try{
            if (string.IsNullOrEmpty(cmbBookType.Text))
            {
                MessageBox.Show("Please select book type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBookType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStaff.Text))
            {
                MessageBox.Show("Please enter fine per day (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStudent.Text))
            {
                MessageBox.Show("Please enter fine per day (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStudent.Focus();
                return;
            }
          
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update Setting Set MaxDays_Staff=@d2, MaxDays_Student=@d3, FinePerDay_Student=@d4, FinePerDay_Staff=@d5,MaxBooks_Staff=@d6,MaxBooks_Student=@d7,BookType=@d1 where BookType=@d8";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbBookType.Text);
                cmd.Parameters.AddWithValue("@d2", txtMaxDaysAllowedStaff.Text);
                cmd.Parameters.AddWithValue("@d3", txtMaxDaysAllowedStudent.Text);
                cmd.Parameters.AddWithValue("@d4", txtFinePerDayStudent .Text);
                cmd.Parameters.AddWithValue("@d5", txtFinePerDayStaff .Text);
                cmd.Parameters.AddWithValue("@d6", txtMaxBooksAllowedStaff  .Text);
                cmd.Parameters.AddWithValue("@d7", txtMaxBooksAllowedStudent.Text);
                cmd.Parameters.AddWithValue("@d8", textBox1.Text);
               cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                Getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtMaxBooksAllowedStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMaxBooksAllowedStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMaxDaysAllowedStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMaxDaysAllowedStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFinePerDayStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtFinePerDayStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
