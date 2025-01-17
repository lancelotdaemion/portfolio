using Google.Protobuf.WellKnownTypes;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace Portfolio.Functions.GraphQl
{
    public class Server
    {
        private ISchema schema { get; set; }

        public Server()
        {
            //    type Mutation {
            //        addIpsum(input: IpsumInput): Ipsum
            //                            updateIpsum(input: IpsumInput): Ipsum
            //                            removeIpsum(id: ID): String
            //                          }

            schema = Schema.For(@"
                                  type Ipsum {
                                    id: ID,
                                    name: String,
                                    value: String
                                  }

                                  input IpsumInput {
                                    id: ID,
                                    name: String,
                                    value: String
                                  }

                                  type Query {
                                      ipsums: [Ipsum]
                                      ipsum(id: ID): Ipsum
                                  }", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
            });

        }

        public async Task<string> QueryAsync(string query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            });

            if (result.Errors != null)
            {
                return result.Errors[0].Message;
            }
            else
            {
                var value = ((ExecutionNode)result?.Data)?.ToValue();

                return System.Text.Json.JsonSerializer.Serialize(value);
                //return JsonConvert.SerializeObject(value);
            }
        }
    }
}
