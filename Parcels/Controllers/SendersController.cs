using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Parcels.Models;

namespace Parcels.Controllers
{
  public class SendersController : Controller
  {
    private readonly ParcelsContext _db;

    public SendersController(ParcelsContext db)
    {
      _db = db;
    }
  }
}