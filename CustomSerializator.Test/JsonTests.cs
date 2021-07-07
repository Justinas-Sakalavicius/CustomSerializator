using CustomSerializator.Utilities;
using Xunit;

namespace CustomSerializator.Test
{
    public class JsonTests
    {
        [Fact]
        public void CorrectlySerializeString()
        {
            var result = JsonSerializer.Serialize(new { Name = "Justas" });
            Assert.Equal("{\"Name\":\"Justas\"}", result);
        }

        [Fact]
        public void CorrectlySerializeInt()
        {
            var result = JsonSerializer.Serialize(new { Age = 22 });
            Assert.Equal("{\"Age\":22}", result);
        }

        [Fact]
        public void CorrectlySerializeStringAndIntProperties()
        {
            var result = JsonSerializer.Serialize(new { Age = 22, Name = "Justas" });
            Assert.Equal("{\"Age\":22,\"Name\":\"Justas\"}", result);
        }

        [Fact]
        public void CorrectlySerializeDouble()
        {
            var result = JsonSerializer.Serialize(new { Price = 22.55 });
            Assert.Equal("{\"Price\":22.55}", result);
        }

        [Fact]
        public void CorrectlySerializeFloat()
        {
            var result = JsonSerializer.Serialize(new { Price = 22.666f });
            Assert.Equal("{\"Price\":22.666}", result);
        }

        [Fact]
        public void CorrectlySerializeDecimal()
        {
            var result = JsonSerializer.Serialize(new { Price = (decimal)22.666 });
            Assert.Equal("{\"Price\":22.666}", result);
        }

        [Fact]
        public void CorrectlySerializeTrue()
        {
            var result = JsonSerializer.Serialize(new { IsNew = true });
            Assert.Equal("{\"IsNew\":true}", result);
        }

        [Fact]
        public void CorrectlySerializeFalse()
        {
            var result = JsonSerializer.Serialize(new { IsNew = false });
            Assert.Equal("{\"IsNew\":false}", result);
        }

        [Fact]
        public void CorrectlySerializeArray()
        {
            var result = JsonSerializer.Serialize(new { IsNew = new[] { 4, 5 } });
            Assert.Equal("{\"IsNew\":[4,5]}", result);
        }

        [Fact]
        public void CorrectlySerializeEmptyArray()
        {
            var result = JsonSerializer.Serialize(new { IsNew = new int[] { } });
            Assert.Equal("{\"IsNew\":[]}", result);
        }

        [Fact]
        public void CorrectlySerialize2DArray()
        {
            var result = JsonSerializer.Serialize(new { IsNew = new[] { new[] { 1, 2 }, new[] { 3, 4 } } });
            Assert.Equal("{\"IsNew\":[[1,2],[3,4]]}", result);
        }

        [Fact]
        public void CorrectlySerializeVariousArrays()
        {
            var result = JsonSerializer.Serialize(
                new
                {
                    @string = new[] { "just", "string" },
                    @bool = new[] { false, true },
                    @float = new[] { 1.2f, 1.4f }
                });
            Assert.Equal("{\"string\":[\"just\",\"string\"],\"bool\":[false,true],\"float\":[1.2,1.4]}", result);
        }

        [Fact]
        public void CorrectlySerializeObject()
        {
            var result = JsonSerializer.Serialize(
                new
                {
                    object1 = new
                    {
                        name = "Name",
                        value = 4
                    }
                });
            Assert.Equal("{\"object1\":{\"name\":\"Name\",\"value\":4}}", result);
        }

        [Fact]
        public void CorrectlySerializeNestedObject()
        {
            var result = JsonSerializer.Serialize(
                new
                {
                    object1 = new
                    {
                        object2 = new
                        {
                            object3 = new
                            {
                                value = true
                            }
                        }
                    }
                });
            Assert.Equal("{\"object1\":{\"object2\":{\"object3\":{\"value\":true}}}}", result);
        }
    }
}
