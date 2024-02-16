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
    public partial class frmExamResultsEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string Status;
        Connectionstring cs = new Connectionstring();
        public frmExamResultsEntry()
        {
            InitializeComponent();
        }
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string sql = "SELECT MAX(ResultID+1) FROM Result";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtResultID.Text = Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtResultID.Text = Convert.ToString(Num);
                }
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void D1()
        {
           
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            string cb1 = "insert into Resulting(Result_ID,AdmissionNo,Marks,Absent) VALUES (" + txtResultID.Text + ",@d1,@d2,@d3)";
            cmd = new SqlCommand(cb1);
            cmd.Connection = con;
            cmd.Prepare();
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                 if (Convert.ToBoolean(row.Cells[4].Value) == true)
                    Status = "True";
                else
                    Status = "False";

                if (!row.IsNewRow)
                {
                    cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                    if (Status == "False")
                    {
                        cmd.Parameters.AddWithValue("@d2", Convert.ToDecimal(row.Cells[3].Value));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@d2", 0.00);
                    }
                    cmd.Parameters.AddWithValue("@d3", Status);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }
      
        public void subject()
        {
            try
            {
                cmbSubjectName.Items.Clear();
                cmbSubjectName.Text = "";
                cmbSubjectName.Enabled = true;
                cmbSubjectName.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Subject.SubjectName) FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN Subject ON Subject.SubjectID = Scheduling.Subject_ID where ScheduleID=@d1 ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamScheduleID.Text);
                rdr = cmd.ExecuteReader();
                cmbSubjectName.Items.Clear();
                while (rdr.Read())
                {
                    cmbSubjectName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void frmExamResultsEntry_Load(object sender, EventArgs e)
        {
         
            Crypto();
      
          }

        private void cmbExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void auto1()
        {
            try
            {

              
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please Retrive school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchool.Focus();
                    return;
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please Retrive session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSession.Focus();
                    return;
                }
                if (txtclass.Text == "")
                {
                    MessageBox.Show("Please Retrive class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtclass.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.AdmissionNo),Rtrim(Student.EnrollmentNo),Rtrim(Student.StudentName) FROM  Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID Where Student.Status='Active' and SchoolName=@d1 and Session=@d2 and ClassName=@d3 and SectionName=@d4 order by StudentName", con);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Parameters.AddWithValue("@d3", txtclass.Text);
                cmd.Parameters.AddWithValue("@d4", txtSection.Text);
               rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnGetstudent.Enabled = true;
        }
        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  Scheduling.ExamDate, Scheduling.MaxMarks, Scheduling.MinMarks, Subject.SubjectCode, Scheduling.Subject_ID FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN Subject ON Subject.SubjectID = Scheduling.Subject_ID WHERE SubjectName = '" + cmbSubjectName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtExamDate.Text = rdr.GetValue(0).ToString().Trim();
                    txtMaxMarks.Text = rdr.GetValue(1).ToString().Trim();
                    txtMinMarks.Text = rdr.GetValue(2).ToString().Trim();
                    txtSubjectCode.Text = rdr.GetValue(3).ToString().Trim();
                    txtSubjectID.Text = rdr.GetValue(4).ToString().Trim();
      }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                btnGetstudent.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetstudent_Click(object sender, EventArgs e)
        {
            auto1();
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add Data in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT Rtrim(Result.ScheduleID),Rtrim(Subject.SubjectID) FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID where Result.ScheduleID=@d1 and Subject.SubjectID=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamScheduleID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSubjectID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Result Already Saved For This Subject", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                   con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb = "insert into Result(ResultID,Scheduleid,Subjectid) VALUES (@d1,@d2,@d3)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtResultID.Text);
                    cmd.Parameters.AddWithValue("@d2", txtExamScheduleID.Text);
                    cmd.Parameters.AddWithValue("@d3", txtSubjectID.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    con.Close();
                    D1();
                    MessageBox.Show("Successfully Save", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        private void Reset()
        {
            txtExamScheduleID.Text = "";
       
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtMaxMarks.Text = "";
            txtMinMarks.Text = "";
            txtSubjectID.Text = "";
            cmbSubjectName.SelectedIndex = -1;
            txtSubjectCode.Text = "";
           txtResultID.Text = "";
           DataGridView1.Rows.Clear();
           txtSchool.Text = "";
            txtSession.Text = "";
            txtclass.Text = "";
        
            Crypto();
            btnSave.Enabled = true;
        btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
           btnGetstudent.Enabled = true;
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Result where ResultID='" + txtResultID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                  
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            } 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add Data in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtExamScheduleID.Text) != (txtExamScheduleid1.Text) || (txtSubjectID.Text) != (txtSubjectid1.Text))
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT Rtrim(Result.ScheduleID),Rtrim(Subject.SubjectID) FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN Subject ON Subject.SubjectID = Result.SubjectID where Result.ScheduleID=@d1 and Subject.SubjectID=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamScheduleID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSubjectID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Result Already Saved For This Subject", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update Result Set Scheduleid=@d2,Subjectid=@d3 where ResultID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtResultID.Text);
                cmd.Parameters.AddWithValue("@d2", txtExamScheduleID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSubjectID.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq1 = "delete from Resulting where Result_ID='" + txtResultID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                D1();
                MessageBox.Show("Successfully Updated", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetFeeList_Click(object sender, EventArgs e)
        {
            frmExamScheduleList frm = new frmExamScheduleList(this);
            frm.lblSET.Text = "Result";
            frm.Show();
        }

        private void txtExamScheduleID_TextChanged(object sender, EventArgs e)
        {
            subject();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
           frmExamResultList frm = new frmExamResultList(this);
            frm.lblSET.Text = "R3";
         frm.Show();
        }
    }
}
