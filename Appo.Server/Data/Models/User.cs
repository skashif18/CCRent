namespace Appo.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using Base;

    public class User:IdentityUser,IEntity
    {
        public Profile Profile { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModyfiedOn { get; set; }
        public string ModyfiedBy { get; set; }
        public IEnumerable<Package> Packages { get; } = new HashSet<Package>();
    }
}
