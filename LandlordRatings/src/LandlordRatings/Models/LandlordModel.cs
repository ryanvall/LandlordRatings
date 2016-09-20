using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), BindNever]
        public int LandlordID { get; set; }
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

        // reference to all ratings belonging to the landlord
        public virtual ICollection<RatingModel> Ratings { get; set; }

        // Properties for first and last name of the landlord (if individual, if Landlord is a company it just returns the name)
        public String FirstName
        {
            get
            {
                if (this.Type.ToString().Equals("Individual"))
                {
                    char[] delims = { ' ' };
                    return Name.Split(delims)[0];
                } else
                {
                    return Name;
                }
            }
        }

        public String LastName
        {
            get
            {
                if (this.Type.ToString().Equals("Individual"))
                {
                    char[] delims = { ' ' };
                    return Name.Split(delims)[1];
                } else
                {
                    return Name;
                }
            }
        }
    }
}
