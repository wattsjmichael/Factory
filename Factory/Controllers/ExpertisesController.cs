using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class ExpertisesController : Controller
  {
    private readonly FactoryContext _db;

    public ExpertisesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List <Expertise> model = _db.Expertises.ToList();
      return View (model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Expertise expertise)
    {
      _db.Expertises.Add(expertise);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Expertise thisExpertise  = _db.Expertises
      .Include(expertise => expertise.Engineers)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(x => x.ExpertiseId == id);
      return View(thisExpertise);
    }

    public ActionResult Edit(int id)
    {
      Expertise thisExpertise = _db.Expertises.FirstOrDefault(x=>x.ExpertiseId == id);
      return View(thisExpertise);
    }

    [HttpPost]
    public ActionResult Edit(Expertise expertise)
    {
      _db.Entry(expertise).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Expertise thisExpertise = _db.Expertises.FirstOrDefault(x => x.ExpertiseId == id);
      return View(thisExpertise);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Expertise thisExpertise = _db.Expertises.FirstOrDefault(x => x.ExpertiseId ==id);
      _db.Expertises.Remove(thisExpertise);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult AddEngineer(int id)
    {
      Expertise thisExpertise = _db.Expertises.FirstOrDefault(x => x.ExpertiseId ==id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisExpertise);
    }
    [HttpPost]
    public ActionResult AddEngineer(Expertise expertise, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerExpertise.Add(new EngineerExpertise() { EngineerId = EngineerId, ExpertiseId = expertise.ExpertiseId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult RemoveEngineer(int EngineerExpertiseId)
    {
      EngineerExpertise joinEntry = _db.EngineerExpertise.FirstOrDefault(x => x.EngineerExpertiseId == EngineerExpertiseId);
      _db.EngineerExpertise.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index"); 
    }
  }
}