using Microsoft.EntityFrameworkCore;
using backend.Models.Entities;

namespace backend.Data;

/// <summary>
/// EF Core DbContext for the application. Entities will be added in the next tasks.
/// </summary>
public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
  }

  public DbSet<Location> Locations => Set<Location>();
  public DbSet<Industry> Industries => Set<Industry>();
  public DbSet<Investor> Investors => Set<Investor>();
  public DbSet<Company> Companies => Set<Company>();
  public DbSet<CompanyInvestor> CompanyInvestors => Set<CompanyInvestor>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // location
    modelBuilder.Entity<Location>(entity =>
    {
      entity.ToTable("location");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.City).HasColumnName("city").IsRequired();
      entity.Property(e => e.State).HasColumnName("state");
      entity.Property(e => e.Country).HasColumnName("country").IsRequired();
      entity.Property(e => e.CreatedAt).HasColumnName("created_at");
      entity.Property(e => e.CreatedBy).HasColumnName("created_by");
      entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
      entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
    });

    // industry
    modelBuilder.Entity<Industry>(entity =>
    {
      entity.ToTable("industry");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Name).HasColumnName("name").IsRequired();
      entity.HasIndex(e => e.Name).IsUnique();
      entity.Property(e => e.CreatedAt).HasColumnName("created_at");
      entity.Property(e => e.CreatedBy).HasColumnName("created_by");
      entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
      entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
    });

    // investor
    modelBuilder.Entity<Investor>(entity =>
    {
      entity.ToTable("investor");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Name).HasColumnName("name").IsRequired();
      entity.HasIndex(e => e.Name).IsUnique();
      entity.Property(e => e.CreatedAt).HasColumnName("created_at");
      entity.Property(e => e.CreatedBy).HasColumnName("created_by");
      entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
      entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
    });

    // company
    modelBuilder.Entity<Company>(entity =>
    {
      entity.ToTable("company");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Name).HasColumnName("name").IsRequired();
      entity.Property(e => e.Products).HasColumnName("products");
      entity.Property(e => e.FoundingYear).HasColumnName("founding_year");
      entity.Property(e => e.TotalFunding).HasColumnName("total_funding");
      entity.Property(e => e.Arr).HasColumnName("arr");
      entity.Property(e => e.Valuation).HasColumnName("valuation");
      entity.Property(e => e.Employees).HasColumnName("employees");
      entity.Property(e => e.G2Rating).HasColumnName("g2_rating");
      entity.Property(e => e.IndustryId).HasColumnName("industry_id");
      entity.Property(e => e.LocationId).HasColumnName("location_id");
      entity.Property(e => e.CreatedAt).HasColumnName("created_at");
      entity.Property(e => e.CreatedBy).HasColumnName("created_by");
      entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
      entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

      entity.HasOne(e => e.Industry)
        .WithMany(i => i.Companies)
        .HasForeignKey(e => e.IndustryId);

      entity.HasOne(e => e.Location)
        .WithMany(l => l.Companies)
        .HasForeignKey(e => e.LocationId);
    });

    // company_investor (many-to-many join)
    modelBuilder.Entity<CompanyInvestor>(entity =>
    {
      entity.ToTable("company_investor");
      entity.HasKey(ci => new { ci.CompanyId, ci.InvestorId });
      entity.Property(e => e.CompanyId).HasColumnName("company_id");
      entity.Property(e => e.InvestorId).HasColumnName("investor_id");

      entity.HasOne(ci => ci.Company)
        .WithMany(c => c.Investors)
        .HasForeignKey(ci => ci.CompanyId)
        .OnDelete(DeleteBehavior.Cascade);

      entity.HasOne(ci => ci.Investor)
        .WithMany(i => i.CompanyInvestments)
        .HasForeignKey(ci => ci.InvestorId)
        .OnDelete(DeleteBehavior.Cascade);
    });
  }
}
