using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    public class ChangePasswordEventArgs : EventArgs
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
        public string Number
        {
            get;
            set;
        }

    }
}
