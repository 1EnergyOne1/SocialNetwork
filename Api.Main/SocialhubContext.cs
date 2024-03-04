using System;
using System.Collections.Generic;
using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Main;

public partial class SocialhubContext : DbContext
{
    public DbSet<User> User { get; set; }
    public SocialhubContext()
    {
    }

    public SocialhubContext(DbContextOptions<SocialhubContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=socialhub;Username=postgres;Password=Veo48764511", x => x.UseNodaTime());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
