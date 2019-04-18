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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository db;

        public CityController(ICityRepository context)
        {
            db = context;
        }

        /// <summary>
        /// GET: api/City
        /// </summary>
        /// <returns>ALL CITIES AS NODES</returns> 
        [Route("/api/cities")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var city = await db.GetAllCities();
            return Ok(city.ToList());
        }


        /// <summary>
        /// GET: Conected by TRUCK Cities - neighbours
        /// </summary>
        /// <returns></returns>
        [Route("/api/neighbours")]
        [HttpGet]
        public async Task<IActionResult> GetConnectedCities()
        {
            var req = await db.TruckConnectedCityNeighbours();
            return Ok(req);
        }

        /// <summary>
        /// POST: Create New Node
        /// </summary>
        /// <param name="city"></param>
        /// <param name="iso"></param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="is_port"></param>
        /// <param name="turnaround"></param>
        /// <returns></returns>
        [Route("/api/create/{city}/{iso}/{lat}/{lng}/{is_port}/{turnaround}")]
        [HttpPost]
        public async Task<IActionResult> CreateNewNode(string city, string iso, float lat, float lng, bool is_port, int turnaround)
        {
            var req = db.CreateNode(city, iso, lat, lng, is_port, turnaround);
            await Task.Delay(0); // to silence warning
            return Ok(req);
        }

        /// <summary>
        /// Create Edge / Path between two Cities
        /// </summary>
        /// <param name="fromCity"></param>
        /// <param name="toCity"></param>
        /// <param name="media"></param>
        /// <param name="distance"></param>
        /// <param name="price"></param>
        /// <param name="cotwo"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        [Route("/api/create/edge/{fromCity}/{toCity}/{media}/{distance}/{price}/{cotwo}/{speed}")]
        [HttpPost]
        public async Task<IActionResult> CreateEdge(string fromCity, string toCity, string media, int distance, decimal price, float cotwo, int speed)
        {
            var req = db.CreateEdge(fromCity, toCity, media, distance, price, cotwo, speed);
            await Task.Delay(0); // to silence warning flag for async
            return Ok(req);
        }
    }
}