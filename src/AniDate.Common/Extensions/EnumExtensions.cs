using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace AniDate.Common.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription<T>([NotNull]this T enumValue) where T : struct
        {
            var type = enumValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("Passed parameter must be of enum type");
            }
            var enumInfo = type.GetMember(enumValue.ToString());
            if (enumInfo.Length > 0)
            {
                var attributes = enumInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    var description = ((DescriptionAttribute)attributes[0]).Description.ToString();
                    return description;
                }
            }
            return enumValue.ToString();
        }
        
        public static int GetHttpStatusCode(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            
            HttpStatusCodeAttribute[] attributes = (HttpStatusCodeAttribute[])fieldInfo.
                GetCustomAttributes(typeof(HttpStatusCodeAttribute), false);
            
            return (attributes.Length > 0) ? attributes[0].StatusCode : (int)HttpStatusCode.OK;
        }
    }
}