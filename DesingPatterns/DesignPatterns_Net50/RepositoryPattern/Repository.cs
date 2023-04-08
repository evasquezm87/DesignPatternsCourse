using DesignPatterns_Net50.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Net50.RepositoryPattern
{
	//Cuando se crea un ob jeto esta clase se va a especificar de que tipo es y se va a crear
	//SE emula lo que hace DbSet!!!
	//Se le indica que se especifica que el generics que se envia sea una clase
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private velam987Context _context;
		private DbSet<TEntity> _dbSet;

		public Repository(velam987Context context)
		{
			_context = context;	
			_dbSet= context.Set<TEntity>();	

		}


		public void Add(TEntity data)
		{
			_dbSet.Add(data);	
		}

		public void Delete(int id)
		{
			var dataToDelete = _dbSet.Find(id);
			_dbSet.Remove(dataToDelete);
		}

		public IEnumerable<TEntity> Get()
		{
			return _dbSet.ToList();
		}

		public TEntity Get(int id)
		{
			return _dbSet.Find(id);
		}

		
		public void Update(TEntity data)
		{
			_dbSet.Attach(data);
			_context.Entry(data).State= EntityState.Modified;		

		}

		public void Save()
		{
			_context.SaveChanges();
		}

	}
}
