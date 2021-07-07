using CustomSerializator.Utilities;

namespace CustomSerializator.JsonTypes
{
    public class JsonFloatSerializer : IJsonSerializer<float>
    {
        public string Serialize(string key, float value)
        {
            return string.Format($"\"{key}\":{((float)value).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        }
    }
}
