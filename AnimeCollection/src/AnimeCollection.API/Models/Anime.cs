using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeCollection.API.Models
{
    public class Anime
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }
    }
}
