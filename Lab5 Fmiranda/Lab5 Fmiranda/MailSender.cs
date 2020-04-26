using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    public class MailSender
    {
        public void OnRegistered(object source, RegisterEventArgs e) //Tiene que recibir los mismos paramteros para que si sea el evento correcto
        {
            Thread.Sleep(2000);
            Console.WriteLine("Bien hecho");

        }

        public void  OnPasswordChanged(object source, ChangePasswordEventArgs e) 
        {
            Thread.Sleep(2000);
            Console.WriteLine("Bien hecho x2");
        }
    }
}
