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
    public partial class frmGradingLevels : Form
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
        public frmGradingLevels()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtGradeID.Text = "";
            txtGradeName.Text = "";
            txtGradePoint.Text = "";
            txtTo.Text = "";
            txtminScore.Text = "";
            txtRemark.Text = "";
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Grades where GradeId='" + txtGradeID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Deleted the Grade'" + txtGradeName .Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
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
                GetData();
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
                cmd = new SqlCommand("SELECT RTRIM(Gradeid),RTRIM(Grade),RTRIM(ScoreFrom),RTRIM(ScoreTo),Rtrim(GradePoint),RTRIM(Remark) from Grades order by Gradepoint desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmGradingLevels_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGradeName.Text == "")
                {
                    MessageBox.Show("Please enter Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGradeName.Focus();
                    return;
                }
                if (txtminScore.Text == "")
                {
                    MessageBox.Show("Please enter MinScore ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtminScore.Focus();
                    return;
                }
                if (txtTo.Text == "")
                {
                    MessageBox.Show("Please enter Marks To ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTo.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select Grade from Grades where Grade='" + txtGradeName.Text + "'";
               cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Grade Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGradeName.Text = "";
                    txtGradeName.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into Grades(Grade,ScoreFrom,ScoreTo,GradePoint,Remark) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtGradeName.Text);
                cmd.Parameters.AddWithValue("@d2", txtminScore.Text);
                cmd.Parameters.AddWithValue("@d3", txtTo.Text);
                cmd.Parameters.AddWithValue("@d4", txtGradePoint.Text);
                cmd.Parameters.AddWithValue("@d5", txtRemark.Text);
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "added New  Grade  '" + txtGradeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGradeName.Text == "")
                {
                    MessageBox.Show("Please enter Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGradeName.Focus();
                    return;
                }
                if (txtminScore.Text == "")
                {
                    MessageBox.Show("Please enter MinScore ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtminScore.Focus();
                    return;
                }
                if (txtTo.Text == "")
                {
                    MessageBox.Show("Please enter Marks To ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTo.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update Grades set Grade=@d1,ScoreFrom=@d2,ScoreTo=@d3,GradePoint=@d4,Remark=@d5 where GradeID=@d6";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtGradeName.Text);
                cmd.Parameters.AddWithValue("@d2", txtminScore.Text);
                cmd.Parameters.AddWithValue("@d3", txtTo.Text);
                cmd.Parameters.AddWithValue("@d4", txtGradePoint.Text);
                cmd.Parameters.AddWithValue("@d5", txtRemark.Text);
                cmd.Parameters.AddWithValue("@d6", txtGradeID.Text);
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "Updated Grade  '" + txtGradeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
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
                GetData();
            } 
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtGradeID.Text = dr.Cells[0].Value.ToString();
                txtGradeName.Text = dr.Cells[1].Value.ToString();
                txtminScore.Text = dr.Cells[2].Value.ToString();
                txtTo.Text = dr.Cells[3].Value.ToString();
                txtGradePoint.Text = dr.Cells[4].Value.ToString();
                txtRemark.Text = dr.Cells[5].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled =true;
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGradePoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtminScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
