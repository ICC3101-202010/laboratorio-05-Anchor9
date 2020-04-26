using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    public class Server
    {
        //EVENTOS, clases que no se conozcan se cominuquen entre si, osea que no hay acoplamiento, sin metodos ni nada
        //Es porque solo hace 1 vez, no necesita estar constantemente con un atributo acá para que lo conozca, con un puro click
        //ya voy a saber que necesito realizar cierta accion.

        //El mailsender no ncesita estar acoplado para que sepa, por eso se usa eventos, disparo un solo evento y los sender cuando
        // escuchen eso, tienen que disparar el evento  


        // PASO 1 ---- CREAR EL DELEGATE

        public delegate void RegisterEventHandler(object source, RegisterEventArgs args); //object es un generico porque no se cual es  

        //Register event args --> terremoto, saber epicentro, magnitud etc, 
        //El register evet args me define que es lo que quiero saber, por eso yo defino mis propios event args, voy a crear una clase
        //que obtenga los args que yo quiero saber, los cuales son, nombre contraseña y esos.


        //PASO 2 ---- CREAMOS EL EVENTO QUE SE DISPARA CUANDO EL USUARIO SE REGISTRA

        public event RegisterEventHandler Registered;  //Poner el nombre del evento en pasado


        //PASO 3 ----- PUBLICAR EL EVENTO, notar que si se quiere publicar el evento, se debe llamar


        //El server dice, oye alguien se registró, a alguien le importa?? si --> a mailsender
        protected virtual void OnRegistered(string username, string password, string verificationLink, string email)
            //recibo parametros necesarios ara crear el objeto
        {
            if (Registered != null)//veo si hay alguien suscrito --> tiene que haber alguien que le importe la informacion 
            {
                //si hay alguien registrado, le paso el evento
                Registered(this, new RegisterEventArgs() { VerificationLink = verificationLink, Password = password, Username = username, Email = email });
                //Esto es lo que ncesito para informar
            }
        }



        public delegate void ChangePasswordEventHandler(object source, ChangePasswordEventArgs args);
        public event ChangePasswordEventHandler PasswordChanged;
        protected virtual void OnPasswordChanged(string username, string email, string number) 
        {
            if (PasswordChanged != null) 
            { 
                PasswordChanged(this, new ChangePasswordEventArgs() { Username = username, Email = email, Number = number });
            }
        
        }
        public DataBase Data 
        {
            get;  
        }
        public Server(DataBase data) //server conoce a database
        {
            this.Data = data;
        }

        public void Register() 
        {
            Console.Write("Welcome, Loggin on the website");
            string usuario = Console.ReadLine();
            Console.Write("E-mail");
            string email = Console.ReadLine();
            Console.Write("Password");
            string password = Console.ReadLine();
            Console.Write("Number");
            string number = Console.ReadLine();

            string verificationLink = GenerateLink(usuario);

            string result = Data.AddUser(new List<string>() { usuario, email, password, verificationLink, Convert.ToString(DateTime.Now), number });
            if (result == null) 
            {
                //Disparo evento
                OnRegistered(username: usuario,password: password, verificationLink: verificationLink, email: email);
            }
            else 
            {
                Console.WriteLine("ERROR: " + result + "\n");
            
            }
        }

        public void ChangePassword() 
        {
            Console.Write("Welcome, Loggin on the website");
            string usuario = Console.ReadLine();
            Console.Write("Password");
            string password = Console.ReadLine();

            string result = Data.Login(username: usuario, password: password);
            if (result == null)
            {
                Console.Write("Enter new password");
                string new_password = Console.ReadLine();
                Data.ChangePassword(usuario, new_password);
                List<string> data = Data.GetData(usuario);
                //Tomo los datos de datbase y despues disparo el evento, el evento viene a continuacion
                OnPasswordChanged(username: data[0], email: data[1], number: data[5]);            
            }
            else 
            {
                Console.WriteLine("ERROR: " + result);             
            }
        }

        public string GenerateLink(string usuario) 
        {
            Random random = new Random();
            string result = "";
            for (int ctr = 0; ctr <=99; ctr++) 
            {
                char random_link = (char)random.Next(33, 126);
                result = result + random_link;
            
            }
            return "http://Myownwbesite.com/verificar-correo.php?=" + usuario + "-" + result;        
        }
    }
}
