namespace ProjectManagementDeskApp.ui.controller
{
    partial class companies
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
            this.dataCompanyGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchCompany = new System.Windows.Forms.Button();
            this.txtSearchCompany = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataCompanyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(470, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Companies";
            // 
            // dataCompanyGrid
            // 
            this.dataCompanyGrid.AllowUserToAddRows = false;
            this.dataCompanyGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataCompanyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCompanyGrid.Location = new System.Drawing.Point(45, 140);
            this.dataCompanyGrid.Name = "dataCompanyGrid";
            this.dataCompanyGrid.Size = new System.Drawing.Size(912, 414);
            this.dataCompanyGrid.TabIndex = 111;
            // 
            // btnSearchCompany
            // 
            this.btnSearchCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchCompany.FlatAppearance.BorderSize = 0;
            this.btnSearchCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCompany.ForeColor = System.Drawing.Color.White;
            this.btnSearchCompany.Location = new System.Drawing.Point(860, 90);
            this.btnSearchCompany.Name = "btnSearchCompany";
            this.btnSearchCompany.Size = new System.Drawing.Size(97, 29);
            this.btnSearchCompany.TabIndex = 109;
            this.btnSearchCompany.Text = "Search";
            this.btnSearchCompany.UseVisualStyleBackColor = false;
            this.btnSearchCompany.Click += new System.EventHandler(this.btnSearchCompany_Click);
            // 
            // txtSearchCompany
            // 
            this.txtSearchCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCompany.Location = new System.Drawing.Point(668, 90);
            this.txtSearchCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchCompany.Name = "txtSearchCompany";
            this.txtSearchCompany.Size = new System.Drawing.Size(189, 29);
            this.txtSearchCompany.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(525, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 110;
            this.label6.Text = "Search Companies:";
            // 
            // companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dataCompanyGrid);
            this.Controls.Add(this.btnSearchCompany);
            this.Controls.Add(this.txtSearchCompany);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "companies";
            this.Size = new System.Drawing.Size(1003, 598);
            ((System.ComponentModel.ISupportInitialize)(this.dataCompanyGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataCompanyGrid;
        private System.Windows.Forms.Button btnSearchCompany;
        private System.Windows.Forms.TextBox txtSearchCompany;
        private System.Windows.Forms.Label label6;
    }
}
