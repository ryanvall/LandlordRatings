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
                         type = landlordTypes.Individual,
                         name = "David Rossi",
                         city = "Cleveland",
                         state = "Ohio",
                         zipcode = "44106",
                         rating = null
                     },

                     new LandlordModel
                     {
                         type = landlordTypes.Company,
                         name = "Uptown",
                         city = "Cleveland",
                         state = "Ohio",
                         zipcode = "44106",
                         rating = null
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
