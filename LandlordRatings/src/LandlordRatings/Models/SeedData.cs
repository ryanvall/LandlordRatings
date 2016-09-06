using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LandlordRatings.Data;
using LandlordRatings.Models;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LandlordDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LandlordDbContext>>()))
            {
                // Look for any landlords.
                if (context.Landlords.Any())
                {
                    return;   // DB has been seeded
                }

                context.Landlords.AddRange(
                     new LandlordModel
                     {
                         Type = landlordTypes.Individual,
                         Name = "David Rossi",
                         City = "Cleveland",
                         State = "Ohio",
                         Zipcode = "44106",
                         Ratings = new System.Collections.Generic.List<RatingModel>()
                     },

                     new LandlordModel
                     {
                         Type = landlordTypes.Company,
                         Name = "Uptown",
                         City = "Cleveland",
                         State = "Ohio",
                         Zipcode = "44106",
                         Ratings = new System.Collections.Generic.List<RatingModel>()
                     }
                );

                // Look for any ratings.
                if (context.Ratings.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ratings.AddRange(
                     new RatingModel
                     {
                         PriceScore = 3,
                         PersonalityScore = 4,
                         FlexibilityScore = 4,
                         ResponsivenessScore = 2,
                         Comments = "ok. rossi test",
                     },

                     new RatingModel
                     {
                         PriceScore = 2,
                         PersonalityScore = 4,
                         FlexibilityScore = 3,
                         ResponsivenessScore = 5,
                         Comments = "great! uptown test",
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
