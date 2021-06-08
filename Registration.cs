using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptionn
{
   public class Registration
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Registration(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }

        public Registration()
        {
        }
    }
}
