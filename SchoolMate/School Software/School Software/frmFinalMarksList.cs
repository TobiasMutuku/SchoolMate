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
    public partial class frmFinalMarksList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmFinalMarksEntry frm = null;
        public frmFinalMarksList()
        {
            InitializeComponent();
        }
         public frmFinalMarksList(frmFinalMarksEntry par)
        {
             frm=par;
            InitializeComponent();
        }
         public void FillSchool()
         {
             try
             {
                 con = new SqlConnection(cs.ReadfromXML());
                 con.Open();
                 string ct = "SELECT distinct Rtrim(MarksEntry.StudentSchool) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID";
                 cmd = new SqlCommand(ct);
                 cmd.Connection = con;
                 rdr = cmd.ExecuteReader();
                 cmbSchoolSearch.Items.Clear();
                 while (rdr.Read())
                 {
                     cmbSchoolSearch.Items.Add(rdr[0]);
                 }
                 con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(MarksEntry.M_ID),Rtrim(MarksEntry.AdmissionNo),Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(MarksEntry.StudentSchool),Rtrim(MarksEntry.Session),Rtrim(MarksEntry.StudentClass),Rtrim(MarksEntry.StudentSection),Rtrim(MarksEntry.Result),MarksEntry.EntryDate FROM MarksEntry INNER JOIN Student ON MarksEntry.AdmissionNo = Student.AdmissionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmFinalMarksList_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R3")
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frm.Activate();
                frm.BringToFront();
                frm.txtMarksID.Text = dr.Cells[0].Value.ToString();
                frm.txtAdmissionNo.Text = dr.Cells[1].Value.ToString();
                frm.txtAdmissionNo1.Text = dr.Cells[1].Value.ToString();
                frm.txtStudentName.Text = dr.Cells[2].Value.ToString();
                frm.txtEnrollmentNo.Text = dr.Cells[3].Value.ToString();
                frm.txtSchoolName.Text = dr.Cells[4].Value.ToString();
                frm.txtSession.Text = dr.Cells[5].Value.ToString();
                frm.txtSession1.Text = dr.Cells[5].Value.ToString();
                frm.txtClass.Text = dr.Cells[6].Value.ToString();
                frm.txtSection.Text = dr.Cells[7].Value.ToString();
                if ((dr.Cells[8].Value.ToString() == "Pass"))
                {
                    frm.rbPass.Checked = true;
                }
                if ((dr.Cells[8].Value.ToString() == "Fail"))
                {
                    frm.rbFail.Checked = true;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(MarksEntry_Join.Subject_ID),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(MarksEntry_Join.Status),Rtrim(MarksEntry_Join.MaxMarks),Rtrim(MarksEntry_Join.MMPractical),Rtrim(MarksEntry_Join.CreditHours),Rtrim(MarksEntry_Join.OMTheory),Rtrim(MarksEntry_Join.OMPractical),Rtrim(MarksEntry_Join.OGTheory),Rtrim(MarksEntry_Join.OGPractical),Rtrim(MarksEntry_Join.FinalGrade),Rtrim(MarksEntry_Join.GradePoint) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID INNER JOIN Subject ON MarksEntry_Join.Subject_ID = Subject.SubjectID and MarksEntry_Join.MarksID=" + dr.Cells[0].Value + " order by Subject.SubjectCode", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                frm.DataGridView1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    frm.DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12]);
                }
                con.Close();
               frm.btnSave.Enabled = false ;
               frm.btnUpdate_record.Enabled =true;
               frm.btnDelete.Enabled = true;
               frm.btnPrint.Enabled = true;
               frm.btnPrint2.Enabled = true;
               frm.FillSub();
            }
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(MarksEntry.M_ID),Rtrim(MarksEntry.AdmissionNo),Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(MarksEntry.StudentSchool),Rtrim(MarksEntry.Session),Rtrim(MarksEntry.StudentClass),Rtrim(MarksEntry.StudentSection),Rtrim(MarksEntry.Result),MarksEntry.EntryDate FROM MarksEntry INNER JOIN Student ON MarksEntry.AdmissionNo = Student.AdmissionNo where MarksEntry.AdmissionNo like '%" + txtAdmissionNo.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
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
            txtAdmissionNo.Text = "";
            CmbClassSearch.SelectedIndex = -1;
            cmbBatchSearch.SelectedIndex = -1;
            cmbSchoolSearch.SelectedIndex = -1;
            CmbClassSearch.Enabled = false;
            cmbBatchSearch.Enabled = false;
            dataGridView1.Rows.Clear();
            FillSchool();
            Auto();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();  
        }

        private void cmbSchoolSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBatchSearch.Items.Clear();
                cmbBatchSearch.Text = "";
                cmbBatchSearch.Enabled = true;
                cmbBatchSearch.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(MarksEntry.Session) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID where MarksEntry.StudentSchool='" + cmbSchoolSearch.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBatchSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBatchSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbClassSearch.Items.Clear();
                CmbClassSearch.Text = "";
                CmbClassSearch.Enabled = true;
                CmbClassSearch.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(MarksEntry.StudentClass) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID where MarksEntry.StudentSchool=@d1 and MarksEntry.Session=@d2";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CmbClassSearch.Items.Add(rdr[0]);
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
                if (cmbSchoolSearch.Text == "")
                {
                    MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolSearch.Focus();
                    return;
                }
                if (cmbBatchSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Batch", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBatchSearch.Focus();
                    return;
                }
                if (CmbClassSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbClassSearch.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(MarksEntry.M_ID),Rtrim(MarksEntry.AdmissionNo),Rtrim(Student.StudentName),Rtrim(Student.EnrollmentNo),Rtrim(MarksEntry.StudentSchool),Rtrim(MarksEntry.Session),Rtrim(MarksEntry.StudentClass),Rtrim(MarksEntry.StudentSection),Rtrim(MarksEntry.Result),MarksEntry.EntryDate FROM MarksEntry INNER JOIN Student ON MarksEntry.AdmissionNo = Student.AdmissionNo Where StudentSchool=@d1 and MarksEntry.Session=@d2 and StudentClass=@d3", con);
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                cmd.Parameters.AddWithValue("@d3", CmbClassSearch.Text);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }
    }
}
