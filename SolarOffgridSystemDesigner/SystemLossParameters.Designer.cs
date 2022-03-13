namespace SolarOffgridSystemDesigner
{
    partial class SystemLossParameters
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtKb = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtKr = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtKx = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtKa = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtKc = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtPd = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtDaut = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.txtModuleLosses = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtKb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModuleLosses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Daily Battery Discharge loss:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Losses due battery inefficiency:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Inverter Losses:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Estimated Battery Anotomy days";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Other System Losses:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Loss in Battery Charger or regulator:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Battery Depth of Discharge";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(123, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(267, 365);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(126, 17);
            this.lblError.TabIndex = 34;
            this.lblError.Text = "Please fill all fields!";
            this.lblError.Visible = false;
            // 
            // txtKb
            // 
            this.txtKb.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtKb.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtKb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKb.DoubleValue = 0D;
            this.txtKb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKb.Location = new System.Drawing.Point(285, 69);
            this.txtKb.MaxValue = 100D;
            this.txtKb.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKb.MinValue = 0D;
            this.txtKb.Name = "txtKb";
            this.txtKb.NullString = "";
            this.txtKb.NumberDecimalDigits = 1;
            this.txtKb.Size = new System.Drawing.Size(68, 21);
            this.txtKb.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKb.TabIndex = 35;
            this.txtKb.Text = "0.0";
            // 
            // txtKr
            // 
            this.txtKr.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtKr.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtKr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKr.DoubleValue = 0D;
            this.txtKr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKr.Location = new System.Drawing.Point(285, 147);
            this.txtKr.MaxValue = 100D;
            this.txtKr.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKr.MinValue = 0D;
            this.txtKr.Name = "txtKr";
            this.txtKr.NullString = "";
            this.txtKr.NumberDecimalDigits = 1;
            this.txtKr.Size = new System.Drawing.Size(68, 21);
            this.txtKr.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKr.TabIndex = 36;
            this.txtKr.Text = "0.0";
            // 
            // txtKx
            // 
            this.txtKx.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtKx.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtKx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKx.DoubleValue = 0D;
            this.txtKx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKx.Location = new System.Drawing.Point(285, 186);
            this.txtKx.MaxValue = 100D;
            this.txtKx.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKx.MinValue = 0D;
            this.txtKx.Name = "txtKx";
            this.txtKx.NullString = "";
            this.txtKx.NumberDecimalDigits = 1;
            this.txtKx.Size = new System.Drawing.Size(68, 21);
            this.txtKx.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKx.TabIndex = 37;
            this.txtKx.Text = "0.0";
            // 
            // txtKa
            // 
            this.txtKa.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtKa.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtKa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKa.DoubleValue = 0D;
            this.txtKa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKa.Location = new System.Drawing.Point(285, 230);
            this.txtKa.MaxValue = 100D;
            this.txtKa.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKa.MinValue = 0D;
            this.txtKa.Name = "txtKa";
            this.txtKa.NullString = "";
            this.txtKa.NumberDecimalDigits = 1;
            this.txtKa.Size = new System.Drawing.Size(68, 21);
            this.txtKa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKa.TabIndex = 38;
            this.txtKa.Text = "0.0";
            // 
            // txtKc
            // 
            this.txtKc.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtKc.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtKc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKc.DoubleValue = 0D;
            this.txtKc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKc.Location = new System.Drawing.Point(285, 110);
            this.txtKc.MaxValue = 100D;
            this.txtKc.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKc.MinValue = 0D;
            this.txtKc.Name = "txtKc";
            this.txtKc.NullString = "";
            this.txtKc.NumberDecimalDigits = 1;
            this.txtKc.Size = new System.Drawing.Size(68, 21);
            this.txtKc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKc.TabIndex = 39;
            this.txtKc.Text = "0.0";
            // 
            // txtPd
            // 
            this.txtPd.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtPd.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtPd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPd.DoubleValue = 0D;
            this.txtPd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPd.Location = new System.Drawing.Point(285, 310);
            this.txtPd.MaxValue = 100D;
            this.txtPd.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPd.MinValue = 0D;
            this.txtPd.Name = "txtPd";
            this.txtPd.NullString = "";
            this.txtPd.NumberDecimalDigits = 1;
            this.txtPd.Size = new System.Drawing.Size(68, 21);
            this.txtPd.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPd.TabIndex = 40;
            this.txtPd.Text = "0.0";
            // 
            // txtDaut
            // 
            this.txtDaut.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtDaut.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtDaut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDaut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaut.IntegerValue = ((long)(1));
            this.txtDaut.Location = new System.Drawing.Point(285, 270);
            this.txtDaut.MaxValue = ((long)(30));
            this.txtDaut.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDaut.MinValue = ((long)(1));
            this.txtDaut.Name = "txtDaut";
            this.txtDaut.NullString = "";
            this.txtDaut.Size = new System.Drawing.Size(68, 21);
            this.txtDaut.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtDaut.TabIndex = 41;
            this.txtDaut.Text = "1";
            // 
            // txtModuleLosses
            // 
            this.txtModuleLosses.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtModuleLosses.BeforeTouchSize = new System.Drawing.Size(68, 21);
            this.txtModuleLosses.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtModuleLosses.DoubleValue = 0D;
            this.txtModuleLosses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModuleLosses.Location = new System.Drawing.Point(285, 25);
            this.txtModuleLosses.MaxValue = 100D;
            this.txtModuleLosses.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtModuleLosses.MinValue = 0D;
            this.txtModuleLosses.Name = "txtModuleLosses";
            this.txtModuleLosses.NullString = "";
            this.txtModuleLosses.NumberDecimalDigits = 1;
            this.txtModuleLosses.Size = new System.Drawing.Size(68, 21);
            this.txtModuleLosses.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtModuleLosses.TabIndex = 43;
            this.txtModuleLosses.Text = "0.0";
            // 
            // autoLabel1
            // 
            this.autoLabel1.AutoSize = false;
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(33, 25);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(246, 34);
            this.autoLabel1.TabIndex = 44;
            this.autoLabel1.Text = "Estimated losses due to temperature and low irradiance:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(359, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 46;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(359, 314);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 17);
            this.label10.TabIndex = 47;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(359, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(359, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 49;
            this.label12.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(359, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 17);
            this.label13.TabIndex = 50;
            this.label13.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(359, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 17);
            this.label14.TabIndex = 51;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(359, 273);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 17);
            this.label15.TabIndex = 52;
            this.label15.Text = "days";
            // 
            // SystemLossParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 410);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtModuleLosses);
            this.Controls.Add(this.txtDaut);
            this.Controls.Add(this.txtPd);
            this.Controls.Add(this.txtKc);
            this.Controls.Add(this.txtKa);
            this.Controls.Add(this.txtKx);
            this.Controls.Add(this.txtKr);
            this.Controls.Add(this.txtKb);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "SystemLossParameters";
            this.Text = "System Losses";
            this.Load += new System.EventHandler(this.SystemLossParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModuleLosses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblError;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtKb;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtKr;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtKx;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtKa;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtKc;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtPd;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtDaut;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtModuleLosses;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}