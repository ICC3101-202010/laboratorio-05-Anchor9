using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    public class User
    //LO que hay que hacer es: la forma en que usuario responda el correo imaginar que recibo el correo, darle click al correo de verif
    // y efectivamente verificar el correo
    //EmailOn emailSEnt
    {
        //Defino delegate  (1)
        public delegate void EmailVerifiedEventHandler(object source, EventArgs args);

        //Defino  el evento  (2)
        public event EmailVerifiedEventHandler EmailVerified;

        //Publico el evento (3)
        protected virtual void OnEmailVerified()
        {
            if (EmailVerified != null)
            {
                EmailVerified(this, EventArgs.Empty);
            }
        }

        public void OnEmailSent(object source, EventArgs e) 
        {
            Console.WriteLine("Do you want to verify your email? \n[1]Yes \n[2]No");
            string answer = Console.ReadLine();
            while (answer != "1" && answer != "2") 
            {
                Console.WriteLine("Invalid, re-enter");
            }
            if (answer == "1") 
            {

                //Aqui se gatilla el evento
                OnEmailVerified();
            }
            else 
            {
                Console.WriteLine("Continue");
            }
        }   

    }
}
