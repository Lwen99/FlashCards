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

        public DbSet<Stack> Stacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Stack>().HasData
            //   (
            //       new Stack
            //       {
            //           StackId = 1,
            //           Name = "Stack1",
            //           Description="test"
            //       }


            //   );

        }
    }
}
