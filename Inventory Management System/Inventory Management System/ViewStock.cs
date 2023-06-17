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
    public partial class ViewStock : Form
    {
        SqlConnection connection;

        public ViewStock()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void ViewStock_Load(object sender, EventArgs e)
        {
            loadAvailableStockData();
            loadOutofStockData();
        }

        private void loadAvailableStockData()
        {
            try
            {
                connection.Open();

                String cmd = "Select tbl_Item.ItemID, tbl_Item.I_Name, tbl_Category.Cat_Name, tbl_Item.I_Stock ,tbl_Item.I_Price  FROM tbl_Item INNER JOIN tbl_Category ON tbl_Item.I_CatID=tbl_Category.CategoryID WHERE tbl_Item.I_Stock != 0;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvAvailable.DataSource = null;
                dgvAvailable.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvAvailable.ReadOnly = true;
                dgvAvailable.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadOutofStockData()
        {
            try
            {
                connection.Open();

                String cmd = "Select tbl_Item.ItemID, tbl_Item.I_Name, tbl_Category.Cat_Name, tbl_Item.I_Stock ,tbl_Item.I_Price  FROM tbl_Item INNER JOIN tbl_Category ON tbl_Item.I_CatID=tbl_Category.CategoryID WHERE tbl_Item.I_Stock= 0;";

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvOutOfStock.DataSource = null;
                dgvOutOfStock.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvOutOfStock.ReadOnly = true;
                dgvOutOfStock.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
