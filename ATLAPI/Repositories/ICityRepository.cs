using ATLAPI.Models.Neo4j;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLAPI.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<IRecord>> GetAllCities();
        Task<IEnumerable<IRecord>> FindShortestPathAsync();
        Task<IEnumerable<IRecord>> TruckConnectedCityNeighbours();
        Task<IEnumerable<IRecord>> FindSPathAsync(string departureCity, string arrivalCity, string relation, int noNodes);
        Task<bool> CreateNode(string city, string iso, float lat, float lng, bool is_port, int turnaround);
        Task<bool> CreateEdge(string fromCity, string toCity, string media, int distance, decimal price, float cotwo, int speed);
    }
}
