using CustomSerializator.Utilities;

namespace CustomSerializator.JsonTypes
{
    public class JsonDecimalSerializer : IJsonSerializer<decimal>
    {
        public string Serialize(string key, decimal value)
        {
            return string.Format($"\"{key}\":{value.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        }
    }
}
