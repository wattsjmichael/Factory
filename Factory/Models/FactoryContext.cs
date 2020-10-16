using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public virtual DbSet<Engineer> Engineers {get; set;}
    public virtual DbSet<Machine> Machines {get; set;}
    public virtual DbSet<Expertise> Expertises {get; set;}

    public DbSet<EngineerMachine> EngineerMachine {get; set;}
    public DbSet<EngineerExpertise> EngineerExpertise {get; set;}

    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}