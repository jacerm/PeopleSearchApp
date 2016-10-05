namespace PeopleSearchApp.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PeopleSearchApp.DAL.PeopleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PeopleSearchApp.DAL.PeopleContext context)
        {
            List<Individual> individuals = new List<Individual>
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

            foreach (Individual individual in individuals)
            {
                context.Individuals.Add(individual);
            }
            context.SaveChanges();
        }
    }
}
