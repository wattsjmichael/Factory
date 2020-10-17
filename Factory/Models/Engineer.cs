using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Machines = new HashSet<EngineerMachine>();
      this.Expertises = new HashSet<EngineerExpertise>();
    }
    public int EngineerId { get; set;}
    public string EngineerName {get; set;}

    public string EngineerDate {get; set;}

    
    public ICollection<EngineerMachine> Machines {get;}
    public ICollection<EngineerExpertise> Expertises {get;}

  }
}