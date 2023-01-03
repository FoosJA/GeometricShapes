using ShapeLib.Model;

while (true)
{
	try
	{
		Shape shape;
		int type;
		while (true)
		{
			Console.WriteLine("Введите тип требуемой фигуры: 1 - круг, 2 - треугольник");
			if (!int.TryParse(Console.ReadLine(), out type))
			{
				Console.WriteLine("Некорректное значение");
				continue;
			}
			if (type is 1 or 2) break;
		}

		while (true)
		{
			Console.WriteLine("Введите параметры фигуры через пробел");
			var str = Console.ReadLine();
			if (str == null) continue;

			var parameters = str.Split(' ');
			if (type is 1 && parameters.Length == 1)
			{
				if (!double.TryParse(parameters[0], out var result))
				{
					Console.WriteLine($"Некорректное значение {parameters[0]}");
					continue;
				}
				shape = new Circle(result);
				break;
			}
			else if (type is 2 && parameters.Length == 3)
			{
				var massive = new double[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					if (!double.TryParse(parameters[i], out massive[i]))
					{
						Console.WriteLine($"Некорректное значение {parameters[i]}");
					}
				}
				if (massive.Any(x => x == 0))
					continue;
				shape = new Triangle(massive[0], massive[1], massive[2]);
				break;
			}
			else
			{
				Console.WriteLine("Некорректное количество входных данных для фигуры");
			}
		}
		Console.WriteLine($"Площадь фигуры: {shape.Area()}");
		Console.WriteLine();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}