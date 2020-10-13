using CopaFilmes.Builders;
using CopaFilmes.Domain.Requests;
using CopaFilmes.Models;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorldCupController: Controller
    {
        private WorldCupService _worldCupService = new WorldCupService();
        
        [HttpPost]
        public WorldCup Post([FromBody] WorldCupRequest worldCupRequest)
        {
            return _worldCupService.Create(worldCupRequest.Movies);
        }
    }
}
