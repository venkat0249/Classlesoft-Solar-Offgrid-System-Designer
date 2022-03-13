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
    public partial class ModuleInterspacingParam : Form
    {
        public ModuleInterspacingParam()
        {
            InitializeComponent();
            txtLength.Text = Convert.ToString(Properties.Settings.Default["InterspaceLength"]);
            txtWidth.Text = Convert.ToString(Properties.Settings.Default["InterspaceWidth"]);
                       
        }
        //double Kt = 0.0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLength.Text != "" && txtWidth.Text != "")
            {
                Properties.Settings.Default["InterspaceLength"] = Convert.ToDouble(txtLength.Text);
                Properties.Settings.Default["InterspaceWidth"] = Convert.ToDouble(txtWidth.Text);

                Properties.Settings.Default.Save(); // Saves settings in application configuration file
                
            }
            else
            {
                //MessageBox.Show("No field should be empty!!!","Empty Field",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lblError.Visible = true;
            }
        }

        private void txtKa_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLength.Text, "  ^ [0-9]"))
            {
                txtLength.Text = "";
            }
        }
        private void txtKa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtKb_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtWidth.Text, "  ^ [0-9]"))
            {
                txtWidth.Text = "";
            }
        }


    }
}
