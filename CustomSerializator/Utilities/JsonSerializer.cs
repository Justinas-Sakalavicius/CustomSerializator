using CustomSerializator.JsonTypes;
using System.Text;

namespace CustomSerializator.Utilities
{
    public static class JsonSerializer
    {
        public static string Serialize(object obj)
        {
            StringBuilder stringBuilder = new();
            JsonSerializeMethods.SerializeObject(obj, stringBuilder);
            return stringBuilder.ToString(); 
        }

        public static string SerializeMap(JsonDictionary<string,object> dictionary)
        {
            if (dictionary == null)
            { 
                return null;
            }

            var typesResults = InterfacesTypes.GetAllTypesThatImplementInterface();

            StringBuilder stringBuilder = new();
            return JsonSerializeMethods.SerializeObject(stringBuilder, dictionary);
        }
    }
}
