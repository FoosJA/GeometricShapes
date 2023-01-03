using ShapeLib.Foundation;
using ShapeLib.Model;
using Xunit;

namespace ShapeLib.Tests
{
	public class TriangleTests
	{
		[Fact]
		public void Can_Create()
		{
			var inputData = new double[3] { 1, 2, 3 };
			Triangle triangle = new Triangle(inputData[0], inputData[1], inputData[2]);

			var expectedSegments = inputData;
			var expectedType = TriangleType.ScaleneTriangle;

			Assert.NotNull(triangle.Segments);
			Assert.Equal(triangle.Segments, expectedSegments);
			Assert.Equal(triangle.TriangleType, expectedType);
		}

		[Fact]
		public void Can_ThrowsException()
		{
			var inputData = new double[3] { 1, 1, 3 };

			var expectedMessage = "Сторона треугольника 3 больше суммы двух других сторон";

			var ex = Assert.Throws<ShapeException>(() => new Triangle(inputData[0], inputData[1], inputData[2]));
			Assert.Equal(ex.Message, expectedMessage);
		}

		[Fact]
		public void Can_GetTriangleType()
		{
			var equilateralTriangle = new Triangle(3, 3, 3);
			var isoscelesTriangle = new Triangle(2, 2, 3);
			var rightTriangle = new Triangle(3, 4, 5);

			Assert.Equal(equilateralTriangle?.TriangleType, TriangleType.EquilateralTriangle);

			Assert.Equal(isoscelesTriangle?.TriangleType, TriangleType.IsoscelesTriangle);

			Assert.Equal(rightTriangle?.TriangleType, TriangleType.RightTriangle);
		}

		[Fact]
		public void Can_GetArea()
		{
			var inputData = new double[3] { 1, 2, 3 };
			Triangle triangle = new Triangle(inputData[0], inputData[1], inputData[2]);

			var p = inputData.Sum() * 0.5;
			var expectedArea = Math.Sqrt(p * (p - inputData[0]) * (p - inputData[1]) * (p - inputData[2]));

			Assert.Equal(expectedArea, triangle.Area());
		}

		[Fact]
		public void Can_GetPerimeter()
		{
			var inputData = new double[3] { 1, 2, 3 };
			Triangle triangle = new Triangle(inputData[0], inputData[1], inputData[2]);

			var expectedPerimeter = inputData.Sum();

			Assert.Equal(expectedPerimeter, triangle.Perimeter());
		}
	}
}
