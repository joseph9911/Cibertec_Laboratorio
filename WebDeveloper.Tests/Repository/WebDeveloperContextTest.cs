using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Repository;
using Xunit;
using FluentAssertions;

namespace WebDeveloper.Tests.Repository
{
    public class WebDeveloperContextTest
    {
        private WebContextDb dbContext;
        public WebDeveloperContextTest()
        {
            dbContext = new WebContextDb();
        }
        [Fact(DisplayName = "WebDeveloperDbContextTest")]
        public void WebDeveloperDbContextTest()
        {
            dbContext.Address.Should().NotBeNull();
            dbContext.AddressType.Should().NotBeNull();
            dbContext.BusinessEntity.Should().NotBeNull();
            dbContext.BusinessEntityAddress.Should().NotBeNull();
            dbContext.BusinessEntityContact.Should().NotBeNull();
            dbContext.ContactType.Should().NotBeNull();
            dbContext.CountryRegion.Should().NotBeNull();
            dbContext.EmailAddress.Should().NotBeNull();
            dbContext.Password.Should().NotBeNull();
            dbContext.Person.Should().NotBeNull();
            dbContext.PersonPhone.Should().NotBeNull();
            dbContext.PhoneNumberType.Should().NotBeNull();
            dbContext.StateProvince.Should().NotBeNull();
            dbContext.Picture.Should().NotBeNull();
        }
    }
}
