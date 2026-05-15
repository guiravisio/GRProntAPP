using System.Threading.Tasks;
using GRProntAPP.Models;

namespace GRProntAPP.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(UserProfile user, string password);
    }
}
