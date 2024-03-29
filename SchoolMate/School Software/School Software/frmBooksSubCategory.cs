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
    public partial class frmBooksSubCategory : Form
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
        public frmBooksSubCategory()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BooksSubCategory.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksSubCategory.Category_ID),Rtrim(BooksCategory.CategoryName),Rtrim(BooksCategory.Classification) FROM BooksSubCategory INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
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
            txtCategory.Text = "";
            txtClassification.SelectedIndex = -1;
            txtCategory.SelectedIndex = -1;
            txtSubCategory.Text = "";
            txtSubCategory.Text = "";
            txtSubcategoryID.Text = "";
            txtSearchBySubCategory.Text = "";
            txtCategoryID.Text = "";
            txtCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            FillClassification();
            GetData();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnSave.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubCategory.Text == "")
                {
                    MessageBox.Show("Please Select SubCategory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubCategory.Focus();
                    return;
                }
                if (txtClassification.Text == "")
                {
                    MessageBox.Show("Please Select Classification of Book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassification.Focus();
                    return;
                }
                if (txtCategory.Text == "")
                {
                    MessageBox.Show("Please Enter CategoryName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategory.Focus();
                    return;
                }
               
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(BooksCategory.Classification) FROM BooksCategory INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN BooksSubCategory ON BooksCategory.CategoryID = BooksSubCategory.Category_ID  where CategoryName=@d1 and Classifications.Classification=@d2 and SubcategoryName=@d3";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtCategory.Text);
                cmd.Parameters.AddWithValue("@d2", txtClassification.Text);
                cmd.Parameters.AddWithValue("@d3", txtSubCategory.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassification.Text = "";
                    txtSubCategory.Text = "";
                    txtCategory.Text = "";
                    Reset();
                    txtSubCategory.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into BooksSubCategory(SubCategoryName,Category_ID) VALUES (@d1,@d2)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubCategory.Text);
                cmd.Parameters.AddWithValue("@d2", txtCategoryID.Text);
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "BookSubcategory '" + txtSubCategory.Text + "' is Added";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        public void FillClassification()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(BooksCategory.Classification) FROM BooksCategory INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtClassification.Items.Clear();
                while (rdr.Read())
                {
                    txtClassification.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBooksSubCategory_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(BooksCategory.CategoryID) FROM BooksCategory INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification and BooksCategory.Classification=@d1 and CategoryName=@d2"; 
               cmd.Connection = con;
              cmd.Parameters.AddWithValue("@d2", txtCategory.Text);
              cmd.Parameters.AddWithValue("@d1", txtClassification.Text);
              rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtCategoryID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtSubcategoryID.Text = dr.Cells[0].Value.ToString();
                txtSubCategory.Text = dr.Cells[1].Value.ToString();
                txtCategoryID.Text = dr.Cells[2].Value.ToString();
                txtCategory.DropDownStyle = ComboBoxStyle.DropDown;
                txtCategory.Text = dr.Cells[3].Value.ToString();
                txtClassification.Text = dr.Cells[4].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtSearchBySubCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BooksSubCategory.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksSubCategory.Category_ID),Rtrim(BooksCategory.CategoryName),Rtrim(BooksCategory.Classification) FROM BooksSubCategory INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification and SubcategoryName like '%" + txtSearchBySubCategory.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
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
                if (txtSubCategory.Text == "")
                {
                    MessageBox.Show("Please Select SubCategory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubCategory.Focus();
                    return;
                }
                if (txtClassification.Text == "")
                {
                    MessageBox.Show("Please Select Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassification.Focus();
                    return;
                }
                if (txtCategory.Text == "")
                {
                    MessageBox.Show("Please Enter CategoryName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategory.Focus();
                    return;
                }

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update BooksSubCategory set SubCategoryName=@d1,Category_ID=@d2 Where SubcategoryID=@d3";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubCategory.Text);
                cmd.Parameters.AddWithValue("@d2", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSubcategoryID.Text);
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "BookSubcategory '" + txtSubCategory.Text + "' is Updated";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

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
                string ctm4 = "select SubCategoryID from Book where SubCategoryID='" + txtSubcategoryID.Text + "'";
                cmd = new SqlCommand(ctm4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Book  SubCategory using on Books List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSubCategory.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from BooksSubCategory where SubCategoryID='" + txtSubcategoryID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "BookSubcategory '" + txtSubCategory.Text + "' is Deleted";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void txtClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(BooksCategory.CategoryName) FROM BooksCategory INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification Where BooksCategory.Classification='" + txtClassification.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtCategory.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
