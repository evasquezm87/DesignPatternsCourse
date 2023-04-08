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
			//efRepositoryContext();
			//efRepositoryGenerics();
			//efRepositoryGenericsTableBrand();
			efRepositoryGenericsDelete();
			Console.ReadLine();
		}

		private static void efRepositoryGenerics()
		{
			using (var context = new velam987Context())
			{
				//Insertar a tabla Beer
				var beerRepository = new Repository<Beer>(context);
				var beer = new Beer() { Name = "Fuller", Style = "Stringe Ale" };
				beerRepository.Add(beer); 
				beerRepository.Save();

				foreach(var b in beerRepository.Get())
				{
					Console.WriteLine(b.BeerId + " - " + b.Name);
				}
			}
		}
		private static void efRepositoryGenericsDelete()
		{
			using (var context = new velam987Context())
			{
				//Insertar a tabla Beer
				var beerRepository = new Repository<Beer>(context);
				beerRepository.Delete(4);
				beerRepository.Save();

				foreach (var b in beerRepository.Get())
				{
					Console.WriteLine(b.BeerId + " - " + b.Name);
				}
			}
		}
		private static void efRepositoryGenericsTableBrand()
		{
			using (var context = new velam987Context())
			{
				//Insertar a tabla Beer
				var beerRepository = new Repository<Brand>(context);
				var beer = new Brand() { Name = "Fuller"};
				beerRepository.Add(beer);
				beerRepository.Save();

				foreach (var b in beerRepository.Get())
				{
					Console.WriteLine(b.BrandId + " - " + b.Name);
				}
			}
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
