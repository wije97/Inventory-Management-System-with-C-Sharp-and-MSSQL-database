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

namespace Inventory_Management_System
{
    public partial class StaffLogin : Form
    {
        SqlConnection connection;
        String loginAttempt, staffID;

        public StaffLogin()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin form1 = new AdminLogin();
            form1.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (cmbType.Text == "")
            {
                MessageBox.Show("Please Select User Type!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (txtUserName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Username and Password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    try
                    {
                        connection.Open();
                        String cmd1 = "SELECT tbl_Staff_Login.ST_Username, tbl_Staff_Login.ST_LogAttempt, tbl_Staff_Login.ST_StaffID  FROM dbo.[tbl_Staff_Login]  INNER JOIN tbl_Staff_Member ON tbl_Staff_Login.ST_StaffID = tbl_Staff_Member.StaffID WHERE tbl_Staff_Login.ST_Username='" + txtUserName.Text + "' AND tbl_Staff_Member.S_Type = '" + cmbType.Text + "';";
                        SqlCommand command = new SqlCommand(cmd1, connection);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read() == true)
                        {
                            loginAttempt = reader[1].ToString();
                            staffID = reader[2].ToString();
                            reader.Close();

                            if (loginAttempt != "0")
                            {
                                String cmd2 = "SELECT tbl_Staff_Login.ST_Password  FROM dbo.[tbl_Staff_Login]  WHERE ST_StaffID='" + staffID + "' AND ST_Password= '" + txtPassword.Text + "';";
                                SqlCommand command2 = new SqlCommand(cmd2, connection);

                                SqlDataReader reader2 = command2.ExecuteReader();

                                if (reader2.Read() == true)
                                {
                                    reader2.Close();
                                    updateLoginAttempt(staffID, Convert.ToInt32(loginAttempt), 2);

                                    if (cmbType.Text == "Accountant")
                                    {
                                        AccountantDashboard form1 = new AccountantDashboard();
                                        form1.Show();
                                        this.Hide();
                                    }
                                    else if (cmbType.Text == "Cashier")
                                    {
                                        CashierDashboard form2 = new CashierDashboard();
                                        form2.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        StaffAssistantDashboard form3 = new StaffAssistantDashboard();
                                        form3.Show();
                                        this.Hide();
                                    }
                                    reader2.Close();
                                }
                                else
                                {
                                    reader2.Close();
                                    updateLoginAttempt(staffID, Convert.ToInt32(loginAttempt), 1);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Your Account was locked. Please contact Administration!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            reader.Close();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Correct Username!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void updateLoginAttempt(String stID, int attempt, int type)
        {
            try
            {
                String cmd3;
                int updateAtmpt;

                if (type == 1)
                {
                    updateAtmpt = attempt - 1;
                }
                else
                {
                    updateAtmpt = 5;
                }
                cmd3 = "UPDATE dbo.[tbl_Staff_Login] SET ST_LogAttempt='" + updateAtmpt + "' WHERE ST_StaffID='" + stID + "';";

                SqlCommand command3 = new SqlCommand(cmd3, connection);

                int i = command3.ExecuteNonQuery();

                if (i != 0)
                {
                    if(type == 1)
                    {
                        MessageBox.Show("Please Enter Correct Password!\n\nYou have " + updateAtmpt + " Attempts left!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //MessageBox.Show("You have " + updateAtmpt + " Attempts left!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Update Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
