using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
	public class Circle : IShape
	{
		private double[] _segment = new double[(int)ShapeType.Circle];

		/// <summary>
		/// Сегменты круга
		/// </summary>
		public double[] Segments => _segment;

		/// <summary>
		/// Радиус
		/// </summary>
		private double Radius => Segments[0];

		/// <summary>
		/// Диаметр
		/// </summary>
		private double Diameter => 2 * Radius;

		public Circle(double radius)
		{
			if (double.IsNaN(radius) || double.IsInfinity(radius) || radius <= 0)
				throw new ShapeException($"Некорректное значение {radius}");

			Segments[0] = radius;
		}

		/// <summary>
		/// Площадь круга
		/// </summary>
		/// <returns></returns>
		public double Area() => Math.PI * Segments[0] * Segments[0];

		/// <summary>
		/// Периметр треугольника
		/// </summary>
		/// <returns></returns>
		public double Perimeter() => 2 * Math.PI * Segments[0];
	}
}
