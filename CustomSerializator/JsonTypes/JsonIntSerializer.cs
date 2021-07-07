using CustomSerializator.Utilities;

namespace CustomSerializator.JsonTypes
{
    public class IJsonSerializer : IJsonSerializer<int>
    {
        public string Serialize(string key, int value)
        {
            return string.Format($"\"{key}\":{value}");
        }
    }
}
