using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FactoryList.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List <Machine> model = _db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine);
      if(EngineerId !=0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = machine.MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
      .Include(machine => machine.Engineers)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(machine=> machine.MachineId == id);
      return View(thisMachine);
    }
    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine=>machine.MachineId == id);
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine=> machine.MachineId == id);
      return View(thisMachine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine=>machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult addEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines=>machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "MachineId", "MachineName");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine(){EngineerId = EngineerId, MachineId = machine.MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult RemoveEngineer(int EngineerMachineId)
    {
      EngineerMachine joinEntry = _db.EngineerMachine.FirstOrDefault(x=>x.EngineerMachineId == EngineerMachineId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}