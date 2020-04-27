using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab5_Fmiranda
{
    public class SMSsender
    {
        public void OnPasswordChanged(object source, ChangePasswordEventArgs e) 
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nSMS enviado a {e.Number}: \n {e.Username}, your password has been changed \n");
        }
        public SMSsender()
        {
            
        }
    }
}
