using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper.WPF
{
    class AD
    {

        public string GetPasswordExperationDate()
        {
            string result;
            try
            {
                var adAuth = new PrincipalContext(ContextType.Domain, Environment.UserDomainName);
                var user = UserPrincipal.FindByIdentity(adAuth, Environment.UserName);
                result = GetPasswordExpirationDateUserFromAD(user);
            }
            catch (Exception ex)
            {
                result = "AD offline";
            }
            return result;
        }

        private static string GetPasswordExpirationDateUserFromAD(UserPrincipal user)
        {
            string result;
            try
            {
                var deUser = (DirectoryEntry)user.GetUnderlyingObject();
                var nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;
                result = nativeDeUser.PasswordExpirationDate.ToString();
            }
            catch (Exception ex)
            {
                result = "AD offline";
            }
            return result;
        }
    }
}
