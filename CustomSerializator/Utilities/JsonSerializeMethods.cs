using CustomSerializator.JsonTypes;
using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace CustomSerializator.Utilities
{
    public static class JsonSerializeMethods
    {
        public static string SerializeObject(StringBuilder stringBuilder, JsonDictionary<string, object> dictionary)
        {
            foreach (string key in dictionary)
            {
                var value = dictionary.Get(key);

                var result = Type.GetTypeCode(value.GetType()) switch
                {
                    TypeCode.String => new JsonStringSerializer().Serialize(key, value.ToString()),
                    TypeCode.Char => new JsonStringSerializer().Serialize(key, value.ToString()),
                    TypeCode.Int32 => new IJsonSerializer().Serialize(key, int.Parse(value.ToString())),
                    TypeCode.Decimal => new JsonDecimalSerializer().Serialize(key, decimal.Parse(value.ToString())),
                    TypeCode.Double => new JsonDoubleSerializer().Serialize(key, double.Parse(value.ToString())),
                    TypeCode.Single => new JsonFloatSerializer().Serialize(key, float.Parse(value.ToString())),
                    TypeCode.Boolean => new JsonBooleanSerializer().Serialize(key, bool.Parse(value.ToString())),
                    TypeCode.Object => null,
                    _ => null
                };

                if (result != null)
                {
                    stringBuilder.Append(result + ",");
                }
            }

            return stringBuilder.Replace(stringBuilder.ToString(), "{" + stringBuilder + "}").ToString();
        }

        public static void SerializeObject(object o, StringBuilder sb)
        {
            sb.Append("{");
            var properties = o.GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (i != 0) sb.Append(",");
                var value = properties[i].GetValue(o, null);
                var name = properties[i].Name;

                sb.Append($"\"{name}\":");
                AppendValue(value, properties[i].PropertyType, sb);
            }

            sb.Append("}");
        }

        private static void AppendValue(object value, Type type, StringBuilder sb)
        {
            if (type.IsArray)
            {
                sb.Append("[");

                var arr = (IList)value;

                for (var i = 0; i < arr.Count; i++)
                {
                    if (i != 0) sb.Append(",");
                    AppendValue(arr[i], arr[i]?.GetType(), sb);
                }

                sb.Append("]");
                return;
            }

            if (type.IsClass && type.Name != "String")
            {
                SerializeObject(value, sb);
                return;
            }

            sb.Append(type.Name switch
            {
                "String" => $"\"{value}\"",
                "Boolean" => value != null && (bool)value ? "true" : "false",
                _ => Convert.ToString(value, CultureInfo.InvariantCulture)
            });
        }
    }
}
