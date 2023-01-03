using System.ComponentModel;

namespace ShapeLib.Foundation
{
    public enum ShapeType
    {
        [Description("Круг")] Circle = 1,
        [Description("Треугольник")] Triangle = 3,
        [Description("Четырехугольник")] Rectangle = 4
    }
}
