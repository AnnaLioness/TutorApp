using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Получить Description атрибут для значения перечисления
        /// </summary>
        public static string GetDescription(Enum value)
        {
            if (value == null)
                return string.Empty;

            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }

        /// <summary>
        /// Получить все значения перечисления с их описаниями
        /// </summary>
        public static List<EnumItem<T>> GetEnumItems<T>() where T : Enum
        {
            var items = new List<EnumItem<T>>();

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                items.Add(new EnumItem<T>
                {
                    Value = value,
                    Description = GetDescription(value)
                });
            }

            return items;
        }
    }

    /// <summary>
    /// Вспомогательный класс для хранения значения и описания перечисления
    /// </summary>
    public class EnumItem<T> where T : Enum
    {
        public T Value { get; set; }
        public string Description { get; set; }

        public override string ToString() => Description;
    }
}

