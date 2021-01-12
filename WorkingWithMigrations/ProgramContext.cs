using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithMigrations.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WorkingWithMigrations
{
    public class ProgramContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public ProgramContext(DbContextOptions
        <ProgramContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(d => d.Title).IsRequired().HasMaxLength(512);
            modelBuilder.Entity<BookReview>().Property(x => x.ReviewerName).IsRequired();
            modelBuilder.Entity<Author>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Book>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
        }
    }
}
