using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATLAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATLAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly ICityRepository _db;

        public PathController(ICityRepository context)
        {
            _db = context;
        }

        /// <summary>
        /// Shortest Path from a city to city - hard coded cities for test
        /// </summary>
        /// <returns></returns>
        [Route("/api/shortpath")]
        [HttpGet]
        public async Task<IActionResult> GetShortesrPath()
        {
            var result = await _db.FindShortestPathAsync();
            return Ok(result);
        }

        /// <summary>
        /// Shortest Path using params
        /// </summary>
        /// <param name="departure">Dublin, Tralee</param>
        /// <param name="arrival">Liverpool</param>
        /// <param name="media">TRUCK / TRAIN / SHIP / BARGE</param>
        /// <param name="nrnodes"> int - e.g. 7 </param>
        /// <returns> List of Shortest Paths between cities</returns>
        [Route("/api/spath/{departure}/{arrival}/{media}/{nrnodes}")]
        [HttpGet]
        public async Task<IActionResult> GetSPath(string departure, string arrival, string media, int nrnodes)
        {
            var result = await _db.FindSPathAsync(departure, arrival, media, nrnodes);
            return Ok(result);
        }
    }
}