﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Kisiler
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adres { get; set; }
        public string CepNo { get; set; }
        public string Email { get; set; }
        public DateTime Tarih { get; set; }
    }
}
