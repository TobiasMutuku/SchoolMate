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
    public partial class frmBookIssueListStudent : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmBookIssue BI =null;
         frmBookReturn BR = null;
        public frmBookIssueListStudent()
        {
            InitializeComponent();
        }
         public frmBookIssueListStudent(frmBookIssue Par)
        {
              BI =Par;
            InitializeComponent();
        }
         public frmBookIssueListStudent(frmBookReturn Par1)
         {
             BR = Par1;
             InitializeComponent();
         }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBookIssueListStudent_Load(object sender, EventArgs e)
        {
            Auto();
        }
        public void Reset()
        {
            txtAccessionNo.Text = "";
            txtBookTitle.Text = "";
            txtAddmissionNo.Text = "";
            txtStudentName.Text = "";
            txtBookTitle.Text = "";
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            txtFrom.Text = System.DateTime.Now.ToString();
            txtTo.Text = System.DateTime.Now.ToString();
            Auto();
        }
        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
             try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID Where BookIssue_Student.AccessionNo like '%" + txtAccessionNo.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
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
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID Where Book.BookTitle like '%" + txtBookTitle.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAddmissionNo_TextChanged(object sender, EventArgs e)
        {
         try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID Where BookIssue_Student.AdmissionNo like '%" + txtAddmissionNo.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
           try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID Where Student.StudentName like '%" + txtStudentName.Text + "%' Order by DueDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
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
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID Where IssueDate Between @date1 and @Date2 Order by DueDate", con);
                 cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnduedate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookIssue_Student.ID),BookIssue_Student.IssueDate,BookIssue_Student.DueDate,Rtrim(BookIssue_Student.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookIssue_Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(BookIssue_Student.Status),Rtrim(BookIssue_Student.Remarks) FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN School ON Student.School_ID = School.SchoolID Where DueDate Between @date1 and @Date2 Order by DueDate", con);
                 cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DueDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DueDate").Value = txtTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
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
                    BI.Activate();
                    BI.BringToFront();
                    BI.txtID.Text = dr.Cells[0].Value.ToString();
                    BI.dtpIssueDate.Text = dr.Cells[1].Value.ToString();
                    BI.dtpDueDate.Text = dr.Cells[2].Value.ToString();
                    BI.txtAccessionNo.Text = dr.Cells[3].Value.ToString();
                    BI.txtBookTitle.Text = dr.Cells[4].Value.ToString();
                    BI.txtAuthor.Text = dr.Cells[5].Value.ToString();
                    BI.txtJointAuthor.Text = dr.Cells[6].Value.ToString();
                    BI.txtAdmissionNo.Text = dr.Cells[7].Value.ToString();
                    BI.txtStudentName.Text = dr.Cells[8].Value.ToString();
                    BI.txtClass.Text = dr.Cells[10].Value.ToString();
                    BI.txtStatus.Text = dr.Cells[12].Value.ToString();
                    BI.txtRemarks.Text = dr.Cells[13].Value.ToString();
                    BI.btnSave.Enabled = true;
                    BI.fillStudents();
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + lblUser.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        lblupdate.Text = rdr[0].ToString().Trim();
                        lbldelete.Text = rdr[1].ToString().Trim();

                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    if (lblupdate.Text == "True")
                        BI.btnUpdate_record.Enabled = true;
                    else
                        BI.btnUpdate_record.Enabled = false;


                    if (lbldelete.Text == "True")
                        BI.btnDelete.Enabled = true;
                    else
                        BI.btnDelete.Enabled = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BR")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    BR.Activate();
                    BR.BringToFront();
                    BR.Reset();
                    BR.txtIssueID_Student.Text = dr.Cells[0].Value.ToString();
                    BR.dtpIssueDate.Text = dr.Cells[1].Value.ToString();
                    BR.dtpDueDate.Text = dr.Cells[2].Value.ToString();
                    BR.txtAccessionNo.Text = dr.Cells[3].Value.ToString();
                    BR.txtBookTitle.Text = dr.Cells[4].Value.ToString();
                    BR.txtAuthor.Text = dr.Cells[5].Value.ToString();
                    BR.txtJointAuthor.Text = dr.Cells[6].Value.ToString();
                    BR.txtAdmissionNo.Text = dr.Cells[7].Value.ToString();
                    BR.txtStudentName.Text = dr.Cells[8].Value.ToString();
                    BR.txtClass.Text = dr.Cells[10].Value.ToString();
                    BR.btnUpdate_record.Enabled = false;
                    BR.btnDelete.Enabled = false;
                    BR.btnSave.Enabled = true;
                    BR.FillData();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }

        private void txtTo_Validating(object sender, CancelEventArgs e)
        {
            if ((txtFrom.Value.Date) > (txtTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTo.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
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
