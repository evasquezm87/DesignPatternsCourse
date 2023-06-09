﻿using DesignPatterns.FactoryPattern;
using DesignPatterns.Singleton;
using DesignPatterns.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //singleton();
            //Fabric();
            //FabricBancos();
            DependencyBeer();
            Console.ReadLine();


          
        }

        static void DependencyBeer()
        {
            //Se le quita la responsabilidad de crear el objeto
            //La clase beer es la resonable de crearla no la clase Drink
            //DrinkWithBeer bebida = new DrinkWithBeer(14, 10);
			Beer beer = new Beer("Negra modelo", "Modelo");
            DrinkWithBeer bebida = new DrinkWithBeer(14, 10, beer);


			bebida.Build(); 

        }

        static void FabricBancos()
        {
            ContenidoDetalleFactory santander = new SantanderDetalle("014");
            ContenidoDetalleFactory bbva = new BBVADetalle("012");
            ContenidoDetalleFactory banorte = new BanorteDetalle("072");

            IDetalle santander1 = santander.GetDetail();
            santander1.FillDetail("header1", "Detalle Santander", "Summary 1");

            IDetalle bbva1 = bbva.GetDetail();
            for(int i = 0; i < 10; i++)
            {
                bbva1.FillDetail("header1", "Detalle BBVA linea " + i, "Summary 1");
            }

            IDetalle banorte1 = banorte.GetDetail();
            for (int i = 0; i < 5; i++)
            {
                banorte1.FillDetail("header1", "Detalle Banorte linea " + i, "Summary 1");
            }

        }
        static void Fabric()
        {
            //Fabric
            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(2);
            //Se crean objetos, pero no se usan las clases de la fabrica
            //se usa el objeto fabrica
            ISale sale1 = storeSaleFactory.GetSale();
            sale1.Sell(15);
            ISale sale2 = internetSaleFactory.GetSale();
            sale2.Sell(2);
        }
        static void singleton()
        {
            //var singleton = new Singleton(); Error ya que la clase es estatica no se puede crear con la palabra "new" y el constructor es privado
            //var singleton = new Singleton.Singleton; Error ya que la clase es estatica no se puede crear con la palabra "new" ni usar sus propieades
            var singleton = Singleton.Singleton.Instance; //Correcto permite acceder a la propiedad porque pertence a la clase no al objeto

            var log = Singleton.Log.Instance;//Acceder al objeto singleton, el unico objeto de todo el sistema

            for (var i = 0; i < 10; i++)
            {
                log.Save("Linea numero: " + i);//Se utilza el metodo de la clase singleton que hace la funcionalidad
            }

            var log1 = Singleton.Log.Instance;//Validar que si se llama al objeto nuevamente en otra variable es el mismo objeto

            var log2 = Singleton.Log.Instance;//Validar que si se llama al objeto nuevamente en otra variable es el mismo objeto

            Console.WriteLine(log1.Path);
            Console.WriteLine(log2.Path);

            Console.WriteLine("Leer configuracion");
            var config = Singleton.Config.Instance;
            Console.WriteLine("Config: " + config.path + ";" + config.url + ";" + config.user + ";" + config.password);

            Console.WriteLine("Leer configuracion en una variable nueva 3");
            var config2 = Singleton.Config.Instance;
            Console.WriteLine("Config 2: " + config2.path + ";" + config2.url + ";" + config2.user + ";" + config2.password);

            Console.WriteLine("Leer configuracion en una variable nueva 3");
            var config3 = Singleton.Config.Instance;
            Console.WriteLine("Config 3: " + config3.path + ";" + config3.url + ";" + config3.user + ";" + config3.password);

        }
    }
}
