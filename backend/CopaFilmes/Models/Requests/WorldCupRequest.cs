using CopaFilmes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Requests
{
    public class WorldCupRequest
    {
        public List<string> Movies { get; set; }
    }
}
