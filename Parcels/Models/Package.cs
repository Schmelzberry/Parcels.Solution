using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcels.Models
{
  public class Package
  {
    public int PackageId { get; set; }
    [Required(ErrorMessage = "* You must describe Package.")]
    public string Description { get; set; }
    // Dimensions 
    [Required(ErrorMessage = "* You must specify Package Height.")]
    [Range(1, int.MaxValue, ErrorMessage = "* You must specify Package Height.")]
    public int? Height { get; set; }
    [Required(ErrorMessage = "* You must specify Package Length.")]
    [Range(1, int.MaxValue, ErrorMessage = "* You must specify Package Length.")]
    public int? Length { get; set; }
    [Required(ErrorMessage = "* You must specify Package Weight.")]
    [Range(1, int.MaxValue, ErrorMessage = "* You must specify Package Weight.")]
    public int? Weight { get; set; }
    [Required(ErrorMessage = "* You must specify Package Width.")]
    [Range(1, int.MaxValue, ErrorMessage = "* You must specify Package Width.")]
    public int? Width { get; set; }
    // Connections to Other Models
    public int SenderId { get; set; }
    public Sender Sender { get; set; }
    public List<PackageTag> JoinEntities { get; }
  }
}