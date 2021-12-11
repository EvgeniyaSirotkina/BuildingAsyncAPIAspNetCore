using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeCollection.DAL.Entities
{
    [Table("Studios")]
    public class Studio
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string OriginalName { get; set; }

        [Required]
        public int YearOfFoundation { get; set; }

        [MaxLength(150)]
        public string PresidentName { get; set; }

        public string OriginalPresidentName { get; set; }
    }
}
