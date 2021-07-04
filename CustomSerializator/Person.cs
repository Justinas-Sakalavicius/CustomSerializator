using System;

namespace CustomSerializator
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Score { get; set; }
        public float AdditionScore { get; set; }
        public double ExtraScore { get; set; }
        public bool Adult { get; set; }
    }
}
