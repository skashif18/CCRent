namespace Appo.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Follow
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string FollowerId { get; set; }

        public User Follower { get; set; }

        public bool IsApproved { get; set; }



    }
}
