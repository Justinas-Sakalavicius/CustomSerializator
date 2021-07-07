using CustomSerializator.Model;
using CustomSerializator.Utilities;
using System;

namespace CustomSerializator
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new() { Name = "Justas", Age = 25, Score = 2.21M, ExtraScore = 231.23, AdditionScore = 1.2f, Adult = true };

            var address = new JsonDictionary<string, object>();
            address["City"] = "Vilnius";
            address["Age"] = 225;
            address.Add("Price", 2.25);
            address.Add("Price2", 2.75f);
            address.Add("Price3", 2.05M);
            address.Add("Jumping", false);
            address.Add("Jumps", true);

            var resultT1 = JsonSerializer.Serialize(person);
            var resultT2 = JsonSerializer.SerializeMap(address);

            Console.ReadLine();
        }
    }
}
