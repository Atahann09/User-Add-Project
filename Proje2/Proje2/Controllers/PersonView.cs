using Microsoft.AspNetCore.Mvc;
using Proje2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proje2.Controllers
{
    public class PersonView : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Person> persons = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59669/api/Proje/Veriler");
                //HTTP GET
                var responseTask = client.GetAsync("Person");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Person>>();
                    readTask.Wait();

                    persons = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    persons = Enumerable.Empty<Person>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(persons);
        }
    }
    }