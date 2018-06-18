using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App_CommonLibraries.Objects.Common
{
    public class Branch
    {
        public string Code {get;set;}
        public string Description { get; set; }



        public Branch()
        {
            this.Code = "";
            this.Description = ""; 
        }
	
        public static DataTable GetAllBranches()
        {
            return null;
        }  

        public override string ToString()
        {
            return this.Code.ToString();
        }
    }

}
