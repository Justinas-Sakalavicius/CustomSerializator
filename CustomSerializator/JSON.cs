using System;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace CustomSerializator
{
    public static class JSON
    {
        public static string ToJSON(this object item)
        {
            StringBuilder stringBuilder = new();
            ConstructJson(stringBuilder, item);
            return stringBuilder.ToString();
        }

        private static void ConstructJson(StringBuilder stringBuilder, object item)
        {
            if (item == null)
            {
                stringBuilder.Append(JConst.NullValue);
                return;
            }

            if (item.GetType().IsGenericType | item.GetType().IsArray)
            {
                ConstructArray(stringBuilder, item);
            }
            else
            {
                ConstructObject(stringBuilder, item);
            }
        }

        private static StringBuilder ConstructObject(StringBuilder stringBuilder, object item)
        {
            stringBuilder.Append(JConst.LeftBrace);

            bool isFirst = true;
            PropertyInfo[] propertyInfo = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (!propertyInfo[i].CanRead || propertyInfo[i].IsDefined(typeof(IgnoreDataMemberAttribute), true))
                    continue;

                object value = propertyInfo[i].GetValue(item, null);
                if (value != null)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        stringBuilder.Append(JConst.Comma);
                    }

                    AssignValue(stringBuilder, propertyInfo[i], value);
                }
            }
            stringBuilder.Append(JConst.RightBrace);

            return stringBuilder;
        }

        private static StringBuilder ConstructArray(StringBuilder stringBuilder, object value)
        {
            stringBuilder.Append(JConst.LeftBracket);
            bool isFirst = true;
            IList list = value as IList;
            for (int i = 0; i < list.Count; i++)
            {
                if (isFirst)
                    isFirst = false;
                else
                    stringBuilder.Append(JConst.Comma);
                ConstructObject(stringBuilder, list[i]);
            }
            stringBuilder.Append(JConst.RightBracket);

            return stringBuilder;
        }

        private static StringBuilder AssignValue(StringBuilder stringBuilder, PropertyInfo propertyName, object value)
        {
            stringBuilder.Append(JConst.SlashQuotes);
            stringBuilder.Append(GetMemberName(propertyName));
            stringBuilder.Append(JConst.Colon);
            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.String:
                    stringBuilder.Append(JConst.Quotes + value.ToString() + JConst.Quotes);
                    break;
                case TypeCode.Int32:
                    stringBuilder.Append(value);
                    break;
                case TypeCode.Decimal:
                    stringBuilder.Append(((decimal)value).ToString(System.Globalization.CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Double:
                    stringBuilder.Append(((double)value).ToString(System.Globalization.CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Single:
                    stringBuilder.Append(((float)value).ToString(System.Globalization.CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Boolean:
                    stringBuilder.Append(((bool)value) ? "true" : "false");
                    break;
                default:
                    break;
            }

            return stringBuilder;
        }
       
        private static string GetMemberName(MemberInfo member)
        {
            if (member.IsDefined(typeof(DataMemberAttribute), true))
            {
                DataMemberAttribute dataMemberAttribute = (DataMemberAttribute)Attribute.GetCustomAttribute(member, typeof(DataMemberAttribute), true);
                if (!string.IsNullOrEmpty(dataMemberAttribute.Name))
                    return dataMemberAttribute.Name;
            }

            return member.Name;
        }
    }
}
