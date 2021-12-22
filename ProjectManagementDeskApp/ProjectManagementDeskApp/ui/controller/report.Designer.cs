namespace ProjectManagementDeskApp.ui.controller
{
    partial class report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComplete = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCompany = new System.Windows.Forms.Panel();
            this.lblOngoing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelUser = new System.Windows.Forms.Panel();
            this.lblCritical = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.dataProjectGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.comboEntity = new System.Windows.Forms.ComboBox();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectAssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewImageColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panelCompany.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProjectGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(445, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 32);
            this.label1.TabIndex = 83;
            this.label1.Text = "Report";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.panel1.Controls.Add(this.lblComplete);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(661, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 92);
            this.panel1.TabIndex = 86;
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplete.ForeColor = System.Drawing.Color.White;
            this.lblComplete.Location = new System.Drawing.Point(116, 42);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(57, 32);
            this.lblComplete.TabIndex = 4;
            this.lblComplete.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "Completed Projects";
            // 
            // panelCompany
            // 
            this.panelCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(116)))));
            this.panelCompany.Controls.Add(this.lblOngoing);
            this.panelCompany.Controls.Add(this.label2);
            this.panelCompany.Location = new System.Drawing.Point(363, 70);
            this.panelCompany.Name = "panelCompany";
            this.panelCompany.Size = new System.Drawing.Size(280, 92);
            this.panelCompany.TabIndex = 85;
            // 
            // lblOngoing
            // 
            this.lblOngoing.AutoSize = true;
            this.lblOngoing.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOngoing.ForeColor = System.Drawing.Color.White;
            this.lblOngoing.Location = new System.Drawing.Point(110, 42);
            this.lblOngoing.Name = "lblOngoing";
            this.lblOngoing.Size = new System.Drawing.Size(57, 32);
            this.lblOngoing.TabIndex = 3;
            this.lblOngoing.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ongoing Projects";
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(96)))));
            this.panelUser.Controls.Add(this.lblCritical);
            this.panelUser.Controls.Add(this.label3);
            this.panelUser.Location = new System.Drawing.Point(63, 70);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(280, 92);
            this.panelUser.TabIndex = 84;
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCritical.ForeColor = System.Drawing.Color.White;
            this.lblCritical.Location = new System.Drawing.Point(112, 42);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(57, 32);
            this.lblCritical.TabIndex = 2;
            this.lblCritical.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Critical Projects";
            // 
            // progressChart
            // 
            chartArea3.Name = "ChartArea1";
            this.progressChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.progressChart.Legends.Add(legend3);
            this.progressChart.Location = new System.Drawing.Point(30, 168);
            this.progressChart.Name = "progressChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            series3.LabelForeColor = System.Drawing.Color.Transparent;
            series3.Legend = "Legend1";
            series3.Name = "progressSeries";
            this.progressChart.Series.Add(series3);
            this.progressChart.Size = new System.Drawing.Size(445, 400);
            this.progressChart.TabIndex = 87;
            this.progressChart.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(190, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 25);
            this.label5.TabIndex = 88;
            this.label5.Text = "User Progress";
            // 
            // dataProjectGrid
            // 
            this.dataProjectGrid.AllowUserToAddRows = false;
            this.dataProjectGrid.AllowUserToDeleteRows = false;
            this.dataProjectGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataProjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProjectGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.FirstName,
            this.SurName,
            this.ProjectAssignedTo,
            this.Progress,
            this.Priority});
            this.dataProjectGrid.Location = new System.Drawing.Point(462, 245);
            this.dataProjectGrid.Name = "dataProjectGrid";
            this.dataProjectGrid.ReadOnly = true;
            this.dataProjectGrid.Size = new System.Drawing.Size(509, 330);
            this.dataProjectGrid.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(458, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 109;
            this.label6.Text = "Show Entities:";
            // 
            // comboEntity
            // 
            this.comboEntity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEntity.FormattingEnabled = true;
            this.comboEntity.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "All"});
            this.comboEntity.Location = new System.Drawing.Point(557, 207);
            this.comboEntity.Name = "comboEntity";
            this.comboEntity.Size = new System.Drawing.Size(47, 29);
            this.comboEntity.TabIndex = 110;
            this.comboEntity.Text = "10";
            this.comboEntity.SelectedIndexChanged += new System.EventHandler(this.comboEntity_SelectedIndexChanged);
            // 
            // comboPriority
            // 
            this.comboPriority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.comboPriority.Location = new System.Drawing.Point(893, 207);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(78, 29);
            this.comboPriority.TabIndex = 112;
            this.comboPriority.SelectedIndexChanged += new System.EventHandler(this.comboPriority_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(831, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 111;
            this.label7.Text = "Filter To:";
            // 
            // UserID
            // 
            this.UserID.HeaderText = "User Id";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // SurName
            // 
            this.SurName.HeaderText = "Sur Name";
            this.SurName.Name = "SurName";
            this.SurName.ReadOnly = true;
            // 
            // ProjectAssignedTo
            // 
            this.ProjectAssignedTo.HeaderText = "Project Assigned To";
            this.ProjectAssignedTo.Name = "ProjectAssignedTo";
            this.ProjectAssignedTo.ReadOnly = true;
            // 
            // Progress
            // 
            this.Progress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Progress.HeaderText = "Progress";
            this.Progress.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.comboPriority);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboEntity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataProjectGrid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressChart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCompany);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.label1);
            this.Name = "report";
            this.Size = new System.Drawing.Size(1003, 598);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCompany.ResumeLayout(false);
            this.panelCompany.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProjectGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelCompany;
        private System.Windows.Forms.Label lblOngoing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart progressChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataProjectGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboEntity;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectAssignedTo;
        private System.Windows.Forms.DataGridViewImageColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
    }
}
