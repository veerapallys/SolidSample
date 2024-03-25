using System.Threading.Tasks;

namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        public Task<Policy> GetPolicyfromJsonString(string policyJson);
    }   
}