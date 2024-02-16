using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
namespace School_Software
{
    public partial class frmMainmenu : Form
    {
        string Filename;
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        clsTrial trial = new clsTrial();
        string st1;
        string st2;
      //  Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Shivam");
        public frmMainmenu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           TIME.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       private void schoolEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           frmSchoolEntry frm = new frmSchoolEntry(this);
            frm.ShowDialog();
        }

        private void subjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectsEntry frm = new frmSubjectsEntry(this);
            frm.ShowDialog();
        }

        private void frmMainmenu_Load(object sender, EventArgs e)
        {

            //if (key == null)
            //{
            //    trial.SetNewDate();
            //}
                  
            //trial.Expired();
            frmLogin frm = new frmLogin();
            //Master Entry
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Master Entry View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblMasterentry.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblMasterentry.Text == "True")
            {
                masterEntryToolStripMenuItem.Enabled = true;
            }
            else
            {
                masterEntryToolStripMenuItem.Enabled = false;
            }

            if (UserType.Text == "Super Admin")
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Users View' and Users.UserID='" + User.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    frm.lblusers.Text = rdr[0].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (frm.lblusers.Text == "True")
                {
                    usersSettingToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    usersSettingToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Users View' and Users.UserID='" + User.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    frm.lblusers.Text = rdr[0].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (frm.lblusers.Text == "True")
                {
                    usersSettingToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    usersSettingToolStripMenuItem.Enabled = false;
                    userRegistrationToolStripMenuItem.Enabled = false;
                }
            }
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStudentAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStudentAll.Text == "True")
            {
                studentToolStripMenuItem.Enabled = true;
                studentToolStripMenuItem1.Enabled = true;
            }
            else
            {
                studentToolStripMenuItem.Enabled = false;
                studentToolStripMenuItem1.Enabled = false;
            }

            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStudentRegistration.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStudentRegistration.Text == "True")
            {
                studentRegistrationToolStripMenuItem.Enabled = true;
                studentToolStripMenuItem1.Enabled = true;
            }
            else
            {
                studentRegistrationToolStripMenuItem.Enabled = false;
                studentToolStripMenuItem1.Enabled = false;
            }

            //discount

            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Discount View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSTdiscount.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSTdiscount.Text == "True")
            {
                studentDiscountsToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentDiscountsToolStripMenuItem.Enabled = false;
            }
            //hosteler
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostelers Entry' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblHostelers.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblHostelers.Text == "True")
            {
                hostelersEntryToolStripMenuItem.Enabled = true;
            }
            else
            {
                hostelersEntryToolStripMenuItem.Enabled = false;
            }
            //Bus Holders

            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student BusHolder Entry' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSTBusHostelers.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSTBusHostelers.Text == "True")
            {
                busHoldersEntryToolStripMenuItem.Enabled = true;
            }
            else
            {
                busHoldersEntryToolStripMenuItem.Enabled = false;
            }

            //Library All

            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Library View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblLibraryAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblLibraryAll.Text == "True")
            {
                Library.Enabled = true;
            }
            else
            {
                Library.Enabled = false;
            }

            //Books Fine

            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Books Fine Setting' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblFine.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblFine.Text == "True")
            {
                booksFineSettingsToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksFineSettingsToolStripMenuItem.Enabled = false;
            }

            //Books Reservation

            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookReservation.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookReservation.Text == "True")
            {
                staffBookReservationToolStripMenuItem.Enabled = true;
            }
            else
            {
                staffBookReservationToolStripMenuItem.Enabled = false;
            }

            //Books Issue
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssue.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssue.Text == "True")
            {
                studentBookIssueToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentBookIssueToolStripMenuItem.Enabled = false;
            }
            //Books Return
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Return' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookReturn.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookReturn.Text == "True")
            {
                studentBookReturnToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentBookReturnToolStripMenuItem.Enabled = false;
            }

            //JM
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblJM.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblJM.Text == "True")
            {
                journalAndMagazinesBillingToolStripMenuItem.Enabled = true;
            }
            else
            {
                journalAndMagazinesBillingToolStripMenuItem.Enabled = false;
            }

            //Examination
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Examination View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblExamAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblExamAll.Text == "True")
            {
                examManagementToolStripMenuItem.Enabled = true;
            }
            else
            {
                examManagementToolStripMenuItem.Enabled = false;
            }
            //Exam Schedule
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Examination Schedule' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblExamScchedule.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblExamScchedule.Text == "True")
            {
                examScheduleToolStripMenuItem.Enabled = true;
            }
            else
            {
                examScheduleToolStripMenuItem.Enabled = false;
            }
            //Employee All
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee All' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmployeeAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmployeeAll.Text == "True")
            {
                employeeToolStripMenuItem.Enabled = true;
                employeeToolStripMenuItem1.Enabled = true;
            }
            else
            {
                employeeToolStripMenuItem.Enabled = false;
                employeeToolStripMenuItem1.Enabled = false;
            }
            //Employee Entry
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmployeeEntry.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmployeeEntry.Text == "True")
            {
                employeeRegistrationToolStripMenuItem.Enabled = true;
                employeeToolStripMenuItem1.Enabled = true;
            }
            else
            {
                employeeRegistrationToolStripMenuItem.Enabled = false;
                employeeToolStripMenuItem1.Enabled = false;
            }
            //Employee discount
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Discount' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmpDiscount.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmpDiscount.Text == "True")
            {
                employeeDiscountsToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeDiscountsToolStripMenuItem.Enabled = false;
            }
            //Payroll All
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Payroll All' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblPayrollAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblPayrollAll.Text == "True")
            {
                PayrollAll.Enabled = true;
            }
            else
            {
                PayrollAll.Enabled = false;
            }

            //Employee Attendance
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Attendance' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAttendence.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAttendence.Text == "True")
            {
                employeeAttendanceToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeAttendanceToolStripMenuItem.Enabled = false;
            }

            //Employee Advance
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Advance Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAdvance.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAdvance.Text == "True")
            {
                employeeAdvancePaymentToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeAdvancePaymentToolStripMenuItem.Enabled = false;
            }

            //salaryPayment
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Salary Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSalaryPayment.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSalaryPayment.Text == "True")
            {
                salaryPaymentToolStripMenuItem.Enabled = true;
                salaryPaymentToolStripMenuItem1.Enabled = true;
            }
            else
            {
                salaryPaymentToolStripMenuItem.Enabled = false;
                salaryPaymentToolStripMenuItem1.Enabled = false;
            }

            //Transaction All
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Transaction All' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblTransactionAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblTransactionAll.Text == "True")
            {
                transactionsToolStripMenuItem.Enabled = true;
                schoolFeePaymentToolStripMenuItem.Enabled = true;
                hostelFeePaymentToolStripMenuItem.Enabled = true;
                busFeePaymentToolStripMenuItem.Enabled = true;
            }
            else
            {
                transactionsToolStripMenuItem.Enabled = false;
                schoolFeePaymentToolStripMenuItem.Enabled = false;
                hostelFeePaymentToolStripMenuItem.Enabled = false;
                busFeePaymentToolStripMenuItem.Enabled = false;
            }
            //SchoolFeesPayment
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='School Fees Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSchoolFeesPayment.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSchoolFeesPayment.Text == "True")
            {
                schoolFeesPaymentToolStripMenuItem.Enabled = true;
                schoolFeePaymentToolStripMenuItem.Enabled = true;
            }
            else
            {
                schoolFeesPaymentToolStripMenuItem.Enabled = false;
                schoolFeePaymentToolStripMenuItem.Enabled = false;
            }

            //hostelFeesPayment
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostel Fees Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblHostelFeesPayment.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblHostelFeesPayment.Text == "True")
            {
                hostelFeesPaymentToolStripMenuItem.Enabled = true;
                hostelFeePaymentToolStripMenuItem.Enabled = true;
            }
            else
            {
                hostelFeesPaymentToolStripMenuItem.Enabled = false;
                hostelFeePaymentToolStripMenuItem.Enabled = false;
            }

            //busFeesPayment
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBusFeesPayment.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBusFeesPayment.Text == "True")
            {
                busFeesPaymentStudentToolStripMenuItem.Enabled = true;
                busFeePaymentToolStripMenuItem.Enabled = true;
            }
            else
            {
                busFeesPaymentStudentToolStripMenuItem.Enabled = false;
                busFeePaymentToolStripMenuItem.Enabled = false;
            }
            //busFeesPayment staff
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Staff' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStaffBusFeePay.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStaffBusFeePay.Text == "True")
            {
                busFeesPaymentStaffToolStripMenuItem.Enabled = true;
            }
            else
            {
                busFeesPaymentStaffToolStripMenuItem.Enabled = false;
            }
            //Barcode
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Barcode Genrator All' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBarcode.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBarcode.Text == "True")
            {
                barcodeGenratorToolStripMenuItem.Enabled = true;
                barcodeGeneratorsToolStripMenuItem.Enabled = true;
            }
            else
            {
                barcodeGenratorToolStripMenuItem.Enabled = false;
                barcodeGeneratorsToolStripMenuItem.Enabled = false;
            }
            //RecordsAll
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='All Records' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAllRecords.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAllRecords.Text == "True")
            {
                recordsToolStripMenuItem.Enabled = true;
            }
            else
            {
                recordsToolStripMenuItem.Enabled = false;
            }
            //RecordsAll
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='All Records' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAllRecords.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAllRecords.Text == "True")
            {
                recordsToolStripMenuItem.Enabled = true;
            }
            else
            {
                recordsToolStripMenuItem.Enabled = false;
            }
            //Student list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Student List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStudentRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStudentRecord.Text == "True")
            {
                studentListToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentListToolStripMenuItem.Enabled = false;
            }
            //Employee
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Employee List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmployeeRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmployeeRecord.Text == "True")
            {
                employeeListToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeListToolStripMenuItem.Enabled = false;
            }
            //School Fees
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View School Fees List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSchoolFeeRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSchoolFeeRecord.Text == "True")
            {
                schoolFeesListToolStripMenuItem1.Enabled = true;
            }
            else
            {
                schoolFeesListToolStripMenuItem1.Enabled = false;
            }
            //School Fees Payment
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View School Fees Payment List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSchoolFeePayrecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSchoolFeePayrecord.Text == "True")
            {
                schoolFeesListToolStripMenuItem.Enabled = true;
            }
            else
            {
                schoolFeesListToolStripMenuItem.Enabled = false;
            }
            //Hostelers
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Hosteler List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblHostelerrecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblHostelerrecord.Text == "True")
            {
                hostelersListToolStripMenuItem.Enabled = true;
            }
            else
            {
                hostelersListToolStripMenuItem.Enabled = false;
            }
            //Hostel Fee Pay list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Hostel Fees Payment List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblHostelFeesPayRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblHostelFeesPayRecord.Text == "True")
            {
                hostelFeesListToolStripMenuItem.Enabled = true;
            }
            else
            {
                hostelFeesListToolStripMenuItem.Enabled = false;
            }

            //Bus Holder
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Bus Holder Student List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBusHoldersRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBusHoldersRecord.Text == "True")
            {
                busHolderStudentListToolStripMenuItem.Enabled = true;
            }
            else
            {
                busHolderStudentListToolStripMenuItem.Enabled = false;
            }

            //Bus Fee Pay list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Bus Fees Payment List Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBusFeePayRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBusFeePayRecord.Text == "True")
            {
                busFeesListToolStripMenuItem.Enabled = true;
            }
            else
            {
                busFeesListToolStripMenuItem.Enabled = false;
            }

            //Bus Holder Staff
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Bus Holder Staff List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBusholderStafflist.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBusholderStafflist.Text == "True")
            {
                busHolderStaffListToolStripMenuItem.Enabled = true;
            }
            else
            {
                busHolderStaffListToolStripMenuItem.Enabled = false;
            }

            //Due List
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Due List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblDuelist.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblDuelist.Text == "True")
            {
                dueListToolStripMenuItem.Enabled = true;
                feesDueListToolStripMenuItem1.Enabled = true;
            }
            else
            {
                dueListToolStripMenuItem.Enabled = false;
                feesDueListToolStripMenuItem1.Enabled = false;
            }
            //Staff Attendance List
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Employee Attendance List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStaffAttendancelist.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStaffAttendancelist.Text == "True")
            {
                employeeAttendanceListToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeAttendanceListToolStripMenuItem.Enabled = false;
            }

            //Advance Pay List
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Employee Advance Payment List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAdvanceList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAdvanceList.Text == "True")
            {
                employeeAdvancePaymentListToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeAdvancePaymentListToolStripMenuItem.Enabled = false;
            }
            //Salary Pay List
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Salary Payment List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSalaryList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSalaryList.Text == "True")
            {
                salaryPaymentListToolStripMenuItem.Enabled = true;
            }
            else
            {
                salaryPaymentListToolStripMenuItem.Enabled = false;
            }

            //Book Spplier List
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Book Supplier List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSupplierList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSalaryList.Text == "True")
            {
                bookSupplierListToolStripMenuItem.Enabled = true;
            }
            else
            {
                bookSupplierListToolStripMenuItem.Enabled = false;
            }

            //Book list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSalaryList.Text == "True")
            {
                booksList.Enabled = true;
            }
            else
            {
                booksList.Enabled = false;
            }
            //Book Reservation list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Reservation List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookReservation.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookReservation.Text == "True")
            {
                booksReservationListToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksReservationListToolStripMenuItem.Enabled = false;
            }
            //Book Issue list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Issue List Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksIssueListStudentToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksIssueListStudentToolStripMenuItem.Enabled = false;
            }

            //Book Issue list Staff
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Issue List Staff' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksIssueListStaffToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksIssueListStaffToolStripMenuItem.Enabled = false;
            }

            //Book Return list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Return List Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksReturnListStudentToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksReturnListStudentToolStripMenuItem.Enabled = false;
            }
            //Book Return list Staff
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Return List Staff' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksReturnListStaffToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksReturnListStaffToolStripMenuItem.Enabled = false;
            }

            //Subject list
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Subject List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSubjectList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSubjectList.Text == "True")
            {
                subjectListToolStripMenuItem.Enabled = true;
            }
            else
            {
                subjectListToolStripMenuItem.Enabled = false;
            }

            //ExamSchedulelist
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Exam Schedule List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblExamScheduleList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblExamScheduleList.Text == "True")
            {
                examScheduleListToolStripMenuItem.Enabled = true;
            }
            else
            {
                examScheduleListToolStripMenuItem.Enabled = false;
            }

            //All Reports
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View All Reports' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAllReports.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAllReports.Text == "True")
            {
                reportsToolStripMenuItem.Enabled = true;
            }
            else
            {
                reportsToolStripMenuItem.Enabled = false;
            }
            //Logs
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Logs' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblLogs.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblLogs.Text == "True")
            {
                logsToolStripMenuItem.Enabled = true;
            }
            else
            {
                logsToolStripMenuItem.Enabled = false;
            }
            //SMS
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View SMS Setting' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSMs.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSMs.Text == "True")
            {
                sMSSettingToolStripMenuItem.Enabled = true;
                sMSToolStripMenuItem.Enabled = true;
              
            }
            else
            {
                sMSSettingToolStripMenuItem.Enabled = false;
                sMSToolStripMenuItem.Enabled = false;
            }

            //Database Backup
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Backup & Recovery' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBackup.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBackup.Text == "True")
            {
                dataBaseBackupToolStripMenuItem.Enabled = true;
                Recovery.Enabled = true;
                recoveryToolStripMenuItem.Enabled = true;
                backupToolStripMenuItem.Enabled = true;
            }
            else
            {
                dataBaseBackupToolStripMenuItem.Enabled = false;
                backupToolStripMenuItem.Enabled = false;
                recoveryToolStripMenuItem.Enabled = false;
                Recovery.Enabled = false;
            }
         
        }
    
        private void schoolTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchoolType frm = new frmSchoolType(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassTypes frm = new frmClassTypes();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassEntry frm = new frmClassEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void sectionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSectionEntry frm = new frmSectionEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmClassSection frm = new frmClassSection();
            frm.ShowDialog();
        }

        private void sessionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSessionEntry frm = new frmSessionEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeDepartment frm = new frmEmployeeDepartment();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeDesignationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmEmployeeDesignations frm = new frmEmployeeDesignations();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void feeTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeeTypes frm = new frmFeeTypes();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void schoolFeesEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmSchoolFeesEntry frm = new frmSchoolFeesEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void busEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBusEntry frm = new frmBusEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void locationEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocationEntry frm = new frmLocationEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void busInstallmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBusInstallments frm = new frmBusInstallments();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void hostelEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmHostelEntry frm = new frmHostelEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void hostelInstallmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelInstallment frm = new frmHostelInstallment();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void gradingLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradingLevels frm = new frmGradingLevels();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void examGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExamEntry frm = new frmExamEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksEntry frm = new frmBooksEntry(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void bookSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBookSuppliersEntry frm = new frmBookSuppliersEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void journalAndMagazinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazines frm = new frmJournalAndMagazines(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void studentDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentDocuments frm = new frmStudentDocuments();
            frm.lblUser.Text = User.Text;
          frm.ShowDialog();
        }

        private void userRegistrationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void userGrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserGrants frm = new frmUserGrants();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void studentRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmStudentRegistration frm = new frmStudentRegistration();
           frm.lblUser.Text = User.Text;
           con = new SqlConnection(cs.ReadfromXML());
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
           rdr = cmd.ExecuteReader();
           if (rdr.Read())
           {
               frm.lblsave.Text = rdr[0].ToString().Trim();
               frm.lblview.Text = rdr[1].ToString().Trim();
           }
           if ((rdr != null))
           {
               rdr.Close();
           }
           if (con.State == ConnectionState.Open)
           {
               con.Close();
           }

           if (frm.lblsave.Text == "True")
               frm.btnSave.Enabled = true;
           else
               frm.btnSave.Enabled = false;

           if (frm.lblview.Text == "True")
               frm.btnGetData.Enabled = true;
           else
               frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void studentDiscountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentDiscount frm = new frmStudentDiscount();
            frm.ShowDialog();
        }

        private void hostelersEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelersStudent frm = new frmHostelersStudent();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostelers Entry' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSave.Text = rdr[0].ToString().Trim();
                frm.lblGetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblSave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblGetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void busHoldersEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolderStudents frm = new frmBusHolderStudents();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student BusHolder Entry' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSave.Text = rdr[0].ToString().Trim();
                frm.lblGetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblSave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblGetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void examScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExamSchedule frm = new frmExamSchedule();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Examination Schedule' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeEntry frm = new frmEmployeeEntry();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void employeeDiscountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaffDiscount frm = new frmStaffDiscount();
            frm.ShowDialog();
        }

        private void booksClassificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBooksClassifications frm = new frmBooksClassifications();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();

           
        }

        private void booksSubcategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksSubCategory frm = new frmBooksSubCategory();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksCategory frm = new frmBooksCategory();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAttendanceEntry frm = new frmEmployeeAttendanceEntry();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Attendance' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void employeeAdvancePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAdvancePayment frm = new frmEmployeeAdvancePayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Advance Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void salaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeSalaryPayment frm = new frmEmployeeSalaryPayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Salary Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void schoolFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchoolFeesPayment frm = new frmSchoolFeesPayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='School Fees Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void hostelFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelFeesPayment frm = new frmHostelFeesPayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostel Fees Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void busFeesPaymentStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeesPaymentStudent frm = new frmBusFeesPaymentStudent();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void busFeesPaymentStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeePaymentStaff frm = new frmBusFeePaymentStaff();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Staff' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void booksRandomBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRandomBarcodeGenerator frm = new frmRandomBarcodeGenerator();
            frm.ShowDialog();
        }

        private void booksBarcodeGenratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeGeneration frm = new frmBarcodeGeneration();
           frm.ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogs frm = new frmLogs();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void sMSSettingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSms frm = new frmSms();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksFineSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksFineSetting frm = new frmBooksFineSetting();
            frm.ShowDialog();
        }

      

        private void studentBookReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReturn frm = new frmBookReturn();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Return' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
            {
                frm.btnSave.Enabled = true;
                frm.btnSave1.Enabled = true;
            }
            else
            {
                frm.btnSave.Enabled = false;
                frm.btnSave1.Enabled = false;
            }
            if (frm.lblgetdata.Text == "True")
            {
                frm.btnGetdata.Enabled = true;
                frm.btnGetdata1.Enabled = true;
            }
            else
            {
                frm.btnGetdata.Enabled = false;
                frm.btnGetdata1.Enabled = false;
            }
            frm.ShowDialog();
        }

        private void staffBookReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReservations frm = new frmBookReservations();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btngetdata.Enabled = true;
            else
                frm.btngetdata.Enabled = false;
            frm.ShowDialog();
        }

        private void studentBookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssue frm = new frmBookIssue();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
            {
                frm.btnSave.Enabled = true;
                frm.btnSave1.Enabled = true;
            }
            else
            {
                frm.btnSave.Enabled = false;
                frm.btnSave1.Enabled = false;
            }
            if (frm.lblgetdata.Text == "True")
            {
                frm.btnGetdata.Enabled = true;
                frm.btnGetdata1.Enabled = true;
            }
            else
            {
                frm.btnGetdata.Enabled = false;
                frm.btnGetdata1.Enabled = false;
            }
            frm.ShowDialog();
        }

        private void journalAndMagazinesBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazinesBilling frm = new frmJournalAndMagazinesBilling();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList();
            frm.ShowDialog();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmEmployeeList frm = new frmEmployeeList();
            frm.ShowDialog();
        }

        private void schoolFeesListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSchoolFeesList frm = new frmSchoolFeesList();
            frm.ShowDialog();
        }

        private void schoolFeesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchoolFeesPaymentList frm = new frmSchoolFeesPaymentList();
            frm.ShowDialog();
        }

        private void hostelersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelerStudentList frm = new frmHostelerStudentList();
            frm.ShowDialog();
        }

        private void hostelFeesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelFeePaymentList frm = new frmHostelFeePaymentList();
            frm.ShowDialog();
        }

        private void busHolderStudentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolderStudentList frm = new frmBusHolderStudentList();
            frm.ShowDialog();
        }

        private void busFeesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeesPaymentStudent frm = new frmBusFeesPaymentStudent();
            frm.ShowDialog();
        }

        private void busHolderStaffListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolderStaffList frm = new frmBusHolderStaffList();
            frm.ShowDialog();
        }

        private void busFeesPaymentListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeesPaymentListStaff frm = new frmBusFeesPaymentListStaff();
            frm.ShowDialog();
        }

        private void dueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmFeesDueList frm = new frmFeesDueList();
            frm.ShowDialog();
        }

        private void employeeAttendanceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAttendanceRecords frm = new frmEmployeeAttendanceRecords();
            frm.ShowDialog();
        }

        private void employeeAdvancePaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAdvancePaymentList frm = new frmEmployeeAdvancePaymentList();
            frm.ShowDialog();
        }

        private void salaryPaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeSalaryPaymentList frm = new frmEmployeeSalaryPaymentList();
            frm.ShowDialog();
        }

        private void bookSupplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBookSupplierList frm = new frmBookSupplierList();
            frm.ShowDialog();
        }

        private void booksClassifiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksList frm = new frmBooksList();
            frm.ShowDialog();
        }

        private void booksReservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReservationsList frm = new frmBooksReservationsList();
            frm.ShowDialog();
        }

        private void booksIssueListStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueListStudent frm = new frmBookIssueListStudent();
            frm.ShowDialog();
        }

        private void booksIssueListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueListStaff frm = new frmBookIssueListStaff();
            frm.ShowDialog();
        }

        private void booksReturnListStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReturnListStudent frm = new frmBookReturnListStudent();
            frm.ShowDialog();
        }

        private void booksReturnListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReturnListStaff frm = new frmBooksReturnListStaff();
            frm.ShowDialog();
        }

        private void subjectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectList frm = new frmSubjectList();
            frm.ShowDialog();
        }

        private void examScheduleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExamScheduleList frm = new frmExamScheduleList();
            frm.ShowDialog();
        }
        public void Logout()
        {
            st1 = User.Text;
            st2 = "Successfully logged out";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.UserID.Text = "";
            frm.Password.Text = "";
            frm.progressBar1.Visible = false;
            frm.UserID.Focus();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           try
            {
                if (MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Backup();
                        Logout();
                    }
                    else
                    {
                        Logout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Backup()
        {

            try
            {
                string destdir = "SERP_DB " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak";
                SaveFileDialog objdlg = new SaveFileDialog();
                objdlg.FileName = destdir;
                objdlg.ShowDialog();
                Filename = objdlg.FileName;
                Cursor = Cursors.WaitCursor;
                timer2.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "backup database SERP to disk='" + Filename + "'with init,stats=10";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataBaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentAttendance frm = new frmStudentAttendance();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentClassPromotion frm = new frmStudentClassPromotion();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

        private void examResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinalMarksEntry frm = new frmFinalMarksEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void marksLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarksLedger frm = new frmMarksLedger();
            frm.ShowDialog();
        }

        private void studentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentReport frm = new frmStudentReport();
            frm.ShowDialog();
        }

        private void identityCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentsIdentityCards frm = new frmStudentsIdentityCards();
            frm.ShowDialog();
        }

        private void feesDueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeesDueList frm = new frmFeesDueList();
            frm.ShowDialog();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeReport frm = new frmEmployeeReport();
            frm.ShowDialog();
        }

        private void bookReservationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReservationReport frm = new frmBooksReservationReport();
            frm.ShowDialog();
        }

        private void bookIssueReportStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueReportStudent frm = new frmBookIssueReportStudent();
            frm.ShowDialog();
        }

        private void bookIssueReportsStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueStaffReport frm = new frmBookIssueStaffReport();
            frm.ShowDialog();
        }

        private void bookReturnReportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void booksFineCollectionReportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksFineStudentReports frm = new frmBooksFineStudentReports();
            frm.ShowDialog();
        }

        private void booksFineCollectionReportStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmStaffBooksFineReport frm = new frmStaffBooksFineReport();
            frm.ShowDialog();
        }

        private void finalMarksLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarksLedger frm = new frmMarksLedger();
            frm.ShowDialog();
        }

        private void employeeBusHoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolderStaff frm = new frmBusHolderStaff();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
           // AboutBox frm = new AboutBox();
            //frm.ShowDialog();
        }
        public void DBrecovery()
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("DB Backup File|*.bak;");
                _with1.FilterIndex = 4;
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    timer2.Enabled = true;
                    SqlConnection.ClearAllPools();
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb = "USE Master ALTER DATABASE ERPS_DB SET Single_User WITH Rollback Immediate Restore database ERPS_DB FROM disk='" + openFileDialog1.FileName + "' WITH REPLACE ALTER DATABASE ERPS_DB SET Multi_User ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    st1 = User.Text;
                    st2 = "Successfully restore the database";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Recovery_Click(object sender, EventArgs e)
        {
            DBrecovery();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void usersSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStudentRegistration frm = new frmStudentRegistration();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblview.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployeeEntry frm = new frmEmployeeEntry();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void schoolFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchoolFeesPayment frm = new frmSchoolFeesPayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='School Fees Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void busFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeesPaymentStudent frm = new frmBusFeesPaymentStudent();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void hostelFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelFeesPayment frm = new frmHostelFeesPayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostel Fees Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void salaryPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployeeSalaryPayment frm = new frmEmployeeSalaryPayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Salary Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void feesDueListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFeesDueList frm = new frmFeesDueList();
            frm.ShowDialog();
        }

        private void randomBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRandomBarcodeGenerator frm = new frmRandomBarcodeGenerator();
            frm.ShowDialog();
        }

        private void booksBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeGeneration frm = new frmBarcodeGeneration();
            frm.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void recoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBrecovery();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactMe frm = new frmContactMe();
            frm.ShowDialog();
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSms frm = new frmSms();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Backup();
                        Logout();
                    }
                    else
                    {
                        Logout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importStududentsFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmImportStudents frm = new frmImportStudents();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void importEmployeesFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportEmployees  frm = new frmImportEmployees();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

       }
}

