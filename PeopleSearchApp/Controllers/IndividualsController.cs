using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeopleSearchApp.DAL;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Controllers
{
    public class IndividualsController : Controller
    {
        private PeopleContext db = new PeopleContext();

        // GET: Individuals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
