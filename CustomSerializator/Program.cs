﻿using Newtonsoft.Json.Linq;
using System;

namespace CustomSerializator
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new() { Name = "Justas", Age = 25 };
            string filePath = "data.save";
            Person p = null;

            var json = new JObject();
            json["Name"] = "Justas";
            json["Age"] = 25;
            var jsonStr = json.ToString();


            var resultO = JSON.ToJSON(person);

            Console.ReadLine();
        }
    }
}
