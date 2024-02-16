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
    public partial class frmBooksReservationsList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmBookReservations BR = null;
        frmBookIssue frmBI = null;
        public frmBooksReservationsList()
        {
            InitializeComponent();
        }
        public frmBooksReservationsList(frmBookIssue par2)
        {
            frmBI = par2;
            InitializeComponent();
        }
        public frmBooksReservationsList(frmBookReservations par)
        {
            BR = par;
            InitializeComponent();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID order by R_Date", con);
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
                cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID and BookReservation.Status='Reserved' order by R_Date", con);
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
        private void frmBooksReservationsList_Load(object sender, EventArgs e)
        {
           if (lblSET.Text == "BI")
            {
                Auto1();
            }
            else
            {
                Auto();
            }
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where EmployeeName like '%" + txtEmployeeName.Text + "%' and BookReservation.Status='Reserved' order by R_Date", con);
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
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where EmployeeName like '%" + txtEmployeeName.Text + "%' order by R_Date", con);
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

        private void Button2_Click(object sender, EventArgs e)
        {
            if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID Where R_Date Between @date1 and @Date2 and BookReservation.Status='Reserved' order by R_Date", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "R_Date").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "R_Date").Value = dtpDateTo.Value.Date;
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
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID Where R_Date Between @date1 and @Date2 order by R_Date", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "R_Date").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "R_Date").Value = dtpDateTo.Value.Date;
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

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "BI")
            {
                 try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where BookReservation.AccessionNo  like '%" + txtAccessionNo.Text + "%' and BookReservation.Status='Reserved' order by R_Date", con);
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
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where BookReservation.AccessionNo  like '%" + txtAccessionNo.Text + "%' order by R_Date", con);
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

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where Book.BookTitle like '%" + txtBookTitle.Text + "%' and BookReservation.Status='Reserved' order by R_Date", con);
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
                    cmd = new SqlCommand("SELECT Rtrim(BookReservation.ID),Rtrim(BookReservation.AccessionNo),Rtrim(Book.BookTitle),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(BookReservation.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),BookReservation.R_Date,Rtrim(BookReservation.Status),Rtrim(BookReservation.Remarks) FROM BookReservation INNER JOIN Book ON BookReservation.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookReservation.StaffID = Employee.EMPID where Book.BookTitle like '%" + txtBookTitle.Text + "%' order by R_Date", con);
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
        public void Reset()
        {
            txtAccessionNo.Text = "";
            txtBookTitle.Text = "";
            txtEmployeeName.Text = "";
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            Auto();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

          if (lblSET.Text == "BR") 
           try
            {
                if (DataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    {
                        this.Hide();
                        BR.Activate();
                        BR.BringToFront();
                        BR.txtID.Text = dr.Cells[0].Value.ToString();
                        BR.txtAccessionNo.Text = dr.Cells[1].Value.ToString();
                        BR.txtBookTitle.Text = dr.Cells[2].Value.ToString();
                        BR.txtAuthor.Text = dr.Cells[3].Value.ToString();
                        BR.txtJointAuthor.Text = dr.Cells[4].Value.ToString();
                        BR.txtStaffid.Text = dr.Cells[5].Value.ToString();
                        BR.txtStaffMaxID.Text = dr.Cells[6].Value.ToString();
                        BR.txtStaffName.Text = dr.Cells[7].Value.ToString();
                        BR.dtpReservationDate.Text = dr.Cells[8].Value.ToString();
                        BR.txtStatus.Text = dr.Cells[9].Value.ToString();
                        BR.txtRemarks.Text = dr.Cells[10].Value.ToString();
                        BR.btnSave.Enabled = false;
                        BR.btnCancelReservation.Enabled = true;
                        BR.Button1.Enabled = false;
                        BR.Button2.Enabled = false;
                        con = new SqlConnection(cs.ReadfromXML());
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + lblUser.Text + "'";
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            lblupdate.Text = rdr[0].ToString().Trim();
                            lbldelete.Text = rdr[1].ToString().Trim();

                        }
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        if (lblupdate.Text == "True")
                            BR.btnUpdate_record.Enabled = true;
                        else
                            BR.btnUpdate_record.Enabled = false;


                        if (lbldelete.Text == "True")
                            BR.btnDelete.Enabled = true;
                        else
                            BR.btnDelete.Enabled = false; 
                        this.lblSET.Text = "";
                    }
                }
            }
               
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          else if (lblSET.Text == "BI")
          {
              DataGridViewRow dr = DataGridView1.SelectedRows[0];
              this.Hide();
              frmBI.Show();
              frmBI.txtReservationID.Text = dr.Cells[0].Value.ToString();
              frmBI.txtAccessionNo1.Text = dr.Cells[1].Value.ToString();
              frmBI.txtS_ID.Text = dr.Cells[5].Value.ToString();
              frmBI.txtStaffID.Text = dr.Cells[6].Value.ToString();
              frmBI.txtStaffName.Text = dr.Cells[7].Value.ToString();
              frmBI.txtBookTitle1.Text = dr.Cells[2].Value.ToString();
              frmBI.txtAuthor1.Text = dr.Cells[3].Value.ToString();
              frmBI.txtJointAuthors1.Text = dr.Cells[4].Value.ToString();
              frmBI.FillStaffs();
              frmBI.btnSave1.Enabled = false;
              frmBI.btnIssueReservation.Enabled = true;
              frmBI.Button3.Enabled = false;
          }
        }
    }
}
