using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeCollection.DAL.Entities
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string Alias { get; set; }

        public string OriginalAlias { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
