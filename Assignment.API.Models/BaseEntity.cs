using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment.API.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        protected BaseEntity()
        {
            InitializeBaseEntityState();
        }

        protected void InitializeBaseEntityState()
        {
            Id = default(Guid);
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
