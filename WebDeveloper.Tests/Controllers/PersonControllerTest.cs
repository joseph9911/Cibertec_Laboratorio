
using System.Web.Mvc;
using WebDeveloper.Areas.Personnel.Controllers;
using Xunit;
using FluentAssertions;
using System.Collections;
using WebDeveloper.Model;
using System.Collections.Generic;
using System.Linq;

namespace WebDeveloper.Tests.Controllers
{
    public class PersonControllerTest
    {
        private PersonController controller;
        public PersonControllerTest()
        {
            controller = new PersonController();
        }

        [Fact(DisplayName = "ListActionWithEmptyParameters")]
        public void ListActionWithEmptyParameters()
        {
            var result = controller.List(null, null) as PartialViewResult;
            result.ViewName.Should().Be("_List");

            var modelCount = (IEnumerable<Person>)result.Model;
            modelCount.Count().Should().Be(15);
        }

    }
}
