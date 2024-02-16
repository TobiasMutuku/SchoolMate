using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmBooksList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmBooksEntry frmBookEntry = null;
        frmBookReservations frmBR = null;
        frmBookIssue frmBI = null;
        public frmBooksList()
        {
            InitializeComponent();
        }
        public frmBooksList(frmBooksEntry par)
        {
            frmBookEntry = par;
            InitializeComponent();
        }
        public frmBooksList(frmBookReservations par1)
        {
            frmBR = par1;
            InitializeComponent();
        }
        public frmBooksList(frmBookIssue par2)
        {
            frmBI = par2;
            InitializeComponent();
        }
        public void Reset()
    {
        txtAccessionNo.Text = "";
        txtBookTitle.Text = "";
        txtCategory.Text = "";
        txtClassifications.Text = "";
        txtLanguage.Text = "";
        txtPublisher.Text = "";
        txtSubCategory.Text = "";
        cmbCondition.SelectedIndex = -1;
        cmbStatus.SelectedIndex = -1;
        dtpDateFrom.Text=System.DateTime.Now.ToString();
        dtpDateTo.Text =System.DateTime.Now.ToString();
        Auto();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID", con);
               rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBooksList_Load(object sender, EventArgs e)
        {
            Auto();
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

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.AccessionNo like '%" + txtAccessionNo.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.BookTitle like '%" + txtBookTitle.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where BooksCategory.CategoryName like '%" + txtCategory.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtSubCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where BooksSubCategory.SubCategoryName like '%" + txtSubCategory.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtClass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Classifications.Classification like '%" + txtClassifications.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Publisher like '%" + txtPublisher.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void cmbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Condition ='" + cmbCondition.Text + "' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where BillDate Between @date1 and @Date2 order by AccessionNo ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Language like '%" + txtLanguage.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Status ='" + cmbStatus.Text + "' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R1")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    frmBookEntry.Activate();
                    this.BringToFront();
                    frmBookEntry.txtAccessionNo.Text = dr.Cells[0].Value.ToString();
                    frmBookEntry.txtAccessionNo1.Text = dr.Cells[0].Value.ToString();
                    frmBookEntry.txtBookTitle.Text = dr.Cells[1].Value.ToString();
                    frmBookEntry.dtpEntryDate.Text = dr.Cells[2].Value.ToString();
                    frmBookEntry.txtBookPosition.Text = dr.Cells[3].Value.ToString();
                    frmBookEntry.txtNoOfPages.Text = dr.Cells[4].Value.ToString();
                    frmBookEntry.txtLanguage.Text = dr.Cells[5].Value.ToString();
                
                    frmBookEntry.txtSubCategoryid.Text = dr.Cells[6].Value.ToString();
                    frmBookEntry.cmbSubCategory.DropDownStyle=ComboBoxStyle.DropDown;
                    frmBookEntry.cmbSubCategory.Text = dr.Cells[7].Value.ToString();
                    frmBookEntry.cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                    frmBookEntry.cmbCategory.Text = dr.Cells[8].Value.ToString();
                    frmBookEntry.cmbClassification.Text = dr.Cells[9].Value.ToString();
                    frmBookEntry.txtAuthor.Text = dr.Cells[10].Value.ToString();
                    frmBookEntry.txtJointAuthor.Text = dr.Cells[11].Value.ToString();
                    frmBookEntry.txtPublisherName.Text = dr.Cells[12].Value.ToString();
                    frmBookEntry.txtPlaceOfPublisher.Text = dr.Cells[13].Value.ToString();
                    frmBookEntry.txtPublishingYear.Text = dr.Cells[14].Value.ToString();
                    frmBookEntry.txtEdition.Text = dr.Cells[15].Value.ToString();
                    frmBookEntry.txtBarcode.Text = dr.Cells[16].Value.ToString();
                    frmBookEntry.txtISBN.Text = dr.Cells[17].Value.ToString();
                    frmBookEntry.txtVolume.Text = dr.Cells[18].Value.ToString();
                    frmBookEntry.txtSupplierID.Text = dr.Cells[19].Value.ToString();
                    frmBookEntry.txtSupplierMax.Text = dr.Cells[20].Value.ToString();
                    frmBookEntry.txtSupplierName.Text = dr.Cells[21].Value.ToString();
                    frmBookEntry.txtBillNo.Text = dr.Cells[22].Value.ToString();
                    frmBookEntry.dtpBillDate.Text = dr.Cells[23].Value.ToString();
                    frmBookEntry.txtPrice.Text = dr.Cells[24].Value.ToString();
                    frmBookEntry.cmbCondition.Text = dr.Cells[25].Value.ToString();
                    if ((dr.Cells[27].Value.ToString() == "Normal"))
                    {
                        frmBookEntry.rbNormal.Checked = true;
                    }
                    if ((dr.Cells[27].Value.ToString() == "Reference"))
                    {
                        frmBookEntry.rbReference.Checked = true;
                    }
                    frmBookEntry.txtRemarks.Text = dr.Cells[28].Value.ToString();
                    frmBookEntry.btnUpdate_record.Enabled = true;
                    frmBookEntry.btnDelete.Enabled = true;
                    frmBookEntry.btnSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (lblSET.Text == "BR")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmBR.Show();
                frmBR.txtAccessionNo.Text = dr.Cells[0].Value.ToString();
                frmBR.txtBookTitle.Text = dr.Cells[1].Value.ToString();
                frmBR.txtAuthor.Text = dr.Cells[10].Value.ToString();
                frmBR.txtJointAuthor.Text = dr.Cells[11].Value.ToString();
            }
            else if (lblSET.Text == "BI")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmBI.Show();
                frmBI.txtAccessionNo.Text = dr.Cells[0].Value.ToString();
                frmBI.txtBookTitle.Text = dr.Cells[1].Value.ToString();
                frmBI.txtAuthor.Text = dr.Cells[10].Value.ToString();
                frmBI.txtJointAuthor.Text = dr.Cells[11].Value.ToString();
                frmBI.fillStudents();
              
            }
            else if (lblSET.Text == "BIS")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmBI.Show();
                frmBI.txtAccessionNo1.Text = dr.Cells[0].Value.ToString();
                frmBI.txtBookTitle1.Text = dr.Cells[1].Value.ToString();
                frmBI.txtAuthor1.Text = dr.Cells[10].Value.ToString();
                frmBI.txtJointAuthors1.Text = dr.Cells[11].Value.ToString();
                frmBI.FillStaffs();
            }
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add data in datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = DataGridView1.RowCount;
                colsTotal = DataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }
    }
}
