﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class SR_Cart1 : Form
    {
        private DataAccess Da { set; get; }
        public SR_Cart1()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            ShowAutoProduct();
            ShowBuyProduct();
            autoGeneratedInvoice();
        }

        private void ShowBuyProduct()
        {
            try
            {
                string query = "select * from BuyProduct;";
                var ds = this.Da.ExecuteQuery(query);
                this.dgvShowBuyProduct.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error : " + exc);
            }
        }


        // Show Data for ComboBox
        private void ShowAutoProduct()
        {
            try
            {
                string query = "select * from stock;";
                var ds = this.Da.ExecuteQuery(query);
                this.cmbProductName.DataSource = ds.Tables[0];
                this.cmbProductName.DisplayMember = "ProductName";
                this.cmbProductName.ValueMember = "ProductId";
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void ShowTotalBillAmmount()
        {
            try
            {
                this.txtTotolBillAmmount.Text = "0";
                int i = 0;
                while(i < dgvShowBuyProduct.Rows.Count)
                {
                    this.txtTotolBillAmmount.Text = Convert.ToString(double.Parse(txtTotolBillAmmount.Text) + double.Parse(dgvShowBuyProduct.Rows[i].Cells[3].Value.ToString()));
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void Clear()
        {
            this.cmbProductName.Text = string.Empty;
            this.nuStock.Value = 0;
            this.txtPrice.Clear();
            this.nuQuantity.Value = 0;
            this.txtTotal.Clear();
        }
        

        private void AllClear()
        {
            this.txtInvoiceNo.Clear();
            this.dtpDate.Value = DateTime.Now;
            this.txtCustomerName.Clear();
            this.txtContractNo.Clear();
            this.cmbProductName.Text = string.Empty;
            this.nuStock.Value = 0;
            this.txtPrice.Clear();
            this.nuQuantity.Value = 0;
            this.txtTotal.Clear();
            this.txtTotolBillAmmount.Clear();
            this.txtDiscount.Clear();
            this.txtLastTotal.Clear();
            this.cmbPaymentBy.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AllClear();
            ShowBuyProduct();
            autoGeneratedInvoice();
        }
        private void autoGeneratedInvoice() 
        {
            string query = "select InvoiceNo from SellsReport order by InvoiceNo desc;";
            var dt = this.Da.ExecuteQueryTable(query);
            string oldId = dt.Rows[0][0].ToString();
            string[] s = oldId.Split('-');
            int temp = Convert.ToInt32(s[1]);
            string newId = "in-"+(++temp).ToString();
            this.txtInvoiceNo.Text = newId;

        }

        private void nuQuantity_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "select Quantity from Stock where ProductName = '"+this.cmbProductName.Text+"';";
                var dt = this.Da.ExecuteQueryTable(query);
                string temp = dt.Rows[0][0].ToString();
                int quantity = Convert.ToInt32(temp);
                this.nuStock.Value = quantity - this.nuQuantity.Value;

                double a = Convert.ToDouble(this.txtPrice.Text);
                double b = Convert.ToDouble(this.nuQuantity.Value);
                double calculation = a * b;

                this.txtTotal.Text = calculation.ToString();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void txtDiscount_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                double TotalBillAmmount = double.Parse(this.txtTotolBillAmmount.Text);
                double Discount = double.Parse(this.txtDiscount.Text);
                double Total = TotalBillAmmount - Discount;

                this.txtLastTotal.Text = Total.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

       

    private void txtTotolBillAmmount_TextChanged(object sender, EventArgs e)
        {
            this.txtLastTotal.Text = this.txtTotolBillAmmount.Text;
           
        }

        private void btnAddToSellReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpDate.Text == "" || this.txtInvoiceNo.Text == "" || this.txtCustomerName.Text == "" || this.txtContractNo.Text == "" || this.txtTotolBillAmmount.Text==""|| this.txtLastTotal.Text=="" || this.cmbPaymentBy.Text=="")
                {
                    MessageBox.Show("No found Data !");
                }
                else
                {
                    string query = $"insert into SellsReport (Date,InvoiceNo,CustomerName,ContractNo,TotalBillAmmount,Discount,Total,PaymentBy) values ('{this.dtpDate.Text}','{this.txtInvoiceNo.Text}','{this.txtCustomerName.Text}','{this.txtContractNo.Text}','{this.txtTotolBillAmmount.Text}','{this.txtDiscount.Text}','{this.txtLastTotal.Text}','{cmbPaymentBy.Text}');";
                    var i = this.Da.ExecuteDMLQuery(query);
                    if (i != 0)
                    {
                        MessageBox.Show("New Sells Report added successfully!");
                        autoGeneratedInvoice();
                        AllClear();
                    }
                    else MessageBox.Show("New Sells Report  wasn't added successfully!");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured : " + exc.Message);
            }
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = $"select * from Stock where ProductName = '{this.cmbProductName.Text}';";
                int i = this.Da.ExecuteDMLQuery(query);

                if(i != 0)
                {
                    var reader = this.Da.ExecuteSqlReader(query);
                    if (reader.Read())
                    {
                        string Pprice, Pquantity;

                        Pprice = reader["Price"].ToString();
                        Pquantity = reader["Quantity"].ToString();
                        this.txtPrice.Text = Pprice;
                        this.nuStock.Text = Pquantity;
                    }
                    reader.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if(this.cmbProductName.Text=="" || this.nuStock.Value==0 || this.txtPrice.Text=="" || this.nuQuantity.Value==0 || this.txtTotal.Text == "")
                {
                    MessageBox.Show("Not Found Data properly!");
                }
                else
                {
                    string query2 = "select ProductName from BuyProduct;";
                    var reader = this.Da.ExecuteSqlReader(query2);
                    List<string> productNames = new List<string>();
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        productNames.Add(name);
                    }
                    reader.Close();
                    if (productNames.Contains(this.cmbProductName.Text))
                    {
                        string query4 = "select Quantity,Total from BuyProduct where ProductName = '"+this.cmbProductName.Text+"';";
                        var reader1 = this.Da.ExecuteSqlReader(query4);
                        int qt = 0;
                        decimal ttl = 0;
                        while (reader1.Read()) 
                        {
                            qt = reader1.GetInt32(0);
                            ttl = reader1.GetDecimal(1);
                        }
                        reader1.Close();
                        int quantity = qt + Convert.ToInt32(this.nuQuantity.Value);
                        decimal total = ttl + Convert.ToDecimal(this.txtTotal.Text);

                        string query3 = "update BuyProduct set Quantity = "+Convert.ToString(quantity)+", Total = "+Convert.ToString(total)+" where ProductName = '"+this.cmbProductName.Text+"';";
                        var m = this.Da.ExecuteDMLQuery(query3);
                        ShowBuyProduct();
                        updateStock();
                    }
                    else if(!productNames.Contains(this.cmbProductName.Text))
                    {
                        string query = $"insert into BuyProduct (ProductName,Price,Quantity,Total) values ('{this.cmbProductName.Text}','{this.txtPrice.Text}','{this.nuQuantity.Text}','{this.txtTotal.Text}');";
                        var i = this.Da.ExecuteDMLQuery(query);
                        if (i != 0)
                        {
                            MessageBox.Show("Added successfully!");
                            ShowBuyProduct();
                            updateStock();
                            Clear();
                        }
                        else

                            MessageBox.Show("Wasn't added successfully!");
                    }
                    string query1 = "update Stock set Quantity = '"+this.nuStock.Value+"' where ProductName = '"+this.cmbProductName.Text+"';";
                    var j = this.Da.ExecuteDMLQuery(query1);
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }

            // Show Total : 
            ShowTotalBillAmmount();
          
        }
        private void updateStock() 
        {
            string query = "select Quantity from BuyProduct where ProductName = '"+this.cmbProductName.Text+"';";
            var reader = this.Da.ExecuteSqlReader(query);
            int quantity = 0;
            while (reader.Read())
                quantity = reader.GetInt32(0);
            reader.Close();
            string query1 = "select Quantity from Stock where ProductName = '"+this.cmbProductName.Text+"';";
            var reader1 = this.Da.ExecuteSqlReader(query1);
            int quantity1 = 0;
            while(reader1.Read())
                quantity1 = reader1.GetInt32(0);
            reader1.Close();
            int newQuantity = quantity1 - quantity;
            string query2 = "update Stock set Quantity = "+Convert.ToString(newQuantity)+" where ProductName = '"+this.cmbProductName.Text+"';";
            var i = this.Da.ExecuteDMLQuery(query2);;
        }
        private void btnClearField_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRemoveCart_Click(object sender, EventArgs e)
        {
            try
            { 
                int index = this.dgvShowBuyProduct.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvShowBuyProduct.Rows[index];

                string selectedProductName = row.Cells["ProductName"].Value.ToString();
                var query1 = "select Quantity from BuyProduct where ProductName = '"+selectedProductName+"';";
                var reader = this.Da.ExecuteSqlReader(query1);
                int quantity = 0;
                while (reader.Read())
                    quantity = reader.GetInt32(0);
                reader.Close();
                var query2 = "update Stock set Quantity = "+Convert.ToString(Convert.ToInt32(this.nuStock.Value) + quantity)+" where ProductName = '"+selectedProductName+"';";
                var j = this.Da.ExecuteDMLQuery(query2);
                var query = $"delete from BuyProduct where ProductName = '{selectedProductName}';";
                var i = this.Da.ExecuteDMLQuery(query);
                if (i != 0)
                {
                    ShowBuyProduct();
                }
                else
                {
                    MessageBox.Show("Data  wasn't deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Delete " + ex);
            }
        }
    }
}