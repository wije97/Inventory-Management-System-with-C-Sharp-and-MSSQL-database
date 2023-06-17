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
    public partial class AddOrder : Form
    {
        SqlConnection connection;
        double itemPrice;
        int itemQty, totalSold;

        public AddOrder()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            loadCategories();
            lblDate.Text = (DateTime.Now.ToString("yyyy/M/d"));
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

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmbItemName.Text = "";
                string Sql = "SELECT DISTINCT tbl_Item.I_Name FROM tbl_Item INNER JOIN dbo.tbl_Category ON tbl_Item.I_CatID = (SELECT CategoryID From tbl_Category WHERE Cat_Name= '" + cmbCategory.Text +  "')";

                connection.Open();
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();
                cmbItemName.Items.Clear();
                while (DR.Read())
                {
                    cmbItemName.Items.Add(DR[0]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string Sql = "SELECT ItemID, I_Price, I_Stock FROM dbo.tbl_Item WHERE I_Name='" + cmbItemName.Text + "'";

                connection.Open();
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txtItemID.Text = DR[0].ToString();
                    itemPrice = double.Parse(DR[1].ToString());
                    itemQty = Convert.ToInt32(DR[2].ToString());
                    lblInStock.Text = itemQty.ToString() + " In Stock";

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AddCustomer form1 = new AddCustomer();
            form1.Show();
            this.Hide();
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            if ( cmbCategory.Text == "" || cmbItemName.Text== "" || txtQuantity.Text== "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if(Int32.Parse(txtQuantity.Text) > 0)
                    {
                        if(Int32.Parse(txtQuantity.Text) <= itemQty)
                        {
                            dgvCart.Rows.Add(cmbItemName.Text, txtItemID.Text, itemPrice, txtQuantity.Text);
                            totalPrice();
                            txtQuantity.ResetText();
                            cmbCategory.Text = "";
                            cmbItemName.Text = "";
                            txtItemID.ResetText();
                            lblInStock.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Only " + itemQty + " peices Available!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid Quantity!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void totalPrice()
        {
            try
            {
                int counter;
                double balance = 0;
                int quantity;
                double price;

                for (counter = 0; counter < (dgvCart.Rows.Count - 1); counter++)
                {
                    quantity = 0;
                    price = 0;

                    if (dgvCart.Rows[counter].Cells["Quantity"].Value.ToString().Length != 0)
                    {
                        quantity = int.Parse(dgvCart.Rows[counter].Cells["Quantity"].Value.ToString());
                    }

                    if (dgvCart.Rows[counter].Cells["Price"].Value.ToString().Length != 0)
                    {
                        price = double.Parse(dgvCart.Rows[counter].Cells["Price"].Value.ToString());
                    }

                    double subT = quantity * price;

                    balance += subT;
                    txtTotalPrice.Text = (balance).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCart.Rows.Count > 1 && dgvCart.Rows != null)
                {
                    int rowIndex = dgvCart.CurrentCell.RowIndex;
                    dgvCart.Rows.RemoveAt(rowIndex);
                    txtTotalPrice.Text = "00.00";
                    totalPrice();
                }
                else
                {
                    MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            txtQuantity.ResetText();
            txtTotalPrice.Text = "00.00";
            cmbCategory.Text = "";
            cmbItemName.Text = "";
            txtItemID.ResetText();
            dgvCart.Rows.Clear();
            lblInStock.Text = "";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (txtTotalPrice.Text == "00.00" )
            {
                MessageBox.Show("Please add Items to Cart before Place Order!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    insertData();
                    clear();
                    txtNote.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void insertData()
        {
            try
            {
                String note;
                if(txtNote.Text == "")
                {
                    note = "None";
                }
                else
                {
                    note = txtNote.Text;
                }

                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO  dbo.[tbl_Order](O_Total,O_Note,O_Date,O_Cus_NIC) " + " VALUES ('" + txtTotalPrice.Text + "','" + note + "','" + lblDate.Text + "','" + txtCusNICOrder.Text + "') SELECT SCOPE_IDENTITY()", connection);

                int oid = Convert.ToInt32(command.ExecuteScalar());

                if (oid != 0)
                {
                    connection.Close();
                    insertOrderItemsData(oid);
                    //MessageBox.Show("Order Saved");
                }
                else
                {
                    connection.Close();
                    MessageBox.Show("Order not Saved", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertOrderItemsData(int orderID)
        {
            try
            {
                
                for (int r = 0; r < dgvCart.Rows.Count; r++)
                {
                    if (dgvCart.Rows[r].Cells["ItemID"].Value != null)
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO  dbo.[tbl_Order_Item](OID,ItID,OI_Qty) " + " VALUES ('" + orderID + "','" + dgvCart.Rows[r].Cells["ItemID"].Value +  "','" + dgvCart.Rows[r].Cells["Quantity"].Value +  "')", connection);
                        int i = command.ExecuteNonQuery();

                        if (i != 0)
                        {
                            connection.Close();
                            updateStock(dgvCart.Rows[r].Cells["ItemID"].Value.ToString(), dgvCart.Rows[r].Cells["Quantity"].Value.ToString());
                        }
                        else
                        {
                            connection.Close();
                            MessageBox.Show("Item not Saved", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        connection.Close();
                    }

                }
                MessageBox.Show("Order Placed ", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            clear();
            txtNote.ResetText();
        }

        private void updateStock(String itemID, String itemQuantity)
        {
            try
            {
                string Sql = "SELECT  I_Stock,  I_TotalSold FROM dbo.tbl_Item WHERE ItemID='" + itemID + "'";
                int availableQty=0;
                int totalSoldQty=0;

                connection.Open();
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    availableQty = Convert.ToInt32(DR[0].ToString());
                    totalSoldQty = Convert.ToInt32(DR[1].ToString());
                }
                connection.Close();

                connection.Open();

                int stock = availableQty - Convert.ToInt32(itemQuantity);
                totalSold = totalSoldQty + Convert.ToInt32(itemQuantity);

                String cmd2 = "UPDATE dbo.[tbl_Item] SET I_Stock='" + stock + "', I_TotalSold = '" + totalSold + "' WHERE ItemID='" + itemID + "';";

                SqlCommand command2 = new SqlCommand(cmd2, connection);

                int i = command2.ExecuteNonQuery();

                if (i != 0)
                {
                    connection.Close();
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
