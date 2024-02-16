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
    public partial class frmLogin : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void fillusernType()
        {
            try
            {
               con = new SqlConnection(cs.ReadfromXML());
               con.Open();
               string ct = "SELECT Rtrim(Designations.Designation) FROM Users INNER JOIN Designations ON Users.Designation_ID = Designations.DesignationID";
              cmd = new SqlCommand(ct);
              cmd.Connection = con;
              rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUsertype.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (UserID.Text == "")
            {
                MessageBox.Show("Please enter user ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserID.Focus();
                return;
            }
            if (Password.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Users where UserID=@d1 and Password=@d2";
                cmd.Parameters.AddWithValue("@d1", UserID.Text);
                cmd.Parameters.AddWithValue("@d2", Password.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = con.CreateCommand();
                   cmd.CommandText = "SELECT Rtrim(Designations.Designation) FROM Users INNER JOIN Designations ON Users.Designation_ID = Designations.DesignationID where UserID=@d3 and Password=@d4";
                    cmd.Parameters.AddWithValue("@d3", UserID.Text);
                    cmd.Parameters.AddWithValue("@d4", Password.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        cmbUsertype.Text = rdr.GetValue(0).ToString().Trim();
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    frmMainmenu frm = new frmMainmenu();
                    frm.User.Text = UserID.Text;
                    frm.UserType.Text = cmbUsertype.Text;
                    this.Hide();
                    frm.ShowDialog();
                    st1 = UserID.Text;
                    st2 = "Successfully logged in";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                   }
                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserID.Clear();
                    Password.Clear();
                    UserID.Focus();
                }
               con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
            P1.Location = new Point(
    this.ClientSize.Width / 2 - P1.Size.Width / 2,
    this.ClientSize.Height / 2 - P1.Size.Height / 2);
            P1.Anchor = AnchorStyles.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           lblDate.Text = DateTime.Now.ToString();
            timer1.Start();
        }
    }
}
