using System.Collections.Generic;
using SeedWork.Models.DDD;
using Xunit;

namespace SeedWork.UnitTests.Models
{
    public class TestValueObject : ValueObject
    {
        public string Name { get; set; }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
    
    public class ValueObject_Tests
    {
        [Fact]
        public void TestEquals()
        {
            var valueObject1 = new TestValueObject();
            valueObject1.Name = "test";
            var valueObject2 = new TestValueObject();
            valueObject2.Name = "test";
            var valueObject3 = new TestValueObject();
            valueObject3.Name = "test2";
            
            Assert.True(valueObject1.Equals(valueObject2));
            Assert.True(valueObject2.Equals(valueObject1));
            Assert.False(valueObject3.Equals(valueObject1));
        }
        
        [Fact]
        public void TestGetHashCode()
        {
            var valueObject1 = new TestValueObject();
            valueObject1.Name = "test";
            var valueObject2 = new TestValueObject();
            valueObject2.Name = "test";
            var valueObject3 = new TestValueObject();
            valueObject3.Name = "test2";
            
            Assert.Equal(valueObject1.GetHashCode(), valueObject2.GetHashCode());
            Assert.Equal(valueObject2.GetHashCode(), valueObject1.GetHashCode());
            Assert.NotEqual(valueObject1.GetHashCode(), valueObject3.GetHashCode());
        }

        [Fact]
        public void TestCopy()
        {
            var valueObject1 = new TestValueObject();
            valueObject1.Name = "test";
            var valueObject2 = (TestValueObject) valueObject1.GetCopy();
            
            Assert.Equal(valueObject1.Name, valueObject2.Name);
            Assert.True(valueObject1.Equals(valueObject2));
        }

        [Fact]
        public void TestEqualCompute()
        {
            var valueObject1 = new TestValueObject();
            valueObject1.Name = "test";
            var valueObject2 = new TestValueObject();
            valueObject2.Name = "test";
            var valueObject3 = new TestValueObject();
            valueObject3.Name = "test2";
            
            Assert.True(valueObject1 == valueObject2);
            Assert.True(valueObject2 == valueObject1);
            Assert.True(valueObject2 != valueObject3);
        }
    }
}