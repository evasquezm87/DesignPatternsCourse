using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class Log
    {
        /*Propiedad readonly para que solo sea de lectura, no se pueda editar
        static, para que pertenezca a la clase y no al objeto
       se hace del mismo tipo de la clase
       por conveniencia en C# las propiedades privadas inician con "_"*/
        private readonly static Log _instance = new Log(); //Una vez compilado el proyecto se crea el objeto
        private string _path = "log.txt";
        public string Path; //Para acceder a la variable

        //Validar que no se pueda crear otro objeto de la clase
        //Crear un constructor privado, para que no se pueda crear desde otra parte??
        private Log() 
        {
            Path = _path; //Al crear el objeto pasarle el valor de la varaible privada a la variable publica
        }

        /*Acceso al atributo, al unico objeto d ela clase
         * */
        public static Log Instance 
        { 
            get { 
                return _instance; 
            } 
        }

        //Funcionalidad dentro del Singleton
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
