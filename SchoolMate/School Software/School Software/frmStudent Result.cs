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
    public partial class frmStudent_Result : Form
    {
       
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        public frmStudent_Result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Resulting.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Subject.SubjectCode, Subject.SubjectName, Resulting.Marks, Scheduling.ExamDate, Scheduling.MaxMarks, Scheduling.MinMarks,ExamMaster.ExamName, School.SchoolName, Sessions.Session, Class.ClassName, Section.SectionName FROM Result INNER JOIN Resulting ON Result.ResultID = Resulting.Result_ID INNER JOIN Student ON Resulting.AdmissionNo = Student.AdmissionNo INNER JOIN Subject ON Result.SubjectID = Subject.SubjectID INNER JOIN ExamSchedule ON Result.ScheduleID = ExamSchedule.ScheduleID INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID INNER JOIN ExamMaster ON ExamSchedule.ExamID = ExamMaster.ExamID INNER JOIN School ON Student.School_ID = School.SchoolID AND Subject.SchoolID = School.SchoolID AND ExamSchedule.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID AND ExamSchedule.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON Subject.ClassID = Class.ClassID AND ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID AND Subject.SessionID = Sessions.SessionID AND ExamSchedule.Session_ID = Sessions.SessionID", con);
                adp = new SqlDataAdapter(cmd);
                dtable = new DataTable();
                adp.Fill(dtable);
                con.Close();
               // DataGridView1.DataSource = dtable;
                ds = new DataSet();
                ds.Tables.Add(dtable);
                ds.WriteXmlSchema("Marksheet.xml");
                RptMarksheet rpt = new RptMarksheet();
               rpt.SetDataSource(ds);
               
              crystalReportViewer1.ReportSource = rpt;
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void frmStudent_Result_Load(object sender, EventArgs e)
        {

        }
    }
}
