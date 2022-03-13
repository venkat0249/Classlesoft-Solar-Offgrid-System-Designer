using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolarOffgridSystemDesigner
{
    public partial class SystemLossParameters : Form
    {
        public SystemLossParameters()
        {
            InitializeComponent();

            txtKa.Text = Convert.ToString(Properties.Settings.Default["Ka"]);
            txtKb.Text = Convert.ToString(Properties.Settings.Default["Kb"]);
            txtKc.Text = Convert.ToString(Properties.Settings.Default["Kc"]);
            txtKr.Text = Convert.ToString(Properties.Settings.Default["Kr"]);
            txtKx.Text = Convert.ToString(Properties.Settings.Default["Kx"]);
            txtDaut.Text = Convert.ToString(Properties.Settings.Default["Daut"]);
            txtPd.Text = Convert.ToString(Properties.Settings.Default["Pd"]);
            txtModuleLosses.Text = Convert.ToString(Properties.Settings.Default["ModuleLosses"]);
        }
        double Kt = 0.0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKa.Text != "" && txtKb.Text != "" && txtKc.Text != "" && txtKr.Text != "" && txtKx.Text != "" && txtDaut.Text != "" && txtPd.Text != "")
            {
                Kt = Math.Round((100 - (Convert.ToDouble(txtKb.Text) + Convert.ToDouble(txtModuleLosses.Text) + Convert.ToDouble(txtKc.Text) + Convert.ToDouble(txtKr.Text)
                    + Convert.ToDouble(txtKx.Text))) * (100 - (Convert.ToDouble(txtKa.Text) * Convert.ToDouble(txtDaut.Text) / Convert.ToDouble(txtPd.Text))), 3) ;

                Properties.Settings.Default["Ka"] = Convert.ToDouble(txtKa.Text);
                Properties.Settings.Default["Kb"] = Convert.ToDouble(txtKb.Text);
                Properties.Settings.Default["Kc"] = Convert.ToDouble(txtKc.Text);
                Properties.Settings.Default["Kr"] = Convert.ToDouble(txtKr.Text);
                Properties.Settings.Default["Kx"] = Convert.ToDouble(txtKx.Text);
                Properties.Settings.Default["Daut"] = Convert.ToDouble(txtDaut.Text);
                Properties.Settings.Default["Pd"] = Convert.ToDouble(txtPd.Text);
                Properties.Settings.Default["ModuleLosses"] = Convert.ToDouble(txtModuleLosses.Text);
                Properties.Settings.Default["Kt"] = Kt/10000;
                Properties.Settings.Default.Save(); // Saves settings in application configuration file
            }
            else
            {
                //MessageBox.Show("No field should be empty!!!","Empty Field",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lblError.Visible = true;
            }
        }

        private void SystemLossParameters_Load(object sender, EventArgs e)
        {

        }

       

    }
}
