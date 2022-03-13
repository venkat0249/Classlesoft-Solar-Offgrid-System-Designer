using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarOffgridSystemDesigner
{
    
        
        public class Metadata
        {
            public List<string> sources { get; set; }
        }

        public class Inputs
        {
            public string lat { get; set; }
            public string lon { get; set; }
        }

        public class Monthly
        {
            public double jan { get; set; }
            public double feb { get; set; }
            public double mar { get; set; }
            public double apr { get; set; }
            public double may { get; set; }
            public double jun { get; set; }
            public double jul { get; set; }
            public double aug { get; set; }
            public double sep { get; set; }
            public double oct { get; set; }
            public double nov { get; set; }
            public double dec { get; set; }
        }

        public class AvgDni
        {
            public double annual { get; set; }
            public Monthly monthly { get; set; }
        }

        public class Monthly2
        {
            public double jan { get; set; }
            public double feb { get; set; }
            public double mar { get; set; }
            public double apr { get; set; }
            public double may { get; set; }
            public double jun { get; set; }
            public double jul { get; set; }
            public double aug { get; set; }
            public double sep { get; set; }
            public double oct { get; set; }
            public double nov { get; set; }
            public double dec { get; set; }
        }

        public class AvgGhi
        {
            public double annual { get; set; }
            public Monthly2 monthly { get; set; }
        }

        public class Monthly3
        {
            public double jan { get; set; }
            public double feb { get; set; }
            public double mar { get; set; }
            public double apr { get; set; }
            public double may { get; set; }
            public double jun { get; set; }
            public double jul { get; set; }
            public double aug { get; set; }
            public double sep { get; set; }
            public double oct { get; set; }
            public double nov { get; set; }
            public double dec { get; set; }
        }

        public class AvgLatTilt
        {
            public double annual { get; set; }
            public Monthly3 monthly { get; set; }
        }

        public class Outputs
        {
            public AvgDni avg_dni { get; set; }
            public AvgGhi avg_ghi { get; set; }
            public AvgLatTilt avg_lat_tilt { get; set; }
        }

        public class NREL_RadiationData
        {
            public string version { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public Metadata metadata { get; set; }
            public Inputs inputs { get; set; }
            public Outputs outputs { get; set; }
        }
    }

    
