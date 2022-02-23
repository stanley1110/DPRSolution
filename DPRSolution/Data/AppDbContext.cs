using DPRSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace DPRSolution.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AutomobileOwner> AutomobileOwners { get; set; }
        public DbSet<StationOwner> StationOwners { get; set; }
        public DbSet<AutoFileDetail> FileDetails { get; set; }


    }
}
