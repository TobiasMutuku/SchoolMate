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
    public partial class frmClassEntry : Form
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
        public frmClassEntry()
        {
            InitializeComponent();
        }
        public void FillClassType()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(ClassType) FROM ClassTypes ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtClassType.Items.Clear();
                while (rdr.Read())
                {
                   txtClassType.Items.Add(rdr[0]);
                }
                con.Close();
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
                cmd = new SqlCommand("SELECT Class.ClassID,Class.classname, Class.ClassType_ID, ClassTypes.ClassType FROM  Class INNER JOIN ClassTypes ON Class.ClassType_ID = ClassTypes.ClassTypeID order by Classid", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2], rdr[3]);
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
                string ct = "select Class_ID from classSection where Class_ID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on Class Section Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm = "select Class_ID from SchoolFees where Class_ID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(ctm);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on School Fees List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm1 = "select Class_ID from HostelInstallment where Class_ID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(ctm1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on HostelInstallment Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm2 = "select ClassID from Subject where ClassID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on Subject List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm5 = "select Classname from BusFeesPayment where Classname=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Classname"));
                cmd.Parameters["@find"].Value = txtClass.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on Bus Fees Payment List Form..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm6 = "select Classname from HostelFeesPayment where Classname=@find";
                cmd = new SqlCommand(cm6);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Classname"));
                cmd.Parameters["@find"].Value = txtClass.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on  HostelFeesPayment List Form..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm7 = "select Classname from SchoolFeesPayment where Classname=@find";
                cmd = new SqlCommand(cm7);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Classname"));
                cmd.Parameters["@find"].Value = txtClass.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class using on  SchoolFeesPayment List Form..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Class where ClassID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                     st1 = lblUser.Text;
                    st2 = "Deleted the Class='" + txtClass.Text + "'";
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
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmClassEntry_Load(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            textBox1.Text = "";
            txtSectionID.Text = "";
            txtClassID.Text = "";
            txtClassTypeID.Text = "";
            txtClassType.SelectedIndex = -1;
            txtClass.Text = "";
            FillClassType();
            GetData();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            //func();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtClassType.Text == "")
                {
                    MessageBox.Show("Please Select Class Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassType.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select className from class where className='" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into class(ClassName,ClassType_ID) VALUES (@d1,@d2)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtClass.Text);
                cmd.Parameters.AddWithValue("@d2", txtClassTypeID.Text);
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "Added the New Class='" + txtClass.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassTypeID FROM ClassTypes WHERE ClassType = '" + txtClassType.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassTypeID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtClassType.Text == "")
                {
                    MessageBox.Show("Please Select Class Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassType.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb2 = "Update class set Classname= '" + txtClass.Text + "',ClassType_ID= '" +txtClassTypeID.Text + "' where classID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                GetData();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb3 = "Update BusFeesPayment set Classname= '" + txtClass.Text + "' where Classname='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb4 = "Update HostelFeesPayment set Classname= '" + txtClass.Text + "' where Classname='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb4);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb5 = "Update SchoolFeesPayment set Classname= '" + txtClass.Text + "' where Classname='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb5);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Updated the Class='" + txtClass.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnUpdate_record.Enabled = false;
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
              txtClassID.Text = dr.Cells[0].Value.ToString();
              txtClass.Text = dr.Cells[1].Value.ToString();
              textBox1.Text = dr.Cells[1].Value.ToString();
              txtClassTypeID.Text = dr.Cells[2].Value.ToString();
              txtClassType.Text = dr.Cells[3].Value.ToString();
              btnSave.Enabled = false;
              btnUpdate_record.Enabled = true;
              btnDelete.Enabled = true;
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

      private void btnNewRecord_Click(object sender, EventArgs e)
      {
          Reset();
      }
    }
}
