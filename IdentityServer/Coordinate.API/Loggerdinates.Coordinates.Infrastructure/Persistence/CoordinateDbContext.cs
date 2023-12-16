using Loggerdinates.Coortinates.Domain.CoordinateAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Infrastructure.Persistence
{
    public class CoordinateDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Coordinate";

        public CoordinateDbContext(DbContextOptions<CoordinateDbContext> options): base(options)
        {
            
        }

        public DbSet<Coordinate> Coordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordinate>().ToTable("Coordinates",DEFAULT_SCHEMA);
            modelBuilder.Entity<Coordinate>().OwnsOne(o => o.CoordinateInformation).WithOwner();
            base.OnModelCreating(modelBuilder);
        }
    }
}
