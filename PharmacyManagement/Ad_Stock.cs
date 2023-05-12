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
    public partial class Ad_Stock : Form
    {
        private DataAccess Da { set; get; }
        public Ad_Stock()
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
            while(i < dgvShowStock.Rows.Count)
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

        private void ClearAllBox()
        {
            this.dtpDate.Value = DateTime.Now;
            this.txtProduceId.Clear();
            this.txtProducetName.Clear();
            this.txtBuyPrice.Clear();
            this.nuQuantity.Value = 0;
            this.txtTotalPrice.Clear();
            this.txtSearchId.Clear();
            this.txtFindProductName.Clear();
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

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dgvShowStock.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvShowStock.Rows[index];

                string selectedProductId = row.Cells["ProductId"].Value.ToString();
                string SelectedProductName = row.Cells["ProductName"].Value.ToString();
               
                var query = $"delete from stock where ProductId = '{selectedProductId}' and ProductName = '{SelectedProductName}';";
                var i = this.Da.ExecuteDMLQuery(query);
                if (i != 0)
                {
                    MessageBox.Show( SelectedProductName + " Data Deleted successfully!");
                    ShowStockData();
                    TotalProduct();
                    TotalPriceofProduct();
                }
                else
                {
                    MessageBox.Show(SelectedProductName +" Data  wasn't deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Delete " + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllBox();
            ShowStockData();
            TotalProduct();
            TotalPriceofProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtProduceId.Text=="" || this.txtProducetName.Text=="" || this.txtBuyPrice.Text=="" || this.nuQuantity.Value==0 ||this.txtTotalPrice.Text == "")
                {
                    MessageBox.Show("Data can't complete !");
                }
                else
                {
                    string query = $"insert into Stock (Date,ProductId,ProductName,Price,Quantity,TotalPrice) values ('{this.dtpDate.Text}','{this.txtProduceId.Text}','{this.txtProducetName.Text}','{this.txtBuyPrice.Text}','{this.nuQuantity.Value}','{this.txtTotalPrice.Text}');";
                    var i = this.Da.ExecuteDMLQuery(query);
                    if (i != 0)
                    {
                        MessageBox.Show("New Product added successfully!");
                        ShowStockData();
                        ClearAllBox();
                        TotalProduct();
                        TotalPriceofProduct();

                    }
                    else MessageBox.Show("New Product wasn't added successfully!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void nuQuantity_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(this.txtBuyPrice.Text);
                double b = Convert.ToDouble(this.nuQuantity.Text);
                double calculation = a * b;
                this.txtTotalPrice.Text = calculation.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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

        private void txtFindProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtFindProductName.Text;
                string query = string.Format("select * from Stock where (ProductName like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowStock.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvShowStock.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    DataGridViewRow row = dgvShowStock.Rows[index];

                    this.dtpDate.Text = row.Cells["Date"].Value.ToString();
                    this.txtProduceId.Text = row.Cells["ProductId"].Value.ToString();
                    this.txtProducetName.Text = row.Cells["ProductName"].Value.ToString();
                    this.txtBuyPrice.Text = row.Cells["Price"].Value.ToString();
                    this.nuQuantity.Text = row.Cells["Quantity"].Value.ToString();
                    this.txtTotalPrice.Text = row.Cells["Total"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = @"update Stock
                                set Date = '" + this.dtpDate.Text + @"',
                                ProductName = '" + this.txtProducetName.Text + @"',
                                Price = '" + this.txtBuyPrice.Text + @"',
                                Quantity = '" + this.nuQuantity.Text + @"',
                                TotalPrice = '" + this.txtTotalPrice.Text + @"'
                                where ProductId = '" + this.txtProduceId.Text + "'; ";
                int count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                {
                    MessageBox.Show("Data updated Properly");
                    ShowStockData();
                    TotalProduct();
                    TotalPriceofProduct();
                    ClearAllBox();
                }
                else
                    MessageBox.Show("Data upgradation failed");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

      
    }
}
