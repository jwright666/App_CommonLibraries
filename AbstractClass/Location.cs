using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.AbstractClass
{
    public abstract class Location
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Zone { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }

        public Location()
        {
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.CountryCode = string.Empty;
            this.Zone = string.Empty;
            this.Province = string.Empty;
            this.City = string.Empty;
            this.Zipcode = string.Empty;
            this.Address1 = string.Empty;
            this.Address2 = string.Empty;
            this.Address3 = string.Empty;
            this.Address4 = string.Empty;
            this.Phone1 = string.Empty;
            this.Phone2 = string.Empty;
            this.Phone3 = string.Empty;
            this.Fax1 = string.Empty;
            this.Fax2 = string.Empty;
            this.Contact1 = string.Empty;
            this.Contact2 = string.Empty;
            this.Email1 = string.Empty;
            this.Email2 = string.Empty;
        }
    }
}
