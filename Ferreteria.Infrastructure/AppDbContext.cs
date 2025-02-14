using System;

using Ferreteria.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ferreteria.Infrastructure;

public class AppDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnectionString"));
        }
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category", "ferreteria");
            entity.HasKey(e => e.IdCategory);
            entity.Property(e => e.IdCategory).ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255).IsRequired();
        });
    }
}
