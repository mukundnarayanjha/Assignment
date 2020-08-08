using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment.API.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public Guid MultiplexId { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        public Booking()
        {
            Id = default(Guid);
            CreatedDate = DateTime.Now;
        }
    }
}
