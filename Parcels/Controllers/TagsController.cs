using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Parcels.Models;

namespace Parcels.Controllers
{
  public class TagsController : Controller
  {
    private readonly ParcelsContext _db;
    public TagsController(ParcelsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Tag> allTags = _db.Tags.ToList();
      return View(allTags);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Tag newTag)
    {
      _db.Tags.Add(newTag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPackage(int id)
    {
      Tag tagToAddToPackage = _db.Tags.FirstOrDefault(databaseTags => databaseTags.TagId == id);
      ViewBag.PackageId = new SelectList(_db.Packages, "PackageId", "Description");
      return View(tagToAddToPackage);
    }

    [HttpPost]
    public ActionResult AddPackage(Tag tag, int packageId)
    {
#nullable enable
      PackageTag? joinEntity = _db.PackageTags.FirstOrDefault(join => (join.PackageId == packageId && join.TagId == tag.TagId));
#nullable disable
      if (joinEntity == null && packageId != 0)
      {
        _db.PackageTags.Add(new PackageTag() { TagId = tag.TagId, PackageId = packageId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = tag.TagId });
    }
    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags
                       .Include(tagToView => tagToView.JoinEntities)
                       .ThenInclude(establishRelationship => establishRelationship.Package)
                       .FirstOrDefault(tagToView => tagToView.TagId == id);
      return View(thisTag);
    }
    public ActionResult Edit(int id)
    {
      Tag tagToEdit = _db.Tags.FirstOrDefault(databaseTags => databaseTags.TagId == id);
      return View(tagToEdit);
    }
    
    [HttpPost]
    public ActionResult Edit(Tag tag)
    {
      _db.Tags.Update(tag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Tag tagToDelete = _db.Tags.FirstOrDefault(databaseTags => databaseTags.TagId == id);
      return View(tagToDelete);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Tag tagToDelete = _db.Tags.FirstOrDefault(databaseTags => databaseTags.TagId == id);
      _db.Tags.Remove(tagToDelete);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}