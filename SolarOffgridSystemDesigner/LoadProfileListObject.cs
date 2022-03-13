//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    class LoadProfileListObject
    {
        public UInt16 ItemID { get; set; }
        public UInt16 NumberOfEquipment { get; set; }
        public Single DayOperatingHours { get; set; }
        public Single NightOperatingHours { get; set; }
        public string BuildingSegment { get; set; }
        public string AC_DC { get; set; }
        public string Equipment { get; set; }
        public string LoadType { get; set; }
        public double RatedPower { get; set; }
        public double AdjustedPower { get; set; }
        public double CurrentOfSystem { get; set; }
        public double DayEnergyRequirement { get; set; }
        public double NightEnergyRequirement { get; set; }

        public LoadProfileListObject()
        { }

        public LoadProfileListObject(UInt16 ItemID,UInt16 NumberOfEquipment,Single DayOperatingHours,Single NightOperatingHours, string BuildingSegment, 
            string AC_DC, string Equipment, string LoadType, double RatedPower, double AdjustedPower, double CurrentOfSystem, double DayEnergyRequirement, double NightEnergyRequirement)
        {
            this.ItemID = ItemID;
            this.NumberOfEquipment = NumberOfEquipment;
            this.DayOperatingHours=DayOperatingHours;
            this.NightOperatingHours = NightOperatingHours;
            this.BuildingSegment = BuildingSegment;
            this.AC_DC=AC_DC;
            this.Equipment= Equipment;
            this.LoadType=LoadType;
            this.RatedPower=RatedPower;
            this.AdjustedPower=AdjustedPower;
            this.CurrentOfSystem=CurrentOfSystem;
            this.DayEnergyRequirement=DayEnergyRequirement;
            this.NightEnergyRequirement=NightEnergyRequirement;
        }

    }

    class LoadProfileObject
    {
        string _Method;
        //double _SystemVoltage;
        //double _ConversionFactor;
        //double _SecurityFactor;
        double _TotalCurrentOfSystem;
        double _Pmax;
        double _Kt;
        double _TotalDayEnergyRequirement;
        double _TotalNightEnergyRequirement;
        double _TotalEnergyNeedWithOutLoss;
        double _TotalEnergyNeededWithLoss;


        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }

        //public double SystemVoltage
        //{
        //    get { return _SystemVoltage; }
        //    set { _SystemVoltage = value; }
        //}

        //public double ConversionFactor
        //{
        //    get { return _ConversionFactor; }
        //    set { _ConversionFactor = value; }
        //}

        //public double SecurityFactor
        //{
        //    get { return _SecurityFactor; }
        //    set { _SecurityFactor = value; }
        //}


        public double TotalCurrentOfSystem
        {
            get { return _TotalCurrentOfSystem; }
            set { _TotalCurrentOfSystem = value; }
        }

        public double Pmax
        {
            get { return _Pmax; }
            set { _Pmax = value; }
        }
        public double Kt
        {
            get { return _Kt; }
            set { _Kt = value; }
        }

        public double TotalDayEnergyRequirement
        {
            get { return _TotalDayEnergyRequirement; }
            set { _TotalDayEnergyRequirement = value; }
        }

        public double TotalNightEnergyRequirement
        {
            get { return _TotalNightEnergyRequirement; }
            set { _TotalNightEnergyRequirement = value; }
        }

        public double TotalEnergyNeedWithOutLoss
        {
            get { return _TotalEnergyNeedWithOutLoss; }
            set { _TotalEnergyNeedWithOutLoss = value; }
        }

        public double TotalEnergyNeededWithLoss
        {
            get { return _TotalEnergyNeededWithLoss; }
            set { _TotalEnergyNeededWithLoss = value; }
        }

    }
}
