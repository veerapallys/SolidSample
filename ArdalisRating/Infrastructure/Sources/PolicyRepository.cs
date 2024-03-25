using System.IO;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class PolicyRepository : IPolicyRepository
    {
        public async Task<string> GetPolicy()
        {
           return await File.ReadAllTextAsync("policy.json");
        }
    }
}

