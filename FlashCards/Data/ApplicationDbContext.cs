using Microsoft.EntityFrameworkCore;
using FlashCards.Models;

namespace FlashCards.Data
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

                    //new Cards
                    //{
                    //    Id = 1,
                    //    Question = "What is 2+1",
                    //    Answer = "3"
                    //},
                    //new Cards
                    //{
                    //    Id = 1,
                    //    Question = "What is 3+1",
                    //    Answer = "4"
                    //}
                );
        }
    }
}
