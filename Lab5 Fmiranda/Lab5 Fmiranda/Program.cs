using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    class Program
    {
        static void Main(string[] args)
        {
            // PRIMERO CERO LOS OBJETOS
            User user = new User();
            DataBase database = new DataBase();
            Server server = new Server(database);
            MailSender mailSender = new MailSender(); //De lo unico que se encrga es mandar el correo
            SMSsender smsSender = new SMSsender();



            // ESTA ES LA SUSCRIPCION --- ESTO ES LO SEGUNDO QUE HAGO
            server.Registered += mailSender.OnRegistered; //tienes que suscribir 
            server.PasswordChanged += mailSender.OnPasswordChanged;
            server.PasswordChanged += smsSender.OnPasswordChanged;

            //Se le envia correo cuando se registra, se envia mensaje cuando se registra.

            mailSender.EmailSent += user.OnEmailSent;
            user.EmailVerified += server.OnEmailVerified;



            // RECIEN AHORA EMPIEZO A HACER  EL FLUJO DEL PROGRAMA
            bool exec = true;
            while (true) 
            {
                string chosen = ShowOptions(new List<string>() {"Registrarse", "Cambiar contraseña", "Salir" });
                switch (chosen)
                {
                    case "Registrarse":
                        Console.Clear();
                        server.Register();
                        break;

                    case "Cambiar contraseña":
                        Console.Clear();
                        server.ChangePassword();
                        break;
                    case "Salir":
                        exec = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }




        }
        private static string ShowOptions(List<string> options) 
        {
            int i = 0;
            Console.WriteLine("\n Seleccione una opcion:");
            foreach (string option in options) 
            {
                Console.WriteLine(Convert.ToString(i) + ", " + option);
                i += 1;
            }
            return options[Convert.ToInt16(Console.ReadLine())];
        }
    }
}
