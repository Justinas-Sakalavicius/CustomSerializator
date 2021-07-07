using CustomSerializator.Utilities;

namespace CustomSerializator.JsonTypes
{
    public class JsonDoubleSerializer : IJsonSerializer<double>
    {
        public string Serialize(string key, double value)
        {
            return string.Format($"\"{key}\":{((double)value).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        }
    }
}
