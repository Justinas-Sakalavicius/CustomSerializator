namespace CustomSerializator.Utilities
{
    public interface IJsonSerializer<TValue>
    {
        string Serialize(string key, TValue value);
    }
}
