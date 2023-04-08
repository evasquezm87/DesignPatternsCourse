using DesignPatterns_Net50.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;

namespace DesignPatterns_Net50
{
	internal class Program
	{
		static void Main(string[] args)
		{
			efRepository();
			Console.ReadLine();
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
