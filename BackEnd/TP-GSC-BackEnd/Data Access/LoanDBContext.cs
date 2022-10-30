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
               
                
        }

        public DbSet<Category> Categories { get; set; }

    }
}
