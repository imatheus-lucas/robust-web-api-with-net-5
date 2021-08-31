using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Manager.API.Models;
using Manager.Core.Exceptions;
using AutoMapper;
using Manager.Services.Interfaces;
using Manager.Services.DTOs;
using Manager.API.Utilities;

namespace Manager.API.Controllers

{
  [ApiController]
  [Route("v1/users")]
  public class UserController : ControllerBase
  {



    private readonly IMapper _mapper;

    private readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
      _mapper = mapper;
      _userService = userService;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create([FromBody] CreateUserModel user)
    {

      try
      {
        var userDTO = _mapper.Map<UserDTO>(user);
        var userCreated = await _userService.Create(userDTO);
        return Ok(new ResultModel
        {
          Message = "User created successfully",
          Data = userCreated,
          Success = true
        });

      }
      catch (DomainException ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicatioonErrorMessage());
      }
    }
  }
}