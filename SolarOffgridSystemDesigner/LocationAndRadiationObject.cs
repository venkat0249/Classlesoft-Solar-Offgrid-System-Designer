//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    class LocationAndRadiationObject
    {
        
        string _Method;
        string _NameOfLoc;
        string _APIKey_NREL;
        double _Latitude;
        double _Longitude;
        double _Azimuth;
        double _Tilt;
        double _Kwh_Kwp;
        double _PanelConversionEff;
        double _SlopeCorrection;
        double _AzimuthCorrection;
        double _KwpRequired;

        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }

        public string NameOfLoc
        {
            get { return _NameOfLoc; }
            set { _NameOfLoc = value; }
        }
        public string APIKey_NREL
        {
            get { return _APIKey_NREL; }
            set { _APIKey_NREL = value; }
        }

        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        public double Azimuth
        {
            get { return _Azimuth; }
            set { _Azimuth = value; }
        }

        public double Tilt
        {
            get { return _Tilt; }
            set { _Tilt = value; }
        }

        public double Kwh_Kwp
        {
            get { return _Kwh_Kwp; }
            set { _Kwh_Kwp = value; }
        }

        public double PanelConversionEff
        {
            get { return _PanelConversionEff; }
            set { _PanelConversionEff = value; }
        }

        public double SlopeCorrection
        {
            get { return _SlopeCorrection; }
            set { _SlopeCorrection = value; }
        }

        public double AzimuthCorrection
        {
            get { return _AzimuthCorrection; }
            set { _AzimuthCorrection = value; }
        }

        public double KwpRequired
        {
            get { return _KwpRequired; }
            set { _KwpRequired = value; }
        }

        
    }

   public class IrradianceObject
    {
        public Single Jan { get; set; }
        public Single Feb { get; set; }
        public Single Mar { get; set; }
        public Single Apr { get; set; }
        public Single May { get; set; }
        public Single Jun { get; set; }
        public Single Jul { get; set; }
        public Single Aug { get; set; }
        public Single Sep { get; set; }
        public Single Oct { get; set; }
        public Single Nov { get; set; }
        public Single Dec { get; set; }
    }

   public class LoadObject
    {
        public Single Jan { get; set; }
        public Single Feb { get; set; }
        public Single Mar { get; set; }
        public Single Apr { get; set; }
        public Single May { get; set; }
        public Single Jun { get; set; }
        public Single Jul { get; set; }
        public Single Aug { get; set; }
        public Single Sep { get; set; }
        public Single Oct { get; set; }
        public Single Nov { get; set; }
        public Single Dec { get; set; }
    }

   public class GenObject
    {
        public Single Jan { get; set; }
        public Single Feb { get; set; }
        public Single Mar { get; set; }
        public Single Apr { get; set; }
        public Single May { get; set; }
        public Single Jun { get; set; }
        public Single Jul { get; set; }
        public Single Aug { get; set; }
        public Single Sep { get; set; }
        public Single Oct { get; set; }
        public Single Nov { get; set; }
        public Single Dec { get; set; }
    }

}
