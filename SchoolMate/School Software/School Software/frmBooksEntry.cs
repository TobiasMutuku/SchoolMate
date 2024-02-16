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
    public partial class frmBooksEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm = null;
        string s = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmBooksEntry()
        {
            InitializeComponent();
        }
        public frmBooksEntry(frmMainmenu par)
        {
            frm = par;
            InitializeComponent();
        }
          public void  Reset()
          {
        txtAccessionNo.Text = "";
        txtAuthor.Text = "";
        txtBarcode.Text = "";
        txtBillNo.Text = "";
        txtBookPosition.Text = "";
        txtBookTitle.Text = "";
        txtEdition.Text = "";
        txtSupplierName.Text = "";
        txtISBN.Text = "";
        txtSupplierMax.Text = "";
        txtJointAuthor.Text = "";
        txtLanguage.Text = "";
        txtNoOfPages.Text = "";
        txtPlaceOfPublisher.Text = "";
        txtPrice.Text = "";
        txtPublisherName.Text = "";
        txtPublishingYear.Text = "";
        txtRemarks.Text = "";
        txtSupplierID.Text = "";
        txtVolume.Text = "";
        cmbCategory.SelectedIndex = -1;
        cmbClassification.SelectedIndex = -1;
        cmbSubCategory.SelectedIndex = -1;
        cmbCondition.SelectedIndex = -1;
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSubCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        dtpBillDate.Text = System.DateTime.Now.ToString();
        dtpEntryDate.Text = System.DateTime.Now.ToString();
        cmbCategory.Enabled = false;
        cmbSubCategory.Enabled = false;
        btnSave.Enabled = true;
        btnDelete.Enabled = false;
        btnUpdate_record.Enabled = false;
        rbNormal.Checked = false;
        rbReference.Checked = false;
        txtAccessionNo.Focus();
      }
        private void AutocompletePublisher()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct Publisher FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Publisher"].ToString().Trim().Trim());

                }
                txtPublisherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPublisherName.AutoCompleteCustomSource = col;
                txtPublisherName.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleteTitle()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct BookTitle FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["BookTitle"].ToString().Trim());

                }
                txtBookTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBookTitle.AutoCompleteCustomSource = col;
                txtBookTitle.AutoCompleteMode = AutoCompleteMode.Suggest;
               con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleteAuthor()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct Author FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Author"].ToString().Trim());

                }
                txtAuthor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtAuthor.AutoCompleteCustomSource = col;
                txtAuthor.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompletePosition()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct BookPosition FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["BookPosition"].ToString().Trim());

                }
                txtBookPosition.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBookPosition.AutoCompleteCustomSource = col;
                txtBookPosition.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Autocompletejoint()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct JointAuthors FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["JointAuthors"].ToString().Trim());

                }
                txtJointAuthor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtJointAuthor.AutoCompleteCustomSource = col;
                txtJointAuthor.AutoCompleteMode = AutoCompleteMode.Suggest;

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
                string ctm3 = "select AccessionNo from BookIssue_Student where AccessionNo='" + txtAccessionNo.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Book using on Student's Books Issue List List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAccessionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm4 = "select AccessionNo from BookReservation where AccessionNo='" + txtAccessionNo.Text + "'";
                cmd = new SqlCommand(ctm4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Book using on Staff's Books Reservation List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAccessionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Book where where AccessionNo='"+txtAccessionNo.Text+"'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Book '" + txtAccessionNo.Text + "' is Deleted";
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
        private void AutocompletePlace()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct PlaceOfPublisher FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["PlaceOfPublisher"].ToString().Trim());

                }
                txtPlaceOfPublisher.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPlaceOfPublisher.AutoCompleteCustomSource = col;
                txtPlaceOfPublisher.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompletePLanguage()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct Language FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Language"].ToString().Trim());

                }
                txtLanguage.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtLanguage.AutoCompleteCustomSource = col;
                txtLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            frmBookSupplierList frm = new frmBookSupplierList(this);
            frm.lblSET.Text = "R0";
            frm.Show();
        }

        private void frmBooksEntry_Load(object sender, EventArgs e)
        {
            FillClassification();
            AutocompleteAuthor();
            Autocompletejoint();
            AutocompletePlace();
            AutocompletePLanguage();
            AutocompletePosition();
            AutocompletePublisher();
            AutocompleteTitle();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtAccessionNo.Text == "")
                {
                    MessageBox.Show("Please enter accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccessionNo.Focus();
                    return;
                }
                if (txtBookTitle.Text == "")
                {
                    MessageBox.Show("Please enter book title", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookTitle.Focus();
                    return;
                }
                if (txtAuthor.Text == "")
                {
                    MessageBox.Show("Please enter author", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAuthor.Focus();
                    return;
                }
                if (cmbClassification.Text == "")
                {
                    MessageBox.Show("Please select classification", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClassification.Focus();
                    return;
                }
                if (cmbCategory.Text == "")
                {
                    MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCategory.Focus();
                    return;
                }
                if (cmbSubCategory.Text == "")
                {
                    MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubCategory.Focus();
                    return;
                }
                if (txtPublisherName.Text == "")
                {
                    MessageBox.Show("Please enter publisher", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPublisherName.Focus();
                    return;
                }
                if (((rbNormal.Checked == false) & (rbReference.Checked == false)))
                {
                    MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNoOfPages.Text == "")
                {
                    MessageBox.Show("Please enter no. of pages", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoOfPages.Focus();
                    return;
                }

                if (cmbCondition.Text == "")
                {
                    MessageBox.Show("Please select condition", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCondition.Focus();
                    return;
                }
                if (txtPrice.Text == "")
                {
                    MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
                    return;
                }
                
                if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierID.Focus();
                    return;
                }
                   con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct = "select AccessionNo from Book where AccessionNo=@d1";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        MessageBox.Show("Accession No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAccessionNo.Text = "";
                        txtAccessionNo.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct1 = "select Barcode from Book where Barcode=@d1";
                    cmd = new SqlCommand(ct1);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtBarcode.Text);
                    rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                    {
                        MessageBox.Show("Barcode No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBarcode.Text = "";
                        txtBarcode.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    if ((rbNormal.Checked == true))
                    {
                        s = rbNormal.Text;
                    }
                    if ((rbReference.Checked == true))
                    {
                        s = rbReference.Text;
                    }
                    Fill();
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb = "insert into Book(AccessionNo, BookTitle, EntryDate, Author, JointAuthors, SubCategoryID, Barcode, ISBN, Volume, Edition, Publisher, PlaceOfPublisher, PublishingYear,Section,Language, BookPosition, Price, SupplierID,BillNo, BillDate, NoOfPages, Condition, Status, Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,'Available',@d24)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                    cmd.Parameters.AddWithValue("@d2", txtBookTitle.Text);
                    cmd.Parameters.AddWithValue("@d3", dtpEntryDate.Value.Date);
                    cmd.Parameters.AddWithValue("@d4", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@d5", txtJointAuthor.Text);
                    cmd.Parameters.AddWithValue("@d6", txtSubCategoryid.Text);
                    cmd.Parameters.AddWithValue("@d7", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("@d8", txtISBN.Text);
                    cmd.Parameters.AddWithValue("@d9", txtVolume.Text);
                    cmd.Parameters.AddWithValue("@d10", txtEdition.Text);
                    cmd.Parameters.AddWithValue("@d11", txtPublisherName.Text);
                    cmd.Parameters.AddWithValue("@d12", txtPlaceOfPublisher.Text);
                    cmd.Parameters.AddWithValue("@d13", txtPublishingYear.Text);
                    cmd.Parameters.AddWithValue("@d14", s);
                    cmd.Parameters.AddWithValue("@d15", txtLanguage.Text);
                    cmd.Parameters.AddWithValue("@d16", txtBookPosition.Text);
                    cmd.Parameters.AddWithValue("@d17", Convert.ToDouble(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@d18", txtSupplierID.Text);
                    cmd.Parameters.AddWithValue("@d19", txtBillNo.Text);
                    cmd.Parameters.AddWithValue("@d20", dtpBillDate.Value.Date);
                    cmd.Parameters.AddWithValue("@d21", Convert.ToInt32(txtNoOfPages.Text));
                    cmd.Parameters.AddWithValue("@d22", cmbCondition.Text);
                    cmd.Parameters.AddWithValue("@d24", txtRemarks.Text);
                    cmd.ExecuteReader();
                    con.Close();
                    st1 = lblUser.Text;
                    st2 = "New Book '" + txtBookTitle.Text + "' is Added having AccessionNo='" + txtAccessionNo.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    AutocompleteAuthor();
                    Autocompletejoint();
                    AutocompletePlace();
                    AutocompletePLanguage();
                    AutocompletePosition();
                    AutocompletePublisher();
                    AutocompleteTitle();
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
                string ct1 = "SELECT distinct Rtrim(Classifications.Classification) FROM BooksSubCategory INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClassification.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCategory.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(BooksCategory.CategoryName) FROM BooksSubCategory INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification and Bookscategory.Classification=@d1";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbClassification.Text);
                rdr = cmd.ExecuteReader();
                cmbCategory.Items.Clear();
                while (rdr.Read())
                {
                    cmbCategory.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Fill()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT BooksSubCategory.SubCategoryID FROM BooksSubCategory INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification where BooksCategory.Classification=@d1 and CategoryName=@d2 and SubCategoryName=@d3";
                cmd.Parameters.AddWithValue("@d1", cmbClassification.Text);
                cmd.Parameters.AddWithValue("@d2", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSubCategory.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSubCategoryid.Text = rdr.GetValue(0).ToString();
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

       private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSubCategory.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(BooksSubCategory.SubCategoryName) FROM BooksSubCategory INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification and Bookscategory.Classification=@d1 and CategoryName=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbClassification.Text);
                cmd.Parameters.AddWithValue("@d2", cmbCategory.Text);
                rdr = cmd.ExecuteReader();
                cmbSubCategory.Items.Clear();
                while (rdr.Read())
                {
                    cmbSubCategory.Items.Add(rdr[0]);
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

               if (txtAccessionNo.Text == "")
               {
                   MessageBox.Show("Please enter accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtAccessionNo.Focus();
                   return;
               }
               if (txtBookTitle.Text == "")
               {
                   MessageBox.Show("Please enter book title", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtBookTitle.Focus();
                   return;
               }
               if (txtAuthor.Text == "")
               {
                   MessageBox.Show("Please enter author", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtAuthor.Focus();
                   return;
               }
               if (cmbClassification.Text == "")
               {
                   MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbClassification.Focus();
                   return;
               }
               if (cmbCategory.Text == "")
               {
                   MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbCategory.Focus();
                   return;
               }
               if (cmbSubCategory.Text == "")
               {
                   MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbSubCategory.Focus();
                   return;
               }
               if (txtPublisherName.Text == "")
               {
                   MessageBox.Show("Please enter publisher", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtPublisherName.Focus();
                   return;
               }
               if (((rbNormal.Checked == false) & (rbReference.Checked == false)))
               {
                   MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }

               if (txtNoOfPages.Text == "")
               {
                   MessageBox.Show("Please enter no. of pages", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtNoOfPages.Focus();
                   return;
               }

               if (cmbCondition.Text == "")
               {
                   MessageBox.Show("Please select condition", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbCondition.Focus();
                   return;
               }
               if (txtPrice.Text == "")
               {
                   MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtPrice.Focus();
                   return;
               }
               if (txtSupplierID.Text == "")
               {
                   MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtSupplierID.Focus();
                   return;
               }
              if ((rbNormal.Checked == true))
               {
                   s = rbNormal.Text;
               }
               if ((rbReference.Checked == true))
               {
                   s = rbReference.Text;
               }
               Fill();
               con = new SqlConnection(cs.ReadfromXML());
               con.Open();
               string cb = "Update Book Set BookTitle=@d2, EntryDate=@d3, Author=@d4, JointAuthors=@d5, SubCategoryID=@d6, Barcode=@d7, ISBN=@d8, Volume=@d9, Edition=@d10, Publisher=@d11, PlaceOfPublisher=@d12, PublishingYear=@d13,Section=@d14,Language=@d15, BookPosition=@d16, Price=@d17, SupplierID=@d18,BillNo=@d19, BillDate=@d20, NoOfPages=@d21, Condition=@d22 ,Remarks=@d23 where AccessionNo=@d1";
               cmd = new SqlCommand(cb);
               cmd.Connection = con;
               cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
               cmd.Parameters.AddWithValue("@d2", txtBookTitle.Text);
               cmd.Parameters.AddWithValue("@d3", dtpEntryDate.Value.Date);
               cmd.Parameters.AddWithValue("@d4", txtAuthor.Text);
               cmd.Parameters.AddWithValue("@d5", txtJointAuthor.Text);
               cmd.Parameters.AddWithValue("@d6", txtSubCategoryid.Text);
               cmd.Parameters.AddWithValue("@d7", txtBarcode.Text);
               cmd.Parameters.AddWithValue("@d8", txtISBN.Text);
               cmd.Parameters.AddWithValue("@d9", txtVolume.Text);
               cmd.Parameters.AddWithValue("@d10", txtEdition.Text);
               cmd.Parameters.AddWithValue("@d11", txtPublisherName.Text);
               cmd.Parameters.AddWithValue("@d12", txtPlaceOfPublisher.Text);
               cmd.Parameters.AddWithValue("@d13", txtPublishingYear.Text);
               cmd.Parameters.AddWithValue("@d14", s);
               cmd.Parameters.AddWithValue("@d15", txtLanguage.Text);
               cmd.Parameters.AddWithValue("@d16", txtBookPosition.Text);
               cmd.Parameters.AddWithValue("@d17", Convert.ToDouble(txtPrice.Text));
               cmd.Parameters.AddWithValue("@d18", txtSupplierID.Text);
               cmd.Parameters.AddWithValue("@d19", txtBillNo.Text);
               cmd.Parameters.AddWithValue("@d20", dtpBillDate.Value.Date);
               cmd.Parameters.AddWithValue("@d21", Convert.ToInt32(txtNoOfPages.Text));
               cmd.Parameters.AddWithValue("@d22", cmbCondition.Text);
               cmd.Parameters.AddWithValue("@d23", txtRemarks.Text);
                cmd.ExecuteReader();
               con.Close();
               st1 = lblUser.Text;
               st2 = "Book '" + txtBookTitle.Text + "' is Updated having AccessionNo='"+txtAccessionNo.Text+"'";
               cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnSave.Enabled = false;
               AutocompleteAuthor();
               Autocompletejoint();
               AutocompletePlace();
               AutocompletePLanguage();
               AutocompletePosition();
               AutocompletePublisher();
               AutocompleteTitle();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void btnGetData_Click(object sender, EventArgs e)
       {
           frmBooksList frm = new frmBooksList(this);
           frm.lblSET.Text = "R1";
           frm.ShowDialog();
       }

       private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
       {

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

       private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
           {
               e.Handled = true;
               return;
           }
       }
    }
}
