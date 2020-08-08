using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment.API.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid GenreId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid MultiplexId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Movie()
        {
            Id = default(Guid);
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
