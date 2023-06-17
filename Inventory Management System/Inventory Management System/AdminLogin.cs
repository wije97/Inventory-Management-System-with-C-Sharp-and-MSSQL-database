using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Management_System
{
    public partial class AdminLogin : Form
    {
        SqlConnection connection;

        public AdminLogin()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    String cmd1 = "SELECT A_Username, A_Password FROM dbo.[tbl_Admin] WHERE  A_Username='" + txtUserName.Text + "' AND A_Password='" + txtPassword.Text + "';";
                    SqlCommand command = new SqlCommand(cmd1, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {


                        AdminDashboard form1 = new AdminDashboard();
                        form1.Show();
                        this.Hide();

                        reader.Close();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Correct Username and Password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StaffLogin form2 = new StaffLogin();
            form2.Show();
            this.Hide();
        }
    }
}
