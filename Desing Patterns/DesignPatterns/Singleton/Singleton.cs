using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class Singleton
    {
        /*Propiedad readonly para que solo sea de lectura, no se pueda editar
         static, para que pertenezca a la clase y no al objeto
        se hace del mismo tipo de la clase
        por conveniencia en C# las propiedades privadas inician con "_"*/
        private readonly static Singleton _instance= new Singleton(); //Una vez compilado el proyecto se crea el objeto

        //Validar que no se pueda crear otro objeto de la clase
        //Crear un constructor privado, para que no se pueda crear desde otra parte??
        private Singleton() { }

        /*Acceso al atributo, al unico objeto d ela clase
         * */
        public static Singleton Instance { get { return _instance;} }


    }
}
