﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class SomeModels
    {
        public IEnumerable<Developer> Developer{ get; set; }
        public IEnumerable<Publisher> Publisher { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}
