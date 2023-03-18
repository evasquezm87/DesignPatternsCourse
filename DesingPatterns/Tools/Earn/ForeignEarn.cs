using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
	//Producto 2, cuando se requiere añadir funcionalidad
	//En este caso para ventas a extranjero con una comision adicional
	//no se toca el codigo que ya esta funcional, se extiene mediante este patron
	public class ForeignEarn : IEarn
	{
		private decimal _percentaje;
		private decimal _extra;

		//Se crea el constructor para enviarle las propiedades necesarias
		public ForeignEarn(decimal percentaje, decimal extra) 
		{
			_percentaje = percentaje;
			_extra = extra;	
		}
		//se crea el producto con le metodo
		//es el mismo metodo que los otros productos pero con funcionalidad diferente
		public decimal Earn(decimal amount)
		{
			return (amount * _percentaje) + _extra;
		}

		

	}
}
