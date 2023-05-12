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
    public partial class SellerPortal : Form
    {
        public SellerPortal()
        {
            InitializeComponent();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
          SR_Stock stock  = new SR_Stock();
            stock.TopLevel = false;
            pnlShowSeller.Controls.Add(stock);
            stock.BringToFront();
            stock.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SR_Home home = new SR_Home();
            home.TopLevel = false;
            pnlShowSeller.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
           SR_CustomerInformation customerInformation = new SR_CustomerInformation();
            customerInformation.TopLevel = false;
            pnlShowSeller.Controls.Add(customerInformation);
            customerInformation.BringToFront();
            customerInformation.Show();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            /*SR_Cart cart = new SR_Cart();
            cart.TopLevel = false;
            pnlShowSeller.Controls.Add(cart);
            cart.BringToFront();
            cart.Show();*/

            SR_Cart1 cart = new SR_Cart1();
            cart.TopLevel = false;
            pnlShowSeller.Controls.Add(cart);
            cart.BringToFront();
            cart.Show();
        }

        private void btnSellsReport_Click(object sender, EventArgs e)
        {
            SR_SellReport sellReport = new SR_SellReport();
            sellReport.TopLevel = false;
            pnlShowSeller.Controls.Add(sellReport);
            sellReport.BringToFront();
            sellReport.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var d = MessageBox.Show("Are you Sure to logout ?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
