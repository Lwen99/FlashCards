using Microsoft.EntityFrameworkCore;
using FlashCards.Models;

namespace FlashCards.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Cards> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cards>().HasData
                (
                    new Cards
                    {
                        Id = 1, Question = "What is 1+1", Answer = "2" 
                    }

              
                );
        }
    }
}
