using System;
using System.Collections.Generic;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.SocialhubContext;

public partial class SocialhubContext : DbContext
{
    public SocialhubContext()
    {
    }

    public SocialhubContext(DbContextOptions<SocialhubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mail> Mails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=socialhub;Username=postgres;Password=Veo48764511");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mails_pkey");

            entity.ToTable("mails");

            entity.HasIndex(e => e.FromUserId, "mails_from_user_id_idx");

            entity.HasIndex(e => e.ToUserId, "mails_to_user_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateSend).HasColumnName("date_send");
            entity.Property(e => e.FromUserId).HasColumnName("from_user_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ToUserId).HasColumnName("to_user_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Datecreate).HasColumnName("datecreate");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
