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

                LandlordModel seed1 = new LandlordModel
                {
                    Type = LandlordTypes.Individual,
                    Name = "David Rossi",
                    City = "Cleveland",
                    State = "OH",
                    Zipcode = "44106",
                    Ratings = new System.Collections.Generic.List<RatingModel>()
                };

                LandlordModel seed2 = new LandlordModel
                {
                    Type = LandlordTypes.Company,
                    Name = "Uptown",
                    City = "Cleveland",
                    State = "OH",
                    Zipcode = "44106",
                    Ratings = new System.Collections.Generic.List<RatingModel>()
                };

                context.Landlords.AddRange(seed1, seed2);

                // Look for any ratings.
                if (context.Ratings.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ratings.AddRange(
                     new RatingModel
                     {
                         LandlordID = 1,
                         PriceScore = 3,
                         PersonalityScore = 4,
                         FlexibilityScore = 4,
                         ResponsivenessScore = 2,
                         Comments = "ok. rossi test",
                         Landlord = seed1
                     },

                     new RatingModel
                     {
                         LandlordID = 2,
                         PriceScore = 2,
                         PersonalityScore = 4,
                         FlexibilityScore = 3,
                         ResponsivenessScore = 5,
                         Comments = "great! uptown test",
                         Landlord = seed2
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
