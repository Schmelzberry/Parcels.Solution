using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Parcels.Models;

namespace Parcels.Controllers
{
  public class PackagesController : Controller
  {
    private readonly ParcelsContext _db;
    public PackagesController(ParcelsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Package> model = _db.Packages.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Package entry) 
    {
      _db.Packages.Add(entry);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Package thisPackage = _db.Packages.FirstOrDefault(package => package.PackageId == id);
      return View(thisPackage);
    }
  }
}