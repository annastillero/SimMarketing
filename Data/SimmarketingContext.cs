using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimMarketing.Models;

namespace SimMarketing.Data;

public partial class SimmarketingContext : DbContext
{
    public SimmarketingContext()
    {
    }

    public SimmarketingContext(DbContextOptions<SimmarketingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyInformation> CompanyInformations { get; set; }

    public virtual DbSet<InquiryInformation> InquiryInformations { get; set; }

    public virtual DbSet<ProductInformation> ProductInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=54.174.175.109;Initial Catalog=SIMMarketing;User ID=dbayadmin;Password=Aam@2006;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyInformation>(entity =>
        {
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LogicalDelete).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<InquiryInformation>(entity =>
        {
            entity.HasKey(e => e.InquiryInformationId).HasName("PK_Person");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LogicalDelete).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<ProductInformation>(entity =>
        {
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LogicalDelete).HasDefaultValueSql("((0))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
