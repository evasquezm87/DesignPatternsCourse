using DesignPatternsMVC.Configuration;
using DesignPatternsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tools;

namespace DesignPatternsMVC.Controllers
{
    public class HomeController : Controller
    {
        //Crear atributo privado para obtener la inyección del objeto que lee de config
        private readonly IOptions<MyConfig> _config;
        //Obtener el objeto inyectado en elparametro del constructor
        public HomeController(IOptions<MyConfig> config)
        {
            _config = config; //Se lee el objeto inyectado y se asigna en una propiedad
        }

        public IActionResult Index()
        {
            //Que se cree el log cuando se entra a la vista y se guarde el log
            //Obtiene la ruta donde se creara el archivo leido desde la configuración pór medio de inyección de dependencias
            Log.GetInstance(_config.Value.PathLog).Save("Entro a Index");//Se accede al metodo sigleton para que cree la instancia y guarde
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
