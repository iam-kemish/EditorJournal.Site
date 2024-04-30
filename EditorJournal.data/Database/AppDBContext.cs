using EditorJournal.Modals;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EditorJournal.dataSet.Database
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
       
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Title = "Item 1",
                    Description = "Description for Item 1",
                    AuthorName = "Author 1",
                    Price = 40.00,
                    Genre = "Thriller",
                    ImageUrl = "hhtps//:Image1234"
                }
            );

            // Enable IDENTITY_INSERT for Items table
         
        }

    }
}