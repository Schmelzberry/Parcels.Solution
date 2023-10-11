using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcels.Models 
{
  public class Package
  {
    public int PackageId { get; set; }
    public string Description { get; set; }
    // Dimensions 
    public int Height { get; set; } 
    public int Length { get; set; } 
    public int Weight { get; set; }    
    public int Width { get; set; } 
    // Connections to Other Models
    // public int SenderId { get; set; }
    // public Sender Sender { get; set; }
    // public List <PackageTag> JoinEntities { get; }
  }
}