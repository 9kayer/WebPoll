using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Repository;
using WebPoll.Service.Test.TestContainer;
using Xunit;

namespace WebPoll.Test.Repository
{
    public abstract class RepositoryTest<T> where T : IModel
    {
        private TestContainer<T> _testContainer;
        private IRepository<T> _repository;

        public RepositoryTest(IRepository<T> repository , TestContainer<T> testContainer)
        {
            _testContainer = testContainer;
            _repository = repository;
        }

        [Fact]
        public abstract void GetAll_ReturnsWhatIsInTheDBSet();

        [Fact]
        public virtual void Insert_GetAllWithOneMoreElement()
        {
            int previousCount = _repository.GetAll().Count;
            
            _repository.Insert((_testContainer.Dictionary.GetValueOrDefault(RepositoryOperations.FIRST_INSERT)));

            Assert.Equal(previousCount + 1, _repository.GetAll().Count);
        }

        [Fact]
        public virtual void Insert_PersistDataCorrectly()
        {
            _repository.Insert((_testContainer.Dictionary.GetValueOrDefault(RepositoryOperations.SECOND_INSERT)));

            Assert.Contains<T>(_testContainer.Dictionary.GetValueOrDefault(RepositoryOperations.SECOND_INSERT) , _repository.GetAll());
        }

        public abstract void Update_PersistDataCorrectly();

        public virtual void Delete_RemovesItemFromTheContext()
        {
            _repository
        }

        
    }
}
