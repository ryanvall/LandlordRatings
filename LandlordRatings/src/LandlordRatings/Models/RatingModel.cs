using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LandlordRatings.Models
{
    public class RatingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), BindNever]
        public int ID { get; set; }
        public int LandlordID { get; set; }
        // reference to landlord
        [ForeignKey("LandlordID")]
        public virtual LandlordModel Landlord { get; set; }
        [Required, Display(Name = "Price Score")]
        public int PriceScore { get; set; }
        [Required, Display(Name = "Personality Score")]
        public int PersonalityScore { get; set; }
        [Required, Display(Name = "Flexibility Score")]
        public int FlexibilityScore { get; set; }
        [Required, Display(Name = "Responsiveness Score")]
        public int ResponsivenessScore { get; set; }
        [StringLength(300, ErrorMessage = "Comments are limited to 300 characters."), Display(Name = "Additional Comments"), DataType(DataType.MultilineText)]
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
