using App_CommonLibraries.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.Objects.Common
{
    public class Operation : Location
    {
        public string Added_By_Who { get; set; }
        public DateTime Added_Date_Time { get; set; }
        public string Changed_By_Who { get; set; }
        public DateTime Changed_Date_Time { get; set; }

        public Operation() : base()
        {
            this.Added_By_Who = string.Empty;
            this.Added_Date_Time = DateTime.Today;
            this.Changed_By_Who = string.Empty;
            this.Changed_Date_Time = DateTime.Today;
        }
    }
}
