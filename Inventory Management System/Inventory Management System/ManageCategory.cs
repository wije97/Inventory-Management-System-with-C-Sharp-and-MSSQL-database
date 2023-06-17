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
    public partial class ManageCategory : Form
    {
        SqlConnection connection;

        public ManageCategory()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCatID.Text == "" || txtCatName.Text == "" || txtCatDesc.Text == "" )
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "INSERT INTO  dbo.[tbl_Category](CategoryID, Cat_Name, Cat_Desc) " + " VALUES ('" + txtCatID.Text + "','" + txtCatName.Text + "','" + txtCatDesc.Text + "')";

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
            txtCatName.ResetText();
            txtCatID.ResetText();
            txtCatDesc.ResetText();
            txtSearchCatID.ResetText();
            loadData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtCatID.ReadOnly = false;
        }

        public void loadData()
        {
            try
            {
                connection.Open();

                String cmd = "Select * FROM tbl_Category;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvCatUpdate.DataSource = null;
                dgvCatUpdate.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvCatUpdate.ReadOnly = true;
                dgvCatUpdate.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageCategory_Load(object sender, EventArgs e)
        {
            loadData();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvCatUpdate_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                txtCatID.ReadOnly = true;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCatUpdate.Rows[e.RowIndex];
                    txtCatID.Text = row.Cells[0].Value.ToString();
                    txtCatName.Text = row.Cells[1].Value.ToString();
                    txtCatDesc.Text = row.Cells[2].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCatID.Text == "" || txtCatName.Text == "" || txtCatDesc.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "UPDATE dbo.[tbl_Category] SET Cat_Name='" + txtCatName.Text + "', Cat_Desc='" + txtCatDesc.Text + "' WHERE CategoryID='" + txtCatID.Text + "';";

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
            if (txtCatID.Text == "")
            {
                MessageBox.Show("Please Select Category!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "DELETE  FROM dbo.[tbl_Category] WHERE CategoryID='" + txtCatID.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        connection.Close();
                        clear();
                        MessageBox.Show("Category Deleted Successfully");
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
            if (txtSearchCatID.Text == "")
            {
                MessageBox.Show("Please Enter Category ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                searchClear();
                connection.Open();
                String cmd = "Select * FROM tbl_Category WHERE CategoryID='" + txtSearchCatID.Text + "';";
                
                SqlCommand command = new SqlCommand(cmd, connection);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvCatUpdate.DataSource = null;
                dgvCatUpdate.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);

                dgvCatUpdate.ReadOnly = true;
                dgvCatUpdate.DataSource = ds.Tables[0];
                connection.Close();
            }
        }
        private void searchClear()
        {
            txtCatName.ResetText();
            txtCatID.ResetText();
            txtCatDesc.ResetText();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtCatID.ReadOnly = true;
        }
    }
}
