using System.Threading;
using System.Threading.Tasks;
using DBTools.EntityFramework.Abstract.Repositories;
using DBTools.EntityFramework.Abstract.UnitOfWork;
using SeedWork.Models.DDD;
using Xunit;

namespace DBTools.EntitytFramework.UnitTests.Repositories
{
    internal class TestEntity : Entity
    {
        public string Name { get; set; }
    }

    internal class TestRepository : IRepository<TestEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TestRepository()
        {
            _unitOfWork = new TestUnitOfWork();
        }

        public override Task<int> CommitAsync()
        {
            return _unitOfWork.SaveChangesAsync();
        }
    }

    internal class TestUnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(15);
        }
    }
    
    public class Repository_Tests
    {
        [Fact]
        public void TestBasic()
        {
            var repo = new TestRepository();

            var result = repo.CommitAsync().Result;
            
            Assert.Equal(15, result);
        }
    }
}