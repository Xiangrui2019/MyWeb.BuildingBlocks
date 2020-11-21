using System.Collections.Generic;
using System.Linq;
using SeedWork.Tools;
using Xunit;

namespace SeedWork.UnitTests.Tools
{
    public class ListExtends_Tests
    {
        [Fact]
        public void TestShuffle()
        {
            var list = new List<int>(){ 1, 2, 3, 4, 5, 6 };
            list.Shuffle();
            
            Assert.NotEmpty(list);
        }
    }
}