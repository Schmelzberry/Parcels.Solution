using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcels.Models 
{
  public class Package
  {
    public int PackageId { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int SenderId { get; set; }
    public Sender Sender { get; set; }
    public List <PackageTag> JoinEntities { get; }
  }
}