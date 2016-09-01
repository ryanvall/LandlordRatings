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
                         Rating = null
                     },

                     new LandlordModel
                     {
                         Type = landlordTypes.Company,
                         Name = "Uptown",
                         City = "Cleveland",
                         State = "Ohio",
                         Zipcode = "44106",
                         Rating = null
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
