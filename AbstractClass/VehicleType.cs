using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.AbstractClass
{
    abstract class VehicleType
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double TareWeight { get; set; }
        public double MaxWeight { get; set; }
        public double UpperWeightLimit { get; set; }

    }
}
