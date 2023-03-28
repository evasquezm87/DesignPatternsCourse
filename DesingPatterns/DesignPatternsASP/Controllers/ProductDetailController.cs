using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Schema;
using Tools.Earn;

namespace DesignPatternsASP.Controllers
{
    public class ProductDetailController : Controller
    {
        //Para mandar el objeto que se creara desde la inyeccion de dependencias en Start.cs
        private EarnFactory _localEarnFactory;
        private ForeignEarnFactory _foreignEarnFactory;

		//Se crea el constructor para que devuelva el objeto creado
		public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignEarnFactory) { 
            _localEarnFactory= localEarnFactory;
			_foreignEarnFactory = foreignEarnFactory; ;
		}

		public IActionResult Index(decimal total)
        {
            //Crear la fabrica para crear el producto
            //Fabrica
            //Para el patro inyeccion de dependeicias se quita la responsabilidad a esta clase de crear el objeto, 
            //Se manda llamar en Start.cs, donde se creara el objeto
            //LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.2m);
            
            //Crear los productos creados por la fabrica
            //Se crea un objeto del tipo localEarnFactory, el cual ya ejecuta los metodos que tiene           
            var localEarn = _localEarnFactory.GetEarn();

			//Producto 2
			//Se manda llamar en Start.cs, donde se creara el objeto
			//ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.3m,10);
			var foreignEarn = _foreignEarnFactory.GetEarn();

			//Metodo para calcular las ganancias, el cual esta en el producto
			ViewBag.totalLocal = total + localEarn.Earn(total);
			ViewBag.totalForeign = total + foreignEarn.Earn(total);

			return View();
        }
    }
}
