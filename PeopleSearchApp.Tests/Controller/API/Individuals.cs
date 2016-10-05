using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchApp.Models;
using System.Collections.Generic;
using PeopleSearchApp.Controllers.API;
using System.Threading.Tasks;

namespace PeopleSearchApp.Tests
{
    [TestClass]
    public class IndividualsAPITest
    {
        [TestMethod]
        public async Task GetIndividuals_ReturnAllIndividuals()
        {
            var testIndividuals = GetTestIndividuals();

            var controller = new IndividualsController(testIndividuals);

            //var actionResult = controller.GetIndividuals();
        }

        private List<Individual> GetTestIndividuals()
        {
            List<Individual> testIndividuals = new List<Individual>
            {
                new Individual { FirstName = "Jace", LastName = "Milne", Age = 24, Interests = "Disco Skating", Address = "123 N State St",
                Picture = "/Content/avatar_male.png"},
                new Individual { FirstName = "John", LastName = "Smith", Age = 24, Interests = "Volleybal", Address = "456 N State St",
                Picture = "/Content/avatar_male.png"},
                new Individual { FirstName = "Emily", LastName = "Doe", Age = 24, Interests = "Dancing", Address = "789 N State St",
                Picture = "/Content/avatar_female.png"},
                new Individual { FirstName = "Alex", LastName = "Miller", Age = 24, Interests = "Football", Address = "012 N State St",
                Picture = "/Content/avatar_male.png"},
                new Individual { FirstName = "Roger", LastName = "Turner", Age = 24, Interests = "Running", Address = "345 N State St",
                Picture = "/Content/avatar_male.png"},
                new Individual { FirstName = "Wilson", LastName = "Norman", Age = 24, Interests = "Development", Address = "678 N State St",
                Picture = "/Content/avatar_male.png"}
            };
            return testIndividuals;
        }
    }
}
