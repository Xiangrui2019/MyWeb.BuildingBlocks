using System;
using SeedWork.Tools;
using Xunit;

namespace SeedWork.UnitTests.Tools
{
    public class StringExtends_Tests
    {
        [Fact]
        public void TestStringToBytes()
        {
            var src = "test";
            var dst = src.StringToBytes();

            Assert.NotEmpty(dst);
        }
        
        [Fact]
        public void TestBytesToString()
        {
            var src = "test";
            var dst = src.StringToBytes();
            
            Assert.Equal(src, dst.BytesToString());
        }

        [Fact]
        public void TestBytesToBase64()
        {
            var src = new byte[] { 1, 2, 3 };
            var dst = src.BytesToBase64();
            
            Assert.NotEmpty(dst);
        }

        [Fact]
        public void TestBase64ToBytes()
        {
            var src = new byte[] { 1, 2, 3 };
            var dst = src.BytesToBase64();
            
            Assert.Equal(src, dst.Base64ToBytes());
        }

        [Fact]
        public void TestStringToBase64()
        {
            var src = "test";
            var dst = src.StringToBase64();
            
            Assert.NotEmpty(dst);
        }

        [Fact]
        public void TestBase64ToString()
        {
            var src = "test";
            var dst = src.StringToBase64();
            
            Assert.Equal(src, dst.Base64ToString());
        }

        [Fact]
        public void TestToUTF8WithDom()
        {
            var src = "test";
            var dst = src.ToUTF8WithDom();
            
            Assert.NotEmpty(dst);
        }
    }
}