using System.Collections.Generic;
using DigitalBookstoreManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace DigitalBookstoreManagement.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext() { }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BookManagement> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookManagement>()
                .HasOne(b=>b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookManagement>()
                .HasOne(b => b.Category)
                .WithMany()
                .HasForeignKey(b => b.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
