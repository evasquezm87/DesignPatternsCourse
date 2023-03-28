using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.DependencyInjection
{
	public class DrinkWithBeer
	{		
		/*Funciona pero no esta correcto, se puede mejorar
		 * El problema es cuando se agregue un nuevo atributo hay que modificar todas las referencias, 
		con la inyeccion de dependencias solo se cambia en una parte, ya que por parametro se pasa el objeto inyectado*/
		//private Beer _beer = new Beer("Negra Modelo", "Modelo");
		private Beer _beer;
		private decimal _water;
		private decimal _sugar;

		/*Se agrega en el ultimo parametro el objeto*/
		public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
		{
			_water = water;
			_sugar = sugar;
			_beer = beer;
		}	

		public void Build()
		{
			Console.WriteLine($"Preparamos bebida que tiene agua {_water} " +
				$"azucar {_sugar} y cerverza {_beer.Name} ");
		}
	}
}
