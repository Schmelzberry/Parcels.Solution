using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcels.Models
{
  public class PackageTag
  {
    public int PackageTagId { get; set; }
    public int PackageId { get; set; }
    public Package Package { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
  }
}