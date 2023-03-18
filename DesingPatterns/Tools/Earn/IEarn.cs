using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    //En esta carpeta va toda la logistica de las fabricas
    //Interfaz para categorizar los productos creados por la fabrica
    public interface IEarn
    {
        //Metodo para el calculo de la ganancia,
        //cada clase(Productos) que implemente esta interfaz debe tener este metodo  
        public decimal Earn(decimal amount);
    }
}
