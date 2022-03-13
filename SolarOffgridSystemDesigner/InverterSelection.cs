//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolarOffgridSystemDesigner
{
    
    public partial class InverterSelection : Form
    {
        // add a delegate
        public delegate void InverterUpdateHandler(object sender, InverterUpdateEventArgs e);

        // add an event of the delegate type
        public event InverterUpdateHandler InverterUpdated;
        private SolarOffgridSystemDesigner.InverterDBObject inverterDBObj = new SolarOffgridSystemDesigner.InverterDBObject();
        string mDbPath = Application.StartupPath + "/SolarOffgridDesigner_DB.db";

        SQLiteConnection mConn;
        SQLiteDataAdapter mAdapter;
        DataTable mTable;
        double VmppMax, VmppMin, VocMax, ReqPowerMax, ReqPowerMin;
        public InverterSelection(double _VmppMax, double _VmppMin, double _VocMax, double _ReqPowerMax, double _ReqPowerMin,bool disableSelectBtn)
        {
            InitializeComponent();
            VmppMax = _VmppMax;
            VmppMin = _VmppMin;
            VocMax = _VocMax;
            ReqPowerMax = _ReqPowerMax;
            ReqPowerMin = _ReqPowerMin;
            if (disableSelectBtn)
                btnOk.Enabled = false;
            else
                btnOk.Enabled = true;
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (gridViewInverters.SelectedRows.Count > 0)
            {
                inverterDBObj.ItemID = Convert.ToUInt32(gridViewInverters.SelectedRows[0].Cells["ItemID"].Value);
                inverterDBObj.CompanyName = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["Manufacturer"].Value);
                inverterDBObj.ModelNumber = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["ModelNumber"].Value);
                inverterDBObj.OtherText = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["OtherInfo"].Value);
                inverterDBObj.InverterType = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["InverterType"].Value);
                inverterDBObj.Price = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["Price"].Value);
                inverterDBObj.Currency = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["Currency"].Value);
                inverterDBObj.RatedPower = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["RatedPower"].Value);
                inverterDBObj.PV_MaxDCPower = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_MaxDCPower"].Value);
                inverterDBObj.PV_Nominal_DC_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Nominal_DC_Voltage"].Value);
                inverterDBObj.PV_Maximum_DC_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Maximum_DC_Voltage"].Value);
                inverterDBObj.PV_Max_MPP_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Max_MPP_Voltage"].Value);
                inverterDBObj.PV_Min_MPP_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Min_MPP_Voltage"].Value);
                inverterDBObj.PV_Maximum_Input_Current = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Maximum_Input_Current"].Value);
                inverterDBObj.Bat_Nominal_DC_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["Bat_Nominal_DC_Voltage"].Value);
                inverterDBObj.PV_MPPTrackers = Convert.ToUInt16(gridViewInverters.SelectedRows[0].Cells["PV_MPPTrackers"].Value);
                inverterDBObj.Dimension = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["Dimension"].Value);
                inverterDBObj.Weight = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["Weight"].Value);

                // instance the event args and pass it each value
                InverterUpdateEventArgs args = new InverterUpdateEventArgs(inverterDBObj);

                // raise the event with the updated arguments
                InverterUpdated(this, args);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void loadFromDB()
        {
            try
            {
                mConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;");
                //mConn.SetPassword("0123456789");
                // ----------------- Opening The Connection -----------------
                // ----------------------------------------------------------
                // I.e. Opening DB's File for Reading And Writing.
                // SQLiteDataAdapter cans do it automatically.
                // But, if you would also use SQLiteCommand, or GetSchema(),
                // you should Open DB Manually.
                // mConn.Open();
                mAdapter = new SQLiteDataAdapter("SELECT * FROM InveterTable_v1", mConn);
                mTable = new DataTable(); // Don't forget initialize!
                mAdapter.Fill(mTable);
                gridViewInverters.DataSource = mTable;

                for (int row = 0; row <= gridViewInverters.Rows.Count - 1; row++)
                {
                    if (Convert.ToDouble((gridViewInverters.Rows[row].Cells["RatedPower"]).Value) <= ReqPowerMax && Convert.ToDouble((gridViewInverters.Rows[row].Cells["RatedPower"]).Value) >= ReqPowerMin)
                        ((DataGridViewImageCell)gridViewInverters.Rows[row].Cells[0]).Value = Properties.Resources.green_tick_20x20;
                }
                // using (SQLiteCommand mCmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS _[Test Table] (id INTEGER PRIMARY KEY AUTOINCREMENT, 'FirstName' TEXT, 'Age' INTEGER);", mConn))
                //{
                //    mCmd.ExecuteNonQuery();
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        public class InverterUpdateEventArgs : System.EventArgs
        {
            private InverterDBObject _inverterDBObj;

            public InverterUpdateEventArgs(InverterDBObject inverterDBObj2)
            {
                // TODO: Complete member initialization
                this._inverterDBObj = inverterDBObj2;
            }
            public InverterDBObject selectedInverter
            {
                get
                {
                    return _inverterDBObj;
                }
            }
        }

     

        private void btnAddToFav_Click(object sender, EventArgs e)
        {

        }

        private void InverterSelection_Load(object sender, EventArgs e)
        {
            loadFromDB();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection sqlConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;"))
            {
                try
                {
                    UInt32 ItemID = Convert.ToUInt32(gridViewInverters.SelectedRows[0].Cells["ItemID"].Value);
                    sqlConn.Open();
                    //create command
                    SQLiteCommand sqlComm = sqlConn.CreateCommand();
                    sqlComm.CommandText = "DELETE FROM InveterTable_v1 WHERE ItemID=" + ItemID;
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted!");
                    gridViewInverters.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewInverters.SelectedRows.Count>0)
                {
                InverterDBObject invModuleDBEditObj = new InverterDBObject();
                invModuleDBEditObj.ItemID = Convert.ToUInt32(gridViewInverters.SelectedRows[0].Cells["ItemID"].Value);
                invModuleDBEditObj.CompanyName = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["Manufacturer"].Value);
                invModuleDBEditObj.ModelNumber = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["ModelNumber"].Value);
                invModuleDBEditObj.OtherText = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["OtherInfo"].Value);
                invModuleDBEditObj.InverterType = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["InverterType"].Value);
                invModuleDBEditObj.Price = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["Price"].Value);
                invModuleDBEditObj.Currency = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["Currency"].Value);
                invModuleDBEditObj.RatedPower = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["RatedPower"].Value);
                invModuleDBEditObj.PV_MaxDCPower = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_MaxDCPower"].Value);
                invModuleDBEditObj.PV_Nominal_DC_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Nominal_DC_Voltage"].Value);
                invModuleDBEditObj.PV_Maximum_DC_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Maximum_DC_Voltage"].Value);
                invModuleDBEditObj.PV_Max_MPP_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Max_MPP_Voltage"].Value);
                invModuleDBEditObj.PV_Min_MPP_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Min_MPP_Voltage"].Value);
                invModuleDBEditObj.PV_Maximum_Input_Current = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["PV_Maximum_Input_Current"].Value);
                invModuleDBEditObj.Bat_Nominal_DC_Voltage = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["Bat_Nominal_DC_Voltage"].Value);
                invModuleDBEditObj.PV_MPPTrackers = Convert.ToUInt16(gridViewInverters.SelectedRows[0].Cells["PV_MPPTrackers"].Value);
                invModuleDBEditObj.Dimension = Convert.ToString(gridViewInverters.SelectedRows[0].Cells["Dimension"].Value);
                invModuleDBEditObj.Weight = Convert.ToDouble(gridViewInverters.SelectedRows[0].Cells["Weight"].Value);
                using (EditInverterInformation dialogEditSelect = new EditInverterInformation(invModuleDBEditObj))
                {

                    if (dialogEditSelect.ShowDialog() == DialogResult.OK)
                    {
                        loadFromDB();
                    }

                }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSettingsDialog_Click(object sender, EventArgs e)
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
    }
}
