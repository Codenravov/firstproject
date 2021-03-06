﻿namespace MVCWebProjectDAL.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}