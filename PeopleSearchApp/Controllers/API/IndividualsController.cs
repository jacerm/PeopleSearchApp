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

namespace PeopleSearchApp.Controllers.API
{
    public class IndividualsController : ApiController
    {
        private List<Individual> testIndividuals = new List<Individual>();

        // Empty constructor for 'production'
        public IndividualsController() { }

        // Constructor used for testing, mocking individuals returned from db
        public IndividualsController(List<Individual> testIndividuals)
        {
            this.testIndividuals = testIndividuals;
        }

        private PeopleContext db = new PeopleContext();

        // GET: api/Individuals
        [HttpGet]
        public IHttpActionResult GetIndividuals()
        {
            List<Individual> individuals = db.Individuals.ToList();
            return Ok(individuals);
        }

        // GET: api/Individuals/Search/query
        [HttpGet]
        [Route("api/Individuals/Search/{query}")]
        public IHttpActionResult GetSearch(string query)
        {
            List<Individual> individuals = db.Individuals.Where(x => x.FirstName.Contains(query) || x.LastName.Contains(query)).ToList();
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
                db.Individuals.Add(person);
                db.SaveChanges();
            }
            else
            {

                return NotFound();
            }

            return Ok(person);
        }
    }
}