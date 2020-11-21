using Handler.Exceptions;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;
using Xunit;

namespace Handler.UnitTests.Exceptions
{
    public class UnexpectedException_Tests
    {
        [Fact]
        public void TestBasic()
        {
            var exception = new UnexpectedException(new MessageModel()
            {
                Code = ErrorType.Success,
                Message = "Testing"
            });
            
            Assert.Equal(1, exception.Code.Id);
            Assert.Equal("Testing", exception.Message);
        }

        [Fact]
        public void TestThrowException()
        {
            try
            {
                throw new UnexpectedException(new MessageModel()
                {
                    Code = ErrorType.Success,
                    Message = "Testing"
                });
            }
            catch(UnexpectedException e)
            {
                Assert.Equal(1, e.Code.Id);
                Assert.Equal("Testing", e.Message);
            }
        }
    }
}