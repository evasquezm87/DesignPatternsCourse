using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class Config
    {
        private readonly static Config _instance = new Config(); //Una vez compilado el proyecto se crea el objeto

        //Validar que no se pueda crear otro objeto de la clase
        //Crear un constructor privado, para que no se pueda crear desde otra parte??
        public string path = "";
        public string url = "";
        public string user = "";
        public string password = "";
        private Config() 
        {
            readConfig();
        }

        /*Acceso al atributo, al unico objeto d ela clase
         * */
        public static Config Instance { get { return _instance; } }

        private void readConfig()
        {
            path = @"C:\MyFolder";
            url = "www.mydataconnextion.com:1454";
            user = "myUserUnique";
            password = "ki@ju4æ54g";

        }

    }
}
