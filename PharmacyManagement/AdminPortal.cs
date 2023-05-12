using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class AdminPortal : Form
    {
        public AdminPortal()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Ad_Home h = new Ad_Home();
            h.TopLevel = false;
            pnlDisplay.Controls.Add(h);
            h.BringToFront();
            h.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Ad_StaffInformation staffInfo = new Ad_StaffInformation();
            staffInfo.TopLevel = false;
            pnlDisplay.Controls.Add(staffInfo);
            staffInfo.BringToFront();
            staffInfo.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Ad_Users u = new Ad_Users();
            u.TopLevel = false;
            pnlDisplay.Controls.Add(u);
            u.BringToFront();
            u.Show();
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            Ad_CustomerInformation customerInfo = new Ad_CustomerInformation();
            customerInfo.TopLevel = false;
            pnlDisplay.Controls.Add(customerInfo);
            customerInfo.BringToFront();
            customerInfo.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Ad_Stock stock = new Ad_Stock();
            stock.TopLevel = false;
            pnlDisplay.Controls.Add(stock);
            stock.BringToFront();
            stock.Show();
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var d = MessageBox.Show("Are you Sure to logout ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
