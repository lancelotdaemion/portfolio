using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Functions
{
    internal class Mutation
    {
        [GraphQLMetadata("addJedi")]
        public Jedi AddJedi(Jedi input)
        {
            return StarWarsDB.AddJedi(input);
        }

        [GraphQLMetadata("updateJedi")]
        public Jedi UpdateJedi(Jedi input)
        {
            return StarWarsDB.AddJedi(input);
        }

        [GraphQLMetadata("removeJedi")]
        public string AddJedi(int id)
        {
            return StarWarsDB.RemoveJedi(id);
        }
    }
}
