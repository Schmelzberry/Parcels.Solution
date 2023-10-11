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
  }
}n