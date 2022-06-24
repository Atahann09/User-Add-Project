using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var prsn = new List<Person>
            {
                new Person(){Name="asd",Surname="asd",Adres="asd"},
                new Person(){Name="asd",Surname="asd",Adres="asd"}
            };
            return View(prsn);
        }
    }
}
