using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandlordRatings.Models
{
    public class RatingModel
    {
        public int ID { get; set; }
        public int priceScore { get; set; }
        public int personalityScore { get; set; }
        public int flexibilityScore { get; set; }
        public int responsivenessScore { get; set; }
        public double overallScore { get; set; }
    }
}
