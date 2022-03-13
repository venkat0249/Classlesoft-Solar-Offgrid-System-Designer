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
    
    public partial class SolarModuleSelection : Form
    {
        // add a delegate
        public delegate void IdentityUpdateHandler(object sender, IdentityUpdateEventArgs e);

        // add an event of the delegate type
        public event IdentityUpdateHandler IdentityUpdated;
        public PVModuleDBObject pvModuleDBObj = new PVModuleDBObject();
        string mDbPath = Application.StartupPath + "/SolarOffgridDesigner_DB.db";

        SQLiteConnection mConn;
        SQLiteDataAdapter mAdapter;
        DataTable mTable;
        public SolarModuleSelection(bool disableSelectedBtn)
        {
            InitializeComponent();
            if (disableSelectedBtn)
                btnOk.Enabled = false;
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewModules.SelectedRows.Count > 0)
                {
                    CopySelectedToObject();
                    // instance the event args and pass it each value
                    IdentityUpdateEventArgs args = new IdentityUpdateEventArgs(pvModuleDBObj);

                    // raise the event with the updated arguments
                    IdentityUpdated(this, args);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                mAdapter = new SQLiteDataAdapter("SELECT * FROM PVModuleTable_v1", mConn);
                mTable = new DataTable(); // Don't forget initialize!
                mAdapter.Fill(mTable);
                gridViewModules.DataSource = mTable;
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
        //copy selected item values from data gridview to item object
        private void CopySelectedToObject()
        {
            try
            {
                pvModuleDBObj.ItemID = Convert.ToUInt32(gridViewModules.SelectedRows[0].Cells["ItemID"].Value);
                pvModuleDBObj.CompanyName = Convert.ToString(gridViewModules.SelectedRows[0].Cells["CompanyName"].Value);
                pvModuleDBObj.ModelNumber = Convert.ToString(gridViewModules.SelectedRows[0].Cells["ModelNumber"].Value);
                pvModuleDBObj.OtherText = Convert.ToString(gridViewModules.SelectedRows[0].Cells["OtherText"].Value);
                pvModuleDBObj.ModuleType = Convert.ToString(gridViewModules.SelectedRows[0].Cells["ModuleType"].Value);
                pvModuleDBObj.Price = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Price"].Value);
                pvModuleDBObj.Currency = Convert.ToString(gridViewModules.SelectedRows[0].Cells["Currency"].Value);
                pvModuleDBObj.PowerOutput = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["PowerOutput"].Value);
                pvModuleDBObj.PowerOutputTolerances = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["PowerOutputTolerances"].Value);
                pvModuleDBObj.ModuleEfficiency = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["ModuleEfficiency"].Value);
                pvModuleDBObj.Vmpp = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Vmpp"].Value);
                pvModuleDBObj.Impp = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Impp"].Value);
                pvModuleDBObj.Voc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Voc"].Value);
                pvModuleDBObj.Isc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Isc"].Value);
                pvModuleDBObj.NOCT = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["NOCT"].Value);
                pvModuleDBObj.TempCoePmax = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoePmax"].Value);
                pvModuleDBObj.TempCoeVoc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoeVoc"].Value);
                pvModuleDBObj.TempCoeIsc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoeIsc"].Value);
                pvModuleDBObj.TempCoeVmpp = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoeVmpp"].Value);
                pvModuleDBObj.Length = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Length"].Value);
                pvModuleDBObj.Width = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Width"].Value);
                pvModuleDBObj.Thickness = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Thickness"].Value);
                pvModuleDBObj.Weight = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Weight"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public class IdentityUpdateEventArgs : System.EventArgs
        {
            private PVModuleDBObject _pvModuleDBObj;
            public IdentityUpdateEventArgs(PVModuleDBObject pvModuleDBObj)
            {
            // TODO: Complete member initialization
            this._pvModuleDBObj = pvModuleDBObj;
            }
            public PVModuleDBObject selectedModule
            {
            get
            {
                return _pvModuleDBObj;
            }
            }
        }

        private void SolarModuleSelection_Load(object sender, EventArgs e)
        {
            loadFromDB();

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection sqlConn = new SQLiteConnection("Data Source=SolarOffgridDesigner_DB.db;Version=3;" ))
            {
                try
                {
                    UInt32 ItemID = Convert.ToUInt32(gridViewModules.SelectedRows[0].Cells["ItemID"].Value);
                    sqlConn.Open();
                    //create command
                    SQLiteCommand sqlComm = sqlConn.CreateCommand();
                    sqlComm.CommandText = "DELETE FROM PVModuleTable_v1 WHERE ItemID=" + ItemID;
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted!");
                    foreach (DataGridViewRow item in this.gridViewModules.SelectedRows)
                    {
                        gridViewModules.Rows.RemoveAt(item.Index);
                    }
                    gridViewModules.Refresh();
                }
                catch(Exception ex)
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
                if (gridViewModules.SelectedRows.Count > 0)
                {
                    PVModuleDBObject pvModuleDBEditObj = new PVModuleDBObject();
                    pvModuleDBEditObj.ItemID = Convert.ToUInt32(gridViewModules.SelectedRows[0].Cells["ItemID"].Value);
                    pvModuleDBEditObj.CompanyName = Convert.ToString(gridViewModules.SelectedRows[0].Cells["CompanyName"].Value);
                    pvModuleDBEditObj.ModelNumber = Convert.ToString(gridViewModules.SelectedRows[0].Cells["ModelNumber"].Value);
                    pvModuleDBEditObj.OtherText = Convert.ToString(gridViewModules.SelectedRows[0].Cells["OtherText"].Value);
                    pvModuleDBEditObj.ModuleType = Convert.ToString(gridViewModules.SelectedRows[0].Cells["ModuleType"].Value);
                    pvModuleDBEditObj.Price = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Price"].Value);
                    pvModuleDBEditObj.Currency = Convert.ToString(gridViewModules.SelectedRows[0].Cells["Currency"].Value);
                    pvModuleDBEditObj.PowerOutput = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["PowerOutput"].Value);
                    //pvModuleDBEditObj.PowerOutputTolerances = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["PowerOutputTolerances"].Value);
                    pvModuleDBEditObj.ModuleEfficiency = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["ModuleEfficiency"].Value);
                    pvModuleDBEditObj.Vmpp = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Vmpp"].Value);
                    pvModuleDBEditObj.Impp = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Impp"].Value);
                    pvModuleDBEditObj.Voc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Voc"].Value);
                    pvModuleDBEditObj.Isc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Isc"].Value);
                    pvModuleDBEditObj.NOCT = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["NOCT"].Value);
                    pvModuleDBEditObj.TempCoePmax = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoePmax"].Value);
                    pvModuleDBEditObj.TempCoeVoc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoeVoc"].Value);
                    pvModuleDBEditObj.TempCoeIsc = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoeIsc"].Value);
                    pvModuleDBEditObj.TempCoeVmpp = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["TempCoeVmpp"].Value);
                    pvModuleDBEditObj.Length = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Length"].Value);
                    pvModuleDBEditObj.Width = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Width"].Value);
                    pvModuleDBEditObj.Thickness = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Thickness"].Value);
                    pvModuleDBEditObj.Weight = Convert.ToDouble(gridViewModules.SelectedRows[0].Cells["Weight"].Value);
                    using (EditModuleInformation dialogEditSelect = new EditModuleInformation(pvModuleDBEditObj))
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
