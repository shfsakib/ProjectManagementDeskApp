namespace ProjectManagementDeskApp.ui.controller
{
    partial class assigned_project
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
            this.dataProjectGrid = new System.Windows.Forms.DataGridView();
            this.btnSearchProject = new System.Windows.Forms.Button();
            this.txtSearchProject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataProjectGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(446, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Assign Projects";
            // 
            // dataProjectGrid
            // 
            this.dataProjectGrid.AllowUserToAddRows = false;
            this.dataProjectGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataProjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProjectGrid.Location = new System.Drawing.Point(44, 131);
            this.dataProjectGrid.Name = "dataProjectGrid";
            this.dataProjectGrid.Size = new System.Drawing.Size(912, 423);
            this.dataProjectGrid.TabIndex = 111;
            // 
            // btnSearchProject
            // 
            this.btnSearchProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(127)))), ((int)(((byte)(173)))));
            this.btnSearchProject.FlatAppearance.BorderSize = 0;
            this.btnSearchProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProject.ForeColor = System.Drawing.Color.White;
            this.btnSearchProject.Location = new System.Drawing.Point(859, 81);
            this.btnSearchProject.Name = "btnSearchProject";
            this.btnSearchProject.Size = new System.Drawing.Size(97, 29);
            this.btnSearchProject.TabIndex = 109;
            this.btnSearchProject.Text = "Search";
            this.btnSearchProject.UseVisualStyleBackColor = false;
            this.btnSearchProject.Click += new System.EventHandler(this.btnSearchProject_Click);
            // 
            // txtSearchProject
            // 
            this.txtSearchProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProject.Location = new System.Drawing.Point(667, 81);
            this.txtSearchProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchProject.Name = "txtSearchProject";
            this.txtSearchProject.Size = new System.Drawing.Size(189, 29);
            this.txtSearchProject.TabIndex = 108;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(545, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 21);
            this.label3.TabIndex = 110;
            this.label3.Text = "Search Projects:";
            // 
            // assigned_project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectManagementDeskApp.Properties.Resources.bg_radius;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dataProjectGrid);
            this.Controls.Add(this.btnSearchProject);
            this.Controls.Add(this.txtSearchProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "assigned_project";
            this.Size = new System.Drawing.Size(1003, 598);
            ((System.ComponentModel.ISupportInitialize)(this.dataProjectGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataProjectGrid;
        private System.Windows.Forms.Button btnSearchProject;
        private System.Windows.Forms.TextBox txtSearchProject;
        private System.Windows.Forms.Label label3;
    }
}
