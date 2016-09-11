using Xunit;
using FluentAssertions;
using WebDeveloper.Repository;
using WebDeveloper.Model;
using System;

namespace WebDeveloper.Tests.Repository
{

    public class BaseRepositoryTest
    {
        private IRepository<Person> _repository;
        public BaseRepositoryTest()
        {
            _repository = new BaseRepository<Person>();
        }
        [Fact(DisplayName ="AddTestOk")]
        public void AddTestOk()
        {
            var person = new Person
            {
                PersonType = "SC",
                FirstName = "Test",
                LastName = "Test",
                EmailPromotion = 1
            };
            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                ModifiedDate= DateTime.Now,
                rowguid= person.rowguid
            };

            var result = _repository.Add(person);
            result.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "AddTestWrong")]
        public void AddTestWrong()
        {
            var person = new Person();
            person.rowguid = Guid.NewGuid();
            try
            {
                _repository.Add(person);
            }
            catch(Exception ex)
            {
                ex.Source.Should().Be("EntityFramework");                
            }
        }
    }
}
