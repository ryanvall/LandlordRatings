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
        public landlordTypes type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public RatingModel rating { get; set; }
    }
}
