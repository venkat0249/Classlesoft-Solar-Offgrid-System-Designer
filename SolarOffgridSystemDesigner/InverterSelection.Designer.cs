//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
namespace SolarOffgridSystemDesigner
{
    partial class InverterSelection
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
            this.gridViewInverters = new System.Windows.Forms.DataGridView();
            this.Suitable = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnEditSelected = new System.Windows.Forms.Button();
            this.btnSettingsDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInverters)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewInverters
            // 
            this.gridViewInverters.AllowUserToAddRows = false;
            this.gridViewInverters.AllowUserToDeleteRows = false;
            this.gridViewInverters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewInverters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewInverters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Suitable});
            this.gridViewInverters.Location = new System.Drawing.Point(12, 12);
            this.gridViewInverters.MultiSelect = false;
            this.gridViewInverters.Name = "gridViewInverters";
            this.gridViewInverters.ReadOnly = true;
            this.gridViewInverters.RowHeadersWidth = 10;
            this.gridViewInverters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewInverters.Size = new System.Drawing.Size(983, 412);
            this.gridViewInverters.TabIndex = 0;
            // 
            // Suitable
            // 
            this.Suitable.HeaderText = "Suitable";
            this.Suitable.Name = "Suitable";
            this.Suitable.ReadOnly = true;
            this.Suitable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Suitable.Width = 30;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.BackColor = System.Drawing.Color.GreenYellow;
            this.btnOk.Location = new System.Drawing.Point(785, 442);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Choose the Selected";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(921, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteSelected.Location = new System.Drawing.Point(116, 442);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(116, 23);
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = false;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnEditSelected
            // 
            this.btnEditSelected.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditSelected.Location = new System.Drawing.Point(238, 442);
            this.btnEditSelected.Name = "btnEditSelected";
            this.btnEditSelected.Size = new System.Drawing.Size(116, 23);
            this.btnEditSelected.TabIndex = 5;
            this.btnEditSelected.Text = "Edit Selected";
            this.btnEditSelected.UseVisualStyleBackColor = false;
            this.btnEditSelected.Click += new System.EventHandler(this.btnEditSelected_Click);
            // 
            // btnSettingsDialog
            // 
            this.btnSettingsDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettingsDialog.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSettingsDialog.Location = new System.Drawing.Point(11, 442);
            this.btnSettingsDialog.Name = "btnSettingsDialog";
            this.btnSettingsDialog.Size = new System.Drawing.Size(99, 23);
            this.btnSettingsDialog.TabIndex = 6;
            this.btnSettingsDialog.Text = "Settings";
            this.btnSettingsDialog.UseVisualStyleBackColor = false;
            this.btnSettingsDialog.Click += new System.EventHandler(this.btnSettingsDialog_Click);
            // 
            // InverterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 486);
            this.Controls.Add(this.btnSettingsDialog);
            this.Controls.Add(this.btnEditSelected);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gridViewInverters);
            this.Name = "InverterSelection";
            this.Text = "SolarModuleSelection";
            this.Load += new System.EventHandler(this.InverterSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInverters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewInverters;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewImageColumn Suitable;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnEditSelected;
        private System.Windows.Forms.Button btnSettingsDialog;
    }
}