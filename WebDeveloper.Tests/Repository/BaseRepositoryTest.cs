using Xunit;
using FluentAssertions;
using WebDeveloper.Repository;
using WebDeveloper.Model;
using System;
using Moq;
using System.Data.Entity;

namespace WebDeveloper.Tests.Repository
{

    public class BaseRepositoryTest
    {
        private IRepository<Person> _repository;
        public BaseRepositoryTest()
        {
            _repository = new BaseRepository<Person>();
        }
        [Fact(DisplayName = "AddTestOk")]
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
                ModifiedDate = DateTime.Now,
                rowguid = person.rowguid
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
            catch (Exception ex)
            {
                ex.Source.Should().Be("EntityFramework");
            }
        }

        [Fact(DisplayName = "MockData")]
        public void Test()
        {
            //var persons = Enumerable.Range(1, 10).Select(i => new Person
            //{
            //    PersonType = "SC",
            //    FirstName = $"Name{i}",
            //    LastName = $"LastName{i}",
            //    ModifiedDate = DateTime.Now,
            //}).AsQueryable();
            //var mockSet = new Mock<DbSet<Person>>();
            //mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(persons.Provider);
            //mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(persons.Expression);
            //mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            //mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(() => persons.GetEnumerator());


            //var contextMock = DbContextMockFactory.Create<WebContextDb>();
            //contextMock.Setup(m => m.Person).Returns(mockSet.Object);

            var personDbSetMock = new Mock<DbSet<Person>>();

            var webContextMock = new Mock<WebContextDb>();
            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);
            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var repository = new BaseRepository<Person>(webContextMock.Object);
            var newPerson = TestPersonOk();
            var result = repository.Add(newPerson);
            
            personDbSetMock.Verify(s => s.Add(It.IsAny<Person>()), Times.Once());
            webContextMock.Verify(c => c.SaveChanges(), Times.Once());
        }

        private Person TestPersonOk()
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
                ModifiedDate = DateTime.Now,
                rowguid = person.rowguid
            };
            return person;
        }
    }
}
