namespace PharmacyManagement
{
    partial class SellerPortal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerPortal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlShowSeller = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSellsReport = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnCustomerInfo = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlShowSeller.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pnlShowSeller);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 618);
            this.panel1.TabIndex = 0;
            // 
            // pnlShowSeller
            // 
            this.pnlShowSeller.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlShowSeller.BackgroundImage")));
            this.pnlShowSeller.Controls.Add(this.label2);
            this.pnlShowSeller.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlShowSeller.Location = new System.Drawing.Point(0, 94);
            this.pnlShowSeller.Name = "pnlShowSeller";
            this.pnlShowSeller.Size = new System.Drawing.Size(1027, 524);
            this.pnlShowSeller.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(289, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 53);
            this.label2.TabIndex = 6;
            this.label2.Text = "Welcome, Seller Portal";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.btnSellsReport);
            this.panel2.Controls.Add(this.btnCart);
            this.panel2.Controls.Add(this.btnCustomerInfo);
            this.panel2.Controls.Add(this.btnStock);
            this.panel2.Controls.Add(this.btnLogOut);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 94);
            this.panel2.TabIndex = 1;
            // 
            // btnSellsReport
            // 
            this.btnSellsReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSellsReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSellsReport.ForeColor = System.Drawing.Color.Bisque;
            this.btnSellsReport.Image = ((System.Drawing.Image)(resources.GetObject("btnSellsReport.Image")));
            this.btnSellsReport.Location = new System.Drawing.Point(582, 3);
            this.btnSellsReport.Name = "btnSellsReport";
            this.btnSellsReport.Size = new System.Drawing.Size(121, 84);
            this.btnSellsReport.TabIndex = 8;
            this.btnSellsReport.Text = "Sells Report";
            this.btnSellsReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSellsReport.UseVisualStyleBackColor = false;
            this.btnSellsReport.Click += new System.EventHandler(this.btnSellsReport_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.Transparent;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCart.ForeColor = System.Drawing.Color.Bisque;
            this.btnCart.Image = ((System.Drawing.Image)(resources.GetObject("btnCart.Image")));
            this.btnCart.Location = new System.Drawing.Point(501, 3);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(75, 84);
            this.btnCart.TabIndex = 7;
            this.btnCart.Text = "Cart";
            this.btnCart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnCustomerInfo
            // 
            this.btnCustomerInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerInfo.ForeColor = System.Drawing.Color.Bisque;
            this.btnCustomerInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerInfo.Image")));
            this.btnCustomerInfo.Location = new System.Drawing.Point(298, 3);
            this.btnCustomerInfo.Name = "btnCustomerInfo";
            this.btnCustomerInfo.Size = new System.Drawing.Size(116, 84);
            this.btnCustomerInfo.TabIndex = 4;
            this.btnCustomerInfo.Text = "Customer Info";
            this.btnCustomerInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomerInfo.UseVisualStyleBackColor = false;
            this.btnCustomerInfo.Click += new System.EventHandler(this.btnCustomerInfo_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.Transparent;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStock.ForeColor = System.Drawing.Color.Bisque;
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.Location = new System.Drawing.Point(420, 3);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(75, 84);
            this.btnStock.TabIndex = 3;
            this.btnStock.Text = "Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Bisque;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(718, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(72, 84);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.ForeColor = System.Drawing.Color.Bisque;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(220, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(72, 84);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // SellerPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 618);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SellerPortal";
            this.Text = "Seller";
            this.panel1.ResumeLayout(false);
            this.pnlShowSeller.ResumeLayout(false);
            this.pnlShowSeller.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCustomerInfo;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSellsReport;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Panel pnlShowSeller;
        private System.Windows.Forms.Label label2;
    }
}