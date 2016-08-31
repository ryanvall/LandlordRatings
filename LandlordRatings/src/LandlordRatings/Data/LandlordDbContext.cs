using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LandlordRatings.Models;
using LandlordRatings.Data;

namespace LandlordRatings.Data
{
    public class LandlordDbContext : DbContext
    {
        public LandlordDbContext(DbContextOptions<LandlordDbContext> options)
            : base(options)
        { }

        public DbSet<LandlordModel> Landlords { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
    }
}
