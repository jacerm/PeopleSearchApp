using PeopleSearchApp.DAL;
using PeopleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearchApp.Interfaces
{
    public interface IIndividualRepository
    {
        List<Individual> GetAllIndividuals();
        List<Individual> GetSearchIndividuals(string query);
        void AddIndividual(Individual person);
        void Save();
    }
}
