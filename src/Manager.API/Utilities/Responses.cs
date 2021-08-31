using System.Collections.Generic;
using Manager.API.Models;

namespace Manager.API.Utilities
{
  public static class Responses
  {
    public static ResultModel ApplicatioonErrorMessage()
    {
      return new ResultModel
      {
        Success = false,
        Message = "Application Error",
        Data = null
      };
    }

    public static ResultModel DomainErrorMessage(string message)
    {
      return new ResultModel
      {
        Success = false,
        Message = message,
        Data = null
      };
    }
    public static ResultModel DomainErrorMessage(string message, List<string> errors)
    {
      return new ResultModel
      {
        Success = false,
        Message = message,
        Data = errors
      };
    }
    public static ResultModel UnauthorizedErrorMessage()
    {
      return new ResultModel
      {
        Message = "Unauthorized",
        Success = false,
        Data = null
      };
    }
  }
}