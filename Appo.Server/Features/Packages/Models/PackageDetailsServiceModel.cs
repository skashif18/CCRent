using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appo.Server.Features.Packages.Models
{
    public class PackageDetailsServiceModel:PackageListServiceModel
    {

        public string UserId { get; set; }

        public string UserName { get; set; }


    }
}
