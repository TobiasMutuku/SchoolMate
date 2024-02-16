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
    public partial class frmSubjectsEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmSubjectsEntry()
        {
            InitializeComponent();
        }
        public frmSubjectsEntry(frmMainmenu par)
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
                string ct = "SELECT distinct RTRIM(SchoolName) FROM School";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSchool.Items.Clear();
                while (rdr.Read())
                {
                    txtSchool.Items.Add(rdr[0]);
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
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSubjectType.SelectedIndex = -1;
            txtSubjectType.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Text = "";
            txtClass.Text = "";
            txtTo.Text = "";
            txtTimeFrom.Text = "";
            txtWeekly.Text = "";
            txtSubjectName.Text = "";
            txtSchoolID.Text = "";
            txtClassID.Text = "";
            txtSchoolType.Text = "";
            txtSubjectCode.Text = "";
            FillClass();
            FillSchool();
            FillSession();
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
      }
        private void frmSubjectsEntry_Load(object sender, EventArgs e)
        {
            Reset();
        }
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(ClassName),Classid FROM class order by 2";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtClass.Items.Clear();
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
        public void FillSession()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM Sessions";
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
        private void txtSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(School.SchoolID),Rtrim(SchoolTypes.SchoolType) FROM School INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID WHERE SchoolName = '" + txtSchool.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSchoolID.Text = rdr.GetValue(0).ToString().Trim();
                    txtSchoolType.Text = rdr.GetValue(1).ToString().Trim();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please select School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchool.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   txtSession.Focus();
                    return;
                }
                if (txtSubjectCode.Text == "")
                {
                    MessageBox.Show("Please Enter SubjectCode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectCode.Focus();
                    return;
                }
                if (txtSubjectName.Text == "")
                {
                    MessageBox.Show("Please Enter Subject Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectName.Focus();
                    return;
                }
                if (txtSubjectType.Text == "")
                {
                    MessageBox.Show("Please Select Subject Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectType.Focus();
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT Rtrim(Subject.SubjectCode),Rtrim(School.SchoolName),Rtrim(Sessions.Session) FROM School INNER JOIN Subject ON School.SchoolID = Subject.SchoolID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID where Subjectcode=@d1 and Session=@d2 and Schoolname=@d3";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubjectCode.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchool.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Subject Code Already Exist For This Batch/Session and School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   txtSubjectCode.Text = "";
                  txtSubjectCode.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into Subject(SchoolID,ClassID,SessionID,SubjectCode,SubjectName,SubjectType,MaxClasses,TimeFrom,TimeTo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d2", txtClassID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSubjectCode.Text);
                cmd.Parameters.AddWithValue("@d5", txtSubjectName.Text);
                cmd.Parameters.AddWithValue("@d6", txtSubjectType.Text);
                cmd.Parameters.AddWithValue("@d7", txtWeekly.Text);
                cmd.Parameters.AddWithValue("@d8", txtTimeFrom.Text);
                cmd.Parameters.AddWithValue("@d9", txtTo.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Added New Subject'" + txtSubjectName.Text + "' having School'" + txtSchool.Text + "' and Class'" + txtClass.Text + "' and Session'" + txtSession.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassID FROM Class WHERE ClassName = '" + txtClass.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SessionID FROM Sessions WHERE Session = '" + txtSession.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSessionID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmSubjectList frm = new frmSubjectList(this);
            frm.lblSET.Text = "R3";
            frm.ShowDialog();
        }
        private void d2()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm1 = "select SubjectID from AttendanceMaster where SubjectID='" +textBox1.Text + "'";
                cmd = new SqlCommand(ctm1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Subject using on Attendance List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSchool.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ctm2 = "select Subject_ID from MarksEntry_Join where Subject_ID='" + textBox1.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Subject using on Final Marks List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtSchool.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq = "delete from Subject where SubjectID=" + textBox1.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Reset();
                    st1 = lblUser.Text;
                    st2 = "Deleted Subject'" + txtSubjectName.Text + "' having School'" + txtSchool.Text + "' and Class'" + txtClass.Text + "' and Session'" + txtSession.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please select School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchool.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSession.Focus();
                    return;
                }
                if (txtSubjectCode.Text == "")
                {
                    MessageBox.Show("Please Enter SubjectCode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectCode.Focus();
                    return;
                }
                if (txtSubjectName.Text == "")
                {
                    MessageBox.Show("Please Enter Subject Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectName.Focus();
                    return;
                }
                if (txtSubjectType.Text == "")
                {
                    MessageBox.Show("Please Select Subject Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectType.Focus();
                    return;
                }
                if ((txtSubjectCode.Text) != (subjectcodesss.Text) || (txtSession.Text) != (sessions.Text) || (txtSchool.Text) != (schools.Text))
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string ct = "SELECT Rtrim(Subject.SubjectCode),Rtrim(School.SchoolName),Rtrim(Sessions.Session) FROM School INNER JOIN Subject ON School.SchoolID = Subject.SchoolID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID where Subjectcode=@d1 and Session=@d2 and Schoolname=@d3";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtSubjectCode.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtSchool.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Subject Code Already Exist For This Batch/Session and School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSubjectCode.Text = "";
                        txtSubjectCode.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update Subject Set SchoolID=@d1,ClassID=@d2,SessionID=@d3,SubjectCode=@d4,SubjectName=@d5,SubjectType=@d6,MaxClasses=@d7,TimeFrom=@d8,TimeTo=@d9 Where SubjectID=@d10";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d2", txtClassID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSubjectCode.Text);
                cmd.Parameters.AddWithValue("@d5", txtSubjectName.Text);
                cmd.Parameters.AddWithValue("@d6", txtSubjectType.Text);
                cmd.Parameters.AddWithValue("@d7", txtWeekly.Text);
                cmd.Parameters.AddWithValue("@d8", txtTimeFrom.Text);
                cmd.Parameters.AddWithValue("@d9", txtTo.Text);
                cmd.Parameters.AddWithValue("@d10", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Updated Subject'" + txtSubjectName.Text + "' having School'" + txtSchool.Text + "' and Class'" + txtClass.Text + "' and Session'" + txtSession.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
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
                d2();
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
