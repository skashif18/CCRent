using System.ComponentModel.DataAnnotations;

namespace Appo.Server.Features.Identity.Models
{
    public class ForgetPwdModel
    {
        [Required]
        public string Email { get; set; }

    }
}
