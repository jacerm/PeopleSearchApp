using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchApp.Models;
using System.Collections.Generic;
using PeopleSearchApp.Controllers.API;
using System.Threading.Tasks;
using PeopleSearchApp.Interfaces;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;

namespace PeopleSearchApp.Tests
{
    [TestClass]
    public class IndividualsAPITest
    {
        private Mock<IIndividualRepository> individualRepository;
        private string query;
        private Individual person;

        [TestInitialize]
        public void Initialize()
        {
            query = "Jace";
            person = new Individual {
                ID = 0,
                FirstName = "Jace",
                LastName = "Milne",
                Age = 24,
                Address = "123 N St",
                Interests = "Volleyball",
                Picture = "/Content/avatart_male.png"
            };
            individualRepository = new Mock<IIndividualRepository>();
            individualRepository.Setup(x => x.GetAllIndividuals()).Returns(new List<Individual> {
                new Individual {
                    ID = 1
                },
                new Individual {
                    ID = 2
                }
            });

            individualRepository.Setup(x => x.GetSearchIndividuals("Jace")).Returns(new List<Individual> {
                new Individual {
                    ID = 1,
                    FirstName = "Jace",
                    LastName = "Milne",
                    Age = 24,
                    Address = "123 N St",
                    Interests = "Volleyball",
                    Picture = "/Content/avatart_male.png"
                }
            });

            individualRepository.Setup(x => x.AddIndividual(new Individual {
                ID = 0,
                FirstName = "Jace",
                LastName = "Milne",
                Age = 24,
                Address = "123 N St",
                Interests = "Volleyball",
                Picture = "/Content/avatart_male.png"
            }));
            individualRepository.Setup(x => x.Save());
        }

        [TestMethod]
        public void GetIndividuals_ReturnNonNullIndividuals()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.GetIndividuals();
            var dataResult = actionResult as OkNegotiatedContentResult<List<Individual>>;
            Assert.IsNotNull(dataResult);
        }

        [TestMethod]
        public void GetIndividuals_ReturnOkResultOfIndividuals()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.GetIndividuals();
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<List<Individual>>));
        }

        [TestMethod]
        public void GetSearchIndividuals_ReturnNonNullIndividuals()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.GetSearch(query);
            var dataResult = actionResult as OkNegotiatedContentResult<List<Individual>>;
            Assert.IsNotNull(dataResult);
        }

        [TestMethod]
        public void GetSearchIndividuals_ReturnOkResultOfIndividuals()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.GetSearch(query);
            var dataResult = actionResult as OkNegotiatedContentResult<List<Individual>>;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<List<Individual>>));
        }

        [TestMethod]
        public void GetSearchIndividuals_ReturnExpectedIndividuals()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.GetSearch(query);
            var dataResult = actionResult as OkNegotiatedContentResult<List<Individual>>;

            List<Individual> expectedResult = new List<Individual> {
                new Individual {
                    ID = 1,
                    FirstName = "Jace",
                    LastName = "Milne",
                    Age = 24,
                    Address = "123 N St",
                    Interests = "Volleyball",
                    Picture = "/Content/avatart_male.png"
                }
            };
            
            Assert.AreEqual(expectedResult[0].ID, dataResult.Content[0].ID);
        }

        [TestMethod]
        public void PostIndividuals_ReturnNonNullIndividual()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.PostIndividual(person);
            var dataResult = actionResult as OkNegotiatedContentResult<Individual>;
            Assert.IsNotNull(dataResult);
        }

        [TestMethod]
        public void PostIndividuals_ReturnOkResultOfIndividual()
        {
            IndividualsController controller = GetController(individualRepository);

            IHttpActionResult actionResult = controller.PostIndividual(person);
            var dataResult = actionResult as OkNegotiatedContentResult<Individual>;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Individual>));
        }

        public IndividualsController GetController(Mock<IIndividualRepository> individualRepository)
        {
            return new IndividualsController(individualRepository.Object);
        }
    }
}
