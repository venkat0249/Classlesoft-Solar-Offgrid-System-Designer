namespace SolarOffgridSystemDesigner
{
    partial class SolarModuleSelection
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
            this.gridViewModules = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSettingsDialog = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnEditSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewModules)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewModules
            // 
            this.gridViewModules.AllowUserToAddRows = false;
            this.gridViewModules.AllowUserToDeleteRows = false;
            this.gridViewModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewModules.Location = new System.Drawing.Point(12, 12);
            this.gridViewModules.MultiSelect = false;
            this.gridViewModules.Name = "gridViewModules";
            this.gridViewModules.ReadOnly = true;
            this.gridViewModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewModules.Size = new System.Drawing.Size(983, 412);
            this.gridViewModules.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.BackColor = System.Drawing.Color.PaleGreen;
            this.btnOk.Location = new System.Drawing.Point(798, 442);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Choose Selected";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSettingsDialog
            // 
            this.btnSettingsDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettingsDialog.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSettingsDialog.Location = new System.Drawing.Point(12, 442);
            this.btnSettingsDialog.Name = "btnSettingsDialog";
            this.btnSettingsDialog.Size = new System.Drawing.Size(99, 23);
            this.btnSettingsDialog.TabIndex = 2;
            this.btnSettingsDialog.Text = "Settings";
            this.btnSettingsDialog.UseVisualStyleBackColor = false;
            this.btnSettingsDialog.Click += new System.EventHandler(this.btnSettingsDialog_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(922, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteSelected.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteSelected.Location = new System.Drawing.Point(117, 442);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = false;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnEditSelected
            // 
            this.btnEditSelected.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditSelected.Location = new System.Drawing.Point(222, 442);
            this.btnEditSelected.Name = "btnEditSelected";
            this.btnEditSelected.Size = new System.Drawing.Size(116, 23);
            this.btnEditSelected.TabIndex = 6;
            this.btnEditSelected.Text = "Edit Selected";
            this.btnEditSelected.UseVisualStyleBackColor = false;
            this.btnEditSelected.Click += new System.EventHandler(this.btnEditSelected_Click);
            // 
            // SolarModuleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 486);
            this.Controls.Add(this.btnEditSelected);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSettingsDialog);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gridViewModules);
            this.Name = "SolarModuleSelection";
            this.Text = "SolarModuleSelection";
            this.Load += new System.EventHandler(this.SolarModuleSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewModules;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSettingsDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnEditSelected;
    }
}