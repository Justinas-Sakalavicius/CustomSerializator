using System;
using System.Collections.Generic;

namespace CustomSerializator
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new() { Name = "Justas", Age = 25, Score = 2.21M, ExtraScore = 231.23, AdditionScore = 1.2f, Adult = true };

            var resultObj = JSON.ToJSON(person);

            List<Person> list = new();
            list.AddRange(new List<Person> {
                new Person { Name = "Test1", Age = 25, Score = 2.21M, ExtraScore = 231.23, AdditionScore = 1.2f, Adult = true },
                new Person { Name = "TEe1", Age = 35, Score = 2.21M, ExtraScore = 231.23, AdditionScore = 1.2f, Adult = true },
                new Person { Name = "Justas", Age = 50, Score = 2.21M, ExtraScore = 231.23, AdditionScore = 1.2f, Adult = false }
            });

            var resultArray = JSON.ToJSON(list);

            Console.ReadLine();
        }
    }
}
