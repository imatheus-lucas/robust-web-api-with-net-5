
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTOs;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
  public class UserService : IUserService
  {

    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public UserService(IMapper mapper, IUserRepository userRepository)
    {

    }
    public async Task<UserDTO> Create(UserDTO userDTO)
    {
      var userExist = await _userRepository.GetByEmail(userDTO.Email);
      if (userExist != null) throw new DomainException("User already exist");
      var user = _mapper.Map<User>(userDTO);
      user.Validate();

      var userCreated = await _userRepository.Create(user);
      return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task Delete(long id)
    {
      var user = await _userRepository.Get(id);
      if (user == null) throw new DomainException("User not found");
      await _userRepository.Delete(id);
    }
    public async Task<UserDTO> Get(long id)
    {
      var user = await _userRepository.Get(id);
      if (user == null) throw new DomainException("User not found");
      return _mapper.Map<UserDTO>(user);
    }
    public async Task<List<UserDTO>> Get()
    {
      var AllUsers = await _userRepository.Get();
      return _mapper.Map<List<UserDTO>>(AllUsers);
    }

    public async Task<List<UserDTO>> GetByEmail(string email)
    {
      var users = await _userRepository.GetByEmail(email);
      return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
      var users = await _userRepository.SearchByEmail(email);
      return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<List<UserDTO>> SearchByName(string name)
    {
      var users = await _userRepository.SearchByName(name);
      return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<UserDTO> Update(UserDTO userDTO)
    {
      var userExist = await _userRepository.Get(userDTO.Id);
      if (userExist == null) throw new DomainException("User not found");
      var user = _mapper.Map<User>(userDTO);
      user.Validate();

      var userUpdated = await _userRepository.Update(user);
      return _mapper.Map<UserDTO>(userUpdated);
    }
  }
}