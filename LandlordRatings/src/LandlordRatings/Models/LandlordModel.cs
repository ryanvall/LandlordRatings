using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandlordRatings.Models
{
    public enum landlordTypes { Individual, Company };

    public class LandlordModel
    {
        private landlordTypes type { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string city { get; set; }
        private string state { get; set; }
        private string zipcode { get; set; }
        private RatingModel rating { get; set; }
    }
}
