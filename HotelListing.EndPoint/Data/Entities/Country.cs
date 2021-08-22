using System;
using System.Collections.Generic;



namespace HotelListing.EndPoint.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Countrycode { get; set; }
        public string ShortName { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
    }
}