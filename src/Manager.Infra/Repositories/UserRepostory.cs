using Manager.Infra.Context;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using System.Linq;
namespace Manager.Infra.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {

    private readonly ManagerContext _context;
    public UserRepository(ManagerContext context) : base(context)
    {
      _context = context;
    }

    public async Task<UserRepository> GetByEmail(string email)
    {
      var user = await _context.Users
              .Where(x => x.Email.ToLower() == email.ToLower())
              .AsNoTracking()
              .ToListAsync()
              .FirstOrDefaultAsync();
      return user;
    }

    public async Task<List<User>> SearchByEmail(string email)
    {
      var AllUsers = await _context.Users
            .Where(x => x.Email.ToLower().Contains(email.ToLower()))
            .AsNoTracking()
            .ToListAsync();

      return AllUsers;
    }

    public async Task<List<User>> SearchByName(string name)
    {
      var AllUsers = await _context.Users
          .Where(x => x.Name.ToLower().Contains(name.ToLower()))
          .AsNoTracking()
          .ToListAsync();

      return AllUsers;
    }
  }
}