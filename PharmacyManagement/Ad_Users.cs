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
    public partial class Ad_Users : Form
    {
        private DataAccess Da { set; get; }
        public Ad_Users()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            ShowUsers();
        }

        private void ShowUsers()
        {
            try
            {
                string query = "select * from Users;";
                var ds = this.Da.ExecuteQuery(query);
                this.dgvUserInformation.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show(" " + exc);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserName.Clear();
            this.txtUserId.Clear();
            this.txtUserPassword.Clear();
            this.txtSearchBox.Clear();
            this.cmbUserType.Text = string.Empty;
            ShowUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
           
                try
                {
                if (this.txtUserName.Text == "" || this.txtUserId.Text == "" || this.cmbUserType.Text == "" || this.txtUserPassword.Text == "")
                {
                    MessageBox.Show("No found Data !");
                }
                else
                {
                    string query = $"insert into Users (UserName,UserId,UserType,UserPassword) values ('{this.txtUserName.Text}','{this.txtUserId.Text}','{this.cmbUserType.Text}','{this.txtUserPassword.Text}');";
                    var i = this.Da.ExecuteDMLQuery(query);
                    if (i != 0)
                    {
                        MessageBox.Show("New User added successfully!");
                        this.txtUserName.Clear();
                        this.txtUserId.Clear();
                        this.txtUserPassword.Clear();
                        this.txtSearchBox.Clear();
                        this.cmbUserType.Text = string.Empty;
                        ShowUsers();
                    }
                    else MessageBox.Show("New User wasn't added successfully!");
                }
          
                }
                catch (Exception exc)
                {
                    MessageBox.Show("An error has occured : " + exc.Message);
                } 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dgvUserInformation.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvUserInformation.Rows[index];
                string selectedUserName = row.Cells["UserName"].Value.ToString();
                string SelectedUserType = row.Cells["UserType"].Value.ToString();
                string selecteUserId = row.Cells["UserId"].Value.ToString();
                string SelectedUserPassword = row.Cells["UserPassword"].Value.ToString();

                var query = $"delete from Users where UserName = '{selectedUserName}' and UserId = '{selecteUserId}' and UserType = '{SelectedUserType}' and UserId = '{selecteUserId}'and UserPassword = '{SelectedUserPassword}';";
                var i = this.Da.ExecuteDMLQuery(query);
                if (i != 0)
                {
                    MessageBox.Show("Data Deleted successfully!");
                    ShowUsers();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = this.txtSearchBox.Text;
                string query = string.Format("select * from Users where (UserId like '%{0}%');", searchText);
                var ds = this.Da.ExecuteQuery(query);
                this.dgvUserInformation.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
            
        }
    }
}
