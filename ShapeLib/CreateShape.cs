using ShapeLib.Foundation;
using ShapeLib.Model;

namespace ShapeLib
{
    public static class CreateShape
    {
        public static double GetAreaShape(int typeShape, params double[] inputData)
        {
            var type = (ShapeType)typeShape;
            if (type == ShapeType.Circle)
            {
                if (inputData.Length != typeShape)
                    throw new ShapeException($"Количество входных параметров для {type.ToDescriptionString()} не корректно");

                var circle = new Circle(inputData[0]);
                return circle.Area();
            }
            else if (type == ShapeType.Triangle)
            {
                if (inputData.Length != typeShape)
                    throw new ShapeException($"Количество входных параметров для {type.ToDescriptionString()} не корректно");

                var triangle = new Triangle(inputData[0], inputData[1], inputData[2]);
                return triangle.Area();
            }

            throw new ShapeException("Неизвестный тип фигуры");
        }
    }
}
