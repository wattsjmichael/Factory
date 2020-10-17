using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db=db;
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      Dictionary<string, object> engineerMachineExpertise = new Dictionary<string, object>();
       List<Engineer> engineers = _db.Engineers.ToList();
       List<Machine> machines = _db.Machines.ToList();
       List<Expertise> expertises = _db.Expertises.ToList();
       engineerMachineExpertise.Add("engineers", engineers);
       engineerMachineExpertise.Add("machines", machines);
       engineerMachineExpertise.Add("expertises", expertises);
       return View(engineerMachineExpertise);
    }
  }
}