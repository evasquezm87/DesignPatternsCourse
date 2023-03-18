using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    /*Clase Fabrica
     *Es la clase encargada de crear los productos
     *En algunos casos se puede utilizar una interfaz, la diferencia es que la clase se utilizaria cuando
     *se requiera tener propiedades, para que se hereden al producto, en caso de que sean solo metodos se puede usar una interfaz
     */
    //La Fabrica tiene que ser una clase abstraca ¿Para que no se pueda usar el new = ?
    public abstract class EarnFactory
    {
        /*Este tipo de clases fabricas Tienen una regla:
         Tiene que tener un metodo que cree un objeto del tipo que tiene implementado en la interfaz*/
        public abstract IEarn GetEarn();
    }
}
