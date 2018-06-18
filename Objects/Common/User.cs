using System;
using System.Collections.Generic;
using System.Text;

namespace App_CommonLibraries.Objects.Common
{
    public class User
    {
        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Branch DefaultBranch { get; set; }

        public int DefaultLanguage { get; set; }

        public User()
        {
            this.UserID = "";
            this.FirstName = "";
            this.LastName = "";
            this.DefaultBranch = new Branch();
            this.DefaultLanguage = 1;
        }

        public static User GetUser(string userID)
        {
            return null;
        }

        public static bool ValidateUser(string userID, string serverName)
        {
            if (userID.Length == 0 || serverName.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
