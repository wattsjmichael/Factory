namespace Factory.Models
{
  public class EngineerExpertise
  {
    public int EngineerExpertiseId {get; set;}
    public int ExpertiseId {get; set;}
    public int EngineerId {get; set;}
    public Expertise Expertise {get; set;}
    public Engineer Engineer {get; set;}

    
  }
}