using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    //Clase fabrica, que creara el producto LocalEarn, implementa a la clase padre abstracta EarnFactory, por lo 
    //que se tiene que implementar el metodo
    public class LocalEarnFactory : EarnFactory
    {
        //EL objeto que se va a crear con esta fabrica tiene un atributo, por lo que se va a crear aqui el atributo

        private decimal _percentage;
        public LocalEarnFactory(decimal percentage)
        {
            _percentage = percentage;
        }

        //Cada vez que se llame a esta clase va a sobreescribir el metodo de la clase abstracta, 
        //Va a crear y devolver un producto ya con el porcentaje
        public override IEarn GetEarn()
        {
            return new LocalEarn(_percentage);
        }
    }
}
