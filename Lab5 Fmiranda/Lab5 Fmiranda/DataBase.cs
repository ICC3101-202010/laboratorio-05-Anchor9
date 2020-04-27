using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Fmiranda
{
    public class DataBase
    {
        // {usuario, correo, password, linkver, fecha, n_tel}
        private Dictionary<int, List<string>> registered; // (tipo de keys, tipo del valor)

        public DataBase()
        {
           
            registered = new Dictionary<int, List<string>>();
        }

        //Change password
        public void ChangePassword(string usuario, string new_password) 
        {
            foreach (List<string> user in this.registered.Values) //values son los valores del diccionario
                //recorro los elementos y le cambio la contraseña 
            {
                if(user[0] == usuario)
                {
                    user[2] = new_password;
                }
            }
        }

        //Add person
        public string AddUser(List<string> data) 
        {
            string description = null;
            foreach (List<string> value in this.registered.Values)
            {
                if (data[0]== value[0]) 
                {
                    description = "Name is alredy exist";
                }
                else if(data[1] == value[1]) 
                {
                    description = "mail alredy exists";
                }
            }
            if (description == null)
            {
                this.registered.Add(registered.Count + 1, data); //la posicion del dato y los datos, que es lista de string
            }

            return description;
        }

        //User data
        public List<string> GetData(string usuario) 
        {
            foreach (List<string> user in this.registered.Values) 
            { 
                if(user[0] == usuario) 
                {
                    return user;
                }            
            }
            return new List<string>(); // si no lo obtiene
        }

        //User Login sin equivocarse o que coinciden
        public string Login(string username, string password) 
        {
            string description = null;
            foreach (List<string> user in this.registered.Values) 
            { 
                if(user[0] == username && user[2] == password) 
                {
                    return description;

                }
            }
            return "Invalid user and password";



        }
 
        
    }
}
