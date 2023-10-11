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
      entry.Description = "This is a placeholder description";
      entry.Weight = 10;
      entry.Height = 10;
      entry.Length = 20;
      entry.Width = 25;
      _db.Packages.Add(entry);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Package thisPackage = _db.Packages.FirstOrDefault(package => package.PackageId == id);
      return View(thisPackage);
    }

    public ActionResult Edit(int id)
    {
      Package thisPackage = _db.Packages.FirstOrDefault(package => package.PackageId == id);
      return View(thisPackage);
    }

    [HttpPost]
    public ActionResult Edit(Package package)
    {
      _db.Packages.Update(package);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Package thisPackage = _db.Packages.FirstOrDefault(package => package.PackageId == id);
      return View(thisPackage);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Package thisPackage = _db.Packages.FirstOrDefault(package => package.PackageId == id);
      _db.Packages.Remove(thisPackage);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}