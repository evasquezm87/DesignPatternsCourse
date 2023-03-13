using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    /*Ejemplo de herencia, crear una clase Padre que sea Abstracta
     Se crea una clase hija la cual hereda de padre
    La clase padre no se puede invocar para crear un objeto
    La clase hija se puede invocar para crear el objeto
    El objetivo de la clase padre que funcione como base o estructura*/
    internal class Program
    {
        static void Main(string[] args)
        {
            //Objeto de la clase persona
            sportyPerson luis = new sportyPerson("Luis", 36, "Mexican");
            sportyPerson jonh = new sportyPerson("Alber", 25, "American");
            sportyPerson juliette = new sportyPerson("Marian", 25, "French");

            Console.WriteLine(luis.show());
            Console.WriteLine(jonh.show());
            Console.WriteLine(juliette.show());
            
            luis.run();
            
            Console.ReadLine();
        }
    }

    abstract class Person
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

    class sportyPerson : Person
    {
        public sportyPerson(string name_, int age_, string nationality_) : base(name_, age_, nationality_)
        {

        }

        public void run()
        {
            Console.WriteLine(name + " Esta Corriendo");
        }
    }

    }
