using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcels.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    public string Description { get; set; }
    public List<PackageTag> JoinEntities { get; }
  }
}