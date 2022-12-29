// See https://aka.ms/new-console-template for more information

using ShapeLib;
using System.ComponentModel.DataAnnotations;

try
{
	var t = new Triangle(4, 6, 7);
	Console.WriteLine(t.Area());
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}



Console.ReadLine();
