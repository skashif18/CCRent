namespace Appo.Server.Data.Models.Base
{
    using System;
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime? ModyfiedOn { get; set; }
        string ModyfiedBy { get; set; }
    }
}
