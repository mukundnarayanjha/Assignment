using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment.API.Models
{ 
    public class Multiplex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public int NoOfShowPerDay { get; set; } 
        public int TotalNumberOfSeats { get; set; }        
        public DateTime CreatedDate { get; set; }
        public Multiplex()
        {
            Id = default(Guid);
            NoOfShowPerDay = 1;
            TotalNumberOfSeats = 100;
            CreatedDate = DateTime.Now;
        }
    }
}
