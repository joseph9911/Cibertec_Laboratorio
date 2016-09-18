using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Repository;
using Xunit;
using FluentAssertions;
using Moq;
using System.Data.Entity;

namespace WebDeveloper.Tests.Repository
{
    public class BaseRepositoryTest
    {
        private IRepository<Person> repository;
        public BaseRepositoryTest()
        {
            repository = new BaseRepository<Person>();
        }

        [Fact(DisplayName = "AddTestWrongWithMissingData")]
        public void AddTestWrongWithMissingData()
        {
            var person = new Person();            
            person.PersonType = "SC";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.rowguid = Guid.NewGuid();
            try
            {
                repository.Add(person);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }

        [Fact(DisplayName = "AddTestWrongWithNull")]
        public void AddTestWrongWithNull()
        {
            var person = new Person();
            try
            {
                repository.Add(person);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }            
        }

        [Fact(DisplayName = "AddTestWithProperData")]
        public void AddTestWithProperData()
        {
            Person person = TestPersonOk();
            var result = repository.Add(person);
            result.Should().BeGreaterThan(0);
        }
                
        [Fact(DisplayName = "MockData")]
        public void MockData()
        {
            var personDbSetMock =
                new Mock<DbSet<Person>>();


            var webContextMock =
                new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var repository = new BaseRepository<Person>(webContextMock.Object);

            var newPerson = TestPersonOk();
            repository.Add(newPerson);
            personDbSetMock.Verify(p => p.Add(It.IsAny<Person>()), Times.Once);

            webContextMock.Verify(w => w.SaveChanges(), Times.Once);                  
        }

        [Fact(DisplayName = "MockDataUpdate")]
        public void MockDataUpdate()
        {          
            var personList = PersonList().AsQueryable();
            var personDbSetMock = new Mock<DbSet<Person>>();
            //El origen de datos con lo que se trabaja en este caso la lista.
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personList.GetEnumerator());
            
            var webContextMock =
               new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);
            
            var _repository = new BaseRepository<Person>(webContextMock.Object);

            var personToUpdate = _repository.GetById(x => x.FirstName == "Name1");

            var result = _repository.Update(personToUpdate);

            webContextMock.Verify(c => c.SaveChanges(), Times.Once());
        }

        [Fact(DisplayName = "MockDataDelete")]
        public void MockDataDelete()
        {
            var personList = PersonList().AsQueryable();
            var personDbSetMock = new Mock<DbSet<Person>>();
            //El origen de datos con lo que se trabaja en este caso la lista.
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personList.GetEnumerator());

            var webContextMock =
               new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var _repository = new BaseRepository<Person>(webContextMock.Object);

            var personToDelete = _repository.GetById(x => x.FirstName == "Name1");

            var result = _repository.Delete(personToDelete);

            webContextMock.Verify(c => c.SaveChanges(), Times.Once());
        }


        [Fact(DisplayName = "MockDataById")]
        public void MockDataById()
        {
            var personList = PersonList().AsQueryable();
            var personDbSetMock = new Mock<DbSet<Person>>();
            //El origen de datos con lo que se trabaja en este caso la lista.
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);

            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);

            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);

            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personList.GetEnumerator());

            var webContextMock =
               new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var repository = new BaseRepository<Person>(webContextMock.Object);

            var personGetByID = repository.GetById(p => p.FirstName == "Name1");

            personGetByID.Should().NotBeNull();
        }


        [Fact(DisplayName = "MockDataList")]
        public void MockDataList()
        {
            var personList = PersonList().AsQueryable();
            var personDbSetMock = new Mock<DbSet<Person>>();
            //El origen de datos con lo que se trabaja en este caso la lista.
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personList.GetEnumerator());

            var webContextMock =
               new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var _repository = new BaseRepository<Person>(webContextMock.Object);

            var result = _repository.GetList();
            result.Count.Should().BeGreaterOrEqualTo(10);

        }


        [Fact(DisplayName = "MockDataListById")]
        public void MockDataListById()
        {
            var personList = PersonList().AsQueryable();
            var personDbSetMock = new Mock<DbSet<Person>>();
            //El origen de datos con lo que se trabaja en este caso la lista.
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personList.GetEnumerator());

            var webContextMock =
               new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var _repository = new BaseRepository<Person>(webContextMock.Object);

            var result = _repository.ListById(x => x.BusinessEntityID == 1);
            result.Count().Should().BeGreaterOrEqualTo(1);

        }


        [Fact(DisplayName = "MockDataOrderedList")]
        public void MockDataOrderedList()
        {
            var personList = PersonList().AsQueryable();
            var personDbSetMock = new Mock<DbSet<Person>>();
            //El origen de datos con lo que se trabaja en este caso la lista.
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);
            personDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personList.GetEnumerator());

            var webContextMock =
               new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Person).Returns(personDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Person>()).Returns(personDbSetMock.Object);

            var _repository = new BaseRepository<Person>(webContextMock.Object);

            var result = _repository.OrderedListByDateAndSize(x => x.ModifiedDate, 5);
            result.Count().Should().BeGreaterOrEqualTo(5);

        }



        [Fact(DisplayName = "MockConstructor")]
        public void MockConstructor()
        {
            var repository = new BaseRepository<Person>();
            repository.Should().NotBeNull();
        }


        private IEnumerable<Person> PersonList()
        {
            return Enumerable.Range(1, 10).Select(i => new Person
                {
                    BusinessEntityID = i,
                    PersonType = "SC",
                    FirstName = $"Name{i}",
                    LastName = $"LastName{i}",
                    ModifiedDate = DateTime.Now
                });
        }

        private Person TestPersonOk()
        {
            var person = new Person();
            person.PersonType = "SC";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                ModifiedDate = person.ModifiedDate,
                rowguid = person.rowguid
            };
            return person;
        }

    }
}
