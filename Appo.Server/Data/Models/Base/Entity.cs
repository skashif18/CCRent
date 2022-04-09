namespace Appo.Server.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity:IEntity
    {
        public DateTime  CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModyfiedOn { get; set; }
        public string ModyfiedBy { get; set; }

    }
}
