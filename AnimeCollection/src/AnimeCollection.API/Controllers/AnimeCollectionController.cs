using AnimeCollection.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeCollection.API.Controllers
{
    [Route("api/animecollection")]
    [ApiController]
    public class AnimeCollectionController : ControllerBase
    {
        private readonly IAnimeCollectionRepository _animeCollectionRepository;

        public AnimeCollectionController(IAnimeCollectionRepository animeCollectionRepository)
        {
            _animeCollectionRepository = animeCollectionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimeCollection()
        {
            var animeCollection = await _animeCollectionRepository.GetAnimeCollectionAsync();
            return Ok(animeCollection);
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetAnime(Guid id)
        {
            var anime = await _animeCollectionRepository.GetAnimeAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }
    }
}
