using CopaFilmes.Models.Requests;
using CopaFilmes.Models;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Interfaces;
using System.Threading.Tasks;

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
        public async Task<WorldCup> Post([FromBody] WorldCupRequest worldCupRequest)
        {
            return await _worldCupService.Create(worldCupRequest.Movies);
        }
    }
}
