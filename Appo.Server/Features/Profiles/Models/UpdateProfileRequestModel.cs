namespace Appo.Server.Features.Profiles.Models
{
    using Appo.Server.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Data.Validation.User;
    public class UpdateProfileRequestModel
    {

        [EmailAddress]
        public string Email { get; set; }
        public string  UserName { get; set; }

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
