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
    public partial class ViewOrder : Form
    {
        SqlConnection connection;

        public ViewOrder()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void ViewOrder_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            try
            {
                connection.Open();

                String cmd = "Select tbl_Order.OrderID, tbl_Order.O_Total, tbl_Order.O_Date, tbl_Order.O_Cus_NIC, tbl_Customer.Cus_Name,  tbl_Customer.Cus_Phone FROM tbl_Order INNER JOIN tbl_Customer ON tbl_Order.O_Cus_NIC = tbl_Customer.Customer_NIC;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvOrders.DataSource = null;
                dgvOrders.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvOrders.ReadOnly = true;
                dgvOrders.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvOrders.Rows[e.RowIndex];

                    String oID = row.Cells[0].Value.ToString();
                    getItemsInOrder(oID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getItemsInOrder(String orderID)
        {
            connection.Open();

            String cmd = "Select tbl_Order_Item.ItID, tbl_Item.I_Name, tbl_Item.I_Price, tbl_Order_Item.OI_Qty FROM tbl_Order_Item INNER JOIN tbl_Item ON tbl_Order_Item.ItID = tbl_Item.ItemID WHERE tbl_Order_Item.OID = '" + orderID +  "';";

            SqlCommand command = new SqlCommand(cmd, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            dgvOrderItems.DataSource = null;
            dgvOrderItems.Rows.Clear();

            SqlDataAdapter dAdapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dAdapter.Fill(ds);
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadData();
            txtOrderID.ResetText();
            txtSearchCNIC.ResetText();
            dgvOrderItems.DataSource = null;
        }

        private void btnSearchOID_Click(object sender, EventArgs e)
        {
            txtSearchCNIC.Text = "";
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please Enter Order ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    getDataBySearch(1, txtOrderID.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void getDataBySearch(int type, String value)
        {
            try
            {
                connection.Open();
                String cmd;
                if (type == 1)
                {
                    cmd = "Select tbl_Order.OrderID, tbl_Order.O_Total, tbl_Order.O_Date, tbl_Order.O_Cus_NIC, tbl_Customer.Cus_Name,  tbl_Customer.Cus_Phone FROM tbl_Order INNER JOIN tbl_Customer ON tbl_Order.O_Cus_NIC = tbl_Customer.Customer_NIC WHERE OrderID='" + value + "';";

                }
                else
                {
                    cmd = "Select tbl_Order.OrderID, tbl_Order.O_Total, tbl_Order.O_Date, tbl_Order.O_Cus_NIC, tbl_Customer.Cus_Name,  tbl_Customer.Cus_Phone FROM tbl_Order INNER JOIN tbl_Customer ON tbl_Order.O_Cus_NIC = tbl_Customer.Customer_NIC WHERE O_Cus_NIC='" + value + "';";

                }

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvOrders.DataSource = null;
                dgvOrders.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvOrders.ReadOnly = true;
                dgvOrders.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeachCNIC_Click(object sender, EventArgs e)
        {
            txtOrderID.Text = "";
            if (txtSearchCNIC.Text == "")
            {
                MessageBox.Show("Please Enter Order ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    getDataBySearch(2, txtSearchCNIC.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
