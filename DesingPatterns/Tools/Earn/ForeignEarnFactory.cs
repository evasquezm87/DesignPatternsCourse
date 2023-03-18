using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
	//Clase fabrica que crea los productos de Earn Extranjero
	//Hereda de la clase abstracta EarnFactory
	public class ForeignEarnFactory : EarnFactory
	{
		//Depende de los factores del producto
		private decimal _percentaje;
		private decimal _extra;
		//Se crea constructor que recibe los 2 parametros
		public ForeignEarnFactory(decimal percentaje, decimal extra)
		{
			_percentaje = percentaje;
			_extra = extra;	
		}
		//regresa un objeto del tipo ForeignEarn
		public override IEarn GetEarn()
		{
			return new ForeignEarn(_percentaje, _extra);
		}
	}
}
