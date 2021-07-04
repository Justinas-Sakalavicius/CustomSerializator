using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomSerializator.Test
{
    public class JsonTests
    {
        [Theory]
        [ClassData(typeof(PersonTestData))]
        public void test1(object obj)
        {
            var resultObj = JSON.ToJSON(obj);

            Assert.Equal("{\"Name\":\"Jo\",\"Age\":36,\"Score\":23.1,\"AdditionScore\":2.5,\"ExtraScore\":9.31}", resultObj);
        }
    }
}
