using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary
{
   public class UserManager
    {
        private User user;
        private User[] users;
        public UserManager()
        {
            users = initUsers();
        }



        public User getUserFromUsername(String pusername)
        {
            User mUser = new User();

            switch (pusername)
            {
                case "vscheidecker":
                    mUser.firstName = "Victor";
                    mUser.lastName = "Scheidecker";
                    mUser.username = "vscheidecker";
                    mUser.password = "VS2017";
                    mUser.userId = 1;
                    break;
                case "sdaeden":
                    mUser.firstName = "Samuel";
                    mUser.lastName = "Daeden";
                    mUser.username = "sdaeden";
                    mUser.password = "SD2017";
                    mUser.userId = 2;
                    break;
                case "ablanchard":
                    mUser.firstName = "Alexandre";
                    mUser.lastName = "Blanchard";
                    mUser.username = "ablanchard";
                    mUser.password = "AB2017";
                    mUser.userId = 0;
                    break;
            }
            return mUser;
        }
        private User[] initUsers()
        {
            var initUser = new User[3];
            initUser[0] = getUserFromId(1);
            initUser[1] = getUserFromId(2);
            initUser[2] = getUserFromId(3);
            return initUser;
        }

        private User getUserFromId(int pUserId)
        {
            User mUser = new User();
            switch (pUserId)
            {
                case 1:
                    mUser.firstName = "Victor";
                    mUser.lastName = "Scheidecker";
                    mUser.username = "vscheidecker";
                    mUser.password = "VS2017";
                    mUser.userId = 1;
                    break;
                case 2:
                    mUser.firstName = "Samuel";
                    mUser.lastName = "Daeden";
                    mUser.username = "sdaeden";
                    mUser.password = "SD2017";
                    mUser.userId = 2;
                    break;
                default:
                    mUser.firstName = "Alexandre";
                    mUser.lastName = "Blanchard";
                    mUser.username = "ablanchard";
                    mUser.password = "AB2017";
                    mUser.userId = 0;
                    break;
            }
            return mUser;
        }
    }
}
