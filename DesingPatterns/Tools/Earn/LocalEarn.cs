using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    //Clase de tipo producto, es el resultado de la creación de la fabrica
    //Implementa a la interfaz que categoriza los productos
    public class LocalEarn : IEarn
    {
        //propiedad de la clase, en este caso el porcentaje que se le agregara al monto
        private decimal _percentage;
        //Constructor, es lo primero que se realizara cuando se llame a esta clase
        public LocalEarn(decimal percentage)
        {
            _percentage = percentage; //Se le asigna a la propiedad de la clase el valor enviado desde donde es llamado
        }

        //Metodo implementado de la interfaz, que tiene que ser llamado a fuerza cuando se implementa una interfaz
        //La interfaz al llamarlo no le importa que haga el metodo, solo lo va a ejecutar
        //
        public decimal Earn(decimal amount)
        {
            //Logica que dependiendo del porcentaje se le agrega al monto
            /*Por cuestiones de enseñanza la logica es muy sencilla, pero aqui iria toda la logica requerida
             En caso de que este metodo requiera añadir funcionalidad aqui se agregaria, pero los otros productos que surgieron de la misma
            fabrica que este producto no se alteran, ni tampoco la parte donde se llama este metodo*/
            var result = amount * _percentage;
            return result; //
            
        }
    }
}
