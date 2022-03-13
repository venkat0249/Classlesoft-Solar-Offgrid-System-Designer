//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using RestSharp;
using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.SqlServer.Types;
namespace SolarOffgridSystemDesigner
{
    public partial class MainForm : Form
    {
        string mDbPath = Application.StartupPath + "/SolarOffgridDesigner_DB.db";
        SQLiteConnection mConnRad = new SQLiteConnection("Data Source=SolarOffgridDesignerRadiationData.db;Version=3;");
        SQLiteDataAdapter radAdapter;
        DataTable radTable;
        GeneralInfo genInfoObj = new GeneralInfo();
        LoadProfileObject loadProfileObj = new LoadProfileObject();
        LocationAndRadiationObject locationAndRadiationObj = new LocationAndRadiationObject();
        List<LoadProfileListObject> loadProfileListObj = new List<LoadProfileListObject>();
        LoadProfileListObject LoadProfileListClass = new LoadProfileListObject();
        PVModuleDBObject pvModuleDBObj2 = new PVModuleDBObject();
        ModuleSelectionObject moduleSelectObj = new ModuleSelectionObject();
        InveterSelectionObject inverterSelectObj = new InveterSelectionObject();
        InverterDBObject inverterDBObj = new InverterDBObject();
        BatteryDimensioningObject batteryDimensionObj = new BatteryDimensioningObject();
        ReportSettingsObject reportSettingsObj = new ReportSettingsObject();
        IrradianceObject irradianceObj = new IrradianceObject();
        LoadObject LoadObj = new LoadObject();
        GenObject GenObj = new GenObject();
        List<string> lstMonths = new List<string>(new string[] { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" });
        List<Single> lstMonthlyGeneration;
        List<Single> lstMonthlyLoad;
        UInt16 i = 0;
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            try
            {
                reportSettingsObj.CompanyAddress = Convert.ToString(Properties.Settings.Default["ReportCompAddress"]);
                reportSettingsObj.CompanyWebsite = Convert.ToString(Properties.Settings.Default["ReportCompWebsite"]);
                reportSettingsObj.CompanyLogo = "file:///" + Application.StartupPath + "/CompanyLogo.png";
                reportSettingsObj.QRCode = "file:///" + Application.StartupPath + "/barcode.png";
                reportSettingsObj.GenChartLoc = "file:///" + Application.StartupPath + "/genprofile.png";
                loadProfileObj.Kt = Convert.ToDouble(Properties.Settings.Default["Kt"]);
                locationAndRadiationObj.APIKey_NREL = Convert.ToString(Properties.Settings.Default["APIKey_NREL"]);
                //moduleSelectObj.InterspaceLength = Convert.ToDouble(Properties.Settings.Default["InterspaceLength"]);
                comboLoadType.SelectedIndex = 0;
                loadProfileObj.Method = "Method-1";
                locationAndRadiationObj.Method = "Radiation Database (NASA)";
                //tabControlMain.Size = new Size(0, 1);
                //tabControlMain.SizeMode = TabSizeMode.Fixed;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgHome"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = false;
                    imgNavLoc.Visible = false;
                    imgNavModule.Visible = false;
                    imgNavInv.Visible = false;
                    imgNavBat.Visible = false;
                    imgNavResults.Visible = false;
                    imgNavReport.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgLoadProfile"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = false;
                    imgNavModule.Visible = false;
                    imgNavInv.Visible = false;
                    imgNavBat.Visible = false;
                    imgNavResults.Visible = false;
                    imgNavReport.Visible = false;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }
            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgLocationInfo"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = true;
                    imgNavModule.Visible = false;
                    imgNavInv.Visible = false;
                    imgNavBat.Visible = false;
                    imgNavResults.Visible = false;
                    imgNavReport.Visible = false;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }
            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgModuleSelection"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = true;
                    imgNavModule.Visible = true;
                    imgNavInv.Visible = false;
                    imgNavBat.Visible = false;
                    imgNavResults.Visible = false;
                    imgNavReport.Visible = false;
                    lblMSReqMinkWp.Text = locationAndRadiationObj.KwpRequired.ToString();

                    if (moduleSelectObj.isSelected)
                    {
                        //MSSelectionCalculations();
                        //txtMSNumModuleReq.Text = Convert.ToString(moduleSelectObj.NumberOfModule);
                        //lblMSTotArea.Text = moduleSelectObj.RequriedArea.ToString();
                        //lblMSTotPower.Text = moduleSelectObj.TotalPower.ToString();
                        //checkSpaceConstraint();
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
                
            }
            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgInverter"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = true;
                    imgNavModule.Visible = true;
                    imgNavInv.Visible = true;
                    imgNavBat.Visible = false;
                    imgNavResults.Visible = false;
                    imgNavReport.Visible = false;

                    inverterSelectObj.VmppMin = pvModuleDBObj2.Vmpp * (1 + pvModuleDBObj2.TempCoeVmpp * 0.01 * 45);
                    inverterSelectObj.VmppMax = pvModuleDBObj2.Vmpp * (1 - pvModuleDBObj2.TempCoeVmpp * 0.01 * 35);
                    inverterSelectObj.VocMax = pvModuleDBObj2.Voc * (1 - pvModuleDBObj2.TempCoeVmpp * 0.01 * 35);
                    inverterSelectObj.ReqPowerMin = moduleSelectObj.TotalPower * 0.8 * 1000;
                    inverterSelectObj.ReqPowerMax = moduleSelectObj.TotalPower * 1.2 * 1000;
                    //aGauge1.MinValue = Convert.ToSingle(inverterSelectObj.VmppMin);
                    //aGauge1.MaxValue = Convert.ToSingle(inverterSelectObj.VmppMax);
                    if (inverterDBObj.RatedPower > 0.0)
                        InverterSectionRevalidation();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }


            }

            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgBattery"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = true;
                    imgNavModule.Visible = true;
                    imgNavInv.Visible = true;
                    imgNavBat.Visible = true;
                    imgNavResults.Visible = false;
                    imgNavReport.Visible = false;
                    //btnBatNext.Enabled = false;

                    lblBatDailyLoad.Text = Convert.ToString(Math.Round(loadProfileObj.TotalEnergyNeededWithLoss, 3)) + " kWh";
                    if (loadProfileObj.Method == "Method-1")
                    {

                        lblBatDayLoad.Text = Convert.ToString(Math.Round(loadProfileObj.TotalDayEnergyRequirement / loadProfileObj.Kt, 3)) + " kWh";
                        lblBatNightLoad.Text = Convert.ToString(Math.Round(loadProfileObj.TotalNightEnergyRequirement / loadProfileObj.Kt, 3)) + " kWh";
                    }
                    else
                    {
                        radioBatDayLoad.Enabled = false;
                        radioBatNightLoad.Enabled = false;
                    }
                    RadioBatteryChanged();
                    CopyBatValuesToObj();
                    BatteryCalculations();
                    SetBatteryLabels();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }

            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgReport"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = true;
                    imgNavModule.Visible = true;
                    imgNavInv.Visible = true;
                    imgNavBat.Visible = true;
                    imgNavResults.Visible = true;
                    imgNavReport.Visible = true;

                    GeneralInfoBindingSource.DataSource = genInfoObj;
                    InveterSelectionObjectBindingSource.DataSource = inverterSelectObj;
                    ModuleSelectionObjectBindingSource.DataSource = moduleSelectObj;
                    LoadProfileObjectBindingSource.DataSource = loadProfileObj;
                    BatteryDimensioningObjectBindingSource.DataSource = batteryDimensionObj;
                    PVModuleDBObjectBindingSource.DataSource = pvModuleDBObj2;
                    InverterDBObjectBindingSource.DataSource = inverterDBObj;
                    ReportSettingsObjectBindingSource.DataSource = reportSettingsObj;
                    LocationAndRadiationObjectBindingSource.DataSource = locationAndRadiationObj;
                    reportViewer1.LocalReport.EnableExternalImages = true;

                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }

            if (tabControlMain.SelectedTab == tabControlMain.TabPages["tabPgResults"])//your specific tabname
            {
                try
                {
                    imgNavHome.Visible = true;
                    imgNavLoad.Visible = true;
                    imgNavLoc.Visible = true;
                    imgNavModule.Visible = true;
                    imgNavInv.Visible = true;
                    imgNavBat.Visible = true;
                    imgNavResults.Visible = true;
                    imgNavReport.Visible = false;

                    lblResultsBattery.Text = batteryDimensionObj.FinalCapacity.ToString() + "kWh";
                    lblResultsInverter.Text = inverterDBObj.RatedPower.ToString() + "W";
                    lblResultsLoad.Text = loadProfileObj.TotalEnergyNeedWithOutLoss.ToString() + "kWh";
                    lblResultsPVModule.Text = moduleSelectObj.TotalPower.ToString() + " kWp";


                    if (locationAndRadiationObj.Method == "Radiation Database (NASA)")
                    {
                        chartResultsGenProfile1.Visible = true;
                        chartResultsGenProfile1.Series.Clear();
                        ChartSeries series1 = new ChartSeries("Generation");
                        for (int i = 0; i < 12; i++)
                            series1.Points.Add(lstMonths[i], Convert.ToDouble(lstMonthlyGeneration[i]));
                        series1.Type = ChartSeriesType.Column;
                        series1.SortPoints = false;
                        chartResultsGenProfile1.Series.Add(series1);

                        ChartSeries series2 = new ChartSeries("Load");
                        for (int i = 0; i < 12; i++)
                            series2.Points.Add(lstMonths[i], Convert.ToDouble(lstMonthlyLoad[i]));
                        series2.Type = ChartSeriesType.StackingColumn;
                        series2.SortPoints = false;
                        chartResultsGenProfile1.Series.Add(series2);
                        chartResultsGenProfile1.SaveImage("genprofile.png");
                    }
                    else
                    {
                        chartResultsGenProfile1.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnHomeNext_Click(object sender, EventArgs e)
        {
            try
            {
                genInfoObj.AdditionalDetails = txtHomeAddiDetails.Text;
                genInfoObj.CustomerContactDetails = txtHomeCustContact.Text;
                genInfoObj.CustomerName = txtHomeCustName.Text;
                genInfoObj.ProjectDate = txtHomeProjDate.Text;
                genInfoObj.ProjectName = txtHomeProjName.Text;
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgLoadProfile"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

       
        private void radioButtonsLP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioBtnLPMethod1.Checked)
                {
                    loadProfileObj.Method = "Method-1";
                    gBoxAppliances.Enabled = true;
                    dataGVLoadProfile.Enabled = true;
                    btnLPDeleteSelected.Enabled = true;
                    panelLPMethod2.Visible = false;


                }
                else if (radioBtnLPMethod2.Checked)
                {
                    loadProfileObj.Method = "Method-2";
                    gBoxAppliances.Enabled = false;
                    dataGVLoadProfile.Enabled = false;
                    btnLPDeleteSelected.Enabled = false;
                    panelLPMethod2.Visible = true;
                    calculateCustomLP();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }
        private void btnLPSaveM2_Click(object sender, EventArgs e)
        {
            try
            {
                calculateCustomLP();
            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.Message);
            }
        }

        public void calculateCustomLP()
        {
            try
            {
                loadProfileObj.TotalEnergyNeedWithOutLoss = Convert.ToDouble(txtLPEnergyReq.Text);
                loadProfileObj.TotalEnergyNeededWithLoss = Math.Round((loadProfileObj.TotalEnergyNeedWithOutLoss) / (loadProfileObj.Kt), 3);
                lblLPFinalEnergy.Text = Convert.ToString(loadProfileObj.TotalEnergyNeededWithLoss);
                lblLPLossFactor.Text = Convert.ToString(loadProfileObj.Kt);
                lblLPTotDayEnergy.Text = "-";
                lblLPTotNightEnergy.Text = "-";
                lblLPTotEnerWoutLoss.Text = txtLPEnergyReq.Text;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLPDayOpHours.Text != "" && txtLPRoom.Text != "" && txtNightOpHours.Text != "" && txtLPEquipQuantity.Text != "" && txtRatedPower.Text != "" && txtLPEquipment.Text != "")
                {
                    //loadProfileObj.SystemVoltage = Convert.ToDouble(txtSystemVoltage.Text);
                    LoadProfileListClass.ItemID = i;
                    LoadProfileListClass.BuildingSegment = txtLPRoom.Text;
                    LoadProfileListClass.DayOperatingHours = Convert.ToSingle(txtLPDayOpHours.Text);
                    LoadProfileListClass.NightOperatingHours = Convert.ToSingle(txtNightOpHours.Text);
                    LoadProfileListClass.NumberOfEquipment = Convert.ToUInt16(txtLPEquipQuantity.Text);
                    LoadProfileListClass.RatedPower = Convert.ToDouble(txtRatedPower.Text);
                    LoadProfileListClass.LoadType = comboLoadType.SelectedItem.ToString();
                    LoadProfileListClass.Equipment = txtLPEquipment.Text;
                    LoadProfileListClass.AdjustedPower = LoadProfileListClass.RatedPower * LoadProfileListClass.NumberOfEquipment;
                    //LoadProfileListClass.CurrentOfSystem = LoadProfileListClass.AdjustedPower / loadProfileObj.SystemVoltage;
                    LoadProfileListClass.DayEnergyRequirement = LoadProfileListClass.DayOperatingHours * LoadProfileListClass.NumberOfEquipment * LoadProfileListClass.RatedPower;
                    LoadProfileListClass.NightEnergyRequirement = LoadProfileListClass.NightOperatingHours * LoadProfileListClass.NumberOfEquipment * LoadProfileListClass.RatedPower;

                    loadProfileListObj.Add(new LoadProfileListObject(LoadProfileListClass.ItemID, LoadProfileListClass.NumberOfEquipment, LoadProfileListClass.DayOperatingHours,
                        LoadProfileListClass.NightOperatingHours, LoadProfileListClass.BuildingSegment, "", LoadProfileListClass.Equipment, "", LoadProfileListClass.RatedPower,
                        LoadProfileListClass.AdjustedPower, LoadProfileListClass.CurrentOfSystem, LoadProfileListClass.DayEnergyRequirement, LoadProfileListClass.NightEnergyRequirement));
                    dataGVLoadProfile.DataSource = null;
                    dataGVLoadProfile.AutoGenerateColumns = false;
                    dataGVLoadProfile.Columns[0].DataPropertyName = "ItemID";
                    dataGVLoadProfile.Columns[1].DataPropertyName = "BuildingSegment";
                    dataGVLoadProfile.Columns[2].DataPropertyName = "Equipment";
                    dataGVLoadProfile.Columns[3].DataPropertyName = "LoadType";
                    dataGVLoadProfile.Columns[4].DataPropertyName = "RatedPower";
                    dataGVLoadProfile.Columns[5].DataPropertyName = "DayOperatingHours";
                    dataGVLoadProfile.Columns[6].DataPropertyName = "NightOperatingHours";
                    dataGVLoadProfile.DataSource = loadProfileListObj;
                    dataGVLoadProfile.Refresh();
                    calculateLP();
                    updateLPLabels();
                    i++;
                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch (Exception ex)
            {
                
                       MessageBox.Show(ex.Message);
            }
        }

        private void btnLPDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGVLoadProfile.SelectedRows)
                {
                    //dataGVLoadProfile.Rows.RemoveAt(item.Index);
                    //var itemToRemove = Convert.ToUInt16(dataGVLoadProfile.SelectedRows[item.Index].Cells[0].Value);
                    loadProfileListObj.RemoveAt(Convert.ToUInt16(item.Index));
                    dataGVLoadProfile.DataSource = "";
                    //loadProfileListObj.RemoveAt(
                    //Convert.ToUInt16(dataGVLoadProfile.SelectedRows[item.Index].Cells[0]);
                }
                dataGVLoadProfile.DataSource = loadProfileListObj;
                dataGVLoadProfile.Refresh();
                calculateLP();
                updateLPLabels();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        public void calculateLP()
        {
            try
            {
                loadProfileObj.Pmax = Math.Round(loadProfileListObj.Sum(item => item.AdjustedPower), MidpointRounding.AwayFromZero);
                loadProfileObj.TotalCurrentOfSystem = Math.Round(loadProfileListObj.Sum(item => item.CurrentOfSystem), 2);
                loadProfileObj.TotalDayEnergyRequirement = Math.Round((loadProfileListObj.Sum(item => item.DayEnergyRequirement) / 1000), 3);
                loadProfileObj.TotalNightEnergyRequirement = Math.Round((loadProfileListObj.Sum(item => item.NightEnergyRequirement) / 1000), 3);
                loadProfileObj.TotalEnergyNeedWithOutLoss = Math.Round((loadProfileObj.TotalDayEnergyRequirement + loadProfileObj.TotalNightEnergyRequirement), 3);
                loadProfileObj.TotalEnergyNeededWithLoss = Math.Round((loadProfileObj.TotalEnergyNeedWithOutLoss) / (loadProfileObj.Kt), 3);

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        public void updateLPLabels()
        {
            try
            {
                lblLPTotDayEnergy.Text = Convert.ToString(loadProfileObj.TotalDayEnergyRequirement);
                //lblLPTotCurrent.Text = Convert.ToString(loadProfileObj.TotalCurrentOfSystem);
                lblLPTotNightEnergy.Text = Convert.ToString(loadProfileObj.TotalNightEnergyRequirement);
                //lblLPPmax.Text = Convert.ToString(loadProfileObj.Pmax);
                lblLPTotEnerWoutLoss.Text = Convert.ToString(loadProfileObj.TotalEnergyNeedWithOutLoss);
                lblLPLossFactor.Text = Convert.ToString(loadProfileObj.Kt);
                lblLPFinalEnergy.Text = Convert.ToString(loadProfileObj.TotalEnergyNeededWithLoss) + " kWh";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLPNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadProfileObj.TotalEnergyNeededWithLoss != 0.0)
                {
                    if (radioBtnLPMethod1.Checked)
                        loadProfileObj.Method = "Method-1";
                    if (radioBtnLPMethod2.Checked)
                        loadProfileObj.Method = "Method-2";
                    tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgLocationInfo"];
                    //for chart in results tab
                    ComputeLoadReqArray();
                }
                else
                    MessageBox.Show("Invalid Load!!!");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }


        private void btnLPLossParams_Click(object sender, EventArgs e)
        {
            try
            {
                using (SystemLossParameters dialogLossParam = new SystemLossParameters())
                {

                    if (dialogLossParam.ShowDialog() == DialogResult.OK)
                    {
                        if (loadProfileObj.Method == "Method-1")
                        {
                            lblLPLossFactor.Text = Convert.ToString(Properties.Settings.Default["Kt"]);
                            loadProfileObj.Kt = Convert.ToDouble(Properties.Settings.Default["Kt"]);
                            calculateLP();
                            updateLPLabels();
                        }
                        else if (loadProfileObj.Method == "Method-2")
                        {
                            lblLPLossFactor.Text = Convert.ToString(Properties.Settings.Default["Kt"]);
                            loadProfileObj.Kt = Convert.ToDouble(Properties.Settings.Default["Kt"]);
                            loadProfileObj.TotalEnergyNeededWithLoss = Math.Round((loadProfileObj.TotalEnergyNeedWithOutLoss) / (loadProfileObj.Kt), 3);
                            lblLPFinalEnergy.Text = Convert.ToString(loadProfileObj.TotalEnergyNeededWithLoss);
                            lblLPLossFactor.Text = Convert.ToString(loadProfileObj.Kt);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLPBack_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgHome"];
        }


        /// <summary>
        /// Location and SOlar Irradiation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void radioButtonsLocMethod_CheckedChanged(object sender, EventArgs e)
        {
            //RadioButton radioButton = sender as RadioButton;

            if (radioLocMethod1.Checked)
            {
                gBoxLocCustomData.Enabled = false;
                gBoxLocSearchOnline.Enabled = true;
                gBoxLocSolarRad.Enabled = true;
                locationAndRadiationObj.Method = "Radiation Database (NASA)";
            }
            else if (radioLocMethod2.Checked)
            {
                gBoxLocCustomData.Enabled = true;
                gBoxLocSolarRad.Enabled = false;
                gBoxLocSearchOnline.Enabled = false;
                locationAndRadiationObj.Method = "Custom Data";
            }
            

        }
        private void radioButtonsLocOnline_CheckedChanged(object sender, EventArgs e)
        {
            //RadioButton radioButton = sender as RadioButton;

             if (radioLocTitledLatitude.Checked)
            {
                txtLocTilt.Text = txtLocLatitude.Text;
                //txtLocAzimuth.Enabled = false;
            }
            else if (radioLocOptiTilt.Checked)
            {
                ////txtLocTilt.Enabled = false;
                //txtLocAzimuth.Enabled = false;
            }
            else if (radioLocCustomTilt.Checked)
            {
                //txtLocTilt.Enabled = true;
                //txtLocAzimuth.Enabled = true;
            }

        }

        private void btnLocCustomSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLocNameOfLoc2.Text != "" && txtLocCustomKwh_Kwp.Text != "" && txtLocConversEff.Text != "" && txtLocSlopeCorrec.Text != "" && txtLocAzimuthCorrec.Text != "")
                {
                    locationAndRadiationObj.NameOfLoc = txtLocNameOfLoc2.Text;
                    locationAndRadiationObj.Kwh_Kwp = Convert.ToDouble(txtLocCustomKwh_Kwp.Text);
                    locationAndRadiationObj.PanelConversionEff = Convert.ToDouble(txtLocConversEff.Text);
                    locationAndRadiationObj.SlopeCorrection = Convert.ToDouble(txtLocSlopeCorrec.Text);
                    locationAndRadiationObj.AzimuthCorrection = Convert.ToDouble(txtLocAzimuthCorrec.Text);

                    if (locationAndRadiationObj.Kwh_Kwp > 0.0 && locationAndRadiationObj.PanelConversionEff > 0.0 && locationAndRadiationObj.SlopeCorrection > 0 && locationAndRadiationObj.AzimuthCorrection > 0)
                    {
                        locationAndRadiationObj.KwpRequired = (loadProfileObj.TotalEnergyNeededWithLoss) / (locationAndRadiationObj.Kwh_Kwp * locationAndRadiationObj.PanelConversionEff * locationAndRadiationObj.SlopeCorrection * locationAndRadiationObj.AzimuthCorrection);
                        tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgModuleSelection"];
                    }
                    else
                    {
                        MessageBox.Show("Invalid values detected!");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }


        }


        private void locTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadRadData_Click(object sender, EventArgs e)
        {
        
        }

        private void btnLocOnlineSave_Click(object sender, EventArgs e)
        {
            try
            {
                locationAndRadiationObj.Latitude = Math.Floor(Convert.ToDouble(txtLocLatitude.Text));
                locationAndRadiationObj.Longitude = Math.Floor(Convert.ToDouble(txtLocLongitude.Text));
                string queryString = String.Format("SELECT * FROM LatTiltedRadTbl_NASA where Lat ={0} and Lon ={1};", locationAndRadiationObj.Latitude.ToString(), locationAndRadiationObj.Longitude.ToString());
                radAdapter = new SQLiteDataAdapter(queryString, mConnRad);
                radTable = new DataTable();

                radAdapter.Fill(radTable);
                gdViewRadData.Columns[0].DataPropertyName = "Jan";
                gdViewRadData.Columns[1].DataPropertyName = "Feb";
                gdViewRadData.Columns[2].DataPropertyName = "Mar";
                gdViewRadData.Columns[3].DataPropertyName = "Apr";
                gdViewRadData.Columns[4].DataPropertyName = "May";
                gdViewRadData.Columns[5].DataPropertyName = "Jun";
                gdViewRadData.Columns[6].DataPropertyName = "Jul";
                gdViewRadData.Columns[7].DataPropertyName = "Aug";
                gdViewRadData.Columns[8].DataPropertyName = "Sep";
                gdViewRadData.Columns[9].DataPropertyName = "Oct";
                gdViewRadData.Columns[10].DataPropertyName = "Nov";
                gdViewRadData.Columns[11].DataPropertyName = "Dec";
                gdViewRadData.Columns[12].DataPropertyName = "Ann";
                gdViewRadData.AutoGenerateColumns = false;
                gdViewRadData.DataSource = radTable;

                //copy irradiation data for generation profile and graphs
                irradianceObj.Jan = Convert.ToSingle(radTable.Rows[0]["Jan"]);
                irradianceObj.Feb = Convert.ToSingle(radTable.Rows[0]["Feb"]);
                irradianceObj.Mar = Convert.ToSingle(radTable.Rows[0]["Mar"]);
                irradianceObj.Apr = Convert.ToSingle(radTable.Rows[0]["Apr"]);
                irradianceObj.May = Convert.ToSingle(radTable.Rows[0]["May"]);
                irradianceObj.Jun = Convert.ToSingle(radTable.Rows[0]["Jun"]);
                irradianceObj.Jul = Convert.ToSingle(radTable.Rows[0]["Jul"]);
                irradianceObj.Aug = Convert.ToSingle(radTable.Rows[0]["Aug"]);
                irradianceObj.Sep = Convert.ToSingle(radTable.Rows[0]["Sep"]);
                irradianceObj.Oct = Convert.ToSingle(radTable.Rows[0]["Oct"]);
                irradianceObj.Nov = Convert.ToSingle(radTable.Rows[0]["Nov"]);
                irradianceObj.Dec = Convert.ToSingle(radTable.Rows[0]["Dec"]);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLocRadDataNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdViewRadData.Rows.Count > 0)
                {
                    if (radioLocWorstMon.Checked)
                    {
                        double minValue = 1000;
                        for (int i = 0; i < gdViewRadData.ColumnCount; i++)
                        {
                            if (Convert.ToDouble(gdViewRadData.Rows[0].Cells[i].FormattedValue) < minValue)
                                minValue = Convert.ToDouble(gdViewRadData.Rows[0].Cells[i].FormattedValue);
                        }
                        locationAndRadiationObj.Kwh_Kwp = minValue;
                    }
                    else if (radioLocAnnualAvg.Checked)
                    {
                        locationAndRadiationObj.Kwh_Kwp = Convert.ToDouble(gdViewRadData.Rows[0].Cells["Ann"].FormattedValue);
                    }
                    else
                    {
                        locationAndRadiationObj.Kwh_Kwp = Convert.ToDouble(gdViewRadData.Rows[0].Cells[comboLocMonth.SelectedItem.ToString()].FormattedValue);
                    }

                    locationAndRadiationObj.KwpRequired = Math.Round((loadProfileObj.TotalEnergyNeededWithLoss) / (locationAndRadiationObj.Kwh_Kwp), 2);
                    tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgModuleSelection"];
                    
                }
                else
                {
                    MessageBox.Show("Radiation data is missing!!! Did you click load data button?");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLocBack1_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgLoadProfile"];
        }
        private void btnLocBack2_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgLoadProfile"];
        }

        private void CalculateEstimatedGeneration(double pVCapacity, double lossFactor)
        {

            try
            {
                GenObj.Jan = Convert.ToSingle(pVCapacity * irradianceObj.Jan * 30);
                GenObj.Feb = Convert.ToSingle(pVCapacity * irradianceObj.Feb * 30);
                GenObj.Mar = Convert.ToSingle(pVCapacity * irradianceObj.Mar * 30);
                GenObj.Apr = Convert.ToSingle(pVCapacity * irradianceObj.Apr * 30);
                GenObj.May = Convert.ToSingle(pVCapacity * irradianceObj.May * 30);
                GenObj.Jun = Convert.ToSingle(pVCapacity * irradianceObj.Jun * 30);
                GenObj.Jul = Convert.ToSingle(pVCapacity * irradianceObj.Jul * 30);
                GenObj.Aug = Convert.ToSingle(pVCapacity * irradianceObj.Aug * 30);
                GenObj.Sep = Convert.ToSingle(pVCapacity * irradianceObj.Sep * 30);
                GenObj.Oct = Convert.ToSingle(pVCapacity * irradianceObj.Oct * 30);
                GenObj.Nov = Convert.ToSingle(pVCapacity * irradianceObj.Nov * 30);
                GenObj.Dec = Convert.ToSingle(pVCapacity * irradianceObj.Dec * 30);
                lstMonthlyGeneration = new List<Single>(new Single[] { GenObj.Jan, GenObj.Feb, GenObj.Mar, GenObj.Apr, GenObj.May, GenObj.Jun, GenObj.Jul, GenObj.Aug, GenObj.Sep, GenObj.Oct, GenObj.Nov, GenObj.Dec });

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void ComputeLoadReqArray()
        {
            try
            {
                LoadObj.Jan = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Feb = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Mar = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Apr = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.May = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Jun = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Jul = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Aug = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Sep = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Oct = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Nov = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                LoadObj.Dec = Convert.ToSingle(loadProfileObj.TotalEnergyNeededWithLoss * 30);
                //loadGenList.Add(new LoadGenListObject(LoadObj.Jan, LoadObj.Feb, LoadObj.Mar, LoadObj.Apr, LoadObj.May, LoadObj.Jun, LoadObj.Jul, LoadObj.Aug, LoadObj.Sep, LoadObj.Oct, LoadObj.Nov, LoadObj.Dec));
                lstMonthlyLoad = new List<Single>(new Single[] { LoadObj.Jan, LoadObj.Feb, LoadObj.Mar, LoadObj.Apr, LoadObj.May, LoadObj.Jun, LoadObj.Jul, LoadObj.Aug, LoadObj.Sep, LoadObj.Oct, LoadObj.Nov, LoadObj.Dec });

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonsMS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioMSAvailaleArea.Checked)
                {
                    txtMSAvailArea.Enabled = true;
                    moduleSelectObj.SelectionMethod = "Available Area";
                    if (moduleSelectObj.isSelected)
                        checkSpaceConstraint();
                }
                else if (radioMSEnoughSpace.Checked)
                {
                    txtMSAvailArea.Enabled = false;
                    moduleSelectObj.SelectionMethod = "Area is not constraint";
                    if (moduleSelectObj.isSelected)
                        checkSpaceConstraint();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void radioButtonsMSSelecMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMSFavorite.Checked)
            {
                moduleSelectObj.ModuleSelectionMode = "Favorites";
                btnMSSelectfrmDB.Enabled = false;
                comboMSFavModules.Enabled = true;
            }
            else if (radioMSAutoSuggest.Checked)
            {
                moduleSelectObj.ModuleSelectionMode = "Auto Suggest";
                btnMSSelectfrmDB.Enabled = false;
                comboMSFavModules.Enabled = false;
            }
            else if (radioMSManualSelect.Checked)
            {
                moduleSelectObj.ModuleSelectionMode = "Manual Selection";
                btnMSSelectfrmDB.Enabled = true;
                comboMSFavModules.Enabled = false;
            }
        }

        private void btnMSSelectfrmDB_Click(object sender, EventArgs e)
        {
            try
            {
                using (SolarModuleSelection dialogModuleSelect = new SolarModuleSelection(false))
                {
                    // retrive selected module

                    dialogModuleSelect.IdentityUpdated += new SolarModuleSelection.IdentityUpdateHandler(receiveSelectedModule);
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

        private void btnMSNext_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgInverter"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMSBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgLocationInfo"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }



        private void btnInvBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgModuleSelection"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void receiveSelectedModule(object sender, SolarOffgridSystemDesigner.SolarModuleSelection.IdentityUpdateEventArgs e)
        {
            try
            {
                // update the forms values from the event args
                //MessageBox.Show(e.selectedModule.Impp.ToString());
                pvModuleDBObj2.CompanyName = e.selectedModule.CompanyName;
                pvModuleDBObj2.Impp = e.selectedModule.Impp;
                pvModuleDBObj2.Isc = e.selectedModule.Isc;
                pvModuleDBObj2.ItemID = e.selectedModule.ItemID;
                pvModuleDBObj2.Length = e.selectedModule.Length;
                pvModuleDBObj2.ModelNumber = e.selectedModule.ModelNumber;
                pvModuleDBObj2.ModuleEfficiency = e.selectedModule.ModuleEfficiency;
                pvModuleDBObj2.ModuleType = e.selectedModule.ModuleType;
                pvModuleDBObj2.NOCT = e.selectedModule.NOCT;
                pvModuleDBObj2.OtherText = e.selectedModule.OtherText;
                pvModuleDBObj2.PowerOutput = e.selectedModule.PowerOutput;
                pvModuleDBObj2.PowerOutputTolerances = e.selectedModule.PowerOutputTolerances;
                pvModuleDBObj2.Price = e.selectedModule.Price;
                pvModuleDBObj2.TempCoeIsc = e.selectedModule.TempCoeIsc;
                pvModuleDBObj2.TempCoePmax = e.selectedModule.TempCoePmax;
                pvModuleDBObj2.TempCoeVmpp = e.selectedModule.TempCoeVmpp;
                pvModuleDBObj2.TempCoeVoc = e.selectedModule.TempCoeVoc;
                pvModuleDBObj2.Thickness = e.selectedModule.Thickness;
                pvModuleDBObj2.Vmpp = e.selectedModule.Vmpp;
                pvModuleDBObj2.Voc = e.selectedModule.Voc;
                pvModuleDBObj2.Weight = e.selectedModule.Weight;
                pvModuleDBObj2.Width = e.selectedModule.Width;

                lblMSImpp.Text = Convert.ToString(pvModuleDBObj2.Impp);
                lblMSIsc.Text = Convert.ToString(pvModuleDBObj2.Isc);
                lblMSManufacturer.Text = pvModuleDBObj2.CompanyName;
                lblMSModEfficiency.Text = Convert.ToString(pvModuleDBObj2.ModuleEfficiency);
                lblMSModelNum.Text = pvModuleDBObj2.ModelNumber;
                lblMSModuleID.Text = Convert.ToString(pvModuleDBObj2.ItemID);
                lblMSModuleType.Text = pvModuleDBObj2.ModuleType;
                lblMSPowerOut.Text = Convert.ToString(pvModuleDBObj2.PowerOutput);
                lblMSPrice.Text = Convert.ToString(pvModuleDBObj2.Price);
                lblMSVmpp.Text = Convert.ToString(pvModuleDBObj2.Vmpp);
                lblMSImpp.Text = Convert.ToString(pvModuleDBObj2.Impp);
                lblMSVoc.Text = Convert.ToString(pvModuleDBObj2.Voc);
                moduleSelectObj.isSelected = true;
                MSSelectionCalculations();

                txtMSNumModuleReq.Text = Convert.ToString(moduleSelectObj.NumberOfModule);
                lblMSTotArea.Text = moduleSelectObj.RequriedArea.ToString();
                lblMSTotPower.Text = moduleSelectObj.TotalPower.ToString();
                //check area constraint
                checkSpaceConstraint();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }
        public void MSSelectionCalculations()
        {
            try
            {
                moduleSelectObj.NumberOfModule = (UInt16)Math.Ceiling(((locationAndRadiationObj.KwpRequired * 1000) / pvModuleDBObj2.PowerOutput));
                moduleSelectObj.RequriedArea = (pvModuleDBObj2.Length * pvModuleDBObj2.Width * moduleSelectObj.NumberOfModule) / 1000000;
                moduleSelectObj.TotalPower = (pvModuleDBObj2.PowerOutput * moduleSelectObj.NumberOfModule) / 1000;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void txtMSAvailArea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMSAvailArea.Text == "")
                    txtMSAvailArea.Text = "1";

                if (moduleSelectObj.isSelected)
                {
                    moduleSelectObj.NumberOfModule = Convert.ToUInt16(txtMSNumModuleReq.Text);
                    mSReCalculate();
                    checkSpaceConstraint();
                    lblMSTotArea.Text = moduleSelectObj.RequriedArea.ToString();
                    lblMSTotPower.Text = moduleSelectObj.TotalPower.ToString();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }


        private void mSReCalculate()
        {
            try
            {
                moduleSelectObj.RequriedArea = (pvModuleDBObj2.Length * pvModuleDBObj2.Width * moduleSelectObj.NumberOfModule) / 1000000;
                moduleSelectObj.TotalPower = (pvModuleDBObj2.PowerOutput * moduleSelectObj.NumberOfModule) / 1000;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMSNumModuleReq_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMSNumModuleReq.Text == "")
                    txtMSNumModuleReq.Text = "1";
                moduleSelectObj.NumberOfModule = Convert.ToUInt16(txtMSNumModuleReq.Text);
                mSReCalculate();
                checkSpaceConstraint();
                lblMSTotArea.Text = moduleSelectObj.RequriedArea.ToString();
                lblMSTotPower.Text = moduleSelectObj.TotalPower.ToString();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        

        private void checkSpaceConstraint()
        {
            try
            {
                if (moduleSelectObj.isSelected)
                {
                    if (radioMSAvailaleArea.Checked)
                    {
                        if (moduleSelectObj.RequriedArea <= Convert.ToDouble(txtMSAvailArea.Text))
                        {

                            imgMSVerify.Visible = true;
                            imgMSVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.green_tick;
                            btnMSNext.Enabled = true;
                        }
                        else
                        {
                            imgMSVerify.Visible = true;
                            imgMSVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.x_mark;
                            btnMSNext.Enabled = false;
                        }
                    }
                    else
                    {
                        imgMSVerify.Visible = true;
                        imgMSVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.green_tick;
                        btnMSNext.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Inverter Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void radioButtonsInvSelecMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioInvFav.Checked)
            {
                inverterSelectObj.InvSelectionMode = "Favorites";
                btnInvSelectDB.Enabled = false;
                comboInvFav.Enabled = true;
            }
            else if (radioInvAutoSelect.Checked)
            {
                inverterSelectObj.InvSelectionMode = "Auto Suggest";
                btnInvSelectDB.Enabled = false;
                comboInvFav.Enabled = false;
            }
            else if (radioInvManualSelect.Checked)
            {
                inverterSelectObj.InvSelectionMode = "Manual Selection";
                btnInvSelectDB.Enabled = true;
                comboInvFav.Enabled = false;
            }
        }



        private void btnInvNext_Click(object sender, EventArgs e)
        {
            try
            {

                //for chart in results tab
                if (locationAndRadiationObj.Method == "Radiation Database (NASA)")
                {
                    CalculateEstimatedGeneration(moduleSelectObj.TotalPower, loadProfileObj.Kt);
                }

                if (!chkBoxInvSkipBattery.Checked)
                {
                    if (inverterDBObj.Bat_Nominal_DC_Voltage > 0)
                    {
                        if ((inverterDBObj.RatedPower * 0.001) < (moduleSelectObj.TotalPower * 0.8))
                        {
                            if (MessageBox.Show("It seems to be like chosen inverter is undersized! Do you still want to continue?", "Attention!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                            {
                                batteryDimensionObj.InverterBatteryVoltage = inverterDBObj.Bat_Nominal_DC_Voltage;
                                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgBattery"];
                            }
                        }
                        //else if ((inverterDBObj.RatedPower * 0.001) > (moduleSelectObj.TotalPower * 1.2))
                        //{
                        //    if (MessageBox.Show("It seems to be like chosen inverter is oversized! Do you still want to continue?", "Attention!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                        //    {
                        //        batteryDimensionObj.InverterBatteryVoltage = inverterDBObj.Bat_Nominal_DC_Voltage;
                        //        tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgBattery"];
                        //    }
                        //}
                        else
                        {
                            batteryDimensionObj.InverterBatteryVoltage = inverterDBObj.Bat_Nominal_DC_Voltage;
                            batteryDimensionObj.FinalCapacity = 0.0;
                            tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgBattery"];
                        }

                    }
                    else
                    {
                        MessageBox.Show("Inverter is not chosen (or) incompatable inverter chosen");
                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to skip battery sizing?", "Attention!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        batteryDimensionObj.InverterBatteryVoltage = 0.0;
                        batteryDimensionObj.BatteryCapacityRequired = 0.0;
                        batteryDimensionObj.FinalCapacity = 0.0;
                        batteryDimensionObj.NumberOfCells = 0;
                        batteryDimensionObj.CellsParallel = 0;
                        batteryDimensionObj.CellSeries = 0;
                        batteryDimensionObj.CellCapacity = 0.0;
                        batteryDimensionObj.CellVoltage = 0.0;
                        tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgResults"];
                    }
                }
                

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }



        }

        private void btnInvSelectDB_Click(object sender, EventArgs e)
        {
            try
            {
                using (InverterSelection dialogInverterSelect = new InverterSelection(inverterSelectObj.VmppMax, inverterSelectObj.VmppMin, inverterSelectObj.VocMax, inverterSelectObj.ReqPowerMax, inverterSelectObj.ReqPowerMin,false))
                {
                    // retrive selected module

                    dialogInverterSelect.InverterUpdated += new InverterSelection.InverterUpdateHandler(receiveSelectedInverter);
                    if (dialogInverterSelect.ShowDialog() == DialogResult.OK)
                    {


                    }

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }



        private void receiveSelectedInverter(object sender, SolarOffgridSystemDesigner.InverterSelection.InverterUpdateEventArgs e)
        {
            try
            {
                // update the forms values from the event args
                //MessageBox.Show(e.selectedModule.Impp.ToString());

                inverterDBObj.Bat_Nominal_DC_Voltage = e.selectedInverter.Bat_Nominal_DC_Voltage;
                inverterDBObj.CompanyName = e.selectedInverter.CompanyName;
                inverterDBObj.Currency = e.selectedInverter.Currency;
                inverterDBObj.Dimension = e.selectedInverter.Dimension;
                inverterDBObj.InverterType = e.selectedInverter.InverterType;
                inverterDBObj.ModelNumber = e.selectedInverter.ModelNumber;
                inverterDBObj.OtherText = e.selectedInverter.OtherText;
                inverterDBObj.Price = e.selectedInverter.Price;
                inverterDBObj.PV_Max_MPP_Voltage = e.selectedInverter.PV_Max_MPP_Voltage;
                inverterDBObj.PV_MaxDCPower = e.selectedInverter.PV_MaxDCPower;
                inverterDBObj.PV_Maximum_DC_Voltage = e.selectedInverter.PV_Maximum_DC_Voltage;
                inverterDBObj.PV_Maximum_Input_Current = e.selectedInverter.PV_Maximum_Input_Current;
                inverterDBObj.PV_Min_MPP_Voltage = e.selectedInverter.PV_Min_MPP_Voltage;
                inverterDBObj.PV_Nominal_DC_Voltage = e.selectedInverter.PV_Nominal_DC_Voltage;
                inverterDBObj.PV_MPPTrackers = e.selectedInverter.PV_MPPTrackers;
                inverterDBObj.RatedPower = e.selectedInverter.RatedPower;
                inverterDBObj.Weight = e.selectedInverter.Weight;

                InverterCalculations();
                InverterLabelsUpdate();

                if (inverterSelectObj.StringNumber > 0 && inverterSelectObj.ModulesPerString > 0)
                {
                    btnInvNext.Enabled = true;
                    lblInvAlert.Visible = false;
                    imgInvVerify.Visible = true;
                    imgInvVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.green_tick;
                }
                else
                {
                    btnInvNext.Enabled = false;
                    lblInvAlert.Visible = true;
                    imgInvVerify.Visible = true;
                    imgInvVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.x_mark;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        public void InverterSectionRevalidation()
        {
            try
            {
                InverterCalculations();
                InverterLabelsUpdate();

                if (inverterSelectObj.StringNumber > 0 && inverterSelectObj.ModulesPerString > 0)
                {
                    btnInvNext.Enabled = true;
                    lblInvAlert.Visible = false;
                    imgInvVerify.Visible = true;
                    imgInvVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.green_tick;
                }
                else
                {
                    btnInvNext.Enabled = false;
                    lblInvAlert.Visible = true;
                    imgInvVerify.Visible = true;
                    imgInvVerify.Image = SolarOffgridSystemDesigner.Properties.Resources.x_mark;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        public void InverterCalculations()
        {
            try
            {
                inverterSelectObj.VocMax = RetriveVmin_max(pvModuleDBObj2.Voc, pvModuleDBObj2.TempCoeVoc * 0.01, -10);
                inverterSelectObj.VmppMax = RetriveVmin_max(pvModuleDBObj2.Vmpp, pvModuleDBObj2.TempCoeVmpp * 0.01, -10);
                inverterSelectObj.VmppMin = RetriveVmin_max(pvModuleDBObj2.Vmpp, pvModuleDBObj2.TempCoeVmpp * 0.01, 70);
                inverterSelectObj.MinModules = MinModules(inverterDBObj.PV_Min_MPP_Voltage, inverterSelectObj.VmppMin);
                int maxModules1 = MinModules(inverterDBObj.PV_Max_MPP_Voltage, inverterSelectObj.VmppMax);
                int maxModules2 = MinModules(inverterDBObj.PV_Maximum_DC_Voltage, inverterSelectObj.VocMax);
                inverterSelectObj.MaxModules = Math.Min(maxModules1, maxModules2);

                //if single mpp tracker
                if (inverterDBObj.PV_MPPTrackers == 1)
                {
                    inverterSelectObj.StringNumber = optModuleCombinationMoreStrings(inverterSelectObj.MaxModules, inverterSelectObj.MinModules, moduleSelectObj.NumberOfModule);
                    if (inverterSelectObj.StringNumber > 0)
                        inverterSelectObj.ModulesPerString = moduleSelectObj.NumberOfModule / inverterSelectObj.StringNumber;
                    inverterSelectObj.MaxArrayCurrent = pvModuleDBObj2.Isc * inverterSelectObj.StringNumber;
                    if (inverterSelectObj.MaxArrayCurrent > inverterDBObj.PV_Maximum_Input_Current)
                    {
                        inverterSelectObj.StringNumber = optModuleCombinationMoreSeries(inverterSelectObj.MaxModules, inverterSelectObj.MinModules, moduleSelectObj.NumberOfModule);
                        if (inverterSelectObj.StringNumber > 0)
                            inverterSelectObj.ModulesPerString = moduleSelectObj.NumberOfModule / inverterSelectObj.StringNumber;
                        inverterSelectObj.MaxArrayCurrent = pvModuleDBObj2.Isc * inverterSelectObj.StringNumber;
                    }
                    inverterSelectObj.MaxArrayCurrent = pvModuleDBObj2.Isc * inverterSelectObj.StringNumber;
                    if (inverterSelectObj.MaxArrayCurrent > inverterDBObj.PV_Maximum_Input_Current)
                    {
                        inverterSelectObj.ModulesPerString = 0;
                        inverterSelectObj.StringNumber = 0;
                    }
                    inverterSelectObj.T2ModulesPerString = 0;
                    inverterSelectObj.T2StringNumber = 0;
                }
                else
                {
                    List<Tuple<int, int, int, int>> moduleCombinations=DualTrackerModuleCombination(inverterSelectObj.MinModules, inverterSelectObj.MaxModules, inverterSelectObj.MinModules, inverterSelectObj.MaxModules, moduleSelectObj.NumberOfModule);
                    if (moduleCombinations.Count > 0)
                    {
                        //loop for removing items not satisfying max input current
                        for (int i = moduleCombinations.Count - 1; i >= 0; i--)
                        {
                            // ignore the combinations that doesnt satisfy maximum input current condition
                            if (pvModuleDBObj2.Isc * moduleCombinations[i].Item2 > inverterDBObj.PV_Maximum_Input_Current || pvModuleDBObj2.Isc * moduleCombinations[i].Item4 > inverterDBObj.PV_Maximum_Input_Current)
                            {
                                moduleCombinations.RemoveAt(i);
                            }
                        }

                        if (moduleCombinations.Count > 0)
                        {
                            inverterSelectObj.StringNumber = moduleCombinations[0].Item2;
                            inverterSelectObj.T2StringNumber = moduleCombinations[0].Item4;
                            inverterSelectObj.ModulesPerString = moduleCombinations[0].Item1;
                            inverterSelectObj.T2ModulesPerString = moduleCombinations[0].Item3;
                            //if string number is zero, make modue number can be ignored
                            if (inverterSelectObj.StringNumber == 0)
                                inverterSelectObj.ModulesPerString = 0;
                            if (inverterSelectObj.T2StringNumber == 0)
                                inverterSelectObj.T2ModulesPerString = 0;

                        }
                        else
                        {
                            inverterSelectObj.ModulesPerString = 0;
                            inverterSelectObj.StringNumber = 0;
                            inverterSelectObj.T2ModulesPerString = 0;
                            inverterSelectObj.T2StringNumber = 0;
                        }

                    }
                    else {
                        inverterSelectObj.ModulesPerString = 0;
                        inverterSelectObj.StringNumber = 0;
                        inverterSelectObj.T2ModulesPerString = 0;
                        inverterSelectObj.T2StringNumber = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }


        }

        //logic for dual mpp trackers. output: Modules/string of tracke-1, total strings of tracker-1,Modules/string of tracke-2, total strings of tracker-2
        public List<Tuple<int, int, int, int>> DualTrackerModuleCombination(int traker1MinModules, int traker1MaxModules, int traker2MinModules, int traker2MaxModules,int totalModules)
        {
            List<Tuple<int, int, int, int>> combination = new List<Tuple<int, int, int, int>>();
            for (int i = traker1MinModules; i <= traker1MaxModules; i++)
            {
                for (int j = traker2MinModules; j <= traker2MaxModules; j++)
                {
                    for (int m = 0; m < totalModules; m++)
                    {
                        for (int n = 0; n < totalModules; n++)
                        {
                            if (i * m + j * n == totalModules)
                            {
                                combination.Add(Tuple.Create(i, m, j, n));
                            }
                        }
                    }

                }

            }
            //consider only unique combination and remove duplicates
            return combination.GroupBy(x => (x.Item1 * x.Item2))
                                 .Select(g => g.First())
                                 .ToList();
        }

        public void InverterLabelsUpdate()
        {
            try
            {
                lblInvSeriesModules.Text = inverterSelectObj.ModulesPerString.ToString();
                lblInvStringNum.Text = inverterSelectObj.StringNumber.ToString();
                lblInvID.Text = inverterDBObj.ItemID.ToString();
                lblInvManufacturer.Text = inverterDBObj.CompanyName.ToString();
                lblInvPower.Text = inverterDBObj.RatedPower.ToString();
                lblInvPrice.Text = inverterDBObj.Price.ToString();
                lblInvModel.Text = inverterDBObj.ModelNumber.ToString();
                lblInvType.Text = inverterDBObj.InverterType.ToString();
                lblInvMaxCurrent.Text = inverterSelectObj.MaxArrayCurrent.ToString();
                lblInvMaxModules.Text = inverterSelectObj.MaxModules.ToString();
                lblInvMinModules.Text = inverterSelectObj.MinModules.ToString();
                lblInvVmppMax.Text = inverterSelectObj.VmppMax.ToString();
                lblInvVmppMin.Text = inverterSelectObj.VmppMin.ToString();
                lblInvVocMax.Text = inverterSelectObj.VocMax.ToString();
                lblInvT2ModulePerString.Text = inverterSelectObj.T2ModulesPerString.ToString();
                lblInvT2Strings.Text = inverterSelectObj.T2StringNumber.ToString();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        public double RetriveVmin_max(double voltage, double beta, double temperature)
        {
            return (voltage * (1 + beta * (temperature - 25)));
        }
        public double RetriveIcoc(double current, double alpha, double temperature)
        {
            return (current * (1 + alpha * (temperature - 25)));
        }
        public int MinModules(double minInvMppVoltage, double mintotalModuleMppVoltage)
        {
            return Convert.ToInt32(Math.Floor(minInvMppVoltage / mintotalModuleMppVoltage));
        }
        public int MaxModules(double maxVoltage, double moduleVoltage)
        {
            return Convert.ToInt32(Math.Floor(maxVoltage / moduleVoltage));
        }

        public int optModuleCombinationMoreStrings(int maxModules, int minModules, int moduleNumber)
        {
            int stringNumber = 0;
            for (int i = maxModules; i >= minModules; i--)
            {
                if (moduleNumber % i == 0)
                    stringNumber = moduleNumber / i;
            }
            return stringNumber;
        }
        public int optModuleCombinationMoreSeries(int maxModules, int minModules, int moduleNumber)
        {
            int stringNumber = 0;
            for (int i = minModules; i <= maxModules; i++)
            {
                if (moduleNumber % i == 0)
                    stringNumber = moduleNumber / i;
            }
            return stringNumber;
        }
        /// <summary>
        /// Battery Dimention
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        private void radioButtonsBatMethod_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //RadioButton radioButton = sender as RadioButton;
                RadioBatteryChanged();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioBatteryChanged()
    {
        try
        {
            if (radioBatCustomLoad.Checked)
            {
                txtBatCustomLoad.Enabled = true;
                batteryDimensionObj.RestitutionEnergy = Convert.ToDouble(txtBatCustomLoad.Text);
                CopyBatValuesToObj();
                BatteryCalculations();
                SetBatteryLabels();
            }
            else if (radioBatNightLoad.Checked)
            {
                batteryDimensionObj.RestitutionEnergy = loadProfileObj.TotalNightEnergyRequirement;
                CopyBatValuesToObj();
                BatteryCalculations();
                SetBatteryLabels();
            }
            else if (radioBatDayLoad.Checked)
            {
                batteryDimensionObj.RestitutionEnergy = loadProfileObj.TotalDayEnergyRequirement;
                CopyBatValuesToObj();
                BatteryCalculations();
                SetBatteryLabels();
            }
            else if (radioBatDailyLoad.Checked)
            {
                batteryDimensionObj.RestitutionEnergy = loadProfileObj.TotalEnergyNeededWithLoss;
                CopyBatValuesToObj();
                BatteryCalculations();
                SetBatteryLabels();
            }
        }
        catch (Exception ex)
        {
            
            MessageBox.Show(ex.Message);
        }
    }

        private void BatteryCalculations()
        {
            try
            {
                batteryDimensionObj.BatteryCapacityRequired = Math.Round((batteryDimensionObj.RestitutionEnergy * batteryDimensionObj.Daut) / (batteryDimensionObj.DoD), 2);
                batteryDimensionObj.NumberOfCells = (int)Math.Ceiling((batteryDimensionObj.BatteryCapacityRequired * 1000) / (batteryDimensionObj.CellCapacity * batteryDimensionObj.CellVoltage));
                batteryDimensionObj.CellSeries = (int)Math.Ceiling(batteryDimensionObj.InverterBatteryVoltage / batteryDimensionObj.CellVoltage);
                batteryDimensionObj.CellsParallel = (int)Math.Ceiling((decimal)batteryDimensionObj.NumberOfCells / batteryDimensionObj.CellSeries);
                batteryDimensionObj.NumberOfCells = batteryDimensionObj.CellSeries * batteryDimensionObj.CellsParallel;
                batteryDimensionObj.FinalCapacity = (batteryDimensionObj.NumberOfCells * batteryDimensionObj.CellCapacity * batteryDimensionObj.CellVoltage) / 1000;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void SetBatteryLabels()
        {
            try
            {
                lblBatCapacityReq.Text = batteryDimensionObj.BatteryCapacityRequired.ToString();
                lblBatCellsParallel.Text = batteryDimensionObj.CellsParallel.ToString();
                lblBatCellsSeries.Text = batteryDimensionObj.CellSeries.ToString();
                lblBatFinalCatacity.Text = batteryDimensionObj.FinalCapacity.ToString();
                lblBatTotalCells.Text = batteryDimensionObj.NumberOfCells.ToString();
                lblBatInvVoltage.Text = batteryDimensionObj.InverterBatteryVoltage.ToString();
                linearGaugeBat.Visible = true;
                linearGaugeBat.Value = Convert.ToSingle(batteryDimensionObj.FinalCapacity / batteryDimensionObj.BatteryCapacityRequired) * 100;
                linearGaugeBat.Refresh();
                btnBatNext.Enabled = true;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void CopyBatValuesToObj()
        {
            //batteryDimensionObj.BatteryEfficiency = Convert.ToDouble(txtBatEfficiency.Value);
            try
            {
                batteryDimensionObj.Daut = Convert.ToDouble(txtBatAnatomyDats.Text);
                batteryDimensionObj.DoD = Convert.ToDouble(txtBatDoD.Text);
                batteryDimensionObj.CellCapacity = Convert.ToDouble(txtBatCellCapacity.Text);
                batteryDimensionObj.CellVoltage = Convert.ToDouble(txtBatCellVoltage.Text);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBatNext_Click(object sender, EventArgs e)
        {
            try
            {
                
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgResults"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBatBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgInverter"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }


        private void btnBatCalculate_Click(object sender, EventArgs e)
        {

            try
            {
                CopyBatValuesToObj();
                BatteryCalculations();

                SetBatteryLabels();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBatDoD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CopyBatValuesToObj();
                BatteryCalculations();
                SetBatteryLabels();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBatCustomLoad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioBatCustomLoad.Checked)
                {
                    txtBatCustomLoad.Enabled = true;
                    batteryDimensionObj.RestitutionEnergy = Convert.ToDouble(txtBatCustomLoad.Text);
                    CopyBatValuesToObj();
                    BatteryCalculations();
                    SetBatteryLabels();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBatAnatomyDats_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CopyBatValuesToObj();
                BatteryCalculations();
                SetBatteryLabels();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void imgHomeSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Settings dialogsettings = new Settings();

                dialogsettings.Show();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        private void imgHomeContactUs_Click(object sender, EventArgs e)
        {
            try
            {
                ContactUs dialogcontactus = new ContactUs();

                dialogcontactus.Show();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        private void btnResultsNext_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgReport"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResultsBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkBoxInvSkipBattery.Checked)
                {
                    tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgBattery"];
                }
                else
                {
                    tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgInverter"];
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReportHome_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgHome"];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReportBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages["tabPgResults"];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnreportExport_Click(object sender, EventArgs e)
        {
            try
            {
                string _sPathFilePDF = String.Empty;
                String v_mimetype;
                String v_encoding;
                String v_filename_extension;
                String[] v_streamids;
                Microsoft.Reporting.WinForms.Warning[] warnings;
                string _sSuggestedName = "ProjectReport";

                byte[] byteViewer = reportViewer1.LocalReport.Render("PDF", null, out v_mimetype, out v_encoding, out v_filename_extension, out v_streamids, out warnings);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = _sSuggestedName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    newFile.Write(byteViewer, 0, byteViewer.Length);
                    newFile.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void imgHomeHelpmanual_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                process.StartInfo = startInfo;
                startInfo.FileName = "SolarOffgridDesigner_help.pdf";
                process.Start();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message);
            }
        }

        private void imgHomeWatchVideos_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://www.youtube.com/channel/UCgwJDryikJO8NMZ2fRjf2yA");
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message);
            }
        }

         







        

        

        

        

        

        

        

        

        





    }
}
