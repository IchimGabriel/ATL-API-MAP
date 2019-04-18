using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLAPI.Repositories
{
    public interface IGraphRepository
    {
        IDriver Driver { get; set; }
    }
}
