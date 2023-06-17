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
    public partial class ViewCustomer : Form
    {
        SqlConnection connection;

        public ViewCustomer()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            loadData();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void loadData()
        {
            try
            {
                connection.Open();

                String cmd = "Select * FROM tbl_Customer;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvCustomer.DataSource = null;
                dgvCustomer.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvCustomer.ReadOnly = true;
                dgvCustomer.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                    txtCusNIC.Text = row.Cells[0].Value.ToString();
                    txtFullName.Text = row.Cells[1].Value.ToString();
                    txtAddress.Text = row.Cells[2].Value.ToString();
                    txtMobile.Text = row.Cells[3].Value.ToString();

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear()
        {
            txtAddress.ResetText();
            txtCusNIC.ResetText();
            txtFullName.ResetText();
            txtMobile.ResetText();
            txtSearchCusNIC.ResetText();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtCusNIC.Text == "" || txtFullName.Text == "" || txtMobile.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    String cmd = "UPDATE dbo.[tbl_Customer] SET Cus_Name='" + txtFullName.Text + "', Cus_Address='" + txtAddress.Text + "', Cus_Phone='" + txtMobile.Text  + "' WHERE Customer_NIC='" + txtCusNIC.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        connection.Close();
                        clear();
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
            if (txtCusNIC.Text == "")
            {
                MessageBox.Show("Please Select Customer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "DELETE  FROM dbo.[tbl_Customer] WHERE Customer_NIC='" + txtCusNIC.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        connection.Close();
                        clear();
                        MessageBox.Show("Customer Deleted Successfully");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchCusNIC.Text == "")
            {
                MessageBox.Show("Please Enter Customer NIC!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                connection.Open();
                String cmd = "Select * FROM tbl_Customer WHERE Customer_NIC='" + txtSearchCusNIC.Text + "';";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvCustomer.DataSource = null;
                dgvCustomer.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvCustomer.ReadOnly = true;
                dgvCustomer.DataSource = ds.Tables[0];
                connection.Close();
            }
        }
    }
}
