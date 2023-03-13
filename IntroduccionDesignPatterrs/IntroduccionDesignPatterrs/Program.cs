using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionDesignPatterrs
{
    /*Ejemplo basico para creación de una clase y crear un objeto desde esa clase*/
    internal class Program
    {
        static void Main(string[] args)
        {
            //Objeto de la clase persona
            Person luis = new Person("Luis", 36, "Mexican");
            Person jonh = new Person("Jonh", 45, "American");
            Person juliette = new Person("Julliete", 25, "French");

            Console.WriteLine(luis.show());
            Console.WriteLine(jonh.show());
            Console.WriteLine(juliette.show());
            Console.ReadLine();

        }
    }

    class Person
    {
        public string name;
        public int age;
        public string nationality;

        //Constructor, cuando se llama la clase se crea
        //Cuando se cree un objeto de esta clase se deben enviar los parametros para crearlo
        public Person(string name_, int age_, string nationality_)
        {
            name = name_;
            age = age_;
            nationality = nationality_;
        }

        //Metodo para mostrar información
        public string show()
        {
            return name + " - " + age + " - " + nationality;
        }
    }
}
