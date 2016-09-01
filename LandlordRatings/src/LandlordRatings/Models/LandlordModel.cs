using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandlordRatings.Models
{
    public enum landlordTypes { Individual, Company };

    public class LandlordModel
    {
        public int ID { get; set; }
        public landlordTypes Type { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public RatingModel Rating { get; set; }
    }
}
