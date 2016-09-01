using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LandlordRatings.Models
{
    public class RatingModel
    {
        public int ID { get; set; }
        public int PriceScore { get; set; }
        public int PersonalityScore { get; set; }
        public int FlexibilityScore { get; set; }
        public int ResponsivenessScore { get; set; }
        public double OverallScore { get; set; }
        [StringLength(300, ErrorMessage = "Comments are limited to 300 characters.")]
        public string Comments { get; set; }
    }
}
