using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern
{
    //Creator, es la clase abstracta de la que heredaran, 
    public abstract class SaleFactory
    {
        public abstract ISale GetSale();
    }

    //Concrete Creator
    //Fabrica que crea el objeto, es quien tiene la respobilidad de la creación, 
    //es la unica que se utilizara en el programa al llamarla
    //Hereda a la clase abstracta
    public class StoreSaleFactory : SaleFactory
    {
        private decimal _extra;
        public StoreSaleFactory(decimal extra)
        {
            _extra= extra;
        }
        //Es la que se llama en el programa para la creacion del objeto
        //cuando se ocupe modificar algo solo seria en esta parte
        //al no tener parametros no hay que cambiar nada en las partes donde se utiliza
        public override ISale GetSale()
        {
            //Implementar la creacion del objeto
            return new StoreSale(_extra);
        }
    }
    //Fabrica de ventas por internet
    public class InternetSaleFactory : SaleFactory
    {
        private decimal _discount;
        public InternetSaleFactory(decimal extra)
        {
            _discount = extra;
        }
        public override ISale GetSale()
        {
            //Implementar la creacion del objeto
            return new StoreSale(_discount);
        }
    }


    //Concrete Product, Clase que implementa la interfaz
    public class StoreSale : ISale
    {
        private decimal _extra;

        public StoreSale(decimal extra) {
            _extra = extra;
        }


        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en tienda tiene total de  { total + _extra} bruto {total}");
        }
    }

   
    //Product, Interfaz, sirve para categorizar la fabrica
    public interface ISale 
    {
        void Sell(decimal total);
    }

 
}
