
using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
namespace Manager.Infra.Context
{
  public class ManagerContext : DbContext
  {
    public ManagerContext() { }

    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
    {

    }

    //filed security string connection in code

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   optionsBuilder.UseNpgsql("Server=127.0.0.1; port=5438; user id = postgres; password = postgres; database=postgres; pooling = true");
    // }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
    }
  }
}