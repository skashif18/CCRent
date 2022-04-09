namespace Appo.Server.Features.Profiles.Models
{
    using Appo.Server.Data.Models;
    public class ProfileServiceModel
    {
      
        public string Name { get; set; }
        public string MainPhotoUrl { get; set; }
        public bool IsPrivate{ get; set; }
    }
}
