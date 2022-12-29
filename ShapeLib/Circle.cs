using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
	public class Circle : IShape
	{
		public double Radius { get; }
		public double Diametr => 2 * Radius;

		public Circle(double radius)
		{
			if (double.IsNaN(radius) || double.IsInfinity(radius) || radius <= 0)
				throw new ShapeException($"Некорректное значение {radius}");
			Radius = radius;
		}

		public double Area() => Math.PI * Radius * Radius;


		public double Perimeter() => 2 * Math.PI * Radius;
	}
}
