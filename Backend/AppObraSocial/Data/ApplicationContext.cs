using System;
using System.Collections.Generic;
using AppObraSocial.Models;
using Microsoft.EntityFrameworkCore;

namespace AppObraSocial.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Planes> Planes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("Clientes_pkey");

            entity.Property(e => e.IdPlan)
                .ValueGeneratedNever()
                .HasColumnName("id_plan");
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdPlanNavigation).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.IdPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente_plan");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("logs_pkey");

            entity.ToTable("logs");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Evento)
                .HasMaxLength(200)
                .HasColumnName("evento");
        });

        modelBuilder.Entity<Planes>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("Planes_pkey");

            entity.Property(e => e.IdPlan)
                .ValueGeneratedNever()
                .HasColumnName("id_plan");
            entity.Property(e => e.Cuota).HasColumnName("cuota");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
