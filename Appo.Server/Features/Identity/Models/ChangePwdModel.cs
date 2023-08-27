using System.ComponentModel.DataAnnotations;

namespace Appo.Server.Features.Identity.Models
{
    public class ChangePwdModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
