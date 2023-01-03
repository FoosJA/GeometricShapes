#Задание
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
Дополнительно к работоспособности оценим:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным

# GeometricShapes

*ShapeLib.csproj* - библиотека работы с фигурами. В папке Model хранится абстрактный класс Shape.cs и его наследники Circle.cs и Triangle.cs. Наследование от Shape.cs
упращает добавление новых фигур. Triangle.cs содержит свойство TriangleType, которое предоставляет пользователю информацию о типе треугольника (прямоугольный, равнобедренный и т.д.)

*ShapeLib.Tests.csproj* - проект с юнит-тестами.

*GeometricShapes.csproj* - в классе Program.cs демонстрируется возможность вычисления площади фигуры без знания типа фигуры в compile-time.