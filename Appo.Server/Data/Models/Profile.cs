namespace Appo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Validation.User;
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [MaxLength(MaxNameLenth)]
        public string Name { get; set; }
        public string MainPhotoUrl { get; set; }
        public string Website { get; set; }

        [MaxLength(MaxBiographyLenth)]
        public string Biography { get; set; }
        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
