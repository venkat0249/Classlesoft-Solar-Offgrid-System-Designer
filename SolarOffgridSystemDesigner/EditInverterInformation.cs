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
    public partial class EditInverterInformation : Form
    {
        string mDbPath = Application.StartupPath + "/SolarOffgridDesigner_DB.db";
        SQLiteConnection mConn;
        UInt32 ItemID;
        public EditInverterInformation(InverterDBObject invModuleDBEditObj)
        {
            InitializeComponent();
            ItemID = invModuleDBEditObj.ItemID;
            txtInvManufacturer.Text=Convert.ToString(invModuleDBEditObj.CompanyName);
            txtInvModel.Text=Convert.ToString(invModuleDBEditObj.ModelNumber);
            txtInvOtherinfo.Text=Convert.ToString(invModuleDBEditObj.OtherText);
            comboInvType.Text=Convert.ToString(invModuleDBEditObj.InverterType);
            txtInvPrice.Text=Convert.ToString(invModuleDBEditObj.Price);
            txtInvCurrency.Text=Convert.ToString(invModuleDBEditObj.Currency);
            txtInvRatedPower.Text=Convert.ToString(invModuleDBEditObj.RatedPower);
            //inverterDBObj.Dimension = txtInvLenght.Text + "X" + txtInvWidth.Text + "X" + txtInvThickness.Text;
            txtDimensions.Text=Convert.ToString(invModuleDBEditObj.Dimension);
            
            txtInvWeight.Text=Convert.ToString(invModuleDBEditObj.Weight);
            txtInvMaxInputPower.Text=Convert.ToString(invModuleDBEditObj.PV_MaxDCPower);
            txtInvMaxVmpp.Text=Convert.ToString(invModuleDBEditObj.PV_Max_MPP_Voltage);
            txtInvMaxVdc.Text=Convert.ToString(invModuleDBEditObj.PV_Maximum_DC_Voltage);
            txtInvMaxI.Text=Convert.ToString(invModuleDBEditObj.PV_Maximum_Input_Current);
            txtInvMinVmpp.Text=Convert.ToString(invModuleDBEditObj.PV_Min_MPP_Voltage);
            txtInvBatVdc.Text=Convert.ToString(invModuleDBEditObj.Bat_Nominal_DC_Voltage);
            txtInvMppTrackers.Text = Convert.ToString(invModuleDBEditObj.PV_MPPTrackers);
        }

        private void btnModulesSaveToDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvManufacturer.Text != "" && txtInvModel.Text != "" && txtInvRatedPower.Text != "" && txtInvMaxI.Text != "" && txtInvMaxVdc.Text != "" && txtInvMaxVmpp.Text != "" && txtInvMinVmpp.Text != "" && txtInvBatVdc.Text != "" && txtInvMaxInputPower.Text != "" && txtInvMppTrackers.Text != "")
                {
                    mConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;");
                    SQLiteCommand insertSQL = new SQLiteCommand("UPDATE InveterTable_v1 set Manufacturer=@Manufacturer,ModelNumber=@ModelNumber,OtherInfo=@OtherInfo,InverterType=@InverterType,Price=@Price,Currency=@Currency,RatedPower=@RatedPower,PV_Maximum_DC_Voltage=@PV_Maximum_DC_Voltage,PV_Max_MPP_Voltage=@PV_Max_MPP_Voltage,PV_Min_MPP_Voltage=@PV_Min_MPP_Voltage,PV_Maximum_Input_Current=@PV_Maximum_Input_Current,Bat_Nominal_DC_Voltage=@Bat_Nominal_DC_Voltage,Dimension=@Dimension,PV_MPPTrackers=@PV_MPPTrackers,PV_MaxDCPower=@PV_MaxDCPower,Weight=@Weight where ItemID=@ItemID", mConn);

                    insertSQL.Parameters.Add(new SQLiteParameter("@Manufacturer", DbType.String) { Value = txtInvManufacturer.Text});
                    insertSQL.Parameters.Add(new SQLiteParameter("@ModelNumber", DbType.String) { Value = txtInvModel.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@OtherInfo", DbType.String) { Value = txtInvOtherinfo.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@InverterType", DbType.String) { Value =comboInvType.SelectedItem.ToString() });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Price", DbType.Double) { Value = txtInvPrice.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Currency", DbType.String) { Value = txtInvCurrency.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@RatedPower", DbType.Double) { Value =txtInvRatedPower.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PV_Maximum_DC_Voltage", DbType.Double) { Value = txtInvMaxVdc.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PV_Max_MPP_Voltage", DbType.Double) { Value = txtInvMaxVmpp.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PV_Min_MPP_Voltage", DbType.Double) { Value = txtInvMinVmpp.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PV_Maximum_Input_Current", DbType.Double) { Value = txtInvMaxI.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Bat_Nominal_DC_Voltage", DbType.Double) { Value = txtInvBatVdc.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Dimension", DbType.String) { Value = txtDimensions.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PV_MPPTrackers", DbType.Int32) { Value = txtInvMppTrackers.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@PV_MaxDCPower", DbType.Double) { Value = txtInvMaxInputPower.Text });
                    insertSQL.Parameters.Add(new SQLiteParameter("@Weight", DbType.Double) { Value = txtInvWeight.Text});
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
                    //MessageBox.Show("please fill mandatory fields!");
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
