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
    public partial class SR_SellReport : Form
    {
        private DataAccess Da { set; get; }
        public SR_SellReport()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            ShowSellsData();
        }

        private void ShowSellsData()
        {
            try
            {
                string query = "select * from SellsReport;";
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowSellsReport.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void Erease()
        {
            this.txtInvoiceNo.Clear();
            this.txtSearchCustomerName.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowSellsData();
            Erease();
        }

        private void btnEraseBox_Click(object sender, EventArgs e)
        {
            Erease();
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dgvShowSellsReport.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvShowSellsReport.Rows[index];

                string selectedInvoiceNo = row.Cells["InvoiceNo"].Value.ToString();
                

                var query = $"delete from SellsReport where InvoiceNo = '{selectedInvoiceNo}';";
                var i = this.Da.ExecuteDMLQuery(query);
                if (i != 0)
                {
                    MessageBox.Show(selectedInvoiceNo + " Data Deleted successfully!");
                    ShowSellsData();
                }
                else
                {
                    MessageBox.Show(selectedInvoiceNo + " Data  wasn't deleted successfully!");
                    ShowSellsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Delete " + ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtInvoiceNo.Text;
                string query = string.Format("select * from SellsReport where (InvoiceId like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowSellsReport.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void txtSearchCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtSearchCustomerName.Text;
                string query = string.Format("select * from SellsReport where (CustomerName like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowSellsReport.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }
    }
}
