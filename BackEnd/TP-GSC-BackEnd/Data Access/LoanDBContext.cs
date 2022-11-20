using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TP_GSC_BackEnd.Entities;

#nullable disable


namespace TP_GSC_BackEnd.Data_Access
{
    public class LoanDBContext: DbContext
    {
        public LoanDBContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Description)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .Property(c => c.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");



            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Person>()
                .Property(p => p.Email)
                .HasMaxLength(320);

            modelBuilder.Entity<Person>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(20);



            modelBuilder.Entity<Thing>()
                .Property(t => t.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Thing>()
              .Property(t => t.CreationDate)
              .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Thing>()
             .HasOne(t => t.Category);




        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set;  }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Loan> Loans { get; set; }

    }
}
