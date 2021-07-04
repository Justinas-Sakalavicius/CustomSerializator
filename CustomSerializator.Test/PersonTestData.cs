using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerializator.Test
{
    public class PersonTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Person
                {
                  Name = "Jo",
                  Age = 36,
                  Score = 23.1M,
                  ExtraScore = 9.31,
                  AdditionScore = 2.5f
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
