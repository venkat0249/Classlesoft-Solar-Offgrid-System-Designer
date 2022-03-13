//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    class InveterSelectionObject
    {
        public UInt16 SelectedItemID { get; set; }
        
        public UInt16 FavInv1 { get; set; }
        public UInt16 FavInv2 { get; set; }
        public UInt16 FavInv3 { get; set; }
        public UInt16 FavInv4 { get; set; }
        public UInt16 FavInv5 { get; set; }
        public string SelectionMethod { get; set; }
        public string InvSelectionMode { get; set; }
        public double VmppMax { get; set; }
        public double VmppMin { get; set; }
        public double VocMax { get; set; }
        public double ReqPowerMax { get; set; }
        public double ReqPowerMin { get; set; }
        public int ModulesPerString { get; set; }
        public int StringNumber { get; set; }
        public int T2ModulesPerString { get; set; }
        public int T2StringNumber { get; set; }
        public int MaxModules { get; set; }
        public int MinModules { get; set; }
        public double MaxArrayCurrent { get; set; }
    }
}
