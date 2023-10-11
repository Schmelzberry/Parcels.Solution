using Microsoft.EntityFrameworkCore;

namespace Parcels.Models
{
  public class ParcelsContext : DbContext
  {
    public DbSet<Sender> Senders { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PackageTag> PackageTags { get; set; }

  public ParcelsContext(DbContextOptions options) : base(options) { }
  }
}