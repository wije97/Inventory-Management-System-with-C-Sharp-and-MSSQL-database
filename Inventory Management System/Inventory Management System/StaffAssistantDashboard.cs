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
    public partial class StaffAssistantDashboard : Form
    {
        public StaffAssistantDashboard()
        {
            InitializeComponent();
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            ManageCategory form1 = new ManageCategory();
            form1.Show();
        }

        private void btnManageItem_Click(object sender, EventArgs e)
        {
            ManageItem form2 = new ManageItem();
            form2.Show();
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            ViewStock form3 = new ViewStock();
            form3.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            StaffLogin form4 = new StaffLogin();
            form4.Show();
            this.Hide();
        }
    }
}
