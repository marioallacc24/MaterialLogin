using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLogin.Class
{
    class LoginHandler
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public LoginHandler(String user, String pass)
        {
            this.Username = user;
            this.Password = pass;
        }

        public bool IsLoginIn(string user, string pass)
        {
            if(Username == user && Password == pass)
                return true;

            return false;
        }
    }
}
