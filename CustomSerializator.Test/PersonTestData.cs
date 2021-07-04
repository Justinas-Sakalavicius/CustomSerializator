using System.Collections;
using System.Collections.Generic;

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
                  AdditionScore = 2.5f,
                  Adult = true
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
