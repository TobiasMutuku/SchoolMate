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
    public partial class frmBookReservations : Form
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
        public frmBookReservations()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo.Text == "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo.Focus();
                return;
            }
            if (txtStaffMaxID.Text == "")
            {
                MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffMaxID.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct = "select Status from BookReservation where AccessionNo=@d1 and Status='Reserved'";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Book is already reserved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string ct1 = "select Status from BookReservation where AccessionNo=@d1 and Status='Issued'";
                cmd = new SqlCommand(ct1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Book is already issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();

                string cb = "insert into BookReservation(AccessionNo,StaffID,R_Date, Status, Remarks) VALUES (@d2,@d3,@d4,'Reserved',@d5)";
                cmd = new SqlCommand(cb);
                 cmd.Parameters.AddWithValue("@d2", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtStaffid.Text);
                cmd.Parameters.AddWithValue("@d4", dtpReservationDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", txtRemarks.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb1 = "Update Book Set Status='Reserved' where AccessionNo=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Book '" + txtAccessionNo.Text + "' is Reserved For Staff '" + txtStaffName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully reserved", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Reset()
        {
            txtAccessionNo.Text = "";
            txtAuthor.Text = "";
            txtBookTitle.Text = "";
            txtID.Text = "";
            txtJointAuthor.Text = "";
            txtRemarks.Text = "";
            txtStaffMaxID.Text = "";
            txtStaffid.Text = "";
            txtStaffName.Text = "";
            txtStatus.Text = "";
            func();
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            btnCancelReservation.Enabled = false;
            Button1.Enabled = true;
            Button2.Enabled = true;
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "Update BookReservation set AccessionNo=@d2,StaffID=@d3,R_Date=@d4,Remarks=@d5 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d2", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtStaffid.Text);
                cmd.Parameters.AddWithValue("@d4", dtpReservationDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", txtRemarks.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Book '" + txtAccessionNo.Text + "' is Reserved For Staff '" + txtStaffName.Text + "' is Updated";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtStatus.Text == "Cancelled"))
                {
                    MessageBox.Show("Reservation is already cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((txtStatus.Text == "Issued"))
                {
                    MessageBox.Show("Reserved book is already issued so it can not be cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Are you sure want to cancel this reservation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb = "update BookReservation set Status='Cancelled' where ID=" + txtID.Text + "";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    string cb1 = "Update Book Set Status='Available' where AccessionNo=@d1";
                    cmd = new SqlCommand(cb1);
                    cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    st1 = lblUser.Text;
                    st2 = " Reservation Cancelled of Book '" + txtAccessionNo.Text + "' Which is Reserved For Staff '" + txtStaffName.Text + "' ";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully cancelled", "Book Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancelReservation.Enabled = false;
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmBooksList  frm = new frmBooksList(this);
            frm.lblSET.Text = "BR";
            frm.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           frmEmployeeList frm = new frmEmployeeList(this);
            frm.lblSET.Text = "BR";
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBooksReservationsList frm = new frmBooksReservationsList(this);
            frm.lblSET.Text = "BR";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }
        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cq = "delete from BookReservation where ID=@d1";
                cmd = new SqlCommand(cq);
                cmd.Parameters.AddWithValue("@d1", txtID.Text);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "deleted the Reserve book'" + txtAccessionNo.Text + "' record for staff'" + txtStaffName.Text + "' having ReservationID='" + txtID.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
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
                DeleteRecord();
            }
        }
        private void func()
        {
            con = new SqlConnection(cs.ReadfromXML());
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblsave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblsave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;
        }
        private void frmBookReservations_Load(object sender, EventArgs e)
        {

        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Books's Info from Books List");
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Staff's Info from Employee List");
        }
    }
}
