using ShapeLib.Foundation;

namespace ShapeLib.Model
{
	public abstract class Shape
	{
		/// <summary>
		/// Составляющие фигуры
		/// </summary>
		public abstract double[] Segments { get; }

		/// <summary>
		/// Вычислить площадь
		/// </summary>
		/// <returns></returns>
		public abstract double Area();

		/// <summary>
		/// Вычислить периметр
		/// </summary>
		/// <returns></returns>
		public virtual double Perimeter() => Segments.Sum();
	}
}
