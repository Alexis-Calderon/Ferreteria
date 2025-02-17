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
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category", "ferreteria");
            entity.HasKey(e => e.IdCategory);
            entity.Property(e => e.IdCategory).HasColumnName("id_category").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client", "ferreteria");
            entity.HasKey(e => e.IdClient);
            entity.Property(e => e.IdClient).HasColumnName("id_client").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").HasMaxLength(50);
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("NUMERIC");
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Address).HasColumnName("address").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
        });

        modelBuilder.Entity<Employee>(entity => {
            entity.ToTable("employee", "ferreteria");   
            entity.HasKey(e => e.IdEmployee);
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").HasMaxLength(30).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").HasMaxLength(30);
            entity.Property(e => e.JobPosition).HasColumnName("job_position").HasColumnType("TEXT").HasMaxLength(20);
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.HiringDate).HasColumnName("hiring_date").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
        });
    }
}