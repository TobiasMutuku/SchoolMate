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
    public partial class frmSubjectList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmSubjectsEntry frm = null;
        
        public frmSubjectList()
        {
            InitializeComponent();
        }
        public frmSubjectList(frmSubjectsEntry par1)
        {
            frm = par1;
            InitializeComponent();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Subject.SessionID),Rtrim(Sessions.Session),Rtrim(Subject.SchoolID),Rtrim(School.SchoolName),Rtrim(Subject.ClassID),Rtrim(Class.ClassName),Rtrim(Subject.SubjectType),Rtrim(Subject.MaxClasses),Rtrim(Subject.TimeFrom),Rtrim(Subject.TimeTo) FROM Subject INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID order By Subjectcode,Session,SchoolName,ClassName,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSubjectList_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
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
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R3")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    frm.Activate();
                    this.BringToFront();
                    frm.textBox1.Text = dr.Cells[0].Value.ToString();
                    frm.txtSubjectCode.Text = dr.Cells[1].Value.ToString();
                    frm.subjectcodesss.Text = dr.Cells[1].Value.ToString();
                    frm.txtSubjectName.Text = dr.Cells[2].Value.ToString();
                    frm.txtSessionID.Text = dr.Cells[3].Value.ToString();
                    frm.txtSession.Text = dr.Cells[4].Value.ToString();
                    frm.sessions.Text = dr.Cells[4].Value.ToString();
                    frm.txtSchoolID.Text = dr.Cells[5].Value.ToString();
                    frm.txtSchool.Text = dr.Cells[6].Value.ToString();
                    frm.schools.Text = dr.Cells[6].Value.ToString();
                    frm.txtClassID.Text = dr.Cells[7].Value.ToString();
                    frm.txtClass.Text = dr.Cells[8].Value.ToString();
                    frm.txtSubjectType.DropDownStyle = ComboBoxStyle.DropDown;
                    frm.txtSubjectType.Text = dr.Cells[9].Value.ToString();
                    frm.txtWeekly.Text = dr.Cells[10].Value.ToString();
                    frm.txtTimeFrom.Text = dr.Cells[11].Value.ToString();
                    frm.txtTo.Text = dr.Cells[12].Value.ToString();
                    frm.btnSave.Enabled = false;
                    frm.btnUpdate_record.Enabled = true;
                    frm.btnDelete.Enabled = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtsubjectName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Subject.SessionID),Rtrim(Sessions.Session),Rtrim(Subject.SchoolID),Rtrim(School.SchoolName),Rtrim(Subject.ClassID),Rtrim(Class.ClassName),Rtrim(Subject.SubjectType),Rtrim(Subject.MaxClasses),Rtrim(Subject.TimeFrom),Rtrim(Subject.TimeTo) FROM Subject INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  Where SubjectName like '%" + txtsubjectName.Text + "%'order By  Subjectcode,Session,SchoolName,ClassName,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSchool_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID), Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Subject.SessionID),Rtrim(Sessions.Session),Rtrim(Subject.SchoolID),Rtrim(School.SchoolName),Rtrim(Subject.ClassID),Rtrim(Class.ClassName),Rtrim(Subject.SubjectType),Rtrim(Subject.MaxClasses),Rtrim(Subject.TimeFrom),Rtrim(Subject.TimeTo) FROM Subject INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  Where School.SchoolName like '%" + txtSchool.Text + "%'order By  Subjectcode,Session,SchoolName,ClassName,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
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
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID), Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Subject.SessionID),Rtrim(Sessions.Session),Rtrim(Subject.SchoolID),Rtrim(School.SchoolName),Rtrim(Subject.ClassID),Rtrim(Class.ClassName),Rtrim(Subject.SubjectType),Rtrim(Subject.MaxClasses),Rtrim(Subject.TimeFrom),Rtrim(Subject.TimeTo) FROM Subject INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  Where Class.ClassName like '%" + txtClass.Text + "%'order By Subjectcode,Session,SchoolName,ClassName,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        public void Reset()
        {
            txtsubjectName.Text = "";
            txtSession.Text = "";
            txtSchool.Text = "";
            txtClass.Text = "";
            Auto();
        }
        private void txtSession_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID), Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Subject.SessionID),Rtrim(Sessions.Session),Rtrim(Subject.SchoolID),Rtrim(School.SchoolName),Rtrim(Subject.ClassID),Rtrim(Class.ClassName),Rtrim(Subject.SubjectType),Rtrim(Subject.MaxClasses),Rtrim(Subject.TimeFrom),Rtrim(Subject.TimeTo) FROM Subject INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  Where Sessions.Session like '%" + txtSession.Text + "%'order By Subjectcode,Session,SchoolName,ClassName,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBatch.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBatch.Focus();
                    return;
                }
                if (txtSubjectCode.Text == "")
                {
                    MessageBox.Show("Please Enter SubjectCode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSubjectCode.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Subject.SubjectID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Subject.SessionID),Rtrim(Sessions.Session),Rtrim(Subject.SchoolID),Rtrim(School.SchoolName),Rtrim(Subject.ClassID),Rtrim(Class.ClassName),Rtrim(Subject.SubjectType),Rtrim(Subject.MaxClasses),Rtrim(Subject.TimeFrom),Rtrim(Subject.TimeTo) FROM Subject INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  Where Session='" + txtBatch.Text + "' and SubjectCode='" + txtSubjectCode.Text + "' order By  Subjectcode,Session,SchoolName,ClassName,SubjectName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void reset()
        {
             txtClass.Text = "";
            txtSchool.Text = "";
            txtSession.Text = "";
            txtsubjectName.Text = "";
            txtBatch2.Text = "";
            txtSubjectName2.Text = "";
            txtBatch.Text = "";
            txtSubjectCode.Text = "";
            DataGridView1.Rows.Clear();
            Auto();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
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
