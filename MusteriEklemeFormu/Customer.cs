using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriEklemeFormu
{
    class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Adres { get; set; }
        public int DogumYili { get; set; }
        public string CepTel { get; set; }
        public string Email { get; set; }
        public DateTime Tarih { get; set; }

    }
}
