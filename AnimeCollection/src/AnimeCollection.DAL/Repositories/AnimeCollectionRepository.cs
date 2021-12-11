using AnimeCollection.DAL.Contexts;
using AnimeCollection.DAL.Entities;
using AnimeCollection.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeCollection.DAL.Repositories
{
    public class AnimeCollectionRepository : IAnimeCollectionRepository, IDisposable
    {
        private AnimeCollectionContext _context;

        public AnimeCollectionRepository(AnimeCollectionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAnime(Anime animeToAdd)
        {
            if (animeToAdd == null)
            {
                throw new ArgumentNullException(nameof(animeToAdd));
            }

            _context.Add(animeToAdd);
        }

        public async Task<Anime> GetAnimeAsync(Guid id)
            => await _context.AnimeCollection
                    .Include(a => a.Author)
                    .Include(a => a.Studio)
                    .FirstOrDefaultAsync(a => a.Id == id);

        public IEnumerable<Anime> GetAnimeCollection()
        {
            _context.Database.ExecuteSqlRaw("WAITFOR DELAY '00:00:02';");
            return _context.AnimeCollection
                    .Include(a => a.Author)
                    .Include(a => a.Studio);
        }

        public async Task<IEnumerable<Anime>> GetAnimeCollectionAsync()
        {
            await _context.Database.ExecuteSqlRawAsync("WAITFOR DELAY '00:00:02';");
            return await _context.AnimeCollection
                    .Include(a => a.Author)
                    .Include(a => a.Studio)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Anime>> GetAnimeCollectionAsync(IEnumerable<Guid> animeIds)
            => await _context.AnimeCollection.Where(a => animeIds.Contains(a.Id))
                .Include(a => a.Author).Include(a => a.Studio).ToListAsync();

        public async Task<bool> SaveChangesAsync()
            => (await _context.SaveChangesAsync() > 0);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
