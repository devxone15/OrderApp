using System;
using System.ComponentModel;

namespace OrdersApp.Helpers
{
    public class EnumHelper
    {
        public static string GetDescription(Enum @enum)
        {
            if (@enum == null)
                return null;

            var description = @enum.ToString();
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());
            if (fieldInfo == null)
                return description;

            var attributes =
                (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : description;
        }
    }
}