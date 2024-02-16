﻿using System;
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
    public partial class frmSectionEntry : Form
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
        public frmSectionEntry()
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
                string ctm3 = "select Section_ID from ClassSection where Section_ID='" + txtSectionID.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Section using on Class Section Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSectionName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm5 = "select Section from BusFeesPayment where Section=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 30, "Section"));
                cmd.Parameters["@find"].Value = txtSectionName.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already use in BusFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cm3 = "select Section from HostelFeesPayment where Section=@find";
                cmd = new SqlCommand(cm3);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 30, "Section"));
                cmd.Parameters["@find"].Value = txtSectionName.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already use in HostelFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Section where sectionId='" + txtSectionID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
               if (RowsAffected > 0)
               {
                   st1 = lblUser.Text;
                   st2 = "Section '" + txtSectionName.Text + "' is Deleted Successfully";
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
        private void frmSectionEntry_Load(object sender, EventArgs e)
        {
            Reset();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(SectionID),Rtrim(SectionName) FROM Section order by Sectionname", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txtSectionID.Text = "";
            txtSectionName.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            GetData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSectionName.Text == "")
                {
                    MessageBox.Show("Please enter Section name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSectionName.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select SectionName from Section where SectionName='" + txtSectionName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Section Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSectionName.Text = "";
                    txtSectionName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into Section(SectionName) VALUES ('" + txtSectionName.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                Reset();
                st1 = lblUser.Text;
                st2 = "Section '" + txtSectionName.Text + "' is Added Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

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
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtSectionID.Text = dr.Cells[0].Value.ToString();
                txtSectionName.Text = dr.Cells[1].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSectionName.Text == "")
                {
                    MessageBox.Show("Please enter Section name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSectionName.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select SectionID from Section where sectionID='" + txtSectionID.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb2 = "Update Section set SectionName= '" + txtSectionName.Text + "' where sectionID = '" + txtSectionID.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
                else
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb1 = "insert into Section(Sectionname) VALUES ('" + txtSectionName.Text + "')";
                    cmd = new SqlCommand(cb1);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
                GetData();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb3 = "Update BusFeesPayment set Section= '" + txtSectionName.Text + "' where section= '" + textBox1.Text + "'";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cbz = "Update HostelFeesPayment set Section= '" + txtSectionName.Text + "' where section= '" + textBox1.Text + "'";
                cmd = new SqlCommand(cbz);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb5 = "Update SchoolFeesPayment set Section= '" + txtSectionName.Text + "' where section= '" + textBox1.Text + "'";
                cmd = new SqlCommand(cb5);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Section '" + txtSectionName.Text + "' is Updated Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;

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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
