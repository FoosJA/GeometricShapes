using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
	/// <summary>
	/// Треугольник
	/// </summary>
	public class Triangle : IShape
	{
		/// <summary>
		/// Тип треугольника
		/// </summary>
		public TriangleTypes TriangleType { get; }

		private double[] _sides = new double[3];

		/// <summary>
		/// Стороны треугольника
		/// </summary>
		public double[] Sides => _sides;

		public Triangle(double a, double b, double c)
		{
			var massive = new[] { a, b, c };
			foreach (var item in massive)
			{
				if (double.IsNaN(item) || double.IsInfinity(item) || item <= 0)
					throw new ShapeException($"Некорректное значение {item}");
				if ((massive.Sum() - item) < 0)
					throw new ShapeException($"Сторона треугольника {item} больше суммы других сторон");
			}

			Sides[0] = a;
			Sides[1] = b;
			Sides[2] = c;
			TriangleType = GetTriangleType();
		}

		public double Area()
		{
			var p = (Sides.Sum()) * 0.5;
			return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
		}

		public double Perimeter()
		{
			return Sides.Sum();
		}

		private TriangleTypes GetTriangleType()
		{
			var equalsSide = Sides.Distinct().Count();
			switch (equalsSide)
			{
				case 1:
					return TriangleTypes.EquilateralTriangle;
				case 2:
					return TriangleTypes.IsoscelesTriangle;
				default:
					{
						var hypotenuse = Sides.Max();
						var squareHypotenuse = hypotenuse * hypotenuse;
						var sumSquaresCathet = Sides.Where(s => !s.Equals(hypotenuse)).Sum(c => c * c);

						return squareHypotenuse.Equals(sumSquaresCathet) ? TriangleTypes.RightTriangle : TriangleTypes.ScaleneTriangle;
					}
			}
		}
	}

	public enum TriangleTypes
	{
		[Description("Разносторонний треугольник")] ScaleneTriangle,
		[Description("Равнобедренный треугольник")] IsoscelesTriangle,
		[Description("Равноcторонний треугольник")] EquilateralTriangle,
		[Description("Прямоугольный треугольник")] RightTriangle
	}

}
