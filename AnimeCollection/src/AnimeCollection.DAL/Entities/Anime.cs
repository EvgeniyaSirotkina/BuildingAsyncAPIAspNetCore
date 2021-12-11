using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeCollection.DAL.Entities
{
    [Table("AnimeCollection")]
    public class Anime
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        [Required]
        [MaxLength(150)]
        public string DirectorName { get; set; }

        public string OriginalDirectorName { get; set; }

        public DateTime DateOfPremiere { get; set; }

        public int NumberOfSeries { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public Guid StudioId { get; set; }

        public Studio Studio { get; set; }
    }
}
