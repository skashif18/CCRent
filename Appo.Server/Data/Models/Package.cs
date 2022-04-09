namespace Appo.Server.Data.Models
{

    using Appo.Server.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;
    using static Appo.Server.Data.Validation.Package;
    public class Package : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxHeadingLenth)]
        public string Heading { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLenth)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }


    }
}
