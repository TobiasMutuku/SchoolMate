using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace School_Software
{
    public partial class frmEmployeeList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmEmployeeEntry frm = null;
        frmBusHolderStaff frm1 = null;
        frmBookReservations frmBR = null;
        frmBookIssue frmBI = null;
        public frmEmployeeList(frmEmployeeEntry par)
        {
            frm = par; 
            InitializeComponent();
        }
        public frmEmployeeList(frmBookIssue par3)
        {
            frmBI = par3;
            InitializeComponent();
        }
        public frmEmployeeList(frmBusHolderStaff par1)
        {
            frm1 = par1;
            InitializeComponent();
        }
        public frmEmployeeList(frmBookReservations par2)
        {
            frmBR = par2;
            InitializeComponent();
        }
        public frmEmployeeList()
        {
           InitializeComponent();
        }
        public void auto()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID  order by Employee.EMPID";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void auto1()
        {
            try
            {
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID Where Employee.Status='Active'order by Employee.EMPID";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                auto1();
            }
            else if (lblSET.Text == "BI")
            {
                auto1();
            } 
            else
            {
                auto();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "S")
            {
                 try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frm1.Show();
                    frm1.txtStaffID.Text = dr.Cells[0].Value.ToString();
                    frm1.txtMaxID.Text = dr.Cells[1].Value.ToString();
                    frm1.txtStaffName.Text = dr.Cells[2].Value.ToString();
                    frm1.txtSchoolID.Text = dr.Cells[15].Value.ToString();
                    frm1.txtSchoolName.Text = dr.Cells[16].Value.ToString();
                    frm1.txtDepartment.Text = dr.Cells[18].Value.ToString();
                    frm1.txtdesignation.Text = dr.Cells[20].Value.ToString();
                }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }  
          }
            else if (lblSET.Text == "BR")
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frmBR.Show();
                    frmBR.txtStaffid.Text = dr.Cells[0].Value.ToString();
                    frmBR.txtStaffMaxID.Text = dr.Cells[1].Value.ToString();
                    frmBR.txtStaffName.Text = dr.Cells[2].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BIS")
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frmBI.Show();
                    frmBI.txtS_ID.Text = dr.Cells[0].Value.ToString();
                    frmBI.txtStaffID.Text = dr.Cells[1].Value.ToString();
                    frmBI.txtStaffName.Text = dr.Cells[2].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "ST")
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frm.Activate();
                    frm.BringToFront();
                    frm.txtEmployeeID.Text = dr.Cells[0].Value.ToString();
                    frm.txtEmployeeMAX.Text = dr.Cells[1].Value.ToString();
                    frm.txtEmployeeName.Text = dr.Cells[2].Value.ToString();
                    if ((dr.Cells[3].Value.ToString() == "Male"))
                    {
                        frm.radioButton1.Checked = true;
                    }
                    if ((dr.Cells[3].Value.ToString() == "Female"))
                    {
                        frm.radioButton2.Checked = true;
                    }
                    frm.txtDOB.Text = dr.Cells[4].Value.ToString();
                    frm.txtBloodGroup.Text = dr.Cells[5].Value.ToString();
                    frm.txtFatherName.Text = dr.Cells[6].Value.ToString();
                    frm.txtmotherName.Text = dr.Cells[7].Value.ToString();
                    frm.txtReligion.Text = dr.Cells[8].Value.ToString();
                    frm.txtContactNo.Text = dr.Cells[9].Value.ToString();
                    frm.txtJoiningDate.Text = dr.Cells[10].Value.ToString();
                    frm.txtEmail.Text = dr.Cells[11].Value.ToString();
                    frm.txtCity.Text = dr.Cells[12].Value.ToString();
                    frm.txtCountry.Text = dr.Cells[13].Value.ToString();
                    frm.txtAddress.Text = dr.Cells[14].Value.ToString();
                    frm.txtSchoolID.Text = dr.Cells[15].Value.ToString();
                    frm.txtSchoolName.Text = dr.Cells[16].Value.ToString();
                    frm.txtDepartmentID.Text = dr.Cells[17].Value.ToString();
                    frm.txtDepartment.Text = dr.Cells[18].Value.ToString();
                    frm.txtDesignationID.Text = dr.Cells[19].Value.ToString();
                    frm.txtDesignation.Text = dr.Cells[20].Value.ToString();
                    frm.txtBasicSalary.Text = dr.Cells[21].Value.ToString();

                    frm.txtAccountName.Text = dr.Cells[24].Value.ToString();
                    frm.txtAccountNo.Text = dr.Cells[25].Value.ToString();
                    frm.txtBank.Text = dr.Cells[26].Value.ToString();
                    frm.txtBranch.Text = dr.Cells[27].Value.ToString();
                    frm.txtIFSCcode.Text = dr.Cells[28].Value.ToString();
            
                    if ((dr.Cells[22].Value.ToString() == "Active"))
                    {
                        frm.txtcheckBox.Checked = true;
                    }
                    if ((dr.Cells[22].Value.ToString() == "Inactive"))
                    {
                        frm.txtcheckBox.Checked = false;
                    }
                    byte[] data = (byte[])dr.Cells[23].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.pictureBox1.Image = Image.FromStream(ms);
                    frm.btnNewRecord.Enabled = true;
                    frm.btnSave.Enabled = false;
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + lblUser.Text + "'";
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
                        frm.btnUpdate_record.Enabled = true;
                    else
                        frm.btnUpdate_record.Enabled = false;


                    if (lbldelete.Text == "True")
                        frm.btnDelete.Enabled = true;
                    else
                        frm.btnDelete.Enabled = false;  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
               string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and EmployeeName like '%" + txtEmployeeName.Text + "%'  order by Employee.EMPIDe";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BI")
            {
             try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and EmployeeName like '%" + txtEmployeeName.Text + "%' order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
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
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where EmployeeName like '%" + txtEmployeeName.Text + "%' order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
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
            if (lblSET.Text == "S")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and DateOfJoining Between @date1 and @Date2 order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfJoining").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfJoining").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "BI")
            {
                try
                {
                    con = new SqlConnection(cs.ReadfromXML());
                    con.Open();
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where Employee.Status='Active' and DateOfJoining between @d1 and @d2 order by Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
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
                    String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Employee.Gender),Rtrim(Employee.DOB),Rtrim(Employee.BloodGroup),Rtrim(Employee.FatherName),Rtrim(Employee.MotherName),Rtrim(Employee.Religion),Rtrim(Employee.ContactNo),Employee.DateOfJoining,Rtrim(Employee.Email),Rtrim(Employee.City),Rtrim(Employee.Country),Rtrim(Employee.Address),Rtrim(Employee.SchoolID),Rtrim(School.SchoolName),Rtrim(Employee.Department_ID),Rtrim(Department.DepartmentName),Rtrim(Employee.Designation_ID),Rtrim(Designations.Designation),Rtrim(Employee.Salary),Rtrim(Employee.Status),Employee.Photo, Rtrim(Employee.AccountName),Rtrim(Employee.AccountNumber),Rtrim(Employee.Bank),Rtrim(Employee.Branch),Rtrim(Employee.IFSCcode) FROM  Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN School ON Employee.SchoolID = School.SchoolID where DateOfJoining between @d1 and @d2 order by EmployeeName Employee.EMPID";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }
        public void Reset()
        {
            txtEmployeeName.Text = "";
           dataGridView1.Rows.Clear();
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            if (lblSET.Text == "S")
            {
                auto1();
            }
            else if (lblSET.Text == "BI")
            {
                auto1();
            }
            else
            {
                auto();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }
        }
    }

