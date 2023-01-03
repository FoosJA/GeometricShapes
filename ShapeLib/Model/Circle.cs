using ShapeLib.Foundation;

namespace ShapeLib.Model
{
	public class Circle : IShape
	{
		private const ShapeType _type = ShapeType.Circle;

		/// <summary>
		/// Сегменты круга
		/// </summary>
		public double[] Segments { get; } = new double[(int)_type];

		/// <summary>
		/// Радиус
		/// </summary>
		public double Radius => Segments[0];

		/// <summary>
		/// Диаметр
		/// </summary>
		public double Diameter => 2 * Segments[0];

		public Circle(double radius)
		{
			if (double.IsNaN(radius) || double.IsInfinity(radius) || radius <= 0)
				throw new ShapeException($"Радиус не может быть равен {radius}");

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
