using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
	internal interface IShape
	{
		/// <summary>
		/// Вычислить площадь
		/// </summary>
		/// <returns></returns>
		public double Area();

		/// <summary>
		/// Вычислить периметр
		/// </summary>
		/// <returns></returns>
		public double Perimeter();
	}
}
