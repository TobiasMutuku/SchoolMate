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
    public partial class frmAttendanceList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmStudentAttendance frm = null;
        public frmAttendanceList()
        {
            InitializeComponent();
        }
        public frmAttendanceList(frmStudentAttendance par)
        {
            frm = par;
            InitializeComponent();
        }
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(School.SchoolName) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSchool.Items.Clear();
                cmbSchool.Items.Clear();
                while (rdr.Read())
                {
                   cmbSchool.Items.Add(rdr[0]);
                   txtSchool.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillSubject()
        {
            try
            {
                cmbSubjectName.Items.Clear();
                cmbSubjectName.Text = "";
                cmbSubjectName.Enabled = true;
                cmbSubjectName.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Subject.SubjectName) FROM AttendanceMaster INNER JOIN Attendance ON AttendanceMaster.AttendanceID = Attendance.Attendance_ID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID Where Session=@d1 and classname=@d2 and SchoolName=@d3";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                rdr = cmd.ExecuteReader();
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
        public void Reset()
        {
            dataGridView2.Rows.Clear();
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            FillSchool();
            cmbSchool.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            DataGridView1.Rows.Clear();
            cmbSession.Enabled = false;
            cmbClass.Enabled = false;
            cmbSubjectName.SelectedIndex = -1;
            cmbSubjectName.Enabled = false;
            dtpDateFrom.Text =System.DateTime.Now.ToString() ;
            dtpDateTo.Text = System.DateTime.Now.ToString();
            txtFrom.Text = System.DateTime.Now.ToString();
            txtTo.Text = System.DateTime.Now.ToString();
            txtSubjectCode.Text = "";
            lblTotalClasses.Visible = false;
        }

        private void frmAttendanceList_Load(object sender, EventArgs e)
        {
            Reset();
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSession.Items.Clear();
                cmbSession.Text = "";
                cmbSession.Enabled = true;
                cmbSession.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                 string ct = "SELECT distinct Rtrim(Sessions.Session) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No where schoolname='" + cmbSchool.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbClass.Items.Clear();
                cmbClass.Text = "";
                cmbClass.Enabled = true;
                cmbClass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Class.ClassName) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No where Session=@d1 and SchoolName=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
               cmd.Parameters.AddWithValue("@d2", cmbSchool.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                  cmbClass.Items.Add(rdr[0]);
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
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchool.Focus();
                    return;
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSession.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClass.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(AttendanceMaster.AttendanceID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Attendance.Admission_No),Rtrim(Student.StudentName),AttendanceMaster.AttendanceDate,Rtrim(Attendance.Status) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Employee ON AttendanceMaster.StaffID = Employee.EMPID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No  Where Session=@d1 and classname=@d2 and SchoolName=@d3 ORDER BY AttendanceMaster.AttendanceDate", con);
                cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchool.Text);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSession.Items.Clear();
                txtSession.Text = "";
                txtSession.Enabled = true;
                txtSession.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Sessions.Session) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No where schoolname='" + txtSchool.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtClass.Items.Clear();
                txtClass.Text = "";
                txtClass.Enabled = true;
                txtClass.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Class.ClassName) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No where Session=@d1 and SchoolName=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                cmd.Parameters.AddWithValue("@d2", txtSchool.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ButtonHighlight;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
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

        private void btnSearchList_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchool.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }


                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("Select distinct RTRIM(student.AdmissionNo),RTRIM(Student.StudentName),Count(Attendance.Status),(Count(Attendance.Status) * 100)/(Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and AttendanceDate between @date1 and @date2) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and Attendance.Status='P' and AttendanceDate between @date1 and @date2 group by Student.AdmissionNo,Student.StudentName ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AttendanceDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AttendanceDate").Value = dtpDateTo.Value.Date;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                lblTotalClasses.Visible = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No and Session=@d1 and classname=@d2 and SchoolName=@d3 and AttendanceDate between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AttendanceDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AttendanceDate").Value = dtpDateTo.Value.Date;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblTotalClasses.Text = rdr.GetValue(0).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchool.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSubjectName.Text == "")
                {
                    MessageBox.Show("Please select Subject", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubjectName.Focus();
                    return;
                }


                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("Select distinct RTRIM(student.AdmissionNo),RTRIM(Student.StudentName),Count(Attendance.Status),(Count(Attendance.Status) * 100)/(Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and SubjectName=@d4 and AttendanceDate between @date1 and @date2) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and SubjectName=@d4 and Attendance.Status='P' and AttendanceDate between @date1 and @date2 group by Student.AdmissionNo,Student.StudentName ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtTo.Value.Date;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSubjectName.Text);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                lblTotalClasses.Visible = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No and Session=@d1 and classname=@d2 and SchoolName=@d3 and SubjectName=@d4 and AttendanceDate between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtTo.Value.Date;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSubjectName.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblTotalClasses.Text = rdr.GetValue(0).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct Rtrim(Subject.Subjectcode) FROM Subject INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  where Sessions.Session=@d1 and Class.ClassName=@d2 and School.SchoolName=@d3 and SubjectName=@d4 order by 1";
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSubjectName.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSubjectCode.Text = rdr.GetValue(0).ToString();
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

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSubject();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
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
                rowsTotal = dataGridView2.RowCount;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
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
