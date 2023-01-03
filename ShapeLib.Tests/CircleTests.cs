using ShapeLib.Foundation;
using ShapeLib.Model;
using Xunit;

namespace ShapeLib.Tests
{
	public class CircleTests
	{
		[Fact]
		public void Can_Create()
		{
			double inputData = 2;
			Circle circle = new Circle(inputData);

			var expectedSegmentsLength = (int)ShapeType.Circle;
			var expectedRadius = inputData;
			var expectedDiameter = inputData * 2;

			Assert.NotNull(circle.Segments);
			Assert.Equal(circle.Segments.Length, expectedSegmentsLength);
			Assert.Equal(circle.Radius, expectedRadius);
			Assert.Equal(circle.Diameter, expectedDiameter);
		}

		[Fact]
		public void Can_ThrowsException()
		{
			double inputData = double.NaN;
			var expectedMessage = "Радиус не может быть равен не число";

			var ex = Assert.Throws<ShapeException>(() => new Circle(inputData));
			Assert.Equal(ex.Message, expectedMessage);
		}

		[Fact]
		public void Can_GetArea()
		{
			double inputData = 2;
			Circle circle = new Circle(inputData);

			var expectedArea = Math.PI * inputData * inputData;
			var area = circle.Area();

			Assert.Equal(expectedArea, area);
		}

		[Fact]
		public void Can_GetPerimeter()
		{
			double inputData = 2;
			Circle circle = new Circle(inputData);

			var expectedPerimeter = 2 * Math.PI * inputData;
			var perimeter = circle.Perimeter();

			Assert.Equal(expectedPerimeter, perimeter);
		}
	}
}
