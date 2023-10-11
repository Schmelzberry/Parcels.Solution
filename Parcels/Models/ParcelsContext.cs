using Microsoft.EntityFrameworkCore;

namespace Parcels.Models
{
  public class ParcelsContext : DbContext
  {

  public ParcelsContext(DbContextOptions options) : base(options) { }
  }
}