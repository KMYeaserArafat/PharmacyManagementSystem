using System;
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
    public partial class SR_CustomerInformation : Form
    {

        private DataAccess Da { set; get; }
        public SR_CustomerInformation()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            ShowCustomerData();
            AutoGenerateCustomerId();
            btnUpdate.Visible = false;
        }

        private void AutoGenerateCustomerId()
        {
            try
            {
                string query = "select CustomerId from CustomerInformation order by CustomerId desc;";
                var dt = this.Da.ExecuteQueryTable(query);
                string oldId = dt.Rows[0][0].ToString();
                string[] s = oldId.Split('-');
                int temp = Convert.ToInt32(s[1]);
                string newId = "Customer-" + (++temp).ToString();
                this.txtCustomerId.Text = newId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Auto GenerateID Error : " + ex);
            }
        }

        private void ShowCustomerData()
        {
            try
            {
                string query = "select * from CustomerInformation;";
                var ds = this.Da.ExecuteQuery(query);
                this.dgvCustomerInfo.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void ClearField()
        {
            this.txtCustomerId.Clear();
            this.txtCustomerName.Clear();
            this.nudCustomerAge.Value = 0;
            this.cmbCustomerType.Text = string.Empty;
            this.txtAddress.Clear();
            this.txtContractNo.Clear();
            this.txtSearchCustomerId.Clear();
            this.txtfindCustomerName.Clear();
            AutoGenerateCustomerId();
            btnUpdate.Visible = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCustomerId.Text == "" || this.txtCustomerName.Text == "" || this.nudCustomerAge.Value == 0 || this.cmbCustomerType.Text == string.Empty || this.txtAddress.Text == "" || this.txtContractNo.Text == "")
                {
                    MessageBox.Show("No found Data !");
                }
                else
                {
                    string query = $"insert into CustomerInformation (CustomerId,CustomerName,CustomerAge,CustomerType,Address,ContractNo) values ('{this.txtCustomerId.Text}','{this.txtCustomerName.Text}','{this.nudCustomerAge.Text}','{this.cmbCustomerType.Text}','{this.txtAddress.Text}','{this.txtContractNo.Text}');";
                    var i = this.Da.ExecuteDMLQuery(query);
                    if (i != 0)
                    {
                        MessageBox.Show("New Customer added successfully!");
                        ClearField();
                        ShowCustomerData();

                    }
                    else MessageBox.Show("New Customer wasn't added successfully!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowCustomerData();
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dgvCustomerInfo.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvCustomerInfo.Rows[index];
                string selectedCustomerId = row.Cells["CustomerId"].Value.ToString();
                string selectedCustomerName = row.Cells["CustomerName"].Value.ToString();

                var query = $"delete from CustomerInformation where CustomerId = '{selectedCustomerId}' and CustomerName = '{selectedCustomerName}';";
                var i = this.Da.ExecuteDMLQuery(query);
                if (i != 0)
                {
                    MessageBox.Show( selectedCustomerName + "Data Deleted successfully!");
                    ShowCustomerData();
                }
                else
                {
                    MessageBox.Show(selectedCustomerName + "Data  wasn't deleted successfully!");
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
                string searchText = this.txtSearchCustomerId.Text;
                string query = string.Format("select * from CustomerInformation where (customerId like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvCustomerInfo.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void txtfindCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtfindCustomerName.Text;
                string query = string.Format("select * from CustomerInforamtion where (customerName like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvCustomerInfo.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            try
            {
                int index = this.dgvCustomerInfo.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    DataGridViewRow row = this.dgvCustomerInfo.Rows[index];

                    this.txtCustomerId.Text = row.Cells["CustomerId"].Value.ToString();
                    this.txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                    this.nudCustomerAge.Text = row.Cells["CustomerAge"].Value.ToString();
                    this.cmbCustomerType.Text = row.Cells["CustomerType"].Value.ToString();
                    this.txtAddress.Text = row.Cells["Address"].Value.ToString();
                    this.txtContractNo.Text = row.Cells["ContractNo"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            try
            {
                var sql = @"update CustomerInformation
                                set CustomerName = '" + this.txtCustomerName.Text + @"',
                                CustomerAge = '" + this.nudCustomerAge.Text + @"',
                                CustomerType = '" + this.cmbCustomerType.Text + @"',
                                Address = '" + this.txtAddress.Text + @"',
                                ContractNo = '" + this.txtContractNo.Text + @"'
                                where CustomerId = '" + this.txtCustomerId.Text + "'; ";
                int count = this.Da.ExecuteDMLQuery(sql);
                MessageBox.Show("Data Update SuccessFully");
                ClearField();
                ShowCustomerData();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }
    }
}
