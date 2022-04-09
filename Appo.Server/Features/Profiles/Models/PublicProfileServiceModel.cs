using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appo.Server.Features.Profiles.Models
{
    public class PublicProfileServiceModel : ProfileServiceModel
    {
        public string Website { get; set; }
        public string Biography { get; set; }
        public string Gender { get; set; }
    }
}
