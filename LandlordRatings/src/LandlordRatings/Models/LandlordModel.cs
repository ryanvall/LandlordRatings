using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LandlordRatings.Models
{
    public enum LandlordTypes
    { Individual = 0,
      Company = 1
    };

    public class LandlordModel
    {
        public int ID { get; set; }
        [Required]
        public LandlordTypes Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required, DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        //reference to all ratings belonging to the landlord
        public virtual ICollection<RatingModel> Ratings { get; set; }
    }
}
