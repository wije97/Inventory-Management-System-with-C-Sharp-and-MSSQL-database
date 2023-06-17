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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            ManageStaff form1 = new ManageStaff();
            form1.Show();
        }

        private void btnManageItem_Click(object sender, EventArgs e)
        {
            ManageItem form2 = new ManageItem();
            form2.Show();
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            ManageCategory form3 = new ManageCategory();
            form3.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AdminLogin form4 = new AdminLogin();
            form4.Show();
            this.Hide();
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            ViewStock form5 = new ViewStock();
            form5.Show();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            AdminManageOrders form6 = new AdminManageOrders();
            form6.Show();
            this.Hide();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            AdminGenerateReport form7 = new AdminGenerateReport();
            form7.Show();
            this.Hide();
        }
    }
}
