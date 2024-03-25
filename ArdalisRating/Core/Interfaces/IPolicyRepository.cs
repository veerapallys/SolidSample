using System.Threading.Tasks;

namespace ArdalisRating{
    public interface IPolicyRepository
    {
        Task<string> GetPolicy();
    }
}
