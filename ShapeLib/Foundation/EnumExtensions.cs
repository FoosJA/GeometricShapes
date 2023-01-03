using System.ComponentModel;

namespace ShapeLib.Foundation
{
	/// <summary>
	/// Метод для получения строкового представления перечислений
	/// </summary>
    internal static class EnumExtensions
	{
		internal static string ToDescriptionString(this ShapeType val)
		{
			DescriptionAttribute[] attributes = (DescriptionAttribute[])val
				.GetType()
				.GetField(val.ToString())
				.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : string.Empty;
		}

		internal static string ToDescriptionString(this TriangleType val)
		{
			DescriptionAttribute[] attributes = (DescriptionAttribute[])val
				.GetType()
				.GetField(val.ToString())
				.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : string.Empty;
		}
	}
}
