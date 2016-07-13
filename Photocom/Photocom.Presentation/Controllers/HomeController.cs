using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photocom.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EF();
            return View();
        }

        private void EF()
        {
            TestContext testContext = new TestContext();

            testContext.Entities.Add( new TestEntity() { Value = "How"});

            var hello = testContext.Entities.ToList();

            testContext.SaveChanges();
        }
    }

    public class TestContext : DbContext
    {
        public DbSet<TestEntity> Entities { get; set; } 
    }

    public class TestEntity
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }
    }
}