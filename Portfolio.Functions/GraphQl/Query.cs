using GraphQL;
using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Functions.GraphQl
{
    internal class Query
    {
        [GraphQLMetadata("ipsums")]
        public IEnumerable<LoremIpsum> Ipsums()
        {
            using (var db = new LoremIpsumContext())
            {
                var result = db.LoremIpsums.ToList();

                return result;
            }
        }

        [GraphQLMetadata("ipsum")]
        public LoremIpsum Ipsum(Guid id)
        {
            using (var db = new LoremIpsumContext())
            {
                var result = db.LoremIpsums.Where(li => li.Id == id).Single();

                return result;
            }
        }
    }
}
