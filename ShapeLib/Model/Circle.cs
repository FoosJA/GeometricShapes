using ShapeLib.Foundation;

namespace ShapeLib.Model
{
	/// <summary>
	/// Круг
	/// </summary>
	public sealed class Circle : Shape
	{
		/// <summary>
		/// Сегменты круга
		/// </summary>
		public override double[] Segments { get; } = new double[(int)ShapeType.Circle];

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
		public override double Area() => Math.PI * Segments[0] * Segments[0];

		/// <summary>
		/// Периметр круга или длина окружности
		/// </summary>
		/// <returns></returns>
		public override double Perimeter() => 2 * Math.PI * Segments[0];
	}
}
