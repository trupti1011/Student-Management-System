using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class Login : Form
    {
       private static string _UserType;
        private static string _UserName;

        public static string UserName
        {
            get { return Login._UserName; }
            set { Login._UserName = value; }
        }

        public static string UserType
        {
            get { return Login._UserType; }
            set { Login._UserType = value; }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtUsername.Text == string.Empty))
                {
                    if (!(txtPassword.Text == string.Empty))
                    {
                        //Can you open SQL and share screen?
                        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-VLOKU34J;Initial Catalog=Student_Management_System;Integrated Security=True"); // making connection   
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM UserLogin WHERE UserName='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "'", con);
                        DataTable dt = new DataTable();                         
                        sda.Fill(dt);
                        if (dt != null && dt.Rows.Count>0)
                        {
                            _UserType = dt.Rows[0][3].ToString().Trim();
                            _UserName = dt.Rows[0][1].ToString().Trim();
                            if (_UserType.Trim() != "" || _UserType.Trim() != null)
                            {
                                this.Hide();
                                new AddEditStudent().Show();
                            }
                            else
                                MessageBox.Show("Invalid username or password");
                        }
                        else
                            MessageBox.Show("Invalid username or password");
                    }
                    else
                    {
                        MessageBox.Show("password empty", "login page");
                    }
                }
                else
                {
                    MessageBox.Show(" username empty", "login page");
                }
                // con.Close();  
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        

    }
}
