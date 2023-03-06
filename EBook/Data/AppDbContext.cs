using EBook.Models;
using Microsoft.EntityFrameworkCore;

namespace EBook.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().HasKey(am => new
            {
                am.AuthorId,
                am.BookId 
            });
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Book).WithMany(am => am.Author_Book).HasForeignKey(m=>m.BookId);
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Author).WithMany(am => am.Author_Book).HasForeignKey(m => m.AuthorId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Author_Book { get; set; }
        public DbSet<PublishingHouse> PublishingHouse { get; set; }



    }
}
