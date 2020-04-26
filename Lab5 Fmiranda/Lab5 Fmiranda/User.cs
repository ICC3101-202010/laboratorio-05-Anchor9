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

        //Publicar el evento (3)
        public void OnEmailSent(object source, EventArgs e ) 
        { 
            //Aqui va el codigo...
        }

    }
}
