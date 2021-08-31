using System.ComponentModel.DataAnnotations;
namespace Manager.API.Models
{
  public class CreateUserModel
  {
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    [MaxLength(80, ErrorMessage = "Name cannot be longer than 80 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [MinLength(3, ErrorMessage = "Email must be at least 3 characters long.")]
    [MaxLength(180, ErrorMessage = "Email cannot be longer than 180 characters.")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    [MaxLength(80, ErrorMessage = "Password cannot be longer than 80 characters.")]
    public string Password { get; set; }
  }
}