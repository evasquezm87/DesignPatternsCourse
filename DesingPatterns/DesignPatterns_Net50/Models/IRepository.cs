using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Net50.Models
{
	//Para trabajar con Generics
	//Es igual a la otra clase, pero aqui es mas potente ya que permite enviarle por parametro un tipo TEntity
	//No sabe ni importa cual es el tipo solo se pasa la clase,
	//No se requiere hacer una interfaz por cada tabla, con una sola interfaz
	public interface IRepository<TEntity>
	{

		IEnumerable<TEntity> Get();//Metodo Get para todo el listado(Colección)
		TEntity Get(int id);//Metodo Get Sobrecargado, filtrado por el id enviado
		void Add(TEntity data);
		void Delete(int id);
		void Update(TEntity data);

		void Save();
	}
}
