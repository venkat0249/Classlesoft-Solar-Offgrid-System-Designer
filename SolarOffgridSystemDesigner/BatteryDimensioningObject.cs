using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    class BatteryDimensioningObject
    {
        int _NumberOfCells;
        double _Daut;
        double _DoD;
        double _InverterBatteryVoltage;
        double _BatteryCapacityRequired;
        double _BatteryEfficiency;
        int _CellSeries;
        double _CellCapacity;
        double _CellVoltage;
        int _CellsParallel;
        double _RestitutionEnergy;
        double _FinalCapacity;
        //UInt16 _SeriesBatteries;
        

        public double Daut
        {
            get { return _Daut; }
            set { _Daut = value; }
        }

        public double DoD
        {
            get { return _DoD; }
            set { _DoD = value; }
        }

        public double InverterBatteryVoltage
        {
            get { return _InverterBatteryVoltage; }
            set { _InverterBatteryVoltage = value; }
        }

        public double BatteryCapacityRequired
        {
            get { return _BatteryCapacityRequired; }
            set { _BatteryCapacityRequired = value; }
        }

        public double BatteryEfficiency
        {
            get { return _BatteryEfficiency; }
            set { _BatteryEfficiency = value; }
        }

        public int CellSeries
        {
            get { return _CellSeries; }
            set { _CellSeries = value; }
        }

        public double CellCapacity
        {
            get { return _CellCapacity; }
            set { _CellCapacity = value; }
        }
        public double CellVoltage
        {
            get { return _CellVoltage; }
            set { _CellVoltage = value; }
        }
        public int CellsParallel
        {
            get { return _CellsParallel; }
            set { _CellsParallel = value; }
        }
        public double RestitutionEnergy
        {
            get { return _RestitutionEnergy; }
            set { _RestitutionEnergy = value; }
        }

        public double FinalCapacity
        {
            get { return _FinalCapacity; }
            set { _FinalCapacity = value; }
        }
        public int NumberOfCells
        {
            get { return _NumberOfCells; }
            set { _NumberOfCells = value; }
        }

    }
}
