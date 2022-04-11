namespace CoreBusiness.Base
{
    using System;
    public interface IEntity
    {
        public string CreationUserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastUpdateUserName { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
