using DesignPatterns_Net50.Models;
using DesignPatterns_Net50.RepositoryPattern;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;

namespace DesignPatterns_Net50
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//efRepository();
			efRepositoryContext();
			
			Console.ReadLine();
		}

		private static void efRepositoryContext()
		{
			//SE crea el contexto
			using (var context = new velam987Context())
			{
				var beerRepository = new BeerRepository(context);

				var beer = new Beer();

				beer.Name = "Negra Modelo";
				beer.Style = "Oscura";

				beerRepository.Add(beer);
				beerRepository.Save();
				efRepositoryGet(beerRepository);
			}

			
		}

		private static void efRepositoryGet(BeerRepository beerRepository){
		
			foreach(var beer in beerRepository.Get())
			{

				Console.WriteLine(beer.Name);	
			}
		}

		private static void efRepository()
		{
			using (var context = new velam987Context())
			{
				var lst = context.Beers.ToList();

				foreach (var beer in lst)
				{
					Console.WriteLine(beer.Name);
				}
			}
		}
	}
}
