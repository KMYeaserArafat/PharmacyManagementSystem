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
    public partial class SR_Stock : Form
    {
        private DataAccess Da { set; get; }
        public SR_Stock()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            ShowStockData();
            TotalProduct();
            TotalPriceofProduct();
        }

        private void TotalProduct()
        {
            this.lblProduct.Text = "0";
            int i = 0;
            while (i < dgvShowStock.Rows.Count)
            {
                this.lblProduct.Text = Convert.ToString(double.Parse(lblProduct.Text) + double.Parse(dgvShowStock.Rows[i].Cells[4].Value.ToString()));
                i++;
            }
        }

        private void TotalPriceofProduct()
        {
            this.lblTotalPrice.Text = "0";
            int i = 0;
            while (i < dgvShowStock.Rows.Count)
            {
                this.lblTotalPrice.Text = Convert.ToString(double.Parse(lblTotalPrice.Text) + double.Parse(dgvShowStock.Rows[i].Cells[5].Value.ToString()));
                i++;
            }
        }

        private void ShowStockData()
        {
            try
            {
                string query = "select * from stock;";
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowStock.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowStockData();
            TotalProduct();
            TotalPriceofProduct();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtSearchId.Text;
                string query = string.Format("select * from Stock where (ProductId like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowStock.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void txtNameSuggest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtNameSuggest.Text;
                string query = string.Format("select * from Stock where (ProductName like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowStock.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNameSuggest.Clear();
            this.txtSearchId.Clear();
        }
    }
}
