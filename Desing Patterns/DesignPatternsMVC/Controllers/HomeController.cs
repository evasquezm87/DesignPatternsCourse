using DesignPatternsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            //Que se cree el log cuando se entra a la vista y se guarde el log
            Log.GetInstance("logasp.txt").Save("Entro a Index");//Se accede al metodo sigleton para que cree la instancia y guarde
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance("logasp.txt").Save("Entro a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
