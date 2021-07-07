using CustomSerializator.Utilities;

namespace CustomSerializator.JsonTypes
{
    public class JsonBooleanSerializer : IJsonSerializer<bool>
    {
        public string Serialize(string key, bool value)
        {
            return string.Format($"\"{key}\":{(value ? "true" : "false")}");
        }
    }
}
