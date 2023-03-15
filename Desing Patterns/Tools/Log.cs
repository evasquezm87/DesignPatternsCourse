using System;
using System.IO;

namespace Tools
{
    //Se añade la palabra reservada "sealed" para que no se pueda heredar la clase
    public sealed class Log
    {
        private static Log _instance = null; //Una vez compilado el proyecto se crea el objeto
        private string _path;
        public string Path; //Para acceder a la variable

        //Validar que no se pueda crear otro objeto de la clase
        //Crear un constructor privado, para que no se pueda crear desde otra parte??
        private Log(string path)
        {
            _path = path; //Al crear el objeto pasarle el valor de la variable recibida
        }

        //Metodo para acceder al objeto
        public static Log GetInstance(string path)
        {
            if (_instance == null) //Si al llamar el objeto es null entonces crea el objeto
            {
                _instance = new Log(path);//Crea el objeto con el parametro enviado
            }

            return _instance;//regresa la instancia del objeto
        }


        //Funcionalidad dentro del Singleton
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}