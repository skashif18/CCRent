using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Masters;

public class UserRole
{
    public int UserRoleId { get; set; }
    [Required(ErrorMessage = "Please enter role name")]
    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid role name ")]
    [StringLength(150, ErrorMessage = "Role name can contain only 150 characters")]
    public string RoleName { get; set; }
    [Required(ErrorMessage = "Please enter short description")]
    [RegularExpression("[a-zA-Z0-9_ ]*$", ErrorMessage = "Invalid short description ")]
    [StringLength(100, ErrorMessage = "Short description can contain only 100 characters")]
    public string ShortDescription { get; set; }
}

