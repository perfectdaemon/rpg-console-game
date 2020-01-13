using System;
using System.ComponentModel;
using System.Linq;

namespace ClassicRPG
{
    public static class Extensions
    {
        public static string GetDescription(this Enum self) => self.GetAttribute<DescriptionAttribute>().Description;

        public static TAttributeType GetAttribute<TAttributeType>(this Enum self)
        {
            var enumType = self.GetType();

            var fieldName = Enum.GetName(enumType, self);

            var attr = enumType.GetField(fieldName)
                .GetCustomAttributes(false)
                .OfType<TAttributeType>()
                .SingleOrDefault();

            return attr;
        }
    }
}
