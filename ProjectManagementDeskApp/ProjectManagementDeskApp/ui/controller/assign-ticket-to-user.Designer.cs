namespace ProjectManagementDeskApp.ui.controller
{
    partial class assign_ticket_to_user
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
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTicket = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateIssue = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAssignTicket = new System.Windows.Forms.Button();
            this.comboProject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCompany = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "Assign Ticket to Company";
            // 
            // comboUser
            // 
            this.comboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Location = new System.Drawing.Point(261, 178);
            this.comboUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboUser.Name = "comboUser";
            this.comboUser.Size = new System.Drawing.Size(402, 29);
            this.comboUser.TabIndex = 1;
            this.comboUser.SelectedIndexChanged += new System.EventHandler(this.comboUser_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 48;
            this.label3.Text = "User Id:";
            // 
            // comboTicket
            // 
            this.comboTicket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboTicket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTicket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTicket.FormattingEnabled = true;
            this.comboTicket.Location = new System.Drawing.Point(261, 141);
            this.comboTicket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboTicket.Name = "comboTicket";
            this.comboTicket.Size = new System.Drawing.Size(402, 29);
            this.comboTicket.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Ticket Id:";
            // 
            // dateIssue
            // 
            this.dateIssue.Enabled = false;
            this.dateIssue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateIssue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateIssue.Location = new System.Drawing.Point(261, 215);
            this.dateIssue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateIssue.Name = "dateIssue";
            this.dateIssue.Size = new System.Drawing.Size(295, 29);
            this.dateIssue.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 57;
            this.label6.Text = "Date Issued:";
            // 
            // btnAssignTicket
            // 
            this.btnAssignTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnAssignTicket.FlatAppearance.BorderSize = 0;
            this.btnAssignTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignTicket.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignTicket.ForeColor = System.Drawing.Color.White;
            this.btnAssignTicket.Location = new System.Drawing.Point(448, 333);
            this.btnAssignTicket.Name = "btnAssignTicket";
            this.btnAssignTicket.Size = new System.Drawing.Size(215, 42);
            this.btnAssignTicket.TabIndex = 3;
            this.btnAssignTicket.Text = "Assign Ticket To User";
            this.btnAssignTicket.UseVisualStyleBackColor = false;
            this.btnAssignTicket.Click += new System.EventHandler(this.btnAssignTicket_Click);
            // 
            // comboProject
            // 
            this.comboProject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboProject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProject.FormattingEnabled = true;
            this.comboProject.Location = new System.Drawing.Point(261, 252);
            this.comboProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboProject.Name = "comboProject";
            this.comboProject.Size = new System.Drawing.Size(402, 29);
            this.comboProject.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 59;
            this.label4.Text = "Project Id:";
            // 
            // comboCompany
            // 
            this.comboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCompany.FormattingEnabled = true;
            this.comboCompany.Location = new System.Drawing.Point(261, 289);
            this.comboCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboCompany.Name = "comboCompany";
            this.comboCompany.Size = new System.Drawing.Size(402, 29);
            this.comboCompany.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 21);
            this.label5.TabIndex = 68;
            this.label5.Text = "Company Id:";
            // 
            // assign_ticket_to_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.comboCompany);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboProject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAssignTicket);
            this.Controls.Add(this.dateIssue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboTicket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "assign_ticket_to_user";
            this.Size = new System.Drawing.Size(1003, 598);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateIssue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAssignTicket;
        private System.Windows.Forms.ComboBox comboProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboCompany;
        private System.Windows.Forms.Label label5;
    }
}
