using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    class ModuleSelectionObject
    {
        public UInt16 SelectedItemID { get; set; }
        public UInt16 NumberOfModule { get; set; }
        public UInt16 FavModule1 { get; set; }
        public UInt16 FavModule2 { get; set; }
        public UInt16 FavModule3 { get; set; }
        public UInt16 FavModule4 { get; set; }
        public UInt16 FavModule5 { get; set; }
        public string SelectionMethod { get; set; }
        public string ModuleSelectionMode { get; set; }
        public double AvailableArea { get; set; }
        public double RequriedArea { get; set; }
        public double TotalPower { get; set; }
        public double InterspaceLength { get; set; }
        public bool isSelected { get; set; }
    }
}
