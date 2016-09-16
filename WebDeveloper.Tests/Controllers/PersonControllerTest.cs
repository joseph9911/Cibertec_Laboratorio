﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebDeveloper.Areas.Personnel.Controllers;
using WebDeveloper.Model;
using WebDeveloper.Repository;
using Xunit;

namespace WebDeveloper.Tests.Controllers
{
    public class PersonControllerTest
    {
        private PersonController controller;
        public PersonControllerTest()
        {
            controller = new PersonController(new BaseRepository<Person>());
        }

        [Fact(DisplayName = "ListActionEmptyParametersTest")]
        private void ListActionEmptyParametersTest()
        {
            var result = controller.List(null, null) as PartialViewResult;
            result.ViewName.Should().Be("_List");

            var modelCount = (IEnumerable<Person>)result.Model;
            modelCount.Count().Should().Be(10);
        }
    }
}
