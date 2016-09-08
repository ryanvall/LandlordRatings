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
        public int LandlordID { get; set; }
        [Required, Display(Name = "Price Score")]
        public int PriceScore { get; set; }
        [Required, Display(Name = "Personality Score")]
        public int PersonalityScore { get; set; }
        [Required, Display(Name = "Flexibility Score")]
        public int FlexibilityScore { get; set; }
        [Required, Display(Name = "Responsiveness Score")]
        public int ResponsivenessScore { get; set; }
        [StringLength(300, ErrorMessage = "Comments are limited to 300 characters."), Display(Name = "Additional Comments")]
        public string Comments { get; set; }

        [Display(Name = "Overall Score")]
        public double OverallScore
        {
            get
            {
                return Math.Round(((this.PriceScore + this.PersonalityScore + this.FlexibilityScore + this.ResponsivenessScore) / 4.0), 1);
            }
        }
    }
}
