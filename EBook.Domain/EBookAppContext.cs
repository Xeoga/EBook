using EBook.Domain.Entities;
using EBook.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Domain
{
    public class EBookAppContext : DbContext
    {
        public EBookAppContext(DbContextOptions<EBookAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().HasKey(pm => new
            {
                pm.AuthorId,
                pm.BookId
            });

            modelBuilder.Entity<Author_Book>().HasOne(m => m.Author).WithMany(pm => pm.Author_Book).HasForeignKey(m => m.AuthorId);
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Book).WithMany(pm => pm.Author_Book).HasForeignKey(m => m.BookId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ULoginData> User { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Author_Book> Authors_Books { get; set; }
        //Posibil eroarea
        public DbSet<PublishingHouse> PublishingHouses { get; set; }



    }
}
