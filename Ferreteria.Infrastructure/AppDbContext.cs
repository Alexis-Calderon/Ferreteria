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
    public DbSet<Client> Clients { get; set; }

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

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client", "ferreteria");
            entity.HasKey(e => e.IdClient);
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").HasMaxLength(50);
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("NUMERIC");
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Address).HasColumnName("address").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("NUMERIC").HasDefaultValueSql("DATETIME('now')");
        });

    }
}