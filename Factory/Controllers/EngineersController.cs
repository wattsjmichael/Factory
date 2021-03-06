using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
      .Include(engineer => engineer.Machines)
      .ThenInclude(join => join.Machine)
      .Include(x=>x.Expertises)
      .ThenInclude(join=>join.Expertise)
      .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName"); //PatientName == Dropdown
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineer.EngineerId, MachineId = MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }

    [HttpPost]
    public ActionResult RemoveMachine(int EngineerMachineId)
    {
      EngineerMachine joinEntry = _db.EngineerMachine.FirstOrDefault(x => x.EngineerMachineId == EngineerMachineId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddExpertise(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      ViewBag.ExpertiseId = new SelectList(_db.Expertises, "ExpertiseId", "ExpertiseArea");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult AddExpertise(Engineer engineer, int ExpertiseId)
    {
      if (ExpertiseId != 0)
      {
        _db.EngineerExpertise.Add(new EngineerExpertise() { EngineerId = engineer.EngineerId, ExpertiseId = ExpertiseId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }
    [HttpPost]
    public ActionResult RemoveExpertise(int EngineerExpertiseId)
    {
      EngineerExpertise joinEntry = _db.EngineerExpertise.FirstOrDefault(x => x.EngineerExpertiseId == EngineerExpertiseId);
      _db.EngineerExpertise.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
