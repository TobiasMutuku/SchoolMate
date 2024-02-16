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
    public partial class frmHostelerStudentList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmHostelersStudent frm1 = null;
        frmHostelFeesPayment frmfeepayment = null;
        Connectionstring cs = new Connectionstring();

        public frmHostelerStudentList()
        {
            InitializeComponent();
        }
        public frmHostelerStudentList(frmHostelFeesPayment par)
        {
            frmfeepayment = par;
            InitializeComponent();
        }
        public frmHostelerStudentList(frmHostelersStudent par1)
        {
            frm1 = par1;
            InitializeComponent();
        }
        public void Sessions()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Sessions.Session) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSession.Items.Clear();
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
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Auto1()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and Hosteler.Status='Active'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmHostelerStudentList_Load(object sender, EventArgs e)
        {
            Reset();
           
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "R")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and Hosteler.Status='Active' and Hosteler.admission_no like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID ", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and Hosteler.admission_no like '%" + txtAdmissionNo.Text + "%' order by Student.ClassSection_ID", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {

            if (lblSET.Text == "R")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and Student.Studentname like '%" + txtStudentName.Text + "%' order by Student.ClassSection_ID ", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and Hosteler.Status='Active' and Student.studentname like '%" + txtStudentName.Text + "%' order by Student.ClassSection_ID ", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN  Class ON ClassSection.Class_ID = Class.ClassID Inner join Sessions on Sessions.Sessionid=Student.Session_ID where Sessions.session='" + txtSession.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
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

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSection.Items.Clear();
            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSection.Items.Add(rdr[0]);
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
            if (lblSET.Text == "R")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and Hosteler.Status='Active' and SectionName=@d1 and ClassName=@d2 and Session=@d3", con);
                    cmd.Parameters.AddWithValue("@d1", txtSection.Text);
                    cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d3", txtSession.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(Hosteler.HostelerID),Rtrim(Hosteler.Admission_No),Rtrim(Student.StudentName),Rtrim(Sessions.Session),Rtrim(School.SchoolName),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(Hosteler.Hostel_ID),Rtrim(Hostel.Hostelname),Hosteler.JoiningDate,Rtrim(Hosteler.Status) FROM Hosteler INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Hostel ON Hosteler.Hostel_ID = Hostel.HostelID INNER JOIN Hostel AS Hostel_1 ON Hosteler.Hostel_ID = Hostel_1.HostelID and SectionName=@d1 and ClassName=@d2 and Session=@d3", con);
                    cmd.Parameters.AddWithValue("@d1", txtSection.Text);
                    cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d3", txtSession.Text);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmfeepayment.Activate();
                frmfeepayment.BringToFront();
                frmfeepayment.txtHostelerID.Text = dr.Cells[0].Value.ToString();
                frmfeepayment.txtAdmissionNo.Text = dr.Cells[1].Value.ToString();
                frmfeepayment.txtStudentName.Text = dr.Cells[2].Value.ToString();
                frmfeepayment.txtSession.Text = dr.Cells[3].Value.ToString();
                frmfeepayment.txtSchoolname.Text = dr.Cells[4].Value.ToString();
                frmfeepayment.txtClass.Text = dr.Cells[5].Value.ToString();
                frmfeepayment.txtSection.Text = dr.Cells[6].Value.ToString();
                frmfeepayment.txtHostelName.Text = dr.Cells[8].Value.ToString();
                frmfeepayment.Fillinstallment();
            }
            else if(lblSET.Text == "R1") 
            {

                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm1.Activate();
                this.BringToFront();
                frm1.txtHostelerID.Text = dr.Cells[0].Value.ToString();
                frm1.txtAdmissionNo.Text = dr.Cells[1].Value.ToString();
                frm1.txtStudentName.Text = dr.Cells[2].Value.ToString();
                frm1.txtSession.Text = dr.Cells[3].Value.ToString();
               frm1.txtSchoolName.Text = dr.Cells[4].Value.ToString();
               frm1.txtClass.Text = dr.Cells[5].Value.ToString();
                frm1.txtSection.Text = dr.Cells[6].Value.ToString();
                frm1.txtHostelID.Text = dr.Cells[7].Value.ToString();
                frm1.txtHostelName.DropDownStyle = ComboBoxStyle.DropDown;
                frm1.txtHostelName.Text = dr.Cells[8].Value.ToString();
                frm1.txtJoiningDate.Text = dr.Cells[9].Value.ToString();
                frm1.txtStatus.DropDownStyle = ComboBoxStyle.DropDown;
                frm1.txtStatus.Text = dr.Cells[10].Value.ToString();
                frm1.btnSave.Enabled = false;
                frm1.btnUpdate_record.Enabled = true;
                frm1.btnDelete.Enabled = true;
            }
        }
        public void Reset()
        {
            txtStudentName.Text = "";
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            txtAdmissionNo.Text = "";
            DataGridView1.Rows.Clear();
            if (lblSET.Text == "R")
            {
                Auto1();
            }
            else
            {
                Auto();
            }
            Sessions();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
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
    }
}
