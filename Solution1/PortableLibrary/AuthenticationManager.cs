using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary
{
    public class AuthenticationManager
    {
        User user;
        UserManager usermanager;
        public AuthenticationManager()
        {
            user = new PortableLibrary.User();
            usermanager=new UserManager();
        }

        public Boolean authenticateUser(String pusername, String ppassword)
        {
            Boolean authenticate=false;
            user = usermanager.getUserFromUsername(pusername);
            if (user.password.Equals(ppassword))
            {
                authenticate = true;
            }
            return authenticate;
        }
    }
}
