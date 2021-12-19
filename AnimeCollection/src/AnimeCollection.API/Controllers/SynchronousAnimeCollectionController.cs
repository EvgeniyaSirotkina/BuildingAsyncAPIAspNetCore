using AnimeCollection.API.Filters;
using AnimeCollection.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCollection.API.Controllers
{
    [Route("api/synchronousanimecollection")]
    [ApiController]
    public class SynchronousAnimeCollectionController : ControllerBase
    {
        private readonly IAnimeCollectionRepository _animeCollectionRepository;

        public SynchronousAnimeCollectionController(IAnimeCollectionRepository animeCollectionRepository)
        {
            _animeCollectionRepository = animeCollectionRepository;
        }

        [HttpGet]
        [AnimeCollectionResultFilter]
        public IActionResult GetAnimeCollection()
        {
            var animeCollection = _animeCollectionRepository.GetAnimeCollection();
            return Ok(animeCollection);
        }
    }
}
