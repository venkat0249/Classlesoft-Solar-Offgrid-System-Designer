//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarOffgridSystemDesigner
{
    public partial class EditModuleInformation : Form
    {
        string mDbPath = Application.StartupPath + "/SolarOffgridDesigner_DB.db";
        SQLiteConnection mConn;
        UInt32 ItemID;
        public EditModuleInformation(PVModuleDBObject pvModuleDBEditObj)
        {
            InitializeComponent();
            ItemID = pvModuleDBEditObj.ItemID;
            txtModuleManufacturer.Text=Convert.ToString(pvModuleDBEditObj.CompanyName);
            txtModuleModel.Text=Convert.ToString(pvModuleDBEditObj.ModelNumber);
            txtModuleOtherinfo.Text=Convert.ToString(pvModuleDBEditObj.OtherText);
            comboModuleType.Text=Convert.ToString(pvModuleDBEditObj.ModuleType);
            txtModulePrice.Text=Convert.ToString(pvModuleDBEditObj.Price);
            txtModuleCurrency.Text=Convert.ToString(pvModuleDBEditObj.Currency);
            txtModulePowerOutput.Text=Convert.ToString(pvModuleDBEditObj.PowerOutput);
            txtModuleEfficiency.Text=Convert.ToString(pvModuleDBEditObj.ModuleEfficiency);
            txtModuleVmpp.Text=Convert.ToString(pvModuleDBEditObj.Vmpp);
            txtModuleImpp.Text=Convert.ToString(pvModuleDBEditObj.Impp);
            txtModuleVoc.Text=Convert.ToString(pvModuleDBEditObj.Voc);
            txtModuleIsc.Text=Convert.ToString(pvModuleDBEditObj.Isc);
            txtModuleTcoePmax.Text=Convert.ToString(pvModuleDBEditObj.TempCoePmax);
            txtModuleTcoeVoc.Text=Convert.ToString(pvModuleDBEditObj.TempCoeVoc);
            txtModuleTcoeIsc.Text=Convert.ToString(pvModuleDBEditObj.TempCoeIsc);
            txtModuleTcoeVmpp.Text=Convert.ToString(pvModuleDBEditObj.TempCoeVmpp);
            txtModuleLenght.Text=Convert.ToString(pvModuleDBEditObj.Length);
            txtModuleWidth.Text=Convert.ToString(pvModuleDBEditObj.Width);
            txtModuleThickness.Text=Convert.ToString(pvModuleDBEditObj.Thickness);
            txtModuleWeight.Text = Convert.ToString(pvModuleDBEditObj.Weight);
        }

        private void EditModuleInformation_Load(object sender, EventArgs e)
        {

        }

        private void btnModulesSaveToDB_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtModuleManufacturer.Text != "" && txtModuleModel.Text != "" && txtModulePowerOutput.Text != "" && txtModuleLenght.Text != "" && txtModuleWidth.Text != "" && txtModuleVoc.Text != "" && txtModuleVmpp.Text != "" && txtModuleTcoeVoc.Text != "" && txtModuleTcoeVmpp.Text != "" && txtModuleTcoeIsc.Text != "" && txtModuleImpp.Text != "" && txtModuleIsc.Text != "" && txtModuleEfficiency.Text != "")
                {
                    mConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;");
                    SQLiteCommand insertSQL = new SQLiteCommand("UPDATE PVModuleTable_v1 set CompanyName=@CompanyName,ModelNumber=@ModelNumber,OtherText=@OtherText,ModuleType=@ModuleType,Price=@Price,Currency=@Currency,PowerOutput=@PowerOutput,ModuleEfficiency=@ModuleEfficiency,Vmpp=@Vmpp,Impp=@Impp,Voc=@Voc,Isc=@Isc,TempCoePmax=@TempCoePmax,TempCoeVoc=@TempCoeVoc,TempCoeIsc=@TempCoeIsc,TempCoeVmpp=@TempCoeVmpp,Length=@Length,Width=@Width,Thickness=@Thickness,Weight=@Weight where ItemID=@ItemID", mConn);

                    insertSQL.Parameters.Add(new SQLiteParameter("@CompanyName", DbType.String) { Value = txtModuleManufacturer.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@ModelNumber", DbType.String) { Value = txtModuleModel.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@OtherText", DbType.String) { Value = txtModuleOtherinfo.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@ModuleType", DbType.String) { Value = comboModuleType.SelectedItem.ToString() });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Price", DbType.Double) { Value = txtModulePrice.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Currency", DbType.String) { Value = txtModuleCurrency.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PowerOutput", DbType.Double) { Value = txtModulePowerOutput.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@ModuleEfficiency", DbType.Double) { Value = txtModuleEfficiency.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Vmpp", DbType.Double) { Value = txtModuleVmpp.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Impp", DbType.Double) { Value = txtModuleImpp.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Voc", DbType.Double) { Value = txtModuleVoc.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Isc", DbType.Double) { Value = txtModuleIsc.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@TempCoePmax", DbType.Double) { Value = txtModuleTcoePmax.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@TempCoeVoc", DbType.Double) { Value = txtModuleTcoeVoc.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@TempCoeIsc", DbType.Double) { Value = txtModuleTcoeIsc.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@TempCoeVmpp", DbType.Double) { Value = txtModuleTcoeVmpp.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Length", DbType.Double, 32) { Value = txtModuleLenght.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Width", DbType.Double) { Value = txtModuleWeight.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Thickness", DbType.Double) { Value = txtModuleThickness.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Weight", DbType.Double) { Value = txtModuleWeight.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@ItemID", DbType.UInt32) { Value = ItemID });


                    mConn.Open();
                    insertSQL.ExecuteNonQuery();
                    MessageBox.Show("Record Updated!");
                    mConn.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                   // MessageBox.Show("please fill mandatory fields!");
                    lblMessage.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
