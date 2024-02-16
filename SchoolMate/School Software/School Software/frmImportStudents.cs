using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Data.SqlClient;
using System.IO;
namespace School_Software
{
    public partial class frmImportStudents : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmImportStudents()
        {
            InitializeComponent();
        }

        private void btnImportExcelSheet_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*";
                if (OpenFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(OpenFileDialog.FileName))
                {
                    Cursor = Cursors.WaitCursor;
                    timer1.Enabled = true;
                    string Pathname = OpenFileDialog.FileName;
                    System.Data.OleDb.OleDbConnection MyConnection = default(System.Data.OleDb.OleDbConnection);
                    System.Data.DataSet DtSet = default(System.Data.DataSet);
                    System.Data.OleDb.OleDbDataAdapter MyCommand = default(System.Data.OleDb.OleDbDataAdapter);
                    MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;");
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                    MyConnection.Open();
                    DtSet = new System.Data.DataSet();
                    MyCommand.Fill(DtSet);
                    DataGridView1.DataSource = DtSet.Tables[0];
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DataGridView1.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to save.." + "\n" + "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {

                    if (!row.IsNewRow)
                    {

                        string ct = "select AdmissionNo from Student where AdmissionNo=@d1";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@d1", row.Cells[4].Value.ToString());
                        rdr = cmd.ExecuteReader();
                        if (!rdr.Read())
                        {
                            rdr.Close();
                        }
                        else
                        {
                            MessageBox.Show("Admission No. Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DataGridView1.DataSource = null;
                            return;
                        }

                    }
                }
                  //cmd.Prepare();
                  foreach (DataGridViewRow row in DataGridView1.Rows)
                {

                    if (!row.IsNewRow)
                    {
                       
               con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb = "insert into student(AdmissionNo, EnrollmentNo, StudentName, FatherName, FatherOcc, MotherName, MotherOcc, ParentContact, PermanentAddress, TemporaryAddress, ContactNo, Email, DOB, Gender, AdmissionDate, Category,Religion, Nationality, ClassSection_ID, School_ID, LastSchool, LastClass, PassingYr, percents, Board, BloodGroup, Height, Weight, GuardianName, Address, GuardianContact,Session_ID,Result,HomeContact,Status,Photo,Country,City) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", row.Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@d2", row.Cells[7].Value.ToString());
                cmd.Parameters.AddWithValue("@d3", row.Cells[6].Value.ToString());
                cmd.Parameters.AddWithValue("@d4", row.Cells[16].Value.ToString());
                cmd.Parameters.AddWithValue("@d5", row.Cells[17].Value.ToString());
                cmd.Parameters.AddWithValue("@d6", row.Cells[18].Value.ToString());
                cmd.Parameters.AddWithValue("@d7", row.Cells[19].Value.ToString());
                cmd.Parameters.AddWithValue("@d8", row.Cells[20].Value.ToString());
                cmd.Parameters.AddWithValue("@d9", row.Cells[23].Value.ToString());
                cmd.Parameters.AddWithValue("@d10", row.Cells[24].Value.ToString());
                cmd.Parameters.AddWithValue("@d11", row.Cells[13].Value.ToString());
                cmd.Parameters.AddWithValue("@d12", row.Cells[15].Value.ToString());
                cmd.Parameters.AddWithValue("@d13", row.Cells[12].Value.ToString());
                cmd.Parameters.AddWithValue("@d14", row.Cells[11].Value.ToString());
                cmd.Parameters.AddWithValue("@d15",Convert.ToDateTime(row.Cells[5].Value.ToString()));
                cmd.Parameters.AddWithValue("@d16", row.Cells[25].Value.ToString());
                cmd.Parameters.AddWithValue("@d17", row.Cells[26].Value.ToString());
                cmd.Parameters.AddWithValue("@d18", row.Cells[27].Value.ToString());
                cmd.Parameters.AddWithValue("@d19", row.Cells[8].Value.ToString());
                cmd.Parameters.AddWithValue("@d20", row.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@d21", row.Cells[28].Value.ToString());
                cmd.Parameters.AddWithValue("@d22", row.Cells[29].Value.ToString());
                cmd.Parameters.AddWithValue("@d23", row.Cells[30].Value.ToString());
                cmd.Parameters.AddWithValue("@d24", row.Cells[32].Value.ToString());
                cmd.Parameters.AddWithValue("@d25", row.Cells[33].Value.ToString());
                cmd.Parameters.AddWithValue("@d26", row.Cells[37].Value.ToString());
                cmd.Parameters.AddWithValue("@d27", row.Cells[38].Value.ToString());
                cmd.Parameters.AddWithValue("@d28", row.Cells[39].Value.ToString());
                cmd.Parameters.AddWithValue("@d29",row.Cells[34].Value.ToString());
                cmd.Parameters.AddWithValue("@d30", row.Cells[35].Value.ToString());
                cmd.Parameters.AddWithValue("@d31", row.Cells[36].Value.ToString());
                cmd.Parameters.AddWithValue("@d32", row.Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@d33", row.Cells[31].Value.ToString());
                cmd.Parameters.AddWithValue("@d34", row.Cells[14].Value.ToString());
                cmd.Parameters.AddWithValue("@d35", row.Cells[40].Value.ToString());
                cmd.Parameters.AddWithValue("@d37", row.Cells[22].Value.ToString());
                cmd.Parameters.AddWithValue("@d38", row.Cells[21].Value.ToString());
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(Properties.Resources.photo);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d36", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb3 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", row.Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@d2", "Class");
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb4 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb4);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1",row.Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@d2", "Bus");
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.ReadfromXML());
                con.Open();
                string cb5 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb5);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1",row.Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@d2", "Hostel");
                cmd.Parameters.AddWithValue("@d3", "0.00");
                cmd.ExecuteReader();
                    }
                 }
               
                MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridView1.DataSource = null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }

        }
    }
}
