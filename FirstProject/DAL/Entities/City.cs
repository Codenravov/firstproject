﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebProject.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}