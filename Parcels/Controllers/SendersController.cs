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

    public ActionResult Index()
    {
      List<Sender> allSenders = _db.Senders.ToList();
      return View(allSenders);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Sender newSender)
    {
      _db.Senders.Add(newSender);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Sender targetSender = _db.Senders
                                .Include(senderToView => senderToView.Packages)
                                .FirstOrDefault(senderToView => senderToView.SenderId == id);
      return View(targetSender);
    }
    public ActionResult Edit(int id)
    {
      Sender targetSender = _db.Senders.FirstOrDefault(senderToEdit => senderToEdit.SenderId == id);
      return View(targetSender);
    }
    [HttpPost]
    public ActionResult Edit(Sender sender)
    {
      _db.Senders.Update(sender);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Sender targetSender = _db.Senders.FirstOrDefault(senderToDelete => senderToDelete.SenderId == id);
      return View(targetSender);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Sender targetSender = _db.Senders.FirstOrDefault(senderToDelete => senderToDelete.SenderId == id);
      _db.Senders.Remove(targetSender);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}