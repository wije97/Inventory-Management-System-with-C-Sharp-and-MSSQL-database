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
    public partial class ManageItem : Form
    {
        SqlConnection connection;
        String catID;

        public ManageItem()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void ManageItem_Load(object sender, EventArgs e)
        {
            loadCategories();
            loadData();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void loadCategories()
        {
            try
            {
                string Sql = "SELECT Cat_Name FROM dbo.tbl_Category";

                connection.Open();
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cmbCategory.Items.Add(DR[0]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text == "" || txtItemID.Text == "" || txtItemName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "" || cmbCategory.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "INSERT INTO  dbo.[tbl_Item](ItemID, I_Name, I_CatID, I_Desc, I_Price, I_Stock, I_TotalSold) " + " VALUES ('" + txtItemID.Text + "','" + txtItemName.Text + "','" + catID + "','" + txtDesc.Text + "','" + txtPrice.Text + "','" + txtQuantity.Text + "', 0)";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {

                        connection.Close();
                        clear();
                        MessageBox.Show("Added Successfully");
                       
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

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string Sql = "SELECT CategoryID FROM dbo.tbl_Category WHERE Cat_Name= '" + cmbCategory.Text + "';";

                connection.Open();
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    catID = DR[0].ToString();

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear()
        {
            txtDesc.ResetText();
            txtItemID.ResetText();
            txtItemName.ResetText();
            txtPrice.ResetText();
            txtQuantity.ResetText();
            txtSearchItID.ResetText();
            cmbCategory.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtItemID.ReadOnly = false;
            loadData();
        }

        private void loadData()
        {
            try
            {
                connection.Open();

                String cmd = "Select * FROM tbl_Item;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvItemUpdate.DataSource = null;
                dgvItemUpdate.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvItemUpdate.ReadOnly = true;
                dgvItemUpdate.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvItemUpdate_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                txtItemID.ReadOnly = true;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvItemUpdate.Rows[e.RowIndex];
                    txtItemID.Text = row.Cells[0].Value.ToString();
                    txtItemName.Text = row.Cells[1].Value.ToString();
                    catID = row.Cells[2].Value.ToString();
                    txtDesc.Text = row.Cells[3].Value.ToString();
                    txtPrice.Text = row.Cells[4].Value.ToString();
                    txtQuantity.Text = row.Cells[5].Value.ToString();
                    

                    

                }
                if (e.RowIndex >= 0)
                {
                    //searchCategorynameFromID();
                }
                   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text == "" || txtItemID.Text == "" || txtItemName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "" || cmbCategory.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    String cmd = "UPDATE dbo.[tbl_Item] SET I_Name='" + txtItemName.Text + "', I_CatID='" + catID + "', I_Desc='" + txtDesc.Text + "', I_Price='" + txtPrice.Text + "', I_Stock='" + txtQuantity.Text + "' WHERE ItemID='" + txtItemID.Text + "';";

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

        private void searchCategorynameFromID()
        {
            try
            {
                connection.Open();
                string Sql = "SELECT Cat_Name FROM dbo.tbl_Category WHERE CategoryID= '" + catID + "';";

                
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cmbCategory.Text = DR[0].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text == "")
            {
                MessageBox.Show("Please Select Item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "DELETE  FROM dbo.[tbl_Item] WHERE ItemID='" + txtItemID.Text + "';";

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchItID.Text == "")
            {
                MessageBox.Show("Please Enter Item ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                searchClear();
                connection.Open();
                String cmd = "Select * FROM tbl_Item WHERE ItemID='" + txtSearchItID.Text + "';";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvItemUpdate.DataSource = null;
                dgvItemUpdate.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvItemUpdate.ReadOnly = true;
                dgvItemUpdate.DataSource = ds.Tables[0];
                connection.Close();
            }
        }

        private void searchClear()
        {
            txtDesc.ResetText();
            txtItemID.ResetText();
            txtItemName.ResetText();
            txtPrice.ResetText();
            txtQuantity.ResetText();
            cmbCategory.Text = "";
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtItemID.ReadOnly = true;
        }
    }
}
