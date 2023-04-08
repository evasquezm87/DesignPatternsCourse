using DesignPatterns_Net50.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Net50.RepositoryPattern
{
	public interface IBeerRepository
	{
		//Metodos con los que tienen que cumplir para llamar a esta interface
		//Serian los metodos para trabajar con la data, obtener, insertar, eliminar, guardar.
		IEnumerable<Beer> Get();//Metodo Get para todo el listado(Colección)
		Beer Get(int id);//Metodo Get Sobrecargado, filtrado por el id enviado
		void Add(Beer data);
		void Delete(int id);
		void Update(Beer data);

		void Save();

	}
}
