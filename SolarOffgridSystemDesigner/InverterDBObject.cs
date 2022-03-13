//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    public class InverterDBObject
    {
        UInt32 _ItemID;
        string _CompanyName;
        string _ModelNumber;
        string _OtherText;
        string _InverterType;
        double _Price;
        string _Currency;
        double _RatedPower;
        double _PV_MaxDCPower;
        double _PV_Nominal_DC_Voltage;
        double _PV_Maximum_DC_Voltage;
        double _PV_Max_MPP_Voltage;
        double _PV_Min_MPP_Voltage;
        double _PV_Maximum_Input_Current;
        double _Bat_Nominal_DC_Voltage;
        int _PV_MPPTrackers;
        string _Dimension;
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
        public string InverterType
        {
            get { return _InverterType; }
            set { _InverterType = value; }
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

        public double RatedPower
        {
            get { return _RatedPower; }
            set { _RatedPower = value; }
        }

        public double PV_MaxDCPower
        {
            get { return _PV_MaxDCPower; }
            set { _PV_MaxDCPower = value; }
        }

        public double PV_Nominal_DC_Voltage
        {
            get { return _PV_Nominal_DC_Voltage; }
            set { _PV_Nominal_DC_Voltage = value; }
        }

        public double PV_Maximum_DC_Voltage
        {
            get { return _PV_Maximum_DC_Voltage; }
            set { _PV_Maximum_DC_Voltage = value; }
        }

        public double PV_Max_MPP_Voltage
        {
            get { return _PV_Max_MPP_Voltage; }
            set { _PV_Max_MPP_Voltage = value; }
        }

        public double PV_Min_MPP_Voltage
        {
            get { return _PV_Min_MPP_Voltage; }
            set { _PV_Min_MPP_Voltage = value; }
        }

        public double PV_Maximum_Input_Current
        {
            get { return _PV_Maximum_Input_Current; }
            set { _PV_Maximum_Input_Current = value; }
        }

        public double Bat_Nominal_DC_Voltage
        {
            get { return _Bat_Nominal_DC_Voltage; }
            set { _Bat_Nominal_DC_Voltage = value; }
        }

        public int PV_MPPTrackers
        {
            get { return _PV_MPPTrackers; }
            set { _PV_MPPTrackers = value; }
        }

        public string Dimension
        {
            get { return _Dimension; }
            set { _Dimension = value; }
        }

        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
    }
}
