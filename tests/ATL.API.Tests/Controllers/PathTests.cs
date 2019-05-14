using ATLAPI.Models.Neo4j;
using ATLAPI.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;


namespace ATL.API.Tests.Controllers
{
    [TestFixture]
    public class PathTests
    {
        public readonly CityRepository _db;
        public IEnumerable<City> city;
    
        [Test]
        public void Returncities()
        {
           city = _db.GetAllCities().Result;
            

            foreach (var item in city)
            {
                //Assert.IsNotNull(item.Id);
                Assert.IsNotNull(item.iso);
                Assert.IsNotNull(item.Latitude);
                Assert.IsNotNull(item.Longitude);
                Assert.IsNotNull(item.Name);
                Assert.IsTrue(item.Port);
            }
        }
       
        //[Test]
        //public void Return_False_Path()
        //{
            
        //    var result = _db.FindShortestPathAsync().Result;
        //    Assert.IsFalse(result.ToString().Contains("aba"),"should be empty");
        //}

    }
}
