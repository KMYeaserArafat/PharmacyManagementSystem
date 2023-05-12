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
    public partial class FormLogin : Form
    {
        private DataAccess Da { set; get; }
        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.txtUserId.Clear();
            this.txtPassword.Clear();

        }


       
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(cbShowPassword.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar =  true;
            }
        }

      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select username, UserType from users where userid = '" + this.txtUserId.Text + "' and userpassword = '" + this.txtPassword.Text + "';";
                int i = this.Da.ExecuteDMLQuery(query);
                if (i != 0)
                {
                   // MessageBox.Show("Successfully logged in!");
                    var reader = this.Da.ExecuteSqlReader(query);
                    string UserType = "";
                    string UserName = "";
                    while (reader.Read())
                    {
                        UserName = reader.GetString(0);
                        UserType = reader.GetString(1);
                    }
                    if (UserType == "Admin")
                    {
                        MessageBox.Show("Successfully open Admin Panel");
                        AdminPortal adminPortal = new AdminPortal();
                        adminPortal.Show();
                        adminPortal.FormClosed += logOut;
                        this.Hide();
                       
                        
                    }
                    else if (UserType == "Seller")
                    {
                        MessageBox.Show("Successfully open Seller Panel");
                        SellerPortal sellerPortal = new SellerPortal();
                        sellerPortal.Show();
                        sellerPortal.FormClosed += logOut;
                        this.Hide();
                     
                    }
                    else
                    {
                        MessageBox.Show("User Name or Password is invalid");
                    }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("username or password is incorrect!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            
        }

        private void logOut(object sender,EventArgs e)
        {
            this.txtUserId.Clear();
            this.txtPassword.Clear();
            this.Show();
            this.txtUserId.Focus();
        }
    }
}
