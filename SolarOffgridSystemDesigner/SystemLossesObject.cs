using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    class SystemLossesObject
    {

        string _Method; //ignored for this version
        double _Ka;
        double _Kb;
        double _Kc;
        double _Kr;
        double _Kx;
        double _Daut;
        double _Pd;
        double _Kt;
        double _KwhEnergyNeededWithLosses;



        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }

        public double Ka
        {
            get { return _Ka; }
            set { _Ka = value; }
        }

        public double Kb
        {
            get { return _Kb; }
            set { _Kb = value; }
        }

        public double Kc
        {
            get { return _Kc; }
            set { _Kc = value; }
        }

        public double Kr
        {
            get { return _Kr; }
            set { _Kr = value; }
        }

        public double Kx
        {
            get { return _Kx; }
            set { _Kx = value; }
        }

        public double Daut
        {
            get { return _Daut; }
            set { _Daut = value; }
        }

        public double Pd
        {
            get { return _Pd; }
            set { _Pd = value; }
        }

        public double Kt
        {
            get { return _Kt; }
            set { _Kt = value; }
        }

        public double KwhEnergyNeededWithLosses
        {
            get { return _KwhEnergyNeededWithLosses; }
            set { _KwhEnergyNeededWithLosses = value; }
        }
    }
}
