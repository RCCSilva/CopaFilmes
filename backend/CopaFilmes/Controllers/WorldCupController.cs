using CopaFilmes.Models.Requests;
using CopaFilmes.Models;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorldCupController: Controller
    {
        private readonly IWorldCupService _worldCupService;

        public WorldCupController(IWorldCupService worldCupService) {
            _worldCupService = worldCupService;
        }
        
        [HttpPost]
        public WorldCup Post([FromBody] WorldCupRequest worldCupRequest)
        {
            return _worldCupService.Create(worldCupRequest.Movies);
        }
    }
}
