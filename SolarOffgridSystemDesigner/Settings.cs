using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarOffgridSystemDesigner
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private SolarOffgridSystemDesigner.InverterDBObject inverterDBObj = new SolarOffgridSystemDesigner.InverterDBObject();
        private SolarOffgridSystemDesigner.PVModuleDBObject pvModuleDBObj = new SolarOffgridSystemDesigner.PVModuleDBObject();
        string mDbPath = Application.StartupPath + "/SolarOffgridDesigner_DB.db";

        SQLiteConnection mConn;
        string FilePath_logo;

        private void btnModulesSaveToDB_Click(object sender, EventArgs e)
        {
            try
                {
            if (txtModuleManufacturer.Text != "" && txtModuleModel.Text != "" && txtModulePowerOutput.Text != "" && txtModuleLenght.Text != "" && txtModuleWidth.Text != "" && txtModuleVoc.Text != "" && txtModuleVmpp.Text != "" && txtModuleTcoeVoc.Text != "" && txtModuleTcoeVmpp.Text != "" && txtModuleTcoeIsc.Text != "" &&txtModuleImpp.Text!=""&&txtModuleIsc.Text!=""&&txtModuleEfficiency.Text!="" )
            { 
            pvModuleDBObj.CompanyName=txtModuleManufacturer.Text;
            pvModuleDBObj.ModelNumber=txtModuleModel.Text;
            pvModuleDBObj.OtherText=txtModuleOtherinfo.Text;
            pvModuleDBObj.ModuleType=comboModuleType.SelectedItem.ToString();
            pvModuleDBObj.Price=Convert.ToDouble(txtModulePrice.Text);
            pvModuleDBObj.Currency=txtModuleCurrency.Text;
            pvModuleDBObj.PowerOutput=Convert.ToDouble(txtModulePowerOutput.Text);
            pvModuleDBObj.ModuleEfficiency=Convert.ToDouble(txtModuleEfficiency.Text);
            pvModuleDBObj.Vmpp=Convert.ToDouble(txtModuleVmpp.Text);
            pvModuleDBObj.Impp=Convert.ToDouble(txtModuleImpp.Text);
            pvModuleDBObj.Voc=Convert.ToDouble(txtModuleVoc.Text);
            pvModuleDBObj.Isc=Convert.ToDouble(txtModuleIsc.Text);
            pvModuleDBObj.TempCoePmax=Convert.ToDouble(txtModuleTcoePmax.Text);
            pvModuleDBObj.TempCoeVoc=Convert.ToDouble(txtModuleTcoeVoc.Text);
            pvModuleDBObj.TempCoeIsc=Convert.ToDouble(txtModuleTcoeIsc.Text);
            pvModuleDBObj.TempCoeVmpp=Convert.ToDouble(txtModuleTcoeVmpp.Text);
            pvModuleDBObj.Length=Convert.ToDouble(txtModuleLenght.Text);
            pvModuleDBObj.Width=Convert.ToDouble(txtModuleWidth.Text);
            pvModuleDBObj.Thickness=Convert.ToDouble(txtModuleThickness.Text);
            pvModuleDBObj.Weight = Convert.ToDouble(txtModuleWeight.Text);

            InsertModuleIntoDB();
            }
            else
            {
                MessageBox.Show("Please fill all required fields!");
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertModuleIntoDB()
        {
            mConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;");
            
            
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO PVModuleTable_v1(CompanyName,ModelNumber,OtherText,ModuleType,Price,Currency,PowerOutput,ModuleEfficiency,Vmpp,Impp,Voc,Isc,TempCoePmax,TempCoeVoc,TempCoeIsc,TempCoeVmpp,Length,Width,Thickness,Weight) VALUES (@CompanyName,@ModelNumber,@OtherText,@ModuleType,@Price,@Currency,@PowerOutput,@ModuleEfficiency,@Vmpp,@Impp,@Voc,@Isc,@TempCoePmax,@TempCoeVoc,@TempCoeIsc,@TempCoeVmpp,@Length,@Width,@Thickness,@Weight)", mConn);
            insertSQL.Parameters.Add(new SQLiteParameter("@CompanyName",DbType.String){ Value = pvModuleDBObj.CompanyName });
            insertSQL.Parameters.Add(new SQLiteParameter("@ModelNumber", DbType.String){ Value = pvModuleDBObj.ModelNumber });
            insertSQL.Parameters.Add(new SQLiteParameter("@OtherText", DbType.String){ Value = pvModuleDBObj.OtherText });
            insertSQL.Parameters.Add(new SQLiteParameter("@ModuleType", DbType.String){ Value = pvModuleDBObj.ModuleType });
            insertSQL.Parameters.Add(new SQLiteParameter("@Price", DbType.Double){ Value = pvModuleDBObj.Price });
            insertSQL.Parameters.Add(new SQLiteParameter("@Currency", DbType.String) { Value = pvModuleDBObj.Currency });
            insertSQL.Parameters.Add(new SQLiteParameter("@PowerOutput", DbType.Double) { Value = pvModuleDBObj.PowerOutput });
            insertSQL.Parameters.Add(new SQLiteParameter("@ModuleEfficiency", DbType.Double) { Value = pvModuleDBObj.ModuleEfficiency });
            insertSQL.Parameters.Add(new SQLiteParameter("@Vmpp", DbType.Double) { Value = pvModuleDBObj.Vmpp });
            insertSQL.Parameters.Add(new SQLiteParameter("@Impp", DbType.Double) { Value = pvModuleDBObj.Impp });
            insertSQL.Parameters.Add(new SQLiteParameter("@Voc", DbType.Double) { Value = pvModuleDBObj.Voc });
            insertSQL.Parameters.Add(new SQLiteParameter("@Isc", DbType.Double) { Value = pvModuleDBObj.Isc });
            insertSQL.Parameters.Add(new SQLiteParameter("@TempCoePmax", DbType.Double) { Value = pvModuleDBObj.TempCoePmax });
            insertSQL.Parameters.Add(new SQLiteParameter("@TempCoeVoc", DbType.Double) { Value = pvModuleDBObj.TempCoeVoc });
            insertSQL.Parameters.Add(new SQLiteParameter("@TempCoeIsc", DbType.Double) { Value = pvModuleDBObj.TempCoeIsc });
            insertSQL.Parameters.Add(new SQLiteParameter("@TempCoeVmpp", DbType.Double) { Value = pvModuleDBObj.TempCoeVmpp });
            insertSQL.Parameters.Add(new SQLiteParameter("@Length", DbType.Double, 32) { Value = pvModuleDBObj.Length });
            insertSQL.Parameters.Add(new SQLiteParameter("@Width", DbType.Double) { Value = pvModuleDBObj.Width });
            insertSQL.Parameters.Add(new SQLiteParameter("@Thickness", DbType.Double) { Value = pvModuleDBObj.Thickness });
            insertSQL.Parameters.Add(new SQLiteParameter("@Weight", DbType.Double) { Value = pvModuleDBObj.Weight });
            
            try
            {
                mConn.Open();
                insertSQL.ExecuteNonQuery();
                MessageBox.Show("Insert Successful!");
                mConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertInverterIntoDB()
        {
            mConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;");
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO InveterTable_v1 (Manufacturer,ModelNumber,OtherInfo,InverterType,Price,Currency,RatedPower,PV_Maximum_DC_Voltage,PV_Max_MPP_Voltage,PV_Min_MPP_Voltage,PV_Maximum_Input_Current,Bat_Nominal_DC_Voltage,Dimension,Weight,PV_MPPTrackers,PV_MaxDCPower) VALUES (@Manufacturer,@ModelNumber,@OtherInfo,@InverterType,@Price,@Currency,@RatedPower,@PV_Maximum_DC_Voltage,@PV_Max_MPP_Voltage,@PV_Min_MPP_Voltage,@PV_Maximum_Input_Current,@Bat_Nominal_DC_Voltage,@Dimension,@Weight,@PV_MPPTrackers,@PV_MaxDCPower)", mConn);


            insertSQL.Parameters.Add(new SQLiteParameter("@Manufacturer", DbType.String) { Value = inverterDBObj.CompanyName });
            insertSQL.Parameters.Add(new SQLiteParameter("@ModelNumber", DbType.String){ Value = inverterDBObj.ModelNumber });
            insertSQL.Parameters.Add(new SQLiteParameter("@OtherInfo", DbType.String) { Value = inverterDBObj.OtherText });
            insertSQL.Parameters.Add(new SQLiteParameter("@InverterType", DbType.String){ Value = inverterDBObj.InverterType });
            insertSQL.Parameters.Add(new SQLiteParameter("@Price", DbType.Double){ Value = inverterDBObj.Price });
            insertSQL.Parameters.Add(new SQLiteParameter("@Currency", DbType.String) { Value = inverterDBObj.Currency });
            insertSQL.Parameters.Add(new SQLiteParameter("@RatedPower", DbType.Double) { Value = inverterDBObj.RatedPower });
            insertSQL.Parameters.Add(new SQLiteParameter("@PV_Maximum_DC_Voltage", DbType.Double) { Value = inverterDBObj.PV_Maximum_DC_Voltage });
            insertSQL.Parameters.Add(new SQLiteParameter("@PV_Max_MPP_Voltage", DbType.Double) { Value = inverterDBObj.PV_Max_MPP_Voltage });
            insertSQL.Parameters.Add(new SQLiteParameter("@PV_Min_MPP_Voltage", DbType.Double) { Value = inverterDBObj.PV_Min_MPP_Voltage });
            insertSQL.Parameters.Add(new SQLiteParameter("@PV_Maximum_Input_Current", DbType.Double) { Value = inverterDBObj.PV_Maximum_Input_Current });
            insertSQL.Parameters.Add(new SQLiteParameter("@Bat_Nominal_DC_Voltage", DbType.Double) { Value = inverterDBObj.Bat_Nominal_DC_Voltage });
            insertSQL.Parameters.Add(new SQLiteParameter("@Dimension", DbType.String) { Value = inverterDBObj.Dimension });
            insertSQL.Parameters.Add(new SQLiteParameter("@Weight", DbType.Double) { Value = inverterDBObj.Weight });
            insertSQL.Parameters.Add(new SQLiteParameter("@PV_MPPTrackers", DbType.Int16) { Value = inverterDBObj.PV_MPPTrackers });
            insertSQL.Parameters.Add(new SQLiteParameter("@PV_MaxDCPower", DbType.Double) { Value = inverterDBObj.PV_MaxDCPower });
            
            try
            {
                mConn.Open();
                insertSQL.ExecuteNonQuery();
                MessageBox.Show("Insert Successful!");
                mConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInvSaveToDB_Click(object sender, EventArgs e)
        {
            try{
                if (txtInvManufacturer.Text != "" && txtInvModel.Text != "" && txtInvRatedPower.Text != "" && txtInvMaxI.Text != "" && txtInvMaxVdc.Text != "" && txtInvMaxVmpp.Text != "" && txtInvMinVmpp.Text != "" && txtInvBatVdc.Text != "" && txtInvMaxInputPower.Text != "" && txtInvMppTrackers.Text != "")
            {
                inverterDBObj.CompanyName = txtInvManufacturer.Text;
                inverterDBObj.ModelNumber = txtInvModel.Text;
                inverterDBObj.OtherText = txtInvOtherinfo.Text;
                inverterDBObj.InverterType = Convert.ToString(comboInvType.SelectedItem) ;
                inverterDBObj.Price = Convert.ToDouble(txtInvPrice.Text);
                inverterDBObj.Currency = txtInvCurrency.Text;
                inverterDBObj.RatedPower = Convert.ToDouble(txtInvRatedPower.Text);
                inverterDBObj.Dimension = txtInvLenght.Text + "X" + txtInvWidth.Text + "X" + txtInvThickness.Text;
                inverterDBObj.Weight = Convert.ToDouble(txtInvWeight.Text);
                inverterDBObj.PV_MaxDCPower = Convert.ToDouble(txtInvMaxInputPower.Text);
                inverterDBObj.PV_Max_MPP_Voltage = Convert.ToDouble(txtInvMaxVmpp.Text);
                inverterDBObj.PV_Maximum_DC_Voltage = Convert.ToDouble(txtInvMaxVdc.Text);
                inverterDBObj.PV_Maximum_Input_Current = Convert.ToDouble(txtInvMaxI.Text);
                inverterDBObj.PV_Min_MPP_Voltage = Convert.ToDouble(txtInvMinVmpp.Text);
                inverterDBObj.Bat_Nominal_DC_Voltage = Convert.ToDouble(txtInvBatVdc.Text);
                inverterDBObj.PV_MPPTrackers = Convert.ToUInt16(txtInvMppTrackers.Text);
                InsertInverterIntoDB();
            }
            else
            {
                MessageBox.Show("Please fill all required fields!");
            }
        }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenSetSave_Click(object sender, EventArgs e)
        {
            try
            {
                sfBarcode1.Text = txtGenSetCompanyWebsite.Text;
                SizeF baSize = new SizeF(90, 90);
                Image barImg = sfBarcode1.ToImage(baSize);
                barImg.Save("barcode.png");
                Bitmap bm = new Bitmap(imgCompanyLogo.Image);
                Image img = (Image)bm;
                //imgCompanyLogo.Image = Image.FromFile("CompanyLogo1.png");
                imgCompanyLogo.Image.Save("CompanyLogo.png", ImageFormat.Png);

                Properties.Settings.Default["ReportCompAddress"] = txtCompanyContactAdd.Text;
                Properties.Settings.Default["ReportCompWebsite"] = txtGenSetCompanyWebsite.Text;
                MessageBox.Show("Settings Saved Successfully!");
                imgCompanyLogo.Image = Image.FromFile("CompanyLogo.png");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenSetCompanyLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialogCompanyLogo.ShowDialog() == DialogResult.OK)
            {
                FilePath_logo = openFileDialogCompanyLogo.FileName;
                imgCompanyLogo.Image = Image.FromFile(FilePath_logo);
                
            }

        }

        private void Settings_Load(object sender, EventArgs e)
        {

            try
            {
                txtCompanyContactAdd.Text = Convert.ToString(Properties.Settings.Default["ReportCompAddress"]);
                txtGenSetCompanyWebsite.Text = Convert.ToString(Properties.Settings.Default["ReportCompWebsite"]);
                byte[] bytes = System.IO.File.ReadAllBytes("CompanyLogo.png");
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                imgCompanyLogo.Image = Image.FromStream(ms);
                comboInvType.SelectedIndex = 0;
                comboModuleType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPgOtherSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnModulesCancel_Click(object sender, EventArgs e)
        {
            txtModuleManufacturer.Text="";
            txtModuleModel.Text="";
            txtModuleOtherinfo.Text="";
            txtModulePrice.Text="0.0";
            txtModuleCurrency.Text="€";
            txtModulePowerOutput.Text="0.0";
            txtModuleEfficiency.Text = "0.0";
            txtModuleVmpp.Text = "0.0";
            txtModuleImpp.Text = "0.0";
            txtModuleVoc.Text = "0.0";
            txtModuleIsc.Text = "0.0";
            txtModuleTcoePmax.Text = "0.0";
            txtModuleTcoeVoc.Text = "0.0";
            txtModuleTcoeIsc.Text = "0.0";
            txtModuleTcoeVmpp.Text = "0.0";
            txtModuleLenght.Text = "0.0";
            txtModuleWidth.Text = "0.0";
            txtModuleThickness.Text = "0.0";
            txtModuleWeight.Text = "0.0";
        }

        private void btnInvCancel_Click(object sender, EventArgs e)
        {
            txtInvManufacturer.Text="";
            txtInvModel.Text="";
            txtInvOtherinfo.Text="";
            txtInvPrice.Text = "0.0";
            txtInvCurrency.Text = "€";
            txtInvLenght.Text = "0.0";
            txtInvRatedPower.Text = "0.0";
            txtInvWidth.Text = "0.0";
            txtInvThickness.Text = "0.0";
            txtInvWeight.Text = "0.0";
            txtInvMaxVmpp.Text = "0.0";
            txtInvMaxVdc.Text = "0.0";
            txtInvMaxI.Text = "0.0";
            txtInvMinVmpp.Text = "0.0";
            txtInvBatVdc.Text = "0.0";
        }

        private void btnExportToolbase_Click(object sender, EventArgs e)
        {
            try
            {
                
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    string _sSuggestedName = "SolarOffgridDesigner_Exported";
                    saveFileDialog1.Filter = "*DB file (*.db)|*.db";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.FileName = _sSuggestedName;
                    //FolderBrowserDialog selectFolder = new FolderBrowserDialog();
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy("SolarOffgridDesigner_DB.db", saveFileDialog1.FileName, true);
                        MessageBox.Show("File Export Successful!");
                    }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImportToolbase_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("This action will replace database file immediately independent of \'save settings button\' action. It is strongly recommend to export existing database before replacing. Do you want to continue with replacement? ", "Warning!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    OpenFileDialog selectFile = new OpenFileDialog();
                    selectFile.Title = "Select Database File";
                    selectFile.Filter = "*DB files (*.db)|*.db";
                    if (selectFile.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(selectFile.FileName, "SolarOffgridDesigner_DB.db", true);
                        MessageBox.Show("Database replacement Successful!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewInvData_Click(object sender, EventArgs e)
        {
            try
            {
                using (InverterSelection dialogModuleSelect = new InverterSelection(1000,200,1200,1000,800,true))
                {
                    if (dialogModuleSelect.ShowDialog() == DialogResult.OK)
                    {


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewModleData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SolarModuleSelection dialogModuleSelect = new SolarModuleSelection(true))
                {
                    if (dialogModuleSelect.ShowDialog() == DialogResult.OK)
                    {


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
