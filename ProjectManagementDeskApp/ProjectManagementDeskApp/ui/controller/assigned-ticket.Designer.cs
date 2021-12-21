namespace ProjectManagementDeskApp.ui.controller
{
    partial class assigned_ticket
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
            this.dataTicketGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchTicket = new System.Windows.Forms.Button();
            this.txtSearchTicket = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTicketGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(424, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Assigned Tickets";
            // 
            // dataTicketGrid
            // 
            this.dataTicketGrid.AllowUserToAddRows = false;
            this.dataTicketGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataTicketGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTicketGrid.Location = new System.Drawing.Point(45, 131);
            this.dataTicketGrid.Name = "dataTicketGrid";
            this.dataTicketGrid.Size = new System.Drawing.Size(912, 412);
            this.dataTicketGrid.TabIndex = 116;
            // 
            // btnSearchTicket
            // 
            this.btnSearchTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchTicket.FlatAppearance.BorderSize = 0;
            this.btnSearchTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTicket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTicket.ForeColor = System.Drawing.Color.White;
            this.btnSearchTicket.Location = new System.Drawing.Point(860, 81);
            this.btnSearchTicket.Name = "btnSearchTicket";
            this.btnSearchTicket.Size = new System.Drawing.Size(97, 29);
            this.btnSearchTicket.TabIndex = 114;
            this.btnSearchTicket.Text = "Search";
            this.btnSearchTicket.UseVisualStyleBackColor = false;
            this.btnSearchTicket.Click += new System.EventHandler(this.btnSearchTicket_Click);
            // 
            // txtSearchTicket
            // 
            this.txtSearchTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchTicket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTicket.Location = new System.Drawing.Point(668, 81);
            this.txtSearchTicket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchTicket.Name = "txtSearchTicket";
            this.txtSearchTicket.Size = new System.Drawing.Size(189, 29);
            this.txtSearchTicket.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(551, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 21);
            this.label8.TabIndex = 115;
            this.label8.Text = "Search Tickets:";
            // 
            // assigned_ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dataTicketGrid);
            this.Controls.Add(this.btnSearchTicket);
            this.Controls.Add(this.txtSearchTicket);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Name = "assigned_ticket";
            this.Size = new System.Drawing.Size(1003, 598);
            ((System.ComponentModel.ISupportInitialize)(this.dataTicketGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataTicketGrid;
        private System.Windows.Forms.Button btnSearchTicket;
        private System.Windows.Forms.TextBox txtSearchTicket;
        private System.Windows.Forms.Label label8;
    }
}
