using System.ComponentModel;

namespace ShapeLib.Foundation
{
	public enum TriangleType
	{
		[Description("Разносторонний треугольник")] ScaleneTriangle,
		[Description("Равнобедренный треугольник")] IsoscelesTriangle,
		[Description("Равноcторонний треугольник")] EquilateralTriangle,
		[Description("Прямоугольный треугольник")] RightTriangle
	}
}
