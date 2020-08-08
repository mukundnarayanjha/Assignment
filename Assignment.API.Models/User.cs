using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment.API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }        
        public string UserName { get; set; }

        [Required]
        public string EmailId { get; set; }
        
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTimeOffset? LastLoggedInDate { get; set; }
        public bool IsActive { get; set; }
        public User()
        {
            Id = default(Guid);
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            IsActive = true;
        }
        //Foreign key for Role
        //public int RoleId { get; set; }
        //public Role Role { get; set; }
    }
}
