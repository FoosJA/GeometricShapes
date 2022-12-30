﻿using System;
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
		private double[] _segment = new double[(int)ShapeType.Triangle];

		/// <summary>
		/// Стороны треугольника
		/// </summary>
		public double[] Segments => _segment;

		/// <summary>
		/// Тип треугольника
		/// </summary>
		public TriangleTypes TriangleType { get; }

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

			Segments[0] = a;
			Segments[1] = b;
			Segments[2] = c;
			TriangleType = _getTriangleType();
		}

		/// <summary>
		/// Площадь треугольника
		/// </summary>
		/// <returns></returns>
		public double Area()
		{
			var p = (Segments.Sum()) * 0.5;
			return Math.Sqrt(p * (p - Segments[0]) * (p - Segments[1]) * (p - Segments[2]));
		}

		/// <summary>
		/// Периметр треугольника
		/// </summary>
		/// <returns></returns>
		public double Perimeter()
		{
			return Segments.Sum();
		}

		private TriangleTypes _getTriangleType()
		{
			var equalsSide = Segments.Distinct().Count();
			switch (equalsSide)
			{
				case 1:
					return TriangleTypes.EquilateralTriangle;
				case 2:
					return TriangleTypes.IsoscelesTriangle;
				default:
					{
						var hypotenuse = Segments.Max();
						var squareHypotenuse = hypotenuse * hypotenuse;
						var sumSquaresCathet = Segments.Where(s => !s.Equals(hypotenuse)).Sum(c => c * c);

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
