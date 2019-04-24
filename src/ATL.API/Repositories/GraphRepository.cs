using Microsoft.Extensions.Options;
using Neo4j.Driver.V1;

namespace ATLAPI.Repositories
{
    public class GraphRepository : IGraphRepository
    {
        private readonly Neo4j neo4J;
        public GraphRepository(IOptions<AtlSettings> options)
        {
            neo4J = options.Value.Neo4j;

            var url = neo4J.Uri;
            var user = neo4J.User;
            var password = neo4J.Password;

            Driver = GraphDatabase.Driver(url, AuthTokens.Basic(user, password));
        }
        public IDriver Driver { get; set; }
    }
}
