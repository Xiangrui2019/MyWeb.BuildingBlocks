using SeedWork.ErrorCode;
using Xunit;

namespace SeedWork.UnitTests.ErrorCode
{
    public class ErrorType_Tests
    {
        [Fact]
        public void TestGet()
        {
            var success = ErrorType.Success;

            Assert.Equal(1, success.Id);
            Assert.Equal("Success", success.Name);
        }

        [Fact]
        public void TestToString()
        {
            var success = ErrorType.Success;

            Assert.Equal(success.Name, success.ToString());
        }

        [Fact]
        public void TestEquals()
        {
            var success = ErrorType.Success;
            var e = ErrorType.Success;
            Assert.True(success.Equals(e));
            
            var test = new ErrorType(2, "Test");
            Assert.False(success.Equals(test));
            
            var test2 = new ErrorType(1, "TTT");
            Assert.True(success.Equals(test2));
        }

        [Fact]
        public void TestHashCodeId()
        {
            var success = ErrorType.Success;

            var hashCode = success.GetHashCode();
            Assert.Equal(success.GetHashCode(), hashCode);
            
            var test1 = new ErrorType(1, "TTTT");
            var test2 = new ErrorType(2, "TTTT");
            
            Assert.Equal(test1.GetHashCode(), success.GetHashCode());
            Assert.NotEqual(test2.GetHashCode(), success.GetHashCode());
        }
    }
}