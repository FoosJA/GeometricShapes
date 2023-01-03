using ShapeLib.Foundation;

namespace ShapeLib.Model
{
	/// <summary>
	/// Треугольник
	/// </summary>
	public sealed class Triangle : Shape
	{
		/// <summary>
		/// Стороны треугольника
		/// </summary>
		public override double[] Segments { get; } = new double[(int)ShapeType.Triangle];

		/// <summary>
		/// Тип треугольника
		/// </summary>
		public TriangleType TriangleType { get; }

		public Triangle(double a, double b, double c)
		{
			var massive = new[] { a, b, c };
			foreach (var item in massive)
			{
				if (double.IsNaN(item) || double.IsInfinity(item) || item <= 0)
					throw new ShapeException($"Некорректное значение {item}");
				if (massive.Sum() - item < item)
					throw new ShapeException($"Сторона треугольника {item} больше суммы двух других сторон");
			}

			Segments[0] = a;
			Segments[1] = b;
			Segments[2] = c;
			TriangleType = _setTriangleType();
		}

		/// <summary>
		/// Получить тип треугольника
		/// </summary>
		/// <returns></returns>
		public string GetTriangleType() => TriangleType.ToDescriptionString();


		/// <summary>
		/// Площадь треугольника
		/// </summary>
		/// <returns></returns>
		public override double Area()
		{
			var p = Segments.Sum() * 0.5;
			return Math.Sqrt(p * (p - Segments[0]) * (p - Segments[1]) * (p - Segments[2]));
		}

		private TriangleType _setTriangleType()
		{
			var equalsSide = Segments.Distinct().Count();
			switch (equalsSide)
			{
				case 1:
					return TriangleType.EquilateralTriangle;
				case 2:
					return TriangleType.IsoscelesTriangle;
				default:
					{
						var hypotenuse = Segments.Max();
						var squareHypotenuse = hypotenuse * hypotenuse;
						var sumSquaresCathet = Segments.Where(s => !s.Equals(hypotenuse)).Sum(c => c * c);

						return squareHypotenuse.Equals(sumSquaresCathet) ? TriangleType.RightTriangle : TriangleType.ScaleneTriangle;
					}
			}
		}
	}
}
