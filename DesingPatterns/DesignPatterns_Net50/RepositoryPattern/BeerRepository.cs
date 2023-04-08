using DesignPatterns_Net50.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Net50.RepositoryPattern
{
	//Clase que implementa la interfaz
	class BeerRepository : IBeerRepository
	{
		//Crear el contexto para trabajar en este caso con la BD
		//
		private velam987Context _context;//Contexto de la BD

		//Constructor que recibe el contexto
		public BeerRepository(velam987Context context)
		{
			_context = context;
		}
		public void Add(Beer data)
		{
			//Para agregar un elemento se manda llamar el Metodo Add del contexto y 
			//se le pasa como parametro el data recibido
			_context.Add(data);

			//Forma simplificada usando expresiones lambda
			//public void Add(Beer data) => _context.Add(data);
		}

		public void Delete(int id)
		{
			var beer = _context.Beers.Find(id);	//Se devuelve un objeto filtrado por el id enviado
			_context.Beers.Remove(beer); //Del objeto recibido se elimina
		}

		public IEnumerable<Beer> Get()
		{
			return _context.Beers.ToList();
		}

		public Beer Get(int id)
		{
			return _context.Beers.Find(id);
		}
				
		public void Update(Beer data)
		{
			_context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		}

		//Primero se hace el cambio en memorio, update, add o delete, pero en la BD
		//se refleja hasta que se mande llamar el evento Save
		public void Save()
		{
			_context.SaveChanges();
		}

	}
}
