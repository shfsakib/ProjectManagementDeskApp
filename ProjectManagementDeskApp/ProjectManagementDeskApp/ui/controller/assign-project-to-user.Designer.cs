namespace ProjectManagementDeskApp.ui.controller
{
    partial class assign_project
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboProject = new System.Windows.Forms.ComboBox();
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAssignProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(393, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Assign Project to Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 44;
            this.label2.Text = "Project Id:";
            // 
            // comboProject
            // 
            this.comboProject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboProject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProject.FormattingEnabled = true;
            this.comboProject.Location = new System.Drawing.Point(318, 187);
            this.comboProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboProject.Name = "comboProject";
            this.comboProject.Size = new System.Drawing.Size(402, 29);
            this.comboProject.TabIndex = 0;
            // 
            // comboUser
            // 
            this.comboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Location = new System.Drawing.Point(318, 224);
            this.comboUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboUser.Name = "comboUser";
            this.comboUser.Size = new System.Drawing.Size(402, 29);
            this.comboUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 46;
            this.label3.Text = "User Id:";
            // 
            // dateEndDate
            // 
            this.dateEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndDate.Location = new System.Drawing.Point(318, 300);
            this.dateEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(295, 29);
            this.dateEndDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(237, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "End Date:";
            // 
            // dateStartDate
            // 
            this.dateStartDate.Enabled = false;
            this.dateStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartDate.Location = new System.Drawing.Point(318, 261);
            this.dateStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(295, 29);
            this.dateStartDate.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 55;
            this.label6.Text = "Start Date:";
            // 
            // comboPriority
            // 
            this.comboPriority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.comboPriority.Location = new System.Drawing.Point(318, 336);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(295, 29);
            this.comboPriority.TabIndex = 4;
            this.comboPriority.Text = "-- SELECT PRIORITY --";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(248, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 58;
            this.label5.Text = "Priority:";
            // 
            // btnAssignProject
            // 
            this.btnAssignProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnAssignProject.FlatAppearance.BorderSize = 0;
            this.btnAssignProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignProject.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignProject.ForeColor = System.Drawing.Color.White;
            this.btnAssignProject.Location = new System.Drawing.Point(563, 396);
            this.btnAssignProject.Name = "btnAssignProject";
            this.btnAssignProject.Size = new System.Drawing.Size(157, 42);
            this.btnAssignProject.TabIndex = 5;
            this.btnAssignProject.Text = "Assign Project";
            this.btnAssignProject.UseVisualStyleBackColor = false;
            this.btnAssignProject.Click += new System.EventHandler(this.btnAssignProject_Click);
            // 
            // assign_project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnAssignProject);
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
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "assign_project";
            this.Size = new System.Drawing.Size(1003, 598);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboProject;
        private System.Windows.Forms.ComboBox comboUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAssignProject;
    }
}
