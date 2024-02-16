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
    public partial class frmStudentClassPromotion : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmStudentClassPromotion()
        {
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
                while (rdr.Read())
                {
                    cmbSchool.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStudentClassPromotion_Load(object sender, EventArgs e)
        {
            FillSchool();
         }
        public void Fillsession()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM Sessions ";
                cmd = new SqlCommand(ct1);
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
        public void Fillclasses()
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
                string ct1 = "SELECT distinct Rtrim(Sessions.Session) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where School.SchoolName=@d1";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                rdr = cmd.ExecuteReader();
                cmbSession.Items.Clear();
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
                string ct = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID where SchoolName=@d1 and Session=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSession.Text);
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

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSection.Items.Clear();
                cmbSection.Text = "";
                cmbSection.Enabled = true;
                cmbSection.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "SELECT distinct Section.SectionName FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where SchoolName=@d1 and Session=@d2 and ClassName=@d3";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSection.Items.Add(rdr[0]);
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
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please Select School of Student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSchool .Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please Select  current session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please Select current class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSection.Text == "")
                {
                    MessageBox.Show("Please Select current section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSection.Focus();
                    return;
                }
                btnUpdate.Enabled = true;

                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.AdmissionNo),Rtrim(Student.StudentName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Schoolname=@d1 and Session=@d2 and Classname=@d3 and SectionName=@d4  order by StudentName", con);
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSection.Text);
                rdr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (rdr.Read())
                {
                    dynamic item = new ListViewItem();
                    item.Text = rdr[0].ToString().Trim();
                    item.SubItems.Add(rdr[1].ToString().Trim());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnUpdate.Enabled = true;
            txtSession.Items.Clear();
            txtSession.Text = "";
            txtSession.Enabled = true;
            txtSession.Focus();
            Fillsession();
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
                string ct1 = "SELECT distinct Rtrim(Class.ClassName),classid FROM ClassSection INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID order by classid";
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
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(Sessions.SessionID) FROM Sessions Where Sessions.Session = '" + txtSession.Text + "'";
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

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSection.Items.Clear();
                txtSection.Text = "";
                txtSection.Enabled = true;
                txtSection.Focus();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "SELECT  distinct Rtrim(Section.SectionName) FROM  ClassSection INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Class.ClassName=@d1 ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtClass.Text);
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

        private void txtSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct Rtrim(ClasssectionID) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "' and Section.SectionName = '" + txtSection.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassSectionID.Text = rdr.GetValue(0).ToString().Trim();
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
        public void Reset()
        {
            cmbSchool.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Text = "";
            txtSessionID.Text = "";
            txtSection.Text = "";
            txtClassSectionID.Text = "";
            cmbSection.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            listView1.Items.Clear();
            cmbSession.Enabled = false;
            cmbClass.Enabled = false;
            cmbSection.Enabled = false;
           
            txtSession.Enabled = false;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to update..Please retrieve data in listview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = listView1.Items.Count - 1; i >= 0; i += -1)
                {
                    if (listView1.Items[i].Checked == true)
                    {
                        con = new SqlConnection(cs.ReadfromXML());
                        string cd = "update student set Session_ID=@d1,ClassSection_ID=@d2 where AdmissionNo=@d3";
                        cmd = new SqlCommand(cd);

                        cmd.Parameters.AddWithValue("@d1", txtSessionID.Text);
                        cmd.Parameters.AddWithValue("@d2", txtClassSectionID.Text);
                        cmd.Parameters.AddWithValue("@d3", listView1.Items[i].SubItems[0].Text);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
