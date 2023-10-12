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
      ViewBag.SenderId = new SelectList(_db.Senders, "SenderId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Package entry)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.SenderId = new SelectList(_db.Senders, "SenderId", "Name");
        return View(entry);
      }
      else
      {
        entry.Weight = 10;
        entry.Height = 10;
        entry.Length = 20;
        entry.Width = 25;
        _db.Packages.Add(entry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Package thisPackage = _db.Packages
                               .Include(packageToView => packageToView.Sender)
                               .Include(packageToView => packageToView.JoinEntities)
                               .ThenInclude(establishRelationship => establishRelationship.Tag)
                               .FirstOrDefault(package => package.PackageId == id);
      return View(thisPackage);
    }

    public ActionResult Edit(int id)
    {
      Package thisPackage = _db.Packages.FirstOrDefault(package => package.PackageId == id);
      ViewBag.SenderId = new SelectList(_db.Senders, "SenderId", "Name");
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

    public ActionResult AddTags(int id)
    {
      Package targetPackage = _db.Packages.FirstOrDefault(entry => entry.PackageId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Description");
      return View(targetPackage);
    }

    [HttpPost]
    public ActionResult AddTags(Tag selectedTag, Package selectedPkg)
    {
      #nullable enable
      PackageTag? joinEntity = _db.PackageTags.FirstOrDefault(join => (join.PackageId == selectedPkg.PackageId && join.TagId == selectedTag.TagId));
      #nullable disable
      if (joinEntity == null && selectedTag.TagId != 0)
      {
        _db.PackageTags.Add(new PackageTag() { TagId = selectedTag.TagId, PackageId = selectedPkg.PackageId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = selectedPkg.PackageId });
    }
  }
}