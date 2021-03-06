namespace ProjectManagementDeskApp.ui.controller
{
    partial class delete_assigned_project_to_user
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
            this.txtAssignId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteAssignProject = new System.Windows.Forms.Button();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAssignId
            // 
            this.txtAssignId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssignId.Enabled = false;
            this.txtAssignId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignId.Location = new System.Drawing.Point(415, 184);
            this.txtAssignId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAssignId.Name = "txtAssignId";
            this.txtAssignId.Size = new System.Drawing.Size(295, 29);
            this.txtAssignId.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(333, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 21);
            this.label8.TabIndex = 96;
            this.label8.Text = "Assign Id:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(713, 149);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 29);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(415, 149);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 29);
            this.txtSearch.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(144, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 21);
            this.label7.TabIndex = 94;
            this.label7.Text = "Search by Assign Id or Project Name:";
            // 
            // btnDeleteAssignProject
            // 
            this.btnDeleteAssignProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnDeleteAssignProject.FlatAppearance.BorderSize = 0;
            this.btnDeleteAssignProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAssignProject.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAssignProject.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAssignProject.Location = new System.Drawing.Point(590, 430);
            this.btnDeleteAssignProject.Name = "btnDeleteAssignProject";
            this.btnDeleteAssignProject.Size = new System.Drawing.Size(227, 42);
            this.btnDeleteAssignProject.TabIndex = 2;
            this.btnDeleteAssignProject.Text = "Delete Assigned Project";
            this.btnDeleteAssignProject.UseVisualStyleBackColor = false;
            this.btnDeleteAssignProject.Click += new System.EventHandler(this.btnDeleteAssignProject_Click);
            // 
            // comboPriority
            // 
            this.comboPriority.Enabled = false;
            this.comboPriority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.comboPriority.Location = new System.Drawing.Point(415, 370);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(295, 29);
            this.comboPriority.TabIndex = 86;
            this.comboPriority.Text = "-- SELECT PRIORITY --";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(345, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 93;
            this.label5.Text = "Priority:";
            // 
            // dateEndDate
            // 
            this.dateEndDate.Enabled = false;
            this.dateEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndDate.Location = new System.Drawing.Point(415, 334);
            this.dateEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(295, 29);
            this.dateEndDate.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 92;
            this.label4.Text = "End Date:";
            // 
            // dateStartDate
            // 
            this.dateStartDate.Enabled = false;
            this.dateStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartDate.Location = new System.Drawing.Point(415, 295);
            this.dateStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(295, 29);
            this.dateStartDate.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(328, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 91;
            this.label6.Text = "Start Date:";
            // 
            // comboUser
            // 
            this.comboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUser.Enabled = false;
            this.comboUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Location = new System.Drawing.Point(415, 258);
            this.comboUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboUser.Name = "comboUser";
            this.comboUser.Size = new System.Drawing.Size(402, 29);
            this.comboUser.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 90;
            this.label3.Text = "User Id:";
            // 
            // comboProject
            // 
            this.comboProject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboProject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboProject.Enabled = false;
            this.comboProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProject.FormattingEnabled = true;
            this.comboProject.Location = new System.Drawing.Point(415, 221);
            this.comboProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboProject.Name = "comboProject";
            this.comboProject.Size = new System.Drawing.Size(402, 29);
            this.comboProject.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 89;
            this.label2.Text = "Project Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 32);
            this.label1.TabIndex = 88;
            this.label1.Text = "Delete Assigned Project to User";
            // 
            // delete_assigned_project_to_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtAssignId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeleteAssignProject);
            this.Controls.Add(this.comboPriority);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateStartDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "delete_assigned_project_to_user";
            this.Size = new System.Drawing.Size(1003, 598);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAssignId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteAssignProject;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
