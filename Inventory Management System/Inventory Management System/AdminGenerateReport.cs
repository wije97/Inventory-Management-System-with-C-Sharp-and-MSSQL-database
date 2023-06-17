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
    public partial class AdminGenerateReport : Form
    {
        SqlConnection connection;

        public AdminGenerateReport()
        {
            InitializeComponent();

            DBConnection dbCon = new DBConnection();
            connection = dbCon.getConnection();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard form4 = new AdminDashboard();
            form4.Show();
            this.Hide();
        }

        private void AdminGenerateReport_Load(object sender, EventArgs e)
        {
            getMonths();
            getMostDemandItem();
            getLeastDemandItem();
        }

        private void getMonths()
        {
            try
            {
                string Sql = "SELECT DISTINCT tbl_Month.MonthName FROM tbl_Order INNER JOIN tbl_Month ON MONTH(tbl_Order.O_Date)=tbl_Month.MonthID";

                connection.Open();
                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cmbMonths.Items.Add(DR[0]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    cmd = "Select tbl_Order.OrderID, tbl_Order.O_Total, tbl_Order.O_Date FROM tbl_Order  WHERE MONTH(tbl_Order.O_Date)= ( SELECT MonthID FROM tbl_Month WHERE MonthName = '" + value + "' );";

                }
                else
                {
                    cmd = "Select tbl_Order.OrderID, tbl_Order.O_Total, tbl_Order.O_Date FROM tbl_Order WHERE O_Date='" + dtpDays.Text + "';";

                }

                SqlCommand command = new SqlCommand(cmd, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dgvOrder.DataSource = null;
                dgvOrder.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvOrder.ReadOnly = true;
                dgvOrder.DataSource = ds.Tables[0];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvOrder.Rows[e.RowIndex];

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

            String cmd = "Select tbl_Order_Item.ItID, tbl_Item.I_Name, tbl_Item.I_Price, tbl_Order_Item.OI_Qty, tbl_Item.I_Stock AS InStock FROM tbl_Order_Item INNER JOIN tbl_Item ON tbl_Order_Item.ItID = tbl_Item.ItemID WHERE tbl_Order_Item.OID = '" + orderID + "';";

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

        private void btnSearchByMonth_Click(object sender, EventArgs e)
        {
            if (cmbMonths.Text == "")
            {
                MessageBox.Show("Please Select Month!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    getDataBySearch(1, cmbMonths.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSeachByDate_Click(object sender, EventArgs e)
        {
            if (dtpDays.Text == "")
            {
                MessageBox.Show("Please Select Month!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    getDataBySearch(2, cmbMonths.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbMonths.Text = "";
            dtpDays.ResetText();
            dgvOrder.DataSource = null;
            dgvOrderItems.DataSource = null;
        }

        private void getMostDemandItem()
        {
            try
            {
                connection.Open();

                string Sql = "SELECT  ItemID, I_Name, I_Price FROM tbl_Item WHERE I_TotalSold = (SELECT MAX(I_TotalSold) FROM tbl_Item);";

                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txtIDMax.Text = DR[0].ToString();
                    txtNameMax.Text = DR[1].ToString();
                    txtPriceMax.Text = DR[2].ToString();
                }
                DR.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getLeastDemandItem()
        {
            try
            {
                connection.Open();

                string Sql = "SELECT  ItemID, I_Name, I_Price FROM tbl_Item WHERE I_TotalSold = (SELECT MIN(I_TotalSold) FROM tbl_Item);";

                SqlCommand cmd = new SqlCommand(Sql, connection);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txtIDMin.Text = DR[0].ToString();
                    txtNameMin.Text = DR[1].ToString();
                    txtPriceMin.Text = DR[2].ToString();
                }
                DR.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
