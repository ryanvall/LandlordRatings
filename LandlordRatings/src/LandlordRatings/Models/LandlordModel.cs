using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandlordRatings.Models
{
    public enum landlordTypes
    { Individual = 0,
      Company = 1
    };

    public class LandlordModel
    {
        public int ID { get; set; }
        public landlordTypes Type { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public List<RatingModel> Ratings { get; set; }
    }
}
