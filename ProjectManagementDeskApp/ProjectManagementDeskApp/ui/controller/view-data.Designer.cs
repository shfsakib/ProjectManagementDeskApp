namespace ProjectManagementDeskApp.ui.controller
{
    partial class view_data
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabViewData = new System.Windows.Forms.TabControl();
            this.tabUserPage = new System.Windows.Forms.TabPage();
            this.dataUserGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.dataProjectGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchProject = new System.Windows.Forms.Button();
            this.txtSearchProject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.dataCompanyGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchCompany = new System.Windows.Forms.Button();
            this.txtSearchCompany = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabTicket = new System.Windows.Forms.TabPage();
            this.dataTicketGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchTicket = new System.Windows.Forms.Button();
            this.txtSearchTicket = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabViewData.SuspendLayout();
            this.tabUserPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGrid)).BeginInit();
            this.tabProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProjectGrid)).BeginInit();
            this.tabCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCompanyGrid)).BeginInit();
            this.tabTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTicketGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "View";
            // 
            // tabViewData
            // 
            this.tabViewData.Controls.Add(this.tabUserPage);
            this.tabViewData.Controls.Add(this.tabProject);
            this.tabViewData.Controls.Add(this.tabCompany);
            this.tabViewData.Controls.Add(this.tabTicket);
            this.tabViewData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabViewData.Location = new System.Drawing.Point(14, 68);
            this.tabViewData.Name = "tabViewData";
            this.tabViewData.SelectedIndex = 0;
            this.tabViewData.Size = new System.Drawing.Size(975, 507);
            this.tabViewData.TabIndex = 98;
            // 
            // tabUserPage
            // 
            this.tabUserPage.BackColor = System.Drawing.Color.White;
            this.tabUserPage.Controls.Add(this.dataUserGrid);
            this.tabUserPage.Controls.Add(this.btnSearchUser);
            this.tabUserPage.Controls.Add(this.txtSearchUser);
            this.tabUserPage.Controls.Add(this.label5);
            this.tabUserPage.Controls.Add(this.label2);
            this.tabUserPage.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabUserPage.Location = new System.Drawing.Point(4, 30);
            this.tabUserPage.Name = "tabUserPage";
            this.tabUserPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserPage.Size = new System.Drawing.Size(967, 473);
            this.tabUserPage.TabIndex = 0;
            this.tabUserPage.Text = "Users";
            // 
            // dataUserGrid
            // 
            this.dataUserGrid.AllowUserToAddRows = false;
            this.dataUserGrid.AllowUserToDeleteRows = false;
            this.dataUserGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataUserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserGrid.Location = new System.Drawing.Point(32, 73);
            this.dataUserGrid.Name = "dataUserGrid";
            this.dataUserGrid.Size = new System.Drawing.Size(912, 387);
            this.dataUserGrid.TabIndex = 102;
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchUser.FlatAppearance.BorderSize = 0;
            this.btnSearchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.ForeColor = System.Drawing.Color.White;
            this.btnSearchUser.Location = new System.Drawing.Point(847, 23);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(97, 29);
            this.btnSearchUser.TabIndex = 100;
            this.btnSearchUser.Text = "Search";
            this.btnSearchUser.UseVisualStyleBackColor = false;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchUser.Location = new System.Drawing.Point(655, 23);
            this.txtSearchUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(189, 29);
            this.txtSearchUser.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(553, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 101;
            this.label5.Text = "Search User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 98;
            this.label2.Text = "Users";
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.dataProjectGrid);
            this.tabProject.Controls.Add(this.btnSearchProject);
            this.tabProject.Controls.Add(this.txtSearchProject);
            this.tabProject.Controls.Add(this.label3);
            this.tabProject.Controls.Add(this.label4);
            this.tabProject.Location = new System.Drawing.Point(4, 30);
            this.tabProject.Name = "tabProject";
            this.tabProject.Size = new System.Drawing.Size(967, 473);
            this.tabProject.TabIndex = 1;
            this.tabProject.Text = "Projects";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // dataProjectGrid
            // 
            this.dataProjectGrid.AllowUserToAddRows = false;
            this.dataProjectGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataProjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProjectGrid.Location = new System.Drawing.Point(30, 68);
            this.dataProjectGrid.Name = "dataProjectGrid";
            this.dataProjectGrid.Size = new System.Drawing.Size(912, 387);
            this.dataProjectGrid.TabIndex = 107;
            // 
            // btnSearchProject
            // 
            this.btnSearchProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchProject.FlatAppearance.BorderSize = 0;
            this.btnSearchProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProject.ForeColor = System.Drawing.Color.White;
            this.btnSearchProject.Location = new System.Drawing.Point(845, 18);
            this.btnSearchProject.Name = "btnSearchProject";
            this.btnSearchProject.Size = new System.Drawing.Size(97, 29);
            this.btnSearchProject.TabIndex = 105;
            this.btnSearchProject.Text = "Search";
            this.btnSearchProject.UseVisualStyleBackColor = false;
            this.btnSearchProject.Click += new System.EventHandler(this.btnSearchProject_Click);
            // 
            // txtSearchProject
            // 
            this.txtSearchProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProject.Location = new System.Drawing.Point(653, 18);
            this.txtSearchProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchProject.Name = "txtSearchProject";
            this.txtSearchProject.Size = new System.Drawing.Size(189, 29);
            this.txtSearchProject.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(531, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 21);
            this.label3.TabIndex = 106;
            this.label3.Text = "Search Projects:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 103;
            this.label4.Text = "Projects";
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.dataCompanyGrid);
            this.tabCompany.Controls.Add(this.btnSearchCompany);
            this.tabCompany.Controls.Add(this.txtSearchCompany);
            this.tabCompany.Controls.Add(this.label6);
            this.tabCompany.Controls.Add(this.label7);
            this.tabCompany.Location = new System.Drawing.Point(4, 30);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Size = new System.Drawing.Size(967, 473);
            this.tabCompany.TabIndex = 3;
            this.tabCompany.Text = "Companies";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // dataCompanyGrid
            // 
            this.dataCompanyGrid.AllowUserToAddRows = false;
            this.dataCompanyGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataCompanyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCompanyGrid.Location = new System.Drawing.Point(30, 68);
            this.dataCompanyGrid.Name = "dataCompanyGrid";
            this.dataCompanyGrid.Size = new System.Drawing.Size(912, 387);
            this.dataCompanyGrid.TabIndex = 107;
            // 
            // btnSearchCompany
            // 
            this.btnSearchCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchCompany.FlatAppearance.BorderSize = 0;
            this.btnSearchCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCompany.ForeColor = System.Drawing.Color.White;
            this.btnSearchCompany.Location = new System.Drawing.Point(845, 18);
            this.btnSearchCompany.Name = "btnSearchCompany";
            this.btnSearchCompany.Size = new System.Drawing.Size(97, 29);
            this.btnSearchCompany.TabIndex = 105;
            this.btnSearchCompany.Text = "Search";
            this.btnSearchCompany.UseVisualStyleBackColor = false;
            this.btnSearchCompany.Click += new System.EventHandler(this.btnSearchCompany_Click);
            // 
            // txtSearchCompany
            // 
            this.txtSearchCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCompany.Location = new System.Drawing.Point(653, 18);
            this.txtSearchCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchCompany.Name = "txtSearchCompany";
            this.txtSearchCompany.Size = new System.Drawing.Size(189, 29);
            this.txtSearchCompany.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(510, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 106;
            this.label6.Text = "Search Companies:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 103;
            this.label7.Text = "Companies";
            // 
            // tabTicket
            // 
            this.tabTicket.Controls.Add(this.dataTicketGrid);
            this.tabTicket.Controls.Add(this.btnSearchTicket);
            this.tabTicket.Controls.Add(this.txtSearchTicket);
            this.tabTicket.Controls.Add(this.label8);
            this.tabTicket.Controls.Add(this.label9);
            this.tabTicket.Location = new System.Drawing.Point(4, 30);
            this.tabTicket.Name = "tabTicket";
            this.tabTicket.Size = new System.Drawing.Size(967, 473);
            this.tabTicket.TabIndex = 2;
            this.tabTicket.Text = "Tickets";
            this.tabTicket.UseVisualStyleBackColor = true;
            // 
            // dataTicketGrid
            // 
            this.dataTicketGrid.AllowUserToAddRows = false;
            this.dataTicketGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataTicketGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTicketGrid.Location = new System.Drawing.Point(30, 68);
            this.dataTicketGrid.Name = "dataTicketGrid";
            this.dataTicketGrid.Size = new System.Drawing.Size(912, 387);
            this.dataTicketGrid.TabIndex = 112;
            // 
            // btnSearchTicket
            // 
            this.btnSearchTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchTicket.FlatAppearance.BorderSize = 0;
            this.btnSearchTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTicket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTicket.ForeColor = System.Drawing.Color.White;
            this.btnSearchTicket.Location = new System.Drawing.Point(845, 18);
            this.btnSearchTicket.Name = "btnSearchTicket";
            this.btnSearchTicket.Size = new System.Drawing.Size(97, 29);
            this.btnSearchTicket.TabIndex = 110;
            this.btnSearchTicket.Text = "Search";
            this.btnSearchTicket.UseVisualStyleBackColor = false;
            this.btnSearchTicket.Click += new System.EventHandler(this.btnSearchTicket_Click);
            // 
            // txtSearchTicket
            // 
            this.txtSearchTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchTicket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTicket.Location = new System.Drawing.Point(653, 18);
            this.txtSearchTicket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchTicket.Name = "txtSearchTicket";
            this.txtSearchTicket.Size = new System.Drawing.Size(189, 29);
            this.txtSearchTicket.TabIndex = 109;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(536, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 21);
            this.label8.TabIndex = 111;
            this.label8.Text = "Search Tickets:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 25);
            this.label9.TabIndex = 108;
            this.label9.Text = "Tickets";
            // 
            // view_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tabViewData);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1003, 598);
            this.Name = "view_data";
            this.Size = new System.Drawing.Size(1003, 598);
            this.tabViewData.ResumeLayout(false);
            this.tabUserPage.ResumeLayout(false);
            this.tabUserPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGrid)).EndInit();
            this.tabProject.ResumeLayout(false);
            this.tabProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProjectGrid)).EndInit();
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCompanyGrid)).EndInit();
            this.tabTicket.ResumeLayout(false);
            this.tabTicket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTicketGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabViewData;
        private System.Windows.Forms.TabPage tabUserPage;
        private System.Windows.Forms.DataGridView dataUserGrid;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.DataGridView dataProjectGrid;
        private System.Windows.Forms.Button btnSearchProject;
        private System.Windows.Forms.TextBox txtSearchProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.TabPage tabTicket;
        private System.Windows.Forms.DataGridView dataCompanyGrid;
        private System.Windows.Forms.Button btnSearchCompany;
        private System.Windows.Forms.TextBox txtSearchCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataTicketGrid;
        private System.Windows.Forms.Button btnSearchTicket;
        private System.Windows.Forms.TextBox txtSearchTicket;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
