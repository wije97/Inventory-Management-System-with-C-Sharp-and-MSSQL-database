using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
    public partial class AdminManageOrders : Form
    {
        public AdminManageOrders()
        {
            InitializeComponent();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddCustomer form1 = new AddCustomer();
            form1.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard form2 = new AdminDashboard();
            form2.Show();
            this.Hide();
        }

        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            ViewCustomer form4 = new ViewCustomer();
            form4.Show();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            ViewOrder form5 = new ViewOrder();
            form5.Show();
        }
    }
}
