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
    public partial class AddCustomer : Form
    {
        SqlConnection connection;

        public AddCustomer()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            loadData();
            btnNext.Enabled = false;
        }

        public void loadData()
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

        private void btnSave_Click(object sender, EventArgs e)
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

                    String cmd = "INSERT INTO  dbo.[tbl_Customer](Customer_NIC,Cus_Name,Cus_Address,Cus_Phone) " + " VALUES ('" + txtCusNIC.Text + "','" + txtFullName.Text + "','" + txtAddress.Text + "','" + txtMobile.Text + "')";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {

                        connection.Close();
                        clear();
                        MessageBox.Show("Added Successfully");
                        loadData();
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
        private void clear()
        {
            txtAddress.ResetText();
            txtCusNIC.ResetText();
            txtFullName.ResetText();
            txtMobile.ResetText();
            txtSearchCusNIC.ResetText();
            loadData();
            btnSave.Enabled = true;
            txtCusNIC.ReadOnly = false;

            btnNext.Enabled = false;
        }

        private void dgvCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                txtCusNIC.ReadOnly = true;

                btnNext.Enabled = true;

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtCusNIC.Text == "")
            {
                MessageBox.Show("Please Select Customer First!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                AddOrder form1 = new AddOrder();
                form1.txtCusNICOrder.Text = txtCusNIC.Text;
                form1.Show();
                this.Hide();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchCusNIC.Text == "")
            {
                MessageBox.Show("Please Enter Customer NIC!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
