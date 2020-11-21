using Handler.Exceptions;
using SeedWork.ErrorCode;
using SeedWork.Services;
using Xunit;

namespace Handler.UnitTests.Exceptions
{
    public class ApiModelException_Tests
    {
        [Fact]
        public void TestBasic()
        {
            var exception = new ApiModelException(ErrorType.Success, "Testing");
            
            Assert.Equal(1, exception.Code.Id);
            Assert.Equal("Testing", exception.Message);
        }

        [Fact]
        public void TestThrowException()
        {
            try
            {
                throw new ApiModelException(ErrorType.Success, "Testing");
            }
            catch(ApiModelException e)
            {
                Assert.Equal(1, e.Code.Id);
                Assert.Equal("Testing", e.Message);
            }
        }
    }
}