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

        //Defino delegate  (1)
        public delegate void EmailSentEventHandler(object source, EventArgs args);

        //Defino  el evento  (2)
        public event EmailSentEventHandler EmailSent;

        //Publicar el evento (3)
        protected virtual void OnEmailSent()
        {
            if (EmailSent != null)
            {
                EmailSent(this, EventArgs.Empty);
            }
        }





        public void OnRegistered(object source, RegisterEventArgs e) //Tiene que recibir los mismos paramteros para que si sea el evento correcto
        {
            Thread.Sleep(2000);
            Console.WriteLine("Bien hecho este es el metodo que envia diciendo 'su mail es' gracias al registro");

        }

        public void  OnPasswordChanged(object source, ChangePasswordEventArgs e) 
        {
            Thread.Sleep(2000);
            Console.WriteLine("Bien hecho x2");
        }

        //Tengo que crear metodo que se dispare despues de enviar el correo al ususario








    }

}
