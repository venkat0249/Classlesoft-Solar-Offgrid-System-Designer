using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    public class PVModuleDBObject
    {
        UInt32 _ItemID;
        string _CompanyName;
        string _ModelNumber;
        string _OtherText;
        string _ModuleType;
        double _Price;
        string _Currency;
        double _PowerOutput;
        double _PowerOutputTolerances;
        double _ModuleEfficiency;
        double _Vmpp;
        double _Impp;
        double _Voc;
        double _Isc;
        double _NOCT;
        double _TempCoePmax;
        double _TempCoeVoc;
        double _TempCoeIsc;
        double _TempCoeVmpp;
        double _Length;
        double _Width;
        double _Thickness;
        double _Weight;

        public UInt32 ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        public string ModelNumber
        {
            get { return _ModelNumber; }
            set { _ModelNumber = value; }
        }
        public string OtherText
        {
            get { return _OtherText; }
            set { _OtherText = value; }
        }
        public string ModuleType
        {
            get { return _ModuleType; }
            set { _ModuleType = value; }
        }

        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }

        public double PowerOutput
        {
            get { return _PowerOutput; }
            set { _PowerOutput = value; }
        }

        public double PowerOutputTolerances
        {
            get { return _PowerOutputTolerances; }
            set { _PowerOutputTolerances = value; }
        }

        public double ModuleEfficiency
        {
            get { return _ModuleEfficiency; }
            set { _ModuleEfficiency = value; }
        }

        public double Vmpp
        {
            get { return _Vmpp; }
            set { _Vmpp = value; }
        }

        public double Impp
        {
            get { return _Impp; }
            set { _Impp = value; }
        }

        public double Voc
        {
            get { return _Voc; }
            set { _Voc = value; }
        }

        public double Isc
        {
            get { return _Isc; }
            set { _Isc = value; }
        }

        public double NOCT
        {
            get { return _NOCT; }
            set { _NOCT = value; }
        }

        public double TempCoePmax
        {
            get { return _TempCoePmax; }
            set { _TempCoePmax = value; }
        }

        public double TempCoeVoc
        {
            get { return _TempCoeVoc; }
            set { _TempCoeVoc = value; }
        }

        public double TempCoeIsc
        {
            get { return _TempCoeIsc; }
            set { _TempCoeIsc = value; }
        }

        public double TempCoeVmpp
        {
            get { return _TempCoeVmpp; }
            set { _TempCoeVmpp = value; }
        }

        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public double Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public double Thickness
        {
            get { return _Thickness; }
            set { _Thickness = value; }
        }

        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        
    }
}
