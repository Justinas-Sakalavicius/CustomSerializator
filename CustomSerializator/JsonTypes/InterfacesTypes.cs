using CustomSerializator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomSerializator.JsonTypes
{
    public static class InterfacesTypes
    {
        public static IEnumerable<Type> GetAllTypesThatImplementInterface()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetInterface(typeof(IJsonSerializer<>).Name.ToString()) != null)
                .ToList();
        }
    }
}
