namespace Appo.Server.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
