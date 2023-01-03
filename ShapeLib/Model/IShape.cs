namespace ShapeLib.Model
{
	public interface IShape
	{
		/// <summary>
		/// Составляющие фигуры
		/// </summary>
		public double[] Segments { get; }

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
