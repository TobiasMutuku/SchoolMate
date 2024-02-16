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
    public partial class frmSchoolFeesList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmSchoolFeesEntry frm1 = null;
        public frmSchoolFeesList(frmSchoolFeesEntry par)
        {
             frm1 = par; 
             InitializeComponent();
        }
        public frmSchoolFeesList()
        {
           InitializeComponent();
        }
        public void FillClass1()
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM SchoolFees INNER JOIN Class ON SchoolFees.Class_ID = Class.ClassID order by 1";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClass1.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSchoolFeesList_Load(object sender, EventArgs e)
        {
            Auto();
            FillClass1();
            cmbMonth1.Enabled = false;
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(SchoolFees.SchoolFeeID),Rtrim(SchoolFees.School_ID),Rtrim(School.SchoolName),Rtrim(SchoolFees.Class_ID),Rtrim(Class.ClassName),Rtrim(SchoolFees.FeeID),Rtrim(Fee.Feename),Rtrim(SchoolFees.Fee),Rtrim(SchoolFees.Month) FROM SchoolFees INNER JOIN Fee ON SchoolFees.FeeID = Fee.Id INNER JOIN Class ON SchoolFees.Class_ID = Class.ClassID INNER JOIN School ON SchoolFees.School_ID = School.SchoolID order By Classname,SchoolFeeID", con);
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(SchoolFees.SchoolFeeID),Rtrim(SchoolFees.School_ID),Rtrim(School.SchoolName),Rtrim(SchoolFees.Class_ID),Rtrim(Class.ClassName),Rtrim(SchoolFees.FeeID),Rtrim(Fee.Feename),Rtrim(SchoolFees.Fee),Rtrim(SchoolFees.Month) FROM SchoolFees INNER JOIN Fee ON SchoolFees.FeeID = Fee.Id INNER JOIN Class ON SchoolFees.Class_ID = Class.ClassID INNER JOIN School ON SchoolFees.School_ID = School.SchoolID  and ClassName ='" + cmbClass1.Text + "' and Month='" + cmbMonth1.Text + "' order By Classname,SchoolFeeID", con);
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

        private void txtclass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(SchoolFees.SchoolFeeID),Rtrim(SchoolFees.School_ID),Rtrim(School.SchoolName),Rtrim(SchoolFees.Class_ID),Rtrim(Class.ClassName),Rtrim(SchoolFees.FeeID),Rtrim(Fee.Feename),Rtrim(SchoolFees.Fee),Rtrim(SchoolFees.Month) FROM SchoolFees INNER JOIN Fee ON SchoolFees.FeeID = Fee.Id INNER JOIN Class ON SchoolFees.Class_ID = Class.ClassID INNER JOIN School ON SchoolFees.School_ID = School.SchoolID where ClassName like '%" + txtclass.Text + "%' order By Classname", con);
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

        private void button4_Click(object sender, EventArgs e)
        {
            cmbMonth1.Enabled = false;
            cmbClass1.SelectedIndex = -1;
            cmbMonth1.SelectedIndex = -1;
            txtclass.Text = "";
            DataGridView1.Rows.Clear();
            Auto();
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
             if(lblSET.Text == "R1") 
            {

                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm1.Activate();
                frm1.BringToFront();
                frm1.txtSchooFeesID.Text = dr.Cells[0].Value.ToString();
                frm1.txtSchoolID.Text = dr.Cells[1].Value.ToString();
                frm1.txtSchoolQ.Text = dr.Cells[1].Value.ToString();
                frm1.txtSchoolName.Text = dr.Cells[2].Value.ToString();
                frm1.txtClassID.Text = dr.Cells[3].Value.ToString();
                frm1.txtClassQ.Text = dr.Cells[3].Value.ToString();
               frm1.cmbClass.Text = dr.Cells[4].Value.ToString();
               frm1.txtFeeID.Text = dr.Cells[5].Value.ToString();
               frm1.txtFeeIDQ.Text = dr.Cells[5].Value.ToString();
                frm1.cmbFeeName .Text = dr.Cells[6].Value.ToString();
                frm1.txtFee.Text = dr.Cells[7].Value.ToString();
                frm1.cmbMonth.Text = dr.Cells[8].Value.ToString();
                frm1.txtMonthQ.Text = dr.Cells[8].Value.ToString();
                 frm1.btnSave.Enabled = false;
                frm1.btnUpdate.Enabled = true;
                frm1.btnDelete.Enabled = true;
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

        private void cmbClass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             cmbMonth1.Items.Clear();
            cmbMonth1.Text = "";
             cmbMonth1.Enabled = true;
              cmbMonth1.Focus();
             con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct2 = "SELECT distinct Rtrim(SchoolFees.Month) ,Class.ClassID FROM SchoolFees INNER JOIN Class ON SchoolFees.Class_ID = Class.ClassID where class.classname='"+cmbClass1.Text+"' order by 2";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbMonth1.Items.Clear();
                while (rdr.Read())
                {
                    cmbMonth1.Items.Add(rdr[0]);
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
