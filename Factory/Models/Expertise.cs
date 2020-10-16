using System.Collections.Generic;

namespace Factory.Models
{
  public class Expertise
  {
    public Expertise()
    {
      this.Engineers = new HashSet<EngineerExpertise>();
    }
    public int ExpertiseId {get; set;}
    public string ExpertiseArea {get; set;}

    public ICollection<EngineerExpertise> Engineers {get;}
  }
}
