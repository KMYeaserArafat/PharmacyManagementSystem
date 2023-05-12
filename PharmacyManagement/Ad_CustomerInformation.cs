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
    public partial class Ad_CustomerInformation : Form
    {
        private DataAccess Da { set; get; }
        public Ad_CustomerInformation()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            ShowCustomerData();
        }

        private void ShowCustomerData()
        {
            try
            {
                string query = "select * from CustomerInformation;";
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowCustomer.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowCustomerData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtSearchCustomerId.Text;
                string query = string.Format("select * from CustomerInformation where (CustomerId like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowCustomer.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void txtFindCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtFindCustomerName.Text;
                string query = string.Format("select * from CustomerInformation where (CustomerName like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowCustomer.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtFindCustomerName.Clear();
            this.txtSearchCustomerId.Clear();
        }
    }
}
