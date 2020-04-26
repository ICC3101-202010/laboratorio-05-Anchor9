using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    public class RegisterEventArgs : EventArgs //tiene que si o si heredar para asi yo poder customizar mis datos
    {
        public string Username 
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string VerificationLink
        {
            get;
            set;
        }
    }
}
