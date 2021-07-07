using CustomSerializator.Utilities;

namespace CustomSerializator.JsonTypes
{
    public class JsonStringSerializer : IJsonSerializer<string>
    {
        public string Serialize(string key, string value)
        {
            return string.Format($"\"{key}\":\"{value}\"");
        }
    }
}
