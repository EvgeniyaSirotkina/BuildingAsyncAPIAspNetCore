using AnimeCollection.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeCollection.DAL.Interfaces
{
    public interface IAnimeCollectionRepository
    {
        IEnumerable<Anime> GetAnimeCollection();

        Task<IEnumerable<Anime>> GetAnimeCollectionAsync();

        Task<IEnumerable<Anime>> GetAnimeCollectionAsync(IEnumerable<Guid> animeIds);

        Task<Anime> GetAnimeAsync(Guid id);

        void AddAnime(Anime animeToAdd);

        Task<bool> SaveChangesAsync();
    }
}
