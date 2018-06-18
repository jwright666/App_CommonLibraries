using App_CommonLibraries.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.Objects.Common
{
    public class Customer : Location
    {
        public string TaxRegNo { get; set; }
        public string Salesman { get; set; }
        public decimal CreditLimit { get; set; }
        public string AR_Accnt_Code{ get; set; }
        public string AP_Accnt_Code{ get; set; }
        public string Currency_Code { get; set; }
        public bool Taxable { get; set; }
        public bool Vendor_Y_N;
        public int Terms { get; set; }
    }
}
