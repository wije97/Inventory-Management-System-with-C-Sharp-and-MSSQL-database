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
    public partial class CashierDashboard : Form
    {
        public CashierDashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            StaffLogin form1 = new StaffLogin();
            form1.Show();
            this.Hide();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddCustomer form2 = new AddCustomer();
            form2.Show();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            ViewOrder form3 = new ViewOrder();
            form3.Show();
        }

        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            ViewCustomer form4 = new ViewCustomer();
            form4.Show();
        }
    }
}
