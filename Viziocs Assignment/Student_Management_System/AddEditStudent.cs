using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class AddEditStudent : Form
    {
        String conString = "Data Source=LAPTOP-VLOKU34J;Initial Catalog=Student_Management_System;Integrated Security=True";
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        string Id = null;
        string pinCode = @"^\d{6,}$";
        string mobileNo = @"^\d{10,}$";
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"; // Email address pattern  
        string _UserType = Login.UserType.Trim();
        string _UserName = Login.UserName.Trim();
        DataTable _StudentDetails;
        public AddEditStudent()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            dtpBirthDate.Value = DateTime.Now;
            dtpBirthDate.MaxDate = DateTime.Now;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isEmailValid = Regex.IsMatch(txtEmail.Text, emailPattern);
            bool isPinValid = Regex.IsMatch(txtPostalCode.Text, pinCode);
            bool isPhoneValid = Regex.IsMatch(txtContactNo.Text, mobileNo);
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter Student Name !!!");
                txtName.Select();
            }
            else if (cmbGender.SelectedIndex == 0)
            {
                MessageBox.Show("Select Gender !!!");
                cmbGender.Select();
            }
            else if (Convert.ToDateTime(dtpBirthDate.Text) == DateTime.Now.Date)
            {
                MessageBox.Show("Enter Birthdate !!!");
                dtpBirthDate.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Enter Email !!!");
                txtEmail.Select();

            }
            else if (string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                MessageBox.Show("Enter Contact Number !!!");
                txtContactNo.Select();

            }
            else if (cmbClass.SelectedIndex == 0)
            {
                MessageBox.Show("Select Class !!!");
                cmbClass.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Enter Address !!!");
                txtAddress.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                MessageBox.Show("Enter Street !!!");
                txtStreet.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Enter City !!!");
                txtCity.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtState.Text))
            {
                MessageBox.Show("Enter State !!!");
                txtState.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                MessageBox.Show("Enter Postal Code !!!");
                txtPostalCode.Select();

            }
            else if (!isPinValid)
            {
                MessageBox.Show("Please enter a valid zip code");
                txtPostalCode.Select();
            }
            else if (!isPhoneValid)
            {
                MessageBox.Show("Please enter a valid phone number");
                txtContactNo.Select();
            }
            else if (!isEmailValid)
            {
                MessageBox.Show("Please enter a valid email");
                txtEmail.Select();
            }
            else
            {
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                    }
                    DataTable dtData = new DataTable();
                    sqlCmd = new SqlCommand("usp_AddEditStudent", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Id", Id);
                    sqlCmd.Parameters.AddWithValue("@Name", txtName.Text);
                    sqlCmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(dtpBirthDate.Text));
                    sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    sqlCmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text);
                    sqlCmd.Parameters.AddWithValue("@Class", cmbClass.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    sqlCmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                    sqlCmd.Parameters.AddWithValue("@City", txtCity.Text);
                    sqlCmd.Parameters.AddWithValue("@State", txtState.Text);
                    sqlCmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    sqlCmd.Parameters.AddWithValue("@Pincode", Convert.ToInt32(txtPostalCode.Text));
                    sqlCmd.Parameters.AddWithValue("@ActionType", "SaveData");
                    int numRes = sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully !!!");
                    ClearAllData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:- " + ex.Message);
                }
            }
        }

        private void AddEditStudent_Load(object sender, EventArgs e)
        {
            this.studentDetailsTableAdapter.Fill(this.student_Management_SystemDataSet.StudentDetails);
            _StudentDetails = this.student_Management_SystemDataSet.StudentDetails;
            this.usp_SelectClassTableAdapter.Fill(this.studentDetails.usp_SelectClass);
            this.usp_SelectGenderTableAdapter.Fill(this.studentDetails.usp_SelectGender);

            if (_UserType == "S")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                tabControl1.TabPages.Remove(tbpgStudentDetails);
                //tbpgStudentDetails.Enabled = false;
                btnAdd.Visible = false;
                btnClear.Visible = false;
                btnDelete.Visible = false;

                //DataView dv = new DataView(_StudentDetails);
                //dv.RowFilter = "[Name] = '" + _UserName + "'";
                _StudentDetails.DefaultView.RowFilter = "[Name] = '" + _UserName + "'";

                DataTable dtData = new DataTable();
                dtData = _StudentDetails.DefaultView.ToTable();
                if (dtData.Rows.Count > 0)
                {
                    Id = dtData.Rows[0][0].ToString();
                    txtName.Text = dtData.Rows[0][1].ToString();
                    cmbGender.SelectedValue = dtData.Rows[0][2].ToString();
                    dtpBirthDate.Text = dtData.Rows[0][3].ToString();
                    txtEmail.Text = dtData.Rows[0][4].ToString();
                    txtContactNo.Text = dtData.Rows[0][5].ToString();
                    cmbClass.SelectedValue = dtData.Rows[0][6].ToString();
                    txtAddress.Text = dtData.Rows[0][7].ToString();
                    txtStreet.Text = dtData.Rows[0][8].ToString();
                    txtCity.Text = dtData.Rows[0][9].ToString();
                    txtState.Text = dtData.Rows[0][10].ToString();
                    txtCountry.Text = dtData.Rows[0][11].ToString();
                    txtPostalCode.Text = dtData.Rows[0][12].ToString();
                }


            }
            else
            {
                dgvStudentDetails.AutoGenerateColumns = false; // dgvEmp is DataGridView name  
                dgvStudentDetails.DataSource = FetchStudentDetails();
                button1.Visible = false;
                textBox1.Visible = false;
            }
        }
        private DataTable FetchStudentDetails()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            DataTable dtData = new DataTable();
            sqlCmd = new SqlCommand("usp_AddEditStudent", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ActionType", "FetchData");
            SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
            sqlSda.Fill(dtData);
            return dtData;
        }

        private void dgvStudentDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (_UserType == "A")

                {
                    btnAdd.Text = "Update";
                    Id = dgvStudentDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DataTable dtData = FetchStudentRecords(Id);
                    if (dtData.Rows.Count > 0)
                    {
                        Id = dtData.Rows[0][0].ToString();
                        txtName.Text = dtData.Rows[0][1].ToString();
                        cmbGender.SelectedValue = dtData.Rows[0][2].ToString();
                        dtpBirthDate.Text = dtData.Rows[0][3].ToString();
                        txtEmail.Text = dtData.Rows[0][4].ToString();
                        txtContactNo.Text = dtData.Rows[0][5].ToString();
                        cmbClass.SelectedValue = dtData.Rows[0][6].ToString();
                        txtAddress.Text = dtData.Rows[0][7].ToString();
                        txtStreet.Text = dtData.Rows[0][8].ToString();
                        txtCity.Text = dtData.Rows[0][9].ToString();
                        txtState.Text = dtData.Rows[0][10].ToString();
                        txtCountry.Text = dtData.Rows[0][11].ToString();
                        txtPostalCode.Text = dtData.Rows[0][12].ToString();

                    }
                    else
                    {
                        ClearAllData(); // For clear all control and refresh DataGridView data.  
                    }
                    tabControl1.SelectedTab = tbpgAddEditStudent;
                }
                else
                {
                    MessageBox.Show("student nohaving edit  option");
                }
            }
        }

        private DataTable FetchStudentRecords(string Id)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            DataTable dtData = new DataTable();
            sqlCmd = new SqlCommand("usp_AddEditStudent", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ActionType", "FetchRecord");
            sqlCmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
            sqlSda.Fill(dtData);
            return dtData;
        }

        private void ClearAllData()
        {
            btnAdd.Text = "Save";
            txtName.Text = "";
            cmbGender.SelectedIndex = 0;
            dtpBirthDate.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            cmbClass.SelectedIndex = 0;
            txtAddress.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            txtPostalCode.Text = "";
            Id = "";
            dgvStudentDetails.AutoGenerateColumns = false;
            dgvStudentDetails.DataSource = FetchStudentDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Id))
            {

                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                    }
                    DataTable dtData = new DataTable();
                    sqlCmd = new SqlCommand("usp_AddEditStudent", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ActionType", "DeleteData");
                    sqlCmd.Parameters.AddWithValue("@Id", Id);
                    int numRes = sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully !!!");
                    ClearAllData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:- " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Record !!!");
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }


        string saveDirectory = @"D:\StudentsFiles\";

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Excel(*.xls,*.xlsx)|*.xls;*.xlsx|PDF(*.pdf)|*.pdf";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }


                    textBox1.Text = openFileDialog1.FileName;

                    string fileName = Path.GetFileName(openFileDialog1.FileName);
                    string fileSavePath = Path.Combine(saveDirectory, fileName);
                    File.Copy(openFileDialog1.FileName, fileSavePath, true);
                }
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtByName_TextChanged(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter adapt = new SqlDataAdapter("select * from StudentDetails where Name like '" + txtByName.Text + "%'", sqlCon);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dgvStudentDetails.DataSource = dt;
            sqlCon.Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter adapt = new SqlDataAdapter("select * from StudentDetails where BirthDate Between '" + dtpFromDate.Text + "' AND '" + dtpToDate.Text + "'", sqlCon);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dgvStudentDetails.DataSource = dt;
            sqlCon.Close();
        }

        private void dtpToDate_CloseUp(object sender, EventArgs e)
        {
            DateTime fromdate = Convert.ToDateTime(dtpFromDate.Text);
            DateTime todate1 = Convert.ToDateTime(dtpToDate.Text);
            if (fromdate <= todate1)
            {
                TimeSpan daycount = todate1.Subtract(fromdate);
                int dacount1 = Convert.ToInt32(daycount.Days) + 1;
                // MessageBox.Show(Convert.ToString(dacount1));
            }
            else
            {
                MessageBox.Show("From Date Must be Less Than To Date");
            }
        }
    }
}
