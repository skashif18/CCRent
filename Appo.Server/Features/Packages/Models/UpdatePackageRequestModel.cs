

namespace Appo.Server.Features.Packages.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Appo.Server.Data.Validation.Package;
    public class UpdatePackageRequestModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxHeadingLenth)]
        public string Heading { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLenth)]
        public string Description { get; set; }

  

    }
}
