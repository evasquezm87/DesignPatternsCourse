using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IVolador> aves = new List<IVolador>();     
            var pato1 = new Pato();
            var pato2 = new Pato();
            var pato3 = new Pato();
            var gallina1 = new Gallina();

            List<ICaminador> avesCaminadoras = new List<ICaminador>();  
            var avestruz1 = new Avestruz();

            aves.Add(pato1);
            aves.Add(pato2);
            aves.Add(pato3);
            aves.Add(gallina1);

            avesCaminadoras.Add(avestruz1);

            AVolar(aves);
            ACaminar(avesCaminadoras);
            Console.Read();
        }

        static void AVolar(List<IVolador> aves)
        {
            foreach(var ave in aves)
            {
                ave.Vuela();
            }
        }

        static void ACaminar(List<ICaminador> avesCaminadoras)
        {
            foreach(var ave in avesCaminadoras)
            {
                ave.Camina();
            }
        }

        interface IVolador
        {
            void Vuela();
        }

        interface ICaminador
        {
            void Camina();
        }

        public class Pato : IVolador, ICaminador
        {
            public void Vuela()
            {
                Console.WriteLine("Pato Vuela");
            }

            public void Camina()
            {
                Console.WriteLine("Pato Camina");
            }
        }

        public class Gallina : IVolador
        { 
            public void Vuela() 
            {

                Console.WriteLine("Gallina Vuela");
            }
        }

        public class Avestruz : ICaminador
        {
            public void Camina()
            {
                Console.WriteLine("Avestruz Camina");
            }
        }
    }
}
