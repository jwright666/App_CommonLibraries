using System;
using System.Collections.Generic;
using System.Text;
using App_CommonLibraries.Objects;

namespace App_CommonLibraries.Objects.Common
{
    public class UserAccess
    {
        public User User { get; set; }
        public List<ItemAccess> ModuleItemAccess { get; set; }

        public UserAccess()
        {
            this.User = new User();
            this.ModuleItemAccess = new List<ItemAccess>();
        }

        public static UserAccess GetUserAccess(User user)
        {
            return null;
        }

        public static ItemAccess GetUserAccessRightsForModuleItem(User user, string moduleItem)
        {
            return null;
        }

        public static bool IsModuleItemAllowed(User user, string moduleItem)
        {
            return false; // UserAccessDAL.IsModuleItemAllowed(user, moduleItem);
        }
    }
}
