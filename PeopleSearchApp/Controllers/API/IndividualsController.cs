using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PeopleSearchApp.DAL;
using PeopleSearchApp.Models;
using PeopleSearchApp.Interfaces;

namespace PeopleSearchApp.Controllers.API
{
    public class IndividualsController : ApiController
    {
        private IIndividualRepository individualRepository;

        // Empty constructor for 'production'
        public IndividualsController()
        {
            this.individualRepository = new IndividualRepository(new PeopleContext());
        }

        // Constructor used for testing, mocking individuals returned from db
        public IndividualsController(IIndividualRepository individualRepository)
        {
            this.individualRepository = individualRepository;
        }

        // GET: api/Individuals
        [HttpGet]
        public IHttpActionResult GetIndividuals()
        {
            List<Individual> individuals = individualRepository.GetAllIndividuals();
            return Ok(individuals);
        }

        // GET: api/Individuals/Search/query
        [HttpGet]
        [Route("api/Individuals/Search/{query}")]
        public IHttpActionResult GetSearch(string query)
        {
            List<Individual> individuals = individualRepository.GetSearchIndividuals(query);
            if (individuals == null)
            {
                return NotFound();
            }

            return Ok(individuals);
        }

        // POST: api/Individuals/Create
        [HttpPost]
        [Route("api/Individuals/Create")]
        public IHttpActionResult PostIndividual(Individual person)
        {
            if (person.ID == 0)
            {
                if (person.Picture == null)
                {
                    person.Picture = "/Content/No_image.svg";
                }
                else
                {
                    person.Picture = person.Picture;
                }
                individualRepository.AddIndividual(person);
                individualRepository.Save();
            }
            else
            {

                return NotFound();
            }

            return Ok(person);
        }
    }
}