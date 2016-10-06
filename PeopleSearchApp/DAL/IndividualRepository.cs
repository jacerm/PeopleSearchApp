using PeopleSearchApp.Interfaces;
using PeopleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearchApp.DAL
{
    public class IndividualRepository : IIndividualRepository
    {
        private PeopleContext db;

        public IndividualRepository(PeopleContext db)
        {
            this.db = db;
        }

        public List<Individual> GetAllIndividuals()
        {
            return db.Individuals.ToList();
        }

        public List<Individual> GetSearchIndividuals(string query)
        {
            return db.Individuals.Where(x => x.FirstName.Contains(query) || x.LastName.Contains(query)).ToList();
        }

        public void AddIndividual(Individual person)
        {
            db.Individuals.Add(person);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}