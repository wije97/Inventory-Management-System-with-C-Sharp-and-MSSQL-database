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
    public partial class ManageStaff : Form
    {
        SqlConnection connection;
        public ManageStaff()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtAge.Text == "" || txtFullName.Text == "" || txtMobile.Text == "" || txtPassword.Text == "" || txtSalary.Text == "" || txtStaffID.Text == "" || txtUsername.Text == "" || cmbGender.Text=="" || cmbType.Text=="")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "INSERT INTO  dbo.[tbl_Staff_Member](StaffID, S_FullName, S_Gender, S_Age, S_Address, S_Mobile, S_Type, S_Salary) " + " VALUES ('" + txtStaffID.Text + "','" + txtFullName.Text + "','" + cmbGender.Text + "','" + txtAge.Text + "','" + txtAddress.Text + "','" + txtMobile.Text + "','" + cmbType.Text + "','" + txtSalary.Text +  "')";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        String type = cmbType.Text;
                        String cmd2 = "INSERT INTO  dbo.[tbl_Staff_Login](ST_StaffID, ST_Username, ST_Password, ST_LogAttempt) " + " VALUES ('" + txtStaffID.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "' , 5 )";
                        
                        SqlCommand command2 = new SqlCommand(cmd2, connection);
                        int j = command2.ExecuteNonQuery();

                        if (i != 0)
                        {
                            clear();
                            connection.Close();
                            MessageBox.Show("Added Successfully");
                            loadData();

                        }

                    }
                    else
                    {
                        MessageBox.Show("Data not Saved");
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void loadData()
        {
            try
            {
                connection.Open();

                String cmd = "Select tbl_Staff_Member.*, tbl_Staff_Login.ST_Username, tbl_Staff_Login.ST_Password, tbl_Staff_Login.ST_LogAttempt FROM tbl_Staff_Member INNER JOIN tbl_Staff_Login ON tbl_Staff_Member.StaffID=tbl_Staff_Login.ST_STaffID;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvStaffUpdate.DataSource = null;
                dgvStaffUpdate.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvStaffUpdate.ReadOnly = true;
                dgvStaffUpdate.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageStaff_Load(object sender, EventArgs e)
        {
            loadData();
            lblLocked.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvStaffUpdate_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                txtStaffID.ReadOnly = true;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvStaffUpdate.Rows[e.RowIndex];
                    txtStaffID.Text = row.Cells[0].Value.ToString();
                    txtFullName.Text = row.Cells[1].Value.ToString();
                    cmbGender.Text = row.Cells[2].Value.ToString();
                    txtAge.Text = row.Cells[3].Value.ToString();
                    txtAddress.Text = row.Cells[4].Value.ToString();
                    txtMobile.Text = row.Cells[5].Value.ToString();
                    cmbType.Text = row.Cells[6].Value.ToString();
                    txtSalary.Text = row.Cells[7].Value.ToString();
                    txtUsername.Text = row.Cells[8].Value.ToString();
                    txtPassword.Text = row.Cells[9].Value.ToString();
                    int logAtmpt = Convert.ToInt32(row.Cells[10].Value.ToString());

                    if(logAtmpt == 0)
                    {
                        lblLocked.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear()
        {
            txtAddress.ResetText();
            txtAge.ResetText();
            txtFullName.ResetText();
            txtMobile.ResetText();
            txtPassword.ResetText();
            txtSalary.ResetText();
            txtStaffID.ResetText();
            txtUsername.ResetText();
            cmbGender.Text = "";
            cmbType.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtStaffID.ReadOnly = false;
            lblLocked.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            txtSearchStID.ResetText();
            cmbSearchType.Text = "";
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtAge.Text == "" || txtFullName.Text == "" || txtMobile.Text == "" || txtPassword.Text == "" || txtSalary.Text == "" || txtStaffID.Text == "" || txtUsername.Text == "" || cmbGender.Text == "" || cmbType.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "UPDATE dbo.[tbl_Staff_Member] SET S_FullName='" + txtFullName.Text + "', S_Gender='" + cmbGender.Text + "', S_Age='" + txtAge.Text + "', S_Address='" + txtAddress.Text + "', S_Mobile='" + txtMobile.Text + "', S_Type='" + cmbType.Text + "', S_Salary='" + txtSalary.Text +  "' WHERE StaffID='" + txtStaffID.Text + "';";

                    String cmd2 = "UPDATE dbo.[tbl_Staff_Login] SET ST_Username='" + txtUsername.Text + "', ST_Password='" + txtPassword.Text + "', ST_LogAttempt= 5 WHERE ST_StaffID='" + txtStaffID.Text + "';";


                    SqlCommand command = new SqlCommand(cmd, connection);
                    SqlCommand command2 = new SqlCommand(cmd2, connection);

                    int i = command.ExecuteNonQuery();
                    int j = command2.ExecuteNonQuery();

                    if (i != 0 && j != 0)
                    {
                        clear();
                        connection.Close();
                        loadData();
                        MessageBox.Show("Updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text == "")
            {
                MessageBox.Show("Please Select Staff Member!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "DELETE  FROM dbo.[tbl_Staff_Member] WHERE StaffID='" + txtStaffID.Text + "';";
                    String cmd2 = "DELETE  FROM dbo.[tbl_Staff_Login] WHERE ST_StaffID='" + txtStaffID.Text + "';";
                    
                    SqlCommand command = new SqlCommand(cmd, connection);
                    SqlCommand command2 = new SqlCommand(cmd2, connection);

                    int i = command.ExecuteNonQuery();
                    int j = command2.ExecuteNonQuery();

                    if (i != 0 && j != 0)
                    {
                        clear();
                        connection.Close();
                        loadData();
                        MessageBox.Show("Member Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Data not Deleted");
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void search(int type, String value)
        {
            try
            {
                
                connection.Open();
                String cmd;

                if (type == 1)
                {
                    cmd = "Select * FROM tbl_Staff_Member WHERE StaffID='" + value + "';";
                }else{
                    cmd = "Select * FROM tbl_Staff_Member WHERE S_Type='" + value + "';";
                }

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvStaffUpdate.DataSource = null;
                dgvStaffUpdate.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvStaffUpdate.ReadOnly = true;
                dgvStaffUpdate.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchStID.Text == "")
            {
                MessageBox.Show("Please Enter Staff ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                search(1, txtSearchStID.Text);
                clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "")
            {
                MessageBox.Show("Please Select Staff Type!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                search(2, cmbSearchType.Text);
                clear();
            }
        }
    }
}
