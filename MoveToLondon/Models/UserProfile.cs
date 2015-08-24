namespace MoveToLondon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
