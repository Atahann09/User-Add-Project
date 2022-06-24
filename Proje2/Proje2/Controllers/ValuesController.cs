using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje2.ApiPostParameters;
using Proje2.Data;
using Proje2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje2.Controllers
{
    [Route("api/Proje")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static ApplicationDbContext applicationDbContext;
        public ValuesController(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }



        [HttpPost("PersonKaydet")]
        public string PersonKaydet([FromBody] PersonGetParameter Parameters)
        {

            Person person1 = new Person();
            person1.Name = Parameters.Name;
            person1.Surname = Parameters.Surname;
            person1.Adres = Parameters.Adres;
            person1.CepNo = Parameters.CepTel;
            person1.PersonId = Guid.NewGuid();
            person1.Email = Parameters.Email;
            person1.Tarih = Parameters.Tarih;

            var UpdatedPerson = applicationDbContext.Person.Where(i => i.Name == Parameters.Name && i.Surname == Parameters.Surname && i.Adres == Parameters.Adres).FirstOrDefault();
            if (UpdatedPerson != null)
            {
                UpdatedPerson.CepNo = Parameters.CepTel;
                applicationDbContext.Person.Update(UpdatedPerson);
                applicationDbContext.SaveChanges();
                return "Kişi güncellemesi yapıldı !";
            }


            applicationDbContext.Person.Add(person1);
            applicationDbContext.SaveChanges();

            return "Kayıt işlemi başarılı";

        }

        [HttpGet("Veriler")]
        public List<Person> Veriler()
        {
            //lists Users
            using (var ApplicationDbContext = new ApplicationDbContext())
            {
                return ApplicationDbContext.Person.ToList();
            }
        }
      
        [HttpGet("Calculator")]
        public void Calculator()
        {
            //example
            Person person1 = new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Atahan",
                Surname = "Ateş"
            };

            applicationDbContext.Person.Add(person1);
            applicationDbContext.SaveChanges();

            Order order1 = new Order();
            order1.OrderId = Guid.NewGuid();
            order1.KursAdi = "asda";
            order1.Metod1 = "metodismisaa";
            order1.Metod2 = "14:46";
            order1.Metod3 = "15";
            order1.Metod4 = "15";
            order1.Metod5 = "15";
            order1.Metod6 = "15";
            order1.PersonId = person1.PersonId;
            applicationDbContext.Order.Add(order1);
            applicationDbContext.SaveChanges();


            Person person2 = new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Ali",
                Surname = "Demirtaş",

            };

            Person person3 = new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Kamill",
                Surname = "İşler",

            };

            applicationDbContext.Person.AddRange(person2, person3);
            applicationDbContext.SaveChanges();

            applicationDbContext.Person.RemoveRange(person2);
            applicationDbContext.SaveChanges();






        }
    }
}
