using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;
using Tools.Earn;

namespace DesignPatternsASP.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //Crear la fabrica para crear el producto
            //Fabrica
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.2m);
            //Crear los productos creados por la fabrica
            //Se crea un objeto del tipo localEarnFactory, el cual ya ejecuta los metodos que tiene           
            var localEarn = localEarnFactory.GetEarn();

			//Producto 2
			ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.3m,10);
			var foreignEarn = foreignEarnFactory.GetEarn();

			//Metodo para calcular las ganancias, el cual esta en el producto
			ViewBag.totalLocal = total + localEarn.Earn(total);
			ViewBag.totalForeign = total + foreignEarn.Earn(total);

			return View();
        }
    }
}
