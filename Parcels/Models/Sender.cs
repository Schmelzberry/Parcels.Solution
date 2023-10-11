using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcels.Models
{
  public class Sender
  {
    public int SenderId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Package> Packages { get; set; }
  }
}