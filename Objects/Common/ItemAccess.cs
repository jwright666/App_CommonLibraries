using System;
using System.Collections.Generic;
using System.Text;

namespace App_CommonLibraries.Objects.Common
{
    public class ItemAccess
    {
        public string ModuleItem { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Browse { get; set; }
        public bool Print { get; set; }
        public bool Post { get; set; }
        public bool AdminRight { get; set; }

        public ItemAccess()
        {
            this.ModuleItem = "";
            this.Add = false;
            this.Edit = false;
            this.Delete = false;
            this.Browse = false;
            this.Print = false;
            this.Post = false;
            this.AdminRight = false;
        }

    }
}
