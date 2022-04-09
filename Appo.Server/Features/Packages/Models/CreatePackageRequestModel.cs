namespace Appo.Server.Features.Packages.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Appo.Server.Data.Validation.Package;
    public class CreatePackageRequestModel
    {

        [Required]
        [MaxLength(MaxHeadingLenth)]
        public string Heading { get; set; }

        [MaxLength(MaxDescriptionLenth)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; } 
    }
}
