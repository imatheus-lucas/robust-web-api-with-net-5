using Manager.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Services.Interfaces
{
  public interface IUserService
  {
    Task<UserDTO> Create(UserDTO userDTO);
    Task<UserDTO> Update(UserDTO userDTO);
    Task Delete(long id);
    Task<UserDTO> Get(long id);
    Task<List<UserDTO>> Get();
    Task<List<UserDTO>> SearchByName(string name);
    Task<List<UserDTO>> SearchByEmail(string email);
    Task<List<UserDTO>> GetByEmail(string email);



  }
}