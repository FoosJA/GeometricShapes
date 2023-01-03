using ShapeLib;
using ShapeLib.Model;

try
{
	var c = new Circle(double.NaN);
	var t = new Triangle(4, 6, 7);
	Console.WriteLine(CreateShape.GetAreaShape(1, 4, 6, 7));
	Console.WriteLine(t.Area());
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}



Console.ReadLine();
