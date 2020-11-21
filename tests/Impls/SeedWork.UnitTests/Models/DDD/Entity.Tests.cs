using SeedWork.Models.DDD;
using Xunit;

namespace SeedWork.UnitTests.Models
{
    public class TestEntity : Entity
    {
        public string Name { get; set; }
    }
    
    public class Entity_Tests
    {
        [Fact]
        public void TestBasic()
        {
            var entity = new TestEntity();
            entity.Id = 10;
            entity.Name = "Test";
            
            Assert.Equal(10, entity.Id);
            Assert.Equal("Test", entity.Name);
        }
        
        [Fact]
        public void TestIsTransient()
        {
            var entity = new TestEntity();
            var entityInited = new TestEntity();
            entityInited.Id = 10;
            
            Assert.True(entity.IsTransient());
            Assert.False(entityInited.IsTransient());
        }

        [Fact]
        public void TestEqualsTransient()
        {
            var entity1 = new TestEntity();
            var entity2 = new TestEntity();
            
            Assert.False(entity1.Equals(entity2));
        }

        [Fact]
        public void TestEquals()
        {
            var entity1 = new TestEntity();
            entity1.Id = 15;
            var entity2 = new TestEntity();
            entity2.Id = 15;
            var entity3 = new TestEntity();
            entity3.Id = 10;
            
            Assert.True(entity1.Equals(entity2));
            Assert.True(entity2.Equals(entity1));
            Assert.False(entity1.Equals(entity3));
        }

        [Fact]
        public void TestGetHashCode()
        {
            var entity1 = new TestEntity();
            entity1.Id = 10;
            var entity2 = new TestEntity();
            entity2.Id = 10;
            var entity3 = new TestEntity();
            entity3.Id = 15;
            
            Assert.Equal(entity1.GetHashCode(), entity2.GetHashCode());
            Assert.NotEqual(entity1.GetHashCode(), entity3.GetHashCode());
        }

        public void TestGetHashCodeTransient()
        {
            var entity1 = new TestEntity();
            var entity2 = new TestEntity();
            
            Assert.NotEqual(entity1.GetHashCode(), entity2.GetHashCode());
        }

        [Fact]
        public void TestEqualCompute()
        {
            var entity1 = new TestEntity();
            entity1.Id = 15;
            var entity2 = new TestEntity();
            entity2.Id = 15;
            var entity3 = new TestEntity();
            entity3.Id = 10;
            
            Assert.True(entity1 == entity2);
            Assert.True(entity2 == entity1);
            Assert.True(entity2 != entity3);
        }
    }
}