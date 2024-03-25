using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class PolicySerializers : IPolicySerializer
    {
        public Task<Policy> GetPolicyfromJsonString(string policyJson)
        {
            
                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true,
                    Converters = {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
                };
                var result =   JsonSerializer.Deserialize<Policy>(policyJson,options);
                return Task.FromResult(result);
            
        }
    }
}