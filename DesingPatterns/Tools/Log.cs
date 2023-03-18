using System;
using System.IO;

namespace Tools
{
    //Se añade la palabra reservada "sealed" para que no se pueda heredar la clase
    public sealed class Log
    {
        private static Log _instance = null; //Una vez compilado el proyecto se crea el objeto
        private string _path;
        //Para trabajar con concurrencia(multihilos), en caso de que esten 2 hilos entren
        //y generen los 2 una instancia cada quien, de esta manera proteger que solo se cree una
        private static object _protected = new object();


        //Validar que no se pueda crear otro objeto de la clase
        //Crear un constructor privado, para que no se pueda crear desde otra parte??
        private Log(string path)
        {
            _path = path; //Al crear el objeto pasarle el valor de la variable recibida
        }

        //Metodo para acceder al objeto
        public static Log GetInstance(string path)
        {
            lock (_protected)//Mientras esta un hilo trabajando no puede otro hilo trabajar con esto, ya que lo protege
            {
                if (_instance == null) //Si al llamar el objeto es null entonces crea el objeto
                {
                    _instance = new Log(path);//Crea el objeto con el parametro enviado
                }
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